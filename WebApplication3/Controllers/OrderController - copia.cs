using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using PagedList;

namespace WebApplication3.Controllers
{
    public class OrderController : Controller
    {
        northwindEntities contexto = new northwindEntities();

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            var ordenes = from o
                          in contexto.Orders
                          select new OrderP
                          {
                              // OrderID = o.OrderID,
                              customer = new CustomerP
                              {
                                  CustomerID = o.Customers.CustomerID,
                                  CompanyName = o.Customers.CompanyName
                              },
                              OrderDate = o.OrderDate,
                              requiredDate = o.RequiredDate,
                              shippedDate = o.ShippedDate,
                              shipName = o.ShipName,
                              shipAddress = o.ShipAddress,
                              shipCity = o.ShipCity,
                              shipRegion = o.ShipRegion,
                              shipPostalCode = o.ShipPostalCode,
                              shipCountry = o.ShipCountry,
                              employee = new EmployeeP
                              {
                                  EmployeeID = o.Employees.EmployeeID,
                                  FirstName = o.Employees.FirstName,
                                  LastName = o.Employees.LastName
                              },
                              shipper = new ShipperP
                              {
                                  ShipperID = o.Shippers.ShipperID,
                                  CompanyName = o.Shippers.CompanyName
                              },
                              freight = o.Freight
                          };

            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            // return View(ordenes.ToList());
            return View(ordenes.OrderBy(i => i.customer.CustomerID).ToPagedList(pageIndex, pageSize));
        }
    }
}