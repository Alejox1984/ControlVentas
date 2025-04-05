using System;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// Capa BLL para la gestión de tipos de pago
    /// Contiene la lógica de negocio para los tipos de pago
    /// </summary>
    public class TiposPagoBLL
    {
        /// <summary>
        /// Obtiene todos los tipos de pago disponibles
        /// </summary>
        /// <returns>DataTable con la lista de tipos</returns>
        public static DataTable ListarTodos()
        {
            return TiposPagoDAL.ListarTiposPago();
        }

        /// <summary>
        /// Obtiene el nombre de un tipo de pago por su ID
        /// </summary>
        /// <param name="idTipoPago">ID del tipo de pago</param>
        /// <returns>Nombre del tipo de pago</returns>
        /// <exception cref="ArgumentException">ID no válido</exception>
        public static string ObtenerNombreTipoPago(int idTipoPago)
        {
            if (idTipoPago <= 0)
                throw new ArgumentException("ID de tipo de pago no válido");

            DataRow tipo = TiposPagoDAL.ObtenerTipoPagoPorId(idTipoPago);

            if (tipo == null)
                throw new InvalidOperationException("Tipo de pago no encontrado");

            return tipo["tipoPago"].ToString();
        }
    }
}