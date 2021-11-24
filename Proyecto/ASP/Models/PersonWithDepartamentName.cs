﻿using BL.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models
{
    public class PersonWithDepartamentName
    {

        #region Properties 

        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public String departamentname { get; set; }
        #endregion


        public PersonWithDepartamentName(clsPerson clsPerson)
        {
            this.id = clsPerson.id;
            this.name = clsPerson.name;
            this.lastName = clsPerson.lastName;
            this.birthDate = clsPerson.birthDate;
            this.phoneNumber = clsPerson.phoneNumber;
            this.address = clsPerson.address;
            this.departamentname = new clsDepartamentListBL().getNameDepartamentById(clsPerson.iddepartamento);

        }


    }
}
