using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BLL.Servicios;
using Control_de_Ventas_Online.Forms;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Repositorios;
using DAL.Repositorios.Control_de_Ventas_Online.DAL.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Control_de_Ventas_Online
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configurar el servicio de inyección de dependencias
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // Obtener y ejecutar el formulario principal
            var mainForm = ServiceProvider.GetRequiredService<Main>();

            if (mainForm == null)
            {
                throw new InvalidOperationException("El formulario principal no pudo ser obtenido de la inyección de dependencias.");
            }

            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // 1. Configurar conexión a la BD
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("ERROR: No se encontró la cadena de conexión en App.config", "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            services.AddScoped<IDbConnection>(_ => new SqlConnection(connectionString));

            // 2. Registrar repositorios
            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPlataformaRepository, PlataformaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaProductoRepository>();
            services.AddScoped<IOpContableRepository,OperacionContableRepository >();
            services.AddScoped<IOpContableCompraRepository, OpContableCompraRepository>();
            services.AddScoped<IHistorialPagoCompra, HistorialPagosCompraRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<ITasaRepository, TasaRepository>();
            services.AddScoped<IOpContableCompraRepository, OpContableCompraRepository>();
            services.AddScoped<IOpContableRepository, OperacionContableRepository>();
     
            // 3. Registrar servicios de negocio
            services.AddScoped<CompraService>();
            services.AddScoped<ClienteService>();
            services.AddScoped<PlataformaService>();
            services.AddScoped<CategoriaService>();
            services.AddScoped<ProductoService>();
            services.AddScoped<TasasService>();
            services.AddScoped<OpContableCompraService>();
            services.AddScoped<OpContableService>();
            // 4. Registrar formularios
            services.AddScoped<Main>();
            services.AddScoped<FNuevaCompra>();
            services.AddScoped<FGestionCliente>();
            services.AddScoped<FOperaciones>();
           
        }
    }
}