﻿namespace FutureLending
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelMenu = new Panel();
            btnReparar = new FontAwesome.Sharp.IconButton();
            btnTodosSistemas = new FontAwesome.Sharp.IconButton();
            btnEstadoPagos = new FontAwesome.Sharp.IconButton();
            btnListas = new FontAwesome.Sharp.IconButton();
            btnIngresarClientes = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            btnMenu = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            pnlClientes = new Panel();
            txtCorreo = new Controles_personalizados.TextBoxPersonalizado();
            label15 = new Label();
            txtTelefono = new Controles_personalizados.TextBoxPersonalizado();
            label14 = new Label();
            txtNumExt = new Controles_personalizados.TextBoxPersonalizado();
            label13 = new Label();
            txtNumInt = new Controles_personalizados.TextBoxPersonalizado();
            label12 = new Label();
            txtColonia = new Controles_personalizados.TextBoxPersonalizado();
            label11 = new Label();
            txtCalle = new Controles_personalizados.TextBoxPersonalizado();
            label10 = new Label();
            label9 = new Label();
            btnGuardar = new Controles_personalizados.RJButton();
            label7 = new Label();
            cmbPromotor = new ControlesPersonalizados.RJComboBox();
            label6 = new Label();
            cmbTipo = new ControlesPersonalizados.RJComboBox();
            label5 = new Label();
            txtInteres = new Controles_personalizados.TextBoxPersonalizado();
            label4 = new Label();
            dateFechaInicio = new Controles_personalizados.DateTimePickerPersonalizado();
            label3 = new Label();
            txtCredito = new Controles_personalizados.TextBoxPersonalizado();
            label2 = new Label();
            txtNombre = new Controles_personalizados.TextBoxPersonalizado();
            label1 = new Label();
            pnlListas = new Panel();
            btnEliminar = new Controles_personalizados.RJButton();
            btnEditar = new Controles_personalizados.RJButton();
            gridListas = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            btnLiquidados = new Controles_personalizados.RJButton();
            btnMostrarTodos = new Controles_personalizados.RJButton();
            label8 = new Label();
            btnLista3 = new Controles_personalizados.RJButton();
            rjButton1 = new Controles_personalizados.RJButton();
            btnLista1 = new Controles_personalizados.RJButton();
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            pnlClientes.SuspendLayout();
            pnlListas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridListas).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.AccessibleName = "panelMenu";
            panelMenu.BackColor = Color.DarkSlateGray;
            panelMenu.Controls.Add(btnReparar);
            panelMenu.Controls.Add(btnTodosSistemas);
            panelMenu.Controls.Add(btnEstadoPagos);
            panelMenu.Controls.Add(btnListas);
            panelMenu.Controls.Add(btnIngresarClientes);
            panelMenu.Controls.Add(panel1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(263, 723);
            panelMenu.TabIndex = 0;
            // 
            // btnReparar
            // 
            btnReparar.Dock = DockStyle.Bottom;
            btnReparar.FlatAppearance.BorderSize = 0;
            btnReparar.FlatStyle = FlatStyle.Flat;
            btnReparar.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnReparar.ForeColor = Color.White;
            btnReparar.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            btnReparar.IconColor = Color.White;
            btnReparar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReparar.ImageAlign = ContentAlignment.MiddleLeft;
            btnReparar.Location = new Point(0, 651);
            btnReparar.Margin = new Padding(3, 4, 3, 4);
            btnReparar.Name = "btnReparar";
            btnReparar.Padding = new Padding(11, 0, 0, 0);
            btnReparar.Size = new Size(263, 72);
            btnReparar.TabIndex = 4;
            btnReparar.Tag = "         Reparar";
            btnReparar.Text = "         Reparar";
            btnReparar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReparar.UseVisualStyleBackColor = true;
            // 
            // btnTodosSistemas
            // 
            btnTodosSistemas.Dock = DockStyle.Top;
            btnTodosSistemas.FlatAppearance.BorderSize = 0;
            btnTodosSistemas.FlatStyle = FlatStyle.Flat;
            btnTodosSistemas.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnTodosSistemas.ForeColor = Color.White;
            btnTodosSistemas.IconChar = FontAwesome.Sharp.IconChar.Computer;
            btnTodosSistemas.IconColor = Color.White;
            btnTodosSistemas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTodosSistemas.ImageAlign = ContentAlignment.MiddleLeft;
            btnTodosSistemas.Location = new Point(0, 423);
            btnTodosSistemas.Margin = new Padding(3, 4, 3, 4);
            btnTodosSistemas.Name = "btnTodosSistemas";
            btnTodosSistemas.Padding = new Padding(11, 0, 0, 0);
            btnTodosSistemas.Size = new Size(263, 72);
            btnTodosSistemas.TabIndex = 3;
            btnTodosSistemas.Tag = "Ver estado de todos los sistemas";
            btnTodosSistemas.Text = "Ver estado de todos los sistemas";
            btnTodosSistemas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTodosSistemas.UseVisualStyleBackColor = true;
            btnTodosSistemas.Click += btnTodosSistemas_Click;
            // 
            // btnEstadoPagos
            // 
            btnEstadoPagos.Dock = DockStyle.Top;
            btnEstadoPagos.FlatAppearance.BorderSize = 0;
            btnEstadoPagos.FlatStyle = FlatStyle.Flat;
            btnEstadoPagos.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEstadoPagos.ForeColor = Color.White;
            btnEstadoPagos.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt;
            btnEstadoPagos.IconColor = Color.White;
            btnEstadoPagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEstadoPagos.ImageAlign = ContentAlignment.MiddleLeft;
            btnEstadoPagos.Location = new Point(0, 351);
            btnEstadoPagos.Margin = new Padding(3, 4, 3, 4);
            btnEstadoPagos.Name = "btnEstadoPagos";
            btnEstadoPagos.Padding = new Padding(11, 0, 0, 0);
            btnEstadoPagos.Size = new Size(263, 72);
            btnEstadoPagos.TabIndex = 2;
            btnEstadoPagos.Tag = "  Estado de pagos";
            btnEstadoPagos.Text = "  Estado de pagos";
            btnEstadoPagos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEstadoPagos.UseVisualStyleBackColor = true;
            // 
            // btnListas
            // 
            btnListas.Dock = DockStyle.Top;
            btnListas.FlatAppearance.BorderSize = 0;
            btnListas.FlatStyle = FlatStyle.Flat;
            btnListas.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnListas.ForeColor = Color.White;
            btnListas.IconChar = FontAwesome.Sharp.IconChar.List12;
            btnListas.IconColor = Color.White;
            btnListas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnListas.ImageAlign = ContentAlignment.MiddleLeft;
            btnListas.Location = new Point(0, 279);
            btnListas.Margin = new Padding(3, 4, 3, 4);
            btnListas.Name = "btnListas";
            btnListas.Padding = new Padding(11, 0, 0, 0);
            btnListas.Size = new Size(263, 72);
            btnListas.TabIndex = 1;
            btnListas.Tag = "  Listas completas";
            btnListas.Text = "  Listas completas";
            btnListas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnListas.UseVisualStyleBackColor = true;
            btnListas.Click += btnListas_Click;
            // 
            // btnIngresarClientes
            // 
            btnIngresarClientes.Dock = DockStyle.Top;
            btnIngresarClientes.FlatAppearance.BorderSize = 0;
            btnIngresarClientes.FlatStyle = FlatStyle.Flat;
            btnIngresarClientes.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnIngresarClientes.ForeColor = Color.White;
            btnIngresarClientes.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            btnIngresarClientes.IconColor = Color.White;
            btnIngresarClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIngresarClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnIngresarClientes.Location = new Point(0, 207);
            btnIngresarClientes.Margin = new Padding(3, 4, 3, 4);
            btnIngresarClientes.Name = "btnIngresarClientes";
            btnIngresarClientes.Padding = new Padding(11, 0, 0, 0);
            btnIngresarClientes.Size = new Size(263, 72);
            btnIngresarClientes.TabIndex = 0;
            btnIngresarClientes.Tag = "   Ingresar clientes";
            btnIngresarClientes.Text = "   Ingresar clientes";
            btnIngresarClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIngresarClientes.UseVisualStyleBackColor = true;
            btnIngresarClientes.Click += btnIngresarClientes_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnMenu);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 207);
            panel1.TabIndex = 0;
            // 
            // btnMenu
            // 
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            btnMenu.IconColor = Color.White;
            btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMenu.IconSize = 30;
            btnMenu.Location = new Point(193, 68);
            btnMenu.Margin = new Padding(3, 4, 3, 4);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(69, 80);
            btnMenu.TabIndex = 0;
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 4);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(184, 195);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.DarkCyan;
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(263, 0);
            panelTitleBar.Margin = new Padding(3, 4, 3, 4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(979, 80);
            panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Georgia", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = SystemColors.Desktop;
            lblTitle.Location = new Point(41, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(299, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Bienvenido";
            // 
            // pnlClientes
            // 
            pnlClientes.BackColor = SystemColors.Info;
            pnlClientes.Controls.Add(txtCorreo);
            pnlClientes.Controls.Add(label15);
            pnlClientes.Controls.Add(txtTelefono);
            pnlClientes.Controls.Add(label14);
            pnlClientes.Controls.Add(txtNumExt);
            pnlClientes.Controls.Add(label13);
            pnlClientes.Controls.Add(txtNumInt);
            pnlClientes.Controls.Add(label12);
            pnlClientes.Controls.Add(txtColonia);
            pnlClientes.Controls.Add(label11);
            pnlClientes.Controls.Add(txtCalle);
            pnlClientes.Controls.Add(label10);
            pnlClientes.Controls.Add(label9);
            pnlClientes.Controls.Add(btnGuardar);
            pnlClientes.Controls.Add(label7);
            pnlClientes.Controls.Add(cmbPromotor);
            pnlClientes.Controls.Add(label6);
            pnlClientes.Controls.Add(cmbTipo);
            pnlClientes.Controls.Add(label5);
            pnlClientes.Controls.Add(txtInteres);
            pnlClientes.Controls.Add(label4);
            pnlClientes.Controls.Add(dateFechaInicio);
            pnlClientes.Controls.Add(label3);
            pnlClientes.Controls.Add(txtCredito);
            pnlClientes.Controls.Add(label2);
            pnlClientes.Controls.Add(txtNombre);
            pnlClientes.Controls.Add(label1);
            pnlClientes.Dock = DockStyle.Fill;
            pnlClientes.Location = new Point(0, 0);
            pnlClientes.Margin = new Padding(3, 4, 3, 4);
            pnlClientes.Name = "pnlClientes";
            pnlClientes.Size = new Size(1242, 723);
            pnlClientes.TabIndex = 2;
            // 
            // txtCorreo
            // 
            txtCorreo.BorderColor = Color.DarkSlateGray;
            txtCorreo.BorderFocusColor = SystemColors.Info;
            txtCorreo.BorderRadius = 0;
            txtCorreo.BorderSize = 2;
            txtCorreo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCorreo.Location = new Point(666, 504);
            txtCorreo.Margin = new Padding(3, 4, 3, 4);
            txtCorreo.Multiline = false;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Padding = new Padding(11, 9, 11, 9);
            txtCorreo.PasswordChar = false;
            txtCorreo.PlaceholderColor = Color.DimGray;
            txtCorreo.PlaceholderText = "Introduzca el núm. de tel.";
            txtCorreo.Size = new Size(265, 48);
            txtCorreo.TabIndex = 26;
            txtCorreo.Texts = "";
            txtCorreo.UnderlinedStyle = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(666, 472);
            label15.Name = "label15";
            label15.Size = new Size(219, 29);
            label15.TabIndex = 25;
            label15.Text = "Correo electrónico:";
            // 
            // txtTelefono
            // 
            txtTelefono.BorderColor = Color.DarkSlateGray;
            txtTelefono.BorderFocusColor = SystemColors.Info;
            txtTelefono.BorderRadius = 0;
            txtTelefono.BorderSize = 2;
            txtTelefono.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.Location = new Point(669, 404);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Multiline = false;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Padding = new Padding(11, 9, 11, 9);
            txtTelefono.PasswordChar = false;
            txtTelefono.PlaceholderColor = Color.DimGray;
            txtTelefono.PlaceholderText = "Introduzca el núm. de tel.";
            txtTelefono.Size = new Size(265, 48);
            txtTelefono.TabIndex = 24;
            txtTelefono.Texts = "";
            txtTelefono.UnderlinedStyle = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(666, 372);
            label14.Name = "label14";
            label14.Size = new Size(116, 29);
            label14.TabIndex = 23;
            label14.Text = "Teléfono:";
            // 
            // txtNumExt
            // 
            txtNumExt.BorderColor = Color.DarkSlateGray;
            txtNumExt.BorderFocusColor = SystemColors.Info;
            txtNumExt.BorderRadius = 0;
            txtNumExt.BorderSize = 2;
            txtNumExt.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumExt.Location = new Point(823, 304);
            txtNumExt.Margin = new Padding(3, 4, 3, 4);
            txtNumExt.Multiline = false;
            txtNumExt.Name = "txtNumExt";
            txtNumExt.Padding = new Padding(11, 9, 11, 9);
            txtNumExt.PasswordChar = false;
            txtNumExt.PlaceholderColor = Color.DimGray;
            txtNumExt.PlaceholderText = "Num. ext.";
            txtNumExt.Size = new Size(115, 48);
            txtNumExt.TabIndex = 22;
            txtNumExt.Texts = "";
            txtNumExt.UnderlinedStyle = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(823, 272);
            label13.Name = "label13";
            label13.Size = new Size(119, 29);
            label13.TabIndex = 21;
            label13.Text = "Núm. ext.:";
            // 
            // txtNumInt
            // 
            txtNumInt.BorderColor = Color.DarkSlateGray;
            txtNumInt.BorderFocusColor = SystemColors.Info;
            txtNumInt.BorderRadius = 0;
            txtNumInt.BorderSize = 2;
            txtNumInt.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumInt.Location = new Point(666, 304);
            txtNumInt.Margin = new Padding(3, 4, 3, 4);
            txtNumInt.Multiline = false;
            txtNumInt.Name = "txtNumInt";
            txtNumInt.Padding = new Padding(11, 9, 11, 9);
            txtNumInt.PasswordChar = false;
            txtNumInt.PlaceholderColor = Color.DimGray;
            txtNumInt.PlaceholderText = "Num. int.";
            txtNumInt.Size = new Size(115, 48);
            txtNumInt.TabIndex = 20;
            txtNumInt.Texts = "";
            txtNumInt.UnderlinedStyle = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(669, 272);
            label12.Name = "label12";
            label12.Size = new Size(113, 29);
            label12.TabIndex = 19;
            label12.Text = "Núm. int.:";
            // 
            // txtColonia
            // 
            txtColonia.BorderColor = Color.DarkSlateGray;
            txtColonia.BorderFocusColor = SystemColors.Info;
            txtColonia.BorderRadius = 0;
            txtColonia.BorderSize = 2;
            txtColonia.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtColonia.Location = new Point(669, 204);
            txtColonia.Margin = new Padding(3, 4, 3, 4);
            txtColonia.Multiline = false;
            txtColonia.Name = "txtColonia";
            txtColonia.Padding = new Padding(11, 9, 11, 9);
            txtColonia.PasswordChar = false;
            txtColonia.PlaceholderColor = Color.DimGray;
            txtColonia.PlaceholderText = "Introduzca la colonia";
            txtColonia.Size = new Size(265, 48);
            txtColonia.TabIndex = 18;
            txtColonia.Texts = "";
            txtColonia.UnderlinedStyle = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(669, 172);
            label11.Name = "label11";
            label11.Size = new Size(102, 29);
            label11.TabIndex = 17;
            label11.Text = "Colonia:";
            // 
            // txtCalle
            // 
            txtCalle.BorderColor = Color.DarkSlateGray;
            txtCalle.BorderFocusColor = SystemColors.Info;
            txtCalle.BorderRadius = 0;
            txtCalle.BorderSize = 2;
            txtCalle.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCalle.Location = new Point(669, 104);
            txtCalle.Margin = new Padding(3, 4, 3, 4);
            txtCalle.Multiline = false;
            txtCalle.Name = "txtCalle";
            txtCalle.Padding = new Padding(11, 9, 11, 9);
            txtCalle.PasswordChar = false;
            txtCalle.PlaceholderColor = Color.DimGray;
            txtCalle.PlaceholderText = "Introduzca la calle";
            txtCalle.Size = new Size(265, 48);
            txtCalle.TabIndex = 16;
            txtCalle.Texts = "";
            txtCalle.UnderlinedStyle = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(669, 72);
            label10.Name = "label10";
            label10.Size = new Size(75, 29);
            label10.TabIndex = 15;
            label10.Text = "Calle:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(666, 28);
            label9.Name = "label9";
            label9.Size = new Size(121, 29);
            label9.TabIndex = 14;
            label9.Text = "Dirección:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Info;
            btnGuardar.BackgroundColor = SystemColors.Info;
            btnGuardar.BorderColor = Color.DarkSlateGray;
            btnGuardar.BorderRadius = 10;
            btnGuardar.BorderSize = 2;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(784, 573);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(171, 53);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextColor = Color.Black;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(18, 537);
            label7.Name = "label7";
            label7.Size = new Size(261, 29);
            label7.TabIndex = 12;
            label7.Text = "Monto total con interés:";
            // 
            // cmbPromotor
            // 
            cmbPromotor.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbPromotor.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbPromotor.BackColor = SystemColors.Info;
            cmbPromotor.BorderColor = Color.DarkSlateGray;
            cmbPromotor.BorderSize = 2;
            cmbPromotor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPromotor.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbPromotor.ForeColor = Color.Black;
            cmbPromotor.IconColor = Color.DarkSlateGray;
            cmbPromotor.Items.AddRange(new object[] { "Semanales", "Quincenales", "Mensuales" });
            cmbPromotor.ListBackColor = SystemColors.Info;
            cmbPromotor.ListTextColor = Color.DimGray;
            cmbPromotor.Location = new Point(207, 424);
            cmbPromotor.Margin = new Padding(3, 4, 3, 4);
            cmbPromotor.MinimumSize = new Size(229, 40);
            cmbPromotor.Name = "cmbPromotor";
            cmbPromotor.Padding = new Padding(2, 3, 2, 3);
            cmbPromotor.Size = new Size(330, 49);
            cmbPromotor.TabIndex = 11;
            cmbPromotor.Texts = "Seleccione al promotor";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(18, 435);
            label6.Name = "label6";
            label6.Size = new Size(119, 29);
            label6.TabIndex = 10;
            label6.Text = "Promotor:";
            // 
            // cmbTipo
            // 
            cmbTipo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTipo.BackColor = SystemColors.Info;
            cmbTipo.BorderColor = Color.DarkSlateGray;
            cmbTipo.BorderSize = 2;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTipo.ForeColor = Color.Black;
            cmbTipo.IconColor = Color.DarkSlateGray;
            cmbTipo.Items.AddRange(new object[] { "Semanales", "Quincenales", "Mensuales" });
            cmbTipo.ListBackColor = SystemColors.Info;
            cmbTipo.ListTextColor = Color.DimGray;
            cmbTipo.Location = new Point(207, 339);
            cmbTipo.Margin = new Padding(3, 4, 3, 4);
            cmbTipo.MinimumSize = new Size(229, 40);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Padding = new Padding(2, 3, 2, 3);
            cmbTipo.Size = new Size(330, 49);
            cmbTipo.TabIndex = 9;
            cmbTipo.Texts = "Seleccione un tipo de pago";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(18, 353);
            label5.Name = "label5";
            label5.Size = new Size(164, 29);
            label5.TabIndex = 8;
            label5.Text = "Tipo de pago:";
            // 
            // txtInteres
            // 
            txtInteres.BorderColor = Color.DarkSlateGray;
            txtInteres.BorderFocusColor = SystemColors.Info;
            txtInteres.BorderRadius = 0;
            txtInteres.BorderSize = 2;
            txtInteres.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtInteres.Location = new Point(209, 259);
            txtInteres.Margin = new Padding(3, 4, 3, 4);
            txtInteres.Multiline = false;
            txtInteres.Name = "txtInteres";
            txtInteres.Padding = new Padding(11, 9, 11, 9);
            txtInteres.PasswordChar = false;
            txtInteres.PlaceholderColor = Color.DimGray;
            txtInteres.PlaceholderText = "Introduzca la tasa de interés";
            txtInteres.Size = new Size(401, 48);
            txtInteres.TabIndex = 7;
            txtInteres.Texts = "";
            txtInteres.UnderlinedStyle = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(18, 272);
            label4.Name = "label4";
            label4.Size = new Size(92, 29);
            label4.TabIndex = 6;
            label4.Text = "Interés:";
            // 
            // dateFechaInicio
            // 
            dateFechaInicio.BorderColor = Color.DarkSlateGray;
            dateFechaInicio.BorderSize = 2;
            dateFechaInicio.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dateFechaInicio.Format = DateTimePickerFormat.Short;
            dateFechaInicio.Location = new Point(209, 180);
            dateFechaInicio.Margin = new Padding(3, 4, 3, 4);
            dateFechaInicio.MinimumSize = new Size(4, 35);
            dateFechaInicio.Name = "dateFechaInicio";
            dateFechaInicio.Size = new Size(327, 35);
            dateFechaInicio.SkinColor = SystemColors.Info;
            dateFechaInicio.TabIndex = 5;
            dateFechaInicio.TextColor = Color.Black;
            dateFechaInicio.ValueChanged += dateFechaInicio_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(18, 191);
            label3.Name = "label3";
            label3.Size = new Size(183, 29);
            label3.TabIndex = 4;
            label3.Text = "Fecha de inicio:";
            // 
            // txtCredito
            // 
            txtCredito.BorderColor = Color.DarkSlateGray;
            txtCredito.BorderFocusColor = SystemColors.Info;
            txtCredito.BorderRadius = 0;
            txtCredito.BorderSize = 2;
            txtCredito.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCredito.Location = new Point(209, 100);
            txtCredito.Margin = new Padding(3, 4, 3, 4);
            txtCredito.Multiline = false;
            txtCredito.Name = "txtCredito";
            txtCredito.Padding = new Padding(11, 9, 11, 9);
            txtCredito.PasswordChar = false;
            txtCredito.PlaceholderColor = Color.DimGray;
            txtCredito.PlaceholderText = "Introduzca monto total";
            txtCredito.Size = new Size(401, 48);
            txtCredito.TabIndex = 3;
            txtCredito.Texts = "";
            txtCredito.UnderlinedStyle = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(18, 109);
            label2.Name = "label2";
            label2.Size = new Size(199, 29);
            label2.TabIndex = 2;
            label2.Text = "Crédito prestado:";
            // 
            // txtNombre
            // 
            txtNombre.BorderColor = Color.DarkSlateGray;
            txtNombre.BorderFocusColor = SystemColors.Info;
            txtNombre.BorderRadius = 0;
            txtNombre.BorderSize = 2;
            txtNombre.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(209, 20);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Multiline = false;
            txtNombre.Name = "txtNombre";
            txtNombre.Padding = new Padding(11, 9, 11, 9);
            txtNombre.PasswordChar = false;
            txtNombre.PlaceholderColor = Color.DimGray;
            txtNombre.PlaceholderText = "Introduzca el nombre";
            txtNombre.Size = new Size(401, 48);
            txtNombre.TabIndex = 1;
            txtNombre.Texts = "";
            txtNombre.UnderlinedStyle = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 28);
            label1.Name = "label1";
            label1.Size = new Size(213, 29);
            label1.TabIndex = 0;
            label1.Text = "Nombre completo:";
            // 
            // pnlListas
            // 
            pnlListas.BackColor = SystemColors.Info;
            pnlListas.Controls.Add(btnEliminar);
            pnlListas.Controls.Add(btnEditar);
            pnlListas.Controls.Add(gridListas);
            pnlListas.Controls.Add(btnLiquidados);
            pnlListas.Controls.Add(btnMostrarTodos);
            pnlListas.Controls.Add(label8);
            pnlListas.Controls.Add(btnLista3);
            pnlListas.Controls.Add(rjButton1);
            pnlListas.Controls.Add(btnLista1);
            pnlListas.Dock = DockStyle.Fill;
            pnlListas.Location = new Point(263, 80);
            pnlListas.Margin = new Padding(3, 4, 3, 4);
            pnlListas.Name = "pnlListas";
            pnlListas.Size = new Size(979, 643);
            pnlListas.TabIndex = 14;
            pnlListas.Paint += pnlListas_Paint;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.SteelBlue;
            btnEliminar.BackgroundColor = Color.SteelBlue;
            btnEliminar.BorderColor = Color.SteelBlue;
            btnEliminar.BorderRadius = 15;
            btnEliminar.BorderSize = 2;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.Transparent;
            btnEliminar.Location = new Point(829, 560);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(127, 60);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "Eliminar\r\ncliente\r\n";
            btnEliminar.TextColor = Color.Transparent;
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Teal;
            btnEditar.BackgroundColor = Color.Teal;
            btnEditar.BorderColor = Color.Teal;
            btnEditar.BorderRadius = 15;
            btnEditar.BorderSize = 2;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.Transparent;
            btnEditar.Location = new Point(686, 560);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(127, 60);
            btnEditar.TabIndex = 18;
            btnEditar.Text = "Editar\r\ncliente\r\n";
            btnEditar.TextColor = Color.Transparent;
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // gridListas
            // 
            gridListas.AllowUserToAddRows = false;
            gridListas.AllowUserToDeleteRows = false;
            gridListas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridListas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridListas.BackgroundColor = Color.DarkCyan;
            gridListas.BorderStyle = BorderStyle.None;
            gridListas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridListas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.Info;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridListas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridListas.ColumnHeadersHeight = 30;
            gridListas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridListas.Columns.AddRange(new DataGridViewColumn[] { ID });
            gridListas.EnableHeadersVisualStyles = false;
            gridListas.GridColor = Color.CadetBlue;
            gridListas.Location = new Point(18, 156);
            gridListas.Margin = new Padding(3, 4, 3, 4);
            gridListas.Name = "gridListas";
            gridListas.RowHeadersVisible = false;
            gridListas.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = Color.DarkCyan;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = Color.CadetBlue;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Info;
            gridListas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            gridListas.RowTemplate.Height = 25;
            gridListas.SelectionMode = DataGridViewSelectionMode.CellSelect;
            gridListas.Size = new Size(937, 396);
            gridListas.TabIndex = 16;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 60;
            // 
            // btnLiquidados
            // 
            btnLiquidados.BackColor = Color.Teal;
            btnLiquidados.BackgroundColor = Color.Teal;
            btnLiquidados.BorderColor = Color.Teal;
            btnLiquidados.BorderRadius = 15;
            btnLiquidados.BorderSize = 2;
            btnLiquidados.FlatAppearance.BorderSize = 0;
            btnLiquidados.FlatStyle = FlatStyle.Flat;
            btnLiquidados.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLiquidados.ForeColor = Color.Transparent;
            btnLiquidados.Location = new Point(829, 77);
            btnLiquidados.Margin = new Padding(3, 4, 3, 4);
            btnLiquidados.Name = "btnLiquidados";
            btnLiquidados.Size = new Size(127, 60);
            btnLiquidados.TabIndex = 15;
            btnLiquidados.Text = "Clientes\r\nliquidados";
            btnLiquidados.TextColor = Color.Transparent;
            btnLiquidados.UseVisualStyleBackColor = false;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.BackColor = Color.DarkSlateGray;
            btnMostrarTodos.BackgroundColor = Color.DarkSlateGray;
            btnMostrarTodos.BorderColor = Color.DarkSlateGray;
            btnMostrarTodos.BorderRadius = 15;
            btnMostrarTodos.BorderSize = 2;
            btnMostrarTodos.FlatAppearance.BorderSize = 0;
            btnMostrarTodos.FlatStyle = FlatStyle.Flat;
            btnMostrarTodos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMostrarTodos.ForeColor = Color.Transparent;
            btnMostrarTodos.Location = new Point(686, 76);
            btnMostrarTodos.Margin = new Padding(3, 4, 3, 4);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(127, 60);
            btnMostrarTodos.TabIndex = 14;
            btnMostrarTodos.Text = "Mostrar\r\ntodos";
            btnMostrarTodos.TextColor = Color.Transparent;
            btnMostrarTodos.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(338, 29);
            label8.Name = "label8";
            label8.Size = new Size(214, 29);
            label8.TabIndex = 13;
            label8.Text = "Seleccione la lista:";
            // 
            // btnLista3
            // 
            btnLista3.BackColor = Color.SteelBlue;
            btnLista3.BackgroundColor = Color.SteelBlue;
            btnLista3.BorderColor = Color.SteelBlue;
            btnLista3.BorderRadius = 15;
            btnLista3.BorderSize = 2;
            btnLista3.FlatAppearance.BorderSize = 0;
            btnLista3.FlatStyle = FlatStyle.Flat;
            btnLista3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLista3.ForeColor = Color.Transparent;
            btnLista3.Location = new Point(818, 13);
            btnLista3.Margin = new Padding(3, 4, 3, 4);
            btnLista3.Name = "btnLista3";
            btnLista3.Size = new Size(145, 60);
            btnLista3.TabIndex = 2;
            btnLista3.Text = "Lista 3:\r\nDemanda legal";
            btnLista3.TextColor = Color.Transparent;
            btnLista3.UseVisualStyleBackColor = false;
            btnLista3.Click += rjButton2_Click;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.Teal;
            rjButton1.BackgroundColor = Color.Teal;
            rjButton1.BorderColor = Color.Teal;
            rjButton1.BorderRadius = 15;
            rjButton1.BorderSize = 2;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.Transparent;
            rjButton1.Location = new Point(685, 13);
            rjButton1.Margin = new Padding(3, 4, 3, 4);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(127, 60);
            rjButton1.TabIndex = 1;
            rjButton1.Text = "Lista 2:\r\nExtrajudicial";
            rjButton1.TextColor = Color.Transparent;
            rjButton1.UseVisualStyleBackColor = false;
            // 
            // btnLista1
            // 
            btnLista1.BackColor = Color.DarkSlateGray;
            btnLista1.BackgroundColor = Color.DarkSlateGray;
            btnLista1.BorderColor = Color.DarkSlateGray;
            btnLista1.BorderRadius = 15;
            btnLista1.BorderSize = 2;
            btnLista1.FlatAppearance.BorderSize = 0;
            btnLista1.FlatStyle = FlatStyle.Flat;
            btnLista1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLista1.ForeColor = Color.Transparent;
            btnLista1.Location = new Point(551, 13);
            btnLista1.Margin = new Padding(3, 4, 3, 4);
            btnLista1.Name = "btnLista1";
            btnLista1.Size = new Size(127, 60);
            btnLista1.TabIndex = 0;
            btnLista1.Text = "Lista 1:\r\nIniciación";
            btnLista1.TextColor = Color.Transparent;
            btnLista1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 723);
            Controls.Add(pnlListas);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Controls.Add(pnlClientes);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "FutureLending";
            Load += Form1_Load;
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            pnlClientes.ResumeLayout(false);
            pnlClientes.PerformLayout();
            pnlListas.ResumeLayout(false);
            pnlListas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridListas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelTitleBar;
        private Panel pnlClientes;
        private Panel panel1;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnMenu;
        private FontAwesome.Sharp.IconButton btnIngresarClientes;
        private FontAwesome.Sharp.IconButton btnListas;
        private FontAwesome.Sharp.IconButton btnEstadoPagos;
        private FontAwesome.Sharp.IconButton btnTodosSistemas;
        private FontAwesome.Sharp.IconButton btnReparar;
        private Label lblTitle;
        private Label label1;
        private Controles_personalizados.TextBoxPersonalizado txtNombre;
        private Controles_personalizados.TextBoxPersonalizado txtCredito;
        private Label label2;
        private Label label3;
        private Controles_personalizados.DateTimePickerPersonalizado dateFechaInicio;
        private Controles_personalizados.TextBoxPersonalizado txtInteres;
        private Label label4;
        private ControlesPersonalizados.RJComboBox cmbTipo;
        private Label label5;
        private ControlesPersonalizados.RJComboBox cmbPromotor;
        private Label label6;
        private Label label7;
        private Controles_personalizados.RJButton btnGuardar;
        private Panel pnlListas;
        private Controles_personalizados.RJButton btnLista1;
        private Controles_personalizados.RJButton btnLista3;
        private Controles_personalizados.RJButton rjButton1;
        private Label label8;
        private Controles_personalizados.RJButton btnLiquidados;
        private Controles_personalizados.RJButton btnMostrarTodos;
        private DataGridView gridListas;
        private DataGridViewTextBoxColumn ID;
        private Controles_personalizados.TextBoxPersonalizado txtNumExt;
        private Label label13;
        private Controles_personalizados.TextBoxPersonalizado txtNumInt;
        private Label label12;
        private Controles_personalizados.TextBoxPersonalizado txtColonia;
        private Label label11;
        private Controles_personalizados.TextBoxPersonalizado txtCalle;
        private Label label10;
        private Label label9;
        private Controles_personalizados.TextBoxPersonalizado txtCorreo;
        private Label label15;
        private Controles_personalizados.TextBoxPersonalizado txtTelefono;
        private Label label14;
        private Controles_personalizados.RJButton btnEliminar;
        private Controles_personalizados.RJButton btnEditar;
    }
}