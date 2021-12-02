using Dal.Lists;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Lists
{
    public class clsDepartamentListBL
    {
        #region Constructor
        public clsDepartamentListBL() { 
        
        }
        #endregion

        #region Methods
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Devuelve lo que devuelve el método getDepartaments() de la capa dal
        /// Descripcion: En este metodo incluiremos las reglas de negocio
        /// </summary>
        /// <returns>List<clsDepartament> La lista con todos los departamentos que devuelve el método getDepartaments() de la capa dal </returns>
        public List<clsDepartament> getDepartaments() 
        {

            return new clsDepartamentListDal().getDepartaments();


        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Devuelve lo que devuelve el método getNameDepartamentById(int id) de la capa dal
        /// Descripcion: En este metodo incluiremos las reglas de negocio
        /// </summary>
        /// <param name="id">La id de del departamento cuyo nombre que queremos obtener</param>
        /// <returns>String el nombre del departamento cuya id es el parámetro</returns>
        public String getNameDepartamentById(int id)
        {

            return new clsDepartamentListDal().getNameDepartamentById(id);

        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Devuelve lo que devuelve el método getNameDepartaments() de la capa dal
        /// Descripcion: En este metodo incluiremos las reglas de negocio
        /// </summary>
        /// <returns>List<String> El listado con todos los nombres de los departamentos que devuelve el método getNameDepartaments()</returns>
        public List<String> getNameDepartaments()
        {
            return new clsDepartamentListDal().getNameDepartaments();
        }

        #endregion

    }
}
