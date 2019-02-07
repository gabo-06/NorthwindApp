using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        northwindEntities contexto = new northwindEntities();

        public ActionResult Index(string nombre = "", string cantidad = "")
        {
            List<Products> productos = new List<Products>();

            if (nombre != "" && cantidad != "")
            {
                var productosTemp = from p in contexto.Products
                                where p.ProductName == nombre &&
                                    p.QuantityPerUnit == cantidad
                                select p;

                productos = productosTemp.ToList(); 
            }

            return View(productos.ToList());
        }
    }
}