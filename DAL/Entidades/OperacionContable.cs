using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class OperacionContable
    {
        public int idOperacionContable { get; set; }
        public int idDetalleOperacion { get; set; }
        public DateTime fecha { get; set; }
        public double importe { get; set; }
    }
}
