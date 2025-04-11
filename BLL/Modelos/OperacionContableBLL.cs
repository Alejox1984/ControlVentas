using System;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// Capa BLL para la gestión de operaciones contables
    /// Contiene la lógica de negocio para las operaciones contables
    /// </summary>
    public class OperacionContableBLL
    {
        /// <summary>
        /// Registra una nueva operación contable
        /// </summary>
        /// <param name="idDetalleOperacion">ID del detalle de operación</param>
        /// <param name="fecha">Fecha de la operación</param>
        /// <param name="importe">Importe de la operación</param>
        /// <returns>ID de la nueva operación creada</returns>
        /// <exception cref="ArgumentException">Error en datos de entrada</exception>
        public static int RegistrarOperacionContable(int idDetalleOperacion, DateTime fecha, decimal importe)
        {
            if (idDetalleOperacion <= 0)
                throw new ArgumentException("El ID de detalle de operación no es válido");

            if (importe <= 0)
                throw new ArgumentException("El importe debe ser mayor a cero");

            if (fecha > DateTime.Now)
                throw new ArgumentException("La fecha no puede ser futura");

            return OperacionContableDAL.InsertarOperacionContable(idDetalleOperacion, fecha, importe);
        }

        /// <summary>
        /// Actualiza una operación contable existente
        /// </summary>
        /// <param name="idOperacionContable">ID de la operación a actualizar</param>
        /// <param name="idDetalleOperacion">Nuevo ID del detalle de operación</param>
        /// <param name="fecha">Nueva fecha</param>
        /// <param name="importe">Nuevo importe</param>
        /// <returns>True si se actualizó correctamente</returns>
        /// <exception cref="ArgumentException">Error en datos de entrada</exception>
        public static bool ModificarOperacionContable(int idOperacionContable, int idDetalleOperacion, DateTime fecha, decimal importe)
        {
            if (idOperacionContable <= 0)
                throw new ArgumentException("ID de operación no válido");

            if (idDetalleOperacion <= 0)
                throw new ArgumentException("El ID de detalle de operación no es válido");

            if (importe <= 0)
                throw new ArgumentException("El importe debe ser mayor a cero");

            if (fecha > DateTime.Now)
                throw new ArgumentException("La fecha no puede ser futura");

            return OperacionContableDAL.ActualizarOperacionContable(idOperacionContable, idDetalleOperacion, fecha, importe);
        }

        /// <summary>
        /// Elimina una operación contable
        /// </summary>
        /// <param name="idOperacionContable">ID de la operación a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        /// <exception cref="ArgumentException">ID de operación no válido</exception>
        public static bool EliminarOperacionContable(int idOperacionContable)
        {
            if (idOperacionContable <= 0)
                throw new ArgumentException("ID de operación no válido");

            return OperacionContableDAL.EliminarOperacionContable(idOperacionContable);
        }

        /// <summary>
        /// Obtiene los datos de una operación contable
        /// </summary>
        /// <param name="idOperacionContable">ID de la operación a consultar</param>
        /// <returns>DataRow con los datos de la operación o null si no existe</returns>
        /// <exception cref="ArgumentException">ID de operación no válido</exception>
        public static DataRow ConsultarOperacion(int idOperacionContable)
        {
            if (idOperacionContable <= 0)
                throw new ArgumentException("ID de operación no válido");

            return OperacionContableDAL.ObtenerOperacionPorId(idOperacionContable);
        }

        /// <summary>
        /// Calcula el total de importes para un detalle de operación específico
        /// </summary>
        /// <param name="idDetalleOperacion">ID del detalle de operación</param>
        /// <returns>Suma total de los importes</returns>
        public static decimal CalcularTotalPorDetalleOperacion(int idDetalleOperacion)
        {
            DataTable dt = OperacionContableDAL.ListarOperacionesContables();
            decimal total = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row["idDetalleOperacion"]) == idDetalleOperacion)
                {
                    total += Convert.ToDecimal(row["importe"]);
                }
            }

            return total;
        }
    }
}