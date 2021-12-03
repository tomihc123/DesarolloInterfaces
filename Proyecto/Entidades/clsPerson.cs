using Microsoft.OData.Edm;
using NPOI.SS.Util;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Entidades
{
    public class clsPerson
    {

        #region Properties 
        public int id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Nombre muy largo")]
        [DisplayName("Nombre")]
        public string name { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Apellido muy largo")]
        [DisplayName("Apellidos")]
        public string lastName { get; set; }
        [Required]
        [DisplayName("Fecha de nacimiento")]
        public DateTime birthDate { get; set; }
        [Required]
        [RegularExpression(@"^^(?:6[0-9]|7[1-9])[0-9]{7}$")]
        [DisplayName("Móvil")]
        public string phoneNumber { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Direccion muy larga")]
        [DisplayName("Dirección")]
        public string address { get; set; }
        [DisplayName("Url Imagen")]
        public string image { get; set; }
        public int iddepartamento { get; set; }
        #endregion

        #region Constructors 
        //Constructor por defecto
        public clsPerson()
        {

        }

        //Constructor con parametros
        public clsPerson(string name, string lastName, DateTime birthDate, string phoneNumber, string address, string image, int iddepartamento)
        {
            this.name = name;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.image = image;
            this.iddepartamento = iddepartamento;
        }

        
        public clsPerson(clsPerson clsPerson)
        {
            this.name = clsPerson.name;
            this.lastName = clsPerson.lastName;
            this.birthDate = clsPerson.birthDate;
            this.phoneNumber = clsPerson.phoneNumber;
            this.address = clsPerson.address;
            this.image = clsPerson.image;
            this.iddepartamento = clsPerson.iddepartamento;
        }


        //Constructor con parametros
        public clsPerson(int id, string name, string lastName, DateTime birthDate, string phoneNumber, string address, string image,  int iddepartamento)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.image = image;
            this.iddepartamento = iddepartamento;
        }
        #endregion
    }
}
