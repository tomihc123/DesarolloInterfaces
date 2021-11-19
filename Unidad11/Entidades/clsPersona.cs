using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class clsPersona
    {

        #region Properties 
        public string name { get; set; }
        public string lastName { get; set; }
        public string birthDate { get; set; }
        public int phoneNumber { get; set; }
        public string address { get; set; }
        #endregion

        #region Constructors 
        //Constructor por defecto
        public clsPersona()
        {

        }


        //Constructor con parametros
        public clsPersona(string name, string lastName, string birthDate, int phoneNumber, string address)
        {
            this.name = name;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }
        #endregion

    }
}
