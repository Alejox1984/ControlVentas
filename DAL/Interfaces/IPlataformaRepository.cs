using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{

    /// <summary>
    /// Obtiene plataforma por su id
    /// Obtiene el id pasandole el nombre de la plataforma
    /// </summary>
    public interface IPlataformaRepository
    {

        string ObtenerPlataformaPorId(int idPlataforma);
        int ObtenerIdPorNombrePlataforma(string plataforma);
    }
}
