using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;
using DAL.Interfaces;
using DAL.Repositorios;

namespace BLL.Servicios
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _categoria;

        public CategoriaService(ICategoriaRepository categoriaRepository) 
        {
            _categoria = categoriaRepository;
        }

        public string ObtenerCategoria(int idCategoria)
        {
            if (idCategoria <= 0)
                throw new ArgumentException("ID de categoría no válido");

            var categoria = _categoria.ObtenerCategoriaProductoPorId(idCategoria);
            if (string.IsNullOrEmpty(categoria))
                throw new Exception("Categoría no encontrada");

            return categoria;
        }
        public int ObtenerIDCategoria(string Categoria) 
        {
            if (string.IsNullOrEmpty(Categoria))
                throw new ArgumentException("La categoria del producto no puede ser vacío.");

            int idcategoria = _categoria.ObtenerIdPorCategoriaProducto(Categoria);
            if (idcategoria <= 0)
                throw new Exception("Categoria no encontrada.");

            return idcategoria;
        }
        public int ContarCategorias() 
        {
            int contador = _categoria.ContarCategorias();
            return contador;
        }
    }
}
