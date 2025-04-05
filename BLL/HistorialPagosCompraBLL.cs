using System;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// Capa de lógica de negocios para el historial de pagos de compras
    /// </summary>
    public class HistorialPagosCompraBLL
    {
        /// <summary>
        /// Obtiene todos los registros de pagos de compras
        /// </summary>
        /// <returns>DataTable con el historial completo de pagos</returns>
        /// <exception cref="Exception">Error al acceder a la capa de datos</exception>
        public DataTable ListarHistorialPagos()
        {
            try
            {
                return HistorialPagosCompraDAL.ListarHistorialPagosCompra();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el historial de pagos: " + ex.Message);
            }
        }

        /// <summary>
        /// Registra un nuevo pago de compra en el sistema
        /// </summary>
        /// <param name="idCompra">ID de la compra asociada</param>
        /// <param name="idPago">ID del tipo de pago</param>
        /// <param name="importe">Monto del pago</param>
        /// <param name="fecha">Fecha del pago</param>
        /// <returns>True si el registro fue exitoso</returns>
        /// <exception cref="ArgumentException">Datos inválidos</exception>
        /// <exception cref="Exception">Error al registrar el pago</exception>
        public bool RegistrarPagoCompra(int idCompra, int idPago, decimal importe, DateTime fecha)
        {
            // Validaciones de negocio
            if (idCompra <= 0)
                throw new ArgumentException("El ID de compra no es válido");

            if (idPago <= 0)
                throw new ArgumentException("El ID de pago no es válido");

            if (importe <= 0)
                throw new ArgumentException("El importe debe ser mayor a cero");

            if (fecha > DateTime.Now)
                throw new ArgumentException("La fecha no puede ser futura");

            try
            {
                int result = HistorialPagosCompraDAL.InsertarHistorialPagoCompra(idCompra, idPago, importe, fecha);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el pago: " + ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un registro de pago existente
        /// </summary>
        /// <param name="idHistorial">ID del registro a actualizar</param>
        /// <param name="idCompra">Nuevo ID de compra</param>
        /// <param name="idPago">Nuevo ID de tipo de pago</param>
        /// <param name="importe">Nuevo importe</param>
        /// <param name="fecha">Nueva fecha</param>
        /// <returns>True si la actualización fue exitosa</returns>
        /// <exception cref="ArgumentException">Datos inválidos</exception>
        /// <exception cref="Exception">Error al actualizar el registro</exception>
        public bool ActualizarPagoCompra(int idHistorial, int idCompra, int idPago, decimal importe, DateTime fecha)
        {
            // Validaciones de negocio
            if (idHistorial <= 0)
                throw new ArgumentException("ID de historial inválido");

            if (idCompra <= 0)
                throw new ArgumentException("El ID de compra no es válido");

            if (idPago <= 0)
                throw new ArgumentException("El ID de pago no es válido");

            if (importe <= 0)
                throw new ArgumentException("El importe debe ser mayor a cero");

            if (fecha > DateTime.Now)
                throw new ArgumentException("La fecha no puede ser futura");

            try
            {
                int result = HistorialPagosCompraDAL.ActualizarHistorialPagoCompra(
                    idHistorial, idCompra, idPago, importe, fecha);

                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pago: " + ex.Message);
            }
        }

        /// <summary>
        /// Elimina un registro de pago de compra
        /// </summary>
        /// <param name="idHistorial">ID del registro a eliminar</param>
        /// <returns>True si la eliminación fue exitosa</returns>
        /// <exception cref="ArgumentException">ID inválido</exception>
        /// <exception cref="Exception">Error al eliminar el registro</exception>
        public bool EliminarPagoCompra(int idHistorial)
        {
            if (idHistorial <= 0)
                throw new ArgumentException("ID de historial inválido");

            try
            {
                int result = HistorialPagosCompraDAL.EliminarHistorialPagoCompra(idHistorial);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pago: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los pagos asociados a una compra específica
        /// </summary>
        /// <param name="idCompra">ID de la compra a consultar</param>
        /// <returns>DataTable con los pagos de la compra</returns>
        /// <exception cref="ArgumentException">ID inválido</exception>
        /// <exception cref="Exception">Error al obtener los pagos</exception>
        public DataTable ObtenerPagosPorCompra(int idCompra)
        {
            if (idCompra <= 0)
                throw new ArgumentException("ID de compra inválido");

            try
            {
                return HistorialPagosCompraDAL.ObtenerPagosPorCompra(idCompra);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pagos de la compra: " + ex.Message);
            }
        }

        /// <summary>
        /// Calcula el total pagado para una compra específica
        /// </summary>
        /// <param name="idCompra">ID de la compra</param>
        /// <returns>Total pagado</returns>
        /// <exception cref="ArgumentException">ID inválido</exception>
        /// <exception cref="Exception">Error al calcular el total</exception>
        public decimal CalcularTotalPagado(int idCompra)
        {
            if (idCompra <= 0)
                throw new ArgumentException("ID de compra inválido");

            try
            {
                DataTable pagos = ObtenerPagosPorCompra(idCompra);
                decimal total = 0;

                foreach (DataRow row in pagos.Rows)
                {
                    total += Convert.ToDecimal(row["importe"]);
                }

                return total;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al calcular el total pagado: " + ex.Message);
            }
        }
    }
}
