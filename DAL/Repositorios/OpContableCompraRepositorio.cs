using DAL.Interfaces;
using DAL.Entidades;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Linq;
using System;

namespace DAL.Repositorios
{
    public class OpContableCompraRepository : IOpContableCompraRepository
    {
        private readonly IDbConnection _dbConnection;

        public OpContableCompraRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Implementación del método para insertar en TOpContableCompra

        public void AddOpContableCompra(OpContableCompra _opContableCompra)
        {
            var query = "INSERT INTO TOpContableCompra (IdCompra, IdOpContable) VALUES (@IdCompra, @idOpContable)";
            _dbConnection.Execute(query, _opContableCompra);
        }
        public (int IdIngreso, int IdGasto) IdsOpContableCompraActiva(int idcompraActiva)
        {
            var query = "SELECT idOpContableCompra FROM TOpContableCompra WHERE idCompra = @IdCompra";
            var ids = _dbConnection.Query<int>(query, new { IdCompra = idcompraActiva }).ToArray();

            if (ids.Length != 2)
                throw new InvalidOperationException("Deben existir exactamente 2 registros.");

            return (ids[0], ids[1]); // Tupla con los dos IDs
        }
    }
}
