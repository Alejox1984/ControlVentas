using System;
using System.Data;
using DAL;

namespace BLL
{
    public class TProductoBLL
    {
        private readonly TProductoDAL productoDAL = new TProductoDAL();

        public DataTable GetAllProductos()
        {
            try
            {
                return productoDAL.GetAllProductos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos: " + ex.Message);
            }
        }

        public bool InsertProducto(int idCompra, int idStatus, int idCategoria, string producto,
                                 decimal preciomxO, decimal preciomxF, decimal preciousO,
                                 decimal preciousF, int cantidad, string localizadorTransportista,
                                 string localizadorPlataforma, DateTime? fechaEEI,
                                 DateTime? fechaEEF, DateTime? fechaEC, byte[] imagenP)
        {
            // Validaciones de negocio ampliadas
            if (string.IsNullOrEmpty(producto))
                throw new ArgumentException("El nombre del producto no puede estar vacío");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero");

            if (idCategoria <= 0)
                throw new ArgumentException("Debe seleccionar una categoría válida");

            try
            {
                return productoDAL.InsertProducto(
                    idCompra, idStatus, idCategoria, producto, preciomxO, preciomxF, preciousO,
                    preciousF, cantidad, localizadorTransportista, localizadorPlataforma,
                    fechaEEI, fechaEEF, fechaEC, imagenP);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el producto: " + ex.Message);
            }
        }

        public bool UpdateProducto(int idProducto, int idCompra, int idStatus, int idCategoria, string producto,
                                 decimal preciomxO, decimal preciomxF, decimal preciousO,
                                 decimal preciousF, int cantidad, string localizadorTransportista,
                                 string localizadorPlataforma, DateTime? fechaEEI,
                                 DateTime? fechaEEF, DateTime? fechaEC, byte[] imagenP)
        {
            if (string.IsNullOrEmpty(producto))
                throw new ArgumentException("El nombre del producto no puede estar vacío");

            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor que cero");

            if (idCategoria <= 0)
                throw new ArgumentException("Debe seleccionar una categoría válida");

            try
            {
                return productoDAL.UpdateProducto(
                    idProducto, idCompra, idStatus, idCategoria, producto, preciomxO, preciomxF, preciousO,
                    preciousF, cantidad, localizadorTransportista, localizadorPlataforma,
                    fechaEEI, fechaEEF, fechaEC, imagenP);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto: " + ex.Message);
            }
        }

        // Los métodos DeleteProducto, GetProductoById y GetProductosByCompra permanecen iguales
        // ...
    }
}