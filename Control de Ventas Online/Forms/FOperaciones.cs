using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Servicios;
using DAL.Entidades;


namespace Control_de_Ventas_Online.Forms
{
    public class FOperaciones : Form
    {

        private Panel panel1;
        private Label label1;
        private ComboBox ComboBoxProductos;
        private Label label2;
        private ComboBox ComboBoxCodigoCompra;
        private Label label3;
        private Label label4;
        private DateTimePicker dtFechaCompra;
        private ComboBox ComboBoxCliente;
        private Label label5;
        private TableLayoutPanel TLPFiltros2;
        private ComboBox ComboBoxCodigoArticulo;
        private Label label6;
        private ComboBox comboBox5;
        private Label label7;
        private Button btnLimpiarFiltros;
        private Label label8;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label10;
        private Label label9;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TextBox txtTransportista;
        private TextBox txtPrecioM;
        private Label label11;
        private DateTimePicker dateTimePicker1;
        private Label label12;
        private DateTimePicker dateTimePicker2;
        private Label label15;
        private Label label14;
        private Label label13;
        private Button btnAsignarTransportista;
        private TextBox txtValorEtiquetados;
        private TextBox txtCantidadEtiquetados;
        private TextBox txtValorTraslado;
        private TextBox txtCantidadTraslado;
        private TextBox txtValorSolicitados;
        private TextBox txtCantidadSolicitados;
        private Panel panel6;
        private Panel panel7;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBoxProducto;
        private Button button1;
        private Button button3;
        private Button btnRecibir;
        private Panel panel8;
        private ListView ListViewArticulos;
        private TableLayoutPanel TLFiltros;
        private readonly ProductoService _productoService;
        private List<ProductoDTO> _todosLosProductos;
        private bool _cambiandoSeleccion = false;
        private bool _aplicandoFiltro = false;
        private bool _ignoreTextChanged = false;
        private string _lastSelectedText = "";
        private bool _procesandoSeleccionProducto = false;
        private int cantidadArtSolicitados = 0;
        private decimal valorArtSolicitados = 0;
        private int cantidadArtEnTraslado = 0;
        private decimal valorArtEnTraslado = 0;
        private int cantidadArtEtiquetados = 0;
        private decimal valorArtEtiquetados = 0;
        private Dictionary<int, byte[]> _imagenCache = new Dictionary<int, byte[]>();
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        // 2. Constantes para el mensaje de scroll
        private const int WM_VSCROLL = 0x0115;   // Código para scroll vertical
        private const int SB_BOTTOM = 7;




        private void InitializeComponent()
        {
            this.TLFiltros = new System.Windows.Forms.TableLayoutPanel();
            this.ComboBoxCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboBoxCodigoCompra = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxProductos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TLPFiltros2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ComboBoxCodigoArticulo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPrecioM = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTransportista = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAsignarTransportista = new System.Windows.Forms.Button();
            this.txtValorEtiquetados = new System.Windows.Forms.TextBox();
            this.txtCantidadEtiquetados = new System.Windows.Forms.TextBox();
            this.txtValorTraslado = new System.Windows.Forms.TextBox();
            this.txtCantidadTraslado = new System.Windows.Forms.TextBox();
            this.txtValorSolicitados = new System.Windows.Forms.TextBox();
            this.txtCantidadSolicitados = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.btnRecibir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBoxProducto = new System.Windows.Forms.PictureBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ListViewArticulos = new System.Windows.Forms.ListView();
            this.TLFiltros.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TLPFiltros2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProducto)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLFiltros
            // 
            this.TLFiltros.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TLFiltros.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TLFiltros.ColumnCount = 8;
            this.TLFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.17102F));
            this.TLFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.79318F));
            this.TLFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.52125F));
            this.TLFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.73137F));
            this.TLFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.790579F));
            this.TLFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.960896F));
            this.TLFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.590559F));
            this.TLFiltros.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.44114F));
            this.TLFiltros.Controls.Add(this.ComboBoxCliente, 7, 1);
            this.TLFiltros.Controls.Add(this.label5, 6, 1);
            this.TLFiltros.Controls.Add(this.dtFechaCompra, 5, 1);
            this.TLFiltros.Controls.Add(this.label4, 4, 1);
            this.TLFiltros.Controls.Add(this.ComboBoxCodigoCompra, 3, 1);
            this.TLFiltros.Controls.Add(this.label3, 2, 1);
            this.TLFiltros.Controls.Add(this.panel1, 0, 0);
            this.TLFiltros.Controls.Add(this.ComboBoxProductos, 1, 1);
            this.TLFiltros.Controls.Add(this.label2, 0, 1);
            this.TLFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLFiltros.Location = new System.Drawing.Point(0, 0);
            this.TLFiltros.Margin = new System.Windows.Forms.Padding(5);
            this.TLFiltros.Name = "TLFiltros";
            this.TLFiltros.RowCount = 2;
            this.TLFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLFiltros.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLFiltros.Size = new System.Drawing.Size(1284, 81);
            this.TLFiltros.TabIndex = 0;
            // 
            // ComboBoxCliente
            // 
            this.ComboBoxCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ComboBoxCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ComboBoxCliente.FormattingEnabled = true;
            this.ComboBoxCliente.Location = new System.Drawing.Point(1137, 44);
            this.ComboBoxCliente.Name = "ComboBoxCliente";
            this.ComboBoxCliente.Size = new System.Drawing.Size(143, 33);
            this.ComboBoxCliente.TabIndex = 10;
            this.ComboBoxCliente.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxCliente_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(1065, 41);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3);
            this.label5.Size = new System.Drawing.Size(65, 39);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cliente";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtFechaCompra
            // 
            this.dtFechaCompra.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaCompra.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dtFechaCompra.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaCompra.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaCompra.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaCompra.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaCompra.Checked = false;
            this.dtFechaCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFechaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaCompra.Location = new System.Drawing.Point(950, 44);
            this.dtFechaCompra.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtFechaCompra.Name = "dtFechaCompra";
            this.dtFechaCompra.Size = new System.Drawing.Size(108, 30);
            this.dtFechaCompra.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(876, 41);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3);
            this.label4.Size = new System.Drawing.Size(67, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboBoxCodigoCompra
            // 
            this.ComboBoxCodigoCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ComboBoxCodigoCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxCodigoCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxCodigoCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ComboBoxCodigoCompra.FormattingEnabled = true;
            this.ComboBoxCodigoCompra.Location = new System.Drawing.Point(707, 44);
            this.ComboBoxCodigoCompra.Margin = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.ComboBoxCodigoCompra.Name = "ComboBoxCodigoCompra";
            this.ComboBoxCodigoCompra.Size = new System.Drawing.Size(165, 33);
            this.ComboBoxCodigoCompra.TabIndex = 6;
            this.ComboBoxCodigoCompra.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxCodigoCompra_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(540, 41);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3);
            this.label3.Size = new System.Drawing.Size(153, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "Código de Compra";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TLFiltros.SetColumnSpan(this.panel1, 8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1276, 33);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtros";
            // 
            // ComboBoxProductos
            // 
            this.ComboBoxProductos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ComboBoxProductos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboBoxProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ComboBoxProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ComboBoxProductos.FormattingEnabled = true;
            this.ComboBoxProductos.Location = new System.Drawing.Point(134, 44);
            this.ComboBoxProductos.Name = "ComboBoxProductos";
            this.ComboBoxProductos.Size = new System.Drawing.Size(399, 33);
            this.ComboBoxProductos.TabIndex = 1;
            this.ComboBoxProductos.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxProductos_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(123, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Artículo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TLPFiltros2
            // 
            this.TLPFiltros2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TLPFiltros2.ColumnCount = 7;
            this.TLPFiltros2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.TLPFiltros2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.TLPFiltros2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21F));
            this.TLPFiltros2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.78193F));
            this.TLPFiltros2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.127726F));
            this.TLPFiltros2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.TLPFiltros2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLPFiltros2.Controls.Add(this.btnLimpiarFiltros, 6, 0);
            this.TLPFiltros2.Controls.Add(this.comboBox5, 3, 0);
            this.TLPFiltros2.Controls.Add(this.label7, 2, 0);
            this.TLPFiltros2.Controls.Add(this.ComboBoxCodigoArticulo, 1, 0);
            this.TLPFiltros2.Controls.Add(this.label6, 0, 0);
            this.TLPFiltros2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLPFiltros2.Location = new System.Drawing.Point(0, 81);
            this.TLPFiltros2.Name = "TLPFiltros2";
            this.TLPFiltros2.RowCount = 1;
            this.TLPFiltros2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPFiltros2.Size = new System.Drawing.Size(1284, 40);
            this.TLPFiltros2.TabIndex = 1;
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.AutoSize = true;
            this.btnLimpiarFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(1153, 1);
            this.btnLimpiarFiltros.Margin = new System.Windows.Forms.Padding(1);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(130, 38);
            this.btnLimpiarFiltros.TabIndex = 10;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.comboBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(810, 3);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(248, 33);
            this.comboBox5.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(541, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(3);
            this.label7.Size = new System.Drawing.Size(263, 40);
            this.label7.TabIndex = 8;
            this.label7.Text = "Localizador de Transportista";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ComboBoxCodigoArticulo
            // 
            this.ComboBoxCodigoArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ComboBoxCodigoArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxCodigoArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxCodigoArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ComboBoxCodigoArticulo.FormattingEnabled = true;
            this.ComboBoxCodigoArticulo.Location = new System.Drawing.Point(272, 3);
            this.ComboBoxCodigoArticulo.Name = "ComboBoxCodigoArticulo";
            this.ComboBoxCodigoArticulo.Size = new System.Drawing.Size(263, 33);
            this.ComboBoxCodigoArticulo.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3);
            this.label6.Size = new System.Drawing.Size(263, 40);
            this.label6.TabIndex = 6;
            this.label6.Text = "Código de Artículo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(3);
            this.label8.Size = new System.Drawing.Size(790, 31);
            this.label8.TabIndex = 0;
            this.label8.Text = "Asignacion de Transportista, Cambio de Precio, Asignacion de fecha de Entrega";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1284, 42);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.24088F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.33757F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.42155F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 163);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 103);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(354, 91);
            this.panel3.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtPrecioM, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTransportista, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(352, 89);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtPrecioM
            // 
            this.txtPrecioM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPrecioM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrecioM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtPrecioM.Location = new System.Drawing.Point(179, 47);
            this.txtPrecioM.Name = "txtPrecioM";
            this.txtPrecioM.Size = new System.Drawing.Size(167, 30);
            this.txtPrecioM.TabIndex = 6;
            this.txtPrecioM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(6, 47);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(3);
            this.label10.Size = new System.Drawing.Size(167, 36);
            this.label10.TabIndex = 4;
            this.label10.Text = "Precio";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(6, 3);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(3);
            this.label9.Size = new System.Drawing.Size(167, 41);
            this.label9.TabIndex = 3;
            this.label9.Text = "Código de Transportista";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTransportista
            // 
            this.txtTransportista.AcceptsReturn = true;
            this.txtTransportista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTransportista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransportista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtTransportista.Location = new System.Drawing.Point(179, 6);
            this.txtTransportista.Name = "txtTransportista";
            this.txtTransportista.Size = new System.Drawing.Size(167, 30);
            this.txtTransportista.TabIndex = 5;
            this.txtTransportista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(366, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(279, 91);
            this.panel4.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker2, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label12, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(277, 89);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dateTimePicker2.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTimePicker2.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTimePicker2.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTimePicker2.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTimePicker2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(154, 47);
            this.dateTimePicker2.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(117, 30);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 47);
            this.dateTimePicker1.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(115, 30);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label11, 3);
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(6, 3);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(3);
            this.label11.Size = new System.Drawing.Size(265, 41);
            this.label11.TabIndex = 4;
            this.label11.Text = "Fecha estimada de entrega";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(127, 47);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(3);
            this.label12.Size = new System.Drawing.Size(21, 36);
            this.label12.TabIndex = 10;
            this.label12.Text = "Y";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.tableLayoutPanel4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(651, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(627, 91);
            this.panel5.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 8;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.5F));
            this.tableLayoutPanel4.Controls.Add(this.btnAsignarTransportista, 6, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtValorEtiquetados, 5, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtCantidadEtiquetados, 4, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtValorTraslado, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtCantidadTraslado, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtValorSolicitados, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtCantidadSolicitados, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label15, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(625, 89);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // btnAsignarTransportista
            // 
            this.btnAsignarTransportista.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.btnAsignarTransportista, 2);
            this.btnAsignarTransportista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAsignarTransportista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarTransportista.Location = new System.Drawing.Point(478, 45);
            this.btnAsignarTransportista.Margin = new System.Windows.Forms.Padding(1);
            this.btnAsignarTransportista.Name = "btnAsignarTransportista";
            this.btnAsignarTransportista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAsignarTransportista.Size = new System.Drawing.Size(143, 40);
            this.btnAsignarTransportista.TabIndex = 16;
            this.btnAsignarTransportista.Text = "Asignar";
            this.btnAsignarTransportista.UseVisualStyleBackColor = true;
            this.btnAsignarTransportista.Click += new System.EventHandler(this.btnAsignarTransportista_Click);
            // 
            // txtValorEtiquetados
            // 
            this.txtValorEtiquetados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtValorEtiquetados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValorEtiquetados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorEtiquetados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtValorEtiquetados.Location = new System.Drawing.Point(400, 47);
            this.txtValorEtiquetados.Name = "txtValorEtiquetados";
            this.txtValorEtiquetados.Size = new System.Drawing.Size(74, 30);
            this.txtValorEtiquetados.TabIndex = 15;
            this.txtValorEtiquetados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantidadEtiquetados
            // 
            this.txtCantidadEtiquetados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCantidadEtiquetados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCantidadEtiquetados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadEtiquetados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtCantidadEtiquetados.Location = new System.Drawing.Point(320, 47);
            this.txtCantidadEtiquetados.Name = "txtCantidadEtiquetados";
            this.txtCantidadEtiquetados.Size = new System.Drawing.Size(74, 30);
            this.txtCantidadEtiquetados.TabIndex = 14;
            this.txtCantidadEtiquetados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtValorTraslado
            // 
            this.txtValorTraslado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtValorTraslado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValorTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTraslado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtValorTraslado.Location = new System.Drawing.Point(240, 47);
            this.txtValorTraslado.Name = "txtValorTraslado";
            this.txtValorTraslado.Size = new System.Drawing.Size(74, 30);
            this.txtValorTraslado.TabIndex = 13;
            this.txtValorTraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantidadTraslado
            // 
            this.txtCantidadTraslado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCantidadTraslado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCantidadTraslado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadTraslado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtCantidadTraslado.Location = new System.Drawing.Point(160, 47);
            this.txtCantidadTraslado.Name = "txtCantidadTraslado";
            this.txtCantidadTraslado.Size = new System.Drawing.Size(74, 30);
            this.txtCantidadTraslado.TabIndex = 12;
            this.txtCantidadTraslado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtValorSolicitados
            // 
            this.txtValorSolicitados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtValorSolicitados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValorSolicitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorSolicitados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtValorSolicitados.Location = new System.Drawing.Point(83, 47);
            this.txtValorSolicitados.Name = "txtValorSolicitados";
            this.txtValorSolicitados.Size = new System.Drawing.Size(71, 30);
            this.txtValorSolicitados.TabIndex = 11;
            this.txtValorSolicitados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantidadSolicitados
            // 
            this.txtCantidadSolicitados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCantidadSolicitados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCantidadSolicitados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadSolicitados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtCantidadSolicitados.Location = new System.Drawing.Point(6, 47);
            this.txtCantidadSolicitados.Name = "txtCantidadSolicitados";
            this.txtCantidadSolicitados.Size = new System.Drawing.Size(71, 30);
            this.txtCantidadSolicitados.TabIndex = 10;
            this.txtCantidadSolicitados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.label15, 2);
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(320, 6);
            this.label15.Margin = new System.Windows.Forms.Padding(3);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(3);
            this.label15.Size = new System.Drawing.Size(154, 35);
            this.label15.TabIndex = 7;
            this.label15.Text = "Articulos Etiquetados";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.label14, 2);
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(160, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(3);
            this.label14.Size = new System.Drawing.Size(154, 35);
            this.label14.TabIndex = 6;
            this.label14.Text = "Articulos en Traslado";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel4.SetColumnSpan(this.label13, 2);
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(6, 6);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(3);
            this.label13.Size = new System.Drawing.Size(148, 35);
            this.label13.TabIndex = 5;
            this.label13.Text = "Articulos Solicitados";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tableLayoutPanel5);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(771, 266);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(513, 586);
            this.panel6.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel5.Controls.Add(this.button3, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.btnRecibir, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 261);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 9;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.002501F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.85643F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.85643F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.85643F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.85643F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.85643F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.85643F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.85643F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.002501F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(513, 325);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(345, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "Nueva Compra";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnRecibir
            // 
            this.btnRecibir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecibir.Location = new System.Drawing.Point(3, 19);
            this.btnRecibir.Name = "btnRecibir";
            this.btnRecibir.Size = new System.Drawing.Size(165, 35);
            this.btnRecibir.TabIndex = 1;
            this.btnRecibir.Text = "Recibir";
            this.btnRecibir.UseVisualStyleBackColor = true;
            this.btnRecibir.Click += new System.EventHandler(this.btnRecibir_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(174, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pictureBoxProducto);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(513, 261);
            this.panel7.TabIndex = 0;
            // 
            // pictureBoxProducto
            // 
            this.pictureBoxProducto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxProducto.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxProducto.Name = "pictureBoxProducto";
            this.pictureBoxProducto.Size = new System.Drawing.Size(513, 261);
            this.pictureBoxProducto.TabIndex = 1;
            this.pictureBoxProducto.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.Controls.Add(this.ListViewArticulos);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 266);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(771, 586);
            this.panel8.TabIndex = 5;
            // 
            // ListViewArticulos
            // 
            this.ListViewArticulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ListViewArticulos.Dock = System.Windows.Forms.DockStyle.Top;
            this.ListViewArticulos.FullRowSelect = true;
            this.ListViewArticulos.GridLines = true;
            this.ListViewArticulos.HideSelection = false;
            this.ListViewArticulos.LabelEdit = true;
            this.ListViewArticulos.Location = new System.Drawing.Point(0, 0);
            this.ListViewArticulos.Name = "ListViewArticulos";
            this.ListViewArticulos.Size = new System.Drawing.Size(771, 504);
            this.ListViewArticulos.TabIndex = 0;
            this.ListViewArticulos.UseCompatibleStateImageBehavior = false;
            this.ListViewArticulos.View = System.Windows.Forms.View.Details;
            // 
            // FOperaciones
            // 
            this.ClientSize = new System.Drawing.Size(1284, 852);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TLPFiltros2);
            this.Controls.Add(this.TLFiltros);
            this.Name = "FOperaciones";
            this.Text = "Operaciones";
            this.TLFiltros.ResumeLayout(false);
            this.TLFiltros.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TLPFiltros2.ResumeLayout(false);
            this.TLPFiltros2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProducto)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public FOperaciones(ProductoService productoService)
        {
            InitializeComponent();
            _productoService = productoService;
            // Carga inicial de dato
            CargarDatosIniciales();
            ActualizarTextBoxArticulos();
        }
        private void CargarDatosIniciales()
        {
            try
            {
                _todosLosProductos = _productoService.ObtenerProductosConDetalle();
                ConfigurarListView();
                CargarProductosEnListView();
                ActualizarComboBox(ComboBoxProductos, _todosLosProductos);
                CargarCodigoCompraEnComboBox();
                CargarClienteEnComboBox();
                CargarCodigoArticuloEnComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        #region Eventos de Filtros - IMPLEMENTACIÓN CORRECTA

        private void ComboBoxProductos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_cambiandoSeleccion) return;
            ComboBoxProductos.DroppedDown = false;
            _cambiandoSeleccion = true;
            try
            {
                if (ComboBoxProductos.SelectedItem == null) return;
                string productoSeleccionado = ComboBoxProductos.SelectedItem.ToString();

                _lastSelectedText = productoSeleccionado;
                // Obtener valores actuales de otros combos (IGUAL QUE EN CLIENTE)
                string codigoCompraActual = ComboBoxCodigoCompra.SelectedItem?.ToString() ?? "";
                string clienteActual = ComboBoxCliente.SelectedItem?.ToString() ?? "";
                string codigoArticuloActual = ComboBoxCodigoArticulo.SelectedItem?.ToString() ?? "";
                DateTime? fechaActual = dtFechaCompra.ShowCheckBox && dtFechaCompra.Checked ? dtFechaCompra.Value.Date : (DateTime?)null;

                // NO ACTUALIZAR ComboProductos aquí
                ActualizarComboCliente(productoSeleccionado, codigoCompraActual, fechaActual, codigoArticuloActual);
                ActualizarComboCodigoCompra(productoSeleccionado, codigoCompraActual, fechaActual, clienteActual, codigoArticuloActual);
                ActualizarComboCodigoArticulo(productoSeleccionado, codigoCompraActual, fechaActual, clienteActual);
                ActualizarFecha(productoSeleccionado, codigoCompraActual, clienteActual, codigoArticuloActual);

                var codigosCompra = ObtenerCodigosPorFiltros(productoSeleccionado, codigoCompraActual, fechaActual, clienteActual, codigoArticuloActual);
                ActualizarListview(codigosCompra);
            }
            finally
            {
                _cambiandoSeleccion = false;
            }
        }

        private void ComboBoxCodigoCompra_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_cambiandoSeleccion) return;
            ComboBoxCodigoCompra.DroppedDown = false;
            _cambiandoSeleccion = true;

            try
            {
                if (ComboBoxCodigoCompra.SelectedItem == null) return;

                string codigoCompraSeleccionado = ComboBoxCodigoCompra.SelectedItem.ToString();

                // Obtener valores actuales de otros combos
                string productoActual = !string.IsNullOrEmpty(_lastSelectedText) ? _lastSelectedText : "";
                string clienteActual = ComboBoxCliente.SelectedItem?.ToString() ?? "";
                string codigoArticuloActual = ComboBoxCodigoArticulo.SelectedItem?.ToString() ?? "";
                DateTime? fechaActual = dtFechaCompra.ShowCheckBox && dtFechaCompra.Checked ? dtFechaCompra.Value.Date : (DateTime?)null;

                // Actualizar otros combos con todos los filtros
                ActualizarComboProductos(productoActual, codigoCompraSeleccionado, fechaActual, clienteActual, codigoArticuloActual);
                ActualizarComboCliente(productoActual, codigoCompraSeleccionado, fechaActual, codigoArticuloActual);
                ActualizarComboCodigoArticulo(productoActual, codigoCompraSeleccionado, fechaActual, clienteActual);
                ActualizarFecha(productoActual, codigoCompraSeleccionado, clienteActual, codigoArticuloActual);

                // Actualizar ListView
                var codigosCompra = ObtenerCodigosPorFiltros(productoActual, codigoCompraSeleccionado, fechaActual, clienteActual, codigoArticuloActual);
                ActualizarListview(codigosCompra);
            }
            finally
            {
                _cambiandoSeleccion = false;
            }
        }

        private void ComboBoxCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_cambiandoSeleccion) return;
            ComboBoxCliente.DroppedDown = false;
            _cambiandoSeleccion = true;

            try
            {
                if (ComboBoxCliente.SelectedItem == null) return;

                string clienteSeleccionado = ComboBoxCliente.SelectedItem.ToString();

                // Obtener valores actuales de otros combos
                string productoActual = !string.IsNullOrEmpty(_lastSelectedText) ? _lastSelectedText : "";
                string codigoCompraActual = ComboBoxCodigoCompra.SelectedItem?.ToString() ?? "";
                string codigoArticuloActual = ComboBoxCodigoArticulo.SelectedItem?.ToString() ?? "";
                DateTime? fechaActual = dtFechaCompra.ShowCheckBox && dtFechaCompra.Checked ? dtFechaCompra.Value.Date : (DateTime?)null;

                // Actualizar otros combos con todos los filtros
                ActualizarComboProductos(productoActual, codigoCompraActual, fechaActual, clienteSeleccionado, codigoArticuloActual);
                ActualizarComboCodigoCompra(productoActual, codigoCompraActual, fechaActual, clienteSeleccionado, codigoArticuloActual);
                ActualizarComboCodigoArticulo(productoActual, codigoCompraActual, fechaActual, clienteSeleccionado);
                ActualizarFecha(productoActual, codigoCompraActual, clienteSeleccionado, codigoArticuloActual);

                // Actualizar ListView
                var codigosCompra = ObtenerCodigosPorFiltros(productoActual, codigoCompraActual, fechaActual, clienteSeleccionado, codigoArticuloActual);
                ActualizarListview(codigosCompra);
            }
            finally
            {
                _cambiandoSeleccion = false;
            }
        }

        private void ComboBoxCodigoArticulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (_cambiandoSeleccion) return;
            ComboBoxCodigoArticulo.DroppedDown = false;
            _cambiandoSeleccion = true;

            try
            {
                if (ComboBoxCodigoArticulo.SelectedItem == null) return;

                string codigoArticuloSeleccionado = ComboBoxCodigoArticulo.SelectedItem.ToString();

                // Obtener valores actuales de otros combos
                string productoActual = !string.IsNullOrEmpty(_lastSelectedText) ? _lastSelectedText : "";
                string codigoCompraActual = ComboBoxCodigoCompra.SelectedItem?.ToString() ?? "";
                string clienteActual = ComboBoxCliente.SelectedItem?.ToString() ?? "";
                DateTime? fechaActual = dtFechaCompra.Checked ? dtFechaCompra.Value.Date : (DateTime?)null;

                // Actualizar otros combos con todos los filtros
                ActualizarComboProductos(productoActual, codigoCompraActual, fechaActual, clienteActual, codigoArticuloSeleccionado);
                ActualizarComboCodigoCompra(productoActual, codigoCompraActual, fechaActual, clienteActual, codigoArticuloSeleccionado);
                ActualizarComboCliente(productoActual, codigoCompraActual, fechaActual, codigoArticuloSeleccionado);
                ActualizarFecha(productoActual, codigoCompraActual, clienteActual, codigoArticuloSeleccionado);

                // Actualizar ListView
                var codigosCompra = ObtenerCodigosPorFiltros(productoActual, codigoCompraActual, fechaActual, clienteActual, codigoArticuloSeleccionado);
                ActualizarListview(codigosCompra);
            }
            finally
            {
                _cambiandoSeleccion = false;
            }
        }

        private void dtFechaCompra_ValueChanged(object sender, EventArgs e)
        {
            if (_cambiandoSeleccion) return;
            if (!dtFechaCompra.Checked) return;

            _cambiandoSeleccion = true;

            try
            {
                DateTime fechaSeleccionada = dtFechaCompra.Value.Date;

                // Obtener valores actuales de otros combos
                string productoActual = !string.IsNullOrEmpty(_lastSelectedText) ? _lastSelectedText : "";
                string codigoCompraActual = ComboBoxCodigoCompra.SelectedItem?.ToString() ?? "";
                string clienteActual = ComboBoxCliente.SelectedItem?.ToString() ?? "";
                string codigoArticuloActual = ComboBoxCodigoArticulo.SelectedItem?.ToString() ?? "";

                // Actualizar otros combos con todos los filtros
                ActualizarComboProductos(productoActual, codigoCompraActual, fechaSeleccionada, clienteActual, codigoArticuloActual);
                ActualizarComboCodigoCompra(productoActual, codigoCompraActual, fechaSeleccionada, clienteActual, codigoArticuloActual);
                ActualizarComboCliente(productoActual, codigoCompraActual, fechaSeleccionada, codigoArticuloActual);
                ActualizarComboCodigoArticulo(productoActual, codigoCompraActual, fechaSeleccionada, clienteActual);

                // Actualizar ListView
                var codigosCompra = ObtenerCodigosPorFiltros(productoActual, codigoCompraActual, fechaSeleccionada, clienteActual, codigoArticuloActual);
                ActualizarListview(codigosCompra);
            }
            finally
            {
                _cambiandoSeleccion = false;
            }
        }

        #endregion

        #region Métodos de Actualización con Filtros Combinados

        private void ActualizarComboCodigoCompra(string articulo, string codigoCompra, DateTime? fecha, string cliente, string codigoArticulo)
        {
            // Obtener todos los registros para filtrar
            IQueryable<ProductoDTO> registrosFiltrados = _todosLosProductos.AsQueryable();

            // Aplicar filtros
            if (!string.IsNullOrEmpty(articulo))
            {
                registrosFiltrados = registrosFiltrados.Where(p => p.Producto.Equals(articulo, StringComparison.OrdinalIgnoreCase));
            }

            if (fecha.HasValue)
            {
                registrosFiltrados = registrosFiltrados.Where(p => p.FechaCompra.Date == fecha.Value);
            }

            if (!string.IsNullOrEmpty(cliente))
            {
                registrosFiltrados = registrosFiltrados.Where(p => p.ClienteNombre.Equals(cliente, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(codigoArticulo))
            {
                registrosFiltrados = registrosFiltrados.Where(p => p.CodigoArticulo == codigoArticulo);
            }

            // Obtener códigos únicos
            var codigosUnicos = registrosFiltrados
                .Select(p => p.CodigoCompra)
                .Distinct()
                .ToArray();

            // Actualizar combo
            ComboBoxCodigoCompra.BeginUpdate();
            ComboBoxCodigoCompra.Items.Clear();
            ComboBoxCodigoCompra.Items.AddRange(codigosUnicos);
            ComboBoxCodigoCompra.EndUpdate();

            // Lógica de selección
            if (codigosUnicos.Length == 1)
            {
                ComboBoxCodigoCompra.SelectedIndex = 0;
                ComboBoxCodigoCompra.Enabled = false;
            }
            else
            {
                ComboBoxCodigoCompra.SelectedIndex = -1;
                ComboBoxCodigoCompra.Enabled = true;
            }
        }
        private void ActualizarComboProductos(string articulo, string codigoCompra, DateTime? fecha, string cliente, string codigoArticulo)
        {
            var query = _todosLosProductos.AsQueryable();

            // Aplicar filtros solo si tienen valores
            if (!string.IsNullOrEmpty(codigoCompra))
                query = query.Where(p => p.CodigoCompra == codigoCompra);

            if (fecha.HasValue)
                query = query.Where(p => p.FechaCompra.Date == fecha.Value);

            if (!string.IsNullOrEmpty(cliente))
                query = query.Where(p => p.ClienteNombre.Equals(cliente, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(codigoArticulo))
                query = query.Where(p => p.CodigoArticulo == codigoArticulo);

            var productosUnicos = query
                .Select(p => p.Producto)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            ComboBoxProductos.BeginUpdate();
            ComboBoxProductos.Items.Clear();
            ComboBoxProductos.Items.AddRange(productosUnicos.ToArray());
            ComboBoxProductos.EndUpdate();

            // Mantener selección si es válida
            if (!string.IsNullOrEmpty(articulo) && productosUnicos.Contains(articulo))
            {
                ComboBoxProductos.SelectedItem = articulo;
                ComboBoxProductos.Text = articulo;
                _lastSelectedText = articulo;
            }
        }

        private void ActualizarComboCliente(string articulo, string codigoCompra, DateTime? fecha, string codigoArticulo)
        {
            var query = _todosLosProductos.AsQueryable();

            // Aplicar filtros solo si tienen valores
            if (!string.IsNullOrEmpty(articulo))
                query = query.Where(p => p.Producto.Equals(articulo, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(codigoCompra))
                query = query.Where(p => p.CodigoCompra == codigoCompra);

            if (fecha.HasValue)
                query = query.Where(p => p.FechaCompra.Date == fecha.Value);

            if (!string.IsNullOrEmpty(codigoArticulo))
                query = query.Where(p => p.CodigoArticulo == codigoArticulo);

            var clientesUnicos = query
                .Where(p => !string.IsNullOrEmpty(p.ClienteNombre))
                .Select(p => p.ClienteNombre)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            ComboBoxCliente.BeginUpdate();
            ComboBoxCliente.Items.Clear();
            ComboBoxCliente.Items.AddRange(clientesUnicos.ToArray());
            ComboBoxCliente.EndUpdate();

            if (clientesUnicos.Count == 1)
            {
                ComboBoxCliente.SelectedIndex = 0;
                ComboBoxCliente.Enabled = false;
            }
            else
            {
                ComboBoxCliente.SelectedIndex = -1;
                ComboBoxCliente.Enabled = true;
            }
        }

        private void ActualizarComboCodigoArticulo(string articulo, string codigoCompra, DateTime? fecha, string cliente)
        {
            var query = _todosLosProductos.AsQueryable();

            // Aplicar filtros solo si tienen valores
            if (!string.IsNullOrEmpty(articulo))
                query = query.Where(p => p.Producto.Equals(articulo, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(codigoCompra))
                query = query.Where(p => p.CodigoCompra == codigoCompra);

            if (fecha.HasValue)
                query = query.Where(p => p.FechaCompra.Date == fecha.Value);

            if (!string.IsNullOrEmpty(cliente))
                query = query.Where(p => p.ClienteNombre.Equals(cliente, StringComparison.OrdinalIgnoreCase));

            var codigosUnicos = query
                .Where(p => !string.IsNullOrEmpty(p.CodigoArticulo))
                .Select(p => p.CodigoArticulo)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            ComboBoxCodigoArticulo.BeginUpdate();
            ComboBoxCodigoArticulo.Items.Clear();
            ComboBoxCodigoArticulo.Items.AddRange(codigosUnicos.ToArray());
            ComboBoxCodigoArticulo.EndUpdate();

            if (codigosUnicos.Count == 1)
            {
                ComboBoxCodigoArticulo.SelectedIndex = 0;
                ComboBoxCodigoArticulo.Enabled = false;
            }
            else
            {
                ComboBoxCodigoArticulo.SelectedIndex = -1;
                ComboBoxCodigoArticulo.Enabled = true;
            }
        }

        private void ActualizarFecha(string articulo, string codigoCompra, string cliente, string codigoArticulo)
        {
            var query = _todosLosProductos.AsQueryable();

            // Aplicar filtros solo si tienen valores
            if (!string.IsNullOrEmpty(articulo))
                query = query.Where(p => p.Producto.Equals(articulo, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(codigoCompra))
                query = query.Where(p => p.CodigoCompra == codigoCompra);

            if (!string.IsNullOrEmpty(cliente))
                query = query.Where(p => p.ClienteNombre.Equals(cliente, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(codigoArticulo))
                query = query.Where(p => p.CodigoArticulo == codigoArticulo);

            var fechasUnicas = query
                .Select(p => p.FechaCompra.Date)
                .Distinct()
                .OrderBy(f => f)
                .ToList();

            dtFechaCompra.ShowCheckBox = true;

            if (fechasUnicas.Count == 1)
            {
                dtFechaCompra.Value = fechasUnicas[0];
                dtFechaCompra.Checked = true;
                dtFechaCompra.Enabled = false;
            }
            else if (fechasUnicas.Count > 1)
            {
                dtFechaCompra.Enabled = true;
            }
            else
            {
                dtFechaCompra.Checked = false;
                dtFechaCompra.Enabled = true;
            }
        }

        private string[] ObtenerCodigosPorFiltros(string articulo, string codigoCompra, DateTime? fecha, string cliente, string codigoArticulo)
        {
            var query = _todosLosProductos.AsQueryable();

            // Aplicar filtros solo si tienen valores
            if (!string.IsNullOrEmpty(articulo))
                query = query.Where(p => p.Producto.Equals(articulo, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(codigoCompra))
                query = query.Where(p => p.CodigoCompra == codigoCompra);

            if (fecha.HasValue)
                query = query.Where(p => p.FechaCompra.Date == fecha.Value);

            if (!string.IsNullOrEmpty(cliente))
                query = query.Where(p => p.ClienteNombre.Equals(cliente, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(codigoArticulo))
                query = query.Where(p => p.CodigoArticulo == codigoArticulo);

            return query.Select(p => p.CodigoCompra).Distinct().ToArray();
        }

        #endregion

        #region Metodos Antiguos
        private void ActualizarComboBox(ComboBox comboBox, List<ProductoDTO> productos)
        {
            comboBox.BeginUpdate();
            comboBox.Items.Clear();

            // Obtener nombres únicos de productos
            var productosUnicos = productos
                .Where(p => !string.IsNullOrEmpty(p.Producto))
                .Select(p => p.Producto)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            foreach (var producto in productosUnicos)
            {
                comboBox.Items.Add(producto);
            }

            comboBox.EndUpdate();
        }
        private void CargarCodigoCompraEnComboBox()
        {
            try
            {
                ComboBoxCodigoCompra.BeginUpdate();
                ComboBoxCodigoCompra.Items.Clear();

                if (_todosLosProductos != null && _todosLosProductos.Any())
                {

                    var codigoUnico = _todosLosProductos
                       .Select(p => p.CodigoCompra)
                       .Where(codigoC => !string.IsNullOrEmpty(codigoC)) // Opcional: filtra nulos/vacíos
                       .Distinct();

                    foreach (var codigoC in codigoUnico)
                    {
                        ComboBoxCodigoCompra.Items.Add(codigoC); // O la propiedad que quieras mostrar
                    }
                }
            }
            finally
            {
                ComboBoxCodigoCompra.EndUpdate();
            }
        }
        private void CargarClienteEnComboBox()
        {
            try
            {
                ComboBoxCliente.BeginUpdate();
                ComboBoxCliente.Items.Clear();

                if (_todosLosProductos != null && _todosLosProductos.Any())
                {
                    // Selecciona solo los clientes distintos (sin repetir)
                    var clientesUnicos = _todosLosProductos
                        .Select(p => p.ClienteNombre)
                        .Distinct()
                        .OrderBy(nombre => nombre); // Opcional: orden alfabético

                    foreach (var cliente in clientesUnicos)
                    {
                        ComboBoxCliente.Items.Add(cliente);
                    }
                }
            }
            finally
            {
                ComboBoxCliente.EndUpdate();
            }
        }
        private void CargarCodigoArticuloEnComboBox()
        {
            try
            {
                ComboBoxCodigoArticulo.BeginUpdate();
                ComboBoxCodigoArticulo.Items.Clear();

                if (_todosLosProductos != null && _todosLosProductos.Any())
                {
                    var codigosUnicos = _todosLosProductos
                        .Where(p => !string.IsNullOrEmpty(p.CodigoArticulo))
                        .Select(p => p.CodigoArticulo)
                        .Distinct()
                        .OrderBy(codigo => codigo);

                    foreach (var codigo in codigosUnicos)
                    {
                        ComboBoxCodigoArticulo.Items.Add(codigo);
                    }
                }
            }
            finally
            {
                ComboBoxCodigoArticulo.EndUpdate();
            }
        }

        /*private void CargarProductosEnListView()
        {
            try
            {
                // Desactivar la interfaz durante la carga
                ListViewArticulos.BeginUpdate();

                ListViewArticulos.Items.Clear();

                // Usar los productos ya cargados en _todosLosProductos
                foreach (var producto in _todosLosProductos)
                {
                    ListViewItem item = new ListViewItem(producto.IdProducto.ToString());
                    item.SubItems.Add(producto.Producto);
                    item.SubItems.Add(producto.ClienteNombre);
                    item.SubItems.Add(producto.Categoria);
                    item.SubItems.Add(producto.Precio.ToString("C"));
                    item.SubItems.Add(producto.Cantidad.ToString());
                    item.SubItems.Add(producto.FechaCompra.ToShortDateString());
                    item.SubItems.Add(producto.CodigoTransportista ?? "");
                    item.SubItems.Add(producto.CodigoArticulo ?? "");
                    item.SubItems.Add(producto.Status);
                    item.Tag = producto;

                    ListViewArticulos.Items.Add(item);
                }

                ListViewArticulos.EndUpdate();
                ListViewArticulos.Focus();

                if (ListViewArticulos.Items.Count > 0)
                {
                    ListViewArticulos.Items[0].Selected = true;
                    ListViewArticulos.Items[0].EnsureVisible();
                }
                else
                {
                    // Limpiar la imagen si no hay productos
                    if (pictureBoxProducto.Image != null)
                    {
                        var oldImage = pictureBoxProducto.Image;
                        pictureBoxProducto.Image = null;
                        oldImage.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos en ListView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        /*private void ActualizarListview(string[] codigosCompra)
        {
            ListViewArticulos.Items.Clear();

            var productosAgrupados = _todosLosProductos
                .Where(p => codigosCompra.Contains(p.CodigoCompra))
                .GroupBy(p => p.CodigoCompra)
                .OrderBy(grupo => grupo.Key)
                .Select(grupo => new
                {
                    CodigoCompra = grupo.Key,
                    Productos = grupo.OrderBy(p => p.Producto).ToList()
                })
                .ToList();

            foreach (var grupo in productosAgrupados)
            {
                foreach (var producto in grupo.Productos)
                {
                    ListViewItem item = new ListViewItem(producto.IdProducto.ToString());
                    item.SubItems.Add(producto.Producto);
                    item.SubItems.Add(producto.ClienteNombre);
                    item.SubItems.Add(producto.Categoria);
                    item.SubItems.Add(producto.Precio.ToString("C"));
                    item.SubItems.Add(producto.Cantidad.ToString());
                    item.SubItems.Add(producto.FechaCompra.ToShortDateString());
                    item.SubItems.Add(producto.CodigoTransportista ?? "");
                    item.SubItems.Add(producto.CodigoArticulo ?? "");
                    item.SubItems.Add(producto.Status);
                    item.SubItems.Add(grupo.CodigoCompra);

                    item.Tag = producto;
                    ListViewArticulos.Items.Add(item);
                }
            }
        }*/
        private string[] ObtenerClientesPorCodigoCompra(string codigoCompra)
        {
            // Validación robusta de parámetros
            if (string.IsNullOrWhiteSpace(codigoCompra))
            {
                return Array.Empty<string>();
            }

            // Validar que la colección de productos esté inicializada
            if (_todosLosProductos == null || !_todosLosProductos.Any())
            {
                Console.WriteLine("Advertencia: La lista de productos no está inicializada o está vacía.");
                return Array.Empty<string>();
            }

            try
            {
                // Buscar todas las coincidencias para el código de compra
                var productosEncontrados = _todosLosProductos
                    .Where(p => !string.IsNullOrEmpty(p.CodigoCompra) &&
                               p.CodigoCompra.Equals(codigoCompra, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Extraer clientes únicos y no nulos
                return productosEncontrados
                    .Select(p => p.ClienteNombre) // Asumiendo que hay una propiedad Cliente en tu objeto Producto
                    .Where(cliente => !string.IsNullOrEmpty(cliente))
                    .Distinct()
                    .ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar clientes para el código '{codigoCompra}': {ex.Message}");
                return Array.Empty<string>();
            }
        }
        private string[] ObtenerCodigoPorDescripcionArticulo(string descripcionArticulo)
        {
            // Validación robusta de parámetros
            if (string.IsNullOrWhiteSpace(descripcionArticulo))
            {
                return Array.Empty<string>();
            }

            // Validar que la colección de productos esté inicializada
            if (_todosLosProductos == null || !_todosLosProductos.Any())
            {
                Console.WriteLine("Advertencia: La lista de productos no está inicializada o está vacía.");
                return Array.Empty<string>();
            }

            try
            {
                // Buscar directamente los códigos de compra para el producto especificado
                return _todosLosProductos
                    .Where(p => !string.IsNullOrEmpty(p.Producto) &&
                               p.Producto.Equals(descripcionArticulo, StringComparison.OrdinalIgnoreCase) &&
                               !string.IsNullOrEmpty(p.CodigoCompra))
                    .Select(p => p.CodigoCompra)
                    .Distinct()
                    .ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar códigos para la descripción '{descripcionArticulo}': {ex.Message}");
                return Array.Empty<string>();
            }
        }
        private DateTime ObtenerFechaPorCodigoCompra(string CodigoCompra)
        {
            try
            {
                // Verificar si el código viene vacío o nulo
                if (string.IsNullOrWhiteSpace(CodigoCompra))
                {
                    return DateTime.MinValue;
                }

                // CORRECCIÓN: Buscar por CodigoCompra, NO por Producto
                var fechaCompra = _todosLosProductos
                    .Where(p => !string.IsNullOrEmpty(p.CodigoCompra) &&
                               p.CodigoCompra.Equals(CodigoCompra, StringComparison.OrdinalIgnoreCase))
                    .Select(p => p.FechaCompra)
                    .FirstOrDefault();

                return fechaCompra;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ObtenerFechaPorCodigoCompra: {ex.Message}");
                return DateTime.MinValue;
            }
        }
        private string ObtenerCodigoProductoPorDescProducto(string DescProducto)
        {
            try
            {
                // Verificar si la descripción viene vacía o nula
                if (string.IsNullOrWhiteSpace(DescProducto))
                {
                    return string.Empty;
                }

                // CORRECCIÓN: Búsqueda exacta y retorno correcto
                var codigoProducto = _todosLosProductos
                    .Where(p => !string.IsNullOrEmpty(p.Producto) &&
                               p.Producto.Equals(DescProducto, StringComparison.OrdinalIgnoreCase))
                    .Select(p => p.CodigoArticulo)
                    .FirstOrDefault();

                return codigoProducto ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en ObtenerCodigoProductoPorDescProducto: {ex.Message}");
                return string.Empty;
            }
        }
        /* private void ConfigurarListView()
         {
             // Configurar propiedades básicas
             ListViewArticulos.View = View.Details;
             ListViewArticulos.FullRowSelect = true;
             ListViewArticulos.GridLines = true;
             ListViewArticulos.MultiSelect = false; // Permitir seleccionar solo un elemento a la vez

             // Importante: Asegurar que el control permita scroll
             ListViewArticulos.Scrollable = true;
             ListViewArticulos.AutoArrange = true;

             // Establecer tamaño adecuado para el control
             // Asegurarse de que el ListView tenga suficiente espacio para mostrar todos los elementos
             ListViewArticulos.Dock = DockStyle.Fill; // Si está usando Dock, ajustarlo adecuadamente
             ListViewArticulos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
             // Agregar columnas
             ListViewArticulos.Columns.Add("ID", 0); // Columna oculta (ancho = 0)
             ListViewArticulos.Columns.Add("Descripción de Artículo", 350, HorizontalAlignment.Center);
             ListViewArticulos.Columns.Add("Cliente", 100, HorizontalAlignment.Center);
             ListViewArticulos.Columns.Add("Categoria", 100, HorizontalAlignment.Center);
             ListViewArticulos.Columns.Add("Precio", 100, HorizontalAlignment.Center);
             ListViewArticulos.Columns.Add("Cantidad", 80, HorizontalAlignment.Center);
             ListViewArticulos.Columns.Add("Fecha", 80, HorizontalAlignment.Center);
             ListViewArticulos.Columns.Add("Codigo Transportista", 100, HorizontalAlignment.Center);
             ListViewArticulos.Columns.Add("Codigo Articulo", 100, HorizontalAlignment.Center);
             ListViewArticulos.Columns.Add("Estado", 100, HorizontalAlignment.Center);

             ListViewArticulos.ColumnWidthChanging += ListViewArticulos_ColumnWidthChanging;

             // Asegurarse de que el evento de selección esté conectado correctamente
             ListViewArticulos.SelectedIndexChanged += ListViewArticulos_SelectedIndexChanged;
         }*/
        /* private void ListViewArticulos_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
         {
             int minWidth = 50;   // Ancho mínimo para todas las columnas
             int maxWidth = 400;  // Ancho máximo para todas las columnas

             // Obtener el índice de la última columna
             int lastColumnIndex = ListViewArticulos.Columns.Count - 1;

             // Evitar que cualquier columna sea demasiado pequeña o grande
             if (e.NewWidth < minWidth)
             {
                 e.NewWidth = minWidth;
                 e.Cancel = true;
             }
             else if (e.NewWidth > maxWidth)
             {
                 e.NewWidth = maxWidth;
                 e.Cancel = true;
             }

             // Restricción extra para la última columna
             if (e.ColumnIndex == lastColumnIndex)
             {
                 int maxLastColumnWidth = 250; // Ajusta el tamaño máximo permitido para la última columna
                 if (e.NewWidth > maxLastColumnWidth)
                 {
                     e.NewWidth = maxLastColumnWidth;
                     e.Cancel = true;
                 }
             }
         }
         private void ListViewArticulos_SelectedIndexChanged(object sender, EventArgs e)
         {
             try
             {
                 if (ListViewArticulos.SelectedItems.Count > 0)
                 {
                     ListViewItem selectedItem = ListViewArticulos.SelectedItems[0];

                     if (selectedItem.Tag is ProductoDTO producto)
                     {
                         // Usar .FireAndForget() o Task.Run para no bloquear la UI
                         // pero sin esperar con await, ya que estamos en un manejador de eventos
                         _ = MostrarImagenProducto(producto.IdProducto);
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show($"Error al cambiar la selección: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }*/
        /* private async Task MostrarImagenProducto(int idProducto)
         {
             try
             {
                 byte[] imagenBytes;

                 // Verificar si la imagen ya está en caché
                 if (_imagenCache.TryGetValue(idProducto, out imagenBytes))
                 {
                     // Si ya está en caché, usarla directamente
                 }
                 else
                 {
                     // Si no está en caché, cargarla y guardarla
                     imagenBytes = await Task.Run(() => _productoService.ObtenerImagen(idProducto));

                     // Guardar en caché para uso futuro
                     if (imagenBytes != null && imagenBytes.Length > 0)
                     {
                         _imagenCache[idProducto] = imagenBytes;
                     }
                 }

                 // Actualizar la UI con la imagen
                 if (pictureBoxProducto.InvokeRequired)
                 {
                     pictureBoxProducto.Invoke(new Action(() => ActualizarImagen(imagenBytes)));
                 }
                 else
                 {
                     ActualizarImagen(imagenBytes);
                 }
             }
             catch (Exception ex)
             {
                 // Aquí usamos BeginInvoke para no bloquear el hilo de UI
                 pictureBoxProducto.BeginInvoke(new Action(() =>
                     MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                 ));
             }
         }*/
        /*private void ActualizarImagen(byte[] imagenBytes)
         {
             if (imagenBytes != null && imagenBytes.Length > 0)
             {
                 using (MemoryStream ms = new MemoryStream(imagenBytes))
                 {
                     try
                     {
                         // Liberar recursos de la imagen anterior si existe
                         if (pictureBoxProducto.Image != null)
                         {
                             var oldImage = pictureBoxProducto.Image;
                             pictureBoxProducto.Image = null;
                             oldImage.Dispose();
                         }

                         pictureBoxProducto.Image = Image.FromStream(ms);
                         pictureBoxProducto.SizeMode = PictureBoxSizeMode.Zoom;
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show($"Error al procesar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
                 }
             }
             else
             {
                 // Si no hay imagen, dejar vacío
                 if (pictureBoxProducto.Image != null)
                 {
                     var oldImage = pictureBoxProducto.Image;
                     pictureBoxProducto.Image = null;
                     oldImage.Dispose();
                 }
             }
         }*/

        private void ProcesarUnicoCodigoCompra(string codigoCompra, string productoSeleccionado)
        {
            // Obtener todos los datos de esta compra específica para este producto
            var productosDeEstaCompra = _todosLosProductos
                .Where(p => p.CodigoCompra == codigoCompra &&
                           p.Producto.Equals(productoSeleccionado, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();

            if (productosDeEstaCompra == null) return;

            // Llenar y bloquear todos los controles porque solo hay UNA opción
            ComboBoxCodigoCompra.Items.Clear();
            ComboBoxCliente.Items.Clear();
            ComboBoxCodigoArticulo.Items.Clear();

            ComboBoxCodigoCompra.Items.Add(productosDeEstaCompra.CodigoCompra);
            ComboBoxCliente.Items.Add(productosDeEstaCompra.ClienteNombre ?? "Cliente no especificado");
            ComboBoxCodigoArticulo.Items.Add(productosDeEstaCompra.CodigoArticulo ?? "Código no especificado");

            // Seleccionar los únicos valores disponibles
            ComboBoxCodigoCompra.SelectedIndex = 0;
            ComboBoxCliente.SelectedIndex = 0;
            ComboBoxCodigoArticulo.SelectedIndex = 0;

            // Configurar fecha única
            dtFechaCompra.ShowCheckBox = true;
            if (productosDeEstaCompra.FechaCompra != DateTime.MinValue &&
                productosDeEstaCompra.FechaCompra >= dtFechaCompra.MinDate &&
                productosDeEstaCompra.FechaCompra <= dtFechaCompra.MaxDate)
            {
                dtFechaCompra.Value = productosDeEstaCompra.FechaCompra.Date;
                dtFechaCompra.Checked = true;
                dtFechaCompra.Enabled = false; // Bloquear porque es única
            }
            else
            {
                dtFechaCompra.Checked = false;
                dtFechaCompra.Enabled = true;
            }

            // BLOQUEAR todos los controles porque solo hay una opción
            ComboBoxCodigoCompra.Enabled = false;
            ComboBoxCliente.Enabled = false;
            ComboBoxCodigoArticulo.Enabled = false;

            ActualizarListview(new[] { codigoCompra });
        }

        private void ProcesarMultiplesCodigosCompra(string[] codigosCompra)
        {
            // Obtener TODAS las compras que contienen el producto seleccionado
            string productoSeleccionado = _lastSelectedText;
            var comprasDelProducto = _todosLosProductos
                .Where(p => codigosCompra.Contains(p.CodigoCompra) &&
                           p.Producto.Equals(productoSeleccionado, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // 1. CÓDIGOS DE COMPRA - Mostrar todos los disponibles
            ComboBoxCodigoCompra.Items.Clear();
            var codigosUnicos = comprasDelProducto.Select(p => p.CodigoCompra).Distinct().ToArray();
            ComboBoxCodigoCompra.Items.AddRange(codigosUnicos);
            ComboBoxCodigoCompra.SelectedIndex = -1; // No preseleccionar
            ComboBoxCodigoCompra.Enabled = true;

            // 2. CLIENTES - Mostrar todos los clientes que compraron este producto
            ComboBoxCliente.Items.Clear();
            var clientesUnicos = comprasDelProducto
                .Where(p => !string.IsNullOrEmpty(p.ClienteNombre))
                .Select(p => p.ClienteNombre)
                .Distinct()
                .ToArray();
            ComboBoxCliente.Items.AddRange(clientesUnicos);
            ComboBoxCliente.SelectedIndex = -1; // No preseleccionar
            ComboBoxCliente.Enabled = true;

            // 3. CÓDIGOS DE ARTÍCULO - Mostrar todos los códigos únicos
            ComboBoxCodigoArticulo.Items.Clear();
            var codigosArticulo = comprasDelProducto
                .Where(p => !string.IsNullOrEmpty(p.CodigoArticulo))
                .Select(p => p.CodigoArticulo)
                .Distinct()
                .ToArray();
            ComboBoxCodigoArticulo.Items.AddRange(codigosArticulo);
            ComboBoxCodigoArticulo.SelectedIndex = -1; // No preseleccionar
            ComboBoxCodigoArticulo.Enabled = true;

            // 4. FECHAS - Configurar según las fechas disponibles
            var fechasUnicas = comprasDelProducto
                .Select(p => p.FechaCompra)
                .Where(f => f != DateTime.MinValue && f >= dtFechaCompra.MinDate && f <= dtFechaCompra.MaxDate)
                .Select(f => f.Date)
                .Distinct()
                .ToArray();

            dtFechaCompra.ShowCheckBox = true;
            if (fechasUnicas.Length == 1)
            {
                // Solo una fecha - bloquear
                dtFechaCompra.Value = fechasUnicas[0];
                dtFechaCompra.Checked = true;
                dtFechaCompra.Enabled = false;
            }
            else if (fechasUnicas.Length > 1)
            {
                // Múltiples fechas - habilitar para selección
                dtFechaCompra.Checked = false;
                dtFechaCompra.Enabled = true;
            }
            else
            {
                dtFechaCompra.Checked = false;
                dtFechaCompra.Enabled = true;
            }

            ActualizarListview(codigosUnicos);
        }
        private void LimpiarControles()
        {
            ComboBoxCodigoCompra.Items.Clear();
            ComboBoxCliente.Items.Clear();
            ComboBoxCodigoArticulo.Items.Clear();

            ComboBoxCodigoCompra.Enabled = true;
            ComboBoxCliente.Enabled = true;
            ComboBoxCodigoArticulo.Enabled = true;

            dtFechaCompra.ShowCheckBox = false;
            dtFechaCompra.Value = DateTime.Today;
        }
        private List<ProductoDTO> FiltrarProductos(string codigoCompra = null, string codigoProducto = null, string nombreProducto = null, DateTime? fechaCompra = null, string cliente = null)
        {
            var query = _todosLosProductos.AsQueryable();

            // Filtrar por código de compra si no es null
            if (!string.IsNullOrEmpty(codigoCompra))
            {
                query = query.Where(p => p.CodigoCompra == codigoCompra);
            }

            // Filtrar por código de producto si no es null
            if (!string.IsNullOrEmpty(codigoProducto))
            {
                query = query.Where(p => p.CodigoArticulo == codigoProducto);
            }

            // Filtrar por nombre de producto si no es null (búsqueda parcial)
            if (!string.IsNullOrEmpty(nombreProducto))
            {
                query = query.Where(p => p.Producto.Contains(nombreProducto));
            }

            // Filtrar por fecha de compra si no es null
            if (fechaCompra.HasValue)
            {
                query = query.Where(p => p.FechaCompra.Date == fechaCompra.Value.Date);
            }

            // Filtrar por cliente si no es null (búsqueda parcial)
            if (!string.IsNullOrEmpty(cliente))
            {
                query = query.Where(p => p.ClienteNombre.Contains(cliente));
            }

            return query.ToList();
        }
        /*     private void AplicarFiltroAcumulativo()
             {
                 if (_aplicandoFiltro) return;
                 _aplicandoFiltro = true;
                 try
                 {
                     string codigoCompra = ObtenerValorComboSeguro(ComboBoxCodigoCompra);
                     string codigoProducto = ObtenerValorComboSeguro(ComboBoxCodigoArticulo);
                     string nombreProducto = ObtenerValorComboSeguro(ComboBoxProductos);
                     DateTime? fechaCompra = ObtenerFechaSeleccionada();
                     string cliente = ObtenerValorComboSeguro(ComboBoxCliente);

                     // Si no hay ningún filtro aplicado, no hacer nada
                     if (string.IsNullOrEmpty(codigoCompra) &&
                         string.IsNullOrEmpty(codigoProducto) &&
                         string.IsNullOrEmpty(nombreProducto) &&
                         string.IsNullOrEmpty(cliente) &&
                         fechaCompra == null)
                     {
                         return;
                     }

                     var productosFiltrados = FiltrarProductos(
                         codigoCompra: codigoCompra,
                         codigoProducto: codigoProducto,
                         nombreProducto: nombreProducto,
                         fechaCompra: fechaCompra,
                         cliente: cliente
                     );

                     ActualizarTodosLosControles(productosFiltrados, codigoCompra, codigoProducto, nombreProducto, cliente);
                 }
                 finally
                 {
                     _aplicandoFiltro = false;
                 }
             }*/
        private void ActualizarTodosLosControles(List<ProductoDTO> productos,
             string codigoCompraActual, string codigoProductoActual,
             string nombreProductoActual, string clienteActual)
        {
            // Actualizar combo Código de Compra
            if (string.IsNullOrEmpty(codigoCompraActual))
            {
                ActualizarComboCodigoCompra(productos);
            }

            // Actualizar combo Código de Productos
            if (string.IsNullOrEmpty(codigoProductoActual))
            {
                ActualizarComboCodigoProductos(productos);
            }

            // Actualizar combo Productos
            if (string.IsNullOrEmpty(nombreProductoActual))
            {
                ActualizarComboProductos(productos);
            }

            // Actualizar combo Clientes
            if (string.IsNullOrEmpty(clienteActual))
            {
                ActualizarComboClientes(productos);
            }

            // SIEMPRE actualizar el ListView
            ActualizarListViewConProductos(productos);
        }
        private void ActualizarComboCodigoCompra(List<ProductoDTO> productos)
        {
            var valorActual = ComboBoxCodigoCompra.SelectedValue;
            var codigosCompraUnicos = productos
                .Select(p => p.CodigoCompra)
                .Distinct()
                .Where(c => !string.IsNullOrEmpty(c))
                .OrderBy(c => c)
                .ToArray(); // Convertir a array para AddRange

            ComboBoxCodigoCompra.Items.Clear();
            ComboBoxCodigoCompra.Items.AddRange(codigosCompraUnicos);

            // Intentar mantener la selección actual si existe
            if (valorActual != null && codigosCompraUnicos.Contains(valorActual.ToString()))
            {
                ComboBoxCodigoCompra.SelectedValue = valorActual;
            }
        }

        private void ActualizarComboProductos(List<ProductoDTO> productos)
        {
            var valorActual = ComboBoxProductos.Text;
            ActualizarComboBox(ComboBoxProductos, productos); // Reutilizar el método existente

            // Restaurar selección por texto
            if (!string.IsNullOrEmpty(valorActual))
            {
                ComboBoxProductos.Text = valorActual;
            }
        }

        private void ActualizarComboClientes(List<ProductoDTO> productos)
        {
            var valorActual = ComboBoxCliente.SelectedValue;
            var clientesUnicos = productos
                .Where(p => !string.IsNullOrEmpty(p.ClienteNombre))
                .Select(p => p.ClienteNombre)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            ComboBoxCliente.Items.Clear();

            foreach (var cliente in clientesUnicos)
            {
                ComboBoxCliente.Items.Add(cliente);
            }

            // Intentar mantener la selección actual si existe
            if (valorActual != null && clientesUnicos.Contains(valorActual.ToString()))
            {
                ComboBoxCliente.SelectedValue = valorActual;
            }
        }

        private void ActualizarComboCodigoProductos(List<ProductoDTO> productos)
        {
            var valorActual = ComboBoxCodigoArticulo.Text;
            var codigosProductosUnicos = productos
                .Where(p => !string.IsNullOrEmpty(p.CodigoArticulo))
                .GroupBy(p => p.CodigoArticulo) // Usar GroupBy en lugar de Distinct
                .Select(g => g.First())
                .OrderBy(p => p.CodigoArticulo)
                .ToList();

            ComboBoxCodigoArticulo.Items.Clear();

            foreach (var producto in codigosProductosUnicos)
            {
                string descripcion = $"{producto.CodigoArticulo} - {producto.Producto}";
                ComboBoxCodigoArticulo.Items.Add(descripcion);
            }

            // Restaurar selección por texto
            if (!string.IsNullOrEmpty(valorActual))
            {
                ComboBoxCodigoArticulo.Text = valorActual;
            }
        }
        /*private string ObtenerValorComboSeguro(ComboBox combo)
        {
            if (combo.SelectedIndex == -1)
                return null;

            return combo.SelectedItem?.ToString(); // Esto funciona con Items.AddRange()
        }
        private DateTime? ObtenerFechaSeleccionada()
        {
            // Asumiendo que tu DateTimePicker tiene ShowCheckBox = true
            if (dtFechaCompra.Checked)
                return dtFechaCompra.Value.Date;

            return null;
        }*/

        /* private void ActualizarListViewConProductos(List<ProductoDTO> productos)
         {
             if (_cambiandoSeleccion) return; // Evitar conflictos

             ListViewArticulos.Items.Clear();

             foreach (var producto in productos.OrderBy(p => p.Producto))
             {
                 ListViewItem item = new ListViewItem(producto.IdProducto.ToString());
                 item.SubItems.Add(producto.Producto);
                 item.SubItems.Add(producto.ClienteNombre);
                 item.SubItems.Add(producto.Categoria);
                 item.SubItems.Add(producto.Precio.ToString("C"));
                 item.SubItems.Add(producto.Cantidad.ToString());
                 item.SubItems.Add(producto.FechaCompra.ToShortDateString());
                 item.SubItems.Add(producto.CodigoTransportista ?? "");
                 item.SubItems.Add(producto.CodigoArticulo ?? "");
                 item.SubItems.Add(producto.Status);
                 item.SubItems.Add(producto.CodigoCompra);
                 item.Tag = producto;

                 ListViewArticulos.Items.Add(item);
             }
         }*/

        #endregion

        #region ListView y Búsqueda de Texto
        private void CargarProductosEnListView()
        {
            try
            {
                ListViewArticulos.BeginUpdate();
                ListViewArticulos.Items.Clear();

                foreach (var producto in _todosLosProductos)
                {
                    ListViewItem item = new ListViewItem(producto.IdProducto.ToString());
                    item.SubItems.Add(producto.Producto);
                    item.SubItems.Add(producto.ClienteNombre);
                    item.SubItems.Add(producto.Categoria);
                    item.SubItems.Add(producto.Precio.ToString("C"));
                    item.SubItems.Add(producto.Cantidad.ToString());
                    item.SubItems.Add(producto.FechaCompra.ToShortDateString());
                    item.SubItems.Add(producto.CodigoTransportista ?? "");
                    item.SubItems.Add(producto.CodigoArticulo ?? "");
                    item.SubItems.Add(producto.Status);
                    item.Tag = producto;

                    ListViewArticulos.Items.Add(item);
                }

                ListViewArticulos.EndUpdate();
                ListViewArticulos.Focus();

                if (ListViewArticulos.Items.Count > 0)
                {
                    ListViewArticulos.Items[0].Selected = true;
                    ListViewArticulos.Items[0].EnsureVisible();
                }
                else
                {
                    if (pictureBoxProducto.Image != null)
                    {
                        var oldImage = pictureBoxProducto.Image;
                        pictureBoxProducto.Image = null;
                        oldImage.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos en ListView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarListview(string[] codigosCompra)
        {
            ListViewArticulos.Items.Clear();

            var productosAgrupados = _todosLosProductos
                .Where(p => codigosCompra.Contains(p.CodigoCompra))
                .GroupBy(p => p.CodigoCompra)
                .OrderBy(grupo => grupo.Key)
                .Select(grupo => new
                {
                    CodigoCompra = grupo.Key,
                    Productos = grupo.OrderBy(p => p.Producto).ToList()
                })
                .ToList();

            foreach (var grupo in productosAgrupados)
            {
                foreach (var producto in grupo.Productos)
                {
                    ListViewItem item = new ListViewItem(producto.IdProducto.ToString());
                    item.SubItems.Add(producto.Producto);
                    item.SubItems.Add(producto.ClienteNombre);
                    item.SubItems.Add(producto.Categoria);
                    item.SubItems.Add(producto.Precio.ToString("C"));
                    item.SubItems.Add(producto.Cantidad.ToString());
                    item.SubItems.Add(producto.FechaCompra.ToShortDateString());
                    item.SubItems.Add(producto.CodigoTransportista ?? "");
                    item.SubItems.Add(producto.CodigoArticulo ?? "");
                    item.SubItems.Add(producto.Status);
                    item.SubItems.Add(grupo.CodigoCompra);

                    item.Tag = producto;
                    ListViewArticulos.Items.Add(item);
                }
            }
        }

        private void ActualizarListViewConProductos(List<ProductoDTO> productos)
        {
            if (_cambiandoSeleccion) return;

            ListViewArticulos.Items.Clear();

            foreach (var producto in productos.OrderBy(p => p.Producto))
            {
                ListViewItem item = new ListViewItem(producto.IdProducto.ToString());
                item.SubItems.Add(producto.Producto);
                item.SubItems.Add(producto.ClienteNombre);
                item.SubItems.Add(producto.Categoria);
                item.SubItems.Add(producto.Precio.ToString("C"));
                item.SubItems.Add(producto.Cantidad.ToString());
                item.SubItems.Add(producto.FechaCompra.ToShortDateString());
                item.SubItems.Add(producto.CodigoTransportista ?? "");
                item.SubItems.Add(producto.CodigoArticulo ?? "");
                item.SubItems.Add(producto.Status);
                item.SubItems.Add(producto.CodigoCompra);
                item.Tag = producto;

                ListViewArticulos.Items.Add(item);
            }
        }

        private void ComboBoxProductos_TextChanged(object sender, EventArgs e)
        {
            if (_ignoreTextChanged || !ComboBoxProductos.Focused) return;

            try
            {
                string textoActual = ComboBoxProductos.Text;

                if (textoActual == _lastSelectedText) return;

                var terminosBusqueda = textoActual.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var filtrados = _todosLosProductos.AsEnumerable();

                foreach (var termino in terminosBusqueda)
                {
                    string terminoLower = termino.ToLower();
                    filtrados = filtrados.Where(p =>
                        !string.IsNullOrEmpty(p.Producto) &&
                        p.Producto.ToLower().Contains(terminoLower));
                }

                _ignoreTextChanged = true;
                try
                {
                    ComboBoxProductos.BeginUpdate();
                    ComboBoxProductos.Items.Clear();

                    var productosUnicos = filtrados
                        .Select(p => p.Producto)
                        .Distinct()
                        .OrderBy(p => p)
                        .ToList();

                    foreach (var producto in productosUnicos)
                    {
                        ComboBoxProductos.Items.Add(producto);
                    }

                    ComboBoxProductos.Text = textoActual;
                    ComboBoxProductos.SelectionStart = textoActual.Length;
                    ComboBoxProductos.DroppedDown = !string.IsNullOrEmpty(textoActual) && productosUnicos.Any();
                }
                finally
                {
                    ComboBoxProductos.EndUpdate();
                    _ignoreTextChanged = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error en filtrado: {ex.Message}");
            }
        }

        private void ComboBoxProductos_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_lastSelectedText))
            {
                _ignoreTextChanged = true;
                try
                {
                    ComboBoxProductos.Text = _lastSelectedText;
                }
                finally
                {
                    _ignoreTextChanged = false;
                }
                return;
            }

            _ignoreTextChanged = true;
            try
            {
                ComboBoxProductos.BeginUpdate();
                ComboBoxProductos.Items.Clear();

                var productosUnicos = _todosLosProductos
                    .Where(p => !string.IsNullOrEmpty(p.Producto))
                    .Select(p => p.Producto)
                    .Distinct()
                    .OrderBy(p => p)
                    .ToList();

                foreach (var producto in productosUnicos)
                {
                    ComboBoxProductos.Items.Add(producto);
                }

                ComboBoxProductos.EndUpdate();
                ComboBoxProductos.Text = "";
            }
            finally
            {
                _ignoreTextChanged = false;
            }
        }
        #endregion

        #region ListView Configuration y Events
        private void ConfigurarListView()
        {
            ListViewArticulos.View = View.Details;
            ListViewArticulos.FullRowSelect = true;
            ListViewArticulos.GridLines = true;
            ListViewArticulos.MultiSelect = true;
            ListViewArticulos.Scrollable = true;
            ListViewArticulos.AutoArrange = true;
            ListViewArticulos.Dock = DockStyle.Fill;
            ListViewArticulos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            ListViewArticulos.Columns.Add("ID", 0);
            ListViewArticulos.Columns.Add("Descripción de Artículo", 350, HorizontalAlignment.Center);
            ListViewArticulos.Columns.Add("Cliente", 100, HorizontalAlignment.Center);
            ListViewArticulos.Columns.Add("Categoria", 100, HorizontalAlignment.Center);
            ListViewArticulos.Columns.Add("Precio", 100, HorizontalAlignment.Center);
            ListViewArticulos.Columns.Add("Cantidad", 80, HorizontalAlignment.Center);
            ListViewArticulos.Columns.Add("Fecha", 80, HorizontalAlignment.Center);
            ListViewArticulos.Columns.Add("Codigo Transportista", 100, HorizontalAlignment.Center);
            ListViewArticulos.Columns.Add("Codigo Articulo", 100, HorizontalAlignment.Center);
            ListViewArticulos.Columns.Add("Estado", 100, HorizontalAlignment.Center);

            ListViewArticulos.ColumnWidthChanging += ListViewArticulos_ColumnWidthChanging;
            ListViewArticulos.SelectedIndexChanged += ListViewArticulos_SelectedIndexChanged;
        }

        private void ListViewArticulos_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            int minWidth = 50;
            int maxWidth = 400;
            int lastColumnIndex = ListViewArticulos.Columns.Count - 1;

            if (e.NewWidth < minWidth)
            {
                e.NewWidth = minWidth;
                e.Cancel = true;
            }
            else if (e.NewWidth > maxWidth)
            {
                e.NewWidth = maxWidth;
                e.Cancel = true;
            }

            if (e.ColumnIndex == lastColumnIndex)
            {
                int maxLastColumnWidth = 250;
                if (e.NewWidth > maxLastColumnWidth)
                {
                    e.NewWidth = maxLastColumnWidth;
                    e.Cancel = true;
                }
            }
        }

        private void ListViewArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ListViewArticulos.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = ListViewArticulos.SelectedItems[0];

                    if (selectedItem.Tag is ProductoDTO producto)
                    {
                        _ = MostrarImagenProducto(producto.IdProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar la selección: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task MostrarImagenProducto(int idProducto)
        {
            try
            {
                byte[] imagenBytes;

                if (_imagenCache.TryGetValue(idProducto, out imagenBytes))
                {
                    // Ya está en caché
                }
                else
                {
                    imagenBytes = await Task.Run(() => _productoService.ObtenerImagen(idProducto));

                    if (imagenBytes != null && imagenBytes.Length > 0)
                    {
                        _imagenCache[idProducto] = imagenBytes;
                    }
                }

                if (pictureBoxProducto.InvokeRequired)
                {
                    pictureBoxProducto.Invoke(new Action(() => ActualizarImagen(imagenBytes)));
                }
                else
                {
                    ActualizarImagen(imagenBytes);
                }
            }
            catch (Exception ex)
            {
                pictureBoxProducto.BeginInvoke(new Action(() =>
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ));
            }
        }

        private void ActualizarImagen(byte[] imagenBytes)
        {
            if (imagenBytes != null && imagenBytes.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imagenBytes))
                {
                    try
                    {
                        if (pictureBoxProducto.Image != null)
                        {
                            var oldImage = pictureBoxProducto.Image;
                            pictureBoxProducto.Image = null;
                            oldImage.Dispose();
                        }

                        pictureBoxProducto.Image = Image.FromStream(ms);
                        pictureBoxProducto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al procesar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (pictureBoxProducto.Image != null)
                {
                    var oldImage = pictureBoxProducto.Image;
                    pictureBoxProducto.Image = null;
                    oldImage.Dispose();
                }
            }
        }
        #endregion

        #region Métodos de Limpieza
        public void LimpiarTodosLosFiltros()
        {
            _aplicandoFiltro = true;
            _cambiandoSeleccion = true;
            _lastSelectedText = "";

            try
            {
                ComboBoxProductos.SelectedIndex = -1;
                ComboBoxCodigoCompra.SelectedIndex = -1;
                ComboBoxCodigoArticulo.SelectedIndex = -1;
                ComboBoxCliente.SelectedIndex = -1;
                dtFechaCompra.Checked = false;

                ComboBoxProductos.Text = "";
                ComboBoxCodigoCompra.Text = "";
                ComboBoxCodigoArticulo.Text = "";
                ComboBoxCliente.Text = "";

                // Habilitar todos los controles
                ComboBoxProductos.Enabled = true;
                ComboBoxCodigoCompra.Enabled = true;
                ComboBoxCodigoArticulo.Enabled = true;
                ComboBoxCliente.Enabled = true;
                dtFechaCompra.Enabled = true;

                // Restaurar datos iniciales
                CargarDatosIniciales();
            }
            finally
            {
                _aplicandoFiltro = false;
                _cambiandoSeleccion = false;
            }
        }
        #endregion

        #region Clase de Apoyo
        public class FiltrosActivos
        {
            public string Producto { get; set; }
            public string CodigoCompra { get; set; }
            public string CodigoArticulo { get; set; }
            public string Cliente { get; set; }
            public DateTime? Fecha { get; set; }
        }

        #endregion

        #region Eventos de Botones
        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            // Activar flag para evitar eventos durante limpieza
            _cambiandoSeleccion = true;

            try
            {
                // 1. Limpiar selecciones de todos los ComboBox
                ComboBoxProductos.SelectedIndex = -1;
                ComboBoxCodigoCompra.SelectedIndex = -1;
                ComboBoxCodigoArticulo.SelectedIndex = -1;
                ComboBoxCliente.SelectedIndex = -1;

                // 2. Limpiar texto y variable de producto
                ComboBoxProductos.Text = "";
                _lastSelectedText = "";

                // 3. Resetear DateTimePicker
                dtFechaCompra.Checked = false;
                dtFechaCompra.ShowCheckBox = true;
                dtFechaCompra.Enabled = true;

                // 4. Habilitar todos los controles
                ComboBoxProductos.Enabled = true;
                ComboBoxCodigoCompra.Enabled = true;
                ComboBoxCodigoArticulo.Enabled = true;
                ComboBoxCliente.Enabled = true;

                // 5. Recargar datos iniciales en todos los ComboBox
                ActualizarComboBox(ComboBoxProductos, _todosLosProductos);
                CargarCodigoCompraEnComboBox();
                CargarClienteEnComboBox();
                CargarCodigoArticuloEnComboBox();

                // 6. Mostrar todos los productos en ListView
                CargarProductosEnListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al limpiar filtros: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Desactivar flag al final
                _cambiandoSeleccion = false;
            }
        }
        private void btnRecibir_Click(object sender, EventArgs e)
        {
            ProcesarRecepcionProductos();
        }


        // ===== EVENTO DEL BOTÓN ASIGNAR TRANSPORTISTA=====

        /// <summary>
        /// Evento del botón para asignar transportista
        /// </summary>
        private void btnAsignarTransportista_Click(object sender, EventArgs e)
        {
            ProcesarAsignacionTransportista();
        }

        // ===== MÉTODO PRINCIPAL =====

        /// <summary>
        /// Procesa la asignación de transportista para uno o múltiples productos seleccionados
        /// En selección única: permite modificar precio, asignar transportista y cambiar status
        /// En selección múltiple: asigna transportista, mantiene precios originales y cambia status
        /// </summary>
        private void ProcesarAsignacionTransportista()
        {
            try
            {
                // ===== VALIDACIÓN INICIAL DE SELECCIÓN =====
                var resultadoValidacion = ValidarSeleccionInicial();
                if (!resultadoValidacion.EsValido)
                {
                    MostrarMensajeValidacion(resultadoValidacion.Mensaje, resultadoValidacion.Control);
                    return;
                }

                // ===== DETERMINACIÓN DEL TIPO DE OPERACIÓN =====
                var itemsSeleccionados = ListViewArticulos.SelectedItems.Cast<ListViewItem>().ToList();
                bool esSeleccionUnica = itemsSeleccionados.Count == 1;

                // ===== VALIDACIÓN DE CONFLICTO PRECIO/SELECCIÓN MÚLTIPLE =====
                var validacionConflicto = ValidarConflictoPrecioSeleccionMultiple(esSeleccionUnica);
                if (!validacionConflicto.EsValido)
                {
                    MostrarMensajeValidacion(validacionConflicto.Mensaje, validacionConflicto.Control);
                    return;
                }

                // ===== VALIDACIÓN DE DATOS REQUERIDOS =====
                var datosValidacion = ValidarDatosRequeridos(esSeleccionUnica);
                if (!datosValidacion.EsValido)
                {
                    MostrarMensajeValidacion(datosValidacion.Mensaje, datosValidacion.Control);
                    return;
                }

                // ===== PROCESAMIENTO SEGÚN TIPO DE SELECCIÓN =====
                if (esSeleccionUnica)
                {
                    ProcesarSeleccionUnica(itemsSeleccionados[0], datosValidacion);
                }
                else
                {
                    ProcesarSeleccionMultiple(itemsSeleccionados, datosValidacion);
                }

                // ===== ACTUALIZACIÓN DE LA INTERFAZ =====
                ActualizarInterfazDespuesDeProceso(datosValidacion.CodigoCompra);

                // ===== CONFIRMACIÓN AL USUARIO =====
                string mensajeExito = esSeleccionUnica
                    ? "Transportista, precio y status actualizados correctamente"
                    : $"Transportista y status asignados a {itemsSeleccionados.Count} productos correctamente";

                MostrarMensajeExito(mensajeExito);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        // ===== MÉTODOS DE VALIDACIÓN =====

        /// <summary>
        /// Valida que no haya conflicto entre precio modificado y selección múltiple
        /// </summary>
        private (bool EsValido, string Mensaje, Control Control) ValidarConflictoPrecioSeleccionMultiple(bool esSeleccionUnica)
        {
            // Si es selección única, no hay conflicto
            if (esSeleccionUnica)
            {
                return (true, string.Empty, null);
            }

            // Si hay múltiples seleccionados Y hay precio en el textbox, es un conflicto
            if (!string.IsNullOrWhiteSpace(txtPrecioM.Text))
            {
                return (false,
                        "No es posible modificar el precio cuando hay múltiples productos seleccionados.\n\n" +
                        "Opciones disponibles:\n" +
                        "• Selecciona un solo producto para modificar su precio\n" +
                        "• Borra el precio del campo para proceder con selección múltiple\n" +
                        "• Los precios originales se mantendrán para todos los productos",
                        txtPrecioM);
            }

            return (true, string.Empty, null);
        }

        /// <summary>
        /// Valida que haya elementos seleccionados en el ListView
        /// </summary>
        private (bool EsValido, string Mensaje, Control Control) ValidarSeleccionInicial()
        {
            if (ListViewArticulos.SelectedItems.Count == 0)
            {
                return (false, "Por favor, selecciona al menos un producto del listado.", ListViewArticulos);
            }
            return (true, string.Empty, null);
        }

        /// <summary>
        /// Valida los datos requeridos según el tipo de selección
        /// </summary>
        private DatosValidacion ValidarDatosRequeridos(bool esSeleccionUnica)
        {
            var datos = new DatosValidacion();

            // Validar transportista
            if (string.IsNullOrWhiteSpace(txtTransportista.Text))
            {
                return new DatosValidacion
                {
                    EsValido = false,
                    Mensaje = "Introduzca el código del transportista",
                    Control = txtTransportista
                };
            }
            datos.CodigoTransportista = txtTransportista.Text.Trim();

            // Validar código de compra
            if (string.IsNullOrWhiteSpace(ComboBoxCodigoCompra.Text))
            {
                return new DatosValidacion
                {
                    EsValido = false,
                    Mensaje = "El código de compra no debe estar vacío",
                    Control = ComboBoxCodigoCompra
                };
            }
            datos.CodigoCompra = ComboBoxCodigoCompra.Text.Trim();

            // Para selección única, determinar el precio
            if (esSeleccionUnica)
            {
                datos.PrecioModificado = ObtenerPrecioParaSeleccionUnica();
            }

            datos.EsValido = true;
            return datos;
        }

        // ===== MÉTODOS DE PROCESAMIENTO =====

        /// <summary>
        /// Procesa la actualización para un solo producto (permite modificar precio, transportista y status)
        /// </summary>
        private void ProcesarSeleccionUnica(ListViewItem item, DatosValidacion datos)
        {
            var productoInfo = ExtraerInformacionProducto(item);

            // Validar que el producto existe en la lista global
            var productoDTOEncontrado = _todosLosProductos.FirstOrDefault(p => p.IdProducto == productoInfo.Id);
            if (productoDTOEncontrado == null)
            {
                throw new InvalidOperationException($"No se encontró el producto con ID {productoInfo.Id}");
            }

            // Actualizar en base de datos (transportista, precio y STATUS)
            _productoService.ActualizarProductoTransportista(
                productoInfo.Id,
                datos.PrecioModificado ?? productoInfo.PrecioOriginal,
                datos.CodigoTransportista
            );
        }

        /// <summary>
        /// Procesa la actualización para múltiples productos (transportista + status, mantiene precios)
        /// </summary>
        private void ProcesarSeleccionMultiple(List<ListViewItem> items, DatosValidacion datos)
        {
            var productosParaActualizar = new List<int>();
            var productosNoEncontrados = new List<int>();

            // Validar que todos los productos existen
            foreach (var item in items)
            {
                var productoInfo = ExtraerInformacionProducto(item);
                var productoDTOEncontrado = _todosLosProductos.FirstOrDefault(p => p.IdProducto == productoInfo.Id);

                if (productoDTOEncontrado != null)
                {
                    productosParaActualizar.Add(productoInfo.Id);
                }
                else
                {
                    productosNoEncontrados.Add(productoInfo.Id);
                }
            }

            // Reportar productos no encontrados si los hay
            if (productosNoEncontrados.Any())
            {
                string idsNoEncontrados = string.Join(", ", productosNoEncontrados);
                throw new InvalidOperationException($"No se encontraron los siguientes productos: {idsNoEncontrados}");
            }

            // Actualizar todos los productos (transportista + status, mantener precios originales)
            foreach (var idProducto in productosParaActualizar)
            {
                var producto = _todosLosProductos.First(p => p.IdProducto == idProducto);
                // ActualizarProductoTransportista cambia: transportista, precio y STATUS del producto
                _productoService.ActualizarProductoTransportista(
                    idProducto,
                    producto.Precio, // Mantener precio original
                    datos.CodigoTransportista
                );
            }
        }

        // ===== MÉTODOS AUXILIARES =====

        /// <summary>
        /// Extrae la información básica de un producto desde un ListViewItem
        /// </summary>
        private (int Id, decimal PrecioOriginal) ExtraerInformacionProducto(ListViewItem item)
        {
            if (!int.TryParse(item.SubItems[0].Text, out int id))
            {
                throw new FormatException($"ID de producto inválido: {item.SubItems[0].Text}");
            }

            string textoPrecio = item.SubItems[4].Text.Replace("$", "").Trim();
            if (!decimal.TryParse(textoPrecio, out decimal precio))
            {
                throw new FormatException($"Precio inválido para producto ID {id}: {textoPrecio}");
            }

            return (id, precio);
        }

        /// <summary>
        /// Determina el precio a usar para selección única (modificado o original)
        /// </summary>
        private decimal? ObtenerPrecioParaSeleccionUnica()
        {
            string valorTxt = txtPrecioM.Text.Trim();

            if (string.IsNullOrEmpty(valorTxt))
            {
                return null; // Usar precio original del ListView
            }

            if (!decimal.TryParse(valorTxt, out decimal precioModificado))
            {
                throw new FormatException($"El precio modificado no es válido: {valorTxt}");
            }

            return precioModificado;
        }

        /// <summary>
        /// Actualiza la interfaz después del procesamiento
        /// </summary>
        private void ActualizarInterfazDespuesDeProceso(string codigoCompra)
        {
            // Refrescar datos
            _todosLosProductos = _productoService.ObtenerProductosConDetalle();

            // Actualizar ListView
            string[] codigosCompra = { codigoCompra };
            ActualizarListview(codigosCompra);

            // Actualizar contadores
            ActualizarTextBoxArticulos();

            // Limpiar campo de precio modificado
            txtPrecioM.Clear();

        }

        // ===== MÉTODOS DE INTERFAZ DE USUARIO =====

        /// <summary>
        /// Muestra mensaje de validación y enfoca el control correspondiente
        /// </summary>
        private void MostrarMensajeValidacion(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control?.Focus();
        }

        /// <summary>
        /// Muestra mensaje de éxito
        /// </summary>
        private void MostrarMensajeExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Maneja errores de manera centralizada
        /// </summary>
        private void ManejarError(Exception ex)
        {
            string mensajeError = ex is FormatException || ex is InvalidOperationException
                ? ex.Message
                : $"Error inesperado: {ex.Message}";

            MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Procesa la recepción de uno o múltiples productos seleccionados
        /// Cambia el status a 4, requiere que tengan transportista asignado
        /// En selección única: permite modificar precio
        /// En selección múltiple: mantiene precios originales
        /// </summary>
        private void ProcesarRecepcionProductos()
        {
            try
            {
                // ===== VALIDACIÓN INICIAL DE SELECCIÓN =====
                var resultadoValidacion = ValidarSeleccionInicial();
                if (!resultadoValidacion.EsValido)
                {
                    MostrarMensajeValidacion(resultadoValidacion.Mensaje, resultadoValidacion.Control);
                    return;
                }

                // ===== DETERMINACIÓN DEL TIPO DE OPERACIÓN =====
                var itemsSeleccionados = ListViewArticulos.SelectedItems.Cast<ListViewItem>().ToList();
                bool esSeleccionUnica = itemsSeleccionados.Count == 1;

                // ===== VALIDACIÓN DE CONFLICTO PRECIO/SELECCIÓN MÚLTIPLE =====
                var validacionConflicto = ValidarConflictoPrecioSeleccionMultiple(esSeleccionUnica);
                if (!validacionConflicto.EsValido)
                {
                    MostrarMensajeValidacion(validacionConflicto.Mensaje, validacionConflicto.Control);
                    return;
                }

                // ===== VALIDACIÓN ESPECÍFICA: TRANSPORTISTA ASIGNADO =====
                var validacionTransportista = ValidarTransportistaAsignado(itemsSeleccionados);
                if (!validacionTransportista.EsValido)
                {
                    MostrarMensajeValidacion(validacionTransportista.Mensaje, validacionTransportista.Control);
                    return;
                }

                // ===== VALIDACIÓN DE CÓDIGO DE COMPRA =====
                var validacionCodigoCompra = ValidarCodigoCompraRequerido();
                if (!validacionCodigoCompra.EsValido)
                {
                    MostrarMensajeValidacion(validacionCodigoCompra.Mensaje, validacionCodigoCompra.Control);
                    return;
                }

                // ===== PROCESAMIENTO SEGÚN TIPO DE SELECCIÓN =====
                if (esSeleccionUnica)
                {
                    ProcesarRecepcionUnica(itemsSeleccionados[0], validacionCodigoCompra.CodigoCompra);
                }
                else
                {
                    ProcesarRecepcionMultiple(itemsSeleccionados, validacionCodigoCompra.CodigoCompra);
                }

                // ===== ACTUALIZACIÓN INMEDIATA DE LA INTERFAZ =====
                _todosLosProductos = _productoService.ObtenerProductosConDetalle();
                string[] codigosCompra = { validacionCodigoCompra.CodigoCompra };
                ActualizarListview(codigosCompra);
                ActualizarTextBoxArticulos();
                txtPrecioM.Clear();

                // ===== CONFIRMACIÓN AL USUARIO =====
                string mensajeExito = esSeleccionUnica
                    ? "Producto recibido correctamente (Status: 4)"
                    : $"{itemsSeleccionados.Count} productos recibidos correctamente (Status: 4)";

                MostrarMensajeExito(mensajeExito);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        // ===== VALIDACIONES ESPECÍFICAS PARA RECIBIR =====

        /// <summary>
        /// Valida que todos los productos seleccionados tengan transportista asignado
        /// </summary>
        private (bool EsValido, string Mensaje, Control Control) ValidarTransportistaAsignado(List<ListViewItem> itemsSeleccionados)
        {
            var productosSinTransportista = new List<string>();

            foreach (var item in itemsSeleccionados)
            {
                var productoInfo = ExtraerInformacionProducto(item);
                var producto = _todosLosProductos.FirstOrDefault(p => p.IdProducto == productoInfo.Id);

                if (producto == null)
                {
                    return (false, $"No se encontró el producto con ID {productoInfo.Id}", ListViewArticulos);
                }

                // Verificar que tenga transportista asignado
                if (string.IsNullOrWhiteSpace(producto.CodigoTransportista))
                {
                    productosSinTransportista.Add($"ID: {producto.IdProducto} - {producto.Producto}");
                }
            }

            if (productosSinTransportista.Any())
            {
                string mensaje = productosSinTransportista.Count == 1
                    ? $"El producto seleccionado no tiene transportista asignado:\n\n{productosSinTransportista[0]}\n\nDebe asignar un transportista antes de poder recibir el producto."
                    : $"Los siguientes productos no tienen transportista asignado:\n\n{string.Join("\n", productosSinTransportista.Take(5))}" +
                      (productosSinTransportista.Count > 5 ? $"\n... y {productosSinTransportista.Count - 5} más." : "") +
                      "\n\nDebe asignar transportista a todos los productos antes de poder recibirlos.";

                return (false, mensaje, ListViewArticulos);
            }

            return (true, string.Empty, null);
        }

        /// <summary>
        /// Valida que haya código de compra seleccionado
        /// </summary>
        private (bool EsValido, string Mensaje, Control Control, string CodigoCompra) ValidarCodigoCompraRequerido()
        {
            if (string.IsNullOrWhiteSpace(ComboBoxCodigoCompra.Text))
            {
                return (false, "El código de compra no debe estar vacío", ComboBoxCodigoCompra, string.Empty);
            }

            return (true, string.Empty, null, ComboBoxCodigoCompra.Text.Trim());
        }

        // ===== MÉTODOS DE PROCESAMIENTO PARA RECIBIR =====

        /// <summary>
        /// Procesa la recepción de un solo producto (permite modificar precio + status 4)
        /// </summary>
        private void ProcesarRecepcionUnica(ListViewItem item, string codigoCompra)
        {
            var productoInfo = ExtraerInformacionProducto(item);
            var producto = _todosLosProductos.FirstOrDefault(p => p.IdProducto == productoInfo.Id);

            // Determinar precio (modificado o original)
            decimal precioFinal = string.IsNullOrWhiteSpace(txtPrecioM.Text)
                ? productoInfo.PrecioOriginal
                : decimal.Parse(txtPrecioM.Text.Trim());

            // Actualizar en base de datos con status 4 usando el nuevo servicio
            _productoService.ActualizarProductoRecibido(
                productoInfo.Id,
                precioFinal,
                producto.CodigoTransportista
            );
        }

        /// <summary>
        /// Procesa la recepción de múltiples productos (status 4, mantiene precios originales)
        /// </summary>
        private void ProcesarRecepcionMultiple(List<ListViewItem> items, string codigoCompra)
        {
            foreach (var item in items)
            {
                var productoInfo = ExtraerInformacionProducto(item);
                var producto = _todosLosProductos.First(p => p.IdProducto == productoInfo.Id);

                // Actualizar con precio original y status 4 usando el nuevo servicio
                _productoService.ActualizarProductoRecibido(
                    productoInfo.Id,
                    producto.Precio, // Mantener precio original
                    producto.CodigoTransportista
                );
            }
        }

        // ===== CLASE DE DATOS AUXILIAR =====

        /// <summary>
        /// Encapsula los datos validados para el procesamiento
        /// </summary>
        private class DatosValidacion
        {
            public bool EsValido { get; set; }
            public string Mensaje { get; set; } = string.Empty;
            public Control Control { get; set; }
            public string CodigoTransportista { get; set; } = string.Empty;
            public string CodigoCompra { get; set; } = string.Empty;
            public decimal? PrecioModificado { get; set; }
        }

        #endregion

        #region Carga de Texbox
        private void ActualizarTextBoxArticulos()

        {
            List<ProductoDTO> productos = _todosLosProductos;

            // Reiniciar contadores
            cantidadArtSolicitados = 0;
            valorArtSolicitados = 0;
            cantidadArtEnTraslado = 0;
            valorArtEnTraslado = 0;
            cantidadArtEtiquetados = 0;
            valorArtEtiquetados = 0;

            // Calcular valores según el estado de cada producto
            foreach (ProductoDTO producto in productos)
            {
                switch (producto.Status) // Asumiendo que el estado está en una propiedad llamada "Estado"
                {
                    case "Solicitado": // Solicitado
                        cantidadArtSolicitados++;
                        valorArtSolicitados += producto.Precio; // Asumiendo que el precio está en una propiedad "Precio"
                        break;

                    case "Traslado en MX": // En traslado
                        cantidadArtEnTraslado++;
                        valorArtEnTraslado += producto.Precio;
                        break;

                    case "Etiquetado": // Etiquetado
                        cantidadArtEtiquetados++;
                        valorArtEtiquetados += producto.Precio;
                        break;
                }
            }
            AsignarValoresATextBoxes();
        }
        private void AsignarValoresATextBoxes()
        {
            // TextBoxes para artículos solicitados
            txtCantidadSolicitados.Text = cantidadArtSolicitados.ToString();
            txtValorSolicitados.Text = valorArtSolicitados.ToString("C2"); // Formato moneda

            // TextBoxes para artículos en traslado
            txtCantidadTraslado.Text = cantidadArtEnTraslado.ToString();
            txtValorTraslado.Text = valorArtEnTraslado.ToString("C2");

            // TextBoxes para artículos etiquetados
            txtCantidadEtiquetados.Text = cantidadArtEtiquetados.ToString();
            txtValorEtiquetados.Text = valorArtEtiquetados.ToString("C2");
        }

        


        // Asignar valores a los TextBox

    }
   
        #endregion
    }


