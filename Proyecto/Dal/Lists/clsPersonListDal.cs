﻿using Dal.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Lists
{
    public class clsPersonListDal
    {


        /// <summary>
        /// Devuelve el listado completo de personas de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<clsPerson> getPersons()
        {

            List<clsPerson> personList = new List<clsPerson>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPerson person;
            clsMyConnection connection = new clsMyConnection();
            SqlConnection myConnection = null;

            try
            {
                myConnection = connection.getConnection();
                command.CommandText = "Select * FROM Persons";
                command.Connection = myConnection;
                reader = command.ExecuteReader();


                //If there are rows in the reader
                if (reader.HasRows)
                {
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

                        person.iddepartamento = (int)reader["iddepartamento"];

                        personList.Add(person);
                    }
                }


                connection.closeConnection(ref myConnection);

            }
            catch (SqlException)
            {
                throw;
            }


            return personList;
        }


    }
}