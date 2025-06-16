using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entidades;
using DAL.Repositories;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BLL.Servicios
{
    // BLL/Services/CompraService.cs
    public class CompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IOpContableRepository _operacionContableRepository;
        private readonly IOpContableCompraRepository _opContableCompraRepository;
        private readonly IHistorialPagoCompra _historialPagosCompraRepository;

        public CompraService(
            ICompraRepository compraRepository,
            IOpContableRepository operacionContableRepository,
            IOpContableCompraRepository opContableCompraRepository,
            IHistorialPagoCompra historialPagosCompraRepository)
        {
            _compraRepository = compraRepository;
            _operacionContableRepository = operacionContableRepository;
            _opContableCompraRepository = opContableCompraRepository;
            _historialPagosCompraRepository = historialPagosCompraRepository;
        }

        public int ObtenerConteoCompras(int idCliente, DateTime fecha)
        {
            // Validaciones de negocio
            if (idCliente <= 0)
                throw new ArgumentException("ID de cliente no válido");

            if (fecha.Date > DateTime.Today)
                throw new ArgumentException("No se pueden consultar fechas futuras");

            return _compraRepository.ContarComprasPorClienteYFecha(idCliente, fecha);
        }

        public void InsertarCompraCompleta(Compra nuevaCompra, OperacionContable nuevaOperacion, decimal? anticipo)
        {
            try
            {
                // 1. Insertar en TOperacionContable
                int idOperacionContable = _operacionContableRepository.AddOperacionContable(nuevaOperacion);

                // 2. Insertar la compra y obtener IdCompra
                int idCompra = _compraRepository.AddCompra(nuevaCompra);

                // 3. Insertar en TOpContableCompra
                _opContableCompraRepository.AddOpContableCompra(new OpContableCompra
                {
                    idCompra = idCompra,
                    idOpContable = idOperacionContable
                });

                // 4. Insertar en THistorialPagosCompra
                _historialPagosCompraRepository.AddOpHistorialPago(new HistorialPagoCompra
                {
                    idCompra = idCompra,
                    idPago = 1, // Pagos estándar
                    importe = nuevaOperacion.importe,
                    fecha = nuevaCompra.fecha
                });

                // Si hay anticipo, insertar otro registro en THistorialPagosCompra
                if (anticipo.HasValue && anticipo.Value > 0)
                {
                    _historialPagosCompraRepository.AddOpHistorialPago(new HistorialPagoCompra
                    {
                        idCompra = idCompra,
                        idPago = 2, // Anticipo
                        importe = nuevaOperacion.importe,
                        fecha = nuevaCompra.fecha
                    });
                }
                MessageBox.Show("Nueva compra registrada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar la compra completa: {ex.Message}", ex);
            }
        }
        public int UltimaCompraID() 
        {
            return _compraRepository.UltimaCompra();
        }
        public void ActualizarCompraIDGastoIDIngreso(int idCompra, int idIngreso, int idGasto) 
        {
            try
            {
              _compraRepository.ModificarCompraIngresoGasto(idCompra, idIngreso, idGasto);

             MessageBox.Show("Pedido Finalizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al Finalizar Pedido: {ex.Message}", ex);
            }
        }
        
        /// <summary>
        /// Elimina una compra y sus relaciones, manejando errores y retornando mensajes amigables.
        /// </summary>
        /// <param name="idCompra">ID de la compra</param>
        /// <returns>Mensaje de éxito o error</returns>
        public string EliminarCompra(int idCompra) 
        {
            try
            {
                _compraRepository.EliminarCompra(idCompra);
                return "Compra eliminada con éxito";
            }
            catch (KeyNotFoundException ex)
            {
                return ex.Message; // Ej: "La compra no existe o ya fue eliminada"
            }
            catch (Exception ex)
            {
                return "Error al eliminar la compra: " + ex.Message;
            }
        }
    }
    }

