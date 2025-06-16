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
        /// <summary>
        /// Obtiene el IdCompra de la última compra realizada en la base de datos.
        /// </summary>
        /// <returns>El identificador único de la última compra.</returns>
             int UltimaCompra();
        /// <summary>
        /// Actualiza los datos de una compra existente en la base de datos.
        /// </summary>
        /// <param name="idCompra">ID de la compra a modificar.</param>
        /// <param name="idIngreso">Nuevo ID de ingreso asociado a la compra.</param>
        /// <param name="idGasto">Nuevo ID de gasto asociado a la compra.</param>
        /// <returns>
        /// **True**: Si la compra fue actualizada correctamente (al menos 1 fila afectada).
        /// **False**: Si no se encontró la compra (0 filas afectadas).
        /// </returns>
        /// <remarks>
        /// Este método ejecuta un UPDATE directo en la tabla `TCompra`.
        /// No maneja excepciones; deben ser gestionadas por la capa de servicio.
        /// </remarks>
        bool ModificarCompraIngresoGasto(int idCompra, int idIngreso, int idGasto);
        void EliminarCompra(int id);
        }
    
}
