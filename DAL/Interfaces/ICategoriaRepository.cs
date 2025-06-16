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
    public interface ICategoriaRepository
    {

        string ObtenerCategoriaProductoPorId(int idCategoria);
        int ObtenerIdPorCategoriaProducto(string Categoria);
        int ContarCategorias();

    }
}
