using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ClienteDAL
    {
        private static string connectionString = "Server=LAPTOPHP\\SQLEXPRESS;Database=ControlVentasOnline;Integrated Security=True;";


        public DataTable ObtenerClientesDesdeVista()
        {
            // Crear el DataTable donde almacenaremos los datos
            DataTable clientesTable = new DataTable();

            // Consulta SQL para obtener los datos de la vista
            string query = "SELECT * FROM ViewCliente";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Usar SqlDataAdapter para ejecutar la consulta y llenar el DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(clientesTable);
                }
                catch (Exception ex)
                {
                    // Manejo de errores (puedes personalizar esto según necesites)
                    throw new Exception("Error al obtener datos de la vista: " + ex.Message);
                }
            }

            return clientesTable; // Retornar los datos al nivel de negocio o presentación
        }

            public DataTable ObtenerClientes()
        {
            DataTable clientesTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ObtenerClientes", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(clientesTable);
            }

            return clientesTable;
        }

        public void InsertarCliente(string nombre, string direccion, string telefono)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TCliente (Nombre, Direccion, Telefono) VALUES (@Nombre, @Direccion, @Telefono)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Direccion", direccion);
                command.Parameters.AddWithValue("@Telefono", telefono);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarCliente(int id, string nombre, string direccion, string telefono)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE TCliente SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono WHERE id_cliente = @id_cliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_cliente", id); // Corregido: Usar @id_cliente
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Direccion", direccion);
                command.Parameters.AddWithValue("@Telefono", telefono);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TCliente WHERE id_cliente = @id_cliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_cliente", id); // Corregido: Usar @id_cliente
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}