using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class OrderP
    {
        public int orderID { get; set; }

        // public string CustomerID { get; set; }

        // public Nullable<int> EmployeeID { get; set; }

        [DisplayName("FECHA DE ORDEN")]
        public Nullable<System.DateTime> orderDate { get; set; }
        
        [DisplayName("FECHA REQUERIDA")]
        public Nullable<System.DateTime> requiredDate { get; set; }
        
        [DisplayName("FECHA DE ENVIO")]
        public Nullable<System.DateTime> shippedDate { get; set; }

        // public Nullable<int> ShipVia { get; set; }

        [DisplayName("FLETE")]
        public Nullable<decimal> freight { get; set; }

        /// <summary>
        ///   Nombre de la persona o empresa que recibe el envío.
        /// </summary>
        [DisplayName("DESTINO (PERSONA/EMPRESA)")]
        public string shipName { get; set; }

        [DisplayName("DIRECCION DE ENVIO")]
        public string shipAddress { get; set; }

        [DisplayName("CIUDAD DE ENVIO")]
        public string shipCity { get; set; }

        [DisplayName("REGION DE ENVIO")]
        public string shipRegion { get; set; }

        [DisplayName("CODIGO POSTAL")]
        public string shipPostalCode { get; set; }

        [DisplayName("PAIS DE ENVIO")]
        public string shipCountry { get; set; }

        public virtual CustomerP customer { get; set; }
        public virtual EmployeeP employee { get; set; }
        public virtual ICollection<Order_Details> Order_Details { get; set; }
        public virtual ShipperP shipper { get; set; }

    }
}