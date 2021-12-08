using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dal.Connection;


namespace Dal.Handler
{
   public  class clsHandlerDepartamentDal
    {

        #region  Constructor
        public clsHandlerDepartamentDal()
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// Precondiciones: Ninguna
        /// Postcondiciones: Si se puede realizar correctamente la inserción, el departamento se insertara en la base de datos
        /// Descripcion: Este metodo usa sentencias de sql para insertar el departamento
        /// </summary>
        /// <param name="clsDepartament"> El departamento que queremos insertar en la base de datos</param>
        /// <returns>int Las filas afectadas</returns>
        public int insertDepartament(clsDepartament clsDepartament)
        {

            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            int rowsAffected;


            sqlCommand.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = clsDepartament.name;

            try
            {
                sqlConnection = clsMyConnection.getConnection();
                sqlCommand.CommandText = "INSERT INTO Departaments VALUES (@name)";
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
        /// Precondiciones: Ninguna
        /// Postcondiciones: Si se puede realizar correctamente la actualización, el departamento se actualizara en la base de datos
        /// Descripcion: Este metodo usa sentencias de sql para actualizar el departamento
        /// </summary>
        /// <param name="clsDepartament"> El departamento que queremos actualizar en la base de datos</param>
        /// <returns>int Las filas afectadas</returns>
        public int updateDepartament(clsDepartament clsDepartament)
        {

            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            int rowsAffected;

            try
            {
                sqlConnection = clsMyConnection.getConnection();

                sqlCommand.Parameters.Add("@idDepartament", System.Data.SqlDbType.VarChar).Value = clsDepartament.id;
                sqlCommand.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = clsDepartament.name;



                sqlCommand.CommandText = "UPDATE Departaments SET name = @name WHERE id = @idDepartament";
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
        /// Postcondiciones: Si se puede realizar correctamente la eliminación, el departamento cuya id es la pasado por parámetro se eliminara en la base de datos
        /// Descripcion: Este metodo usa sentencias de sql para eliminar la persona
        /// </summary>
        /// <param name="id">La id de el departamento que queremos eliminar</param>
        /// <returns>int Las filas afectadas</returns>
        /// 
        public int deleteDepartament(int id)
        {

            SqlCommand sqlCommand = new SqlCommand();
            SqlConnection sqlConnection = null;
            clsMyConnection clsMyConnection = new clsMyConnection();
            int rowsAffected;

            try
            {
                sqlConnection = clsMyConnection.getConnection();
                sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = id;
                sqlCommand.CommandText = "DELETE  FROM Departaments WHERE id = @id";
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
