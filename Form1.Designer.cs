namespace FutureLending
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnReparar = new FontAwesome.Sharp.IconButton();
            this.btnTodosSistemas = new FontAwesome.Sharp.IconButton();
            this.btnEstadoPagos = new FontAwesome.Sharp.IconButton();
            this.btnListas = new FontAwesome.Sharp.IconButton();
            this.btnIngresarClientes = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.btnGuardar = new FutureLending.Controles_personalizados.RJButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPromotor = new FutureLending.ControlesPersonalizados.RJComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTipo = new FutureLending.ControlesPersonalizados.RJComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInteres = new FutureLending.Controles_personalizados.TextBoxPersonalizado();
            this.label4 = new System.Windows.Forms.Label();
            this.dateFechaInicio = new FutureLending.Controles_personalizados.DateTimePickerPersonalizado();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCredito = new FutureLending.Controles_personalizados.TextBoxPersonalizado();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new FutureLending.Controles_personalizados.TextBoxPersonalizado();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AccessibleName = "panelMenu";
            this.panelMenu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelMenu.Controls.Add(this.btnReparar);
            this.panelMenu.Controls.Add(this.btnTodosSistemas);
            this.panelMenu.Controls.Add(this.btnEstadoPagos);
            this.panelMenu.Controls.Add(this.btnListas);
            this.panelMenu.Controls.Add(this.btnIngresarClientes);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(230, 531);
            this.panelMenu.TabIndex = 0;
            // 
            // btnReparar
            // 
            this.btnReparar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReparar.FlatAppearance.BorderSize = 0;
            this.btnReparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReparar.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnReparar.ForeColor = System.Drawing.Color.White;
            this.btnReparar.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.btnReparar.IconColor = System.Drawing.Color.White;
            this.btnReparar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReparar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReparar.Location = new System.Drawing.Point(0, 477);
            this.btnReparar.Name = "btnReparar";
            this.btnReparar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReparar.Size = new System.Drawing.Size(230, 54);
            this.btnReparar.TabIndex = 4;
            this.btnReparar.Tag = "         Reparar";
            this.btnReparar.Text = "         Reparar";
            this.btnReparar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReparar.UseVisualStyleBackColor = true;
            // 
            // btnTodosSistemas
            // 
            this.btnTodosSistemas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTodosSistemas.FlatAppearance.BorderSize = 0;
            this.btnTodosSistemas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodosSistemas.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTodosSistemas.ForeColor = System.Drawing.Color.White;
            this.btnTodosSistemas.IconChar = FontAwesome.Sharp.IconChar.Computer;
            this.btnTodosSistemas.IconColor = System.Drawing.Color.White;
            this.btnTodosSistemas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTodosSistemas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTodosSistemas.Location = new System.Drawing.Point(0, 317);
            this.btnTodosSistemas.Name = "btnTodosSistemas";
            this.btnTodosSistemas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTodosSistemas.Size = new System.Drawing.Size(230, 54);
            this.btnTodosSistemas.TabIndex = 3;
            this.btnTodosSistemas.Tag = "Ver estado de todos los sistemas";
            this.btnTodosSistemas.Text = "Ver estado de todos los sistemas";
            this.btnTodosSistemas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTodosSistemas.UseVisualStyleBackColor = true;
            // 
            // btnEstadoPagos
            // 
            this.btnEstadoPagos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstadoPagos.FlatAppearance.BorderSize = 0;
            this.btnEstadoPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoPagos.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEstadoPagos.ForeColor = System.Drawing.Color.White;
            this.btnEstadoPagos.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt;
            this.btnEstadoPagos.IconColor = System.Drawing.Color.White;
            this.btnEstadoPagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEstadoPagos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadoPagos.Location = new System.Drawing.Point(0, 263);
            this.btnEstadoPagos.Name = "btnEstadoPagos";
            this.btnEstadoPagos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnEstadoPagos.Size = new System.Drawing.Size(230, 54);
            this.btnEstadoPagos.TabIndex = 2;
            this.btnEstadoPagos.Tag = "  Estado de pagos";
            this.btnEstadoPagos.Text = "  Estado de pagos";
            this.btnEstadoPagos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstadoPagos.UseVisualStyleBackColor = true;
            // 
            // btnListas
            // 
            this.btnListas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListas.FlatAppearance.BorderSize = 0;
            this.btnListas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListas.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnListas.ForeColor = System.Drawing.Color.White;
            this.btnListas.IconChar = FontAwesome.Sharp.IconChar.List12;
            this.btnListas.IconColor = System.Drawing.Color.White;
            this.btnListas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnListas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListas.Location = new System.Drawing.Point(0, 209);
            this.btnListas.Name = "btnListas";
            this.btnListas.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnListas.Size = new System.Drawing.Size(230, 54);
            this.btnListas.TabIndex = 1;
            this.btnListas.Tag = "  Listas completas";
            this.btnListas.Text = "  Listas completas";
            this.btnListas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnListas.UseVisualStyleBackColor = true;
            // 
            // btnIngresarClientes
            // 
            this.btnIngresarClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngresarClientes.FlatAppearance.BorderSize = 0;
            this.btnIngresarClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarClientes.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIngresarClientes.ForeColor = System.Drawing.Color.White;
            this.btnIngresarClientes.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.btnIngresarClientes.IconColor = System.Drawing.Color.White;
            this.btnIngresarClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIngresarClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresarClientes.Location = new System.Drawing.Point(0, 155);
            this.btnIngresarClientes.Name = "btnIngresarClientes";
            this.btnIngresarClientes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnIngresarClientes.Size = new System.Drawing.Size(230, 54);
            this.btnIngresarClientes.TabIndex = 0;
            this.btnIngresarClientes.Tag = "   Ingresar clientes";
            this.btnIngresarClientes.Text = "   Ingresar clientes";
            this.btnIngresarClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngresarClientes.UseVisualStyleBackColor = true;
            this.btnIngresarClientes.Click += new System.EventHandler(this.btnIngresarClientes_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 155);
            this.panel1.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.btnMenu.IconColor = System.Drawing.Color.White;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 30;
            this.btnMenu.Location = new System.Drawing.Point(169, 51);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(60, 60);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(230, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(594, 60);
            this.panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Georgia", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTitle.Location = new System.Drawing.Point(36, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(237, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bienvenido";
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.SystemColors.Info;
            this.panelDesktop.Controls.Add(this.btnGuardar);
            this.panelDesktop.Controls.Add(this.label7);
            this.panelDesktop.Controls.Add(this.cmbPromotor);
            this.panelDesktop.Controls.Add(this.label6);
            this.panelDesktop.Controls.Add(this.cmbTipo);
            this.panelDesktop.Controls.Add(this.label5);
            this.panelDesktop.Controls.Add(this.txtInteres);
            this.panelDesktop.Controls.Add(this.label4);
            this.panelDesktop.Controls.Add(this.dateFechaInicio);
            this.panelDesktop.Controls.Add(this.label3);
            this.panelDesktop.Controls.Add(this.txtCredito);
            this.panelDesktop.Controls.Add(this.label2);
            this.panelDesktop.Controls.Add(this.txtNombre);
            this.panelDesktop.Controls.Add(this.label1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(230, 60);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(594, 471);
            this.panelDesktop.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.Info;
            this.btnGuardar.BackgroundColor = System.Drawing.SystemColors.Info;
            this.btnGuardar.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnGuardar.BorderRadius = 10;
            this.btnGuardar.BorderSize = 2;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(408, 403);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 40);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextColor = System.Drawing.Color.Black;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(16, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "Monto total con interés:";
            // 
            // cmbPromotor
            // 
            this.cmbPromotor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPromotor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPromotor.BackColor = System.Drawing.SystemColors.Info;
            this.cmbPromotor.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.cmbPromotor.BorderSize = 2;
            this.cmbPromotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPromotor.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbPromotor.ForeColor = System.Drawing.Color.Black;
            this.cmbPromotor.IconColor = System.Drawing.Color.DarkSlateGray;
            this.cmbPromotor.Items.AddRange(new object[] {
            "Semanales",
            "Quincenales",
            "Mensuales"});
            this.cmbPromotor.ListBackColor = System.Drawing.SystemColors.Info;
            this.cmbPromotor.ListTextColor = System.Drawing.Color.DimGray;
            this.cmbPromotor.Location = new System.Drawing.Point(181, 318);
            this.cmbPromotor.MinimumSize = new System.Drawing.Size(200, 30);
            this.cmbPromotor.Name = "cmbPromotor";
            this.cmbPromotor.Padding = new System.Windows.Forms.Padding(2);
            this.cmbPromotor.Size = new System.Drawing.Size(289, 37);
            this.cmbPromotor.TabIndex = 11;
            this.cmbPromotor.Texts = "Seleccione al promotor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(16, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Promotor:";
            // 
            // cmbTipo
            // 
            this.cmbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipo.BackColor = System.Drawing.SystemColors.Info;
            this.cmbTipo.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.cmbTipo.BorderSize = 2;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbTipo.ForeColor = System.Drawing.Color.Black;
            this.cmbTipo.IconColor = System.Drawing.Color.DarkSlateGray;
            this.cmbTipo.Items.AddRange(new object[] {
            "Semanales",
            "Quincenales",
            "Mensuales"});
            this.cmbTipo.ListBackColor = System.Drawing.SystemColors.Info;
            this.cmbTipo.ListTextColor = System.Drawing.Color.DimGray;
            this.cmbTipo.Location = new System.Drawing.Point(181, 254);
            this.cmbTipo.MinimumSize = new System.Drawing.Size(200, 30);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Padding = new System.Windows.Forms.Padding(2);
            this.cmbTipo.Size = new System.Drawing.Size(289, 37);
            this.cmbTipo.TabIndex = 9;
            this.cmbTipo.Texts = "Seleccione un tipo de pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(16, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo de pago:";
            // 
            // txtInteres
            // 
            this.txtInteres.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txtInteres.BorderFocusColor = System.Drawing.SystemColors.Info;
            this.txtInteres.BorderRadius = 0;
            this.txtInteres.BorderSize = 2;
            this.txtInteres.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInteres.Location = new System.Drawing.Point(183, 194);
            this.txtInteres.Multiline = false;
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtInteres.PasswordChar = false;
            this.txtInteres.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtInteres.PlaceholderText = "Introduzca la tasa de interés";
            this.txtInteres.Size = new System.Drawing.Size(351, 36);
            this.txtInteres.TabIndex = 7;
            this.txtInteres.Texts = "";
            this.txtInteres.UnderlinedStyle = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(16, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Interés:";
            // 
            // dateFechaInicio
            // 
            this.dateFechaInicio.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.dateFechaInicio.BorderSize = 2;
            this.dateFechaInicio.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFechaInicio.Location = new System.Drawing.Point(183, 135);
            this.dateFechaInicio.MinimumSize = new System.Drawing.Size(0, 35);
            this.dateFechaInicio.Name = "dateFechaInicio";
            this.dateFechaInicio.Size = new System.Drawing.Size(287, 35);
            this.dateFechaInicio.SkinColor = System.Drawing.SystemColors.Info;
            this.dateFechaInicio.TabIndex = 5;
            this.dateFechaInicio.TextColor = System.Drawing.Color.Black;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de inicio:";
            // 
            // txtCredito
            // 
            this.txtCredito.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txtCredito.BorderFocusColor = System.Drawing.SystemColors.Info;
            this.txtCredito.BorderRadius = 0;
            this.txtCredito.BorderSize = 2;
            this.txtCredito.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCredito.Location = new System.Drawing.Point(183, 75);
            this.txtCredito.Multiline = false;
            this.txtCredito.Name = "txtCredito";
            this.txtCredito.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCredito.PasswordChar = false;
            this.txtCredito.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtCredito.PlaceholderText = "Introduzca monto total";
            this.txtCredito.Size = new System.Drawing.Size(351, 36);
            this.txtCredito.TabIndex = 3;
            this.txtCredito.Texts = "";
            this.txtCredito.UnderlinedStyle = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Crédito prestado:";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.txtNombre.BorderFocusColor = System.Drawing.SystemColors.Info;
            this.txtNombre.BorderRadius = 0;
            this.txtNombre.BorderSize = 2;
            this.txtNombre.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombre.Location = new System.Drawing.Point(183, 15);
            this.txtNombre.Multiline = false;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNombre.PasswordChar = false;
            this.txtNombre.PlaceholderColor = System.Drawing.Color.DimGray;
            this.txtNombre.PlaceholderText = "Introduzca el nombre";
            this.txtNombre.Size = new System.Drawing.Size(351, 36);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Texts = "";
            this.txtNombre.UnderlinedStyle = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre completo:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 531);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "FutureLending";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelMenu;
        private Panel panelTitleBar;
        private Panel panelDesktop;
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
    }
}