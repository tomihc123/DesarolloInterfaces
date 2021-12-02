using BL.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models
{
    public class PersonWithDepartamentName : clsPerson
    {

        #region Properties 
        [DisplayName("Departamento")]
        public String departamentname { get; set; }
        #endregion


        public PersonWithDepartamentName(clsPerson clsPerson) : base(clsPerson)
        {
            this.id = clsPerson.id;
            this.name = clsPerson.name;
            this.lastName = clsPerson.lastName;
            this.birthDate = clsPerson.birthDate;
            this.phoneNumber = clsPerson.phoneNumber;
            this.address = clsPerson.address;
            this.image = clsPerson.image;
            this.departamentname = new clsDepartamentListBL().getNameDepartamentById(clsPerson.iddepartamento);

        }


    }
}
