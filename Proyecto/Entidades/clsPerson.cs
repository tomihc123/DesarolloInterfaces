using Microsoft.OData.Edm;
using NPOI.SS.Util;
using System;
using System.Globalization;

namespace Entidades
{
    public class clsPerson
    {

        #region Properties 

        public int id { get; set; }
        public string name { get; set; } 
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public int iddepartamento { get; set; }
        #endregion

        #region Constructors 
        //Constructor por defecto
        public clsPerson()
        {
            name = "tomi";
            lastName = "el venerable immortal";
            birthDate = DateTime.Parse("2000-01-01");
            phoneNumber = "654121212";
            address = "Avenida";
            iddepartamento = 1;
        }


        //Constructor con parametros
        public clsPerson(string name, string lastName, DateTime birthDate, string phoneNumber, string address, int iddepartamento)
        {
            this.name = name;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.iddepartamento = iddepartamento;
        }


        //Constructor con parametros
        public clsPerson(int id, string name, string lastName, DateTime birthDate, string phoneNumber, string address, int iddepartamento)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.iddepartamento = iddepartamento;
        }
        #endregion
    }
}
