using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Dapper;

namespace DAL.Repositorios
{
    public class TasaRepository :ITasaRepository
    {
        private readonly IDbConnection _dbConnection;

        public TasaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public decimal[] ObtenerTasas() 
        {
            var query = "SELECT tasaPorCambio, tasaUSDReal FROM TTasas";
            var resultado = _dbConnection.QueryFirstOrDefault(query);

            if (resultado == null)
                return new decimal[] { 0m, 0m }; // Valores por defecto si no hay datos

            return new decimal[]
            {
              (decimal)resultado.tasaPorCambio,
              (decimal)resultado.tasaUSDReal
            };
        }
    }
}
