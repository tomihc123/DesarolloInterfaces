using Dal.Handler;
using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Handler
{
    public class clsHandlerPersonBL
    {

        #region Constructor
        public clsHandlerPersonBL()
        {

        }
        #endregion


        #region Methods
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion updatePerson(clsPerson person) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="person">La persona que pasamos la funcion updatePerson(clsPerson person) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo updatePerson(clsPerson person) de la capa dal</returns>
        public int updatePerson(clsPerson person)
        {
            return new clsHandlerPersonDal().updatePerson(person);
        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion insertPerson(clsPerson person) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="person">La persona que pasamos la funcion insertPerson(clsPerson person) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo insertPerson(clsPerson person) de la capa dal</returns>
        public int insertPerson(clsPerson person)
        {
            return new clsHandlerPersonDal().insertPerson(person);
        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: LLamara a la funcion deletePerson(int id) de la capa dal
        /// Descripcion: En este metodo se incluirán las reglas de negocios
        /// </summary>
        /// <param name="id">La id que pasamos a la funcion deletePerson(int id) de la capa dal</param>
        /// <returns>int el numero de filas afectadas que devuelve el metodo deletePerson(int id) de la capa dal</returns>
        public int deletePerson(int id)
        {

            return new clsHandlerPersonDal().deletePerson(id);

        }

        #endregion

    }

    

}
