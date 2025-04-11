using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BLL.Servicios;
using DAL.Repositories;
using DAL.Repositorios.Control_de_Ventas_Online.DAL.Repositorios;

namespace Control_de_Ventas_Online
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Inicialización de estilo de la aplicación
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Obtener cadena de conexión desde configuración
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Crear conexión a la base de datos
            using (var dbConnection = new SqlConnection(connectionString))
            {
                // Instanciar repositorios
                var compraRepo = new CompraRepository(dbConnection);
                var clienteRepo = new ClienteRepository(dbConnection);

                // Instanciar servicios
                var compraService = new CompraService(compraRepo);
                var clienteService = new ClienteService(clienteRepo);

                // Ejecutar la aplicación con inyección de servicios
                Application.Run(new Main(compraService, clienteService));
            }
        }
    }
}

