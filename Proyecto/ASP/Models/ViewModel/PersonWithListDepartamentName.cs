using BL.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models
{
    public class PersonWithListDepartamentName
    {

        #region Properties 
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }

        public string image { get; set; }
        public int iddepartamento { get; set; }
        public List<clsDepartament> departaments{ get; set; }
        #endregion

       public PersonWithListDepartamentName()
        {

            this.departaments = new clsDepartamentListBL().getDepartaments();

        }

        public PersonWithListDepartamentName(clsPerson clsPerson)
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
