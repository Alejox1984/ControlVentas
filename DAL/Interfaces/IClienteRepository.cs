using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;
namespace DAL.Interfaces

{
 
        public interface IClienteRepository
        {
            /// <summary>
            /// Obtiene un cliente por su ID
            /// </summary>
           
            string ObtenerNombrePorId(int idCliente);
            int ObtenerIdPorNombre(string nombreCliente);
        }

    

}

