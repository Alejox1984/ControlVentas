using System;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// Capa BLL para la gestión de categorías
    /// Contiene la lógica de negocio para las categorías
    /// </summary>
    public class CategoriaBLL
    {
        /// <summary>
        /// Obtiene todas las categorías disponibles
        /// </summary>
        /// <returns>DataTable con la lista de categorías</returns>
        public static DataTable ListarTodas()
        {
            return CategoriaDAL.ListarCategorias();
        }

        /// <summary>
        /// Registra una nueva categoría
        /// </summary>
        /// <param name="nombreCategoria">Nombre de la categoría</param>
        /// <returns>ID de la nueva categoría creada</returns>
        /// <exception cref="ArgumentException">Error en datos de entrada</exception>
        public static int CrearCategoria(string nombreCategoria)
        {
            if (string.IsNullOrWhiteSpace(nombreCategoria))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío");

            if (nombreCategoria.Trim().Length > 20)
                throw new ArgumentException("El nombre no puede exceder los 20 caracteres");

            return CategoriaDAL.InsertarCategoria(nombreCategoria);
        }

        /// <summary>
        /// Obtiene el nombre de una categoría por su ID
        /// </summary>
        /// <param name="idCategoria">ID de la categoría</param>
        /// <returns>Nombre de la categoría</returns>
        /// <exception cref="ArgumentException">ID no válido</exception>
        public static string ObtenerNombreCategoria(int idCategoria)
        {
            if (idCategoria <= 0)
                throw new ArgumentException("ID de categoría no válido");

            DataRow categoria = CategoriaDAL.ObtenerCategoriaPorId(idCategoria);

            if (categoria == null)
                throw new InvalidOperationException("Categoría no encontrada");

            return categoria["categoria"].ToString();
        }
    }
}