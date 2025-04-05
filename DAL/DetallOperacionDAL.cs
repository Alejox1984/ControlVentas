using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DetalleOperacionDAL
    {
        private static string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        public static DataTable ListarDetalleOperaciones()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT idDetalleOperacion, idTipoOperacion, Operacion FROM DetalleOperacion";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static int InsertarDetalleOperacion(int idTipoOperacion, string operacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DetalleOperacion (idTipoOperacion, Operacion) VALUES (@idTipoOperacion, @operacion)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idTipoOperacion", idTipoOperacion);
                command.Parameters.AddWithValue("@operacion", operacion.Trim());

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static int ActualizarDetalleOperacion(int idDetalleOperacion, int idTipoOperacion, string operacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE DetalleOperacion SET idTipoOperacion = @idTipoOperacion, Operacion = @operacion WHERE idDetalleOperacion = @idDetalleOperacion";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idDetalleOperacion", idDetalleOperacion);
                command.Parameters.AddWithValue("@idTipoOperacion", idTipoOperacion);
                command.Parameters.AddWithValue("@operacion", operacion.Trim());

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static int EliminarDetalleOperacion(int idDetalleOperacion)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM DetalleOperacion WHERE idDetalleOperacion = @idDetalleOperacion";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idDetalleOperacion", idDetalleOperacion);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static DataRow ObtenerDetalleOperacionPorId(int idDetalleOperacion)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT idDetalleOperacion, idTipoOperacion, Operacion FROM DetalleOperacion WHERE idDetalleOperacion = @idDetalleOperacion";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idDetalleOperacion", idDetalleOperacion);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}