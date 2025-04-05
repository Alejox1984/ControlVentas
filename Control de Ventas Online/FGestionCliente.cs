using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Control_de_Ventas_Online
{
    public partial class FGestionCliente : Form
    {
        private ClienteBLL clienteBLL = new ClienteBLL();
        private ClienteDAL clienteDAL = new ClienteDAL();
        private bool sortAscending = true;
        public FGestionCliente()
        {
            InitializeComponent(); // Inicializar componentes

            // Cargar datos en el ListView
            CargarClientesEnListView();
            
        }

        private void CargarClientesEnListView()
        {
            try
            {
                // Obtener los datos de la base de datos a través de la capa BLL
                DataTable dt = clienteBLL.ObtenerClientes();

                // Limpiar completamente las columnas y los elementos del ListView
                listViewClientes.Columns.Clear();
                listViewClientes.Items.Clear();

                // Configurar el ListView con la vista de detalle y cuadrículas
                listViewClientes.View = View.Details;
                listViewClientes.GridLines = true; // Activar cuadrículas
                listViewClientes.FullRowSelect = true; // Permitir seleccionar la fila completa

                // Configurar el color de fondo y el color del texto
                listViewClientes.BackColor = Color.FromArgb(255, 255, 200); // Amarillo claro
                listViewClientes.ForeColor = Color.DarkBlue; // Azul oscuro

                
                // Configurar columnas (exactamente 3: Nombre, Dirección y Teléfono)
                listViewClientes.Columns.Add("Nombre", 300, HorizontalAlignment.Center);
                listViewClientes.Columns.Add("Dirección", 300, HorizontalAlignment.Center);
                listViewClientes.Columns.Add("Teléfono", 290, HorizontalAlignment.Center);

                // Verificar si no hay datos para mostrar
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay clientes para mostrar.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Cargar los datos de la tabla al ListView
                foreach (DataRow row in dt.Rows)
                {
                    // Crear un ListViewItem para cada fila del DataTable
                    var item = new ListViewItem
                    {
                        Text = row["Nombre"].ToString() // Primera columna (Nombre)
                    };

                    // Agregar las otras columnas como SubItems
                    item.SubItems.Add(row["Direccion"].ToString()); // Segunda columna (Dirección)
                    item.SubItems.Add(row["Telefono"].ToString()); // Tercera columna (Teléfono)

                    // Almacenar el ID del cliente en la propiedad Tag
                    item.Tag = row["id_cliente"];

                    // Agregar el elemento al ListView
                    listViewClientes.Items.Add(item);
                }

                // Ajustar automáticamente las columnas al tamaño del encabezado
                //listViewClientes.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                int columnWidth = listViewClientes.Width / 3;
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de problemas
                MessageBox.Show("Error al cargar los clientes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia los campos de texto utilizados para capturar la información del cliente.
        /// </summary>
        private void LimpiarCampos()
        {
            txtNombreC.Text = "";
            txtDireccionC.Text = "";
            txtTelefonoC.Text = "";
        }

        /// <summary>
        /// Evento para adicionar un nuevo cliente en la base de datos.
        /// </summary>
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén llenos
                if (string.IsNullOrEmpty(txtNombreC.Text) || string.IsNullOrEmpty(txtDireccionC.Text) || string.IsNullOrEmpty(txtTelefonoC.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar al método para insertar un nuevo cliente
                clienteBLL.InsertarCliente(txtNombreC.Text, txtDireccionC.Text, txtTelefonoC.Text);
                MessageBox.Show("Cliente agregado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar los datos en el ListView y limpiar los campos
                CargarClientesEnListView();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de problemas
                MessageBox.Show("Error al agregar el cliente: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
// Evento del botón "Actualizar"
private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewClientes.SelectedItems.Count > 0)
                {
                    // Obtener el ID desde el Tag del ListViewItem
                    ListViewItem selectedItem = listViewClientes.SelectedItems[0];
                    int id = Convert.ToInt32(selectedItem.Tag);

                    // Validar campos
                    if (string.IsNullOrEmpty(txtNombreC.Text) || string.IsNullOrEmpty(txtDireccionC.Text) || string.IsNullOrEmpty(txtTelefonoC.Text))
                    {
                        MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Llama al método de la BLL para actualizar
                    clienteBLL.ActualizarCliente(id, txtNombreC.Text, txtDireccionC.Text, txtTelefonoC.Text);
                    MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar datos y limpiar campos
                    CargarClientesEnListView();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón "Eliminar"
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewClientes.SelectedItems.Count > 0)
                {
                    // Obtener el ID desde el Tag del ListViewItem
                    ListViewItem selectedItem = listViewClientes.SelectedItems[0];
                    int id = Convert.ToInt32(selectedItem.Tag);

                    // Confirmar la eliminación
                    DialogResult result = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Llama al método de la BLL para eliminar
                        clienteBLL.EliminarCliente(id);
                        MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar datos
                        CargarClientesEnListView();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento del botón "Imprimir"
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = clienteDAL.ObtenerClientesDesdeVista(); // Obtener los datos

                // Crear una instancia del formulario de reporte y pasarle los datos
                FReporteClientes reporteForm = new FReporteClientes(dt);
                reporteForm.ShowDialog(); // Mostrar el formulario como un cuadro de diálogo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void listViewClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay un elemento seleccionado
            if (listViewClientes.SelectedItems.Count > 0)
            {
                // Obtener el elemento seleccionado
                ListViewItem selectedItem = listViewClientes.SelectedItems[0];

                // Cargar los valores en los TextBox
                txtNombreC.Text = selectedItem.SubItems[0].Text; // Nombre
                txtDireccionC.Text = selectedItem.SubItems[1].Text; // Dirección
                txtTelefonoC.Text = selectedItem.SubItems[2].Text; // Teléfono
            }
        }

        private void listViewClientes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listViewClientes.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
            sortAscending = !sortAscending; // Alternar el orden
            listViewClientes.Sort();
        }
        private class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            private bool order;

            public ListViewItemComparer(int column, bool ascending)
            {
                col = column;
                order = ascending;
            }

            public int Compare(object x, object y)
            {
                int result = String.Compare(
                    ((ListViewItem)x).SubItems[col].Text,
                    ((ListViewItem)y).SubItems[col].Text
                );
                return order ? result : -result; // Alternar entre ascendente/descendente
            }
        }

        
    }
}