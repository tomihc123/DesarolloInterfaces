using Dal.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Lists
{
    public class clsDepartamentListBL
    {


        public List<clsDepartament> getDepartaments()
        {

            return new clsDepartamentListDal().getDepartaments();


        }

        public String getNameDepartamentById(int id)
        {

            return new clsDepartamentListDal().getNameDepartamentById(id);

        }

        public List<String> getNameDepartaments()
        {
            return new clsDepartamentListDal().getNameDepartaments();
        }

    }
}
