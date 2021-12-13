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

        #region Constructor
        public clsPersonListBL()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Devuelve lo que devuelve el metodo getPersons() de la capa dal
        /// Descripcion: En este metodo incluiremos las reglas de negocio
        /// </summary>
        /// <returns>List<clsPerson> Las lista de personas que devuelve el metodo getPersons() de la capa dal</returns>
        public List<clsPerson> getPersons()
        {

            return new clsPersonListDal().getPersons();

        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Devuelve lo que devuelve el metodo getPerson(int id) de la capa dal
        /// Descripcion: En este metodo incluiremos las reglas de negocio
        /// </summary>
        /// <param name="id">La id de la persona que queremos obtener</param>
        /// <returns>clsPerson La persona que devuelve el metodo getPerson(int id) de la capa dal</returns>
        public clsPerson getPerson(int id)
        {
            return new clsPersonListDal().getPerson(id);
        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Devuelve lo que devuelve el metodo getPersonsByDepartament(int id) de la capa dal
        /// </summary>
        /// <param name="id">La id del departamento</param>
        /// <returns>List<clsPersona> la lista que devuelve el metodo getPersonsByDepartament(int id) de la capa dal</returns>
        public List<clsPerson> getPersonsByDepartament(int id)
        {

            return new clsPersonListDal().getPersonsByDepartament(id);

        }

        #endregion





    }
}
