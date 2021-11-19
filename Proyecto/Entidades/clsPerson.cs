using System;

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
        #endregion
    }
}
