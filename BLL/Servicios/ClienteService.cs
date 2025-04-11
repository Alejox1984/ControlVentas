using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Servicios
{
    // BLL/Services/ClienteService.cs
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Solo obtiene datos del cliente (sin lógica de compras)
        public string ObtenerNombreCliente(int idCliente)
        {
            if (idCliente <= 0)
                throw new ArgumentException("ID de cliente no válido");

            var nombreCliente = _clienteRepository.ObtenerNombrePorId(idCliente);
            if (string.IsNullOrEmpty(nombreCliente))
                throw new Exception("Cliente no encontrado");

            return nombreCliente;
        }
        public int ObtenerIdPorNombre(string nombreCliente)
        {
            if (string.IsNullOrEmpty(nombreCliente))
                throw new ArgumentException("El nombre del cliente no puede estar vacío.");

            int idCliente = _clienteRepository.ObtenerIdPorNombre(nombreCliente);
            if (idCliente <= 0)
                throw new Exception("Cliente no encontrado.");

            return idCliente;
        }
    }
}
