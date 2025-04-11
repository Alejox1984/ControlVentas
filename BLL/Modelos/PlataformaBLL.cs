using System;
using System.Data;
using DAL;

namespace BLL
{
    /// <summary>
    /// Capa BLL para la gestión de plataformas
    /// Contiene la lógica de negocio para las plataformas
    /// </summary>
    public class PlataformaBLL
    {
        /// <summary>
        /// Obtiene todas las plataformas disponibles
        /// </summary>
        /// <returns>DataTable con la lista de plataformas</returns>
        public  DataTable ListarTodas()
        {
            return PlataformaDAL.ListarPlataformas();
        }

        /// <summary>
        /// Registra una nueva plataforma
        /// </summary>
        /// <param name="nombrePlataforma">Nombre de la plataforma</param>
        /// <returns>ID de la nueva plataforma creada</returns>
        /// <exception cref="ArgumentException">Error en datos de entrada</exception>
        public static int CrearPlataforma(string nombrePlataforma)
        {
            if (string.IsNullOrWhiteSpace(nombrePlataforma))
                throw new ArgumentException("El nombre de la plataforma no puede estar vacío");

            if (nombrePlataforma.Trim().Length > 30)
                throw new ArgumentException("El nombre no puede exceder los 30 caracteres");

            if (PlataformaDAL.ExistePlataforma(nombrePlataforma))
                throw new InvalidOperationException("Ya existe una plataforma con ese nombre");

            return PlataformaDAL.InsertarPlataforma(nombrePlataforma);
        }

        /// <summary>
        /// Actualiza una plataforma existente
        /// </summary>
        /// <param name="idPlataforma">ID de la plataforma a actualizar</param>
        /// <param name="nuevoNombre">Nuevo nombre para la plataforma</param>
        /// <returns>True si se actualizó correctamente</returns>
        /// <exception cref="ArgumentException">Error en datos de entrada</exception>
        public static bool EditarPlataforma(int idPlataforma, string nuevoNombre)
        {
            if (idPlataforma <= 0)
                throw new ArgumentException("ID de plataforma no válido");

            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new ArgumentException("El nombre de la plataforma no puede estar vacío");

            if (nuevoNombre.Trim().Length > 30)
                throw new ArgumentException("El nombre no puede exceder los 30 caracteres");

            if (PlataformaDAL.ExistePlataforma(nuevoNombre, idPlataforma))
                throw new InvalidOperationException("Ya existe otra plataforma con ese nombre");

            return PlataformaDAL.ActualizarPlataforma(idPlataforma, nuevoNombre);
        }

        /// <summary>
        /// Elimina una plataforma
        /// </summary>
        /// <param name="idPlataforma">ID de la plataforma a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        /// <exception cref="ArgumentException">ID de plataforma no válido</exception>
        public static bool RemoverPlataforma(int idPlataforma)
        {
            if (idPlataforma <= 0)
                throw new ArgumentException("ID de plataforma no válido");

            // Aquí podrías agregar validaciones adicionales como:
            // - Verificar que no tenga productos asociados
            // - Validar otras dependencias

            return PlataformaDAL.EliminarPlataforma(idPlataforma);
        }

        /// <summary>
        /// Obtiene los datos de una plataforma específica
        /// </summary>
        /// <param name="idPlataforma">ID de la plataforma a consultar</param>
        /// <returns>DataRow con los datos de la plataforma</returns>
        /// <exception cref="ArgumentException">ID de plataforma no válido</exception>
        public static DataRow ObtenerPlataforma(int idPlataforma)
        {
            if (idPlataforma <= 0)
                throw new ArgumentException("ID de plataforma no válido");

            DataRow plataforma = PlataformaDAL.ObtenerPlataformaPorId(idPlataforma);

            if (plataforma == null)
                throw new InvalidOperationException("Plataforma no encontrada");

            return plataforma;
        }

        /// <summary>
        /// Obtiene el nombre de una plataforma por su ID
        /// </summary>
        /// <param name="idPlataforma">ID de la plataforma</param>
        /// <returns>Nombre de la plataforma</returns>
        public static string ObtenerNombrePlataforma(int idPlataforma)
        {
            DataRow plataforma = ObtenerPlataforma(idPlataforma);
            return plataforma["plataforma"].ToString();
        }
    }
}