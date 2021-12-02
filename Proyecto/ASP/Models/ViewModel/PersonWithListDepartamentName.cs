using BL.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models
{
    public class PersonWithListDepartamentName : clsPerson
    {

        #region
        public List<clsDepartament> departaments{ get; set; }
        #endregion

       public PersonWithListDepartamentName()
        {

            this.departaments = new clsDepartamentListBL().getDepartaments();

        }

        public PersonWithListDepartamentName(clsPerson clsPerson) : base(clsPerson)
        {
            this.name = clsPerson.name;
            this.lastName = clsPerson.lastName;
            this.birthDate = clsPerson.birthDate;
            this.phoneNumber = clsPerson.phoneNumber;
            this.address = clsPerson.address;
            this.image = clsPerson.image;
            this.iddepartamento = clsPerson.iddepartamento;
            this.departaments = new clsDepartamentListBL().getDepartaments();

        }

    }
}
