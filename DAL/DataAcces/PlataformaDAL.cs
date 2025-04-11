using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa DAL para la gestión de plataformas
    /// Maneja el acceso directo a la base de datos para la tabla TPlataforma
    /// </summary>
    public class PlataformaDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene todas las plataformas registradas
        /// </summary>
        /// <returns>DataTable con los registros de plataformas</returns>
        public static DataTable ListarPlataformas()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idPlataforma, plataforma 
                                      FROM TPlataforma
                                      ORDER BY plataforma";

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
        /// Inserta una nueva plataforma
        /// </summary>
        /// <param name="plataforma">Nombre de la plataforma (máx. 30 caracteres)</param>
        /// <returns>ID de la nueva plataforma creada</returns>
        public static int InsertarPlataforma(string plataforma)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO TPlataforma 
                                     (plataforma) 
                                     VALUES (@plataforma);
                                     SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@plataforma", plataforma.Trim());

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Actualiza una plataforma existente
        /// </summary>
        /// <param name="idPlataforma">ID de la plataforma a actualizar</param>
        /// <param name="plataforma">Nuevo nombre para la plataforma (máx. 30 caracteres)</param>
        /// <returns>True si se actualizó correctamente</returns>
        public static bool ActualizarPlataforma(int idPlataforma, string plataforma)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"UPDATE TPlataforma 
                                     SET plataforma = @plataforma
                                     WHERE idPlataforma = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idPlataforma);
                    command.Parameters.AddWithValue("@plataforma", plataforma.Trim());

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Elimina una plataforma
        /// </summary>
        /// <param name="idPlataforma">ID de la plataforma a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        public static bool EliminarPlataforma(int idPlataforma)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"DELETE FROM TPlataforma 
                                      WHERE idPlataforma = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idPlataforma);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene una plataforma por su ID
        /// </summary>
        /// <param name="idPlataforma">ID de la plataforma a buscar</param>
        /// <returns>DataRow con los datos de la plataforma o null si no existe</returns>
        public static DataRow ObtenerPlataformaPorId(int idPlataforma)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idPlataforma, plataforma 
                                      FROM TPlataforma
                                      WHERE idPlataforma = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idPlataforma);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Verifica si existe una plataforma con el mismo nombre
        /// </summary>
        /// <param name="plataforma">Nombre de la plataforma a verificar</param>
        /// <param name="excluirId">ID a excluir de la verificación (para updates)</param>
        /// <returns>True si ya existe una plataforma con ese nombre</returns>
        public static bool ExistePlataforma(string plataforma, int excluirId = 0)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT COUNT(*) 
                                     FROM TPlataforma 
                                     WHERE plataforma = @plataforma
                                     AND idPlataforma != @excluirId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@plataforma", plataforma.Trim());
                    command.Parameters.AddWithValue("@excluirId", excluirId);

                    connection.Open();
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }
    }
}
