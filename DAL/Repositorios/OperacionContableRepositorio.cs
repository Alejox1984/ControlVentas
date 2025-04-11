using DAL.Interfaces;
using DAL.Entidades;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Repositories
{
    public class OperacionContableRepository : IOpContableCompra
    {
        private readonly SqlConnection _dbConnection;

        public OperacionContableRepository(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Este método debe ser público para cumplir con el contrato de la interfaz
        public int AddOperacionContable(OperacionContable operacionContable)
        {
            var query = "INSERT INTO TOperacionContable (IdDetalleOperacion, Importe, Fecha) OUTPUT INSERTED.IdOperacionContable VALUES (@IdDetalleOperacion, @Importe, @Fecha)";
            return _dbConnection.QuerySingle<int>(query, operacionContable);
        }
    }
}

