using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DAL.Interfaces;
using DAL.Entidades;

namespace DAL.Repositorios
{
    
    namespace Control_de_Ventas_Online.DAL.Repositorios
    {
        public class CompraRepository : ICompraRepository
        {
            private readonly IDbConnection _db;

            public CompraRepository(IDbConnection dbConnection)
            {
                _db = dbConnection;
            }

            public int ContarComprasPorClienteYFecha(int idCliente, DateTime fecha)
            {
                const string sql = @"
                SELECT COUNT(*) 
                FROM TCompra 
                WHERE IdCliente = @IdCliente 
                AND CAST(fecha AS DATE) = CAST(@Fecha AS DATE)";

                return _db.ExecuteScalar<int>(sql, new
                {
                    IdCliente = idCliente,
                    Fecha = fecha.Date
                });
            }
            public int AddCompra(Compra compra)
            {
                var query = "INSERT INTO TCompra (IdCliente, IdGasto, IdIngreso, IdPlataforma, IdStatus, Fecha, CodigoCompra) " +
                            "OUTPUT INSERTED.IdCompra VALUES (@IdCliente, @IdGasto, @IdIngreso, @IdPlataforma, @IdStatus, @Fecha, @CodigoCompra)";

                return _db.QuerySingle<int>(query, compra);
            }
        }
    }
}
