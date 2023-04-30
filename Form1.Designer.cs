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
            panelDesktop = new Panel();
            textBoxPersonalizado6 = new Controles_personalizados.TextBoxPersonalizado();
            label10 = new Label();
            textBoxPersonalizado5 = new Controles_personalizados.TextBoxPersonalizado();
            label9 = new Label();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            textBoxPersonalizado4 = new Controles_personalizados.TextBoxPersonalizado();
            textBoxPersonalizado3 = new Controles_personalizados.TextBoxPersonalizado();
            label8 = new Label();
            label7 = new Label();
            textBoxPersonalizado2 = new Controles_personalizados.TextBoxPersonalizado();
            label6 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            comboBox1 = new ComboBox();
            label5 = new Label();
            textBoxPersonalizado1 = new Controles_personalizados.TextBoxPersonalizado();
            label4 = new Label();
            dateFechaInicio = new Controles_personalizados.DateTimePickerPersonalizado();
            label3 = new Label();
            txtCredito = new Controles_personalizados.TextBoxPersonalizado();
            label2 = new Label();
            txtNombre = new Controles_personalizados.TextBoxPersonalizado();
            label1 = new Label();
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelTitleBar.SuspendLayout();
            panelDesktop.SuspendLayout();
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
            panelMenu.Size = new Size(263, 631);
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
            btnReparar.Location = new Point(0, 559);
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
            panelTitleBar.BackColor = Color.Thistle;
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(263, 0);
            panelTitleBar.Margin = new Padding(3, 4, 3, 4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(651, 80);
            panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Elephant", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.ForeColor = SystemColors.Desktop;
            lblTitle.Location = new Point(46, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(433, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Ingresar Clientes";
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = SystemColors.Info;
            panelDesktop.Controls.Add(textBoxPersonalizado6);
            panelDesktop.Controls.Add(label10);
            panelDesktop.Controls.Add(textBoxPersonalizado5);
            panelDesktop.Controls.Add(label9);
            panelDesktop.Controls.Add(iconButton2);
            panelDesktop.Controls.Add(textBoxPersonalizado4);
            panelDesktop.Controls.Add(textBoxPersonalizado3);
            panelDesktop.Controls.Add(label8);
            panelDesktop.Controls.Add(label7);
            panelDesktop.Controls.Add(textBoxPersonalizado2);
            panelDesktop.Controls.Add(label6);
            panelDesktop.Controls.Add(iconButton1);
            panelDesktop.Controls.Add(comboBox1);
            panelDesktop.Controls.Add(label5);
            panelDesktop.Controls.Add(textBoxPersonalizado1);
            panelDesktop.Controls.Add(label4);
            panelDesktop.Controls.Add(dateFechaInicio);
            panelDesktop.Controls.Add(label3);
            panelDesktop.Controls.Add(txtCredito);
            panelDesktop.Controls.Add(label2);
            panelDesktop.Controls.Add(txtNombre);
            panelDesktop.Controls.Add(label1);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(263, 80);
            panelDesktop.Margin = new Padding(3, 4, 3, 4);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(651, 551);
            panelDesktop.TabIndex = 2;
            panelDesktop.Paint += panelDesktop_Paint;
            // 
            // textBoxPersonalizado6
            // 
            textBoxPersonalizado6.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado6.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado6.BorderRadius = 0;
            textBoxPersonalizado6.BorderSize = 2;
            textBoxPersonalizado6.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPersonalizado6.Location = new Point(381, 416);
            textBoxPersonalizado6.Margin = new Padding(3, 4, 3, 4);
            textBoxPersonalizado6.Multiline = false;
            textBoxPersonalizado6.Name = "textBoxPersonalizado6";
            textBoxPersonalizado6.Padding = new Padding(11, 9, 11, 9);
            textBoxPersonalizado6.PasswordChar = false;
            textBoxPersonalizado6.PlaceholderColor = Color.Gray;
            textBoxPersonalizado6.PlaceholderText = "Monto + Interés";
            textBoxPersonalizado6.Size = new Size(147, 39);
            textBoxPersonalizado6.TabIndex = 20;
            textBoxPersonalizado6.Texts = "";
            textBoxPersonalizado6.UnderlinedStyle = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(347, 429);
            label10.Name = "label10";
            label10.Size = new Size(28, 26);
            label10.TabIndex = 19;
            label10.Text = " =";
            // 
            // textBoxPersonalizado5
            // 
            textBoxPersonalizado5.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado5.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado5.BorderRadius = 0;
            textBoxPersonalizado5.BorderSize = 2;
            textBoxPersonalizado5.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPersonalizado5.Location = new Point(297, 482);
            textBoxPersonalizado5.Margin = new Padding(3, 4, 3, 4);
            textBoxPersonalizado5.Multiline = false;
            textBoxPersonalizado5.Name = "textBoxPersonalizado5";
            textBoxPersonalizado5.Padding = new Padding(11, 9, 11, 9);
            textBoxPersonalizado5.PasswordChar = false;
            textBoxPersonalizado5.PlaceholderColor = Color.Gray;
            textBoxPersonalizado5.PlaceholderText = "";
            textBoxPersonalizado5.Size = new Size(126, 39);
            textBoxPersonalizado5.TabIndex = 18;
            textBoxPersonalizado5.Texts = "";
            textBoxPersonalizado5.UnderlinedStyle = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(18, 495);
            label9.Name = "label9";
            label9.Size = new Size(278, 26);
            label9.TabIndex = 17;
            label9.Text = "Monto segun tipo de pago:";
            label9.Click += label9_Click;
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 2;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton2.IconColor = Color.Black;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(537, 421);
            iconButton2.Margin = new Padding(3, 4, 3, 4);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(84, 33);
            iconButton2.TabIndex = 16;
            iconButton2.Text = "Calcular";
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // textBoxPersonalizado4
            // 
            textBoxPersonalizado4.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado4.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado4.BorderRadius = 0;
            textBoxPersonalizado4.BorderSize = 2;
            textBoxPersonalizado4.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPersonalizado4.Location = new Point(244, 415);
            textBoxPersonalizado4.Margin = new Padding(3, 4, 3, 4);
            textBoxPersonalizado4.Multiline = false;
            textBoxPersonalizado4.Name = "textBoxPersonalizado4";
            textBoxPersonalizado4.Padding = new Padding(11, 9, 11, 9);
            textBoxPersonalizado4.PasswordChar = false;
            textBoxPersonalizado4.PlaceholderColor = Color.Gray;
            textBoxPersonalizado4.PlaceholderText = "Interés";
            textBoxPersonalizado4.Size = new Size(97, 39);
            textBoxPersonalizado4.TabIndex = 15;
            textBoxPersonalizado4.Texts = "";
            textBoxPersonalizado4.UnderlinedStyle = true;
            // 
            // textBoxPersonalizado3
            // 
            textBoxPersonalizado3.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado3.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado3.BorderRadius = 0;
            textBoxPersonalizado3.BorderSize = 2;
            textBoxPersonalizado3.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPersonalizado3.Location = new Point(209, 260);
            textBoxPersonalizado3.Margin = new Padding(3, 4, 3, 4);
            textBoxPersonalizado3.Multiline = false;
            textBoxPersonalizado3.Name = "textBoxPersonalizado3";
            textBoxPersonalizado3.Padding = new Padding(11, 9, 11, 9);
            textBoxPersonalizado3.PasswordChar = false;
            textBoxPersonalizado3.PlaceholderColor = Color.Gray;
            textBoxPersonalizado3.PlaceholderText = "Ingrese el nombre";
            textBoxPersonalizado3.Size = new Size(401, 45);
            textBoxPersonalizado3.TabIndex = 7;
            textBoxPersonalizado3.Texts = "";
            textBoxPersonalizado3.UnderlinedStyle = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Indigo;
            label8.Location = new Point(198, 475);
            label8.Name = "label8";
            label8.Size = new Size(0, 20);
            label8.TabIndex = 14;
            label8.Click += label8_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(210, 428);
            label7.Name = "label7";
            label7.Size = new Size(28, 26);
            label7.TabIndex = 13;
            label7.Text = " =";
            label7.Click += label7_Click;
            // 
            // textBoxPersonalizado2
            // 
            textBoxPersonalizado2.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado2.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado2.BorderRadius = 0;
            textBoxPersonalizado2.BorderSize = 2;
            textBoxPersonalizado2.Font = new Font("Berlin Sans FB", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPersonalizado2.Location = new Point(100, 415);
            textBoxPersonalizado2.Margin = new Padding(3, 4, 3, 4);
            textBoxPersonalizado2.Multiline = false;
            textBoxPersonalizado2.Name = "textBoxPersonalizado2";
            textBoxPersonalizado2.Padding = new Padding(11, 9, 11, 9);
            textBoxPersonalizado2.PasswordChar = false;
            textBoxPersonalizado2.PlaceholderColor = Color.Gray;
            textBoxPersonalizado2.PlaceholderText = "Porcentaje";
            textBoxPersonalizado2.Size = new Size(104, 39);
            textBoxPersonalizado2.TabIndex = 12;
            textBoxPersonalizado2.Texts = "";
            textBoxPersonalizado2.UnderlinedStyle = true;
            textBoxPersonalizado2._TextChanged += textBoxPersonalizado2__TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(18, 428);
            label6.Name = "label6";
            label6.Size = new Size(83, 26);
            label6.TabIndex = 11;
            label6.Text = "Interés:";
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 2;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(512, 500);
            iconButton1.Margin = new Padding(3, 4, 3, 4);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(136, 35);
            iconButton1.TabIndex = 10;
            iconButton1.Text = "Guardar";
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Semanales", "Quincenales" });
            comboBox1.Location = new Point(209, 348);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(346, 28);
            comboBox1.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(18, 348);
            label5.Name = "label5";
            label5.Size = new Size(148, 26);
            label5.TabIndex = 8;
            label5.Text = "Tipo de pago:";
            // 
            // textBoxPersonalizado1
            // 
            textBoxPersonalizado1.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado1.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado1.BorderRadius = 0;
            textBoxPersonalizado1.BorderSize = 2;
            textBoxPersonalizado1.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPersonalizado1.Location = new Point(209, 260);
            textBoxPersonalizado1.Margin = new Padding(3, 4, 3, 4);
            textBoxPersonalizado1.Multiline = false;
            textBoxPersonalizado1.Name = "textBoxPersonalizado1";
            textBoxPersonalizado1.Padding = new Padding(11, 9, 11, 9);
            textBoxPersonalizado1.PasswordChar = false;
            textBoxPersonalizado1.PlaceholderColor = Color.Gray;
            textBoxPersonalizado1.PlaceholderText = "Ingrese el nombre";
            textBoxPersonalizado1.Size = new Size(401, 45);
            textBoxPersonalizado1.TabIndex = 7;
            textBoxPersonalizado1.Texts = "";
            textBoxPersonalizado1.UnderlinedStyle = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(18, 268);
            label4.Name = "label4";
            label4.Size = new Size(112, 26);
            label4.TabIndex = 6;
            label4.Text = "Promotor:";
            // 
            // dateFechaInicio
            // 
            dateFechaInicio.BorderColor = Color.DarkSlateGray;
            dateFechaInicio.BorderSize = 2;
            dateFechaInicio.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
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
            label3.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(18, 188);
            label3.Name = "label3";
            label3.Size = new Size(164, 26);
            label3.TabIndex = 4;
            label3.Text = "Fecha de inicio:";
            // 
            // txtCredito
            // 
            txtCredito.BorderColor = Color.DarkSlateGray;
            txtCredito.BorderFocusColor = SystemColors.Info;
            txtCredito.BorderRadius = 0;
            txtCredito.BorderSize = 2;
            txtCredito.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCredito.Location = new Point(209, 100);
            txtCredito.Margin = new Padding(3, 4, 3, 4);
            txtCredito.Multiline = false;
            txtCredito.Name = "txtCredito";
            txtCredito.Padding = new Padding(11, 9, 11, 9);
            txtCredito.PasswordChar = false;
            txtCredito.PlaceholderColor = Color.Gray;
            txtCredito.PlaceholderText = "Introduzca monto total";
            txtCredito.Size = new Size(401, 45);
            txtCredito.TabIndex = 3;
            txtCredito.Texts = "";
            txtCredito.UnderlinedStyle = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(18, 108);
            label2.Name = "label2";
            label2.Size = new Size(183, 26);
            label2.TabIndex = 2;
            label2.Text = "Crédito prestado:";
            // 
            // txtNombre
            // 
            txtNombre.BorderColor = Color.DarkSlateGray;
            txtNombre.BorderFocusColor = SystemColors.Info;
            txtNombre.BorderRadius = 0;
            txtNombre.BorderSize = 2;
            txtNombre.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(209, 20);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Multiline = false;
            txtNombre.Name = "txtNombre";
            txtNombre.Padding = new Padding(11, 9, 11, 9);
            txtNombre.PasswordChar = false;
            txtNombre.PlaceholderColor = Color.Gray;
            txtNombre.PlaceholderText = "Introduzca el nombre";
            txtNombre.Size = new Size(401, 45);
            txtNombre.TabIndex = 1;
            txtNombre.Texts = "";
            txtNombre.UnderlinedStyle = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Berlin Sans FB", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 28);
            label1.Name = "label1";
            label1.Size = new Size(198, 26);
            label1.TabIndex = 0;
            label1.Text = "Nombre completo:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 631);
            Controls.Add(panelDesktop);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "FutureLending";
            Load += Form1_Load;
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelDesktop.ResumeLayout(false);
            panelDesktop.PerformLayout();
            ResumeLayout(false);
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
        private Controles_personalizados.TextBoxPersonalizado textBoxPersonalizado1;
        private Label label4;
        private Label label5;
        private ComboBox comboBox1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Label label6;
        private Controles_personalizados.TextBoxPersonalizado textBoxPersonalizado2;
        private Label label7;
        private Label label8;
        private Controles_personalizados.TextBoxPersonalizado textBoxPersonalizado3;
        private Controles_personalizados.TextBoxPersonalizado textBoxPersonalizado4;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Label label9;
        private Controles_personalizados.TextBoxPersonalizado textBoxPersonalizado5;
        private Controles_personalizados.TextBoxPersonalizado textBoxPersonalizado6;
        private Label label10;
    }
}