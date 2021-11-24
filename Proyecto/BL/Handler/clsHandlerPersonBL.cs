using Dal.Handler;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Handler
{
    public class clsHandlerPersonBL
    {

        public int updatePerson(clsPerson person)
        {
            return new clsHandlerPersonDal().updatePerson(person);
        }


        public int insertPerson(clsPerson person)
        {
            return new clsHandlerPersonDal().insertPerson(person);
        }

        public int deletePerson(int id)
        {

            return new clsHandlerPersonDal().deletePerson(id);

        }


    }
}
