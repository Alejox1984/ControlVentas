using DAL.Interfaces;
using DAL.Entidades;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace DAL.Repositories
{
    public class HistorialPagosCompraRepository : IHistorialPagoCompra
    {
        private readonly IDbConnection _dbConnection;

        public HistorialPagosCompraRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Implementación del método para insertar en THistorialPagosCompra
        public void AddOpHistorialPago(HistorialPagoCompra historialPagosCompra)
        {
            var query = "INSERT INTO THistorialPagosCompra (IdCompra, IdPago, Importe, Fecha) VALUES (@IdCompra, @IdPago, @Importe, @Fecha)";
            _dbConnection.Execute(query, historialPagosCompra);
        }
    }
}

