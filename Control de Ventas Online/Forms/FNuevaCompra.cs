using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using BLL.Servicios;

namespace Control_de_Ventas_Online
{
    public class FNuevaCompra : Form
    {
        private Panel panelDatosCompra;
        private Panel panelLblDatosCompra;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label6;
        private TextBox txtPorcientoVenta;
        private Label label5;
        private TextBox txtAnticipo;
        private Label lblprecio;
        private TextBox txtPrecio;
        private Label label4;
        private DateTimePicker dtFechaCompra;
        private Label label3;
        private ComboBox cmbCliente;
        private ComboBox cmbPlataforma;
        private Button btnNuevaVenta;
        private Label label7;
        private Label lblCodigoCompra;
        private Panel panel2;
        private Panel panel3;
        private Label label8;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel3;
        private DateTimePicker dtFechaEF;
        private DateTimePicker dtFechaEI;
        private Label label14;
        private ComboBox cmbCategoría;
        private Label label13;
        private Button btnBuscarImgProducto;
        private TextBox txtrutaImgProducto;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox txtCodigoProducto;
        private Label label12;
        private TextBox txtPrecioArticulo;
        private Label label11;
        private TextBox txtCantidad;
        private Label label10;
        private TextBox txtDescArticulo;
        private Label label9;
        private SplitContainer splitContainer1;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel5;
        private Button btnFinalizarPedido;
        private Button btnNuevoArticulo;
        private TableLayoutPanel tableLayoutPanel4;
        private PictureBox imgProducto;
        private Panel panel6;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox txttotalPedidoMx;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox7;
        private Button btnEliminarArticulo;
        private Button btnModificarArticulo;
        private ListView lbArticulos;
        private Panel panelPrincipal;
        private PlataformaBLL plataforma = new PlataformaBLL();
        private ClienteBLL cliente = new ClienteBLL();
        private readonly CompraService _compraService;
        private readonly ClienteService _clienteService;
        public FNuevaCompra(CompraService compraService, ClienteService clienteService)
        {
            InitializeComponent();
            ConfigurarListView();
            CargarNombreCliente_cmbCliente();
            CargarPlataforma_cmbPlataforma();
            _compraService = compraService;
            _clienteService = clienteService;
        }

        private void InitializeComponent()
        {
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelDatosCompra = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lbArticulos = new System.Windows.Forms.ListView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txttotalPedidoMx = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEliminarArticulo = new System.Windows.Forms.Button();
            this.btnModificarArticulo = new System.Windows.Forms.Button();
            this.btnFinalizarPedido = new System.Windows.Forms.Button();
            this.btnNuevoArticulo = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.imgProducto = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtFechaEF = new System.Windows.Forms.DateTimePicker();
            this.dtFechaEI = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbCategoría = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnBuscarImgProducto = new System.Windows.Forms.Button();
            this.txtrutaImgProducto = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPrecioArticulo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescArticulo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCodigoCompra = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPlataforma = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPorcientoVenta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAnticipo = new System.Windows.Forms.TextBox();
            this.lblprecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.panelLblDatosCompra = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPrincipal.SuspendLayout();
            this.panelDatosCompra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProducto)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelLblDatosCompra.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrincipal.Controls.Add(this.panelDatosCompra);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1284, 852);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panelDatosCompra
            // 
            this.panelDatosCompra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDatosCompra.Controls.Add(this.splitContainer1);
            this.panelDatosCompra.Controls.Add(this.panel2);
            this.panelDatosCompra.Controls.Add(this.panel1);
            this.panelDatosCompra.Controls.Add(this.panelLblDatosCompra);
            this.panelDatosCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatosCompra.Location = new System.Drawing.Point(0, 0);
            this.panelDatosCompra.Name = "panelDatosCompra";
            this.panelDatosCompra.Size = new System.Drawing.Size(1284, 852);
            this.panelDatosCompra.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 284);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbArticulos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 564);
            this.splitContainer1.SplitterDistance = 747;
            this.splitContainer1.TabIndex = 3;
            // 
            // lbArticulos
            // 
            this.lbArticulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArticulos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbArticulos.GridLines = true;
            this.lbArticulos.HideSelection = false;
            this.lbArticulos.Location = new System.Drawing.Point(0, 0);
            this.lbArticulos.Name = "lbArticulos";
            this.lbArticulos.Size = new System.Drawing.Size(747, 564);
            this.lbArticulos.TabIndex = 0;
            this.lbArticulos.UseCompatibleStateImageBehavior = false;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.tableLayoutPanel6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 319);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3);
            this.panel6.Size = new System.Drawing.Size(529, 245);
            this.panel6.TabIndex = 5;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.Controls.Add(this.textBox7, 1, 6);
            this.tableLayoutPanel6.Controls.Add(this.textBox6, 0, 6);
            this.tableLayoutPanel6.Controls.Add(this.textBox5, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.textBox4, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.textBox3, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.textBox2, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.txttotalPedidoMx, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel6.RowCount = 8;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.86547F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.386193F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.68355F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.386193F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.04738F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.386193F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.906334F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.33869F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(519, 184);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox7.Location = new System.Drawing.Point(237, 136);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox7.Size = new System.Drawing.Size(70, 30);
            this.textBox7.TabIndex = 18;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBox6.Location = new System.Drawing.Point(8, 136);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(223, 30);
            this.textBox6.TabIndex = 17;
            this.textBox6.Text = "Ganancia Bruta por Pedido";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox5.Location = new System.Drawing.Point(237, 93);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox5.Size = new System.Drawing.Size(70, 30);
            this.textBox5.TabIndex = 16;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBox4.Location = new System.Drawing.Point(8, 93);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(223, 30);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "Inversion USD";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox3.Location = new System.Drawing.Point(237, 51);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox3.Size = new System.Drawing.Size(70, 30);
            this.textBox3.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBox2.Location = new System.Drawing.Point(8, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(223, 30);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Tasa de descuento por Cambio";
            // 
            // txttotalPedidoMx
            // 
            this.txttotalPedidoMx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalPedidoMx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txttotalPedidoMx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalPedidoMx.ForeColor = System.Drawing.Color.DarkRed;
            this.txttotalPedidoMx.Location = new System.Drawing.Point(237, 9);
            this.txttotalPedidoMx.Name = "txttotalPedidoMx";
            this.txttotalPedidoMx.ReadOnly = true;
            this.txttotalPedidoMx.Size = new System.Drawing.Size(70, 30);
            this.txttotalPedidoMx.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textBox1.Location = new System.Drawing.Point(8, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(223, 30);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Total de Pedido en MX";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.tableLayoutPanel5);
            this.panel5.Controls.Add(this.tableLayoutPanel4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(529, 319);
            this.panel5.TabIndex = 4;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Controls.Add(this.btnEliminarArticulo, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnModificarArticulo, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnFinalizarPedido, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnNuevoArticulo, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 270);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(519, 40);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.AutoSize = true;
            this.btnEliminarArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEliminarArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArticulo.Location = new System.Drawing.Point(259, 1);
            this.btnEliminarArticulo.Margin = new System.Windows.Forms.Padding(1);
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEliminarArticulo.Size = new System.Drawing.Size(127, 38);
            this.btnEliminarArticulo.TabIndex = 19;
            this.btnEliminarArticulo.Text = "Eliminar Articulo";
            this.btnEliminarArticulo.UseVisualStyleBackColor = true;
            // 
            // btnModificarArticulo
            // 
            this.btnModificarArticulo.AutoSize = true;
            this.btnModificarArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnModificarArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarArticulo.Location = new System.Drawing.Point(130, 1);
            this.btnModificarArticulo.Margin = new System.Windows.Forms.Padding(1);
            this.btnModificarArticulo.Name = "btnModificarArticulo";
            this.btnModificarArticulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnModificarArticulo.Size = new System.Drawing.Size(127, 38);
            this.btnModificarArticulo.TabIndex = 18;
            this.btnModificarArticulo.Text = "Modificar Articulo";
            this.btnModificarArticulo.UseVisualStyleBackColor = true;
            // 
            // btnFinalizarPedido
            // 
            this.btnFinalizarPedido.AutoSize = true;
            this.btnFinalizarPedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFinalizarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarPedido.Location = new System.Drawing.Point(388, 1);
            this.btnFinalizarPedido.Margin = new System.Windows.Forms.Padding(1);
            this.btnFinalizarPedido.Name = "btnFinalizarPedido";
            this.btnFinalizarPedido.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnFinalizarPedido.Size = new System.Drawing.Size(130, 38);
            this.btnFinalizarPedido.TabIndex = 17;
            this.btnFinalizarPedido.Text = "Finalizar Pedido";
            this.btnFinalizarPedido.UseVisualStyleBackColor = true;
            // 
            // btnNuevoArticulo
            // 
            this.btnNuevoArticulo.AutoSize = true;
            this.btnNuevoArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNuevoArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoArticulo.Location = new System.Drawing.Point(1, 1);
            this.btnNuevoArticulo.Margin = new System.Windows.Forms.Padding(1);
            this.btnNuevoArticulo.Name = "btnNuevoArticulo";
            this.btnNuevoArticulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNuevoArticulo.Size = new System.Drawing.Size(127, 38);
            this.btnNuevoArticulo.TabIndex = 16;
            this.btnNuevoArticulo.Text = "Nuevo Articulo";
            this.btnNuevoArticulo.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.imgProducto, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(519, 267);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // imgProducto
            // 
            this.imgProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgProducto.Location = new System.Drawing.Point(3, 3);
            this.imgProducto.Name = "imgProducto";
            this.imgProducto.Size = new System.Drawing.Size(513, 261);
            this.imgProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgProducto.TabIndex = 0;
            this.imgProducto.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1280, 142);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.tableLayoutPanel3);
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1276, 100);
            this.panel4.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.33238F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.73639F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.808023F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.40401F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.52149F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.598854F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.527221F));
            this.tableLayoutPanel3.Controls.Add(this.dtFechaEF, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtFechaEI, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label14, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbCategoría, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBuscarImgProducto, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtrutaImgProducto, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1272, 43);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dtFechaEF
            // 
            this.dtFechaEF.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaEF.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dtFechaEF.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaEF.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaEF.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaEF.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaEF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFechaEF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaEF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEF.Location = new System.Drawing.Point(1147, 6);
            this.dtFechaEF.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtFechaEF.Name = "dtFechaEF";
            this.dtFechaEF.Size = new System.Drawing.Size(119, 30);
            this.dtFechaEF.TabIndex = 21;
            // 
            // dtFechaEI
            // 
            this.dtFechaEI.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaEI.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dtFechaEI.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaEI.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaEI.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaEI.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFechaEI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaEI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEI.Location = new System.Drawing.Point(1026, 6);
            this.dtFechaEI.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtFechaEI.Name = "dtFechaEI";
            this.dtFechaEI.Size = new System.Drawing.Size(115, 30);
            this.dtFechaEI.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(931, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 31);
            this.label14.TabIndex = 19;
            this.label14.Text = "FechaEE";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCategoría
            // 
            this.cmbCategoría.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbCategoría.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategoría.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoría.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbCategoría.FormattingEnabled = true;
            this.cmbCategoría.Location = new System.Drawing.Point(724, 6);
            this.cmbCategoría.Name = "cmbCategoría";
            this.cmbCategoría.Size = new System.Drawing.Size(201, 33);
            this.cmbCategoría.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(626, 6);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 31);
            this.label13.TabIndex = 17;
            this.label13.Text = "Categoría";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBuscarImgProducto
            // 
            this.btnBuscarImgProducto.AutoSize = true;
            this.btnBuscarImgProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscarImgProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarImgProducto.Location = new System.Drawing.Point(4, 4);
            this.btnBuscarImgProducto.Margin = new System.Windows.Forms.Padding(1);
            this.btnBuscarImgProducto.Name = "btnBuscarImgProducto";
            this.btnBuscarImgProducto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscarImgProducto.Size = new System.Drawing.Size(204, 35);
            this.btnBuscarImgProducto.TabIndex = 16;
            this.btnBuscarImgProducto.Text = "Imagen de Producto";
            this.btnBuscarImgProducto.UseVisualStyleBackColor = true;
            this.btnBuscarImgProducto.Click += new System.EventHandler(this.btnBuscarImgProducto_Click);
            // 
            // txtrutaImgProducto
            // 
            this.txtrutaImgProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtrutaImgProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtrutaImgProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrutaImgProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtrutaImgProducto.Location = new System.Drawing.Point(212, 6);
            this.txtrutaImgProducto.Name = "txtrutaImgProducto";
            this.txtrutaImgProducto.Size = new System.Drawing.Size(408, 30);
            this.txtrutaImgProducto.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.2724F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.90323F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.02509F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.451613F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.663083F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.953405F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.451613F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.27957F));
            this.tableLayoutPanel2.Controls.Add(this.txtCodigoProducto, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPrecioArticulo, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCantidad, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtDescArticulo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1272, 43);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCodigoProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtCodigoProducto.Location = new System.Drawing.Point(1037, 6);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(229, 30);
            this.txtCodigoProducto.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(956, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(3);
            this.label12.Size = new System.Drawing.Size(70, 31);
            this.label12.TabIndex = 13;
            this.label12.Text = "Código";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrecioArticulo
            // 
            this.txtPrecioArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPrecioArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrecioArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtPrecioArticulo.Location = new System.Drawing.Point(868, 6);
            this.txtPrecioArticulo.Name = "txtPrecioArticulo";
            this.txtPrecioArticulo.Size = new System.Drawing.Size(82, 30);
            this.txtPrecioArticulo.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(797, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(3);
            this.label11.Size = new System.Drawing.Size(62, 31);
            this.label11.TabIndex = 11;
            this.label11.Text = "Precio";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtCantidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtCantidad.Location = new System.Drawing.Point(716, 6);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(75, 30);
            this.txtCantidad.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(628, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 31);
            this.label10.TabIndex = 9;
            this.label10.Text = "Cantidad";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescArticulo
            // 
            this.txtDescArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDescArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtDescArticulo.Location = new System.Drawing.Point(212, 6);
            this.txtDescArticulo.Name = "txtDescArticulo";
            this.txtDescArticulo.Size = new System.Drawing.Size(410, 30);
            this.txtDescArticulo.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(3);
            this.label9.Size = new System.Drawing.Size(200, 31);
            this.label9.TabIndex = 3;
            this.label9.Text = "Descripción de Artículo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1276, 36);
            this.panel3.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(3);
            this.label8.Size = new System.Drawing.Size(244, 35);
            this.label8.TabIndex = 0;
            this.label8.Text = "Detalles de Producto";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 111);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.165354F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.07087F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.984252F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.44349F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.850394F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.669291F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.322834F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.19685F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.212599F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.96063F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.370079F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.64567F));
            this.tableLayoutPanel1.Controls.Add(this.lblCodigoCompra, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbPlataforma, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPorcientoVenta, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAnticipo, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblprecio, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPrecio, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtFechaCompra, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCliente, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNuevaVenta, 11, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1276, 86);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // lblCodigoCompra
            // 
            this.lblCodigoCompra.AutoSize = true;
            this.lblCodigoCompra.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCodigoCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoCompra.Location = new System.Drawing.Point(98, 49);
            this.lblCodigoCompra.Margin = new System.Windows.Forms.Padding(4);
            this.lblCodigoCompra.Name = "lblCodigoCompra";
            this.lblCodigoCompra.Padding = new System.Windows.Forms.Padding(3);
            this.lblCodigoCompra.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCodigoCompra.Size = new System.Drawing.Size(6, 30);
            this.lblCodigoCompra.TabIndex = 17;
            this.lblCodigoCompra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(3);
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(81, 30);
            this.label7.TabIndex = 16;
            this.label7.Text = "Código";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPlataforma
            // 
            this.cmbPlataforma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbPlataforma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPlataforma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlataforma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbPlataforma.FormattingEnabled = true;
            this.cmbPlataforma.Location = new System.Drawing.Point(1088, 6);
            this.cmbPlataforma.Name = "cmbPlataforma";
            this.cmbPlataforma.Size = new System.Drawing.Size(182, 33);
            this.cmbPlataforma.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(969, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3);
            this.label6.Size = new System.Drawing.Size(111, 36);
            this.label6.TabIndex = 13;
            this.label6.Text = "Plataforma";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPorcientoVenta
            // 
            this.txtPorcientoVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPorcientoVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPorcientoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcientoVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtPorcientoVenta.Location = new System.Drawing.Point(906, 6);
            this.txtPorcientoVenta.Name = "txtPorcientoVenta";
            this.txtPorcientoVenta.Size = new System.Drawing.Size(57, 30);
            this.txtPorcientoVenta.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(789, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 42);
            this.label5.TabIndex = 10;
            this.label5.Text = "% deVenta";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAnticipo
            // 
            this.txtAnticipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtAnticipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnticipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnticipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtAnticipo.Location = new System.Drawing.Point(723, 6);
            this.txtAnticipo.Name = "txtAnticipo";
            this.txtAnticipo.Size = new System.Drawing.Size(60, 30);
            this.txtAnticipo.TabIndex = 9;
            // 
            // lblprecio
            // 
            this.lblprecio.AutoSize = true;
            this.lblprecio.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblprecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprecio.Location = new System.Drawing.Point(630, 3);
            this.lblprecio.Name = "lblprecio";
            this.lblprecio.Size = new System.Drawing.Size(82, 42);
            this.lblprecio.TabIndex = 8;
            this.lblprecio.Text = "Anticipo";
            this.lblprecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPrecio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtPrecio.Location = new System.Drawing.Point(558, 6);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(66, 30);
            this.txtPrecio.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(471, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 36);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtFechaCompra
            // 
            this.dtFechaCompra.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaCompra.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dtFechaCompra.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaCompra.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaCompra.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaCompra.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dtFechaCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFechaCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaCompra.Location = new System.Drawing.Point(339, 6);
            this.dtFechaCompra.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtFechaCompra.Name = "dtFechaCompra";
            this.dtFechaCompra.Size = new System.Drawing.Size(126, 30);
            this.dtFechaCompra.TabIndex = 5;
            this.dtFechaCompra.Leave += new System.EventHandler(this.dtFechaCompra_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(263, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 36);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCliente
            // 
            this.cmbCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cmbCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(97, 6);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(160, 33);
            this.cmbCliente.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(79, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.AutoSize = true;
            this.btnNuevaVenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaVenta.Location = new System.Drawing.Point(1086, 46);
            this.btnNuevaVenta.Margin = new System.Windows.Forms.Padding(1);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnNuevaVenta.Size = new System.Drawing.Size(186, 36);
            this.btnNuevaVenta.TabIndex = 15;
            this.btnNuevaVenta.Text = "Nueva Venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            // 
            // panelLblDatosCompra
            // 
            this.panelLblDatosCompra.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelLblDatosCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLblDatosCompra.Controls.Add(this.label1);
            this.panelLblDatosCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLblDatosCompra.Location = new System.Drawing.Point(0, 0);
            this.panelLblDatosCompra.Name = "panelLblDatosCompra";
            this.panelLblDatosCompra.Size = new System.Drawing.Size(1280, 31);
            this.panelLblDatosCompra.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos de Compra";
            // 
            // FNuevaCompra
            // 
            this.ClientSize = new System.Drawing.Size(1284, 852);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FNuevaCompra";
            this.Text = "Nueva Compra";
            this.panelPrincipal.ResumeLayout(false);
            this.panelDatosCompra.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProducto)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelLblDatosCompra.ResumeLayout(false);
            this.panelLblDatosCompra.PerformLayout();
            this.ResumeLayout(false);

        }


        private void ConfigurarListView()
        {
            // Configurar propiedades básicas
            lbArticulos.View = View.Details;
            lbArticulos.FullRowSelect = true;
            lbArticulos.GridLines = true;

            // Agregar columnas
            lbArticulos.Columns.Add("ID", 0); // Columna oculta (ancho = 0)
            lbArticulos.Columns.Add("Descripción de Artículo", 350, HorizontalAlignment.Center); // Ancho personalizado
            lbArticulos.Columns.Add("Categoría", 150, HorizontalAlignment.Center);
            lbArticulos.Columns.Add("Código", 200, HorizontalAlignment.Center);
            lbArticulos.Columns.Add("Cantidad", 100, HorizontalAlignment.Center); // Alineación derecha
            lbArticulos.Columns.Add("Precio", 80, HorizontalAlignment.Center);
            lbArticulos.Columns.Add("Total", 100, HorizontalAlignment.Center);
        }
        private void CargarNombreCliente_cmbCliente()
        {
            try
            {
                // Obtener los datos de la base de datos a través de la capa BLL
                DataTable dt = cliente.ObtenerClientes();

                // Limpiar completamente las columnas y los elementos del ListView
                cmbCliente.Items.Clear();

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
                    cmbCliente.Items.Add(row["Nombre"]);
                }
                ;



            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de problemas
                MessageBox.Show("Error al cargar los clientes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarPlataforma_cmbPlataforma()
        {
            try
            {
                // Obtener los datos de la base de datos a través de la capa BLL
                DataTable dt = plataforma.ListarTodas();

                // Limpiar completamente las columnas y los elementos del ListView
                cmbPlataforma.Items.Clear();

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
                    cmbPlataforma.Items.Add(row["plataforma"]);
                }
                ;



            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de problemas
                MessageBox.Show("Error al cargar los clientes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerarCodigoCompra(int idCliente, DateTime fecha)
        {
            try
            {
                // Obtener nombre del cliente usando ClienteService
                string nombreCliente = _clienteService.ObtenerNombreCliente(idCliente);
                nombreCliente = nombreCliente.ToUpper();

                // Contar compras usando CompraService
                int numeroCompras = _compraService.ObtenerConteoCompras(idCliente, fecha) + 1;

                // Formatear fecha y generar el código
                string fechaSinSeparadores = fecha.ToString("MMdd");
                string codigoCompra = $"{nombreCliente}-{fechaSinSeparadores}-{numeroCompras}";

                return codigoCompra;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty; // Devolver un string vacío en caso de error
            }
        }

        private void btnBuscarImgProducto_Click(object sender, EventArgs e)
        {
            // Configura el cuadro de diálogo para seleccionar archivos
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleccionar imagen del producto", // Título del diálogo
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*", // Filtros de archivos
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) // Carpeta inicial
            };

            // Si el usuario selecciona un archivo y hace clic en "Abrir"
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaImagen = openFileDialog.FileName; // Obtiene la ruta completa del archivo

                // Muestra la ruta en el TextBox
                txtrutaImgProducto.Text = rutaImagen;

                // Carga la imagen en el PictureBox
                try
                {
                    imgProducto.Image = Image.FromFile(rutaImagen); // Carga la imagen
                    imgProducto.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen al PictureBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtFechaCompra_Leave(object sender, EventArgs e)
        {
            try
            {
                // Obtener nombre del cliente del ComboBox
                string nombreCliente = cmbCliente.SelectedItem.ToString();

                // Usar ClienteService para obtener el ID del cliente
                int idCliente = _clienteService.ObtenerIdPorNombre(nombreCliente);

                // Llamar al método GenerarCodigoCompra para generar el código
                DateTime fechaSeleccionada = dtFechaCompra.Value;
                string codigoCompra = GenerarCodigoCompra(idCliente, fechaSeleccionada);

                // Mostrar el código en el Label
                lblCodigoCompra.Text = codigoCompra;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    }
}
