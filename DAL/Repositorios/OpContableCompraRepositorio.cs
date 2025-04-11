using DAL.Interfaces;
using DAL.Entidades;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Repositorios
{
    public class OpContableCompraRepository : IOpContableCompraRepository
    {
        private readonly SqlConnection _dbConnection;

        public OpContableCompraRepository(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Implementación del método para insertar en TOpContableCompra
        
        public void AddOpContableCompra(OpContableCompra _opContableCompra)
        {
            var query = "INSERT INTO TOpContableCompra (IdCompra, IdOperacionContable) VALUES (@IdCompra, @IdOperacionContable)";
            _dbConnection.Execute(query,_opContableCompra);
        }
    }
}
