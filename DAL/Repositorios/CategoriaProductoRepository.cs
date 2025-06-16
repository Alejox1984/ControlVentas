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
    public class CategoriaProductoRepository : ICategoriaRepository
    {
        private readonly IDbConnection _db;
        public CategoriaProductoRepository(IDbConnection dbConnection) 
        {
            _db = dbConnection;
        }
        public string ObtenerCategoriaProductoPorId(int IdCategoria) 
        {
            var query = "SELECT categoria FROM TCategoria WHERE idCategoria = @IdCategoria";
            return _db.QueryFirstOrDefault<string>(query, new { idCategoria = IdCategoria });

        }
        public int ObtenerIdPorCategoriaProducto(string Categoria) 
        {
            var query = "SELECT idCategoria FROM TCategoria WHERE categoria = @Categoria";
            return _db.QueryFirstOrDefault<int>(query, new { categoria = Categoria });

        }
        public int ContarCategorias()
        {

            const string sql = @"
                SELECT COUNT(*) 
                FROM TCategoria";

            return _db.ExecuteScalar<int>(sql);
        }
    }
}
