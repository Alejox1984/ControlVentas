using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;
using DAL.Interfaces;
using Dapper;

namespace DAL.Repositorios
{
    public class PlataformaRepository : IPlataformaRepository
    {
        private readonly IDbConnection _db;
        public PlataformaRepository(IDbConnection dbConnection) 
        {
            _db = dbConnection;
        }
        public string ObtenerPlataformaPorId(int idPlataforma) 
        {
            var query = "SELECT plataforma FROM TPlataforma WHERE id_cliente = @idPlataforma";
            return _db.QueryFirstOrDefault<string>(query, new { IdPlataforma = idPlataforma });
        }
        public int ObtenerIdPorNombrePlataforma(string plataforma) 
        {
            var query = "SELECT idPlataforma FROM TPlataforma WHERE plataforma = @plataforma";
            return _db.QueryFirstOrDefault<int>(query, new { plataforma = plataforma });

        }

    }
}
