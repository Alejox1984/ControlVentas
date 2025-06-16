using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;
using DAL.Interfaces;
using DAL.Repositorios.Control_de_Ventas_Online.DAL.Repositorios;
namespace BLL.Servicios
{
    public class OpContableCompraService
    {
        private readonly IOpContableCompraRepository  _opContableCompra;

        public OpContableCompraService(IOpContableCompraRepository opContableCompraRepository) 
        {
            _opContableCompra = opContableCompraRepository;
        }
        public void AddOpContableCompra(OpContableCompra opContableCompra) 
        {
             _opContableCompra.AddOpContableCompra(opContableCompra);
        }
        public (int IdIngreso, int IdGasto) ObtenerIdsOperacionesContables(int idCompra)
        {
            try
            {
                return _opContableCompra.IdsOpContableCompraActiva(idCompra);
            }
            catch (KeyNotFoundException ex)
            {
                // Loggear el error si es necesario
                throw new ApplicationException("Error al obtener IDs de operaciones contables", ex);
            }
        }
    }
}

