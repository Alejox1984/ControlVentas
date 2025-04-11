using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TCompraDAL
    {
        private readonly string connectionString;

        public TCompraDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetAllCompras()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TCompra";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public bool InsertCompra(int idCliente, int idGasto, int idIngreso, int idPlataforma, int idStatus, DateTime fecha, string codigo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO TCompra (idCliente, idGasto, idIngreso, idPlataforma, idStatus, fecha, codigo) 
                                VALUES (@idCliente, @idGasto, @idIngreso, @idPlataforma, @idStatus, @fecha, @codigo)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@idGasto", idGasto);
                cmd.Parameters.AddWithValue("@idIngreso", idIngreso);
                cmd.Parameters.AddWithValue("@idPlataforma", idPlataforma);
                cmd.Parameters.AddWithValue("@idStatus", idStatus);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@codigo", codigo);

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool UpdateCompra(int idCompra, int idCliente, int idGasto, int idIngreso, int idPlataforma, int idStatus, DateTime fecha, string codigo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE TCompra SET 
                                idCliente = @idCliente,
                                idGasto = @idGasto,
                                idIngreso = @idIngreso,
                                idPlataforma = @idPlataforma,
                                idStatus = @idStatus,
                                fecha = @fecha,
                                codigo = @codigo
                                WHERE idCompra = @idCompra";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@idGasto", idGasto);
                cmd.Parameters.AddWithValue("@idIngreso", idIngreso);
                cmd.Parameters.AddWithValue("@idPlataforma", idPlataforma);
                cmd.Parameters.AddWithValue("@idStatus", idStatus);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@codigo", codigo);

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteCompra(int idCompra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TCompra WHERE idCompra = @idCompra";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idCompra", idCompra);

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public DataTable GetCompraById(int idCompra)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TCompra WHERE idCompra = @idCompra";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}