using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Servicios
{
    // BLL/Services/PlataformaService.cs

    public class PlataformaService
    {
        private readonly IPlataformaRepository _plataformaRepository;

        // Contructor con referencia a la interface
        public PlataformaService(IPlataformaRepository plataformaRepository) 
        {
            _plataformaRepository = plataformaRepository;
        }
        // Obtener plataforma pasando id por parametro
        public string ObtenerPlataforma(int id_plataforma)
        {
            if (id_plataforma <= 0)
                throw new ArgumentException("ID de plataforma no válido");

            var plataforma = _plataformaRepository.ObtenerPlataformaPorId(id_plataforma);
            if (string.IsNullOrEmpty(plataforma))
                throw new Exception("Plataforma no encontrada");

            return plataforma;
        }
        // Obtener id pasando plataforma por parametro
        public int ObtenerIdPlataforma(string plataforma)
        {
            if (string.IsNullOrEmpty(plataforma))
                throw new ArgumentException("El nombre de la plataforma no puede ser vacío.");

            int idPlataforma = _plataformaRepository.ObtenerIdPorNombrePlataforma(plataforma);
            if (idPlataforma <= 0)
                throw new Exception("Plataforma no encontrada.");

            return idPlataforma;
        }

    }
}


