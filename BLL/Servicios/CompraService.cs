using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entidades;
using DAL.Repositories;
using System.Runtime.InteropServices;

namespace BLL.Servicios
{
    // BLL/Services/CompraService.cs
    public class CompraService
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IOperacionContableRepository _operacionContableRepository;
        private readonly IOpContableCompraRepository _opContableCompraRepository;
        private readonly IHistorialPagosCompraRepository _historialPagosCompraRepository;

        public CompraService(
            ICompraRepository compraRepository,
            IOperacionContableRepository operacionContableRepository,
            IOpContableCompraRepository opContableCompraRepository,
            IHistorialPagosCompraRepository historialPagosCompraRepository)
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
                    idOperacionContable = idOperacionContable
                });

                // 4. Insertar en THistorialPagosCompra
                _historialPagosCompraRepository.InsertarHistorialPagos(new HistorialPagoCompra
                {
                    idCompra = idCompra,
                    idpago = 1, // Pagos estándar
                    importe = nuevaOperacion.importe,
                    fecha = nuevaCompra.fecha
                });

                // Si hay anticipo, insertar otro registro en THistorialPagosCompra
                if (anticipo.HasValue && anticipo.Value > 0)
                {
                    _historialPagosCompraRepository.InsertarHistorialPagos(new HistorialPagoCompra
                    {
                        idCompra = idCompra,
                        idPago = 2, // Anticipo
                        importe = nuevaOperacion.importe,
                        fecha = nuevaCompra.fecha
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar la compra completa: {ex.Message}", ex);
            }
        }
    }
}
