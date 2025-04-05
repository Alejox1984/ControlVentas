using System;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// Capa BLL para la gestión de estados de producto
    /// Contiene la lógica de negocio para los estados de producto
    /// </summary>
    public class StatusProductoBLL
    {
        /// <summary>
        /// Obtiene todos los estados de producto disponibles
        /// </summary>
        /// <returns>DataTable con la lista de estados</returns>
        public static DataTable ListarTodos()
        {
            return StatusProductoDAL.ListarStatusProducto();
        }

        /// <summary>
        /// Registra un nuevo estado de producto
        /// </summary>
        /// <param name="status">Nombre del estado</param>
        /// <returns>ID del nuevo estado creado</returns>
        /// <exception cref="ArgumentException">Error en datos de entrada</exception>
        public static int CrearStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("El nombre del estado no puede estar vacío");

            if (status.Trim().Length > 20)
                throw new ArgumentException("El nombre no puede exceder los 20 caracteres");

            return StatusProductoDAL.InsertarStatusProducto(status);
        }

        /// <summary>
        /// Actualiza un estado de producto existente
        /// </summary>
        /// <param name="idStatus">ID del estado a actualizar</param>
        /// <param name="nuevoStatus">Nuevo nombre para el estado</param>
        /// <returns>True si se actualizó correctamente</returns>
        /// <exception cref="ArgumentException">Error en datos de entrada</exception>
        public static bool EditarStatus(int idStatus, string nuevoStatus)
        {
            if (idStatus <= 0)
                throw new ArgumentException("ID de estado no válido");

            if (string.IsNullOrWhiteSpace(nuevoStatus))
                throw new ArgumentException("El nombre del estado no puede estar vacío");

            if (nuevoStatus.Trim().Length > 20)
                throw new ArgumentException("El nombre no puede exceder los 20 caracteres");

            return StatusProductoDAL.ActualizarStatusProducto(idStatus, nuevoStatus);
        }

        /// <summary>
        /// Obtiene el nombre de un estado por su ID
        /// </summary>
        /// <param name="idStatus">ID del estado</param>
        /// <returns>Nombre del estado</returns>
        /// <exception cref="ArgumentException">ID de estado no válido</exception>
        public static string ObtenerNombreStatus(int idStatus)
        {
            if (idStatus <= 0)
                throw new ArgumentException("ID de estado no válido");

            DataRow status = StatusProductoDAL.ObtenerStatusProductoPorId(idStatus);

            if (status == null)
                throw new InvalidOperationException("Estado no encontrado");

            return status["statusProducto"].ToString();
        }
    }
}