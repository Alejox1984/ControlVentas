using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class HistorialPagoCompra
    {
        public int idpago;

        public int idHistorialPagosCompra { get; set; }
        public int idCompra { get; set; }
        public int idPago { get; set; }
        public double importe { get; set; }
        public DateTime fecha { get; set; }

    }
}
