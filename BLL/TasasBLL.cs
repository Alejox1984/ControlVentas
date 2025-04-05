using System;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// Capa BLL para la gestión de tasas
    /// Contiene la lógica de negocio para las tasas
    /// </summary>
    public class TasasBLL
    {
        /// <summary>
        /// Obtiene la última configuración de tasas
        /// </summary>
        /// <returns>DataRow con los datos de tasas</returns>
        /// <exception cref="InvalidOperationException">No hay tasas configuradas</exception>
        public static DataRow ObtenerTasasActuales()
        {
            DataRow tasas = TasasDAL.ObtenerUltimaTasa();

            if (tasas == null)
                throw new InvalidOperationException("No hay tasas configuradas en el sistema");

            return tasas;
        }

        /// <summary>
        /// Actualiza las tasas del sistema
        /// </summary>
        /// <param name="tasaUSD">Nueva tasa USD</param>
        /// <param name="tasaPorVenta">Nueva tasa por venta</param>
        /// <param name="tasaPorCambio">Nueva tasa por cambio</param>
        /// <returns>ID de la nueva configuración</returns>
        /// <exception cref="ArgumentException">Tasas no válidas</exception>
        public static int ActualizarTasas(decimal tasaUSD, decimal tasaPorVenta, decimal tasaPorCambio)
        {
            if (tasaUSD <= 0 || tasaPorVenta <= 0 || tasaPorCambio <= 0)
                throw new ArgumentException("Todas las tasas deben ser mayores a cero");

            return TasasDAL.InsertarTasa(tasaUSD, tasaPorVenta, tasaPorCambio);
        }

        /// <summary>
        /// Obtiene la tasa de cambio USD actual
        /// </summary>
        /// <returns>Valor de la tasa USD</returns>
        public static decimal ObtenerTasaUSD()
        {
            DataRow tasas = ObtenerTasasActuales();
            return Convert.ToDecimal(tasas["tasaUSD"]);
        }
    }
}
