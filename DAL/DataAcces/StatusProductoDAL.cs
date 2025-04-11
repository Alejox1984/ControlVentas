using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa DAL para el estado de productos
    /// Maneja el acceso directo a la base de datos para la tabla TStatusProducto
    /// </summary>
    public class StatusProductoDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene todos los estados de producto registrados
        /// </summary>
        /// <returns>DataTable con los registros de estados</returns>
        public static DataTable ListarStatusProducto()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idStatus, statusProducto 
                                      FROM TStatusProducto
                                      ORDER BY statusProducto";

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
        /// Inserta un nuevo estado de producto
        /// </summary>
        /// <param name="statusProducto">Nombre del estado (máx. 20 caracteres)</param>
        /// <returns>ID del nuevo estado creado</returns>
        public static int InsertarStatusProducto(string statusProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO TStatusProducto 
                                     (statusProducto) 
                                     VALUES (@status);
                                     SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@status", statusProducto.Trim());

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Actualiza un estado de producto existente
        /// </summary>
        /// <param name="idStatus">ID del estado a actualizar</param>
        /// <param name="statusProducto">Nuevo nombre para el estado (máx. 20 caracteres)</param>
        /// <returns>True si se actualizó correctamente</returns>
        public static bool ActualizarStatusProducto(int idStatus, string statusProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"UPDATE TStatusProducto 
                                     SET statusProducto = @status
                                     WHERE idStatus = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idStatus);
                    command.Parameters.AddWithValue("@status", statusProducto.Trim());

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene un estado de producto por su ID
        /// </summary>
        /// <param name="idStatus">ID del estado a buscar</param>
        /// <returns>DataRow con los datos del estado o null si no existe</returns>
        public static DataRow ObtenerStatusProductoPorId(int idStatus)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idStatus, statusProducto 
                                      FROM TStatusProducto
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