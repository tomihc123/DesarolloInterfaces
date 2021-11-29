using Dal.Handler;
using Dal.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Lists
{
    public class clsPersonListBL
    {

        public List<clsPerson> getPersons()
        {

            return new clsPersonListDal().getPersons();

        }

        public clsPerson getPerson(int id)
        {
            return new clsPersonListDal().getPerson(id);
        }




    }
}
