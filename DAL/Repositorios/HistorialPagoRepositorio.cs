using DAL.Interfaces;
using DAL.Entidades;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Repositories
{
    public class HistorialPagosCompraRepository : IHistorialPagoCompra
    {
        private readonly SqlConnection _dbConnection;

        public HistorialPagosCompraRepository(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Implementación del método para insertar en THistorialPagosCompra
        public void AddOpHistorialPago(HistorialPagoCompra historialPagosCompra)
        {
            var query = "INSERT INTO THistorialPagosCompra (IdCompra, IdPagos, Importe, Fecha) VALUES (@IdCompra, @IdPagos, @Importe, @Fecha)";
            _dbConnection.Execute(query, historialPagosCompra);
        }
    }
}

