using Dal.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Lists
{
    public class clsPersonListDal
    {
        #region Constructor
        public clsPersonListDal()
        {

        }
        #endregion


        #region Methods
        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Que la persona devuelta tenga la misma id que el parametro
        /// Descripcion: Este metodo te devuelve de la base de datos la persona cuyo id coincide con el parámetro que pasamos al metodo
        /// </summary>
        /// <param name="id">La id de la persona que queremos obtener</param>
        /// <returns>Type: clsPerson La persona de la base de datos</returns>
        public clsPerson getPerson(int id)
        {


            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPerson person = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;

            try
            {
                //Obtenemos la conexion
                connection = clsMyConnection.getConnection();
                command.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;
                command.CommandText = "Select * FROM Persons WHERE ID = @ID";
                command.Connection = connection;
                reader = command.ExecuteReader();


                //Si hay filas
                if (reader.HasRows)
                {
                    //Mientras se pueda leer
                    while (reader.Read())
                    {

                        person = new clsPerson();

                        person.id = (int)reader["id"];

                        person.name = (string)reader["name"];

                        //En realidad nunca van a ser nulos porque hacemos las validaciones en el cliente, pero por si acaso
                        if (reader["lastName"] != DBNull.Value)
                        {
                            person.lastName = (string)reader["lastName"];
                        }

                        if (reader["birthDate"] != System.DBNull.Value)
                        {
                            person.birthDate = (DateTime)reader["birthDate"];
                        }

                        if (reader["phoneNumber"] != DBNull.Value)
                        {
                            person.phoneNumber = (string)reader["phoneNumber"];
                        }

                        if (reader["address"] != DBNull.Value)
                        {
                            person.address = (string)reader["address"];
                        }

                        if (reader["image"] != DBNull.Value)
                        {
                            person.image = (string)reader["image"];
                        }

                        person.iddepartamento = (int)reader["iddepartamento"];

                    }
                }


                clsMyConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }


            return person;


        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Tiene que devolver todas las personas
        /// Descripcion: Devuelve el listado completo de personas de la base de datos
        /// </summary>
        /// <returns>List<clsPerson> Una lista de con todas las personas de la base de datos</returns>
        public List<clsPerson> getPersons()
        {

            List<clsPerson> personList = new List<clsPerson>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPerson person;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;



            try
            {
                connection = clsMyConnection.getConnection();
                command.CommandText = "Select * FROM Persons";
                command.Connection = connection;
                reader = command.ExecuteReader();


                //Si hay filas
                if (reader.HasRows)
                {
                    //Mientras se pueda leer
                    while (reader.Read())
                    {

                        person = new clsPerson();

                        person.id = (int)reader["id"];

                        person.name = (string)reader["name"];

                        if (reader["lastName"] != DBNull.Value)
                        {
                            person.lastName = (string)reader["lastName"];
                        }

                        if (reader["birthDate"] != System.DBNull.Value)
                        {
                            person.birthDate = (DateTime)reader["birthDate"];
                        }

                        if (reader["phoneNumber"] != DBNull.Value)
                        {
                            person.phoneNumber = (string)reader["phoneNumber"];
                        }

                        if (reader["address"] != DBNull.Value)
                        {
                            person.address = (string)reader["address"];
                        }

                        if (reader["image"] != DBNull.Value)
                        {
                            person.image = (string)reader["image"];
                        }

                        person.iddepartamento = (int)reader["iddepartamento"];

                        personList.Add(person);
                    }
                }


                clsMyConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }


            return personList;
        }

        /// <summary>
        /// Precondiciones: La id debe existir en la base de datos
        /// Postcondiciones: Devolvera una lista de personas cuyo departamento es la id pasada por parametro
        /// Descripcion: Usa sentencias sql para obtener los resultados
        /// </summary>
        /// <param name="id">La id del departamento</param>
        /// <returns>List<clsPerson> la lista de personas</returns>
        public List<clsPerson> getPersonsByDepartament(int id)
        {

            List<clsPerson> personList = new List<clsPerson>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPerson person;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;



            try
            {
                connection = clsMyConnection.getConnection();
                command.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;
                command.CommandText = "Select * FROM Persons WHERE iddepartamento = @ID";
                command.Connection = connection;
                reader = command.ExecuteReader();


                //Si hay filas
                if (reader.HasRows)
                {
                    //Mientras se pueda leer
                    while (reader.Read())
                    {

                        person = new clsPerson();

                        person.id = (int)reader["id"];

                        person.name = (string)reader["name"];

                        if (reader["lastName"] != DBNull.Value)
                        {
                            person.lastName = (string)reader["lastName"];
                        }

                        if (reader["birthDate"] != System.DBNull.Value)
                        {
                            person.birthDate = (DateTime)reader["birthDate"];
                        }

                        if (reader["phoneNumber"] != DBNull.Value)
                        {
                            person.phoneNumber = (string)reader["phoneNumber"];
                        }

                        if (reader["address"] != DBNull.Value)
                        {
                            person.address = (string)reader["address"];
                        }

                        if (reader["image"] != DBNull.Value)
                        {
                            person.image = (string)reader["image"];
                        }

                        person.iddepartamento = (int)reader["iddepartamento"];

                        personList.Add(person);
                    }
                }


                clsMyConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }


            return personList;
        }


        #endregion
    }
}
