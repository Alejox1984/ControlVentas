using System;
using DAL.Interfaces;
using DAL.Entidades;
using System.Collections.Generic;

namespace BLL.Servicios
{
    /// <summary>
    /// Servicio para la gestión de productos, que actúa como intermediario
    /// entre la capa de presentación y el repositorio de datos.
    /// </summary>
    public class ProductoService   // Recomendado implementar interfaz
    {
        private readonly IProductoRepository _productoRepository;

        /// <summary>
        /// Constructor para inyección de dependencias
        /// </summary>
        /// <param name="productoRepository">Instancia del repositorio de productos</param>
        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
        }

        /// <summary>
        /// Registra un nuevo producto en el sistema
        /// </summary>
        /// <param name="producto">Datos completos del producto a registrar</param>
        /// <exception cref="ArgumentNullException">Cuando el producto es nulo</exception>
        /// <exception cref="InvalidOperationException">Cuando ocurre un error en el repositorio</exception>
        public void InsertarProducto(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo");

            try
            {
                ValidarProductoAntesDeInsertar(producto);
                _productoRepository.AddProducto(producto);
            }
            catch (Exception ex)
            {
                // Loggear el error (usando ILogger, por ejemplo)
                throw new InvalidOperationException("Error al insertar el producto", ex);
            }
        }

        /// <summary>
        /// Actualiza los datos de un producto existente
        /// </summary>
        /// <param name="idProducto">Identificador del producto a actualizar</param>
        /// <param name="producto">Datos parciales/completos del producto</param>
        /// <exception cref="ArgumentException">Cuando el ID es inválido</exception>
        public void ActualizarProducto(int idProducto, Producto producto)
        {
            if (idProducto <= 0)
                throw new ArgumentException("ID de producto inválido", nameof(idProducto));

            if (producto == null)
                throw new ArgumentNullException(nameof(producto));

            try
            {
                _productoRepository.ModificarProducto(idProducto, producto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al actualizar el producto {idProducto}", ex);
            }
        }

        /// <summary>
        /// Elimina un producto del sistema
        /// </summary>
        /// <param name="idProducto">Identificador del producto a eliminar</param>
        /// <exception cref="ArgumentException">Cuando el ID es inválido</exception>
        public void EliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
                throw new ArgumentException("ID de producto inválido", nameof(idProducto));

            try
            {
                _productoRepository.EliminarProducto(idProducto);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al eliminar el producto {idProducto}", ex);
            }
        }

        /// <summary>
        /// Valida las reglas de negocio antes de insertar un producto
        /// </summary>
        private void ValidarProductoAntesDeInsertar(Producto producto)
        {
            // Ejemplo de validaciones de negocio:
            if (producto.preciomxO <= 0)
                throw new InvalidOperationException("El precio debe ser mayor que cero");

            if (string.IsNullOrWhiteSpace(producto.producto))
                throw new InvalidOperationException("El nombre del producto es requerido");
            
            if (producto.idCategoria <= 0)
                throw new InvalidOperationException("La categoria del producto es requerida");

        }
        public List<ProductoCategoria> ListaProductosCC(int id_compra) 
        {
            return _productoRepository.ListaProductosConCategoria(id_compra);
        }
        public byte[] ObtenerImagen(int id)
        {
            return _productoRepository.GetOnlyImage(id);
        }
        /// <summary>
        /// Obtiene una lista de productos con información extendida, 
        /// incluyendo datos de compra, cliente y estado.
        /// </summary>
        /// <returns>Lista de productos con información combinada</returns>
        public List<ProductoDTO> ObtenerProductosConDetalle()
        {
            try
            {
                return _productoRepository.ObtenerProductosCombinados();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al obtener productos con detalles", ex);
            }
        }
        /// <summary>
        /// Actualiza el transportista, precio y estado de un producto específico.
        /// Cambia el estado del producto a "En traslado" (idStatus = 2).
        /// </summary>
        /// <param name="idProducto">Identificador único del producto a actualizar</param>
        /// <param name="precio">Nuevo precio del producto en moneda local</param>
        /// <param name="localizadorTransportista">Código identificador del transportista asignado</param>
        /// <exception cref="ArgumentException">Se lanza cuando los parámetros no son válidos</exception>
        /// <exception cref="InvalidOperationException">Se lanza cuando ocurre un error durante la actualización</exception>
        public void ActualizarProductoTransportista(int idProducto, decimal precio, string localizadorTransportista)
        {
            // Validaciones
            if (idProducto <= 0)
                throw new ArgumentException("ID de producto inválido", nameof(idProducto));

            if (precio < 0)
                throw new ArgumentException("El precio no puede ser negativo", nameof(precio));

            if (string.IsNullOrWhiteSpace(localizadorTransportista))
                throw new ArgumentException("El localizador del transportista no puede estar vacío", nameof(localizadorTransportista));

            try
            {
                // Llamar al repositorio con estado 2 (En traslado)
                _productoRepository.ActualizarProductoTransportista(idProducto, precio, localizadorTransportista, 2);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al actualizar transportista del producto {idProducto}", ex);
            }
        }
        /// <summary>
        /// Actualiza el estado de un producto a "Recibido" (status 4)
        /// Mantiene el transportista y precio existentes o permite modificarlos
        /// </summary>
        /// <param name="idProducto">ID del producto a actualizar</param>
        /// <param name="precio">Nuevo precio del producto</param>
        /// <param name="localizadorTransportista">Código del transportista (debe estar asignado previamente)</param>
        public void ActualizarProductoRecibido(int idProducto, decimal precio, string localizadorTransportista)
        {
            // Validaciones
            if (idProducto <= 0)
                throw new ArgumentException("ID de producto inválido", nameof(idProducto));
            if (precio < 0)
                throw new ArgumentException("El precio no puede ser negativo", nameof(precio));
            if (string.IsNullOrWhiteSpace(localizadorTransportista))
                throw new ArgumentException("El localizador del transportista no puede estar vacío", nameof(localizadorTransportista));

            try
            {
                // Llamar al repositorio con estado 4 (Recibido)
                _productoRepository.ActualizarProductoTransportista(idProducto, precio, localizadorTransportista, 4);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al actualizar producto recibido {idProducto}", ex);
            }
        }
    }
}