using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class clsDepartament
    {

        #region Properties
        public int id { get; set; }
        public string name { get; set; }
        #endregion

        #region Constructors
        public clsDepartament()
        {

        }

        public clsDepartament(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        #endregion 


    }
}
