using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
        public class Cliente  // ¡Public aquí!
        {
            public int IdCliente { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
    }
    

}
