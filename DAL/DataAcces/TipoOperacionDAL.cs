using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa DAL para los tipos de operación
    /// Maneja el acceso directo a la base de datos para la tabla TTipoOperacion
    /// </summary>
    public class TipoOperacionDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene todos los tipos de operación
        /// </summary>
        /// <returns>DataTable con los tipos de operación</returns>
        public static DataTable ListarTiposOperacion()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idTipoOperacion, operacion 
                                      FROM TTipoOperacion
                                      ORDER BY operacion";

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
        /// Obtiene un tipo de operación por su ID
        /// </summary>
        /// <param name="idTipoOperacion">ID del tipo de operación</param>
        /// <returns>DataRow con los datos del tipo de operación</returns>
        public static DataRow ObtenerTipoOperacionPorId(int idTipoOperacion)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idTipoOperacion, operacion 
                                      FROM TTipoOperacion
                                      WHERE idTipoOperacion = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idTipoOperacion);

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
