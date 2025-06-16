using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositorios;

namespace BLL.Servicios
{
    public class TasasService
    {
        private readonly ITasaRepository _tasarepoitory;

        public TasasService(ITasaRepository tasaRepository) 
        {
            _tasarepoitory = tasaRepository;
        }
        public decimal[] ObtenerTasas() 
        {
            return _tasarepoitory.ObtenerTasas();
        }

    }
}
