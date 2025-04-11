namespace Control_de_Ventas_Online
{
    partial class FGestionCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNombreC = new System.Windows.Forms.TextBox();
            this.txtDireccionC = new System.Windows.Forms.TextBox();
            this.txtTelefonoC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelListViewContainer = new System.Windows.Forms.Panel();
            this.listViewClientes = new System.Windows.Forms.ListView();
            this.panelIzquierdo = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.panelPrincipal.SuspendLayout();
            this.panelListViewContainer.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombreC
            // 
            this.txtNombreC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtNombreC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtNombreC.Location = new System.Drawing.Point(120, 23);
            this.txtNombreC.Name = "txtNombreC";
            this.txtNombreC.Size = new System.Drawing.Size(160, 35);
            this.txtNombreC.TabIndex = 0;
            // 
            // txtDireccionC
            // 
            this.txtDireccionC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtDireccionC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccionC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtDireccionC.Location = new System.Drawing.Point(409, 23);
            this.txtDireccionC.Name = "txtDireccionC";
            this.txtDireccionC.Size = new System.Drawing.Size(171, 35);
            this.txtDireccionC.TabIndex = 1;
            // 
            // txtTelefonoC
            // 
            this.txtTelefonoC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTelefonoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefonoC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtTelefonoC.Location = new System.Drawing.Point(707, 23);
            this.txtTelefonoC.Name = "txtTelefonoC";
            this.txtTelefonoC.Size = new System.Drawing.Size(147, 35);
            this.txtTelefonoC.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(13, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(285, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Direccion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(591, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Teléfono";
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPrincipal.Controls.Add(this.panelListViewContainer);
            this.panelPrincipal.Controls.Add(this.panelIzquierdo);
            this.panelPrincipal.Controls.Add(this.panelSuperior);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(888, 319);
            this.panelPrincipal.TabIndex = 12;
            // 
            // panelListViewContainer
            // 
            this.panelListViewContainer.AutoSize = true;
            this.panelListViewContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelListViewContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelListViewContainer.Controls.Add(this.listViewClientes);
            this.panelListViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelListViewContainer.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelListViewContainer.Location = new System.Drawing.Point(0, 79);
            this.panelListViewContainer.Name = "panelListViewContainer";
            this.panelListViewContainer.Size = new System.Drawing.Size(705, 236);
            this.panelListViewContainer.TabIndex = 2;
            // 
            // listViewClientes
            // 
            this.listViewClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listViewClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewClientes.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewClientes.FullRowSelect = true;
            this.listViewClientes.GridLines = true;
            this.listViewClientes.HideSelection = false;
            this.listViewClientes.Location = new System.Drawing.Point(0, 0);
            this.listViewClientes.Name = "listViewClientes";
            this.listViewClientes.Size = new System.Drawing.Size(701, 232);
            this.listViewClientes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewClientes.TabIndex = 13;
            this.listViewClientes.UseCompatibleStateImageBehavior = false;
            this.listViewClientes.View = System.Windows.Forms.View.Details;
            this.listViewClientes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewClientes_ColumnClick);
            this.listViewClientes.SelectedIndexChanged += new System.EventHandler(this.listViewClientes_SelectedIndexChanged);
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelIzquierdo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelIzquierdo.Controls.Add(this.btnImprimir);
            this.panelIzquierdo.Controls.Add(this.btnEliminar);
            this.panelIzquierdo.Controls.Add(this.btnActualizar);
            this.panelIzquierdo.Controls.Add(this.btnAdicionar);
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelIzquierdo.Location = new System.Drawing.Point(705, 79);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(179, 236);
            this.panelIzquierdo.TabIndex = 1;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnImprimir.FlatAppearance.BorderSize = 6;
            this.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnImprimir.Location = new System.Drawing.Point(18, 145);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(138, 40);
            this.btnImprimir.TabIndex = 14;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnEliminar.FlatAppearance.BorderSize = 6;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnEliminar.Location = new System.Drawing.Point(18, 99);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(138, 40);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnActualizar.FlatAppearance.BorderSize = 6;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnActualizar.Location = new System.Drawing.Point(18, 52);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(138, 40);
            this.btnActualizar.TabIndex = 12;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAdicionar.FlatAppearance.BorderSize = 2;
            this.btnAdicionar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnAdicionar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnAdicionar.Location = new System.Drawing.Point(18, 6);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(138, 40);
            this.btnAdicionar.TabIndex = 11;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelSuperior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(884, 79);
            this.panelSuperior.TabIndex = 0;
            // 
            // FGestionCliente
            // 
            this.ClientSize = new System.Drawing.Size(888, 319);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTelefonoC);
            this.Controls.Add(this.txtDireccionC);
            this.Controls.Add(this.txtNombreC);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "FGestionCliente";
            this.Text = "Gestion de Cliente";
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.panelListViewContainer.ResumeLayout(false);
            this.panelIzquierdo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreC;
        private System.Windows.Forms.TextBox txtDireccionC;
        private System.Windows.Forms.TextBox txtTelefonoC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelListViewContainer;
        private System.Windows.Forms.Panel panelIzquierdo;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ListView listViewClientes;
    }
}