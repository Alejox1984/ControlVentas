using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TProductoDAL
    {
        private static string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";

        public DataTable GetAllProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TProducto";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool InsertProducto(int idCompra, int idStatus, int idCategoria, string producto,
                                 decimal preciomxO, decimal preciomxF, decimal preciousO,
                                 decimal preciousF, int cantidad, string localizadorTransportista,
                                 string localizadorPlataforma, DateTime? fechaEEI,
                                 DateTime? fechaEEF, DateTime? fechaEC, byte[] imagenP)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO TProducto (
                                idCompra, idStatus, idCategoria, producto, preciomxO, preciomxF, 
                                preciousO, preciousF, cantidad, localizadorTransportista, 
                                localizadorPlataforma, fechaEEI, fechaEEF, fechaEC, imagenP) 
                                VALUES (
                                @idCompra, @idStatus, @idCategoria, @producto, @preciomxO, @preciomxF, 
                                @preciousO, @preciousF, @cantidad, @localizadorTransportista, 
                                @localizadorPlataforma, @fechaEEI, @fechaEEF, @fechaEC, @imagenP)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                cmd.Parameters.AddWithValue("@idStatus", idStatus);
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@preciomxO", preciomxO);
                cmd.Parameters.AddWithValue("@preciomxF", preciomxF);
                cmd.Parameters.AddWithValue("@preciousO", preciousO);
                cmd.Parameters.AddWithValue("@preciousF", preciousF);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@localizadorTransportista", localizadorTransportista ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@localizadorPlataforma", localizadorPlataforma ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fechaEEI", fechaEEI.HasValue ? (object)fechaEEI.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@fechaEEF", fechaEEF.HasValue ? (object)fechaEEF.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@fechaEC", fechaEC.HasValue ? (object)fechaEC.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@imagenP", imagenP ?? (object)DBNull.Value);

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool UpdateProducto(int idProducto, int idCompra, int idStatus, int idCategoria, string producto,
                                 decimal preciomxO, decimal preciomxF, decimal preciousO,
                                 decimal preciousF, int cantidad, string localizadorTransportista,
                                 string localizadorPlataforma, DateTime? fechaEEI,
                                 DateTime? fechaEEF, DateTime? fechaEC, byte[] imagenP)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE TProducto SET 
                                idCompra = @idCompra,
                                idStatus = @idStatus,
                                idCategoria = @idCategoria,
                                producto = @producto,
                                preciomxO = @preciomxO,
                                preciomxF = @preciomxF,
                                preciousO = @preciousO,
                                preciousF = @preciousF,
                                cantidad = @cantidad,
                                localizadorTransportista = @localizadorTransportista,
                                localizadorPlataforma = @localizadorPlataforma,
                                fechaEEI = @fechaEEI,
                                fechaEEF = @fechaEEF,
                                fechaEC = @fechaEC,
                                imagenP = @imagenP
                                WHERE idProducto = @idProducto";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                cmd.Parameters.AddWithValue("@idStatus", idStatus);
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@preciomxO", preciomxO);
                cmd.Parameters.AddWithValue("@preciomxF", preciomxF);
                cmd.Parameters.AddWithValue("@preciousO", preciousO);
                cmd.Parameters.AddWithValue("@preciousF", preciousF);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@localizadorTransportista", localizadorTransportista ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@localizadorPlataforma", localizadorPlataforma ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fechaEEI", fechaEEI.HasValue ? (object)fechaEEI.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@fechaEEF", fechaEEF.HasValue ? (object)fechaEEF.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@fechaEC", fechaEC.HasValue ? (object)fechaEC.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@imagenP", imagenP ?? (object)DBNull.Value);

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Los métodos DeleteProducto, GetProductoById y GetProductosByCompra permanecen iguales
        // ...
    }
}