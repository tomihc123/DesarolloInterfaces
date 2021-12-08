using Dal.Handler;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Handler
{
    public class clsHandlerDepartamentBL
    {
        #region Constructor
        public clsHandlerDepartamentBL()
        {

        }
        #endregion
        #region Methods
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion updateDepartament(clsDepartament departament) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="person">El departamento que pasamos a la funcion updateDepartament(clsDepartament departament) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo updateDepartament(clsDepartament departament) de la capa dal</returns>
        public int updateDepartament(clsDepartament departament)
        {
            return new clsHandlerDepartamentDal().updateDepartament(departament);
        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion insertPerson(clsPerson person) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="person">La persona que pasamos la funcion insertPerson(clsPerson person) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo insertPerson(clsPerson person) de la capa dal</returns>
        public int insertDepartament(clsDepartament departament)
        {
            return new clsHandlerDepartamentDal().insertDepartament(departament);
        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion deletePerson(int id) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="id">La id que pasamos a la funcion deletePerson(int id) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo deletePerson(int id) de la capa dal</returns>
        public int deleteDepartament(int id)
        {

            return new clsHandlerDepartamentDal().deleteDepartament(id);

        }

        #endregion

    }



}

