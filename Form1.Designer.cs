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
            label18 = new Label();
            CombBoxLista = new ControlesPersonalizados.RJComboBox();
            label17 = new Label();
            btnMarcarP = new Controles_personalizados.RJButton();
            DateTimeReg = new Controles_personalizados.DateTimePickerPersonalizado();
            lblFecha = new Label();
            txtBoxMonto = new Controles_personalizados.TextBoxPersonalizado();
            lblMonto = new Label();
            lblCredito = new Label();
            txtBoxCredito = new Controles_personalizados.TextBoxPersonalizado();
            ComBoxName = new ControlesPersonalizados.RJComboBox();
            btnBuscarC = new Controles_personalizados.RJButton();
            label29 = new Label();
            pnlListas = new Panel();
            gridListas = new DataGridView();
            btnEliminar = new Controles_personalizados.RJButton();
            btnEditar = new Controles_personalizados.RJButton();
            btnLiquidados = new Controles_personalizados.RJButton();
            btnMostrarTodos = new Controles_personalizados.RJButton();
            label8 = new Label();
            btnLista3 = new Controles_personalizados.RJButton();
            btnLista2 = new Controles_personalizados.RJButton();
            btnLista1 = new Controles_personalizados.RJButton();
            label1 = new Label();
            txtNombre = new Controles_personalizados.TextBoxPersonalizado();
            label2 = new Label();
            txtCredito = new Controles_personalizados.TextBoxPersonalizado();
            label3 = new Label();
            dateFechaInicio = new Controles_personalizados.DateTimePickerPersonalizado();
            label4 = new Label();
            label5 = new Label();
            cmbTipo = new ControlesPersonalizados.RJComboBox();
            label6 = new Label();
            cmbPromotor = new ControlesPersonalizados.RJComboBox();
            label7 = new Label();
            btnGuardar = new Controles_personalizados.RJButton();
            label9 = new Label();
            label10 = new Label();
            txtCalle = new Controles_personalizados.TextBoxPersonalizado();
            label11 = new Label();
            txtColonia = new Controles_personalizados.TextBoxPersonalizado();
            label12 = new Label();
            txtNumInt = new Controles_personalizados.TextBoxPersonalizado();
            label13 = new Label();
            txtNumExt = new Controles_personalizados.TextBoxPersonalizado();
            label14 = new Label();
            txtTelefono = new Controles_personalizados.TextBoxPersonalizado();
            label15 = new Label();
            txtCorreo = new Controles_personalizados.TextBoxPersonalizado();
            textBoxPersonalizado1 = new Controles_personalizados.TextBoxPersonalizado();
            label16 = new Label();
            textBoxPersonalizado2 = new Controles_personalizados.TextBoxPersonalizado();
            pnlClientes = new Panel();
            cmbInteres = new ControlesPersonalizados.RJComboBox();
            btnCalcular = new Controles_personalizados.RJButton();
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            pnlRegPago.SuspendLayout();
            pnlListas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridListas).BeginInit();
            pnlClientes.SuspendLayout();
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
            panelMenu.Size = new Size(263, 749);
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
            btnTodosSistemas.Location = new Point(0, 668);
            btnTodosSistemas.Margin = new Padding(3, 4, 3, 4);
            btnTodosSistemas.Name = "btnTodosSistemas";
            btnTodosSistemas.Padding = new Padding(11, 0, 0, 0);
            btnTodosSistemas.Size = new Size(263, 81);
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
            btnEstadoPagos.Click += btnEstadoPagos_Click;
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
            // pnlRegPago
            // 
            pnlRegPago.BackColor = SystemColors.Info;
            pnlRegPago.Controls.Add(label18);
            pnlRegPago.Controls.Add(CombBoxLista);
            pnlRegPago.Controls.Add(label17);
            pnlRegPago.Controls.Add(btnMarcarP);
            pnlRegPago.Controls.Add(DateTimeReg);
            pnlRegPago.Controls.Add(lblFecha);
            pnlRegPago.Controls.Add(txtBoxMonto);
            pnlRegPago.Controls.Add(lblMonto);
            pnlRegPago.Controls.Add(lblCredito);
            pnlRegPago.Controls.Add(txtBoxCredito);
            pnlRegPago.Controls.Add(ComBoxName);
            pnlRegPago.Controls.Add(btnBuscarC);
            pnlRegPago.Controls.Add(label29);
            pnlRegPago.Dock = DockStyle.Fill;
            pnlRegPago.Location = new Point(263, 80);
            pnlRegPago.Margin = new Padding(3, 4, 3, 4);
            pnlRegPago.Name = "pnlRegPago";
            pnlRegPago.Size = new Size(979, 669);
            pnlRegPago.TabIndex = 27;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(685, 467);
            label18.Name = "label18";
            label18.Size = new Size(152, 29);
            label18.TabIndex = 36;
            label18.Text = "Tipo de lista:";
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
            CombBoxLista.Location = new Point(295, 152);
            CombBoxLista.Margin = new Padding(3, 4, 3, 4);
            CombBoxLista.MinimumSize = new Size(229, 40);
            CombBoxLista.Name = "CombBoxLista";
            CombBoxLista.Padding = new Padding(2, 3, 2, 3);
            CombBoxLista.Size = new Size(341, 63);
            CombBoxLista.TabIndex = 35;
            CombBoxLista.Texts = "Introduzca lista";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(18, 167);
            label17.Name = "label17";
            label17.Size = new Size(152, 29);
            label17.TabIndex = 34;
            label17.Text = "Tipo de lista:";
            // 
            // btnMarcarP
            // 
            btnMarcarP.BackColor = SystemColors.Info;
            btnMarcarP.BackgroundColor = SystemColors.Info;
            btnMarcarP.BorderColor = Color.DarkSlateGray;
            btnMarcarP.BorderRadius = 10;
            btnMarcarP.BorderSize = 2;
            btnMarcarP.FlatAppearance.BorderSize = 0;
            btnMarcarP.FlatStyle = FlatStyle.Flat;
            btnMarcarP.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnMarcarP.ForeColor = Color.Black;
            btnMarcarP.Location = new Point(349, 540);
            btnMarcarP.Margin = new Padding(3, 4, 3, 4);
            btnMarcarP.Name = "btnMarcarP";
            btnMarcarP.Size = new Size(277, 53);
            btnMarcarP.TabIndex = 33;
            btnMarcarP.Text = "Marcar como pagada";
            btnMarcarP.TextColor = Color.Black;
            btnMarcarP.UseVisualStyleBackColor = false;
            btnMarcarP.Visible = false;
            btnMarcarP.Click += btnMarcarP_Click;
            // 
            // DateTimeReg
            // 
            DateTimeReg.BorderColor = Color.DarkSlateGray;
            DateTimeReg.BorderSize = 2;
            DateTimeReg.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            DateTimeReg.Format = DateTimePickerFormat.Short;
            DateTimeReg.Location = new Point(295, 460);
            DateTimeReg.Margin = new Padding(3, 4, 3, 4);
            DateTimeReg.MinimumSize = new Size(4, 35);
            DateTimeReg.Name = "DateTimeReg";
            DateTimeReg.Size = new Size(172, 35);
            DateTimeReg.SkinColor = SystemColors.Info;
            DateTimeReg.TabIndex = 32;
            DateTimeReg.TextColor = Color.Black;
            DateTimeReg.Visible = false;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFecha.Location = new Point(18, 467);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(200, 29);
            lblFecha.TabIndex = 31;
            lblFecha.Text = "Fecha a registrar:";
            lblFecha.Visible = false;
            // 
            // txtBoxMonto
            // 
            txtBoxMonto.BorderColor = Color.DarkSlateGray;
            txtBoxMonto.BorderFocusColor = SystemColors.Info;
            txtBoxMonto.BorderRadius = 0;
            txtBoxMonto.BorderSize = 2;
            txtBoxMonto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxMonto.Location = new Point(295, 357);
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
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblMonto.Location = new Point(18, 367);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(294, 29);
            lblMonto.TabIndex = 29;
            lblMonto.Text = "Monto semanal/quincenal:";
            lblMonto.Visible = false;
            // 
            // lblCredito
            // 
            lblCredito.AutoSize = true;
            lblCredito.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblCredito.Location = new Point(18, 267);
            lblCredito.Name = "lblCredito";
            lblCredito.Size = new Size(199, 29);
            lblCredito.TabIndex = 28;
            lblCredito.Text = "Crédito prestado:";
            lblCredito.Visible = false;
            // 
            // txtBoxCredito
            // 
            txtBoxCredito.BorderColor = Color.DarkSlateGray;
            txtBoxCredito.BorderFocusColor = SystemColors.Info;
            txtBoxCredito.BorderRadius = 0;
            txtBoxCredito.BorderSize = 2;
            txtBoxCredito.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxCredito.Location = new Point(295, 257);
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
            ComBoxName.Location = new Point(295, 51);
            ComBoxName.Margin = new Padding(3, 4, 3, 4);
            ComBoxName.MinimumSize = new Size(229, 40);
            ComBoxName.Name = "ComBoxName";
            ComBoxName.Padding = new Padding(2, 3, 2, 3);
            ComBoxName.Size = new Size(385, 65);
            ComBoxName.TabIndex = 14;
            ComBoxName.Texts = "Introduzca nombre";
            // 
            // btnBuscarC
            // 
            btnBuscarC.BackColor = SystemColors.Info;
            btnBuscarC.BackgroundColor = SystemColors.Info;
            btnBuscarC.BorderColor = Color.DarkSlateGray;
            btnBuscarC.BorderRadius = 10;
            btnBuscarC.BorderSize = 2;
            btnBuscarC.FlatAppearance.BorderSize = 0;
            btnBuscarC.FlatStyle = FlatStyle.Flat;
            btnBuscarC.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnBuscarC.ForeColor = Color.Black;
            btnBuscarC.Location = new Point(749, 159);
            btnBuscarC.Margin = new Padding(3, 4, 3, 4);
            btnBuscarC.Name = "btnBuscarC";
            btnBuscarC.Size = new Size(135, 48);
            btnBuscarC.TabIndex = 13;
            btnBuscarC.Text = "Buscar";
            btnBuscarC.TextColor = Color.Black;
            btnBuscarC.UseVisualStyleBackColor = false;
            btnBuscarC.Click += btnBuscarC_Click;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label29.Location = new Point(18, 67);
            label29.Name = "label29";
            label29.Size = new Size(224, 29);
            label29.TabIndex = 0;
            label29.Text = "Nombre del cliente:";
            // 
            // pnlListas
            // 
            pnlListas.BackColor = SystemColors.Info;
            pnlListas.Controls.Add(gridListas);
            pnlListas.Controls.Add(btnEliminar);
            pnlListas.Controls.Add(btnEditar);
            pnlListas.Controls.Add(btnLiquidados);
            pnlListas.Controls.Add(btnMostrarTodos);
            pnlListas.Controls.Add(label8);
            pnlListas.Controls.Add(btnLista3);
            pnlListas.Controls.Add(btnLista2);
            pnlListas.Controls.Add(btnLista1);
            pnlListas.Dock = DockStyle.Fill;
            pnlListas.Location = new Point(263, 80);
            pnlListas.Margin = new Padding(3, 4, 3, 4);
            pnlListas.Name = "pnlListas";
            pnlListas.Size = new Size(979, 669);
            pnlListas.TabIndex = 14;
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
            gridListas.EnableHeadersVisualStyles = false;
            gridListas.GridColor = Color.CadetBlue;
            gridListas.Location = new Point(18, 169);
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
            btnEliminar.Location = new Point(829, 571);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(127, 67);
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
            btnEditar.Location = new Point(686, 571);
            btnEditar.Margin = new Padding(3, 4, 3, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(127, 68);
            btnEditar.TabIndex = 18;
            btnEditar.Text = "Editar\r\ncliente\r\n";
            btnEditar.TextColor = Color.Transparent;
            btnEditar.UseVisualStyleBackColor = false;
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
            btnLiquidados.Location = new Point(827, 91);
            btnLiquidados.Margin = new Padding(3, 4, 3, 4);
            btnLiquidados.Name = "btnLiquidados";
            btnLiquidados.Size = new Size(127, 71);
            btnLiquidados.TabIndex = 15;
            btnLiquidados.Text = "Clientes\r\nliquidados";
            btnLiquidados.TextColor = Color.Transparent;
            btnLiquidados.UseVisualStyleBackColor = false;
            btnLiquidados.Click += btnLiquidados_Click;
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
            btnMostrarTodos.Location = new Point(686, 88);
            btnMostrarTodos.Margin = new Padding(3, 4, 3, 4);
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.Size = new Size(127, 75);
            btnMostrarTodos.TabIndex = 14;
            btnMostrarTodos.Text = "Mostrar\r\ntodos";
            btnMostrarTodos.TextColor = Color.Transparent;
            btnMostrarTodos.UseVisualStyleBackColor = false;
            btnMostrarTodos.Click += btnMostrarTodos_Click;
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
            btnLista3.Size = new Size(145, 73);
            btnLista3.TabIndex = 2;
            btnLista3.Text = "Lista 3:\r\nDemanda legal";
            btnLista3.TextColor = Color.Transparent;
            btnLista3.UseVisualStyleBackColor = false;
            btnLista3.Click += btnLista3_Click;
            // 
            // btnLista2
            // 
            btnLista2.BackColor = Color.Teal;
            btnLista2.BackgroundColor = Color.Teal;
            btnLista2.BorderColor = Color.Teal;
            btnLista2.BorderRadius = 15;
            btnLista2.BorderSize = 2;
            btnLista2.FlatAppearance.BorderSize = 0;
            btnLista2.FlatStyle = FlatStyle.Flat;
            btnLista2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLista2.ForeColor = Color.Transparent;
            btnLista2.Location = new Point(685, 13);
            btnLista2.Margin = new Padding(3, 4, 3, 4);
            btnLista2.Name = "btnLista2";
            btnLista2.Size = new Size(127, 73);
            btnLista2.TabIndex = 1;
            btnLista2.Text = "Lista 2:\r\nExtrajudicial";
            btnLista2.TextColor = Color.Transparent;
            btnLista2.UseVisualStyleBackColor = false;
            btnLista2.Click += btnLista2_Click;
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
            btnLista1.Size = new Size(127, 73);
            btnLista1.TabIndex = 0;
            btnLista1.Text = "Lista 1:\r\nIniciación";
            btnLista1.TextColor = Color.Transparent;
            btnLista1.UseVisualStyleBackColor = false;
            btnLista1.Click += btnLista1_Click;
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
            cmbTipo.Texts = "Seleccione un tipo de pago";
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
            cmbPromotor.Items.AddRange(new object[] { "Roberto la nalgona", "Ramona la vergiona" });
            cmbPromotor.ListBackColor = SystemColors.Info;
            cmbPromotor.ListTextColor = Color.DimGray;
            cmbPromotor.Location = new Point(224, 397);
            cmbPromotor.Margin = new Padding(3, 4, 3, 4);
            cmbPromotor.MinimumSize = new Size(229, 40);
            cmbPromotor.Name = "cmbPromotor";
            cmbPromotor.Padding = new Padding(2, 3, 2, 3);
            cmbPromotor.Size = new Size(361, 53);
            cmbPromotor.TabIndex = 6;
            cmbPromotor.Texts = "Seleccione al promotor";
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
            btnGuardar.Location = new Point(715, 587);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(171, 53);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextColor = Color.Black;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(655, 29);
            label9.Name = "label9";
            label9.Size = new Size(121, 29);
            label9.TabIndex = 14;
            label9.Text = "Dirección:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(655, 72);
            label10.Name = "label10";
            label10.Size = new Size(75, 29);
            label10.TabIndex = 15;
            label10.Text = "Calle:";
            // 
            // txtCalle
            // 
            txtCalle.BorderColor = Color.DarkSlateGray;
            txtCalle.BorderFocusColor = SystemColors.Info;
            txtCalle.BorderRadius = 0;
            txtCalle.BorderSize = 2;
            txtCalle.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCalle.Location = new Point(655, 105);
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
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(651, 172);
            label11.Name = "label11";
            label11.Size = new Size(102, 29);
            label11.TabIndex = 17;
            label11.Text = "Colonia:";
            // 
            // txtColonia
            // 
            txtColonia.BorderColor = Color.DarkSlateGray;
            txtColonia.BorderFocusColor = SystemColors.Info;
            txtColonia.BorderRadius = 0;
            txtColonia.BorderSize = 2;
            txtColonia.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtColonia.Location = new Point(651, 205);
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
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(651, 271);
            label12.Name = "label12";
            label12.Size = new Size(113, 29);
            label12.TabIndex = 19;
            label12.Text = "Núm. int.:";
            // 
            // txtNumInt
            // 
            txtNumInt.BorderColor = Color.DarkSlateGray;
            txtNumInt.BorderFocusColor = SystemColors.Info;
            txtNumInt.BorderRadius = 0;
            txtNumInt.BorderSize = 2;
            txtNumInt.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNumInt.Location = new Point(651, 304);
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
            txtNumExt.TabIndex = 11;
            txtNumExt.Texts = "";
            txtNumExt.UnderlinedStyle = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(655, 371);
            label14.Name = "label14";
            label14.Size = new Size(116, 29);
            label14.TabIndex = 23;
            label14.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.BorderColor = Color.DarkSlateGray;
            txtTelefono.BorderFocusColor = SystemColors.Info;
            txtTelefono.BorderRadius = 0;
            txtTelefono.BorderSize = 2;
            txtTelefono.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.Location = new Point(651, 404);
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
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(651, 472);
            label15.Name = "label15";
            label15.Size = new Size(219, 29);
            label15.TabIndex = 25;
            label15.Text = "Correo electrónico:";
            // 
            // txtCorreo
            // 
            txtCorreo.BorderColor = Color.DarkSlateGray;
            txtCorreo.BorderFocusColor = SystemColors.Info;
            txtCorreo.BorderRadius = 0;
            txtCorreo.BorderSize = 2;
            txtCorreo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCorreo.Location = new Point(651, 505);
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
            // 
            // textBoxPersonalizado1
            // 
            textBoxPersonalizado1.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado1.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado1.BorderRadius = 0;
            textBoxPersonalizado1.BorderSize = 2;
            textBoxPersonalizado1.Enabled = false;
            textBoxPersonalizado1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPersonalizado1.Location = new Point(295, 471);
            textBoxPersonalizado1.Margin = new Padding(3, 4, 3, 4);
            textBoxPersonalizado1.Multiline = false;
            textBoxPersonalizado1.Name = "textBoxPersonalizado1";
            textBoxPersonalizado1.Padding = new Padding(11, 9, 11, 9);
            textBoxPersonalizado1.PasswordChar = false;
            textBoxPersonalizado1.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado1.PlaceholderText = "";
            textBoxPersonalizado1.Size = new Size(159, 48);
            textBoxPersonalizado1.TabIndex = 27;
            textBoxPersonalizado1.Texts = "";
            textBoxPersonalizado1.UnderlinedStyle = true;
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
            // textBoxPersonalizado2
            // 
            textBoxPersonalizado2.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado2.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado2.BorderRadius = 0;
            textBoxPersonalizado2.BorderSize = 2;
            textBoxPersonalizado2.Enabled = false;
            textBoxPersonalizado2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPersonalizado2.Location = new Point(295, 541);
            textBoxPersonalizado2.Margin = new Padding(3, 4, 3, 4);
            textBoxPersonalizado2.Multiline = false;
            textBoxPersonalizado2.Name = "textBoxPersonalizado2";
            textBoxPersonalizado2.Padding = new Padding(11, 9, 11, 9);
            textBoxPersonalizado2.PasswordChar = false;
            textBoxPersonalizado2.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado2.PlaceholderText = "";
            textBoxPersonalizado2.Size = new Size(159, 48);
            textBoxPersonalizado2.TabIndex = 29;
            textBoxPersonalizado2.Texts = "";
            textBoxPersonalizado2.UnderlinedStyle = true;
            // 
            // pnlClientes
            // 
            pnlClientes.BackColor = SystemColors.Info;
            pnlClientes.Controls.Add(cmbInteres);
            pnlClientes.Controls.Add(btnCalcular);
            pnlClientes.Controls.Add(textBoxPersonalizado2);
            pnlClientes.Controls.Add(label16);
            pnlClientes.Controls.Add(textBoxPersonalizado1);
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
            pnlClientes.Location = new Point(0, 0);
            pnlClientes.Margin = new Padding(3, 4, 3, 4);
            pnlClientes.Name = "pnlClientes";
            pnlClientes.Size = new Size(1242, 749);
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
            cmbInteres.Texts = "Seleccione un interés";
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = SystemColors.Info;
            btnCalcular.BackgroundColor = SystemColors.Info;
            btnCalcular.BorderColor = Color.DarkSlateGray;
            btnCalcular.BorderRadius = 10;
            btnCalcular.BorderSize = 2;
            btnCalcular.FlatAppearance.BorderSize = 0;
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalcular.ForeColor = Color.Black;
            btnCalcular.Location = new Point(461, 593);
            btnCalcular.Margin = new Padding(3, 4, 3, 4);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(151, 40);
            btnCalcular.TabIndex = 7;
            btnCalcular.Text = "Calcular";
            btnCalcular.TextColor = Color.Black;
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1242, 749);
            Controls.Add(pnlRegPago);
            Controls.Add(pnlListas);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Controls.Add(pnlClientes);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "FutureLending";
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            pnlRegPago.ResumeLayout(false);
            pnlRegPago.PerformLayout();
            pnlListas.ResumeLayout(false);
            pnlListas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridListas).EndInit();
            pnlClientes.ResumeLayout(false);
            pnlClientes.PerformLayout();
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
        private Controles_personalizados.RJButton btnEliminar;
        private Controles_personalizados.RJButton btnEditar;
        private Panel pnlRegPago;
        private Controles_personalizados.RJButton btnBuscarC;
        private Label label29;
        private ControlesPersonalizados.RJComboBox ComBoxName;
        private Label lblCredito;
        private Controles_personalizados.TextBoxPersonalizado txtBoxCredito;
        private Label lblFecha;
        private Controles_personalizados.TextBoxPersonalizado txtBoxMonto;
        private Label lblMonto;
        private Controles_personalizados.RJButton btnMarcarP;
        private Controles_personalizados.DateTimePickerPersonalizado DateTimeReg;
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
        private Controles_personalizados.TextBoxPersonalizado textBoxPersonalizado1;
        private Label label16;
        private Controles_personalizados.TextBoxPersonalizado textBoxPersonalizado2;
        private Panel pnlClientes;
        private Controles_personalizados.RJButton btnCalcular;
        private DataGridView gridListas;
        private ControlesPersonalizados.RJComboBox CombBoxLista;
        private Label label17;
        private Label label18;
        private ControlesPersonalizados.RJComboBox cmbInteres;
    }
}