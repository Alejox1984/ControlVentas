using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;

namespace DAL.Interfaces
{
    public interface IOpContableCompraRepository
    {
        /// <summary>
        /// Inserta una nueva operación contable para Compra Online especificamente y devuelve el ID generado.
        /// </summary>
        void AddOpContableCompra(OpContableCompra _opContableCompra);
        (int IdIngreso,int  IdGasto) IdsOpContableCompraActiva(int idCompraActiva);
    }
}
