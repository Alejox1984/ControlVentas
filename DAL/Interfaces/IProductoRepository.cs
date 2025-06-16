using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;

namespace DAL.Interfaces
{
    public interface IProductoRepository
    {

        void AddProducto(Producto _producto);
        void EliminarProducto(int idProducto);
        void ModificarProducto(int idProducto, Producto camposActualizar);
        void ActualizarProductoTransportista(int idProducto, decimal precio, string localizadorTransportista, int idStatus);
        List<ProductoCategoria> ListaProductosConCategoria(int id_compra);
        byte[] GetOnlyImage(int productoId);
        List<ProductoDTO> ObtenerProductosCombinados();

    }
}
