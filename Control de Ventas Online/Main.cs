using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_Ventas_Online
{
    public partial class Main: Form
    {
        public Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.Sizable;

        }

        public void CargarSubformulario(Form subFormulario)
        {
            // Limpia el panel antes de cargar un nuevo formulario
            panel_contenedo_formularios.Controls.Clear();

            // Configura el subformulario
            subFormulario.TopLevel = false; // Evita que se cree como ventana independiente
            subFormulario.FormBorderStyle = FormBorderStyle.None; // Elimina bordes del formulario
            subFormulario.Dock = DockStyle.Fill; // Asegura que ocupe todo el espacio del panel

            // Añade el subformulario al panel
            panel_contenedo_formularios.Controls.Add(subFormulario);
            panel_contenedo_formularios.Tag = subFormulario;

            // Muestra el subformulario
            subFormulario.Show();
        }


        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FGestionCliente gestionClienteForm = new FGestionCliente();
            CargarSubformulario(gestionClienteForm);
        }
    }
}
