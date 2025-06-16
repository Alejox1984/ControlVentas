using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;

namespace DAL.Interfaces
{
    public interface IOpContableRepository
    {
        /// <summary>
        /// Inserta una nueva operación contable y devuelve el ID generado.
        /// </summary>
        int AddOperacionContable(OperacionContable _operacionContable);
    }
}
