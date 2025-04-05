using System;
using System.Data;

namespace BLL
{
    public class DetalleOperacionBLL
    {
        public static DataTable ListarDetalleOperaciones()
        {
            return DAL.DetalleOperacionDAL.ListarDetalleOperaciones();
        }

        public static int InsertarDetalleOperacion(int idTipoOperacion, string operacion)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(operacion))
                throw new ArgumentException("El nombre de la operación no puede estar vacío");

            if (operacion.Trim().Length > 30)
                throw new ArgumentException("El nombre de la operación no puede exceder los 30 caracteres");

            return DAL.DetalleOperacionDAL.InsertarDetalleOperacion(idTipoOperacion, operacion);
        }

        public static int ActualizarDetalleOperacion(int idDetalleOperacion, int idTipoOperacion, string operacion)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(operacion))
                throw new ArgumentException("El nombre de la operación no puede estar vacío");

            if (operacion.Trim().Length > 30)
                throw new ArgumentException("El nombre de la operación no puede exceder los 30 caracteres");

            return DAL.DetalleOperacionDAL.ActualizarDetalleOperacion(idDetalleOperacion, idTipoOperacion, operacion);
        }

        public static int EliminarDetalleOperacion(int idDetalleOperacion)
        {
            return DAL.DetalleOperacionDAL.EliminarDetalleOperacion(idDetalleOperacion);
        }

        public static DataRow ObtenerDetalleOperacionPorId(int idDetalleOperacion)
        {
            return DAL.DetalleOperacionDAL.ObtenerDetalleOperacionPorId(idDetalleOperacion);
        }
    }
}