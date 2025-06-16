using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class Producto
    {
        public int idProducto { get; set; }
        public int? idCompra { get; set; }
        public int? idStatus { get; set; }
        public int? idCategoria { get; set; }
        public string producto { get; set; }
        public decimal? preciomxO { get; set; }
        public decimal? preciomxF { get; set; }
        public decimal? preciousO { get; set; }
        public decimal? preciousF { get; set; }
        public int? cantidad { get; set; }
        public string localizadorTransportista { get; set; }
        public string localizadorPlataforma { get; set; }
        public DateTime? fechaEEI { get; set; }
        public DateTime? fechaEEF { get; set; }
        public DateTime? fechaEC { get; set; }
        public byte [] imagenP { get; set; }
    }
}