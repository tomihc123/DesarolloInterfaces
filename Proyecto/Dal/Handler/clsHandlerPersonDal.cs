﻿using Dal.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Handler
{
    public class clsHandlerPersonDal
    {

        public int insertPerson(clsPerson clsPerson)
        {

            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            int rowsAffected;


            sqlCommand.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = clsPerson.name;
            sqlCommand.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = clsPerson.lastName;
            sqlCommand.Parameters.Add("@birthDate", System.Data.SqlDbType.DateTime).Value = clsPerson.birthDate;
            sqlCommand.Parameters.Add("@phoneNumber", System.Data.SqlDbType.VarChar).Value = clsPerson.phoneNumber;
            sqlCommand.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = clsPerson.address;
            sqlCommand.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = clsPerson.iddepartamento;


            try
            {
                sqlConnection = clsMyConnection.getConnection();
                sqlCommand.CommandText = "INSERT INTO Persons VALUES (@name, @lastName, @birthDate, @phoneNumber, @address, @iddepartamento)";
                sqlCommand.Connection = sqlConnection;
                rowsAffected = sqlCommand.ExecuteNonQuery();

            } catch (SqlException) {
                throw;
            }
            finally
            {
                clsMyConnection.closeConnection(ref sqlConnection);
            }

            return rowsAffected;   

        }

        public int deletePerson(clsPerson clsPerson)
        {

            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            int rowsAffected;

            try
            {
                sqlConnection = clsMyConnection.getConnection();

                sqlCommand.Parameters.Add("@idPersona", System.Data.SqlDbType.VarChar).Value = clsPerson.id;
                sqlCommand.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = clsPerson.name;
                sqlCommand.Parameters.Add("@lastName", System.Data.SqlDbType.VarChar).Value = clsPerson.lastName;
                sqlCommand.Parameters.Add("@birthDate", System.Data.SqlDbType.DateTime).Value = clsPerson.birthDate;
                sqlCommand.Parameters.Add("@phoneNumber", System.Data.SqlDbType.VarChar).Value = clsPerson.phoneNumber;
                sqlCommand.Parameters.Add("@address", System.Data.SqlDbType.VarChar).Value = clsPerson.address;
                sqlCommand.Parameters.Add("@iddepartamento", System.Data.SqlDbType.Int).Value = clsPerson.iddepartamento;



                sqlCommand.CommandText = "UPDATE Persons SET name = @name, lastName = @lastName, birthDate = @birthDate, phoneNumber = @phoneNumber, address = @address, iddepartamento = @iddepartamento WHERE id = @id ";
                sqlCommand.Connection = sqlConnection;
                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                clsMyConnection.closeConnection(ref sqlConnection);
            }

            return rowsAffected;


        }



        public int deletePerson(int id)
        {

            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            int rowsAffected;

            try
            {
                sqlConnection = clsMyConnection.getConnection();
                sqlCommand.Parameters.Add("@idPersona", System.Data.SqlDbType.VarChar).Value = id;
                sqlCommand.CommandText = "DELETE  FROM Persons WHERE id = @idPersona ";
                sqlCommand.Connection = sqlConnection;
                rowsAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                clsMyConnection.closeConnection(ref sqlConnection);
            }

            return rowsAffected;


        }



    }
}
