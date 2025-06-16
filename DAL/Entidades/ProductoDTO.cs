using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{

    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public string ClienteNombre { get; set; }
        public string Categoria { get; set; }  // Añadido para coincidir con la columna del ListView
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; }
        public string CodigoCompra { get; set; }
        public string CodigoTransportista { get; set; }  // Renombrado de LocalizadorTransportista
        public string CodigoArticulo { get; set; }       // Renombrado de LocalizadorPlataforma
        public string Status { get; set; }
        public byte[] ImagenP { get; set; }
    }

}
