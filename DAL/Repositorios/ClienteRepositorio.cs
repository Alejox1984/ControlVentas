// DAL/Repositories/ClienteRepository.cs
using System.Data;
using Dapper;
using DAL.Entidades;
using DAL.Interfaces;
using System.Windows.Forms;

namespace DAL.Repositories
{
    public class ClienteRepository : IClienteRepository  // Implementa la interfaz
    {
        private readonly IDbConnection _db;

        public ClienteRepository(IDbConnection dbConnection)
        {
            _db = dbConnection;
        }

        // ¡Aquí sí implementas el método!
        
        public string ObtenerNombrePorId(int idCliente)
        {
            var query = "SELECT Nombre FROM TCliente WHERE id_cliente = @IdCliente";
            return _db.QueryFirstOrDefault<string>(query, new { IdCliente = idCliente });
        }
        public int ObtenerIdPorNombre(string nombreCliente)
        {
            var query = "SELECT id_cliente FROM TCliente WHERE Nombre = @NombreCliente";
            return _db.QueryFirstOrDefault<int>(query, new { NombreCliente = nombreCliente });
        }
    }
}