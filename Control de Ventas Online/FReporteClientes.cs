using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DAL;

namespace Control_de_Ventas_Online
{
    public partial class FReporteClientes : Form
    {
        private DataTable clientesData;

        // Constructor que acepta un DataTable
        public FReporteClientes(DataTable data)
        {
            InitializeComponent();
            this.clientesData = data; // Asignar el DataTable recibido
        }

        private void FReporteClientes_Load(object sender, EventArgs e)
        {
            try
            {
                // Reiniciar el ReportViewer para evitar configuraciones previas
                reportViewer1.Reset();

                // Configurar el ReportViewer en modo local
                reportViewer1.ProcessingMode = ProcessingMode.Local;

                // Verificar si hay datos en el DataTable
                if (clientesData == null || clientesData.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos para el reporte.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Configurar el DataSource del ReportViewer
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", clientesData);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Cargar el archivo RDLC
                reportViewer1.LocalReport.ReportEmbeddedResource = "Control_de_Ventas_Online.InformeCliente.rdlc";

                // Refrescar el reporte
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                // Mostrar detalles del error para depuración
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}\nStackTrace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
