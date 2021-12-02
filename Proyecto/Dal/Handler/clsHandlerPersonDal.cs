using Dal.Connection;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Dal.Handler
{
    public class clsHandlerPersonDal
    {

        #region  Constructor
        public clsHandlerPersonDal()
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Precondiciones: El atributo image del parametro clsPerson en caso de no ser nulo, debe ser una url válida de una imagen
        /// Postcondiciones: Si se puede realizar correctamente la inserción, la persona se insertara en la base de datos
        /// Descripcion: Este metodo usa sentencias de sql para insertar la persona
        /// </summary>
        /// <param name="clsPerson"> La persona que queremos insertar en la base de datos</param>
        /// <returns>int Las filas afectadas</returns>
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

            if(clsPerson.image != null)
            {
                sqlCommand.Parameters.Add("@image", System.Data.SqlDbType.VarChar).Value = clsPerson.image;

            } else
            {
                sqlCommand.Parameters.Add("@image", System.Data.SqlDbType.VarChar).Value = "https://cdn-icons-png.flaticon.com/512/1920/1920952.png";

            }




            try
            {
                sqlConnection = clsMyConnection.getConnection();
                sqlCommand.CommandText = "INSERT INTO Persons VALUES (@name, @lastName, @birthDate, @phoneNumber, @address, @iddepartamento, @image)";
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


        /// <summary>
        /// Precondiciones: El atributo image del parametro clsPerson en caso de no ser nulo, debe ser una url válida de una imagen
        /// Postcondiciones: Si se puede realizar correctamente la actualización, la persona se actualizara en la base de datos
        /// Descripcion: Este metodo usa sentencias de sql para actualizar la persona
        /// </summary>
        /// <param name="clsPerson"> La persona que queremos actualizar en la base de datos</param>
        /// <returns>int Las filas afectadas</returns>
        public int updatePerson(clsPerson clsPerson)
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
                if (clsPerson.image != null)
                {
                    sqlCommand.Parameters.Add("@image", System.Data.SqlDbType.VarChar).Value = clsPerson.image;

                }
                else
                {
                    sqlCommand.Parameters.Add("@image", System.Data.SqlDbType.VarChar).Value = "https://cdn-icons-png.flaticon.com/512/1920/1920952.png";

                }



                sqlCommand.CommandText = "UPDATE Persons SET name = @name, lastName = @lastName, birthDate = @birthDate, phoneNumber = @phoneNumber, address = @address, iddepartamento = @iddepartamento, image = @image WHERE id = @idPersona";
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


        /// <summary>
        /// Precondiciones: La id debe existir en la base de datos
        /// Postcondiciones: Si se puede realizar correctamente la eliminación, la persona cuya id es la pasado por parámetro se eliminara en la base de datos
        /// Descripcion: Este metodo usa sentencias de sql para eliminar la persona
        /// </summary>
        /// <param name="id">La id de la persona que queremos eliminar</param>
        /// <returns>int Las filas afectadas</returns>
        /// 
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

        #endregion

    }
}
