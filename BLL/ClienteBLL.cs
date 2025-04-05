using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;  

namespace BLL
{
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public DataTable ObtenerClientes()
        {
            return clienteDAL.ObtenerClientesDesdeVista();
        }

        public void InsertarCliente(string nombre, string direccion, string telefono)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("El nombre no puede estar vacío.");
            if (string.IsNullOrEmpty(direccion))
                throw new Exception("La dirección no puede estar vacía.");
            if (string.IsNullOrEmpty(telefono))
                throw new Exception("El teléfono no puede estar vacío.");

            clienteDAL.InsertarCliente(nombre, direccion, telefono);
        }

        public void ActualizarCliente(int id, string nombre, string direccion, string telefono)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("El nombre no puede estar vacío.");
            if (string.IsNullOrEmpty(direccion))
                throw new Exception("La dirección no puede estar vacía.");
            if (string.IsNullOrEmpty(telefono))
                throw new Exception("El teléfono no puede estar vacío.");

            clienteDAL.ActualizarCliente(id, nombre, direccion, telefono);
        }

        public void EliminarCliente(int id)
        {
            clienteDAL.EliminarCliente(id);
        }
    }
}