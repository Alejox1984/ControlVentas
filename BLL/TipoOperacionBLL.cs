using System;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// Capa BLL para la gestión de tipos de operación
    /// Contiene la lógica de negocio para los tipos de operación
    /// </summary>
    public class TipoOperacionBLL
    {
        /// <summary>
        /// Obtiene todos los tipos de operación disponibles
        /// </summary>
        /// <returns>DataTable con la lista de tipos</returns>
        public static DataTable ListarTodos()
        {
            return TipoOperacionDAL.ListarTiposOperacion();
        }

        /// <summary>
        /// Obtiene el nombre de un tipo de operación por su ID
        /// </summary>
        /// <param name="idTipoOperacion">ID del tipo de operación</param>
        /// <returns>Nombre del tipo de operación</returns>
        /// <exception cref="ArgumentException">ID no válido</exception>
        public static string ObtenerNombreTipoOperacion(int idTipoOperacion)
        {
            if (idTipoOperacion <= 0)
                throw new ArgumentException("ID de tipo de operación no válido");

            DataRow tipo = TipoOperacionDAL.ObtenerTipoOperacionPorId(idTipoOperacion);

            if (tipo == null)
                throw new InvalidOperationException("Tipo de operación no encontrado");

            return tipo["operacion"].ToString();
        }
    }
}
