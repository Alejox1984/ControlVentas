using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa DAL para la gestión de tasas
    /// Maneja el acceso directo a la base de datos para la tabla TTasas
    /// </summary>
    public class TasasDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene la última tasa registrada
        /// </summary>
        /// <returns>DataRow con los datos de tasas</returns>
        public static DataRow ObtenerUltimaTasa()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT TOP 1 idTasas, tasaUSD, tasaPorVenta, tasaPorCambio 
                                      FROM TTasas
                                      ORDER BY idTasas DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Inserta una nueva configuración de tasas
        /// </summary>
        /// <param name="tasaUSD">Tasa de cambio USD</param>
        /// <param name="tasaPorVenta">Tasa por venta</param>
        /// <param name="tasaPorCambio">Tasa por cambio</param>
        /// <returns>ID de la nueva tasa creada</returns>
        public static int InsertarTasa(decimal tasaUSD, decimal tasaPorVenta, decimal tasaPorCambio)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO TTasas 
                                     (tasaUSD, tasaPorVenta, tasaPorCambio) 
                                     VALUES (@usd, @venta, @cambio);
                                     SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@usd", tasaUSD);
                    command.Parameters.AddWithValue("@venta", tasaPorVenta);
                    command.Parameters.AddWithValue("@cambio", tasaPorCambio);

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}