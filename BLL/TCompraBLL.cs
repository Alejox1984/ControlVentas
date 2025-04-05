using System;
using System.Data;
using DAL;

namespace BLL
{
    public class TCompraBLL
    {
        private readonly TCompraDAL compraDAL;

        public TCompraBLL(string connectionString)
        {
            compraDAL = new TCompraDAL(connectionString);
        }

        public DataTable GetAllCompras()
        {
            try
            {
                return compraDAL.GetAllCompras();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las compras: " + ex.Message);
            }
        }

        public bool InsertCompra(int idCliente, int idGasto, int idIngreso, int idPlataforma, int idStatus, DateTime fecha, string codigo)
        {
            // Validaciones de negocio
            if (string.IsNullOrEmpty(codigo))
                throw new ArgumentException("El código no puede estar vacío");

            if (fecha > DateTime.Now)
                throw new ArgumentException("La fecha no puede ser futura");

            try
            {
                return compraDAL.InsertCompra(idCliente, idGasto, idIngreso, idPlataforma, idStatus, fecha, codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la compra: " + ex.Message);
            }
        }

        public bool UpdateCompra(int idCompra, int idCliente, int idGasto, int idIngreso, int idPlataforma, int idStatus, DateTime fecha, string codigo)
        {
            // Validaciones de negocio
            if (string.IsNullOrEmpty(codigo))
                throw new ArgumentException("El código no puede estar vacío");

            try
            {
                return compraDAL.UpdateCompra(idCompra, idCliente, idGasto, idIngreso, idPlataforma, idStatus, fecha, codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la compra: " + ex.Message);
            }
        }

        public bool DeleteCompra(int idCompra)
        {
            try
            {
                return compraDAL.DeleteCompra(idCompra);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la compra: " + ex.Message);
            }
        }

        public DataTable GetCompraById(int idCompra)
        {
            try
            {
                return compraDAL.GetCompraById(idCompra);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la compra: " + ex.Message);
            }
        }
    }
}