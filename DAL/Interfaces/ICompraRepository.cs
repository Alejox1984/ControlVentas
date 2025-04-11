using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;

namespace DAL.Interfaces
{

        /// <summary>
        /// Interfaz para el repositorio de compras
        /// </summary>
        public interface ICompraRepository
        {
            /// <summary>
            /// Cuenta las compras de un cliente en una fecha específica
            /// </summary>
            /// <param name="idCliente">ID del cliente</param>
            /// <param name="fecha">Fecha de consulta (se ignora la hora)</param>
            /// <returns>Número total de compras</returns>
            int ContarComprasPorClienteYFecha(int idCliente, DateTime fecha);
        /// <summary>
        /// Agrega una nuevaCompra
        /// </summary>
             int AddCompra(Compra _compra); 
        }
    
}
