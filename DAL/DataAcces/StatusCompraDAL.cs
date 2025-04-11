using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa DAL para el estado de compras
    /// Maneja el acceso directo a la base de datos para la tabla TStatusCompra
    /// </summary>
    public class StatusCompraDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene todos los estados de compra registrados
        /// </summary>
        /// <returns>DataTable con los registros de estados</returns>
        public static DataTable ListarStatusCompra()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idStatus, statusCompra 
                                      FROM TStatusCompra
                                      ORDER BY statusCompra";

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
        /// Inserta un nuevo estado de compra
        /// </summary>
        /// <param name="statusCompra">Nombre del estado (máx. 30 caracteres)</param>
        /// <returns>ID del nuevo estado creado</returns>
        public static int InsertarStatusCompra(string statusCompra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO TStatusCompra 
                                     (statusCompra) 
                                     VALUES (@status);
                                     SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@status", statusCompra.Trim());

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Actualiza un estado de compra existente
        /// </summary>
        /// <param name="idStatus">ID del estado a actualizar</param>
        /// <param name="statusCompra">Nuevo nombre para el estado (máx. 30 caracteres)</param>
        /// <returns>True si se actualizó correctamente</returns>
        public static bool ActualizarStatusCompra(int idStatus, string statusCompra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"UPDATE TStatusCompra 
                                     SET statusCompra = @status
                                     WHERE idStatus = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idStatus);
                    command.Parameters.AddWithValue("@status", statusCompra.Trim());

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene un estado de compra por su ID
        /// </summary>
        /// <param name="idStatus">ID del estado a buscar</param>
        /// <returns>DataRow con los datos del estado o null si no existe</returns>
        public static DataRow ObtenerStatusCompraPorId(int idStatus)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idStatus, statusCompra 
                                      FROM TStatusCompra
                                      WHERE idStatus = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idStatus);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}
