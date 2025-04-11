using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public class Compra
    {
        public int idCompra { get; set; }
        public int idClient { get; set; }
        public int idGasto { get; set; }
        public int idIngreso { get; set; }
        public int idPlataforma { get; set; }
        public int idStatus { get; set; }
        public DateTime fecha { get; set; }
        public string codigo { get; set; } 
        
    }
}
