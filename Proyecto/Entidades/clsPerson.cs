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
        public string name { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Apellido muy largo")]
        public string lastName { get; set; }
        [Required]
        public DateTime birthDate { get; set; }
        [Required]
        [RegularExpression(@"^^(?:6[0-9]|7[1-9])[0-9]{7}$")]
        public string phoneNumber { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Direccion muy larga")]
        public string address { get; set; }
        public string image { get; set; }
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
