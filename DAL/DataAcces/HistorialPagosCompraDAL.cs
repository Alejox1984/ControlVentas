using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// Capa de acceso a datos para el historial de pagos de compras
    /// </summary>
    public class HistorialPagosCompraDAL
    {
        private static readonly string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        /// <summary>
        /// Obtiene todos los registros de pagos de compras
        /// </summary>
        /// <returns>DataTable con todos los registros de historial de pagos</returns>
        public static DataTable ListarHistorialPagosCompra()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = "SELECT idHistorialPagosCompra, idCompra, idPago, importe, fecha FROM HistorialPagosCompra";

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
        /// Inserta un nuevo registro de pago de compra
        /// </summary>
        /// <param name="idCompra">Identificador de la compra asociada</param>
        /// <param name="idPago">Identificador del tipo de pago</param>
        /// <param name="importe">Monto del pago realizado</param>
        /// <param name="fecha">Fecha en que se realizó el pago</param>
        /// <returns>Número de filas afectadas (1 = éxito, 0 = error)</returns>
        public static int InsertarHistorialPagoCompra(int idCompra, int idPago, decimal importe, DateTime fecha)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"INSERT INTO HistorialPagosCompra 
                                     (idCompra, idPago, importe, fecha) 
                                     VALUES (@idCompra, @idPago, @importe, @fecha)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idCompra", idCompra);
                    command.Parameters.AddWithValue("@idPago", idPago);
                    command.Parameters.AddWithValue("@importe", importe);
                    command.Parameters.AddWithValue("@fecha", fecha);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Actualiza un registro existente de pago de compra
        /// </summary>
        /// <param name="idHistorialPagosCompra">ID del registro a actualizar</param>
        /// <param name="idCompra">Nuevo ID de compra</param>
        /// <param name="idPago">Nuevo ID de tipo de pago</param>
        /// <param name="importe">Nuevo importe</param>
        /// <param name="fecha">Nueva fecha</param>
        /// <returns>Número de filas afectadas (1 = éxito, 0 = error)</returns>
        public static int ActualizarHistorialPagoCompra(int idHistorialPagosCompra, int idCompra, int idPago, decimal importe, DateTime fecha)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"UPDATE HistorialPagosCompra 
                                     SET idCompra = @idCompra, 
                                         idPago = @idPago, 
                                         importe = @importe, 
                                         fecha = @fecha 
                                     WHERE idHistorialPagosCompra = @idHistorial";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idHistorial", idHistorialPagosCompra);
                    command.Parameters.AddWithValue("@idCompra", idCompra);
                    command.Parameters.AddWithValue("@idPago", idPago);
                    command.Parameters.AddWithValue("@importe", importe);
                    command.Parameters.AddWithValue("@fecha", fecha);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Elimina un registro de pago de compra
        /// </summary>
        /// <param name="idHistorialPagosCompra">ID del registro a eliminar</param>
        /// <returns>Número de filas afectadas (1 = éxito, 0 = error)</returns>
        public static int EliminarHistorialPagoCompra(int idHistorialPagosCompra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = "DELETE FROM HistorialPagosCompra WHERE idHistorialPagosCompra = @idHistorial";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idHistorial", idHistorialPagosCompra);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Obtiene los pagos asociados a una compra específica
        /// </summary>
        /// <param name="idCompra">ID de la compra a consultar</param>
        /// <returns>DataTable con los pagos de la compra especificada</returns>
        public static DataTable ObtenerPagosPorCompra(int idCompra)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                const string query = @"SELECT idHistorialPagosCompra, idPago, importe, fecha 
                                     FROM HistorialPagosCompra 
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