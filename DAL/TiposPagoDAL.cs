using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa DAL para los tipos de pago
    /// Maneja el acceso directo a la base de datos para la tabla TTiposPago
    /// </summary>
    public class TiposPagoDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene todos los tipos de pago
        /// </summary>
        /// <returns>DataTable con los tipos de pago</returns>
        public static DataTable ListarTiposPago()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idTipoPago, tipoPago 
                                      FROM TTiposPago
                                      ORDER BY tipoPago";

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
        /// Obtiene un tipo de pago por su ID
        /// </summary>
        /// <param name="idTipoPago">ID del tipo de pago</param>
        /// <returns>DataRow con los datos del tipo de pago</returns>
        public static DataRow ObtenerTipoPagoPorId(int idTipoPago)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idTipoPago, tipoPago 
                                      FROM TTiposPago
                                      WHERE idTipoPago = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idTipoPago);

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