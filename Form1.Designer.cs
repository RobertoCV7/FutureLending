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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelMenu = new Panel();
            btnTodosSistemas = new FontAwesome.Sharp.IconButton();
            btnEstadoPagos = new FontAwesome.Sharp.IconButton();
            btnListas = new FontAwesome.Sharp.IconButton();
            btnIngresarClientes = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            btnMenu = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            pnlRegPago = new Panel();
            ComBoxName = new ControlesPersonalizados.RJComboBox();
            CombBoxLista = new ControlesPersonalizados.RJComboBox();
            label29 = new Label();
            btnBuscarC = new Controles_personalizados.RJButton();
            label17 = new Label();
            lblFecha = new Label();
            txtBoxCredito = new Controles_personalizados.TextBoxPersonalizado();
            lblCredito = new Label();
            txtBoxMonto = new Controles_personalizados.TextBoxPersonalizado();
            btnMarcarP = new Controles_personalizados.RJButton();
            lblMonto = new Label();
            DateTimeReg = new Controles_personalizados.DateTimePickerPersonalizado();
            pnlClientes = new Panel();
            cmbInteres = new ControlesPersonalizados.RJComboBox();
            btnCalcular = new Controles_personalizados.RJButton();
            txtTotal_I = new Controles_personalizados.TextBoxPersonalizado();
            label16 = new Label();
            txtTotal = new Controles_personalizados.TextBoxPersonalizado();
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
            label6 = new Label();
            cmbTipo = new ControlesPersonalizados.RJComboBox();
            label5 = new Label();
            label4 = new Label();
            dateFechaInicio = new Controles_personalizados.DateTimePickerPersonalizado();
            label3 = new Label();
            txtCredito = new Controles_personalizados.TextBoxPersonalizado();
            label2 = new Label();
            txtNombre = new Controles_personalizados.TextBoxPersonalizado();
            label1 = new Label();
            cmbPromotor = new ControlesPersonalizados.RJComboBox();
            pnlListas = new Panel();
            rjButton1 = new Controles_personalizados.RJButton();
            rjComboBox2 = new ControlesPersonalizados.RJComboBox();
            label18 = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            cmbCliente = new ControlesPersonalizados.RJComboBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnEditar = new Controles_personalizados.RJButton();
            btnEliminar = new Controles_personalizados.RJButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnLista1 = new Controles_personalizados.RJButton();
            btnLista2 = new Controles_personalizados.RJButton();
            btnLista3 = new Controles_personalizados.RJButton();
            btnMostrarTodos = new Controles_personalizados.RJButton();
            btnLiquidados = new Controles_personalizados.RJButton();
            gridListas = new DataGridView();
            label8 = new Label();
            bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(components);
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            pnlRegPago.SuspendLayout();
            pnlClientes.SuspendLayout();
            pnlListas.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridListas).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.AccessibleName = "panelMenu";
            panelMenu.BackColor = Color.DarkSlateGray;
            panelMenu.Controls.Add(btnTodosSistemas);
            panelMenu.Controls.Add(btnEstadoPagos);
            panelMenu.Controls.Add(btnListas);
            panelMenu.Controls.Add(btnIngresarClientes);
            panelMenu.Controls.Add(panel1);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(263, 741);
            panelMenu.TabIndex = 0;
            // 
            // btnTodosSistemas
            // 
            btnTodosSistemas.Dock = DockStyle.Bottom;
            btnTodosSistemas.FlatAppearance.BorderSize = 0;
            btnTodosSistemas.FlatStyle = FlatStyle.Flat;
            btnTodosSistemas.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnTodosSistemas.ForeColor = Color.White;
            btnTodosSistemas.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            btnTodosSistemas.IconColor = Color.White;
            btnTodosSistemas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTodosSistemas.ImageAlign = ContentAlignment.MiddleLeft;
            btnTodosSistemas.Location = new Point(0, 660);
            btnTodosSistemas.Margin = new Padding(3, 4, 3, 4);
            btnTodosSistemas.Name = "btnTodosSistemas";
            btnTodosSistemas.Padding = new Padding(11, 0, 0, 0);
            btnTodosSistemas.Size = new Size(263, 81);
            btnTodosSistemas.TabIndex = 3;
            btnTodosSistemas.Tag = "Reparar";
            btnTodosSistemas.Text = "Reparar";
            btnTodosSistemas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTodosSistemas.UseVisualStyleBackColor = true;
            btnTodosSistemas.Click += BtnTodosSistemas_Click;
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
            btnEstadoPagos.Click += BtnEstadoPagos_Click;
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
            btnListas.Click += BtnListas_Click;
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
            btnIngresarClientes.Click += BtnIngresarClientes_Click;
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
            btnMenu.Click += BtnMenu_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(9, 4);
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
            // pnlRegPago
            // 
            pnlRegPago.BackColor = SystemColors.Info;
            pnlRegPago.Controls.Add(ComBoxName);
            pnlRegPago.Controls.Add(CombBoxLista);
            pnlRegPago.Controls.Add(label29);
            pnlRegPago.Controls.Add(btnBuscarC);
            pnlRegPago.Controls.Add(label17);
            pnlRegPago.Controls.Add(lblFecha);
            pnlRegPago.Controls.Add(txtBoxCredito);
            pnlRegPago.Controls.Add(lblCredito);
            pnlRegPago.Controls.Add(txtBoxMonto);
            pnlRegPago.Controls.Add(btnMarcarP);
            pnlRegPago.Controls.Add(lblMonto);
            pnlRegPago.Controls.Add(DateTimeReg);
            pnlRegPago.Dock = DockStyle.Fill;
            pnlRegPago.Location = new Point(263, 80);
            pnlRegPago.Margin = new Padding(3, 4, 3, 4);
            pnlRegPago.Name = "pnlRegPago";
            pnlRegPago.Size = new Size(979, 661);
            pnlRegPago.TabIndex = 27;
            // 
            // ComBoxName
            // 
            ComBoxName.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComBoxName.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComBoxName.BackColor = SystemColors.Info;
            ComBoxName.BorderColor = Color.DarkSlateGray;
            ComBoxName.BorderSize = 2;
            ComBoxName.DropDownStyle = ComboBoxStyle.DropDown;
            ComBoxName.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ComBoxName.ForeColor = Color.Black;
            ComBoxName.IconColor = Color.DarkSlateGray;
            ComBoxName.ListBackColor = SystemColors.Info;
            ComBoxName.ListTextColor = Color.DimGray;
            ComBoxName.Location = new Point(309, 48);
            ComBoxName.Margin = new Padding(3, 4, 3, 4);
            ComBoxName.MinimumSize = new Size(229, 40);
            ComBoxName.Name = "ComBoxName";
            ComBoxName.Padding = new Padding(2, 3, 2, 3);
            ComBoxName.Size = new Size(391, 65);
            ComBoxName.TabIndex = 14;
            ComBoxName.Texts = "Introduzca nombre";
            ComBoxName.OnSelectedIndexChanged += ActivarBtnBuscar;
            // 
            // CombBoxLista
            // 
            CombBoxLista.AutoCompleteMode = AutoCompleteMode.Suggest;
            CombBoxLista.AutoCompleteSource = AutoCompleteSource.ListItems;
            CombBoxLista.BackColor = SystemColors.Info;
            CombBoxLista.BorderColor = Color.DarkSlateGray;
            CombBoxLista.BorderSize = 2;
            CombBoxLista.DropDownStyle = ComboBoxStyle.DropDown;
            CombBoxLista.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            CombBoxLista.ForeColor = Color.Black;
            CombBoxLista.IconColor = Color.DarkSlateGray;
            CombBoxLista.Items.AddRange(new object[] { "Lista 1", "Lista 2" });
            CombBoxLista.ListBackColor = SystemColors.Info;
            CombBoxLista.ListTextColor = Color.DimGray;
            CombBoxLista.Location = new Point(309, 139);
            CombBoxLista.Margin = new Padding(3, 4, 3, 4);
            CombBoxLista.MinimumSize = new Size(229, 40);
            CombBoxLista.Name = "CombBoxLista";
            CombBoxLista.Padding = new Padding(2, 3, 2, 3);
            CombBoxLista.Size = new Size(346, 63);
            CombBoxLista.TabIndex = 35;
            CombBoxLista.Texts = "Introduzca lista";
            CombBoxLista.OnSelectedIndexChanged += ActivarBtnBuscar;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label29.Location = new Point(41, 77);
            label29.Name = "label29";
            label29.Size = new Size(224, 29);
            label29.TabIndex = 0;
            label29.Text = "Nombre del cliente:";
            // 
            // btnBuscarC
            // 
            btnBuscarC.BackColor = SystemColors.Info;
            btnBuscarC.BackgroundColor = SystemColors.Info;
            btnBuscarC.BorderColor = Color.DarkSlateGray;
            btnBuscarC.BorderRadius = 10;
            btnBuscarC.BorderSize = 2;
            btnBuscarC.Enabled = false;
            btnBuscarC.FlatAppearance.BorderSize = 0;
            btnBuscarC.FlatStyle = FlatStyle.Flat;
            btnBuscarC.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBuscarC.ForeColor = Color.Black;
            btnBuscarC.Location = new Point(799, 109);
            btnBuscarC.Margin = new Padding(3, 4, 3, 4);
            btnBuscarC.Name = "btnBuscarC";
            btnBuscarC.Size = new Size(135, 48);
            btnBuscarC.TabIndex = 13;
            btnBuscarC.Text = "Buscar";
            btnBuscarC.TextColor = Color.Black;
            btnBuscarC.UseVisualStyleBackColor = false;
            btnBuscarC.Click += BtnBuscarC_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(41, 172);
            label17.Name = "label17";
            label17.Size = new Size(152, 29);
            label17.TabIndex = 34;
            label17.Text = "Tipo de lista:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFecha.Location = new Point(41, 536);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(200, 29);
            lblFecha.TabIndex = 31;
            lblFecha.Text = "Fecha a registrar:";
            lblFecha.Visible = false;
            // 
            // txtBoxCredito
            // 
            txtBoxCredito.BorderColor = Color.DarkSlateGray;
            txtBoxCredito.BorderFocusColor = SystemColors.Info;
            txtBoxCredito.BorderRadius = 0;
            txtBoxCredito.BorderSize = 2;
            txtBoxCredito.Enabled = false;
            txtBoxCredito.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxCredito.Location = new Point(309, 264);
            txtBoxCredito.Margin = new Padding(3, 4, 3, 4);
            txtBoxCredito.Multiline = false;
            txtBoxCredito.Name = "txtBoxCredito";
            txtBoxCredito.Padding = new Padding(11, 9, 11, 9);
            txtBoxCredito.PasswordChar = false;
            txtBoxCredito.PlaceholderColor = Color.DimGray;
            txtBoxCredito.PlaceholderText = "";
            txtBoxCredito.Size = new Size(265, 48);
            txtBoxCredito.TabIndex = 27;
            txtBoxCredito.Texts = "";
            txtBoxCredito.UnderlinedStyle = true;
            txtBoxCredito.Visible = false;
            // 
            // lblCredito
            // 
            lblCredito.AutoSize = true;
            lblCredito.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCredito.Location = new Point(41, 292);
            lblCredito.Name = "lblCredito";
            lblCredito.Size = new Size(199, 29);
            lblCredito.TabIndex = 28;
            lblCredito.Text = "Crédito prestado:";
            lblCredito.Visible = false;
            // 
            // txtBoxMonto
            // 
            txtBoxMonto.BorderColor = Color.DarkSlateGray;
            txtBoxMonto.BorderFocusColor = SystemColors.Info;
            txtBoxMonto.BorderRadius = 0;
            txtBoxMonto.BorderSize = 2;
            txtBoxMonto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxMonto.Location = new Point(309, 388);
            txtBoxMonto.Margin = new Padding(3, 4, 3, 4);
            txtBoxMonto.Multiline = false;
            txtBoxMonto.Name = "txtBoxMonto";
            txtBoxMonto.Padding = new Padding(11, 9, 11, 9);
            txtBoxMonto.PasswordChar = false;
            txtBoxMonto.PlaceholderColor = Color.DimGray;
            txtBoxMonto.PlaceholderText = "";
            txtBoxMonto.Size = new Size(171, 48);
            txtBoxMonto.TabIndex = 30;
            txtBoxMonto.Texts = "";
            txtBoxMonto.UnderlinedStyle = true;
            txtBoxMonto.Visible = false;
            txtBoxMonto._TextChanged += ActivarBtnMarcar;
            txtBoxMonto.KeyPress += SoloNumerosDecimal;
            // 
            // btnMarcarP
            // 
            btnMarcarP.Anchor = AnchorStyles.Bottom;
            btnMarcarP.BackColor = SystemColors.Info;
            btnMarcarP.BackgroundColor = SystemColors.Info;
            btnMarcarP.BorderColor = Color.DarkSlateGray;
            btnMarcarP.BorderRadius = 10;
            btnMarcarP.BorderSize = 2;
            btnMarcarP.Enabled = false;
            btnMarcarP.FlatAppearance.BorderSize = 0;
            btnMarcarP.FlatStyle = FlatStyle.Flat;
            btnMarcarP.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMarcarP.ForeColor = Color.Black;
            btnMarcarP.Location = new Point(479, 587);
            btnMarcarP.Margin = new Padding(3, 4, 3, 4);
            btnMarcarP.Name = "btnMarcarP";
            btnMarcarP.Size = new Size(277, 53);
            btnMarcarP.TabIndex = 33;
            btnMarcarP.Text = "Marcar como pagada";
            btnMarcarP.TextColor = Color.Black;
            btnMarcarP.UseVisualStyleBackColor = false;
            btnMarcarP.Visible = false;
            btnMarcarP.Click += BtnMarcarP_Click;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblMonto.Location = new Point(41, 419);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(212, 29);
            lblMonto.TabIndex = 29;
            lblMonto.Text = "Monto a depositar:";
            lblMonto.Visible = false;
            // 
            // DateTimeReg
            // 
            DateTimeReg.BorderColor = Color.DarkSlateGray;
            DateTimeReg.BorderSize = 2;
            DateTimeReg.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            DateTimeReg.Format = DateTimePickerFormat.Short;
            DateTimeReg.Location = new Point(307, 528);
            DateTimeReg.Margin = new Padding(3, 4, 3, 4);
            DateTimeReg.MinimumSize = new Size(4, 35);
            DateTimeReg.Name = "DateTimeReg";
            DateTimeReg.Size = new Size(172, 35);
            DateTimeReg.SkinColor = SystemColors.Info;
            DateTimeReg.TabIndex = 32;
            DateTimeReg.TextColor = Color.Black;
            DateTimeReg.Visible = false;
            // 
            // pnlClientes
            // 
            pnlClientes.BackColor = SystemColors.Info;
            pnlClientes.Controls.Add(cmbInteres);
            pnlClientes.Controls.Add(btnCalcular);
            pnlClientes.Controls.Add(txtTotal_I);
            pnlClientes.Controls.Add(label16);
            pnlClientes.Controls.Add(txtTotal);
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
            pnlClientes.Controls.Add(label6);
            pnlClientes.Controls.Add(cmbTipo);
            pnlClientes.Controls.Add(label5);
            pnlClientes.Controls.Add(label4);
            pnlClientes.Controls.Add(dateFechaInicio);
            pnlClientes.Controls.Add(label3);
            pnlClientes.Controls.Add(txtCredito);
            pnlClientes.Controls.Add(label2);
            pnlClientes.Controls.Add(txtNombre);
            pnlClientes.Controls.Add(label1);
            pnlClientes.Controls.Add(cmbPromotor);
            pnlClientes.Dock = DockStyle.Fill;
            pnlClientes.Location = new Point(263, 80);
            pnlClientes.Margin = new Padding(3, 4, 3, 4);
            pnlClientes.Name = "pnlClientes";
            pnlClientes.Size = new Size(979, 661);
            pnlClientes.TabIndex = 2;
            // 
            // cmbInteres
            // 
            cmbInteres.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbInteres.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbInteres.BackColor = SystemColors.Info;
            cmbInteres.BorderColor = Color.DarkSlateGray;
            cmbInteres.BorderSize = 2;
            cmbInteres.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInteres.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbInteres.ForeColor = Color.Black;
            cmbInteres.IconColor = Color.DarkSlateGray;
            cmbInteres.Items.AddRange(new object[] { "7%", "8%", "10%" });
            cmbInteres.ListBackColor = SystemColors.Info;
            cmbInteres.ListTextColor = Color.DimGray;
            cmbInteres.Location = new Point(224, 253);
            cmbInteres.Margin = new Padding(3, 4, 3, 4);
            cmbInteres.MinimumSize = new Size(229, 40);
            cmbInteres.Name = "cmbInteres";
            cmbInteres.Padding = new Padding(2, 3, 2, 3);
            cmbInteres.Size = new Size(361, 55);
            cmbInteres.TabIndex = 4;
            cmbInteres.Tag = "Seleccione un interés";
            cmbInteres.Texts = "Seleccione un interés";
            cmbInteres.OnSelectedIndexChanged += ActivarBtnCalcular;
            // 
            // btnCalcular
            // 
            btnCalcular.Anchor = AnchorStyles.Bottom;
            btnCalcular.BackColor = SystemColors.Info;
            btnCalcular.BackgroundColor = SystemColors.Info;
            btnCalcular.BorderColor = Color.DarkSlateGray;
            btnCalcular.BorderRadius = 10;
            btnCalcular.BorderSize = 2;
            btnCalcular.Enabled = false;
            btnCalcular.FlatAppearance.BorderSize = 0;
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalcular.ForeColor = Color.Black;
            btnCalcular.Location = new Point(214, 600);
            btnCalcular.Margin = new Padding(3, 4, 3, 4);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(151, 40);
            btnCalcular.TabIndex = 7;
            btnCalcular.Text = "Calcular";
            btnCalcular.TextColor = Color.Black;
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += BtnCalcular_Click;
            // 
            // txtTotal_I
            // 
            txtTotal_I.BorderColor = Color.DarkSlateGray;
            txtTotal_I.BorderFocusColor = SystemColors.Info;
            txtTotal_I.BorderRadius = 0;
            txtTotal_I.BorderSize = 2;
            txtTotal_I.Enabled = false;
            txtTotal_I.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTotal_I.Location = new Point(323, 540);
            txtTotal_I.Margin = new Padding(3, 4, 3, 4);
            txtTotal_I.Multiline = false;
            txtTotal_I.Name = "txtTotal_I";
            txtTotal_I.Padding = new Padding(11, 9, 11, 9);
            txtTotal_I.PasswordChar = false;
            txtTotal_I.PlaceholderColor = Color.DimGray;
            txtTotal_I.PlaceholderText = "";
            txtTotal_I.Size = new Size(159, 48);
            txtTotal_I.TabIndex = 29;
            txtTotal_I.Texts = "";
            txtTotal_I.UnderlinedStyle = true;
            txtTotal_I._TextChanged += ActivarBtnGuardar;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(18, 552);
            label16.Name = "label16";
            label16.Size = new Size(299, 29);
            label16.TabIndex = 28;
            label16.Text = "Monto segun tipo de pago:";
            // 
            // txtTotal
            // 
            txtTotal.BorderColor = Color.DarkSlateGray;
            txtTotal.BorderFocusColor = SystemColors.Info;
            txtTotal.BorderRadius = 0;
            txtTotal.BorderSize = 2;
            txtTotal.Enabled = false;
            txtTotal.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTotal.Location = new Point(323, 472);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Multiline = false;
            txtTotal.Name = "txtTotal";
            txtTotal.Padding = new Padding(11, 9, 11, 9);
            txtTotal.PasswordChar = false;
            txtTotal.PlaceholderColor = Color.DimGray;
            txtTotal.PlaceholderText = "";
            txtTotal.Size = new Size(159, 48);
            txtTotal.TabIndex = 27;
            txtTotal.Texts = "";
            txtTotal.UnderlinedStyle = true;
            txtTotal._TextChanged += ActivarBtnGuardar;
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCorreo.BorderColor = Color.DarkSlateGray;
            txtCorreo.BorderFocusColor = SystemColors.Info;
            txtCorreo.BorderRadius = 0;
            txtCorreo.BorderSize = 2;
            txtCorreo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCorreo.Location = new Point(674, 505);
            txtCorreo.Margin = new Padding(3, 4, 3, 4);
            txtCorreo.Multiline = false;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Padding = new Padding(11, 9, 11, 9);
            txtCorreo.PasswordChar = false;
            txtCorreo.PlaceholderColor = Color.DimGray;
            txtCorreo.PlaceholderText = "Introduzca el correo";
            txtCorreo.Size = new Size(283, 48);
            txtCorreo.TabIndex = 13;
            txtCorreo.Texts = "";
            txtCorreo.UnderlinedStyle = true;
            txtCorreo._TextChanged += ActivarBtnGuardar;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(674, 472);
            label15.Name = "label15";
            label15.Size = new Size(219, 29);
            label15.TabIndex = 25;
            label15.Text = "Correo electrónico:";
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTelefono.BorderColor = Color.DarkSlateGray;
            txtTelefono.BorderFocusColor = SystemColors.Info;
            txtTelefono.BorderRadius = 0;
            txtTelefono.BorderSize = 2;
            txtTelefono.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.Location = new Point(674, 404);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.Multiline = false;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Padding = new Padding(11, 9, 11, 9);
            txtTelefono.PasswordChar = false;
            txtTelefono.PlaceholderColor = Color.DimGray;
            txtTelefono.PlaceholderText = "Introduzca el núm. de tel.";
            txtTelefono.Size = new Size(283, 48);
            txtTelefono.TabIndex = 12;
            txtTelefono.Texts = "";
            txtTelefono.UnderlinedStyle = true;
            txtTelefono._TextChanged += ActivarBtnGuardar;
            txtTelefono.KeyPress += SoloNumerosEnteros;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(674, 371);
            label14.Name = "label14";
            label14.Size = new Size(116, 29);
            label14.TabIndex = 23;
            label14.Text = "Teléfono:";
            // 
            // txtNumExt
            // 
            txtNumExt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNumExt.BorderColor = Color.DarkSlateGray;
            txtNumExt.BorderFocusColor = SystemColors.Info;
            txtNumExt.BorderRadius = 0;
            txtNumExt.BorderSize = 2;
            txtNumExt.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumExt.Location = new Point(842, 303);
            txtNumExt.Margin = new Padding(3, 4, 3, 4);
            txtNumExt.Multiline = false;
            txtNumExt.Name = "txtNumExt";
            txtNumExt.Padding = new Padding(11, 9, 11, 9);
            txtNumExt.PasswordChar = false;
            txtNumExt.PlaceholderColor = Color.DimGray;
            txtNumExt.PlaceholderText = "Num. ext.";
            txtNumExt.Size = new Size(115, 48);
            txtNumExt.TabIndex = 11;
            txtNumExt.Texts = "";
            txtNumExt.UnderlinedStyle = true;
            txtNumExt._TextChanged += ActivarBtnGuardar;
            txtNumExt.KeyPress += SoloNumerosEnteros;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(842, 271);
            label13.Name = "label13";
            label13.Size = new Size(119, 29);
            label13.TabIndex = 21;
            label13.Text = "Núm. ext.:";
            // 
            // txtNumInt
            // 
            txtNumInt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNumInt.BorderColor = Color.DarkSlateGray;
            txtNumInt.BorderFocusColor = SystemColors.Info;
            txtNumInt.BorderRadius = 0;
            txtNumInt.BorderSize = 2;
            txtNumInt.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumInt.Location = new Point(674, 303);
            txtNumInt.Margin = new Padding(3, 4, 3, 4);
            txtNumInt.Multiline = false;
            txtNumInt.Name = "txtNumInt";
            txtNumInt.Padding = new Padding(11, 9, 11, 9);
            txtNumInt.PasswordChar = false;
            txtNumInt.PlaceholderColor = Color.DimGray;
            txtNumInt.PlaceholderText = "Num. int.";
            txtNumInt.Size = new Size(115, 48);
            txtNumInt.TabIndex = 10;
            txtNumInt.Texts = "";
            txtNumInt.UnderlinedStyle = true;
            txtNumInt._TextChanged += ActivarBtnGuardar;
            txtNumInt.KeyPress += SoloNumerosEnteros;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(674, 269);
            label12.Name = "label12";
            label12.Size = new Size(113, 29);
            label12.TabIndex = 19;
            label12.Text = "Núm. int.:";
            // 
            // txtColonia
            // 
            txtColonia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtColonia.BorderColor = Color.DarkSlateGray;
            txtColonia.BorderFocusColor = SystemColors.Info;
            txtColonia.BorderRadius = 0;
            txtColonia.BorderSize = 2;
            txtColonia.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtColonia.Location = new Point(674, 204);
            txtColonia.Margin = new Padding(3, 4, 3, 4);
            txtColonia.Multiline = false;
            txtColonia.Name = "txtColonia";
            txtColonia.Padding = new Padding(11, 9, 11, 9);
            txtColonia.PasswordChar = false;
            txtColonia.PlaceholderColor = Color.DimGray;
            txtColonia.PlaceholderText = "Introduzca la colonia";
            txtColonia.Size = new Size(265, 48);
            txtColonia.TabIndex = 9;
            txtColonia.Texts = "";
            txtColonia.UnderlinedStyle = true;
            txtColonia._TextChanged += ActivarBtnGuardar;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(674, 171);
            label11.Name = "label11";
            label11.Size = new Size(102, 29);
            label11.TabIndex = 17;
            label11.Text = "Colonia:";
            // 
            // txtCalle
            // 
            txtCalle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCalle.BorderColor = Color.DarkSlateGray;
            txtCalle.BorderFocusColor = SystemColors.Info;
            txtCalle.BorderRadius = 0;
            txtCalle.BorderSize = 2;
            txtCalle.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCalle.Location = new Point(674, 104);
            txtCalle.Margin = new Padding(3, 4, 3, 4);
            txtCalle.Multiline = false;
            txtCalle.Name = "txtCalle";
            txtCalle.Padding = new Padding(11, 9, 11, 9);
            txtCalle.PasswordChar = false;
            txtCalle.PlaceholderColor = Color.DimGray;
            txtCalle.PlaceholderText = "Introduzca la calle";
            txtCalle.Size = new Size(265, 48);
            txtCalle.TabIndex = 8;
            txtCalle.Texts = "";
            txtCalle.UnderlinedStyle = true;
            txtCalle._TextChanged += ActivarBtnGuardar;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(674, 71);
            label10.Name = "label10";
            label10.Size = new Size(75, 29);
            label10.TabIndex = 15;
            label10.Text = "Calle:";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(674, 28);
            label9.Name = "label9";
            label9.Size = new Size(121, 29);
            label9.TabIndex = 14;
            label9.Text = "Dirección:";
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGuardar.BackColor = SystemColors.Info;
            btnGuardar.BackgroundColor = SystemColors.Info;
            btnGuardar.BorderColor = Color.DarkSlateGray;
            btnGuardar.BorderRadius = 10;
            btnGuardar.BorderSize = 2;
            btnGuardar.Enabled = false;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(715, 580);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(171, 53);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextColor = Color.Black;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(18, 480);
            label7.Name = "label7";
            label7.Size = new Size(261, 29);
            label7.TabIndex = 12;
            label7.Text = "Monto total con interés:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(18, 408);
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
            cmbTipo.Items.AddRange(new object[] { "Semanales", "Quincenales" });
            cmbTipo.ListBackColor = SystemColors.Info;
            cmbTipo.ListTextColor = Color.DimGray;
            cmbTipo.Location = new Point(224, 325);
            cmbTipo.Margin = new Padding(3, 4, 3, 4);
            cmbTipo.MinimumSize = new Size(229, 40);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Padding = new Padding(2, 3, 2, 3);
            cmbTipo.Size = new Size(361, 55);
            cmbTipo.TabIndex = 5;
            cmbTipo.Tag = "Selecciones un tipo de pago";
            cmbTipo.Texts = "Seleccione un tipo de pago";
            cmbTipo.OnSelectedIndexChanged += ActivarBtnCalcular;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(18, 336);
            label5.Name = "label5";
            label5.Size = new Size(164, 29);
            label5.TabIndex = 8;
            label5.Text = "Tipo de pago:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(18, 264);
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
            dateFechaInicio.Location = new Point(224, 185);
            dateFechaInicio.Margin = new Padding(3, 4, 3, 4);
            dateFechaInicio.MinimumSize = new Size(4, 35);
            dateFechaInicio.Name = "dateFechaInicio";
            dateFechaInicio.Size = new Size(327, 35);
            dateFechaInicio.SkinColor = SystemColors.Info;
            dateFechaInicio.TabIndex = 3;
            dateFechaInicio.TextColor = Color.Black;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(18, 192);
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
            txtCredito.Location = new Point(224, 111);
            txtCredito.Margin = new Padding(3, 4, 3, 4);
            txtCredito.Multiline = false;
            txtCredito.Name = "txtCredito";
            txtCredito.Padding = new Padding(11, 9, 11, 9);
            txtCredito.PasswordChar = false;
            txtCredito.PlaceholderColor = Color.DimGray;
            txtCredito.PlaceholderText = "Introduzca monto total";
            txtCredito.Size = new Size(406, 48);
            txtCredito.TabIndex = 2;
            txtCredito.Texts = "";
            txtCredito.UnderlinedStyle = true;
            txtCredito._TextChanged += ActivarBtnCalcular;
            txtCredito.KeyPress += SoloNumerosDecimal;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(18, 120);
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
            txtNombre.Location = new Point(224, 39);
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
            txtNombre._TextChanged += ActivarBtnGuardar;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 48);
            label1.Name = "label1";
            label1.Size = new Size(213, 29);
            label1.TabIndex = 0;
            label1.Text = "Nombre completo:";
            // 
            // cmbPromotor
            // 
            cmbPromotor.AutoCompleteCustomSource.AddRange(new string[] { "Ramona-la-nalgona", "Yael-el-licenciado" });
            cmbPromotor.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbPromotor.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbPromotor.BackColor = SystemColors.Info;
            cmbPromotor.BorderColor = Color.DarkSlateGray;
            cmbPromotor.BorderSize = 2;
            cmbPromotor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPromotor.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbPromotor.ForeColor = Color.Black;
            cmbPromotor.IconColor = Color.DarkSlateGray;
            cmbPromotor.Items.AddRange(new object[] { "Roberto", "Ramon" });
            cmbPromotor.ListBackColor = SystemColors.Info;
            cmbPromotor.ListTextColor = Color.DimGray;
            cmbPromotor.Location = new Point(224, 397);
            cmbPromotor.Margin = new Padding(3, 4, 3, 4);
            cmbPromotor.MinimumSize = new Size(229, 40);
            cmbPromotor.Name = "cmbPromotor";
            cmbPromotor.Padding = new Padding(2, 3, 2, 3);
            cmbPromotor.Size = new Size(361, 53);
            cmbPromotor.TabIndex = 6;
            cmbPromotor.Tag = "Seleccione al promotor";
            cmbPromotor.Texts = "Seleccione al promotor";
            cmbPromotor.OnSelectedIndexChanged += ActivarBtnGuardar;
            // 
            // pnlListas
            // 
            pnlListas.BackColor = SystemColors.Info;
            pnlListas.Controls.Add(rjButton1);
            pnlListas.Controls.Add(rjComboBox2);
            pnlListas.Controls.Add(label18);
            pnlListas.Controls.Add(flowLayoutPanel3);
            pnlListas.Controls.Add(flowLayoutPanel2);
            pnlListas.Controls.Add(flowLayoutPanel1);
            pnlListas.Controls.Add(gridListas);
            pnlListas.Controls.Add(label8);
            pnlListas.Dock = DockStyle.Fill;
            pnlListas.Location = new Point(263, 80);
            pnlListas.Margin = new Padding(3, 4, 3, 4);
            pnlListas.Name = "pnlListas";
            pnlListas.Size = new Size(979, 661);
            pnlListas.TabIndex = 14;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.DodgerBlue;
            rjButton1.BackgroundColor = Color.DodgerBlue;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(43, 109);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(187, 51);
            rjButton1.TabIndex = 25;
            rjButton1.Text = "Exportar";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += RjButton1_Click;
            // 
            // rjComboBox2
            // 
            rjComboBox2.AllowDrop = true;
            rjComboBox2.AutoCompleteCustomSource.AddRange(new string[] { "Ramona-la-nalgona", "Yael-el-licenciado" });
            rjComboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            rjComboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            rjComboBox2.BackColor = SystemColors.Info;
            rjComboBox2.BorderColor = Color.DarkSlateGray;
            rjComboBox2.BorderSize = 2;
            rjComboBox2.DropDownStyle = ComboBoxStyle.DropDown;
            rjComboBox2.Enabled = false;
            rjComboBox2.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            rjComboBox2.ForeColor = Color.Black;
            rjComboBox2.IconColor = Color.DarkSlateGray;
            rjComboBox2.Items.AddRange(new object[] { "Lista 1", "Lista 2", "Lista 3", "Lista Liquidados", "Todas las Listas" });
            rjComboBox2.ListBackColor = SystemColors.Info;
            rjComboBox2.ListTextColor = Color.DimGray;
            rjComboBox2.Location = new Point(18, 41);
            rjComboBox2.Margin = new Padding(3, 4, 3, 4);
            rjComboBox2.MinimumSize = new Size(229, 40);
            rjComboBox2.Name = "rjComboBox2";
            rjComboBox2.Padding = new Padding(2, 3, 2, 3);
            rjComboBox2.Size = new Size(261, 53);
            rjComboBox2.TabIndex = 23;
            rjComboBox2.Tag = "Seleccione un cliente";
            rjComboBox2.Texts = "Seleccione una Lista";
            rjComboBox2.OnSelectedIndexChanged += RjComboBox2_OnSelectedIndexChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(43, 4);
            label18.Name = "label18";
            label18.Size = new Size(203, 29);
            label18.TabIndex = 24;
            label18.Text = "Exportar a Excel";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanel3.Controls.Add(cmbCliente);
            flowLayoutPanel3.Location = new Point(317, 583);
            flowLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(371, 60);
            flowLayoutPanel3.TabIndex = 23;
            // 
            // cmbCliente
            // 
            cmbCliente.AllowDrop = true;
            cmbCliente.AutoCompleteCustomSource.AddRange(new string[] { "Ramona-la-nalgona", "Yael-el-licenciado" });
            cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCliente.BackColor = SystemColors.Info;
            cmbCliente.BorderColor = Color.DarkSlateGray;
            cmbCliente.BorderSize = 2;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDown;
            cmbCliente.Enabled = false;
            cmbCliente.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            cmbCliente.ForeColor = Color.Black;
            cmbCliente.IconColor = Color.DarkSlateGray;
            cmbCliente.ListBackColor = SystemColors.Info;
            cmbCliente.ListTextColor = Color.DimGray;
            cmbCliente.Location = new Point(3, 4);
            cmbCliente.Margin = new Padding(3, 4, 3, 4);
            cmbCliente.MinimumSize = new Size(229, 40);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Padding = new Padding(2, 3, 2, 3);
            cmbCliente.Size = new Size(361, 53);
            cmbCliente.TabIndex = 22;
            cmbCliente.Tag = "Seleccione un cliente";
            cmbCliente.Texts = "Seleccione un cliente";
            cmbCliente.OnSelectedIndexChanged += CmbCliente_OnSelectedIndexChanged;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            flowLayoutPanel2.Controls.Add(btnEditar);
            flowLayoutPanel2.Controls.Add(btnEliminar);
            flowLayoutPanel2.Location = new Point(695, 575);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(272, 75);
            flowLayoutPanel2.TabIndex = 21;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Bottom;
            btnEditar.BackColor = Color.Teal;
            btnEditar.BackgroundColor = Color.Teal;
            btnEditar.BorderColor = Color.Teal;
            btnEditar.BorderRadius = 15;
            btnEditar.BorderSize = 2;
            btnEditar.Enabled = false;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.Transparent;
            btnEditar.Location = new Point(3, 4);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(127, 68);
            btnEditar.TabIndex = 18;
            btnEditar.Text = "Editar\r\ncliente\r\n";
            btnEditar.TextColor = Color.Transparent;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += BtnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom;
            btnEliminar.BackColor = Color.SteelBlue;
            btnEliminar.BackgroundColor = Color.SteelBlue;
            btnEliminar.BorderColor = Color.SteelBlue;
            btnEliminar.BorderRadius = 15;
            btnEliminar.BorderSize = 2;
            btnEliminar.Enabled = false;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.Transparent;
            btnEliminar.Location = new Point(136, 5);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(127, 67);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "Eliminar\r\ncliente\r\n";
            btnEliminar.TextColor = Color.Transparent;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(btnLista1);
            flowLayoutPanel1.Controls.Add(btnLista2);
            flowLayoutPanel1.Controls.Add(btnLista3);
            flowLayoutPanel1.Controls.Add(btnMostrarTodos);
            flowLayoutPanel1.Controls.Add(btnLiquidados);
            flowLayoutPanel1.Location = new Point(553, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(423, 159);
            flowLayoutPanel1.TabIndex = 20;
            // 
            // btnLista1
            // 
            btnLista1.Anchor = AnchorStyles.Top;
            btnLista1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLista1.BackColor = Color.DarkSlateGray;
            btnLista1.BackgroundColor = Color.DarkSlateGray;
            btnLista1.BorderColor = Color.DarkSlateGray;
            btnLista1.BorderRadius = 15;
            btnLista1.BorderSize = 2;
            btnLista1.FlatAppearance.BorderSize = 0;
            btnLista1.FlatStyle = FlatStyle.Flat;
            btnLista1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLista1.ForeColor = Color.Transparent;
            btnLista1.Location = new Point(3, 4);
            btnLista1.Margin = new Padding(3, 4, 3, 4);
            btnLista1.Name = "btnLista1";
            btnLista1.Size = new Size(127, 73);
            btnLista1.TabIndex = 0;
            btnLista1.Text = "Lista 1:\r\nIniciación";
            btnLista1.TextColor = Color.Transparent;
            btnLista1.UseVisualStyleBackColor = false;
            btnLista1.Click += BtnLista1_Click;
            // 
            // btnLista2
            // 
            btnLista2.Anchor = AnchorStyles.Top;
            btnLista2.BackColor = Color.Teal;
            btnLista2.BackgroundColor = Color.Teal;
            btnLista2.BorderColor = Color.Teal;
            btnLista2.BorderRadius = 15;
            btnLista2.BorderSize = 2;
            btnLista2.FlatAppearance.BorderSize = 0;
            btnLista2.FlatStyle = FlatStyle.Flat;
            btnLista2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLista2.ForeColor = Color.Transparent;
            btnLista2.Location = new Point(136, 4);
            btnLista2.Margin = new Padding(3, 4, 3, 4);
            btnLista2.Name = "btnLista2";
            btnLista2.Size = new Size(127, 73);
            btnLista2.TabIndex = 1;
            btnLista2.Text = "Lista 2:\r\nExtrajudicial";
            btnLista2.TextColor = Color.Transparent;
            btnLista2.UseVisualStyleBackColor = false;
            btnLista2.Click += BtnLista2_Click;
            // 
            // btnLista3
            // 
            btnLista3.Anchor = AnchorStyles.Top;
            btnLista3.BackColor = Color.SteelBlue;
            btnLista3.BackgroundColor = Color.SteelBlue;
            btnLista3.BorderColor = Color.SteelBlue;
            btnLista3.BorderRadius = 15;
            btnLista3.BorderSize = 2;
            btnLista3.FlatAppearance.BorderSize = 0;
            btnLista3.FlatStyle = FlatStyle.Flat;
            btnLista3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLista3.ForeColor = Color.Transparent;
            btnLista3.Location = new Point(269, 4);
            btnLista3.Margin = new Padding(3, 4, 3, 4);
            btnLista3.Name = "btnLista3";
            btnLista3.Size = new Size(145, 73);
            btnLista3.TabIndex = 2;
            btnLista3.Text = "Lista 3:\r\nDemanda legal";
            btnLista3.TextColor = Color.Transparent;
            btnLista3.UseVisualStyleBackColor = false;
            btnLista3.Click += BtnLista3_Click;
            // 
            // btnMostrarTodos
            // 
            btnMostrarTodos.Anchor = AnchorStyles.Top;
            btnMostrarTodos.BackColor = Color.DarkSlateGray;
            btnMostrarTodos.BackgroundColor = Color.DarkSlateGray;
            btnMostrarTodos.BorderColor = Color.DarkSlateGray;
            btnMostrarTodos.BorderRadius = 15;
            btnMostrarTodos.BorderSize = 2;
            btnMostrarTodos.FlatAppearance.BorderSize = 0;
            btnMostrarTodos.FlatStyle = FlatStyle.Flat;
            btnMostrarTodos.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMostrarTodos.ForeColor = Color.Transparent;
            btnMostrarTodos.Location = new Point(3, 85);
            btnMostrarTodos.Margin = new Padding(3, 4, 3, 4);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(127, 75);
            btnMostrarTodos.TabIndex = 14;
            btnMostrarTodos.Text = "Mostrar\r\ntodos";
            btnMostrarTodos.TextColor = Color.Transparent;
            btnMostrarTodos.UseVisualStyleBackColor = false;
            btnMostrarTodos.Click += BtnMostrarTodos_Click;
            // 
            // btnLiquidados
            // 
            btnLiquidados.Anchor = AnchorStyles.Top;
            btnLiquidados.BackColor = Color.Teal;
            btnLiquidados.BackgroundColor = Color.Teal;
            btnLiquidados.BorderColor = Color.Teal;
            btnLiquidados.BorderRadius = 15;
            btnLiquidados.BorderSize = 2;
            btnLiquidados.FlatAppearance.BorderSize = 0;
            btnLiquidados.FlatStyle = FlatStyle.Flat;
            btnLiquidados.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLiquidados.ForeColor = Color.Transparent;
            btnLiquidados.Location = new Point(136, 85);
            btnLiquidados.Margin = new Padding(3, 4, 3, 4);
            btnLiquidados.Name = "btnLiquidados";
            btnLiquidados.Size = new Size(127, 71);
            btnLiquidados.TabIndex = 15;
            btnLiquidados.Text = "Clientes\r\nliquidados";
            btnLiquidados.TextColor = Color.Transparent;
            btnLiquidados.UseVisualStyleBackColor = false;
            btnLiquidados.Click += BtnLiquidados_Click;
            // 
            // gridListas
            // 
            gridListas.AllowUserToAddRows = false;
            gridListas.AllowUserToDeleteRows = false;
            gridListas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            gridListas.EnableHeadersVisualStyles = false;
            gridListas.GridColor = Color.CadetBlue;
            gridListas.Location = new Point(18, 169);
            gridListas.Margin = new Padding(3, 4, 3, 4);
            gridListas.Name = "gridListas";
            gridListas.ReadOnly = true;
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
            gridListas.Size = new Size(937, 389);
            gridListas.TabIndex = 16;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(323, 19);
            label8.Name = "label8";
            label8.Size = new Size(214, 29);
            label8.TabIndex = 13;
            label8.Text = "Seleccione la lista:";
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 40;
            bunifuElipse1.TargetControl = pictureBox1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 741);
            Controls.Add(pnlListas);
            Controls.Add(pnlClientes);
            Controls.Add(pnlRegPago);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FutureLending";
            MaximumSizeChanged += Form1_MaximumSizeChanged;
            FormClosed += Form1_FormClosed;
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            pnlRegPago.ResumeLayout(false);
            pnlRegPago.PerformLayout();
            pnlClientes.ResumeLayout(false);
            pnlClientes.PerformLayout();
            pnlListas.ResumeLayout(false);
            pnlListas.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridListas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelTitleBar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnMenu;
        private FontAwesome.Sharp.IconButton btnIngresarClientes;
        private FontAwesome.Sharp.IconButton btnListas;
        private FontAwesome.Sharp.IconButton btnEstadoPagos;
        private FontAwesome.Sharp.IconButton btnTodosSistemas;
        private Label lblTitle;
        private Panel pnlListas;
        private Controles_personalizados.RJButton btnLista1;
        private Controles_personalizados.RJButton btnLista3;
        private Controles_personalizados.RJButton btnLista2;
        private Label label8;
        private Controles_personalizados.RJButton btnLiquidados;
        private Controles_personalizados.RJButton btnMostrarTodos;
        private Panel pnlRegPago;
        private Label label1;
        private Controles_personalizados.TextBoxPersonalizado txtNombre;
        private Label label2;
        private Controles_personalizados.TextBoxPersonalizado txtCredito;
        private Label label3;
        private Controles_personalizados.DateTimePickerPersonalizado dateFechaInicio;
        private Label label4;
        private Label label5;
        private ControlesPersonalizados.RJComboBox cmbTipo;
        private Label label6;
        private ControlesPersonalizados.RJComboBox cmbPromotor;
        private Label label7;
        private Controles_personalizados.RJButton btnGuardar;
        private Label label9;
        private Label label10;
        private Controles_personalizados.TextBoxPersonalizado txtCalle;
        private Label label11;
        private Controles_personalizados.TextBoxPersonalizado txtColonia;
        private Label label12;
        private Controles_personalizados.TextBoxPersonalizado txtNumInt;
        private Label label13;
        private Controles_personalizados.TextBoxPersonalizado txtNumExt;
        private Label label14;
        private Controles_personalizados.TextBoxPersonalizado txtTelefono;
        private Label label15;
        private Controles_personalizados.TextBoxPersonalizado txtCorreo;
        private Controles_personalizados.TextBoxPersonalizado txtTotal;
        private Label label16;
        private Controles_personalizados.TextBoxPersonalizado txtTotal_I;
        private Panel pnlClientes;
        private Controles_personalizados.RJButton btnCalcular;
        private DataGridView gridListas;
        private ControlesPersonalizados.RJComboBox cmbInteres;
        private FlowLayoutPanel flowLayoutPanel1;
        private ControlesPersonalizados.RJComboBox ComBoxName;
        private ControlesPersonalizados.RJComboBox CombBoxLista;
        private Label label29;
        private Controles_personalizados.RJButton btnBuscarC;
        private Label label17;
        private Label lblFecha;
        private Controles_personalizados.TextBoxPersonalizado txtBoxCredito;
        private Label lblCredito;
        private Controles_personalizados.TextBoxPersonalizado txtBoxMonto;
        private Controles_personalizados.RJButton btnMarcarP;
        private Label lblMonto;
        private Controles_personalizados.DateTimePickerPersonalizado DateTimeReg;
        private FlowLayoutPanel flowLayoutPanel2;
        private ControlesPersonalizados.RJComboBox cmbCliente;
        private Controles_personalizados.RJButton btnEditar;
        private Controles_personalizados.RJButton btnEliminar;
        private FlowLayoutPanel flowLayoutPanel3;
        private Controles_personalizados.RJButton rjButton1;
        private ControlesPersonalizados.RJComboBox rjComboBox2;
        private Label label18;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}