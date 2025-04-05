using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa DAL para las categorías
    /// Maneja el acceso directo a la base de datos para la tabla TCategoria
    /// </summary>
    public class CategoriaDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene todas las categorías
        /// </summary>
        /// <returns>DataTable con las categorías</returns>
        public static DataTable ListarCategorias()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idCategoria, categoria 
                                      FROM TCategoria
                                      ORDER BY categoria";

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
        /// Inserta una nueva categoría
        /// </summary>
        /// <param name="categoria">Nombre de la categoría (máx. 20 caracteres)</param>
        /// <returns>ID de la nueva categoría creada</returns>
        public static int InsertarCategoria(string categoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO TCategoria 
                                     (categoria) 
                                     VALUES (@categoria);
                                     SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@categoria", categoria.Trim());

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Obtiene una categoría por su ID
        /// </summary>
        /// <param name="idCategoria">ID de la categoría</param>
        /// <returns>DataRow con los datos de la categoría</returns>
        public static DataRow ObtenerCategoriaPorId(int idCategoria)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idCategoria, categoria 
                                      FROM TCategoria
                                      WHERE idCategoria = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idCategoria);

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