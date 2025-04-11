using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa DAL para operaciones contables de compras
    /// Maneja el acceso directo a la base de datos para la tabla TOperacionContableCompra
    /// </summary>
    public class OperacionContableCompraDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene todas las relaciones entre operaciones contables y compras
        /// </summary>
        /// <returns>DataTable con los registros existentes</returns>
        public static DataTable ListarOperacionesContablesCompra()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idOpContableCompra, idCompra, idOpContable 
                                      FROM TOperacionContableCompra";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// Inserta una nueva relación entre operación contable y compra
        /// </summary>
        /// <param name="idCompra">ID de la compra</param>
        /// <param name="idOpContable">ID de la operación contable</param>
        /// <returns>ID del nuevo registro insertado</returns>
        public static int InsertarOperacionContableCompra(int idCompra, int idOpContable)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO TOperacionContableCompra 
                                     (idCompra, idOpContable) 
                                     VALUES (@idCompra, @idOpContable);
                                     SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCompra", idCompra);
                    command.Parameters.AddWithValue("@idOpContable", idOpContable);

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Elimina una relación entre operación contable y compra
        /// </summary>
        /// <param name="idOpContableCompra">ID de la relación a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        public static bool EliminarOperacionContableCompra(int idOpContableCompra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"DELETE FROM TOperacionContableCompra 
                                      WHERE idOpContableCompra = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idOpContableCompra);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene las operaciones contables asociadas a una compra específica
        /// </summary>
        /// <param name="idCompra">ID de la compra</param>
        /// <returns>DataTable con las operaciones contables relacionadas</returns>
        public static DataTable ObtenerOperacionesPorCompra(int idCompra)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idOpContableCompra, idOpContable 
                                      FROM TOperacionContableCompra
                                      WHERE idCompra = @idCompra";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCompra", idCompra);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}