using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class OrderController : Controller
    {
        northwindEntities contexto = new northwindEntities();
        List<OrderP> ordenes = new List<OrderP>();
        List<OrderP> ordenesTemporal = new List<OrderP>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dataOrdenes()
        {
            try
            {
                #region Variables
                List<OrderP> ordenesTemporal = null;
                string search = Request.Form.GetValues("search[value]")[0];
                string draw = Request.Form.GetValues("draw")[0];
                string order = Request.Form.GetValues("order[0][column]")[0];
                string orderDir = Request.Form.GetValues("order[0][dir]")[0];
                int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
                int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
                #endregion
                #region Obtención de data
                if (ordenes.Count == 0)
                {
                    this.ordenes = (from o in contexto.Orders
                                    select new OrderP
                                    {
                                        orderID = o.OrderID,
                                        customer = new CustomerP { CustomerID = o.Customers.CustomerID, CompanyName = o.Customers.CompanyName },
                                        orderDate = o.OrderDate,
                                        requiredDate = o.RequiredDate,
                                        shippedDate = o.ShippedDate,
                                        shipName = o.ShipName,
                                        shipAddress = o.ShipAddress,
                                        shipCity = o.ShipCity,
                                        shipRegion = o.ShipRegion,
                                        shipPostalCode = o.ShipPostalCode,
                                        shipCountry = o.ShipCountry,
                                        employee = new EmployeeP { EmployeeID = o.Employees.EmployeeID, FirstName = o.Employees.FirstName, LastName = o.Employees.LastName },
                                        shipper = new ShipperP { ShipperID = o.Shippers.ShipperID, CompanyName = o.Shippers.CompanyName },
                                        freight = o.Freight
                                    }).ToList();
                }
                #endregion
                #region Cantidad de registros totales.
                int recordsTotal = ordenes.Count;
                #endregion
                #region Clona la data en la variable temporal que se va a utilizar para manipular las búsquedas.
                if (search.Trim() == "" || ordenesTemporal.Count == 0)
                    ordenesTemporal = this.ordenes;
                #endregion
                #region Filtrado
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    ordenesTemporal = ordenes.Where(o => o.customer.CompanyName.ToString().ToLower().Contains(search.Replace(" ", "").ToLower()) ||
                                                         o.shipName.ToString().ToLower().Contains(search.Replace(" ", "").ToLower()) ||
                                                         o.shipAddress.ToString().ToLower().Contains(search.Replace(" ", "").ToLower()) ||
                                                         o.shipCity.ToString().ToLower().Contains(search.Replace(" ", "").ToLower()) ||
                                                         o.shipRegion.ToString().ToLower().Contains(search.Replace(" ", "").ToLower()) ||
                                                         o.shipCountry.ToString().ToLower().Contains(search.Replace(" ", "").ToLower()) ||
                                                         o.shipPostalCode.ToString().ToLower().Contains(search.Replace(" ", "").ToLower())).ToList();
                }
                #endregion
                #region Ordenación.
                // ordenesTemporal = this.sor
                #endregion
                #region Obtiene cantidad de registro filtrados.
                int recordsFiltered = ordenesTemporal.Count;
                #endregion
                #region Aplica la paginación.
                ordenesTemporal = ordenesTemporal.Skip(startRec).Take(pageSize).ToList();
                #endregion

                return Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotoal = recordsTotal,
                    recordsFiltered = recordsFiltered,
                    data = ordenesTemporal
                },
                JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* 
         private List<OrderP> sortByColumnWithOrder(string order, string orderDir, List<OrderP> data)
         {
             // Initialization.
             // List<SalesOrderDetail> lst = new List<SalesOrderDetail>();

             try
             {
                 // Sorting
                 switch (order)
                 {
                     case "1":
                         // Setting.
                         data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ClaimNumber).ToList()
                                                                                                  : data.OrderBy(p => p.ClaimNumber).ToList();
                         break;
                     case "3":
                         // Setting.
                         data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Patient).ToList()
                                                                                                  : data.OrderBy(p => p.Patient).ToList();
                         break;
                     case "5":
                         // Setting.
                         data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Insurer).ToList()
                                                                                                  : data.OrderBy(p => p.Insurer).ToList();
                         break;
                     case "6":
                         // Setting.
                         data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.AccidentDate).ToList()
                                                                                                  : data.OrderBy(p => p.AccidentDate).ToList();
                         break;
                     case "7":
                         // Setting.
                         data = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                  : data.OrderBy(p => p.Status).ToList();
                         break;
                 }
             }
             catch (Exception ex)
             {
                 // info.
                 Console.Write(ex);
             }

             // info.
             return data;
         }
      */
    }
}