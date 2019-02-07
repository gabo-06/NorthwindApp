using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class EmployeeP
    {
        public int EmployeeID { get; set; }

        private string firstName;
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        [DisplayName("EMPLEADO")]
        public string NombreCompleto
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}