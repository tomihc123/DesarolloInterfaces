using Dal.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Lists
{
    public class clsDepartamentListDal
    {

        #region Constructor
        public clsDepartamentListDal()
        {

        }
        #endregion


        #region Methods

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Tiene que devolver todos los departamentos que haya en la base de datos
        /// Devuelve todos los departamentos de la base de datos
        /// </summary>
        /// <returns>List<clsDepartament> Un listado con todos los departamentos de la base de datos</returns>
        public List<clsDepartament> getDepartaments()
        {

            List<clsDepartament> departamentList = new List<clsDepartament>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsDepartament clsDepartament;
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;



            try
            {
                connection = clsMyConnection.getConnection();
                command.CommandText = "Select * FROM Departaments";
                command.Connection = connection;
                reader = command.ExecuteReader();


                //If there are rows in the reader
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        clsDepartament = new clsDepartament();

                        clsDepartament.id = (int)reader["id"];

                        clsDepartament.name = (string)reader["name"];


                        departamentList.Add(clsDepartament);
                    }
                }


                clsMyConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw;
            }


            return departamentList;

        }

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: El departamento cuya id es el parametro pasado, debe tener el nombre que devuelve este metodo
        /// Descripcion: Devuelve el nombre de un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>String el nombre</returns>
        public String getNameDepartamentById(int id)
        {

            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            String name = "";
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;

            try
            {
                connection = clsMyConnection.getConnection();
                command.Parameters.Add("@ID", System.Data.SqlDbType.VarChar).Value = id;
                command.CommandText = "SELECT name from Departaments WHERE ID = @ID";
                command.Connection = connection;
                reader = command.ExecuteReader();


                if(reader.HasRows)
                {

                    while(reader.Read())
                    {

                        name = (string)reader["name"];

                    }

                }

                clsMyConnection.closeConnection(ref connection);

            } catch(SqlException)
            {
                throw; ;
            }

            return name;


        }

        /// <summary>
        /// Precondiciones: Ninguna 
        /// Postcondiciones: Tiene que devolver todos los nombres de los departamentos de la base de datos
        /// Descripcion: Un método para obtener todos los nombres de departamentos
        /// </summary>
        /// <returns>List<String> Una lista con todos los nombres</returns>
        public List<String> getNameDepartaments()
        {

            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            List<String> names = new List<string>();
            clsMyConnection clsMyConnection = new clsMyConnection();
            SqlConnection connection = null;

            try
            {
                connection = clsMyConnection.getConnection();
                command.CommandText = "SELECT name from Departaments";
                command.Connection = connection;
                reader = command.ExecuteReader();


                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                       names.Add((string)reader["name"]);

                    }

                }

                clsMyConnection.closeConnection(ref connection);

            }
            catch (SqlException)
            {
                throw; ;
            }

            return names;

        }

        #endregion

    }
}
