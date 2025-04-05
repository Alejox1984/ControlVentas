using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa DAL para operaciones contables
    /// Maneja el acceso directo a la base de datos para la tabla TOperacionContable
    /// </summary>
    public class OperacionContableDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene todas las operaciones contables registradas
        /// </summary>
        /// <returns>DataTable con los registros existentes</returns>
        public static DataTable ListarOperacionesContables()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idOperacionContable, idDetalleOperacion, fecha, importe 
                                      FROM TOperacionContable";

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
        /// Inserta una nueva operación contable
        /// </summary>
        /// <param name="idDetalleOperacion">ID del detalle de operación</param>
        /// <param name="fecha">Fecha de la operación</param>
        /// <param name="importe">Importe de la operación</param>
        /// <returns>ID de la nueva operación contable creada</returns>
        public static int InsertarOperacionContable(int idDetalleOperacion, DateTime fecha, decimal importe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO TOperacionContable 
                                     (idDetalleOperacion, fecha, importe) 
                                     VALUES (@idDetalle, @fecha, @importe);
                                     SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idDetalle", idDetalleOperacion);
                    command.Parameters.AddWithValue("@fecha", fecha);
                    command.Parameters.AddWithValue("@importe", importe);

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Actualiza una operación contable existente
        /// </summary>
        /// <param name="idOperacionContable">ID de la operación a actualizar</param>
        /// <param name="idDetalleOperacion">Nuevo ID del detalle de operación</param>
        /// <param name="fecha">Nueva fecha</param>
        /// <param name="importe">Nuevo importe</param>
        /// <returns>True si se actualizó correctamente</returns>
        public static bool ActualizarOperacionContable(int idOperacionContable, int idDetalleOperacion, DateTime fecha, decimal importe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"UPDATE TOperacionContable 
                                     SET idDetalleOperacion = @idDetalle,
                                         fecha = @fecha,
                                         importe = @importe
                                     WHERE idOperacionContable = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idOperacionContable);
                    command.Parameters.AddWithValue("@idDetalle", idDetalleOperacion);
                    command.Parameters.AddWithValue("@fecha", fecha);
                    command.Parameters.AddWithValue("@importe", importe);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Elimina una operación contable
        /// </summary>
        /// <param name="idOperacionContable">ID de la operación a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        public static bool EliminarOperacionContable(int idOperacionContable)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"DELETE FROM TOperacionContable 
                                      WHERE idOperacionContable = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idOperacionContable);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        /// <summary>
        /// Obtiene una operación contable por su ID
        /// </summary>
        /// <param name="idOperacionContable">ID de la operación a buscar</param>
        /// <returns>DataRow con los datos de la operación o null si no existe</returns>
        public static DataRow ObtenerOperacionPorId(int idOperacionContable)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idOperacionContable, idDetalleOperacion, fecha, importe 
                                      FROM TOperacionContable
                                      WHERE idOperacionContable = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idOperacionContable);

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