using System;

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
            this.name = "John";

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

        public override string ToString()
        {
            return name;
        }
    }


}
