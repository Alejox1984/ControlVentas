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
                var query = "INSERT INTO TCompra (IdCliente, IdGasto, IdIngreso, IdPlataforma, IdStatus, fecha, codigo) " +
                            "OUTPUT INSERTED.IdCompra VALUES (@IdCliente, @IdGasto, @IdIngreso, @IdPlataforma, @IdStatus, @Fecha, @codigo)";

                return _db.QuerySingle<int>(query, compra);
            }
            /// <summary>
            /// Obtiene el IdCompra de la última compra realizada en la base de datos.
            /// </summary>
            /// <returns>El identificador único de la última compra.</returns>
            public int UltimaCompra()
            {
                // Consulta SQL para obtener el primer registro (más reciente) basado en el orden descendente de IdCompra.
                var query = "SELECT TOP 1 IdCompra FROM TCompra " +
                            "ORDER BY IdCompra DESC";

                try
                {
                    // Ejecución de la consulta y obtención del resultado como un entero.
                    // Si la tabla está vacía, esto lanzará una excepción que debe manejarse.
                    return _db.QuerySingle<int>(query);
                }
                catch (Exception ex)
                {
                    // Manejo de errores para capturar cualquier problema durante la ejecución de la consulta.
                    // Por ejemplo, problemas de conexión a la base de datos o ausencia de resultados.
                    Console.WriteLine($"Error al obtener el IdCompra de la última compra: {ex.Message}");

                    // Opcionalmente, puedes decidir si quieres lanzar la excepción o retornar un valor predeterminado.
                    throw new InvalidOperationException("No se pudo obtener el IdCompra de la última compra.", ex);
                }
            }
            public bool ModificarCompraIngresoGasto(int idCompra, int idIngreso, int idGasto)
            {
                var query = @"
        UPDATE TCompra 
        SET IdIngreso = @IdIngreso, 
            IdGasto = @IdGasto 
        WHERE IdCompra = @IdCompra";

                int filasAfectadas = _db.Execute(query, new
                {
                    IdCompra = idCompra,
                    IdIngreso = idIngreso,
                    IdGasto = idGasto
                });

                return filasAfectadas > 0;
            }

            /// <summary>
            /// Elimina una compra y todos sus registros relacionados en las tablas:
            /// 1. TOperacionContable (relacionada indirectamente)
            /// 2. TOpContableCompra (relacionada directamente)
            /// 3. THistorialPagosCompra (relacionada directamente)
            /// 4. TCompra (tabla principal)
            /// </summary>
            /// <param name="idCompra">ID de la compra a eliminar</param>
            /// <exception cref="Exception">Error durante la eliminación</exception>
            public void EliminarCompra(int idCompra)
            {
                try
                {
                    if (_db.State != ConnectionState.Open)
                        _db.Open();

                    using (var transaction = _db.BeginTransaction())
                    {
                        try
                        {

                            // 1. Primero obtener los IDs de operaciones contables relacionados
                            string sqlObtenerIDs = @"
                              SELECT idOpContable FROM TOpContableCompra 
                              WHERE idCompra = @idCompra";
                            var idsOpContable = _db.Query<int>(sqlObtenerIDs, new { idCompra }, transaction).ToList();

                            // 2. Eliminar los registros de la tabla intermedia
                            string sqlEliminarOpContableCompra = @"
                               DELETE FROM TOpContableCompra 
                               WHERE idCompra = @idCompra";
                             _db.Execute(sqlEliminarOpContableCompra, new { idCompra }, transaction);

                            // 3. Eliminar los registros de TOperacionContable
                            if (idsOpContable.Any())
                            {
                                string sqlEliminarOperacionContable = @"
                              DELETE FROM TOperacionContable 
                              WHERE idOperacionContable IN @idsOpContable";
                                _db.Execute(sqlEliminarOperacionContable, new { idsOpContable }, transaction);
                            }

                            // 4. Eliminar de THistorialPagosCompra (relacionada directamente)
                            string sqlHistorialPagos = "DELETE FROM THistorialPagosCompra WHERE idCompra = @idCompra";
                            _db.Execute(sqlHistorialPagos, new { idCompra }, transaction);

                            // 5. Finalmente eliminar la compra principal
                            string sqlCompra = "DELETE FROM TCompra WHERE idCompra = @idCompra";
                            int affectedRows = _db.Execute(sqlCompra, new { idCompra }, transaction);

                            if (affectedRows == 0)
                                throw new KeyNotFoundException($"No se encontró la compra con ID: {idCompra}");

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw; // Relanza la excepción para manejo superior
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al eliminar la compra y sus relaciones: {ex.Message}", ex);
                }
                finally
                {
                    if (_db.State == ConnectionState.Open)
                        _db.Close();
                }
            }

        }
    }
}
