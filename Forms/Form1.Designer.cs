using System.ComponentModel;
using Bunifu.Framework.UI;
using FontAwesome.Sharp;
using FutureLending.Controles_personalizados;
using FutureLending.ControlesPersonalizados;

namespace FutureLending.Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelMenu = new Panel();
            iconButton2 = new IconButton();
            iconButton1 = new IconButton();
            btnTodosSistemas = new IconButton();
            btnEstadoPagos = new IconButton();
            btnListas = new IconButton();
            btnIngresarClientes = new IconButton();
            panel1 = new Panel();
            btnMenu = new IconButton();
            pictureBox1 = new PictureBox();
            PnlEditar2 = new Panel();
            btnEditarFechas2 = new RjButton();
            btnGuardarC = new RjButton();
            TextBoxQuita = new TextBoxPersonalizado();
            label70 = new Label();
            TextBoxLiquidacionIntencion = new TextBoxPersonalizado();
            label68 = new Label();
            TextBoxPagare = new TextBoxPersonalizado();
            label67 = new Label();
            TextBoxRestante = new TextBoxPersonalizado();
            label69 = new Label();
            LabelPertenece = new Label();
            label72 = new Label();
            groupBox2 = new GroupBox();
            btnMover3 = new RjButton();
            CmbLista2 = new RjComboBox();
            TextBoxCorreo = new TextBoxPersonalizado();
            label73 = new Label();
            TextBoxTelefono = new TextBoxPersonalizado();
            label74 = new Label();
            TextBoxNumExt = new TextBoxPersonalizado();
            label75 = new Label();
            TextBoxNumInt = new TextBoxPersonalizado();
            label76 = new Label();
            TextBoxColonia = new TextBoxPersonalizado();
            label77 = new Label();
            TextBoxCalle = new TextBoxPersonalizado();
            label78 = new Label();
            label79 = new Label();
            rjComboBox7 = new RjComboBox();
            label80 = new Label();
            TextBoxCredito = new TextBoxPersonalizado();
            label83 = new Label();
            TextBoxNombre = new TextBoxPersonalizado();
            label84 = new Label();
            rjComboBox8 = new RjComboBox();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            pnlRegPago = new Panel();
            Monto_Recomendado = new TextBoxPersonalizado();
            label82 = new Label();
            TextBoxRestantepagos = new TextBoxPersonalizado();
            label17 = new Label();
            rjComboBox9 = new RjComboBox();
            ComBoxName = new RjComboBox();
            label29 = new Label();
            btnBuscarC = new RjButton();
            lblFecha = new Label();
            txtBoxCredito = new TextBoxPersonalizado();
            lblCredito = new Label();
            txtBoxMonto = new TextBoxPersonalizado();
            btnMarcarP = new RjButton();
            lblMonto = new Label();
            pnlClientes = new Panel();
            label87 = new Label();
            btnCalcular1 = new RjButton();
            btnGuardar1 = new RjButton();
            dateTimePickerPersonalizado2 = new DateTimePickerPersonalizado();
            label65 = new Label();
            cmbInteres = new RjComboBox();
            txtTotal_I = new TextBoxPersonalizado();
            label16 = new Label();
            txtTotal = new TextBoxPersonalizado();
            txtCorreo = new TextBoxPersonalizado();
            label15 = new Label();
            txtTelefono = new TextBoxPersonalizado();
            label14 = new Label();
            txtNumExt = new TextBoxPersonalizado();
            label13 = new Label();
            txtNumInt = new TextBoxPersonalizado();
            label12 = new Label();
            txtColonia = new TextBoxPersonalizado();
            label11 = new Label();
            txtCalle = new TextBoxPersonalizado();
            label10 = new Label();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            cmbTipo = new RjComboBox();
            label5 = new Label();
            label4 = new Label();
            dateFechaInicio = new DateTimePickerPersonalizado();
            label3 = new Label();
            txtCredito = new TextBoxPersonalizado();
            label2 = new Label();
            txtNombre = new TextBoxPersonalizado();
            label1 = new Label();
            cmbPromotor = new RjComboBox();
            PanelEditar3 = new Panel();
            btnGuardar2 = new RjButton();
            ResolucionDemanda = new RjComboBox();
            groupBox3 = new GroupBox();
            btnMover2 = new RjButton();
            rjComboBox5 = new RjComboBox();
            TextImporte3 = new TextBoxPersonalizado();
            label103 = new Label();
            label92 = new Label();
            TextBoxPagare3 = new TextBoxPersonalizado();
            label81 = new Label();
            LabelLista3 = new Label();
            label94 = new Label();
            TextBoxCorreo3 = new TextBoxPersonalizado();
            label95 = new Label();
            TextBoxTelefono3 = new TextBoxPersonalizado();
            label96 = new Label();
            TextBoxNumExt3 = new TextBoxPersonalizado();
            label97 = new Label();
            TextBoxNumInt3 = new TextBoxPersonalizado();
            label98 = new Label();
            TextBoxColonia3 = new TextBoxPersonalizado();
            label99 = new Label();
            TextBoxCalle3 = new TextBoxPersonalizado();
            label100 = new Label();
            label101 = new Label();
            ComboBoxResolucion3 = new RjComboBox();
            label102 = new Label();
            TextBoxCredito3 = new TextBoxPersonalizado();
            label105 = new Label();
            TextBoxNombre3 = new TextBoxPersonalizado();
            LabelNombre3 = new Label();
            ComboBoxPromotor3 = new RjComboBox();
            pnlListas = new Panel();
            labelDineroAire = new Label();
            flowLayoutPanel5 = new FlowLayoutPanel();
            ComboBoxPromotoresListas = new RjComboBox();
            label57 = new Label();
            BarradeProgreso = new ProgressBar();
            flowLayoutPanel3 = new FlowLayoutPanel();
            cmbCliente = new RjComboBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnEditar = new RjButton();
            btnEliminar = new RjButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnLista1 = new RjButton();
            btnLista2 = new RjButton();
            btnLista3 = new RjButton();
            btnMostrarTodos = new RjButton();
            btnLiquidados = new RjButton();
            rjButton1 = new RjButton();
            gridListas = new DataGridView();
            label8 = new Label();
            PanelEditar = new Panel();
            BtnGuardarCambio = new RjButton();
            textBoxPersonalizado11 = new TextBoxPersonalizado();
            label66 = new Label();
            dateTimeLimite = new DateTimePickerPersonalizado();
            LabelLimite = new Label();
            textBoxPersonalizado7 = new TextBoxPersonalizado();
            label25 = new Label();
            textBoxPersonalizado8 = new TextBoxPersonalizado();
            label27 = new Label();
            LblPerte = new Label();
            label26 = new Label();
            groupBox1 = new GroupBox();
            BtnMover = new RjButton();
            cmbLista = new RjComboBox();
            textBoxPersonalizado1 = new TextBoxPersonalizado();
            label18 = new Label();
            textBoxPersonalizado2 = new TextBoxPersonalizado();
            label20 = new Label();
            textBoxPersonalizado3 = new TextBoxPersonalizado();
            label21 = new Label();
            textBoxPersonalizado4 = new TextBoxPersonalizado();
            label22 = new Label();
            textBoxPersonalizado5 = new TextBoxPersonalizado();
            label23 = new Label();
            textBoxPersonalizado6 = new TextBoxPersonalizado();
            label24 = new Label();
            rjComboBox1 = new RjComboBox();
            label28 = new Label();
            rjComboBox2 = new RjComboBox();
            label30 = new Label();
            label31 = new Label();
            dateTimePickerPersonalizado1 = new DateTimePickerPersonalizado();
            label32 = new Label();
            textBoxPersonalizado9 = new TextBoxPersonalizado();
            label33 = new Label();
            textBoxPersonalizado10 = new TextBoxPersonalizado();
            label34 = new Label();
            rjComboBox3 = new RjComboBox();
            bunifuElipse1 = new BunifuElipse(components);
            PanelBien = new Panel();
            label58 = new Label();
            label56 = new Label();
            label55 = new Label();
            label54 = new Label();
            label53 = new Label();
            label52 = new Label();
            label19 = new Label();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label35 = new Label();
            label36 = new Label();
            textBox1 = new TextBox();
            label37 = new Label();
            TextboxContr = new TextBox();
            label38 = new Label();
            TextboxConfirm = new TextBox();
            checkBox1 = new CheckBox();
            Button1 = new RjButton();
            AvisoVacio = new Label();
            flowLayoutPanel6 = new FlowLayoutPanel();
            label39 = new Label();
            label40 = new Label();
            comboBox1 = new RjComboBox();
            Boton_Permisos = new RjButton();
            label41 = new Label();
            textBox2 = new TextBox();
            label42 = new Label();
            textBox3 = new TextBox();
            checkBox2 = new CheckBox();
            panel3 = new Panel();
            rjButton11 = new RjButton();
            rjButton12 = new RjButton();
            Conexion_Sql = new TabPage();
            PingLabel = new Label();
            rjButton3 = new RjButton();
            LabelEstado = new Label();
            label51 = new Label();
            rjButton2 = new RjButton();
            checkBox3 = new CheckBox();
            label50 = new Label();
            label49 = new Label();
            TextContra = new TextBox();
            TextUsuario = new TextBox();
            TextBase = new TextBox();
            TextPuerto = new TextBox();
            TextServer = new TextBox();
            label48 = new Label();
            label47 = new Label();
            label46 = new Label();
            label45 = new Label();
            label44 = new Label();
            label43 = new Label();
            tabPage2 = new TabPage();
            rjButton6 = new RjButton();
            rjButton5 = new RjButton();
            rjButton4 = new RjButton();
            label64 = new Label();
            textBox5 = new TextBox();
            rjComboBox4 = new RjComboBox();
            label62 = new Label();
            label63 = new Label();
            textBox4 = new TextBox();
            label61 = new Label();
            label60 = new Label();
            label59 = new Label();
            PanelEditar2_2 = new Panel();
            rjButton7 = new RjButton();
            BotonVolverEditar2 = new RjButton();
            Botoncambiodefechamomentaneo = new RjButton();
            TextBoxPagoExt = new TextBoxPersonalizado();
            label93 = new Label();
            LabelNombreEditar2_2 = new Label();
            label89 = new Label();
            TextBoxPago = new TextBoxPersonalizado();
            label86 = new Label();
            label85 = new Label();
            FechaEnLista2 = new DateTimePickerPersonalizado();
            label71 = new Label();
            ComboBoxDeFechas = new RjComboBox();
            backgroundWorker1 = new BackgroundWorker();
            backgroundWorker2 = new BackgroundWorker();
            PanelEditarLiquidados = new Panel();
            BottonLiq = new RjButton();
            FechaInicioLiq = new DateTimePickerPersonalizado();
            label91 = new Label();
            label90 = new Label();
            ComBoBoxLiquidacion = new RjComboBox();
            label104 = new Label();
            label106 = new Label();
            TextCorreoLiq = new TextBoxPersonalizado();
            label107 = new Label();
            TextTelefonoLiq = new TextBoxPersonalizado();
            label108 = new Label();
            TextNumExtLiq = new TextBoxPersonalizado();
            label109 = new Label();
            TextNumIntLiq = new TextBoxPersonalizado();
            label110 = new Label();
            TextColoniaLiq = new TextBoxPersonalizado();
            label111 = new Label();
            TextCalleLiq = new TextBoxPersonalizado();
            label112 = new Label();
            label113 = new Label();
            TextCreditoLiq = new TextBoxPersonalizado();
            label115 = new Label();
            TextNombreLiq = new TextBoxPersonalizado();
            label116 = new Label();
            ComboBoxPromotorLiq = new RjComboBox();
            panelMenu.SuspendLayout();
            panel1.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            PnlEditar2.SuspendLayout();
            groupBox2.SuspendLayout();
            panelTitleBar.SuspendLayout();
            pnlRegPago.SuspendLayout();
            pnlClientes.SuspendLayout();
            PanelEditar3.SuspendLayout();
            groupBox3.SuspendLayout();
            pnlListas.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)gridListas).BeginInit();
            PanelEditar.SuspendLayout();
            groupBox1.SuspendLayout();
            PanelBien.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            panel3.SuspendLayout();
            Conexion_Sql.SuspendLayout();
            tabPage2.SuspendLayout();
            PanelEditar2_2.SuspendLayout();
            PanelEditarLiquidados.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            resources.ApplyResources(panelMenu, "panelMenu");
            panelMenu.BackColor = Color.LightSlateGray;
            panelMenu.Controls.Add(iconButton2);
            panelMenu.Controls.Add(iconButton1);
            panelMenu.Controls.Add(btnTodosSistemas);
            panelMenu.Controls.Add(btnEstadoPagos);
            panelMenu.Controls.Add(btnListas);
            panelMenu.Controls.Add(btnIngresarClientes);
            panelMenu.Controls.Add(panel1);
            panelMenu.Name = "panelMenu";
            // 
            // iconButton2
            // 
            resources.ApplyResources(iconButton2, "iconButton2");
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.ForeColor = Color.White;
            iconButton2.IconChar = IconChar.DoorOpen;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = IconFont.Auto;
            iconButton2.Name = "iconButton2";
            iconButton2.Tag = "Cerrar Sesión";
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // iconButton1
            // 
            resources.ApplyResources(iconButton1, "iconButton1");
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.ForeColor = Color.White;
            iconButton1.IconChar = IconChar.Computer;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = IconFont.Auto;
            iconButton1.Name = "iconButton1";
            iconButton1.Tag = "Configuración";
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += IconButton1_Click;
            // 
            // btnTodosSistemas
            // 
            resources.ApplyResources(btnTodosSistemas, "btnTodosSistemas");
            btnTodosSistemas.FlatAppearance.BorderSize = 0;
            btnTodosSistemas.ForeColor = Color.White;
            btnTodosSistemas.IconChar = IconChar.Wrench;
            btnTodosSistemas.IconColor = Color.White;
            btnTodosSistemas.IconFont = IconFont.Auto;
            btnTodosSistemas.Name = "btnTodosSistemas";
            btnTodosSistemas.Tag = "Reparar";
            btnTodosSistemas.UseVisualStyleBackColor = true;
            btnTodosSistemas.Click += BtnTodosSistemas_Click;
            // 
            // btnEstadoPagos
            // 
            resources.ApplyResources(btnEstadoPagos, "btnEstadoPagos");
            btnEstadoPagos.FlatAppearance.BorderSize = 0;
            btnEstadoPagos.ForeColor = Color.White;
            btnEstadoPagos.IconChar = IconChar.MoneyCheckDollar;
            btnEstadoPagos.IconColor = Color.White;
            btnEstadoPagos.IconFont = IconFont.Auto;
            btnEstadoPagos.Name = "btnEstadoPagos";
            btnEstadoPagos.Tag = "  Estado de pagos";
            btnEstadoPagos.UseVisualStyleBackColor = true;
            btnEstadoPagos.Click += BtnEstadoPagos_Click;
            // 
            // btnListas
            // 
            resources.ApplyResources(btnListas, "btnListas");
            btnListas.FlatAppearance.BorderSize = 0;
            btnListas.ForeColor = Color.White;
            btnListas.IconChar = IconChar.ListNumeric;
            btnListas.IconColor = Color.White;
            btnListas.IconFont = IconFont.Auto;
            btnListas.Name = "btnListas";
            btnListas.Tag = "  Listas completas";
            btnListas.UseVisualStyleBackColor = true;
            btnListas.Click += BtnListas_Click;
            // 
            // btnIngresarClientes
            // 
            resources.ApplyResources(btnIngresarClientes, "btnIngresarClientes");
            btnIngresarClientes.FlatAppearance.BorderSize = 0;
            btnIngresarClientes.ForeColor = Color.White;
            btnIngresarClientes.IconChar = IconChar.AddressCard;
            btnIngresarClientes.IconColor = Color.White;
            btnIngresarClientes.IconFont = IconFont.Auto;
            btnIngresarClientes.Name = "btnIngresarClientes";
            btnIngresarClientes.Tag = "   Ingresar clientes";
            btnIngresarClientes.UseVisualStyleBackColor = true;
            btnIngresarClientes.Click += BtnIngresarClientes_Click;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(btnMenu);
            panel1.Controls.Add(pictureBox1);
            panel1.Name = "panel1";
            // 
            // btnMenu
            // 
            resources.ApplyResources(btnMenu, "btnMenu");
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.IconChar = IconChar.Navicon;
            btnMenu.IconColor = Color.White;
            btnMenu.IconFont = IconFont.Auto;
            btnMenu.IconSize = 30;
            btnMenu.Name = "btnMenu";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += BtnMenu_Click;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // PnlEditar2
            // 
            resources.ApplyResources(PnlEditar2, "PnlEditar2");
            PnlEditar2.BackColor = SystemColors.ButtonHighlight;
            PnlEditar2.Controls.Add(btnEditarFechas2);
            PnlEditar2.Controls.Add(btnGuardarC);
            PnlEditar2.Controls.Add(TextBoxQuita);
            PnlEditar2.Controls.Add(label70);
            PnlEditar2.Controls.Add(TextBoxLiquidacionIntencion);
            PnlEditar2.Controls.Add(label68);
            PnlEditar2.Controls.Add(TextBoxPagare);
            PnlEditar2.Controls.Add(label67);
            PnlEditar2.Controls.Add(TextBoxRestante);
            PnlEditar2.Controls.Add(label69);
            PnlEditar2.Controls.Add(LabelPertenece);
            PnlEditar2.Controls.Add(label72);
            PnlEditar2.Controls.Add(groupBox2);
            PnlEditar2.Controls.Add(TextBoxCorreo);
            PnlEditar2.Controls.Add(label73);
            PnlEditar2.Controls.Add(TextBoxTelefono);
            PnlEditar2.Controls.Add(label74);
            PnlEditar2.Controls.Add(TextBoxNumExt);
            PnlEditar2.Controls.Add(label75);
            PnlEditar2.Controls.Add(TextBoxNumInt);
            PnlEditar2.Controls.Add(label76);
            PnlEditar2.Controls.Add(TextBoxColonia);
            PnlEditar2.Controls.Add(label77);
            PnlEditar2.Controls.Add(TextBoxCalle);
            PnlEditar2.Controls.Add(label78);
            PnlEditar2.Controls.Add(label79);
            PnlEditar2.Controls.Add(rjComboBox7);
            PnlEditar2.Controls.Add(label80);
            PnlEditar2.Controls.Add(TextBoxCredito);
            PnlEditar2.Controls.Add(label83);
            PnlEditar2.Controls.Add(TextBoxNombre);
            PnlEditar2.Controls.Add(label84);
            PnlEditar2.Controls.Add(rjComboBox8);
            PnlEditar2.Name = "PnlEditar2";
            // 
            // btnEditarFechas2
            // 
            resources.ApplyResources(btnEditarFechas2, "btnEditarFechas2");
            btnEditarFechas2.BackColor = SystemColors.ActiveCaption;
            btnEditarFechas2.BackgroundColor = SystemColors.ActiveCaption;
            btnEditarFechas2.BorderColor = SystemColors.ActiveCaption;
            btnEditarFechas2.BorderRadius = 15;
            btnEditarFechas2.BorderSize = 2;
            btnEditarFechas2.FlatAppearance.BorderSize = 0;
            btnEditarFechas2.ForeColor = Color.Transparent;
            btnEditarFechas2.Name = "btnEditarFechas2";
            btnEditarFechas2.TextColor = Color.Transparent;
            btnEditarFechas2.UseVisualStyleBackColor = false;
            btnEditarFechas2.Click += btnEditarFechas2_Click;
            // 
            // btnGuardarC
            // 
            resources.ApplyResources(btnGuardarC, "btnGuardarC");
            btnGuardarC.BackColor = Color.SteelBlue;
            btnGuardarC.BackgroundColor = Color.SteelBlue;
            btnGuardarC.BorderColor = Color.SteelBlue;
            btnGuardarC.BorderRadius = 15;
            btnGuardarC.BorderSize = 2;
            btnGuardarC.FlatAppearance.BorderSize = 0;
            btnGuardarC.ForeColor = Color.Transparent;
            btnGuardarC.Name = "btnGuardarC";
            btnGuardarC.TextColor = Color.Transparent;
            btnGuardarC.UseVisualStyleBackColor = false;
            btnGuardarC.Click += btnGuardarC_Click;
            // 
            // TextBoxQuita
            // 
            resources.ApplyResources(TextBoxQuita, "TextBoxQuita");
            TextBoxQuita.BorderColor = Color.DarkSlateGray;
            TextBoxQuita.BorderFocusColor = SystemColors.Info;
            TextBoxQuita.BorderRadius = 0;
            TextBoxQuita.BorderSize = 2;
            TextBoxQuita.Multiline = false;
            TextBoxQuita.Name = "TextBoxQuita";
            TextBoxQuita.PasswordChar = false;
            TextBoxQuita.PlaceholderColor = Color.DimGray;
            TextBoxQuita.PlaceholderText = "";
            TextBoxQuita.Texts = "";
            TextBoxQuita.UnderlinedStyle = true;
            TextBoxQuita.KeyPress += TextBoxQuita_KeyPress;
            // 
            // label70
            // 
            resources.ApplyResources(label70, "label70");
            label70.ForeColor = Color.DarkSlateGray;
            label70.Name = "label70";
            // 
            // TextBoxLiquidacionIntencion
            // 
            resources.ApplyResources(TextBoxLiquidacionIntencion, "TextBoxLiquidacionIntencion");
            TextBoxLiquidacionIntencion.BorderColor = Color.DarkSlateGray;
            TextBoxLiquidacionIntencion.BorderFocusColor = SystemColors.Info;
            TextBoxLiquidacionIntencion.BorderRadius = 0;
            TextBoxLiquidacionIntencion.BorderSize = 2;
            TextBoxLiquidacionIntencion.Multiline = false;
            TextBoxLiquidacionIntencion.Name = "TextBoxLiquidacionIntencion";
            TextBoxLiquidacionIntencion.PasswordChar = false;
            TextBoxLiquidacionIntencion.PlaceholderColor = Color.DimGray;
            TextBoxLiquidacionIntencion.PlaceholderText = "";
            TextBoxLiquidacionIntencion.Texts = "";
            TextBoxLiquidacionIntencion.UnderlinedStyle = true;
            TextBoxLiquidacionIntencion.KeyPress += TextBoxLiquidacionIntencion_KeyPress;
            // 
            // label68
            // 
            resources.ApplyResources(label68, "label68");
            label68.ForeColor = Color.DarkSlateGray;
            label68.Name = "label68";
            // 
            // TextBoxPagare
            // 
            resources.ApplyResources(TextBoxPagare, "TextBoxPagare");
            TextBoxPagare.BorderColor = Color.DarkSlateGray;
            TextBoxPagare.BorderFocusColor = SystemColors.Info;
            TextBoxPagare.BorderRadius = 0;
            TextBoxPagare.BorderSize = 2;
            TextBoxPagare.Multiline = false;
            TextBoxPagare.Name = "TextBoxPagare";
            TextBoxPagare.PasswordChar = false;
            TextBoxPagare.PlaceholderColor = Color.DimGray;
            TextBoxPagare.PlaceholderText = "";
            TextBoxPagare.Texts = "";
            TextBoxPagare.UnderlinedStyle = true;
            TextBoxPagare.KeyPress += TextBoxPagare_KeyPress;
            // 
            // label67
            // 
            resources.ApplyResources(label67, "label67");
            label67.ForeColor = Color.DarkSlateGray;
            label67.Name = "label67";
            // 
            // TextBoxRestante
            // 
            resources.ApplyResources(TextBoxRestante, "TextBoxRestante");
            TextBoxRestante.BorderColor = Color.DarkSlateGray;
            TextBoxRestante.BorderFocusColor = SystemColors.Info;
            TextBoxRestante.BorderRadius = 0;
            TextBoxRestante.BorderSize = 2;
            TextBoxRestante.Multiline = false;
            TextBoxRestante.Name = "TextBoxRestante";
            TextBoxRestante.PasswordChar = false;
            TextBoxRestante.PlaceholderColor = Color.DimGray;
            TextBoxRestante.PlaceholderText = "";
            TextBoxRestante.Texts = "";
            TextBoxRestante.UnderlinedStyle = true;
            TextBoxRestante.KeyPress += TextBoxRestante_KeyPress;
            // 
            // label69
            // 
            resources.ApplyResources(label69, "label69");
            label69.ForeColor = Color.DarkSlateGray;
            label69.Name = "label69";
            // 
            // LabelPertenece
            // 
            resources.ApplyResources(LabelPertenece, "LabelPertenece");
            LabelPertenece.ForeColor = Color.DarkSlateGray;
            LabelPertenece.Name = "LabelPertenece";
            // 
            // label72
            // 
            resources.ApplyResources(label72, "label72");
            label72.ForeColor = Color.DarkSlateGray;
            label72.Name = "label72";
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(btnMover3);
            groupBox2.Controls.Add(CmbLista2);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // btnMover3
            // 
            resources.ApplyResources(btnMover3, "btnMover3");
            btnMover3.BackColor = Color.IndianRed;
            btnMover3.BackgroundColor = Color.IndianRed;
            btnMover3.BorderColor = SystemColors.ActiveCaption;
            btnMover3.BorderRadius = 15;
            btnMover3.BorderSize = 2;
            btnMover3.FlatAppearance.BorderSize = 0;
            btnMover3.ForeColor = Color.Transparent;
            btnMover3.Name = "btnMover3";
            btnMover3.TextColor = Color.Transparent;
            btnMover3.UseVisualStyleBackColor = false;
            btnMover3.Click += btnMover3_Click;
            // 
            // CmbLista2
            // 
            resources.ApplyResources(CmbLista2, "CmbLista2");
            CmbLista2.AutoCompleteMode = AutoCompleteMode.Suggest;
            CmbLista2.AutoCompleteSource = AutoCompleteSource.ListItems;
            CmbLista2.BackColor = SystemColors.ButtonHighlight;
            CmbLista2.BorderColor = Color.DarkSlateGray;
            CmbLista2.BorderSize = 3;
            CmbLista2.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbLista2.ForeColor = Color.Black;
            CmbLista2.IconColor = Color.DarkSlateGray;
            CmbLista2.ListBackColor = SystemColors.ButtonHighlight;
            CmbLista2.ListTextColor = Color.DimGray;
            CmbLista2.Name = "CmbLista2";
            CmbLista2.Tag = "Selecciones un tipo de pago";
            CmbLista2.Texts = "Seleccione una lista";
            CmbLista2.OnSelectedIndexChanged += CmbLista2_OnSelectedIndexChanged;
            // 
            // TextBoxCorreo
            // 
            resources.ApplyResources(TextBoxCorreo, "TextBoxCorreo");
            TextBoxCorreo.BorderColor = Color.DarkSlateGray;
            TextBoxCorreo.BorderFocusColor = SystemColors.Info;
            TextBoxCorreo.BorderRadius = 0;
            TextBoxCorreo.BorderSize = 2;
            TextBoxCorreo.Multiline = false;
            TextBoxCorreo.Name = "TextBoxCorreo";
            TextBoxCorreo.PasswordChar = false;
            TextBoxCorreo.PlaceholderColor = Color.DimGray;
            TextBoxCorreo.PlaceholderText = "";
            TextBoxCorreo.Texts = "";
            TextBoxCorreo.UnderlinedStyle = true;
            // 
            // label73
            // 
            resources.ApplyResources(label73, "label73");
            label73.ForeColor = Color.DarkSlateGray;
            label73.Name = "label73";
            // 
            // TextBoxTelefono
            // 
            resources.ApplyResources(TextBoxTelefono, "TextBoxTelefono");
            TextBoxTelefono.BorderColor = Color.DarkSlateGray;
            TextBoxTelefono.BorderFocusColor = SystemColors.Info;
            TextBoxTelefono.BorderRadius = 0;
            TextBoxTelefono.BorderSize = 2;
            TextBoxTelefono.Multiline = false;
            TextBoxTelefono.Name = "TextBoxTelefono";
            TextBoxTelefono.PasswordChar = false;
            TextBoxTelefono.PlaceholderColor = Color.DimGray;
            TextBoxTelefono.PlaceholderText = "";
            TextBoxTelefono.Texts = "";
            TextBoxTelefono.UnderlinedStyle = true;
            TextBoxTelefono.KeyPress += TextBoxTelefono_KeyPress;
            // 
            // label74
            // 
            resources.ApplyResources(label74, "label74");
            label74.ForeColor = Color.DarkSlateGray;
            label74.Name = "label74";
            // 
            // TextBoxNumExt
            // 
            resources.ApplyResources(TextBoxNumExt, "TextBoxNumExt");
            TextBoxNumExt.BorderColor = Color.DarkSlateGray;
            TextBoxNumExt.BorderFocusColor = SystemColors.Info;
            TextBoxNumExt.BorderRadius = 0;
            TextBoxNumExt.BorderSize = 2;
            TextBoxNumExt.Multiline = false;
            TextBoxNumExt.Name = "TextBoxNumExt";
            TextBoxNumExt.PasswordChar = false;
            TextBoxNumExt.PlaceholderColor = Color.DimGray;
            TextBoxNumExt.PlaceholderText = "";
            TextBoxNumExt.Texts = "";
            TextBoxNumExt.UnderlinedStyle = true;
            TextBoxNumExt.KeyPress += TextBoxNumExt_KeyPress;
            // 
            // label75
            // 
            resources.ApplyResources(label75, "label75");
            label75.ForeColor = Color.DarkSlateGray;
            label75.Name = "label75";
            // 
            // TextBoxNumInt
            // 
            resources.ApplyResources(TextBoxNumInt, "TextBoxNumInt");
            TextBoxNumInt.BorderColor = Color.DarkSlateGray;
            TextBoxNumInt.BorderFocusColor = SystemColors.Info;
            TextBoxNumInt.BorderRadius = 0;
            TextBoxNumInt.BorderSize = 2;
            TextBoxNumInt.Multiline = false;
            TextBoxNumInt.Name = "TextBoxNumInt";
            TextBoxNumInt.PasswordChar = false;
            TextBoxNumInt.PlaceholderColor = Color.DimGray;
            TextBoxNumInt.PlaceholderText = "";
            TextBoxNumInt.Texts = "";
            TextBoxNumInt.UnderlinedStyle = true;
            TextBoxNumInt.KeyPress += TextBoxNumInt_KeyPress;
            // 
            // label76
            // 
            resources.ApplyResources(label76, "label76");
            label76.ForeColor = Color.DarkSlateGray;
            label76.Name = "label76";
            // 
            // TextBoxColonia
            // 
            resources.ApplyResources(TextBoxColonia, "TextBoxColonia");
            TextBoxColonia.BorderColor = Color.DarkSlateGray;
            TextBoxColonia.BorderFocusColor = SystemColors.Info;
            TextBoxColonia.BorderRadius = 0;
            TextBoxColonia.BorderSize = 2;
            TextBoxColonia.Multiline = false;
            TextBoxColonia.Name = "TextBoxColonia";
            TextBoxColonia.PasswordChar = false;
            TextBoxColonia.PlaceholderColor = Color.DimGray;
            TextBoxColonia.PlaceholderText = "";
            TextBoxColonia.Texts = "";
            TextBoxColonia.UnderlinedStyle = true;
            // 
            // label77
            // 
            resources.ApplyResources(label77, "label77");
            label77.ForeColor = Color.DarkSlateGray;
            label77.Name = "label77";
            // 
            // TextBoxCalle
            // 
            resources.ApplyResources(TextBoxCalle, "TextBoxCalle");
            TextBoxCalle.BorderColor = Color.DarkSlateGray;
            TextBoxCalle.BorderFocusColor = SystemColors.Info;
            TextBoxCalle.BorderRadius = 0;
            TextBoxCalle.BorderSize = 2;
            TextBoxCalle.Multiline = false;
            TextBoxCalle.Name = "TextBoxCalle";
            TextBoxCalle.PasswordChar = false;
            TextBoxCalle.PlaceholderColor = Color.DimGray;
            TextBoxCalle.PlaceholderText = "";
            TextBoxCalle.Texts = "";
            TextBoxCalle.UnderlinedStyle = true;
            // 
            // label78
            // 
            resources.ApplyResources(label78, "label78");
            label78.ForeColor = Color.DarkSlateGray;
            label78.Name = "label78";
            // 
            // label79
            // 
            resources.ApplyResources(label79, "label79");
            label79.ForeColor = Color.DarkSlateGray;
            label79.Name = "label79";
            // 
            // rjComboBox7
            // 
            resources.ApplyResources(rjComboBox7, "rjComboBox7");
            rjComboBox7.AutoCompleteMode = AutoCompleteMode.Suggest;
            rjComboBox7.AutoCompleteSource = AutoCompleteSource.ListItems;
            rjComboBox7.BackColor = SystemColors.ButtonHighlight;
            rjComboBox7.BorderColor = Color.DarkSlateGray;
            rjComboBox7.BorderSize = 3;
            rjComboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            rjComboBox7.ForeColor = Color.Black;
            rjComboBox7.IconColor = Color.DarkSlateGray;
            rjComboBox7.Items.AddRange(new object[] { resources.GetString("rjComboBox7.Items"), resources.GetString("rjComboBox7.Items1") });
            rjComboBox7.ListBackColor = SystemColors.ButtonHighlight;
            rjComboBox7.ListTextColor = Color.DimGray;
            rjComboBox7.Name = "rjComboBox7";
            rjComboBox7.Tag = "Selecciones un tipo de pago";
            rjComboBox7.Texts = "Seleccione un tipo de pago";
            // 
            // label80
            // 
            resources.ApplyResources(label80, "label80");
            label80.ForeColor = Color.DarkSlateGray;
            label80.Name = "label80";
            // 
            // TextBoxCredito
            // 
            resources.ApplyResources(TextBoxCredito, "TextBoxCredito");
            TextBoxCredito.BorderColor = Color.DarkSlateGray;
            TextBoxCredito.BorderFocusColor = SystemColors.Info;
            TextBoxCredito.BorderRadius = 0;
            TextBoxCredito.BorderSize = 2;
            TextBoxCredito.Multiline = false;
            TextBoxCredito.Name = "TextBoxCredito";
            TextBoxCredito.PasswordChar = false;
            TextBoxCredito.PlaceholderColor = Color.DimGray;
            TextBoxCredito.PlaceholderText = "";
            TextBoxCredito.Texts = "";
            TextBoxCredito.UnderlinedStyle = true;
            TextBoxCredito.KeyPress += TextBoxCredito_KeyPress;
            // 
            // label83
            // 
            resources.ApplyResources(label83, "label83");
            label83.ForeColor = Color.DarkSlateGray;
            label83.Name = "label83";
            // 
            // TextBoxNombre
            // 
            resources.ApplyResources(TextBoxNombre, "TextBoxNombre");
            TextBoxNombre.BorderColor = Color.DarkSlateGray;
            TextBoxNombre.BorderFocusColor = SystemColors.Info;
            TextBoxNombre.BorderRadius = 0;
            TextBoxNombre.BorderSize = 2;
            TextBoxNombre.Multiline = false;
            TextBoxNombre.Name = "TextBoxNombre";
            TextBoxNombre.PasswordChar = false;
            TextBoxNombre.PlaceholderColor = Color.DimGray;
            TextBoxNombre.PlaceholderText = "";
            TextBoxNombre.Texts = "";
            TextBoxNombre.UnderlinedStyle = true;
            TextBoxNombre.KeyPress += TextBoxNombre_KeyPress;
            // 
            // label84
            // 
            resources.ApplyResources(label84, "label84");
            label84.ForeColor = Color.DarkSlateGray;
            label84.Name = "label84";
            // 
            // rjComboBox8
            // 
            resources.ApplyResources(rjComboBox8, "rjComboBox8");
            rjComboBox8.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("rjComboBox8.AutoCompleteCustomSource"), resources.GetString("rjComboBox8.AutoCompleteCustomSource1"), resources.GetString("rjComboBox8.AutoCompleteCustomSource2") });
            rjComboBox8.AutoCompleteMode = AutoCompleteMode.Suggest;
            rjComboBox8.AutoCompleteSource = AutoCompleteSource.ListItems;
            rjComboBox8.BackColor = SystemColors.ButtonHighlight;
            rjComboBox8.BorderColor = Color.DarkSlateGray;
            rjComboBox8.BorderSize = 3;
            rjComboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            rjComboBox8.ForeColor = Color.Black;
            rjComboBox8.IconColor = Color.DarkSlateGray;
            rjComboBox8.ListBackColor = SystemColors.ButtonHighlight;
            rjComboBox8.ListTextColor = Color.DimGray;
            rjComboBox8.Name = "rjComboBox8";
            rjComboBox8.Tag = "Seleccione al promotor";
            rjComboBox8.Texts = "Seleccione al promotor";
            // 
            // panelTitleBar
            // 
            resources.ApplyResources(panelTitleBar, "panelTitleBar");
            panelTitleBar.BackColor = Color.DarkSlateGray;
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Name = "panelTitleBar";
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.ForeColor = Color.GhostWhite;
            lblTitle.Name = "lblTitle";
            // 
            // pnlRegPago
            // 
            resources.ApplyResources(pnlRegPago, "pnlRegPago");
            pnlRegPago.BackColor = SystemColors.ButtonHighlight;
            pnlRegPago.Controls.Add(Monto_Recomendado);
            pnlRegPago.Controls.Add(label82);
            pnlRegPago.Controls.Add(TextBoxRestantepagos);
            pnlRegPago.Controls.Add(label17);
            pnlRegPago.Controls.Add(rjComboBox9);
            pnlRegPago.Controls.Add(ComBoxName);
            pnlRegPago.Controls.Add(label29);
            pnlRegPago.Controls.Add(btnBuscarC);
            pnlRegPago.Controls.Add(lblFecha);
            pnlRegPago.Controls.Add(txtBoxCredito);
            pnlRegPago.Controls.Add(lblCredito);
            pnlRegPago.Controls.Add(txtBoxMonto);
            pnlRegPago.Controls.Add(btnMarcarP);
            pnlRegPago.Controls.Add(lblMonto);
            pnlRegPago.Name = "pnlRegPago";
            // 
            // Monto_Recomendado
            // 
            resources.ApplyResources(Monto_Recomendado, "Monto_Recomendado");
            Monto_Recomendado.BorderColor = Color.LightSlateGray;
            Monto_Recomendado.BorderFocusColor = SystemColors.ButtonHighlight;
            Monto_Recomendado.BorderRadius = 0;
            Monto_Recomendado.BorderSize = 2;
            Monto_Recomendado.Multiline = false;
            Monto_Recomendado.Name = "Monto_Recomendado";
            Monto_Recomendado.PasswordChar = false;
            Monto_Recomendado.PlaceholderColor = Color.DimGray;
            Monto_Recomendado.PlaceholderText = "";
            Monto_Recomendado.Texts = "";
            Monto_Recomendado.UnderlinedStyle = true;
            // 
            // label82
            // 
            resources.ApplyResources(label82, "label82");
            label82.ForeColor = Color.DarkSlateGray;
            label82.Name = "label82";
            // 
            // TextBoxRestantepagos
            // 
            resources.ApplyResources(TextBoxRestantepagos, "TextBoxRestantepagos");
            TextBoxRestantepagos.BorderColor = Color.LightSlateGray;
            TextBoxRestantepagos.BorderFocusColor = SystemColors.ButtonHighlight;
            TextBoxRestantepagos.BorderRadius = 0;
            TextBoxRestantepagos.BorderSize = 2;
            TextBoxRestantepagos.Multiline = false;
            TextBoxRestantepagos.Name = "TextBoxRestantepagos";
            TextBoxRestantepagos.PasswordChar = false;
            TextBoxRestantepagos.PlaceholderColor = Color.DimGray;
            TextBoxRestantepagos.PlaceholderText = "";
            TextBoxRestantepagos.Texts = "";
            TextBoxRestantepagos.UnderlinedStyle = true;
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.ForeColor = Color.DarkSlateGray;
            label17.Name = "label17";
            // 
            // rjComboBox9
            // 
            resources.ApplyResources(rjComboBox9, "rjComboBox9");
            rjComboBox9.AutoCompleteMode = AutoCompleteMode.Suggest;
            rjComboBox9.AutoCompleteSource = AutoCompleteSource.ListItems;
            rjComboBox9.BackColor = SystemColors.HighlightText;
            rjComboBox9.BorderColor = Color.LightSlateGray;
            rjComboBox9.BorderSize = 3;
            rjComboBox9.DropDownStyle = ComboBoxStyle.DropDown;
            rjComboBox9.ForeColor = Color.Black;
            rjComboBox9.IconColor = Color.DarkSlateGray;
            rjComboBox9.ListBackColor = SystemColors.ButtonHighlight;
            rjComboBox9.ListTextColor = Color.DimGray;
            rjComboBox9.Name = "rjComboBox9";
            rjComboBox9.Texts = "Seleccione la fecha";
            rjComboBox9.OnSelectedIndexChanged += RjComboBox9_OnSelectedIndexChanged;
            // 
            // ComBoxName
            // 
            resources.ApplyResources(ComBoxName, "ComBoxName");
            ComBoxName.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComBoxName.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComBoxName.BackColor = SystemColors.HighlightText;
            ComBoxName.BorderColor = Color.LightSlateGray;
            ComBoxName.BorderSize = 3;
            ComBoxName.DropDownStyle = ComboBoxStyle.DropDown;
            ComBoxName.ForeColor = Color.Black;
            ComBoxName.IconColor = Color.DarkSlateGray;
            ComBoxName.ListBackColor = SystemColors.ButtonHighlight;
            ComBoxName.ListTextColor = Color.DimGray;
            ComBoxName.Name = "ComBoxName";
            ComBoxName.Texts = "Seleccione al cliente";
            ComBoxName.OnSelectedIndexChanged += ActivarBtnBuscar;
            // 
            // label29
            // 
            resources.ApplyResources(label29, "label29");
            label29.ForeColor = Color.DarkSlateGray;
            label29.Name = "label29";
            // 
            // btnBuscarC
            // 
            resources.ApplyResources(btnBuscarC, "btnBuscarC");
            btnBuscarC.BackColor = SystemColors.ActiveCaption;
            btnBuscarC.BackgroundColor = SystemColors.ActiveCaption;
            btnBuscarC.BorderColor = SystemColors.ActiveCaption;
            btnBuscarC.BorderRadius = 10;
            btnBuscarC.BorderSize = 2;
            btnBuscarC.FlatAppearance.BorderSize = 0;
            btnBuscarC.ForeColor = Color.Transparent;
            btnBuscarC.Name = "btnBuscarC";
            btnBuscarC.TextColor = Color.Transparent;
            btnBuscarC.UseVisualStyleBackColor = false;
            btnBuscarC.Click += BtnBuscarC_Click;
            // 
            // lblFecha
            // 
            resources.ApplyResources(lblFecha, "lblFecha");
            lblFecha.ForeColor = Color.DarkSlateGray;
            lblFecha.Name = "lblFecha";
            // 
            // txtBoxCredito
            // 
            resources.ApplyResources(txtBoxCredito, "txtBoxCredito");
            txtBoxCredito.BorderColor = Color.LightSlateGray;
            txtBoxCredito.BorderFocusColor = SystemColors.ButtonHighlight;
            txtBoxCredito.BorderRadius = 0;
            txtBoxCredito.BorderSize = 2;
            txtBoxCredito.Multiline = false;
            txtBoxCredito.Name = "txtBoxCredito";
            txtBoxCredito.PasswordChar = false;
            txtBoxCredito.PlaceholderColor = Color.DimGray;
            txtBoxCredito.PlaceholderText = "";
            txtBoxCredito.Texts = "";
            txtBoxCredito.UnderlinedStyle = true;
            // 
            // lblCredito
            // 
            resources.ApplyResources(lblCredito, "lblCredito");
            lblCredito.ForeColor = Color.DarkSlateGray;
            lblCredito.Name = "lblCredito";
            // 
            // txtBoxMonto
            // 
            resources.ApplyResources(txtBoxMonto, "txtBoxMonto");
            txtBoxMonto.BorderColor = Color.LightSlateGray;
            txtBoxMonto.BorderFocusColor = SystemColors.ButtonHighlight;
            txtBoxMonto.BorderRadius = 0;
            txtBoxMonto.BorderSize = 2;
            txtBoxMonto.Multiline = false;
            txtBoxMonto.Name = "txtBoxMonto";
            txtBoxMonto.PasswordChar = false;
            txtBoxMonto.PlaceholderColor = Color.DimGray;
            txtBoxMonto.PlaceholderText = "";
            txtBoxMonto.Texts = "";
            txtBoxMonto.UnderlinedStyle = true;
            txtBoxMonto.TextChanged2EventHandler += ActivarBtnMarcar;
            txtBoxMonto.KeyPress += SoloNumerosDecimal;
            // 
            // btnMarcarP
            // 
            resources.ApplyResources(btnMarcarP, "btnMarcarP");
            btnMarcarP.BackColor = Color.SteelBlue;
            btnMarcarP.BackgroundColor = Color.SteelBlue;
            btnMarcarP.BorderColor = Color.SteelBlue;
            btnMarcarP.BorderRadius = 10;
            btnMarcarP.BorderSize = 2;
            btnMarcarP.FlatAppearance.BorderSize = 0;
            btnMarcarP.ForeColor = Color.Transparent;
            btnMarcarP.Name = "btnMarcarP";
            btnMarcarP.TextColor = Color.Transparent;
            btnMarcarP.UseVisualStyleBackColor = false;
            btnMarcarP.Click += BtnMarcarP_Click;
            // 
            // lblMonto
            // 
            resources.ApplyResources(lblMonto, "lblMonto");
            lblMonto.ForeColor = Color.DarkSlateGray;
            lblMonto.Name = "lblMonto";
            // 
            // pnlClientes
            // 
            resources.ApplyResources(pnlClientes, "pnlClientes");
            pnlClientes.BackColor = SystemColors.ButtonHighlight;
            pnlClientes.Controls.Add(label87);
            pnlClientes.Controls.Add(btnCalcular1);
            pnlClientes.Controls.Add(btnGuardar1);
            pnlClientes.Controls.Add(dateTimePickerPersonalizado2);
            pnlClientes.Controls.Add(label65);
            pnlClientes.Controls.Add(cmbInteres);
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
            pnlClientes.Name = "pnlClientes";
            // 
            // label87
            // 
            resources.ApplyResources(label87, "label87");
            label87.ForeColor = Color.DarkSlateGray;
            label87.Name = "label87";
            // 
            // btnCalcular1
            // 
            resources.ApplyResources(btnCalcular1, "btnCalcular1");
            btnCalcular1.BackColor = SystemColors.ActiveCaption;
            btnCalcular1.BackgroundColor = SystemColors.ActiveCaption;
            btnCalcular1.BorderColor = SystemColors.ActiveCaption;
            btnCalcular1.BorderRadius = 15;
            btnCalcular1.BorderSize = 2;
            btnCalcular1.FlatAppearance.BorderSize = 0;
            btnCalcular1.ForeColor = Color.Transparent;
            btnCalcular1.Name = "btnCalcular1";
            btnCalcular1.TextColor = Color.Transparent;
            btnCalcular1.UseVisualStyleBackColor = false;
            btnCalcular1.Click += btnCalcular1_Click;
            // 
            // btnGuardar1
            // 
            resources.ApplyResources(btnGuardar1, "btnGuardar1");
            btnGuardar1.BackColor = Color.IndianRed;
            btnGuardar1.BackgroundColor = Color.IndianRed;
            btnGuardar1.BorderColor = Color.SteelBlue;
            btnGuardar1.BorderRadius = 15;
            btnGuardar1.BorderSize = 2;
            btnGuardar1.FlatAppearance.BorderSize = 0;
            btnGuardar1.ForeColor = Color.Transparent;
            btnGuardar1.Name = "btnGuardar1";
            btnGuardar1.TextColor = Color.Transparent;
            btnGuardar1.UseVisualStyleBackColor = false;
            btnGuardar1.Click += btnGuardar1_Click;
            // 
            // dateTimePickerPersonalizado2
            // 
            resources.ApplyResources(dateTimePickerPersonalizado2, "dateTimePickerPersonalizado2");
            dateTimePickerPersonalizado2.BorderColor = Color.DarkSlateGray;
            dateTimePickerPersonalizado2.BorderSize = 3;
            dateTimePickerPersonalizado2.Name = "dateTimePickerPersonalizado2";
            dateTimePickerPersonalizado2.SkinColor = SystemColors.ButtonHighlight;
            dateTimePickerPersonalizado2.TextColor = Color.Black;
            // 
            // label65
            // 
            resources.ApplyResources(label65, "label65");
            label65.BackColor = SystemColors.ButtonHighlight;
            label65.ForeColor = Color.DarkSlateGray;
            label65.Name = "label65";
            // 
            // cmbInteres
            // 
            resources.ApplyResources(cmbInteres, "cmbInteres");
            cmbInteres.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbInteres.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbInteres.BackColor = SystemColors.ButtonHighlight;
            cmbInteres.BorderColor = Color.DarkSlateGray;
            cmbInteres.BorderSize = 3;
            cmbInteres.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInteres.ForeColor = Color.Black;
            cmbInteres.IconColor = Color.DarkSlateGray;
            cmbInteres.Items.AddRange(new object[] { resources.GetString("cmbInteres.Items"), resources.GetString("cmbInteres.Items1"), resources.GetString("cmbInteres.Items2") });
            cmbInteres.ListBackColor = SystemColors.Info;
            cmbInteres.ListTextColor = Color.DimGray;
            cmbInteres.Name = "cmbInteres";
            cmbInteres.Tag = "Seleccione un interés";
            cmbInteres.Texts = "Seleccione un interés";
            cmbInteres.OnSelectedIndexChanged += ActivarBtnCalcular;
            // 
            // txtTotal_I
            // 
            resources.ApplyResources(txtTotal_I, "txtTotal_I");
            txtTotal_I.BorderColor = Color.DarkSlateGray;
            txtTotal_I.BorderFocusColor = SystemColors.ButtonHighlight;
            txtTotal_I.BorderRadius = 0;
            txtTotal_I.BorderSize = 2;
            txtTotal_I.Multiline = false;
            txtTotal_I.Name = "txtTotal_I";
            txtTotal_I.PasswordChar = false;
            txtTotal_I.PlaceholderColor = Color.DimGray;
            txtTotal_I.PlaceholderText = "";
            txtTotal_I.Texts = "";
            txtTotal_I.UnderlinedStyle = true;
            txtTotal_I.TextChanged2EventHandler += ActivarBtnGuardar;
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.ForeColor = Color.DarkSlateGray;
            label16.Name = "label16";
            // 
            // txtTotal
            // 
            resources.ApplyResources(txtTotal, "txtTotal");
            txtTotal.BorderColor = Color.DarkSlateGray;
            txtTotal.BorderFocusColor = SystemColors.ButtonHighlight;
            txtTotal.BorderRadius = 0;
            txtTotal.BorderSize = 2;
            txtTotal.Multiline = false;
            txtTotal.Name = "txtTotal";
            txtTotal.PasswordChar = false;
            txtTotal.PlaceholderColor = Color.DimGray;
            txtTotal.PlaceholderText = "";
            txtTotal.Texts = "";
            txtTotal.UnderlinedStyle = true;
            txtTotal.TextChanged2EventHandler += ActivarBtnGuardar;
            // 
            // txtCorreo
            // 
            resources.ApplyResources(txtCorreo, "txtCorreo");
            txtCorreo.BorderColor = Color.DarkSlateGray;
            txtCorreo.BorderFocusColor = SystemColors.Info;
            txtCorreo.BorderRadius = 0;
            txtCorreo.BorderSize = 2;
            txtCorreo.Multiline = false;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PasswordChar = false;
            txtCorreo.PlaceholderColor = Color.DimGray;
            txtCorreo.PlaceholderText = "Introduzca el correo";
            txtCorreo.Texts = "";
            txtCorreo.UnderlinedStyle = true;
            txtCorreo.TextChanged2EventHandler += ActivarBtnGuardar;
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.ForeColor = Color.DarkSlateGray;
            label15.Name = "label15";
            // 
            // txtTelefono
            // 
            resources.ApplyResources(txtTelefono, "txtTelefono");
            txtTelefono.BorderColor = Color.DarkSlateGray;
            txtTelefono.BorderFocusColor = SystemColors.Info;
            txtTelefono.BorderRadius = 0;
            txtTelefono.BorderSize = 2;
            txtTelefono.Multiline = false;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PasswordChar = false;
            txtTelefono.PlaceholderColor = Color.DimGray;
            txtTelefono.PlaceholderText = "Introduzca el número";
            txtTelefono.Texts = "";
            txtTelefono.UnderlinedStyle = true;
            txtTelefono.TextChanged2EventHandler += ActivarBtnGuardar;
            txtTelefono.KeyPress += SoloNumerosEnteros;
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.ForeColor = Color.DarkSlateGray;
            label14.Name = "label14";
            // 
            // txtNumExt
            // 
            resources.ApplyResources(txtNumExt, "txtNumExt");
            txtNumExt.BorderColor = Color.DarkSlateGray;
            txtNumExt.BorderFocusColor = SystemColors.ButtonHighlight;
            txtNumExt.BorderRadius = 0;
            txtNumExt.BorderSize = 2;
            txtNumExt.Multiline = false;
            txtNumExt.Name = "txtNumExt";
            txtNumExt.PasswordChar = false;
            txtNumExt.PlaceholderColor = Color.DimGray;
            txtNumExt.PlaceholderText = "Num. ext.";
            txtNumExt.Texts = "";
            txtNumExt.UnderlinedStyle = true;
            txtNumExt.TextChanged2EventHandler += ActivarBtnGuardar;
            txtNumExt.KeyPress += SoloNumerosEnteros;
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.ForeColor = Color.DarkSlateGray;
            label13.Name = "label13";
            // 
            // txtNumInt
            // 
            resources.ApplyResources(txtNumInt, "txtNumInt");
            txtNumInt.BorderColor = Color.DarkSlateGray;
            txtNumInt.BorderFocusColor = SystemColors.ButtonHighlight;
            txtNumInt.BorderRadius = 0;
            txtNumInt.BorderSize = 2;
            txtNumInt.Multiline = false;
            txtNumInt.Name = "txtNumInt";
            txtNumInt.PasswordChar = false;
            txtNumInt.PlaceholderColor = Color.DimGray;
            txtNumInt.PlaceholderText = "Num. int.";
            txtNumInt.Texts = "";
            txtNumInt.UnderlinedStyle = true;
            txtNumInt.TextChanged2EventHandler += ActivarBtnGuardar;
            txtNumInt.KeyPress += SoloNumerosEnteros;
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.ForeColor = Color.DarkSlateGray;
            label12.Name = "label12";
            // 
            // txtColonia
            // 
            resources.ApplyResources(txtColonia, "txtColonia");
            txtColonia.BorderColor = Color.DarkSlateGray;
            txtColonia.BorderFocusColor = SystemColors.ButtonHighlight;
            txtColonia.BorderRadius = 0;
            txtColonia.BorderSize = 2;
            txtColonia.Multiline = false;
            txtColonia.Name = "txtColonia";
            txtColonia.PasswordChar = false;
            txtColonia.PlaceholderColor = Color.DimGray;
            txtColonia.PlaceholderText = "Introduzca la colonia";
            txtColonia.Texts = "";
            txtColonia.UnderlinedStyle = true;
            txtColonia.TextChanged2EventHandler += ActivarBtnGuardar;
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.ForeColor = Color.DarkSlateGray;
            label11.Name = "label11";
            // 
            // txtCalle
            // 
            resources.ApplyResources(txtCalle, "txtCalle");
            txtCalle.BorderColor = Color.DarkSlateGray;
            txtCalle.BorderFocusColor = SystemColors.ButtonShadow;
            txtCalle.BorderRadius = 0;
            txtCalle.BorderSize = 2;
            txtCalle.Multiline = false;
            txtCalle.Name = "txtCalle";
            txtCalle.PasswordChar = false;
            txtCalle.PlaceholderColor = Color.DimGray;
            txtCalle.PlaceholderText = "Introduzca la calle";
            txtCalle.Texts = "";
            txtCalle.UnderlinedStyle = true;
            txtCalle.TextChanged2EventHandler += ActivarBtnGuardar;
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.ForeColor = Color.DarkSlateGray;
            label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.ForeColor = Color.DarkSlateGray;
            label9.Name = "label9";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.ForeColor = Color.DarkSlateGray;
            label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.ForeColor = Color.DarkSlateGray;
            label6.Name = "label6";
            // 
            // cmbTipo
            // 
            resources.ApplyResources(cmbTipo, "cmbTipo");
            cmbTipo.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbTipo.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTipo.BackColor = SystemColors.ButtonHighlight;
            cmbTipo.BorderColor = Color.DarkSlateGray;
            cmbTipo.BorderSize = 3;
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.ForeColor = Color.Black;
            cmbTipo.IconColor = Color.DarkSlateGray;
            cmbTipo.Items.AddRange(new object[] { resources.GetString("cmbTipo.Items"), resources.GetString("cmbTipo.Items1") });
            cmbTipo.ListBackColor = SystemColors.ButtonHighlight;
            cmbTipo.ListTextColor = Color.DimGray;
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Tag = "Selecciones un tipo de pago";
            cmbTipo.Texts = "Seleccione un tipo de pago";
            cmbTipo.OnSelectedIndexChanged += ActivarBtnCalcular;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = SystemColors.ButtonHighlight;
            label5.ForeColor = Color.DarkSlateGray;
            label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = SystemColors.ButtonHighlight;
            label4.ForeColor = Color.DarkSlateGray;
            label4.Name = "label4";
            // 
            // dateFechaInicio
            // 
            resources.ApplyResources(dateFechaInicio, "dateFechaInicio");
            dateFechaInicio.BorderColor = Color.DarkSlateGray;
            dateFechaInicio.BorderSize = 3;
            dateFechaInicio.Name = "dateFechaInicio";
            dateFechaInicio.SkinColor = SystemColors.ButtonHighlight;
            dateFechaInicio.TextColor = Color.Black;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = SystemColors.ButtonHighlight;
            label3.ForeColor = Color.DarkSlateGray;
            label3.Name = "label3";
            // 
            // txtCredito
            // 
            resources.ApplyResources(txtCredito, "txtCredito");
            txtCredito.BorderColor = Color.DarkSlateGray;
            txtCredito.BorderFocusColor = SystemColors.ButtonHighlight;
            txtCredito.BorderRadius = 0;
            txtCredito.BorderSize = 2;
            txtCredito.Multiline = false;
            txtCredito.Name = "txtCredito";
            txtCredito.PasswordChar = false;
            txtCredito.PlaceholderColor = Color.DimGray;
            txtCredito.PlaceholderText = "Introduzca monto total";
            txtCredito.Texts = "";
            txtCredito.UnderlinedStyle = true;
            txtCredito.TextChanged2EventHandler += ActivarBtnCalcular;
            txtCredito.KeyPress += SoloNumerosDecimal;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.ForeColor = Color.DarkSlateGray;
            label2.Name = "label2";
            // 
            // txtNombre
            // 
            resources.ApplyResources(txtNombre, "txtNombre");
            txtNombre.BorderColor = Color.DarkSlateGray;
            txtNombre.BorderFocusColor = SystemColors.ButtonHighlight;
            txtNombre.BorderRadius = 0;
            txtNombre.BorderSize = 2;
            txtNombre.Multiline = false;
            txtNombre.Name = "txtNombre";
            txtNombre.PasswordChar = false;
            txtNombre.PlaceholderColor = Color.DimGray;
            txtNombre.PlaceholderText = "Introduzca el nombre";
            txtNombre.Texts = "";
            txtNombre.UnderlinedStyle = true;
            txtNombre.TextChanged2EventHandler += ActivarBtnGuardar;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.ForeColor = Color.DarkSlateGray;
            label1.Name = "label1";
            // 
            // cmbPromotor
            // 
            resources.ApplyResources(cmbPromotor, "cmbPromotor");
            cmbPromotor.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("cmbPromotor.AutoCompleteCustomSource"), resources.GetString("cmbPromotor.AutoCompleteCustomSource1") });
            cmbPromotor.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbPromotor.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbPromotor.BackColor = SystemColors.HighlightText;
            cmbPromotor.BorderColor = Color.DarkSlateGray;
            cmbPromotor.BorderSize = 3;
            cmbPromotor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPromotor.ForeColor = Color.Black;
            cmbPromotor.IconColor = Color.DarkSlateGray;
            cmbPromotor.ListBackColor = SystemColors.HighlightText;
            cmbPromotor.ListTextColor = Color.DimGray;
            cmbPromotor.Name = "cmbPromotor";
            cmbPromotor.Tag = "Seleccione al promotor";
            cmbPromotor.Texts = "Seleccione al promotor";
            cmbPromotor.OnSelectedIndexChanged += ActivarBtnGuardar;
            // 
            // PanelEditar3
            // 
            resources.ApplyResources(PanelEditar3, "PanelEditar3");
            PanelEditar3.BackColor = SystemColors.ButtonHighlight;
            PanelEditar3.Controls.Add(btnGuardar2);
            PanelEditar3.Controls.Add(ResolucionDemanda);
            PanelEditar3.Controls.Add(groupBox3);
            PanelEditar3.Controls.Add(TextImporte3);
            PanelEditar3.Controls.Add(label103);
            PanelEditar3.Controls.Add(label92);
            PanelEditar3.Controls.Add(TextBoxPagare3);
            PanelEditar3.Controls.Add(label81);
            PanelEditar3.Controls.Add(LabelLista3);
            PanelEditar3.Controls.Add(label94);
            PanelEditar3.Controls.Add(TextBoxCorreo3);
            PanelEditar3.Controls.Add(label95);
            PanelEditar3.Controls.Add(TextBoxTelefono3);
            PanelEditar3.Controls.Add(label96);
            PanelEditar3.Controls.Add(TextBoxNumExt3);
            PanelEditar3.Controls.Add(label97);
            PanelEditar3.Controls.Add(TextBoxNumInt3);
            PanelEditar3.Controls.Add(label98);
            PanelEditar3.Controls.Add(TextBoxColonia3);
            PanelEditar3.Controls.Add(label99);
            PanelEditar3.Controls.Add(TextBoxCalle3);
            PanelEditar3.Controls.Add(label100);
            PanelEditar3.Controls.Add(label101);
            PanelEditar3.Controls.Add(ComboBoxResolucion3);
            PanelEditar3.Controls.Add(label102);
            PanelEditar3.Controls.Add(TextBoxCredito3);
            PanelEditar3.Controls.Add(label105);
            PanelEditar3.Controls.Add(TextBoxNombre3);
            PanelEditar3.Controls.Add(LabelNombre3);
            PanelEditar3.Controls.Add(ComboBoxPromotor3);
            PanelEditar3.Name = "PanelEditar3";
            PanelEditar3.Paint += PanelEditar3_Paint;
            // 
            // btnGuardar2
            // 
            resources.ApplyResources(btnGuardar2, "btnGuardar2");
            btnGuardar2.BackColor = Color.IndianRed;
            btnGuardar2.BackgroundColor = Color.IndianRed;
            btnGuardar2.BorderColor = Color.SteelBlue;
            btnGuardar2.BorderRadius = 15;
            btnGuardar2.BorderSize = 2;
            btnGuardar2.FlatAppearance.BorderSize = 0;
            btnGuardar2.ForeColor = Color.Transparent;
            btnGuardar2.Name = "btnGuardar2";
            btnGuardar2.TextColor = Color.Transparent;
            btnGuardar2.UseVisualStyleBackColor = false;
            btnGuardar2.Click += btnGuardar2_Click;
            // 
            // ResolucionDemanda
            // 
            resources.ApplyResources(ResolucionDemanda, "ResolucionDemanda");
            ResolucionDemanda.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("ResolucionDemanda.AutoCompleteCustomSource"), resources.GetString("ResolucionDemanda.AutoCompleteCustomSource1"), resources.GetString("ResolucionDemanda.AutoCompleteCustomSource2") });
            ResolucionDemanda.AutoCompleteMode = AutoCompleteMode.Suggest;
            ResolucionDemanda.AutoCompleteSource = AutoCompleteSource.ListItems;
            ResolucionDemanda.BackColor = SystemColors.ButtonHighlight;
            ResolucionDemanda.BorderColor = Color.DarkSlateGray;
            ResolucionDemanda.BorderSize = 3;
            ResolucionDemanda.DropDownStyle = ComboBoxStyle.DropDownList;
            ResolucionDemanda.ForeColor = Color.Black;
            ResolucionDemanda.IconColor = Color.DarkSlateGray;
            ResolucionDemanda.Items.AddRange(new object[] { resources.GetString("ResolucionDemanda.Items"), resources.GetString("ResolucionDemanda.Items1") });
            ResolucionDemanda.ListBackColor = SystemColors.ButtonHighlight;
            ResolucionDemanda.ListTextColor = Color.DimGray;
            ResolucionDemanda.Name = "ResolucionDemanda";
            ResolucionDemanda.Tag = "Seleccione al promotor";
            ResolucionDemanda.Texts = "Seleccione la resolucion";
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(btnMover2);
            groupBox3.Controls.Add(rjComboBox5);
            groupBox3.ForeColor = Color.DarkSlateGray;
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // btnMover2
            // 
            resources.ApplyResources(btnMover2, "btnMover2");
            btnMover2.BackColor = SystemColors.ActiveCaption;
            btnMover2.BackgroundColor = SystemColors.ActiveCaption;
            btnMover2.BorderColor = SystemColors.ActiveCaption;
            btnMover2.BorderRadius = 15;
            btnMover2.BorderSize = 2;
            btnMover2.FlatAppearance.BorderSize = 0;
            btnMover2.ForeColor = Color.Transparent;
            btnMover2.Name = "btnMover2";
            btnMover2.TextColor = Color.Transparent;
            btnMover2.UseVisualStyleBackColor = false;
            btnMover2.Click += btnMover2_Click;
            // 
            // rjComboBox5
            // 
            resources.ApplyResources(rjComboBox5, "rjComboBox5");
            rjComboBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            rjComboBox5.AutoCompleteSource = AutoCompleteSource.ListItems;
            rjComboBox5.BackColor = SystemColors.ButtonHighlight;
            rjComboBox5.BorderColor = Color.DarkSlateGray;
            rjComboBox5.BorderSize = 3;
            rjComboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            rjComboBox5.ForeColor = Color.Black;
            rjComboBox5.IconColor = Color.DarkSlateGray;
            rjComboBox5.ListBackColor = SystemColors.ButtonHighlight;
            rjComboBox5.ListTextColor = Color.DimGray;
            rjComboBox5.Name = "rjComboBox5";
            rjComboBox5.Tag = "Selecciones un tipo de pago";
            rjComboBox5.Texts = "Seleccione una lista";
            rjComboBox5.OnSelectedIndexChanged += RjComboBox5_OnSelectedIndexChanged;
            // 
            // TextImporte3
            // 
            resources.ApplyResources(TextImporte3, "TextImporte3");
            TextImporte3.BorderColor = Color.DarkSlateGray;
            TextImporte3.BorderFocusColor = SystemColors.Info;
            TextImporte3.BorderRadius = 0;
            TextImporte3.BorderSize = 2;
            TextImporte3.Multiline = false;
            TextImporte3.Name = "TextImporte3";
            TextImporte3.PasswordChar = false;
            TextImporte3.PlaceholderColor = Color.DimGray;
            TextImporte3.PlaceholderText = "";
            TextImporte3.Texts = "";
            TextImporte3.UnderlinedStyle = true;
            TextImporte3.KeyPress += TextImporte3_KeyPress;
            // 
            // label103
            // 
            resources.ApplyResources(label103, "label103");
            label103.ForeColor = Color.DarkSlateGray;
            label103.Name = "label103";
            // 
            // label92
            // 
            resources.ApplyResources(label92, "label92");
            label92.ForeColor = Color.DarkSlateGray;
            label92.Name = "label92";
            // 
            // TextBoxPagare3
            // 
            resources.ApplyResources(TextBoxPagare3, "TextBoxPagare3");
            TextBoxPagare3.BorderColor = Color.DarkSlateGray;
            TextBoxPagare3.BorderFocusColor = SystemColors.ButtonHighlight;
            TextBoxPagare3.BorderRadius = 0;
            TextBoxPagare3.BorderSize = 2;
            TextBoxPagare3.Multiline = false;
            TextBoxPagare3.Name = "TextBoxPagare3";
            TextBoxPagare3.PasswordChar = false;
            TextBoxPagare3.PlaceholderColor = Color.DimGray;
            TextBoxPagare3.PlaceholderText = "";
            TextBoxPagare3.Texts = "";
            TextBoxPagare3.UnderlinedStyle = true;
            TextBoxPagare3.KeyPress += TextBoxPagare3_KeyPress;
            // 
            // label81
            // 
            resources.ApplyResources(label81, "label81");
            label81.ForeColor = Color.DarkSlateGray;
            label81.Name = "label81";
            // 
            // LabelLista3
            // 
            resources.ApplyResources(LabelLista3, "LabelLista3");
            LabelLista3.Name = "LabelLista3";
            // 
            // label94
            // 
            resources.ApplyResources(label94, "label94");
            label94.Name = "label94";
            // 
            // TextBoxCorreo3
            // 
            resources.ApplyResources(TextBoxCorreo3, "TextBoxCorreo3");
            TextBoxCorreo3.BorderColor = Color.DarkSlateGray;
            TextBoxCorreo3.BorderFocusColor = SystemColors.Info;
            TextBoxCorreo3.BorderRadius = 0;
            TextBoxCorreo3.BorderSize = 2;
            TextBoxCorreo3.Multiline = false;
            TextBoxCorreo3.Name = "TextBoxCorreo3";
            TextBoxCorreo3.PasswordChar = false;
            TextBoxCorreo3.PlaceholderColor = Color.DimGray;
            TextBoxCorreo3.PlaceholderText = "";
            TextBoxCorreo3.Texts = "";
            TextBoxCorreo3.UnderlinedStyle = true;
            // 
            // label95
            // 
            resources.ApplyResources(label95, "label95");
            label95.ForeColor = Color.DarkSlateGray;
            label95.Name = "label95";
            // 
            // TextBoxTelefono3
            // 
            resources.ApplyResources(TextBoxTelefono3, "TextBoxTelefono3");
            TextBoxTelefono3.BorderColor = Color.DarkSlateGray;
            TextBoxTelefono3.BorderFocusColor = SystemColors.Info;
            TextBoxTelefono3.BorderRadius = 0;
            TextBoxTelefono3.BorderSize = 2;
            TextBoxTelefono3.Multiline = false;
            TextBoxTelefono3.Name = "TextBoxTelefono3";
            TextBoxTelefono3.PasswordChar = false;
            TextBoxTelefono3.PlaceholderColor = Color.DimGray;
            TextBoxTelefono3.PlaceholderText = "";
            TextBoxTelefono3.Texts = "";
            TextBoxTelefono3.UnderlinedStyle = true;
            TextBoxTelefono3.KeyPress += TextBoxTelefono3_KeyPress;
            // 
            // label96
            // 
            resources.ApplyResources(label96, "label96");
            label96.ForeColor = Color.DarkSlateGray;
            label96.Name = "label96";
            // 
            // TextBoxNumExt3
            // 
            resources.ApplyResources(TextBoxNumExt3, "TextBoxNumExt3");
            TextBoxNumExt3.BorderColor = Color.DarkSlateGray;
            TextBoxNumExt3.BorderFocusColor = SystemColors.Info;
            TextBoxNumExt3.BorderRadius = 0;
            TextBoxNumExt3.BorderSize = 2;
            TextBoxNumExt3.Multiline = false;
            TextBoxNumExt3.Name = "TextBoxNumExt3";
            TextBoxNumExt3.PasswordChar = false;
            TextBoxNumExt3.PlaceholderColor = Color.DimGray;
            TextBoxNumExt3.PlaceholderText = "";
            TextBoxNumExt3.Texts = "";
            TextBoxNumExt3.UnderlinedStyle = true;
            TextBoxNumExt3.KeyPress += TextBoxNumExt3_KeyPress;
            // 
            // label97
            // 
            resources.ApplyResources(label97, "label97");
            label97.ForeColor = Color.DarkSlateGray;
            label97.Name = "label97";
            // 
            // TextBoxNumInt3
            // 
            resources.ApplyResources(TextBoxNumInt3, "TextBoxNumInt3");
            TextBoxNumInt3.BorderColor = Color.DarkSlateGray;
            TextBoxNumInt3.BorderFocusColor = SystemColors.Info;
            TextBoxNumInt3.BorderRadius = 0;
            TextBoxNumInt3.BorderSize = 2;
            TextBoxNumInt3.Multiline = false;
            TextBoxNumInt3.Name = "TextBoxNumInt3";
            TextBoxNumInt3.PasswordChar = false;
            TextBoxNumInt3.PlaceholderColor = Color.DimGray;
            TextBoxNumInt3.PlaceholderText = "";
            TextBoxNumInt3.Texts = "";
            TextBoxNumInt3.UnderlinedStyle = true;
            TextBoxNumInt3.KeyPress += TextBoxNumInt3_KeyPress;
            // 
            // label98
            // 
            resources.ApplyResources(label98, "label98");
            label98.ForeColor = Color.DarkSlateGray;
            label98.Name = "label98";
            // 
            // TextBoxColonia3
            // 
            resources.ApplyResources(TextBoxColonia3, "TextBoxColonia3");
            TextBoxColonia3.BorderColor = Color.DarkSlateGray;
            TextBoxColonia3.BorderFocusColor = SystemColors.Info;
            TextBoxColonia3.BorderRadius = 0;
            TextBoxColonia3.BorderSize = 2;
            TextBoxColonia3.Multiline = false;
            TextBoxColonia3.Name = "TextBoxColonia3";
            TextBoxColonia3.PasswordChar = false;
            TextBoxColonia3.PlaceholderColor = Color.DimGray;
            TextBoxColonia3.PlaceholderText = "";
            TextBoxColonia3.Texts = "";
            TextBoxColonia3.UnderlinedStyle = true;
            // 
            // label99
            // 
            resources.ApplyResources(label99, "label99");
            label99.ForeColor = Color.DarkSlateGray;
            label99.Name = "label99";
            // 
            // TextBoxCalle3
            // 
            resources.ApplyResources(TextBoxCalle3, "TextBoxCalle3");
            TextBoxCalle3.BorderColor = Color.DarkSlateGray;
            TextBoxCalle3.BorderFocusColor = SystemColors.Info;
            TextBoxCalle3.BorderRadius = 0;
            TextBoxCalle3.BorderSize = 2;
            TextBoxCalle3.Multiline = false;
            TextBoxCalle3.Name = "TextBoxCalle3";
            TextBoxCalle3.PasswordChar = false;
            TextBoxCalle3.PlaceholderColor = Color.DimGray;
            TextBoxCalle3.PlaceholderText = "";
            TextBoxCalle3.Texts = "";
            TextBoxCalle3.UnderlinedStyle = true;
            // 
            // label100
            // 
            resources.ApplyResources(label100, "label100");
            label100.ForeColor = Color.DarkSlateGray;
            label100.Name = "label100";
            // 
            // label101
            // 
            resources.ApplyResources(label101, "label101");
            label101.ForeColor = Color.DarkSlateGray;
            label101.Name = "label101";
            // 
            // ComboBoxResolucion3
            // 
            resources.ApplyResources(ComboBoxResolucion3, "ComboBoxResolucion3");
            ComboBoxResolucion3.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComboBoxResolucion3.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboBoxResolucion3.BackColor = SystemColors.ButtonHighlight;
            ComboBoxResolucion3.BorderColor = Color.DarkSlateGray;
            ComboBoxResolucion3.BorderSize = 3;
            ComboBoxResolucion3.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxResolucion3.ForeColor = Color.Black;
            ComboBoxResolucion3.IconColor = Color.DarkSlateGray;
            ComboBoxResolucion3.Items.AddRange(new object[] { resources.GetString("ComboBoxResolucion3.Items"), resources.GetString("ComboBoxResolucion3.Items1") });
            ComboBoxResolucion3.ListBackColor = SystemColors.ButtonHighlight;
            ComboBoxResolucion3.ListTextColor = Color.DimGray;
            ComboBoxResolucion3.Name = "ComboBoxResolucion3";
            ComboBoxResolucion3.Tag = "Selecciones un tipo de pago";
            ComboBoxResolucion3.Texts = "Seleccione un tipo de pago";
            // 
            // label102
            // 
            resources.ApplyResources(label102, "label102");
            label102.ForeColor = Color.DarkSlateGray;
            label102.Name = "label102";
            // 
            // TextBoxCredito3
            // 
            resources.ApplyResources(TextBoxCredito3, "TextBoxCredito3");
            TextBoxCredito3.BorderColor = Color.DarkSlateGray;
            TextBoxCredito3.BorderFocusColor = SystemColors.ButtonHighlight;
            TextBoxCredito3.BorderRadius = 0;
            TextBoxCredito3.BorderSize = 2;
            TextBoxCredito3.Multiline = false;
            TextBoxCredito3.Name = "TextBoxCredito3";
            TextBoxCredito3.PasswordChar = false;
            TextBoxCredito3.PlaceholderColor = Color.DimGray;
            TextBoxCredito3.PlaceholderText = "";
            TextBoxCredito3.Texts = "";
            TextBoxCredito3.UnderlinedStyle = true;
            TextBoxCredito3.TextChanged2EventHandler += TextBoxCredito3TextChanged2EventHandler;
            TextBoxCredito3.KeyPress += TextBoxCredito3_KeyPress;
            // 
            // label105
            // 
            resources.ApplyResources(label105, "label105");
            label105.ForeColor = Color.DarkSlateGray;
            label105.Name = "label105";
            // 
            // TextBoxNombre3
            // 
            resources.ApplyResources(TextBoxNombre3, "TextBoxNombre3");
            TextBoxNombre3.BorderColor = Color.DarkSlateGray;
            TextBoxNombre3.BorderFocusColor = SystemColors.ButtonHighlight;
            TextBoxNombre3.BorderRadius = 0;
            TextBoxNombre3.BorderSize = 2;
            TextBoxNombre3.Multiline = false;
            TextBoxNombre3.Name = "TextBoxNombre3";
            TextBoxNombre3.PasswordChar = false;
            TextBoxNombre3.PlaceholderColor = Color.DimGray;
            TextBoxNombre3.PlaceholderText = "";
            TextBoxNombre3.Texts = "";
            TextBoxNombre3.UnderlinedStyle = true;
            // 
            // LabelNombre3
            // 
            resources.ApplyResources(LabelNombre3, "LabelNombre3");
            LabelNombre3.ForeColor = Color.DarkSlateGray;
            LabelNombre3.Name = "LabelNombre3";
            // 
            // ComboBoxPromotor3
            // 
            resources.ApplyResources(ComboBoxPromotor3, "ComboBoxPromotor3");
            ComboBoxPromotor3.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("ComboBoxPromotor3.AutoCompleteCustomSource"), resources.GetString("ComboBoxPromotor3.AutoCompleteCustomSource1"), resources.GetString("ComboBoxPromotor3.AutoCompleteCustomSource2") });
            ComboBoxPromotor3.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComboBoxPromotor3.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboBoxPromotor3.BackColor = SystemColors.ButtonHighlight;
            ComboBoxPromotor3.BorderColor = Color.DarkSlateGray;
            ComboBoxPromotor3.BorderSize = 3;
            ComboBoxPromotor3.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxPromotor3.ForeColor = Color.Black;
            ComboBoxPromotor3.IconColor = Color.DarkSlateGray;
            ComboBoxPromotor3.ListBackColor = SystemColors.ButtonHighlight;
            ComboBoxPromotor3.ListTextColor = Color.DimGray;
            ComboBoxPromotor3.Name = "ComboBoxPromotor3";
            ComboBoxPromotor3.Tag = "Seleccione al promotor";
            ComboBoxPromotor3.Texts = "Seleccione al promotor";
            // 
            // pnlListas
            // 
            resources.ApplyResources(pnlListas, "pnlListas");
            pnlListas.BackColor = SystemColors.ButtonHighlight;
            pnlListas.Controls.Add(labelDineroAire);
            pnlListas.Controls.Add(flowLayoutPanel5);
            pnlListas.Controls.Add(label57);
            pnlListas.Controls.Add(BarradeProgreso);
            pnlListas.Controls.Add(flowLayoutPanel3);
            pnlListas.Controls.Add(flowLayoutPanel2);
            pnlListas.Controls.Add(flowLayoutPanel1);
            pnlListas.Controls.Add(gridListas);
            pnlListas.Controls.Add(label8);
            pnlListas.Name = "pnlListas";
            // 
            // labelDineroAire
            // 
            resources.ApplyResources(labelDineroAire, "labelDineroAire");
            labelDineroAire.ForeColor = Color.DarkSlateGray;
            labelDineroAire.Name = "labelDineroAire";
            // 
            // flowLayoutPanel5
            // 
            resources.ApplyResources(flowLayoutPanel5, "flowLayoutPanel5");
            flowLayoutPanel5.Controls.Add(ComboBoxPromotoresListas);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            // 
            // ComboBoxPromotoresListas
            // 
            resources.ApplyResources(ComboBoxPromotoresListas, "ComboBoxPromotoresListas");
            ComboBoxPromotoresListas.AllowDrop = true;
            ComboBoxPromotoresListas.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("ComboBoxPromotoresListas.AutoCompleteCustomSource"), resources.GetString("ComboBoxPromotoresListas.AutoCompleteCustomSource1") });
            ComboBoxPromotoresListas.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComboBoxPromotoresListas.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboBoxPromotoresListas.BackColor = SystemColors.ButtonHighlight;
            ComboBoxPromotoresListas.BorderColor = Color.DarkSlateGray;
            ComboBoxPromotoresListas.BorderSize = 3;
            ComboBoxPromotoresListas.DropDownStyle = ComboBoxStyle.DropDown;
            ComboBoxPromotoresListas.ForeColor = Color.DarkSlateGray;
            ComboBoxPromotoresListas.IconColor = Color.LightSlateGray;
            ComboBoxPromotoresListas.ListBackColor = SystemColors.ButtonHighlight;
            ComboBoxPromotoresListas.ListTextColor = Color.DimGray;
            ComboBoxPromotoresListas.Name = "ComboBoxPromotoresListas";
            ComboBoxPromotoresListas.Tag = "Promotor:";
            ComboBoxPromotoresListas.Texts = "Promotor:";
            ComboBoxPromotoresListas.OnSelectedIndexChanged += ComboBoxPromotoresListas_OnSelectedIndexChanged;
            // 
            // label57
            // 
            resources.ApplyResources(label57, "label57");
            label57.ForeColor = Color.DarkSlateGray;
            label57.Name = "label57";
            // 
            // BarradeProgreso
            // 
            resources.ApplyResources(BarradeProgreso, "BarradeProgreso");
            BarradeProgreso.BackColor = SystemColors.Info;
            BarradeProgreso.ForeColor = Color.LightSlateGray;
            BarradeProgreso.Name = "BarradeProgreso";
            BarradeProgreso.Style = ProgressBarStyle.Continuous;
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(flowLayoutPanel3, "flowLayoutPanel3");
            flowLayoutPanel3.Controls.Add(cmbCliente);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // cmbCliente
            // 
            resources.ApplyResources(cmbCliente, "cmbCliente");
            cmbCliente.AllowDrop = true;
            cmbCliente.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("cmbCliente.AutoCompleteCustomSource"), resources.GetString("cmbCliente.AutoCompleteCustomSource1") });
            cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCliente.BackColor = SystemColors.ButtonHighlight;
            cmbCliente.BorderColor = Color.DarkSlateGray;
            cmbCliente.BorderSize = 3;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDown;
            cmbCliente.ForeColor = Color.DarkSlateGray;
            cmbCliente.IconColor = Color.LightSlateGray;
            cmbCliente.ListBackColor = SystemColors.ButtonHighlight;
            cmbCliente.ListTextColor = Color.DimGray;
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Tag = "Seleccione un cliente";
            cmbCliente.Texts = "Seleccione un cliente";
            cmbCliente.OnSelectedIndexChanged += CmbCliente_OnSelectedIndexChanged;
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Controls.Add(btnEditar);
            flowLayoutPanel2.Controls.Add(btnEliminar);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // btnEditar
            // 
            resources.ApplyResources(btnEditar, "btnEditar");
            btnEditar.BackColor = SystemColors.ActiveCaption;
            btnEditar.BackgroundColor = SystemColors.ActiveCaption;
            btnEditar.BorderColor = SystemColors.ActiveCaption;
            btnEditar.BorderRadius = 15;
            btnEditar.BorderSize = 2;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.ForeColor = Color.Transparent;
            btnEditar.Name = "btnEditar";
            btnEditar.TextColor = Color.Transparent;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += BtnEditar_Click;
            // 
            // btnEliminar
            // 
            resources.ApplyResources(btnEliminar, "btnEliminar");
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.BackgroundColor = Color.IndianRed;
            btnEliminar.BorderColor = Color.IndianRed;
            btnEliminar.BorderRadius = 15;
            btnEliminar.BorderSize = 2;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.ForeColor = Color.Transparent;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.TextColor = Color.Transparent;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(btnLista1);
            flowLayoutPanel1.Controls.Add(btnLista2);
            flowLayoutPanel1.Controls.Add(btnLista3);
            flowLayoutPanel1.Controls.Add(btnMostrarTodos);
            flowLayoutPanel1.Controls.Add(btnLiquidados);
            flowLayoutPanel1.Controls.Add(rjButton1);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // btnLista1
            // 
            resources.ApplyResources(btnLista1, "btnLista1");
            btnLista1.BackColor = SystemColors.ActiveCaption;
            btnLista1.BackgroundColor = SystemColors.ActiveCaption;
            btnLista1.BorderColor = SystemColors.ActiveCaption;
            btnLista1.BorderRadius = 15;
            btnLista1.BorderSize = 2;
            btnLista1.FlatAppearance.BorderSize = 0;
            btnLista1.ForeColor = Color.Transparent;
            btnLista1.Name = "btnLista1";
            btnLista1.TextColor = Color.Transparent;
            btnLista1.UseVisualStyleBackColor = false;
            btnLista1.Click += BtnLista1_Click;
            btnLista1.MouseDown += BtnLista1_MouseDown;
            // 
            // btnLista2
            // 
            resources.ApplyResources(btnLista2, "btnLista2");
            btnLista2.BackColor = Color.SteelBlue;
            btnLista2.BackgroundColor = Color.SteelBlue;
            btnLista2.BorderColor = Color.SteelBlue;
            btnLista2.BorderRadius = 15;
            btnLista2.BorderSize = 2;
            btnLista2.FlatAppearance.BorderSize = 0;
            btnLista2.ForeColor = Color.Transparent;
            btnLista2.Name = "btnLista2";
            btnLista2.TextColor = Color.Transparent;
            btnLista2.UseVisualStyleBackColor = false;
            btnLista2.Click += BtnLista2_Click;
            btnLista2.MouseDown += BtnLista2_MouseDown;
            // 
            // btnLista3
            // 
            resources.ApplyResources(btnLista3, "btnLista3");
            btnLista3.BackColor = SystemColors.ActiveCaption;
            btnLista3.BackgroundColor = SystemColors.ActiveCaption;
            btnLista3.BorderColor = SystemColors.ActiveCaption;
            btnLista3.BorderRadius = 15;
            btnLista3.BorderSize = 2;
            btnLista3.FlatAppearance.BorderSize = 0;
            btnLista3.ForeColor = Color.Transparent;
            btnLista3.Name = "btnLista3";
            btnLista3.TextColor = Color.Transparent;
            btnLista3.UseVisualStyleBackColor = false;
            btnLista3.Click += BtnLista3_Click;
            btnLista3.MouseDown += BtnLista3_MouseDown;
            // 
            // btnMostrarTodos
            // 
            resources.ApplyResources(btnMostrarTodos, "btnMostrarTodos");
            btnMostrarTodos.BackColor = SystemColors.ActiveCaption;
            btnMostrarTodos.BackgroundColor = SystemColors.ActiveCaption;
            btnMostrarTodos.BorderColor = SystemColors.ActiveCaption;
            btnMostrarTodos.BorderRadius = 15;
            btnMostrarTodos.BorderSize = 2;
            btnMostrarTodos.FlatAppearance.BorderSize = 0;
            btnMostrarTodos.ForeColor = Color.Transparent;
            btnMostrarTodos.Name = "btnMostrarTodos";
            btnMostrarTodos.TextColor = Color.Transparent;
            btnMostrarTodos.UseVisualStyleBackColor = false;
            btnMostrarTodos.Click += BtnMostrarTodos_Click;
            btnMostrarTodos.MouseDown += BtnMostrarTodos_MouseDown;
            // 
            // btnLiquidados
            // 
            resources.ApplyResources(btnLiquidados, "btnLiquidados");
            btnLiquidados.BackColor = Color.SteelBlue;
            btnLiquidados.BackgroundColor = Color.SteelBlue;
            btnLiquidados.BorderColor = Color.SteelBlue;
            btnLiquidados.BorderRadius = 15;
            btnLiquidados.BorderSize = 2;
            btnLiquidados.FlatAppearance.BorderSize = 0;
            btnLiquidados.ForeColor = Color.Transparent;
            btnLiquidados.Name = "btnLiquidados";
            btnLiquidados.TextColor = Color.Transparent;
            btnLiquidados.UseVisualStyleBackColor = false;
            btnLiquidados.Click += BtnLiquidados_Click;
            btnLiquidados.MouseDown += BtnLiquidados_MouseDown;
            // 
            // rjButton1
            // 
            resources.ApplyResources(rjButton1, "rjButton1");
            rjButton1.BackColor = Color.MidnightBlue;
            rjButton1.BackgroundColor = Color.MidnightBlue;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 20;
            rjButton1.BorderSize = 0;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.ForeColor = Color.White;
            rjButton1.Name = "rjButton1";
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += RjButton1_Click_1;
            // 
            // gridListas
            // 
            resources.ApplyResources(gridListas, "gridListas");
            gridListas.AllowUserToAddRows = false;
            gridListas.AllowUserToDeleteRows = false;
            gridListas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridListas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridListas.BackgroundColor = SystemColors.ActiveCaption;
            gridListas.BorderStyle = BorderStyle.None;
            gridListas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridListas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.DarkSlateGray;
            dataGridViewCellStyle1.Font = new Font("Dubai", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.SelectionBackColor = Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridListas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Corbel", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridListas.DefaultCellStyle = dataGridViewCellStyle2;
            gridListas.EnableHeadersVisualStyles = false;
            gridListas.GridColor = SystemColors.ActiveCaption;
            gridListas.Name = "gridListas";
            gridListas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Font = new Font("Corbel", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridListas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridListas.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle4.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlLightLight;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightSlateGray;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlLightLight;
            gridListas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            gridListas.RowTemplate.Height = 25;
            gridListas.SelectionMode = DataGridViewSelectionMode.CellSelect;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.ForeColor = Color.DarkSlateGray;
            label8.Name = "label8";
            // 
            // PanelEditar
            // 
            resources.ApplyResources(PanelEditar, "PanelEditar");
            PanelEditar.BackColor = SystemColors.HighlightText;
            PanelEditar.Controls.Add(BtnGuardarCambio);
            PanelEditar.Controls.Add(textBoxPersonalizado11);
            PanelEditar.Controls.Add(label66);
            PanelEditar.Controls.Add(dateTimeLimite);
            PanelEditar.Controls.Add(LabelLimite);
            PanelEditar.Controls.Add(textBoxPersonalizado7);
            PanelEditar.Controls.Add(label25);
            PanelEditar.Controls.Add(textBoxPersonalizado8);
            PanelEditar.Controls.Add(label27);
            PanelEditar.Controls.Add(LblPerte);
            PanelEditar.Controls.Add(label26);
            PanelEditar.Controls.Add(groupBox1);
            PanelEditar.Controls.Add(textBoxPersonalizado1);
            PanelEditar.Controls.Add(label18);
            PanelEditar.Controls.Add(textBoxPersonalizado2);
            PanelEditar.Controls.Add(label20);
            PanelEditar.Controls.Add(textBoxPersonalizado3);
            PanelEditar.Controls.Add(label21);
            PanelEditar.Controls.Add(textBoxPersonalizado4);
            PanelEditar.Controls.Add(label22);
            PanelEditar.Controls.Add(textBoxPersonalizado5);
            PanelEditar.Controls.Add(label23);
            PanelEditar.Controls.Add(textBoxPersonalizado6);
            PanelEditar.Controls.Add(label24);
            PanelEditar.Controls.Add(rjComboBox1);
            PanelEditar.Controls.Add(label28);
            PanelEditar.Controls.Add(rjComboBox2);
            PanelEditar.Controls.Add(label30);
            PanelEditar.Controls.Add(label31);
            PanelEditar.Controls.Add(dateTimePickerPersonalizado1);
            PanelEditar.Controls.Add(label32);
            PanelEditar.Controls.Add(textBoxPersonalizado9);
            PanelEditar.Controls.Add(label33);
            PanelEditar.Controls.Add(textBoxPersonalizado10);
            PanelEditar.Controls.Add(label34);
            PanelEditar.Controls.Add(rjComboBox3);
            PanelEditar.Name = "PanelEditar";
            PanelEditar.Paint += PanelEditar_Paint;
            // 
            // BtnGuardarCambio
            // 
            resources.ApplyResources(BtnGuardarCambio, "BtnGuardarCambio");
            BtnGuardarCambio.BackColor = Color.IndianRed;
            BtnGuardarCambio.BackgroundColor = Color.IndianRed;
            BtnGuardarCambio.BorderColor = Color.PaleVioletRed;
            BtnGuardarCambio.BorderRadius = 20;
            BtnGuardarCambio.BorderSize = 0;
            BtnGuardarCambio.FlatAppearance.BorderSize = 0;
            BtnGuardarCambio.ForeColor = Color.White;
            BtnGuardarCambio.Name = "BtnGuardarCambio";
            BtnGuardarCambio.TextColor = Color.White;
            BtnGuardarCambio.UseVisualStyleBackColor = false;
            BtnGuardarCambio.Click += BtnGuardarCambio_Click;
            // 
            // textBoxPersonalizado11
            // 
            resources.ApplyResources(textBoxPersonalizado11, "textBoxPersonalizado11");
            textBoxPersonalizado11.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado11.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado11.BorderRadius = 0;
            textBoxPersonalizado11.BorderSize = 2;
            textBoxPersonalizado11.Multiline = false;
            textBoxPersonalizado11.Name = "textBoxPersonalizado11";
            textBoxPersonalizado11.PasswordChar = false;
            textBoxPersonalizado11.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado11.PlaceholderText = "";
            textBoxPersonalizado11.Texts = "";
            textBoxPersonalizado11.UnderlinedStyle = true;
            textBoxPersonalizado11.KeyPress += textBoxPersonalizado11_KeyPress;
            // 
            // label66
            // 
            resources.ApplyResources(label66, "label66");
            label66.ForeColor = Color.LightSlateGray;
            label66.Name = "label66";
            // 
            // dateTimeLimite
            // 
            resources.ApplyResources(dateTimeLimite, "dateTimeLimite");
            dateTimeLimite.BorderColor = Color.DarkSlateGray;
            dateTimeLimite.BorderSize = 2;
            dateTimeLimite.Name = "dateTimeLimite";
            dateTimeLimite.SkinColor = SystemColors.Info;
            dateTimeLimite.TextColor = Color.Black;
            // 
            // LabelLimite
            // 
            resources.ApplyResources(LabelLimite, "LabelLimite");
            LabelLimite.ForeColor = Color.LightSlateGray;
            LabelLimite.Name = "LabelLimite";
            // 
            // textBoxPersonalizado7
            // 
            resources.ApplyResources(textBoxPersonalizado7, "textBoxPersonalizado7");
            textBoxPersonalizado7.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado7.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado7.BorderRadius = 0;
            textBoxPersonalizado7.BorderSize = 2;
            textBoxPersonalizado7.Multiline = false;
            textBoxPersonalizado7.Name = "textBoxPersonalizado7";
            textBoxPersonalizado7.PasswordChar = false;
            textBoxPersonalizado7.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado7.PlaceholderText = "";
            textBoxPersonalizado7.Texts = "";
            textBoxPersonalizado7.UnderlinedStyle = true;
            textBoxPersonalizado7.KeyPress += textBoxPersonalizado7_KeyPress;
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.ForeColor = Color.LightSlateGray;
            label25.Name = "label25";
            // 
            // textBoxPersonalizado8
            // 
            resources.ApplyResources(textBoxPersonalizado8, "textBoxPersonalizado8");
            textBoxPersonalizado8.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado8.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado8.BorderRadius = 0;
            textBoxPersonalizado8.BorderSize = 2;
            textBoxPersonalizado8.Multiline = false;
            textBoxPersonalizado8.Name = "textBoxPersonalizado8";
            textBoxPersonalizado8.PasswordChar = false;
            textBoxPersonalizado8.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado8.PlaceholderText = "";
            textBoxPersonalizado8.Texts = "";
            textBoxPersonalizado8.UnderlinedStyle = true;
            textBoxPersonalizado8.KeyPress += textBoxPersonalizado8_KeyPress;
            // 
            // label27
            // 
            resources.ApplyResources(label27, "label27");
            label27.ForeColor = Color.LightSlateGray;
            label27.Name = "label27";
            // 
            // LblPerte
            // 
            resources.ApplyResources(LblPerte, "LblPerte");
            LblPerte.ForeColor = Color.DarkSlateGray;
            LblPerte.Name = "LblPerte";
            // 
            // label26
            // 
            resources.ApplyResources(label26, "label26");
            label26.ForeColor = Color.DarkSlateGray;
            label26.Name = "label26";
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(BtnMover);
            groupBox1.Controls.Add(cmbLista);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // BtnMover
            // 
            resources.ApplyResources(BtnMover, "BtnMover");
            BtnMover.BackColor = Color.Gray;
            BtnMover.BackgroundColor = Color.Gray;
            BtnMover.BorderColor = Color.PaleVioletRed;
            BtnMover.BorderRadius = 20;
            BtnMover.BorderSize = 0;
            BtnMover.FlatAppearance.BorderSize = 0;
            BtnMover.ForeColor = Color.White;
            BtnMover.Name = "BtnMover";
            BtnMover.TextColor = Color.White;
            BtnMover.UseVisualStyleBackColor = false;
            BtnMover.Click += BtnMover_Click_1;
            // 
            // cmbLista
            // 
            resources.ApplyResources(cmbLista, "cmbLista");
            cmbLista.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbLista.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbLista.BackColor = SystemColors.HighlightText;
            cmbLista.BorderColor = Color.DarkSlateGray;
            cmbLista.BorderSize = 3;
            cmbLista.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLista.ForeColor = Color.Black;
            cmbLista.IconColor = Color.DarkSlateGray;
            cmbLista.ListBackColor = SystemColors.Info;
            cmbLista.ListTextColor = Color.DimGray;
            cmbLista.Name = "cmbLista";
            cmbLista.Tag = "Selecciones un tipo de pago";
            cmbLista.Texts = "Seleccione una lista";
            cmbLista.OnSelectedIndexChanged += CmbLista_OnSelectedIndexChanged;
            // 
            // textBoxPersonalizado1
            // 
            resources.ApplyResources(textBoxPersonalizado1, "textBoxPersonalizado1");
            textBoxPersonalizado1.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado1.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado1.BorderRadius = 0;
            textBoxPersonalizado1.BorderSize = 2;
            textBoxPersonalizado1.Multiline = false;
            textBoxPersonalizado1.Name = "textBoxPersonalizado1";
            textBoxPersonalizado1.PasswordChar = false;
            textBoxPersonalizado1.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado1.PlaceholderText = "";
            textBoxPersonalizado1.Texts = "";
            textBoxPersonalizado1.UnderlinedStyle = true;
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.ForeColor = Color.LightSlateGray;
            label18.Name = "label18";
            // 
            // textBoxPersonalizado2
            // 
            resources.ApplyResources(textBoxPersonalizado2, "textBoxPersonalizado2");
            textBoxPersonalizado2.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado2.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado2.BorderRadius = 0;
            textBoxPersonalizado2.BorderSize = 2;
            textBoxPersonalizado2.Multiline = false;
            textBoxPersonalizado2.Name = "textBoxPersonalizado2";
            textBoxPersonalizado2.PasswordChar = false;
            textBoxPersonalizado2.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado2.PlaceholderText = "";
            textBoxPersonalizado2.Texts = "";
            textBoxPersonalizado2.UnderlinedStyle = true;
            textBoxPersonalizado2.KeyPress += textBoxPersonalizado2_KeyPress;
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.ForeColor = Color.LightSlateGray;
            label20.Name = "label20";
            // 
            // textBoxPersonalizado3
            // 
            resources.ApplyResources(textBoxPersonalizado3, "textBoxPersonalizado3");
            textBoxPersonalizado3.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado3.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado3.BorderRadius = 0;
            textBoxPersonalizado3.BorderSize = 2;
            textBoxPersonalizado3.Multiline = false;
            textBoxPersonalizado3.Name = "textBoxPersonalizado3";
            textBoxPersonalizado3.PasswordChar = false;
            textBoxPersonalizado3.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado3.PlaceholderText = "";
            textBoxPersonalizado3.Texts = "";
            textBoxPersonalizado3.UnderlinedStyle = true;
            textBoxPersonalizado3.KeyPress += textBoxPersonalizado3_KeyPress;
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.ForeColor = Color.LightSlateGray;
            label21.Name = "label21";
            // 
            // textBoxPersonalizado4
            // 
            resources.ApplyResources(textBoxPersonalizado4, "textBoxPersonalizado4");
            textBoxPersonalizado4.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado4.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado4.BorderRadius = 0;
            textBoxPersonalizado4.BorderSize = 2;
            textBoxPersonalizado4.Multiline = false;
            textBoxPersonalizado4.Name = "textBoxPersonalizado4";
            textBoxPersonalizado4.PasswordChar = false;
            textBoxPersonalizado4.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado4.PlaceholderText = "";
            textBoxPersonalizado4.Texts = "";
            textBoxPersonalizado4.UnderlinedStyle = true;
            textBoxPersonalizado4.KeyPress += textBoxPersonalizado4_KeyPress;
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.ForeColor = Color.LightSlateGray;
            label22.Name = "label22";
            // 
            // textBoxPersonalizado5
            // 
            resources.ApplyResources(textBoxPersonalizado5, "textBoxPersonalizado5");
            textBoxPersonalizado5.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado5.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado5.BorderRadius = 0;
            textBoxPersonalizado5.BorderSize = 2;
            textBoxPersonalizado5.Multiline = false;
            textBoxPersonalizado5.Name = "textBoxPersonalizado5";
            textBoxPersonalizado5.PasswordChar = false;
            textBoxPersonalizado5.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado5.PlaceholderText = "";
            textBoxPersonalizado5.Texts = "";
            textBoxPersonalizado5.UnderlinedStyle = true;
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.ForeColor = Color.LightSlateGray;
            label23.Name = "label23";
            // 
            // textBoxPersonalizado6
            // 
            resources.ApplyResources(textBoxPersonalizado6, "textBoxPersonalizado6");
            textBoxPersonalizado6.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado6.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado6.BorderRadius = 0;
            textBoxPersonalizado6.BorderSize = 2;
            textBoxPersonalizado6.Multiline = false;
            textBoxPersonalizado6.Name = "textBoxPersonalizado6";
            textBoxPersonalizado6.PasswordChar = false;
            textBoxPersonalizado6.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado6.PlaceholderText = "";
            textBoxPersonalizado6.Texts = "";
            textBoxPersonalizado6.UnderlinedStyle = true;
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.ForeColor = Color.LightSlateGray;
            label24.Name = "label24";
            // 
            // rjComboBox1
            // 
            resources.ApplyResources(rjComboBox1, "rjComboBox1");
            rjComboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            rjComboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            rjComboBox1.BackColor = SystemColors.HighlightText;
            rjComboBox1.BorderColor = Color.DarkSlateGray;
            rjComboBox1.BorderSize = 3;
            rjComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            rjComboBox1.ForeColor = Color.Black;
            rjComboBox1.IconColor = Color.DarkSlateGray;
            rjComboBox1.Items.AddRange(new object[] { resources.GetString("rjComboBox1.Items"), resources.GetString("rjComboBox1.Items1"), resources.GetString("rjComboBox1.Items2") });
            rjComboBox1.ListBackColor = SystemColors.Info;
            rjComboBox1.ListTextColor = Color.DimGray;
            rjComboBox1.Name = "rjComboBox1";
            rjComboBox1.Tag = "Seleccione un interés";
            rjComboBox1.Texts = "Seleccione un interés";
            // 
            // label28
            // 
            resources.ApplyResources(label28, "label28");
            label28.ForeColor = Color.LightSlateGray;
            label28.Name = "label28";
            // 
            // rjComboBox2
            // 
            resources.ApplyResources(rjComboBox2, "rjComboBox2");
            rjComboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            rjComboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            rjComboBox2.BackColor = SystemColors.HighlightText;
            rjComboBox2.BorderColor = Color.DarkSlateGray;
            rjComboBox2.BorderSize = 3;
            rjComboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            rjComboBox2.ForeColor = Color.Black;
            rjComboBox2.IconColor = Color.DarkSlateGray;
            rjComboBox2.Items.AddRange(new object[] { resources.GetString("rjComboBox2.Items"), resources.GetString("rjComboBox2.Items1") });
            rjComboBox2.ListBackColor = SystemColors.Info;
            rjComboBox2.ListTextColor = Color.DimGray;
            rjComboBox2.Name = "rjComboBox2";
            rjComboBox2.Tag = "Selecciones un tipo de pago";
            rjComboBox2.Texts = "Seleccione un tipo de pago";
            rjComboBox2.OnSelectedIndexChanged += rjComboBox2_OnSelectedIndexChanged;
            // 
            // label30
            // 
            resources.ApplyResources(label30, "label30");
            label30.ForeColor = Color.LightSlateGray;
            label30.Name = "label30";
            // 
            // label31
            // 
            resources.ApplyResources(label31, "label31");
            label31.ForeColor = Color.LightSlateGray;
            label31.Name = "label31";
            // 
            // dateTimePickerPersonalizado1
            // 
            resources.ApplyResources(dateTimePickerPersonalizado1, "dateTimePickerPersonalizado1");
            dateTimePickerPersonalizado1.BorderColor = Color.DarkSlateGray;
            dateTimePickerPersonalizado1.BorderSize = 2;
            dateTimePickerPersonalizado1.Name = "dateTimePickerPersonalizado1";
            dateTimePickerPersonalizado1.SkinColor = SystemColors.Info;
            dateTimePickerPersonalizado1.TextColor = Color.Black;
            dateTimePickerPersonalizado1.ValueChanged += dateTimePickerPersonalizado1_ValueChanged;
            // 
            // label32
            // 
            resources.ApplyResources(label32, "label32");
            label32.ForeColor = Color.LightSlateGray;
            label32.Name = "label32";
            label32.Click += label32_Click;
            // 
            // textBoxPersonalizado9
            // 
            resources.ApplyResources(textBoxPersonalizado9, "textBoxPersonalizado9");
            textBoxPersonalizado9.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado9.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado9.BorderRadius = 0;
            textBoxPersonalizado9.BorderSize = 2;
            textBoxPersonalizado9.Multiline = false;
            textBoxPersonalizado9.Name = "textBoxPersonalizado9";
            textBoxPersonalizado9.PasswordChar = false;
            textBoxPersonalizado9.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado9.PlaceholderText = "";
            textBoxPersonalizado9.Texts = "";
            textBoxPersonalizado9.UnderlinedStyle = true;
            textBoxPersonalizado9.KeyPress += textBoxPersonalizado9_KeyPress;
            // 
            // label33
            // 
            resources.ApplyResources(label33, "label33");
            label33.ForeColor = Color.LightSlateGray;
            label33.Name = "label33";
            // 
            // textBoxPersonalizado10
            // 
            resources.ApplyResources(textBoxPersonalizado10, "textBoxPersonalizado10");
            textBoxPersonalizado10.BorderColor = Color.DarkSlateGray;
            textBoxPersonalizado10.BorderFocusColor = SystemColors.Info;
            textBoxPersonalizado10.BorderRadius = 0;
            textBoxPersonalizado10.BorderSize = 2;
            textBoxPersonalizado10.Multiline = false;
            textBoxPersonalizado10.Name = "textBoxPersonalizado10";
            textBoxPersonalizado10.PasswordChar = false;
            textBoxPersonalizado10.PlaceholderColor = Color.DimGray;
            textBoxPersonalizado10.PlaceholderText = "";
            textBoxPersonalizado10.Texts = "";
            textBoxPersonalizado10.UnderlinedStyle = true;
            // 
            // label34
            // 
            resources.ApplyResources(label34, "label34");
            label34.ForeColor = Color.LightSlateGray;
            label34.Name = "label34";
            // 
            // rjComboBox3
            // 
            resources.ApplyResources(rjComboBox3, "rjComboBox3");
            rjComboBox3.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("rjComboBox3.AutoCompleteCustomSource"), resources.GetString("rjComboBox3.AutoCompleteCustomSource1"), resources.GetString("rjComboBox3.AutoCompleteCustomSource2") });
            rjComboBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            rjComboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            rjComboBox3.BackColor = SystemColors.HighlightText;
            rjComboBox3.BorderColor = Color.DarkSlateGray;
            rjComboBox3.BorderSize = 3;
            rjComboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            rjComboBox3.ForeColor = Color.Black;
            rjComboBox3.IconColor = Color.DarkSlateGray;
            rjComboBox3.ListBackColor = SystemColors.Info;
            rjComboBox3.ListTextColor = Color.DimGray;
            rjComboBox3.Name = "rjComboBox3";
            rjComboBox3.Tag = "Seleccione al promotor";
            rjComboBox3.Texts = "Seleccione al promotor";
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 20;
            bunifuElipse1.TargetControl = pictureBox1;
            // 
            // PanelBien
            // 
            resources.ApplyResources(PanelBien, "PanelBien");
            PanelBien.BackColor = SystemColors.ButtonHighlight;
            PanelBien.Controls.Add(label58);
            PanelBien.Controls.Add(label56);
            PanelBien.Controls.Add(label55);
            PanelBien.Controls.Add(label54);
            PanelBien.Controls.Add(label53);
            PanelBien.Controls.Add(label52);
            PanelBien.Controls.Add(label19);
            PanelBien.Name = "PanelBien";
            PanelBien.SizeChanged += PanelBien_SizeChanged;
            // 
            // label58
            // 
            resources.ApplyResources(label58, "label58");
            label58.BackColor = SystemColors.ButtonHighlight;
            label58.ForeColor = Color.Red;
            label58.Name = "label58";
            // 
            // label56
            // 
            resources.ApplyResources(label56, "label56");
            label56.Name = "label56";
            // 
            // label55
            // 
            resources.ApplyResources(label55, "label55");
            label55.Name = "label55";
            // 
            // label54
            // 
            resources.ApplyResources(label54, "label54");
            label54.Name = "label54";
            // 
            // label53
            // 
            resources.ApplyResources(label53, "label53");
            label53.Name = "label53";
            // 
            // label52
            // 
            resources.ApplyResources(label52, "label52");
            label52.ForeColor = Color.Red;
            label52.Name = "label52";
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(tabControl1);
            panel2.Name = "panel2";
            // 
            // tabControl1
            // 
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(Conexion_Sql);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.BackColor = SystemColors.ButtonHighlight;
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Name = "tabPage1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(flowLayoutPanel4, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel6, 1, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(flowLayoutPanel4, "flowLayoutPanel4");
            flowLayoutPanel4.BackColor = SystemColors.ButtonHighlight;
            flowLayoutPanel4.Controls.Add(label35);
            flowLayoutPanel4.Controls.Add(label36);
            flowLayoutPanel4.Controls.Add(textBox1);
            flowLayoutPanel4.Controls.Add(label37);
            flowLayoutPanel4.Controls.Add(TextboxContr);
            flowLayoutPanel4.Controls.Add(label38);
            flowLayoutPanel4.Controls.Add(TextboxConfirm);
            flowLayoutPanel4.Controls.Add(checkBox1);
            flowLayoutPanel4.Controls.Add(Button1);
            flowLayoutPanel4.Controls.Add(AvisoVacio);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // label35
            // 
            resources.ApplyResources(label35, "label35");
            label35.BackColor = SystemColors.ButtonHighlight;
            label35.ForeColor = Color.DarkSlateGray;
            label35.Name = "label35";
            // 
            // label36
            // 
            resources.ApplyResources(label36, "label36");
            label36.ForeColor = Color.LightSlateGray;
            label36.Name = "label36";
            // 
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.BackColor = SystemColors.Info;
            textBox1.Name = "textBox1";
            // 
            // label37
            // 
            resources.ApplyResources(label37, "label37");
            label37.ForeColor = Color.LightSlateGray;
            label37.Name = "label37";
            // 
            // TextboxContr
            // 
            resources.ApplyResources(TextboxContr, "TextboxContr");
            TextboxContr.BackColor = SystemColors.Info;
            TextboxContr.Name = "TextboxContr";
            TextboxContr.UseSystemPasswordChar = true;
            // 
            // label38
            // 
            resources.ApplyResources(label38, "label38");
            label38.ForeColor = Color.LightSlateGray;
            label38.Name = "label38";
            // 
            // TextboxConfirm
            // 
            resources.ApplyResources(TextboxConfirm, "TextboxConfirm");
            TextboxConfirm.BackColor = SystemColors.Info;
            TextboxConfirm.Name = "TextboxConfirm";
            TextboxConfirm.UseSystemPasswordChar = true;
            // 
            // checkBox1
            // 
            resources.ApplyResources(checkBox1, "checkBox1");
            checkBox1.ForeColor = Color.LightSlateGray;
            checkBox1.Name = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            // 
            // Button1
            // 
            resources.ApplyResources(Button1, "Button1");
            Button1.BackColor = SystemColors.ActiveCaption;
            Button1.BackgroundColor = SystemColors.ActiveCaption;
            Button1.BorderColor = Color.PaleVioletRed;
            Button1.BorderRadius = 20;
            Button1.BorderSize = 0;
            Button1.FlatAppearance.BorderSize = 0;
            Button1.ForeColor = Color.Azure;
            Button1.Name = "Button1";
            Button1.TextColor = Color.Azure;
            Button1.UseVisualStyleBackColor = false;
            Button1.Click += Button1_Click_2;
            // 
            // AvisoVacio
            // 
            resources.ApplyResources(AvisoVacio, "AvisoVacio");
            AvisoVacio.ForeColor = Color.Red;
            AvisoVacio.Name = "AvisoVacio";
            // 
            // flowLayoutPanel6
            // 
            resources.ApplyResources(flowLayoutPanel6, "flowLayoutPanel6");
            flowLayoutPanel6.Controls.Add(label39);
            flowLayoutPanel6.Controls.Add(label40);
            flowLayoutPanel6.Controls.Add(comboBox1);
            flowLayoutPanel6.Controls.Add(Boton_Permisos);
            flowLayoutPanel6.Controls.Add(label41);
            flowLayoutPanel6.Controls.Add(textBox2);
            flowLayoutPanel6.Controls.Add(label42);
            flowLayoutPanel6.Controls.Add(textBox3);
            flowLayoutPanel6.Controls.Add(checkBox2);
            flowLayoutPanel6.Controls.Add(panel3);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            // 
            // label39
            // 
            resources.ApplyResources(label39, "label39");
            label39.ForeColor = Color.DarkSlateGray;
            label39.Name = "label39";
            // 
            // label40
            // 
            resources.ApplyResources(label40, "label40");
            label40.ForeColor = Color.LightSlateGray;
            label40.Name = "label40";
            // 
            // comboBox1
            // 
            resources.ApplyResources(comboBox1, "comboBox1");
            comboBox1.BackColor = SystemColors.Info;
            comboBox1.BorderColor = Color.Black;
            comboBox1.BorderSize = 3;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox1.ForeColor = Color.LightSlateGray;
            comboBox1.IconColor = Color.Black;
            comboBox1.ListBackColor = SystemColors.ButtonHighlight;
            comboBox1.ListTextColor = Color.Black;
            comboBox1.Name = "comboBox1";
            comboBox1.Texts = "Seleccione un Usuario";
            comboBox1.OnSelectedIndexChanged += comboBox1_OnSelectedIndexChanged;
            // 
            // Boton_Permisos
            // 
            resources.ApplyResources(Boton_Permisos, "Boton_Permisos");
            Boton_Permisos.BackColor = SystemColors.ActiveCaption;
            Boton_Permisos.BackgroundColor = SystemColors.ActiveCaption;
            Boton_Permisos.BorderColor = Color.PaleVioletRed;
            Boton_Permisos.BorderRadius = 20;
            Boton_Permisos.BorderSize = 0;
            Boton_Permisos.FlatAppearance.BorderSize = 0;
            Boton_Permisos.ForeColor = Color.Azure;
            Boton_Permisos.Name = "Boton_Permisos";
            Boton_Permisos.TextColor = Color.Azure;
            Boton_Permisos.UseVisualStyleBackColor = false;
            Boton_Permisos.Click += Boton_Permisos_Click;
            // 
            // label41
            // 
            resources.ApplyResources(label41, "label41");
            label41.ForeColor = Color.LightSlateGray;
            label41.Name = "label41";
            // 
            // textBox2
            // 
            resources.ApplyResources(textBox2, "textBox2");
            textBox2.BackColor = SystemColors.Info;
            textBox2.ForeColor = Color.LightSlateGray;
            textBox2.Name = "textBox2";
            // 
            // label42
            // 
            resources.ApplyResources(label42, "label42");
            label42.ForeColor = Color.LightSlateGray;
            label42.Name = "label42";
            // 
            // textBox3
            // 
            resources.ApplyResources(textBox3, "textBox3");
            textBox3.BackColor = SystemColors.Info;
            textBox3.Name = "textBox3";
            textBox3.UseSystemPasswordChar = true;
            // 
            // checkBox2
            // 
            resources.ApplyResources(checkBox2, "checkBox2");
            checkBox2.ForeColor = Color.LightSlateGray;
            checkBox2.Name = "checkBox2";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Controls.Add(rjButton11);
            panel3.Controls.Add(rjButton12);
            panel3.Name = "panel3";
            // 
            // rjButton11
            // 
            resources.ApplyResources(rjButton11, "rjButton11");
            rjButton11.BackColor = SystemColors.ActiveCaption;
            rjButton11.BackgroundColor = SystemColors.ActiveCaption;
            rjButton11.BorderColor = Color.PaleVioletRed;
            rjButton11.BorderRadius = 20;
            rjButton11.BorderSize = 0;
            rjButton11.FlatAppearance.BorderSize = 0;
            rjButton11.ForeColor = Color.Azure;
            rjButton11.Name = "rjButton11";
            rjButton11.TextColor = Color.Azure;
            rjButton11.UseVisualStyleBackColor = false;
            rjButton11.Click += rjButton11_Click;
            // 
            // rjButton12
            // 
            resources.ApplyResources(rjButton12, "rjButton12");
            rjButton12.BackColor = Color.IndianRed;
            rjButton12.BackgroundColor = Color.IndianRed;
            rjButton12.BorderColor = Color.PaleVioletRed;
            rjButton12.BorderRadius = 20;
            rjButton12.BorderSize = 0;
            rjButton12.FlatAppearance.BorderSize = 0;
            rjButton12.ForeColor = Color.Azure;
            rjButton12.Name = "rjButton12";
            rjButton12.TextColor = Color.Azure;
            rjButton12.UseVisualStyleBackColor = false;
            rjButton12.Click += rjButton12_Click;
            // 
            // Conexion_Sql
            // 
            resources.ApplyResources(Conexion_Sql, "Conexion_Sql");
            Conexion_Sql.BackColor = SystemColors.ButtonHighlight;
            Conexion_Sql.Controls.Add(PingLabel);
            Conexion_Sql.Controls.Add(rjButton3);
            Conexion_Sql.Controls.Add(LabelEstado);
            Conexion_Sql.Controls.Add(label51);
            Conexion_Sql.Controls.Add(rjButton2);
            Conexion_Sql.Controls.Add(checkBox3);
            Conexion_Sql.Controls.Add(label50);
            Conexion_Sql.Controls.Add(label49);
            Conexion_Sql.Controls.Add(TextContra);
            Conexion_Sql.Controls.Add(TextUsuario);
            Conexion_Sql.Controls.Add(TextBase);
            Conexion_Sql.Controls.Add(TextPuerto);
            Conexion_Sql.Controls.Add(TextServer);
            Conexion_Sql.Controls.Add(label48);
            Conexion_Sql.Controls.Add(label47);
            Conexion_Sql.Controls.Add(label46);
            Conexion_Sql.Controls.Add(label45);
            Conexion_Sql.Controls.Add(label44);
            Conexion_Sql.Controls.Add(label43);
            Conexion_Sql.ForeColor = SystemColors.ControlDarkDark;
            Conexion_Sql.Name = "Conexion_Sql";
            // 
            // PingLabel
            // 
            resources.ApplyResources(PingLabel, "PingLabel");
            PingLabel.ForeColor = Color.Red;
            PingLabel.Name = "PingLabel";
            // 
            // rjButton3
            // 
            resources.ApplyResources(rjButton3, "rjButton3");
            rjButton3.BackColor = SystemColors.ActiveCaption;
            rjButton3.BackgroundColor = SystemColors.ActiveCaption;
            rjButton3.BorderColor = Color.PaleVioletRed;
            rjButton3.BorderRadius = 20;
            rjButton3.BorderSize = 0;
            rjButton3.FlatAppearance.BorderSize = 0;
            rjButton3.ForeColor = Color.White;
            rjButton3.Name = "rjButton3";
            rjButton3.TextColor = Color.White;
            rjButton3.UseVisualStyleBackColor = false;
            rjButton3.Click += RjButton3_ClickAsync;
            // 
            // LabelEstado
            // 
            resources.ApplyResources(LabelEstado, "LabelEstado");
            LabelEstado.ForeColor = Color.Red;
            LabelEstado.Name = "LabelEstado";
            // 
            // label51
            // 
            resources.ApplyResources(label51, "label51");
            label51.ForeColor = Color.DarkSlateGray;
            label51.Name = "label51";
            // 
            // rjButton2
            // 
            resources.ApplyResources(rjButton2, "rjButton2");
            rjButton2.BackColor = Color.IndianRed;
            rjButton2.BackgroundColor = Color.IndianRed;
            rjButton2.BorderColor = Color.PaleVioletRed;
            rjButton2.BorderRadius = 20;
            rjButton2.BorderSize = 0;
            rjButton2.FlatAppearance.BorderSize = 0;
            rjButton2.ForeColor = Color.Azure;
            rjButton2.Name = "rjButton2";
            rjButton2.TextColor = Color.Azure;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += RjButton2_Click;
            // 
            // checkBox3
            // 
            resources.ApplyResources(checkBox3, "checkBox3");
            checkBox3.ForeColor = Color.LightSlateGray;
            checkBox3.Name = "checkBox3";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += CheckBox3_CheckedChanged;
            // 
            // label50
            // 
            resources.ApplyResources(label50, "label50");
            label50.ForeColor = Color.Red;
            label50.Name = "label50";
            // 
            // label49
            // 
            resources.ApplyResources(label49, "label49");
            label49.Name = "label49";
            // 
            // TextContra
            // 
            resources.ApplyResources(TextContra, "TextContra");
            TextContra.BackColor = SystemColors.Info;
            TextContra.Name = "TextContra";
            TextContra.UseSystemPasswordChar = true;
            // 
            // TextUsuario
            // 
            resources.ApplyResources(TextUsuario, "TextUsuario");
            TextUsuario.BackColor = SystemColors.Info;
            TextUsuario.Name = "TextUsuario";
            // 
            // TextBase
            // 
            resources.ApplyResources(TextBase, "TextBase");
            TextBase.BackColor = SystemColors.Info;
            TextBase.Name = "TextBase";
            // 
            // TextPuerto
            // 
            resources.ApplyResources(TextPuerto, "TextPuerto");
            TextPuerto.BackColor = SystemColors.Info;
            TextPuerto.Name = "TextPuerto";
            // 
            // TextServer
            // 
            resources.ApplyResources(TextServer, "TextServer");
            TextServer.BackColor = SystemColors.Info;
            TextServer.Name = "TextServer";
            // 
            // label48
            // 
            resources.ApplyResources(label48, "label48");
            label48.ForeColor = Color.LightSlateGray;
            label48.Name = "label48";
            // 
            // label47
            // 
            resources.ApplyResources(label47, "label47");
            label47.ForeColor = Color.LightSlateGray;
            label47.Name = "label47";
            // 
            // label46
            // 
            resources.ApplyResources(label46, "label46");
            label46.ForeColor = Color.LightSlateGray;
            label46.Name = "label46";
            // 
            // label45
            // 
            resources.ApplyResources(label45, "label45");
            label45.ForeColor = Color.LightSlateGray;
            label45.Name = "label45";
            // 
            // label44
            // 
            resources.ApplyResources(label44, "label44");
            label44.ForeColor = Color.LightSlateGray;
            label44.Name = "label44";
            // 
            // label43
            // 
            resources.ApplyResources(label43, "label43");
            label43.ForeColor = Color.DarkSlateGray;
            label43.Name = "label43";
            // 
            // tabPage2
            // 
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.BackColor = SystemColors.ButtonHighlight;
            tabPage2.Controls.Add(rjButton6);
            tabPage2.Controls.Add(rjButton5);
            tabPage2.Controls.Add(rjButton4);
            tabPage2.Controls.Add(label64);
            tabPage2.Controls.Add(textBox5);
            tabPage2.Controls.Add(rjComboBox4);
            tabPage2.Controls.Add(label62);
            tabPage2.Controls.Add(label63);
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(label61);
            tabPage2.Controls.Add(label60);
            tabPage2.Controls.Add(label59);
            tabPage2.Name = "tabPage2";
            // 
            // rjButton6
            // 
            resources.ApplyResources(rjButton6, "rjButton6");
            rjButton6.BackColor = Color.IndianRed;
            rjButton6.BackgroundColor = Color.IndianRed;
            rjButton6.BorderColor = Color.PaleVioletRed;
            rjButton6.BorderRadius = 20;
            rjButton6.BorderSize = 0;
            rjButton6.FlatAppearance.BorderSize = 0;
            rjButton6.ForeColor = Color.White;
            rjButton6.Name = "rjButton6";
            rjButton6.TextColor = Color.White;
            rjButton6.UseVisualStyleBackColor = false;
            rjButton6.Click += RjButton6_Click;
            // 
            // rjButton5
            // 
            resources.ApplyResources(rjButton5, "rjButton5");
            rjButton5.BackColor = SystemColors.ActiveCaption;
            rjButton5.BackgroundColor = SystemColors.ActiveCaption;
            rjButton5.BorderColor = Color.PaleVioletRed;
            rjButton5.BorderRadius = 20;
            rjButton5.BorderSize = 0;
            rjButton5.FlatAppearance.BorderSize = 0;
            rjButton5.ForeColor = Color.White;
            rjButton5.Name = "rjButton5";
            rjButton5.TextColor = Color.White;
            rjButton5.UseVisualStyleBackColor = false;
            rjButton5.Click += RjButton5_Click;
            // 
            // rjButton4
            // 
            resources.ApplyResources(rjButton4, "rjButton4");
            rjButton4.BackColor = SystemColors.ActiveCaption;
            rjButton4.BackgroundColor = SystemColors.ActiveCaption;
            rjButton4.BorderColor = Color.PaleVioletRed;
            rjButton4.BorderRadius = 20;
            rjButton4.BorderSize = 0;
            rjButton4.FlatAppearance.BorderSize = 0;
            rjButton4.ForeColor = Color.White;
            rjButton4.Name = "rjButton4";
            rjButton4.TextColor = Color.White;
            rjButton4.UseVisualStyleBackColor = false;
            rjButton4.Click += RjButton4_Click;
            // 
            // label64
            // 
            resources.ApplyResources(label64, "label64");
            label64.ForeColor = Color.LightSlateGray;
            label64.Name = "label64";
            // 
            // textBox5
            // 
            resources.ApplyResources(textBox5, "textBox5");
            textBox5.BackColor = SystemColors.Info;
            textBox5.Name = "textBox5";
            textBox5.TextChanged += TextBox5_TextChanged;
            // 
            // rjComboBox4
            // 
            resources.ApplyResources(rjComboBox4, "rjComboBox4");
            rjComboBox4.BackColor = SystemColors.Info;
            rjComboBox4.BorderColor = Color.Black;
            rjComboBox4.BorderSize = 3;
            rjComboBox4.DropDownStyle = ComboBoxStyle.DropDown;
            rjComboBox4.ForeColor = Color.DimGray;
            rjComboBox4.IconColor = Color.Black;
            rjComboBox4.ListBackColor = SystemColors.ButtonHighlight;
            rjComboBox4.ListTextColor = Color.Black;
            rjComboBox4.Name = "rjComboBox4";
            rjComboBox4.Texts = "Promotor";
            rjComboBox4.OnSelectedIndexChanged += RjComboBox4_OnSelectedIndexChanged;
            // 
            // label62
            // 
            resources.ApplyResources(label62, "label62");
            label62.ForeColor = Color.LightSlateGray;
            label62.Name = "label62";
            // 
            // label63
            // 
            resources.ApplyResources(label63, "label63");
            label63.ForeColor = Color.LightSlateGray;
            label63.Name = "label63";
            // 
            // textBox4
            // 
            resources.ApplyResources(textBox4, "textBox4");
            textBox4.BackColor = SystemColors.Info;
            textBox4.Name = "textBox4";
            textBox4.TextChanged += TextBox4_TextChanged;
            // 
            // label61
            // 
            resources.ApplyResources(label61, "label61");
            label61.ForeColor = Color.DarkSlateGray;
            label61.Name = "label61";
            // 
            // label60
            // 
            resources.ApplyResources(label60, "label60");
            label60.ForeColor = Color.DarkSlateGray;
            label60.Name = "label60";
            // 
            // label59
            // 
            resources.ApplyResources(label59, "label59");
            label59.ForeColor = Color.DarkSlateGray;
            label59.Name = "label59";
            // 
            // PanelEditar2_2
            // 
            resources.ApplyResources(PanelEditar2_2, "PanelEditar2_2");
            PanelEditar2_2.BackColor = SystemColors.HighlightText;
            PanelEditar2_2.Controls.Add(rjButton7);
            PanelEditar2_2.Controls.Add(BotonVolverEditar2);
            PanelEditar2_2.Controls.Add(Botoncambiodefechamomentaneo);
            PanelEditar2_2.Controls.Add(TextBoxPagoExt);
            PanelEditar2_2.Controls.Add(label93);
            PanelEditar2_2.Controls.Add(LabelNombreEditar2_2);
            PanelEditar2_2.Controls.Add(label89);
            PanelEditar2_2.Controls.Add(TextBoxPago);
            PanelEditar2_2.Controls.Add(label86);
            PanelEditar2_2.Controls.Add(label85);
            PanelEditar2_2.Controls.Add(FechaEnLista2);
            PanelEditar2_2.Controls.Add(label71);
            PanelEditar2_2.Controls.Add(ComboBoxDeFechas);
            PanelEditar2_2.Name = "PanelEditar2_2";
            // 
            // rjButton7
            // 
            resources.ApplyResources(rjButton7, "rjButton7");
            rjButton7.BackColor = Color.SlateGray;
            rjButton7.BackgroundColor = Color.SlateGray;
            rjButton7.BorderColor = Color.PaleVioletRed;
            rjButton7.BorderRadius = 20;
            rjButton7.BorderSize = 0;
            rjButton7.FlatAppearance.BorderSize = 0;
            rjButton7.ForeColor = Color.White;
            rjButton7.Name = "rjButton7";
            rjButton7.TextColor = Color.White;
            rjButton7.UseVisualStyleBackColor = false;
            rjButton7.Click += rjButton7_Click;
            // 
            // BotonVolverEditar2
            // 
            resources.ApplyResources(BotonVolverEditar2, "BotonVolverEditar2");
            BotonVolverEditar2.BackColor = Color.SlateGray;
            BotonVolverEditar2.BackgroundColor = Color.SlateGray;
            BotonVolverEditar2.BorderColor = Color.PaleVioletRed;
            BotonVolverEditar2.BorderRadius = 20;
            BotonVolverEditar2.BorderSize = 0;
            BotonVolverEditar2.FlatAppearance.BorderSize = 0;
            BotonVolverEditar2.ForeColor = Color.White;
            BotonVolverEditar2.Name = "BotonVolverEditar2";
            BotonVolverEditar2.TextColor = Color.White;
            BotonVolverEditar2.UseVisualStyleBackColor = false;
            BotonVolverEditar2.Click += BotonVolverEditar2_Click_1;
            // 
            // Botoncambiodefechamomentaneo
            // 
            resources.ApplyResources(Botoncambiodefechamomentaneo, "Botoncambiodefechamomentaneo");
            Botoncambiodefechamomentaneo.BackColor = Color.IndianRed;
            Botoncambiodefechamomentaneo.BackgroundColor = Color.IndianRed;
            Botoncambiodefechamomentaneo.BorderColor = Color.PaleVioletRed;
            Botoncambiodefechamomentaneo.BorderRadius = 20;
            Botoncambiodefechamomentaneo.BorderSize = 0;
            Botoncambiodefechamomentaneo.FlatAppearance.BorderSize = 0;
            Botoncambiodefechamomentaneo.ForeColor = Color.White;
            Botoncambiodefechamomentaneo.Name = "Botoncambiodefechamomentaneo";
            Botoncambiodefechamomentaneo.TextColor = Color.White;
            Botoncambiodefechamomentaneo.UseVisualStyleBackColor = false;
            Botoncambiodefechamomentaneo.Click += Botoncambiodefechamomentaneo_Click_1;
            // 
            // TextBoxPagoExt
            // 
            resources.ApplyResources(TextBoxPagoExt, "TextBoxPagoExt");
            TextBoxPagoExt.BorderColor = Color.DarkSlateGray;
            TextBoxPagoExt.BorderFocusColor = SystemColors.Info;
            TextBoxPagoExt.BorderRadius = 0;
            TextBoxPagoExt.BorderSize = 2;
            TextBoxPagoExt.Multiline = false;
            TextBoxPagoExt.Name = "TextBoxPagoExt";
            TextBoxPagoExt.PasswordChar = false;
            TextBoxPagoExt.PlaceholderColor = Color.DimGray;
            TextBoxPagoExt.PlaceholderText = "";
            TextBoxPagoExt.Texts = "";
            TextBoxPagoExt.UnderlinedStyle = true;
            // 
            // label93
            // 
            resources.ApplyResources(label93, "label93");
            label93.ForeColor = Color.LightSlateGray;
            label93.Name = "label93";
            // 
            // LabelNombreEditar2_2
            // 
            resources.ApplyResources(LabelNombreEditar2_2, "LabelNombreEditar2_2");
            LabelNombreEditar2_2.ForeColor = Color.DarkSlateGray;
            LabelNombreEditar2_2.Name = "LabelNombreEditar2_2";
            // 
            // label89
            // 
            resources.ApplyResources(label89, "label89");
            label89.ForeColor = Color.DarkSlateGray;
            label89.Name = "label89";
            // 
            // TextBoxPago
            // 
            resources.ApplyResources(TextBoxPago, "TextBoxPago");
            TextBoxPago.BorderColor = Color.DarkSlateGray;
            TextBoxPago.BorderFocusColor = SystemColors.Info;
            TextBoxPago.BorderRadius = 0;
            TextBoxPago.BorderSize = 2;
            TextBoxPago.Multiline = false;
            TextBoxPago.Name = "TextBoxPago";
            TextBoxPago.PasswordChar = false;
            TextBoxPago.PlaceholderColor = Color.DimGray;
            TextBoxPago.PlaceholderText = "";
            TextBoxPago.Texts = "";
            TextBoxPago.UnderlinedStyle = true;
            TextBoxPago.TextChanged2EventHandler += TextBoxPagoTextChanged2EventHandler;
            TextBoxPago.KeyPress += TextBoxPago_KeyPress;
            // 
            // label86
            // 
            resources.ApplyResources(label86, "label86");
            label86.ForeColor = Color.LightSlateGray;
            label86.Name = "label86";
            // 
            // label85
            // 
            resources.ApplyResources(label85, "label85");
            label85.ForeColor = Color.LightSlateGray;
            label85.Name = "label85";
            // 
            // FechaEnLista2
            // 
            resources.ApplyResources(FechaEnLista2, "FechaEnLista2");
            FechaEnLista2.BorderColor = Color.DarkSlateGray;
            FechaEnLista2.BorderSize = 3;
            FechaEnLista2.Name = "FechaEnLista2";
            FechaEnLista2.SkinColor = SystemColors.Info;
            FechaEnLista2.TextColor = Color.Black;
            // 
            // label71
            // 
            resources.ApplyResources(label71, "label71");
            label71.ForeColor = Color.LightSlateGray;
            label71.Name = "label71";
            // 
            // ComboBoxDeFechas
            // 
            resources.ApplyResources(ComboBoxDeFechas, "ComboBoxDeFechas");
            ComboBoxDeFechas.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComboBoxDeFechas.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboBoxDeFechas.BackColor = SystemColors.Info;
            ComboBoxDeFechas.BorderColor = Color.DarkSlateGray;
            ComboBoxDeFechas.BorderSize = 3;
            ComboBoxDeFechas.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxDeFechas.ForeColor = Color.Black;
            ComboBoxDeFechas.IconColor = Color.DarkSlateGray;
            ComboBoxDeFechas.Items.AddRange(new object[] { resources.GetString("ComboBoxDeFechas.Items"), resources.GetString("ComboBoxDeFechas.Items1") });
            ComboBoxDeFechas.ListBackColor = SystemColors.Info;
            ComboBoxDeFechas.ListTextColor = Color.DimGray;
            ComboBoxDeFechas.Name = "ComboBoxDeFechas";
            ComboBoxDeFechas.Tag = "Seleccione la fecha";
            ComboBoxDeFechas.Texts = "Seleccione la fecha";
            ComboBoxDeFechas.OnSelectedIndexChanged += ComboBoxDeFechas_OnSelectedIndexChanged;
            // 
            // PanelEditarLiquidados
            // 
            resources.ApplyResources(PanelEditarLiquidados, "PanelEditarLiquidados");
            PanelEditarLiquidados.BackColor = SystemColors.HighlightText;
            PanelEditarLiquidados.Controls.Add(BottonLiq);
            PanelEditarLiquidados.Controls.Add(FechaInicioLiq);
            PanelEditarLiquidados.Controls.Add(label91);
            PanelEditarLiquidados.Controls.Add(label90);
            PanelEditarLiquidados.Controls.Add(ComBoBoxLiquidacion);
            PanelEditarLiquidados.Controls.Add(label104);
            PanelEditarLiquidados.Controls.Add(label106);
            PanelEditarLiquidados.Controls.Add(TextCorreoLiq);
            PanelEditarLiquidados.Controls.Add(label107);
            PanelEditarLiquidados.Controls.Add(TextTelefonoLiq);
            PanelEditarLiquidados.Controls.Add(label108);
            PanelEditarLiquidados.Controls.Add(TextNumExtLiq);
            PanelEditarLiquidados.Controls.Add(label109);
            PanelEditarLiquidados.Controls.Add(TextNumIntLiq);
            PanelEditarLiquidados.Controls.Add(label110);
            PanelEditarLiquidados.Controls.Add(TextColoniaLiq);
            PanelEditarLiquidados.Controls.Add(label111);
            PanelEditarLiquidados.Controls.Add(TextCalleLiq);
            PanelEditarLiquidados.Controls.Add(label112);
            PanelEditarLiquidados.Controls.Add(label113);
            PanelEditarLiquidados.Controls.Add(TextCreditoLiq);
            PanelEditarLiquidados.Controls.Add(label115);
            PanelEditarLiquidados.Controls.Add(TextNombreLiq);
            PanelEditarLiquidados.Controls.Add(label116);
            PanelEditarLiquidados.Controls.Add(ComboBoxPromotorLiq);
            PanelEditarLiquidados.Name = "PanelEditarLiquidados";
            // 
            // BottonLiq
            // 
            resources.ApplyResources(BottonLiq, "BottonLiq");
            BottonLiq.BackColor = Color.IndianRed;
            BottonLiq.BackgroundColor = Color.IndianRed;
            BottonLiq.BorderColor = Color.PaleVioletRed;
            BottonLiq.BorderRadius = 20;
            BottonLiq.BorderSize = 0;
            BottonLiq.FlatAppearance.BorderSize = 0;
            BottonLiq.ForeColor = Color.White;
            BottonLiq.Name = "BottonLiq";
            BottonLiq.TextColor = Color.White;
            BottonLiq.UseVisualStyleBackColor = false;
            BottonLiq.Click += BottonLiq_Click_1;
            // 
            // FechaInicioLiq
            // 
            resources.ApplyResources(FechaInicioLiq, "FechaInicioLiq");
            FechaInicioLiq.BorderColor = Color.DarkSlateGray;
            FechaInicioLiq.BorderSize = 3;
            FechaInicioLiq.Name = "FechaInicioLiq";
            FechaInicioLiq.SkinColor = SystemColors.Info;
            FechaInicioLiq.TextColor = Color.Black;
            // 
            // label91
            // 
            resources.ApplyResources(label91, "label91");
            label91.ForeColor = Color.LightSlateGray;
            label91.Name = "label91";
            // 
            // label90
            // 
            resources.ApplyResources(label90, "label90");
            label90.ForeColor = Color.LightSlateGray;
            label90.Name = "label90";
            // 
            // ComBoBoxLiquidacion
            // 
            resources.ApplyResources(ComBoBoxLiquidacion, "ComBoBoxLiquidacion");
            ComBoBoxLiquidacion.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("ComBoBoxLiquidacion.AutoCompleteCustomSource"), resources.GetString("ComBoBoxLiquidacion.AutoCompleteCustomSource1"), resources.GetString("ComBoBoxLiquidacion.AutoCompleteCustomSource2") });
            ComBoBoxLiquidacion.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComBoBoxLiquidacion.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComBoBoxLiquidacion.BackColor = SystemColors.HighlightText;
            ComBoBoxLiquidacion.BorderColor = Color.DarkSlateGray;
            ComBoBoxLiquidacion.BorderSize = 3;
            ComBoBoxLiquidacion.DropDownStyle = ComboBoxStyle.DropDownList;
            ComBoBoxLiquidacion.ForeColor = Color.Black;
            ComBoBoxLiquidacion.IconColor = Color.DarkSlateGray;
            ComBoBoxLiquidacion.Items.AddRange(new object[] { resources.GetString("ComBoBoxLiquidacion.Items"), resources.GetString("ComBoBoxLiquidacion.Items1"), resources.GetString("ComBoBoxLiquidacion.Items2") });
            ComBoBoxLiquidacion.ListBackColor = SystemColors.Info;
            ComBoBoxLiquidacion.ListTextColor = Color.DimGray;
            ComBoBoxLiquidacion.Name = "ComBoBoxLiquidacion";
            ComBoBoxLiquidacion.Tag = "";
            ComBoBoxLiquidacion.Texts = "Seleccione la lista ";
            // 
            // label104
            // 
            resources.ApplyResources(label104, "label104");
            label104.ForeColor = Color.DarkSlateGray;
            label104.Name = "label104";
            // 
            // label106
            // 
            resources.ApplyResources(label106, "label106");
            label106.ForeColor = Color.DarkSlateGray;
            label106.Name = "label106";
            // 
            // TextCorreoLiq
            // 
            resources.ApplyResources(TextCorreoLiq, "TextCorreoLiq");
            TextCorreoLiq.BorderColor = Color.DarkSlateGray;
            TextCorreoLiq.BorderFocusColor = SystemColors.Info;
            TextCorreoLiq.BorderRadius = 0;
            TextCorreoLiq.BorderSize = 2;
            TextCorreoLiq.Multiline = false;
            TextCorreoLiq.Name = "TextCorreoLiq";
            TextCorreoLiq.PasswordChar = false;
            TextCorreoLiq.PlaceholderColor = Color.DimGray;
            TextCorreoLiq.PlaceholderText = "";
            TextCorreoLiq.Texts = "";
            TextCorreoLiq.UnderlinedStyle = true;
            // 
            // label107
            // 
            resources.ApplyResources(label107, "label107");
            label107.ForeColor = Color.LightSlateGray;
            label107.Name = "label107";
            // 
            // TextTelefonoLiq
            // 
            resources.ApplyResources(TextTelefonoLiq, "TextTelefonoLiq");
            TextTelefonoLiq.BorderColor = Color.DarkSlateGray;
            TextTelefonoLiq.BorderFocusColor = SystemColors.Info;
            TextTelefonoLiq.BorderRadius = 0;
            TextTelefonoLiq.BorderSize = 2;
            TextTelefonoLiq.Multiline = false;
            TextTelefonoLiq.Name = "TextTelefonoLiq";
            TextTelefonoLiq.PasswordChar = false;
            TextTelefonoLiq.PlaceholderColor = Color.DimGray;
            TextTelefonoLiq.PlaceholderText = "";
            TextTelefonoLiq.Texts = "";
            TextTelefonoLiq.UnderlinedStyle = true;
            TextTelefonoLiq.KeyPress += TextTelefonoLiq_KeyPress;
            // 
            // label108
            // 
            resources.ApplyResources(label108, "label108");
            label108.ForeColor = Color.LightSlateGray;
            label108.Name = "label108";
            // 
            // TextNumExtLiq
            // 
            resources.ApplyResources(TextNumExtLiq, "TextNumExtLiq");
            TextNumExtLiq.BorderColor = Color.DarkSlateGray;
            TextNumExtLiq.BorderFocusColor = SystemColors.Info;
            TextNumExtLiq.BorderRadius = 0;
            TextNumExtLiq.BorderSize = 2;
            TextNumExtLiq.Multiline = false;
            TextNumExtLiq.Name = "TextNumExtLiq";
            TextNumExtLiq.PasswordChar = false;
            TextNumExtLiq.PlaceholderColor = Color.DimGray;
            TextNumExtLiq.PlaceholderText = "";
            TextNumExtLiq.Texts = "";
            TextNumExtLiq.UnderlinedStyle = true;
            TextNumExtLiq.KeyPress += TextNumExtLiq_KeyPress;
            // 
            // label109
            // 
            resources.ApplyResources(label109, "label109");
            label109.ForeColor = Color.LightSlateGray;
            label109.Name = "label109";
            // 
            // TextNumIntLiq
            // 
            resources.ApplyResources(TextNumIntLiq, "TextNumIntLiq");
            TextNumIntLiq.BorderColor = Color.DarkSlateGray;
            TextNumIntLiq.BorderFocusColor = SystemColors.Info;
            TextNumIntLiq.BorderRadius = 0;
            TextNumIntLiq.BorderSize = 2;
            TextNumIntLiq.Multiline = false;
            TextNumIntLiq.Name = "TextNumIntLiq";
            TextNumIntLiq.PasswordChar = false;
            TextNumIntLiq.PlaceholderColor = Color.DimGray;
            TextNumIntLiq.PlaceholderText = "";
            TextNumIntLiq.Texts = "";
            TextNumIntLiq.UnderlinedStyle = true;
            TextNumIntLiq.KeyPress += TextNumIntLiq_KeyPress;
            // 
            // label110
            // 
            resources.ApplyResources(label110, "label110");
            label110.ForeColor = Color.LightSlateGray;
            label110.Name = "label110";
            // 
            // TextColoniaLiq
            // 
            resources.ApplyResources(TextColoniaLiq, "TextColoniaLiq");
            TextColoniaLiq.BorderColor = Color.DarkSlateGray;
            TextColoniaLiq.BorderFocusColor = SystemColors.Info;
            TextColoniaLiq.BorderRadius = 0;
            TextColoniaLiq.BorderSize = 2;
            TextColoniaLiq.Multiline = false;
            TextColoniaLiq.Name = "TextColoniaLiq";
            TextColoniaLiq.PasswordChar = false;
            TextColoniaLiq.PlaceholderColor = Color.DimGray;
            TextColoniaLiq.PlaceholderText = "";
            TextColoniaLiq.Texts = "";
            TextColoniaLiq.UnderlinedStyle = true;
            // 
            // label111
            // 
            resources.ApplyResources(label111, "label111");
            label111.ForeColor = Color.LightSlateGray;
            label111.Name = "label111";
            // 
            // TextCalleLiq
            // 
            resources.ApplyResources(TextCalleLiq, "TextCalleLiq");
            TextCalleLiq.BorderColor = Color.DarkSlateGray;
            TextCalleLiq.BorderFocusColor = SystemColors.Info;
            TextCalleLiq.BorderRadius = 0;
            TextCalleLiq.BorderSize = 2;
            TextCalleLiq.Multiline = false;
            TextCalleLiq.Name = "TextCalleLiq";
            TextCalleLiq.PasswordChar = false;
            TextCalleLiq.PlaceholderColor = Color.DimGray;
            TextCalleLiq.PlaceholderText = "";
            TextCalleLiq.Texts = "";
            TextCalleLiq.UnderlinedStyle = true;
            // 
            // label112
            // 
            resources.ApplyResources(label112, "label112");
            label112.ForeColor = Color.LightSlateGray;
            label112.Name = "label112";
            // 
            // label113
            // 
            resources.ApplyResources(label113, "label113");
            label113.ForeColor = Color.LightSlateGray;
            label113.Name = "label113";
            // 
            // TextCreditoLiq
            // 
            resources.ApplyResources(TextCreditoLiq, "TextCreditoLiq");
            TextCreditoLiq.BorderColor = Color.DarkSlateGray;
            TextCreditoLiq.BorderFocusColor = SystemColors.Info;
            TextCreditoLiq.BorderRadius = 0;
            TextCreditoLiq.BorderSize = 2;
            TextCreditoLiq.Multiline = false;
            TextCreditoLiq.Name = "TextCreditoLiq";
            TextCreditoLiq.PasswordChar = false;
            TextCreditoLiq.PlaceholderColor = Color.DimGray;
            TextCreditoLiq.PlaceholderText = "";
            TextCreditoLiq.Texts = "";
            TextCreditoLiq.UnderlinedStyle = true;
            TextCreditoLiq.KeyPress += TextCreditoLiq_KeyPress;
            // 
            // label115
            // 
            resources.ApplyResources(label115, "label115");
            label115.ForeColor = Color.LightSlateGray;
            label115.Name = "label115";
            // 
            // TextNombreLiq
            // 
            resources.ApplyResources(TextNombreLiq, "TextNombreLiq");
            TextNombreLiq.BorderColor = Color.DarkSlateGray;
            TextNombreLiq.BorderFocusColor = SystemColors.Info;
            TextNombreLiq.BorderRadius = 0;
            TextNombreLiq.BorderSize = 2;
            TextNombreLiq.Multiline = false;
            TextNombreLiq.Name = "TextNombreLiq";
            TextNombreLiq.PasswordChar = false;
            TextNombreLiq.PlaceholderColor = Color.DimGray;
            TextNombreLiq.PlaceholderText = "";
            TextNombreLiq.Texts = "";
            TextNombreLiq.UnderlinedStyle = true;
            // 
            // label116
            // 
            resources.ApplyResources(label116, "label116");
            label116.ForeColor = Color.LightSlateGray;
            label116.Name = "label116";
            // 
            // ComboBoxPromotorLiq
            // 
            resources.ApplyResources(ComboBoxPromotorLiq, "ComboBoxPromotorLiq");
            ComboBoxPromotorLiq.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("ComboBoxPromotorLiq.AutoCompleteCustomSource"), resources.GetString("ComboBoxPromotorLiq.AutoCompleteCustomSource1"), resources.GetString("ComboBoxPromotorLiq.AutoCompleteCustomSource2") });
            ComboBoxPromotorLiq.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComboBoxPromotorLiq.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboBoxPromotorLiq.BackColor = SystemColors.HighlightText;
            ComboBoxPromotorLiq.BorderColor = Color.DarkSlateGray;
            ComboBoxPromotorLiq.BorderSize = 3;
            ComboBoxPromotorLiq.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxPromotorLiq.ForeColor = Color.Black;
            ComboBoxPromotorLiq.IconColor = Color.DarkSlateGray;
            ComboBoxPromotorLiq.ListBackColor = SystemColors.Info;
            ComboBoxPromotorLiq.ListTextColor = Color.DimGray;
            ComboBoxPromotorLiq.Name = "ComboBoxPromotorLiq";
            ComboBoxPromotorLiq.Tag = "Seleccione al promotor";
            ComboBoxPromotorLiq.Texts = "Seleccione al promotor";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelBien);
            Controls.Add(panel2);
            Controls.Add(pnlListas);
            Controls.Add(PanelEditar);
            Controls.Add(pnlClientes);
            Controls.Add(PnlEditar2);
            Controls.Add(PanelEditar3);
            Controls.Add(PanelEditar2_2);
            Controls.Add(pnlRegPago);
            Controls.Add(PanelEditarLiquidados);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            FormClosed += Form1_FormClosed;
            panelMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((ISupportInitialize)pictureBox1).EndInit();
            PnlEditar2.ResumeLayout(false);
            PnlEditar2.PerformLayout();
            groupBox2.ResumeLayout(false);
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            pnlRegPago.ResumeLayout(false);
            pnlRegPago.PerformLayout();
            pnlClientes.ResumeLayout(false);
            pnlClientes.PerformLayout();
            PanelEditar3.ResumeLayout(false);
            PanelEditar3.PerformLayout();
            groupBox3.ResumeLayout(false);
            pnlListas.ResumeLayout(false);
            pnlListas.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((ISupportInitialize)gridListas).EndInit();
            PanelEditar.ResumeLayout(false);
            PanelEditar.PerformLayout();
            groupBox1.ResumeLayout(false);
            PanelBien.ResumeLayout(false);
            PanelBien.PerformLayout();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel6.PerformLayout();
            panel3.ResumeLayout(false);
            Conexion_Sql.ResumeLayout(false);
            Conexion_Sql.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            PanelEditar2_2.ResumeLayout(false);
            PanelEditar2_2.PerformLayout();
            PanelEditarLiquidados.ResumeLayout(false);
            PanelEditarLiquidados.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelMenu;
        private Panel panelTitleBar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private IconButton btnMenu;
        private IconButton btnIngresarClientes;
        private IconButton btnListas;
        private IconButton btnEstadoPagos;
        private IconButton btnTodosSistemas;
        private Label lblTitle;
        private Panel pnlListas;
        private RjButton btnLista1;
        private RjButton btnLista3;
        private RjButton btnLista2;
        private Label label8;
        private RjButton btnLiquidados;
        private RjButton btnMostrarTodos;
        private Panel pnlRegPago;
        private Label label1;
        private TextBoxPersonalizado txtNombre;
        private Label label2;
        private TextBoxPersonalizado txtCredito;
        private Label label3;
        private DateTimePickerPersonalizado dateFechaInicio;
        private Label label4;
        private Label label5;
        private RjComboBox cmbTipo;
        private Label label6;
        private RjComboBox cmbPromotor;
        private Label label7;
        private Label label9;
        private Label label10;
        private TextBoxPersonalizado txtCalle;
        private Label label11;
        private TextBoxPersonalizado txtColonia;
        private Label label12;
        private TextBoxPersonalizado txtNumInt;
        private Label label13;
        private TextBoxPersonalizado txtNumExt;
        private Label label14;
        private TextBoxPersonalizado txtTelefono;
        private Label label15;
        private TextBoxPersonalizado txtCorreo;
        private TextBoxPersonalizado txtTotal;
        private Label label16;
        private TextBoxPersonalizado txtTotal_I;
        private Panel pnlClientes;
        public DataGridView gridListas;
        private RjComboBox cmbInteres;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label29;
        private RjButton btnBuscarC;
        private Label lblFecha;
        private TextBoxPersonalizado txtBoxCredito;
        private Label lblCredito;
        private TextBoxPersonalizado txtBoxMonto;
        private RjButton btnMarcarP;
        private Label lblMonto;
        private FlowLayoutPanel flowLayoutPanel2;
        private RjComboBox cmbCliente;
        private RjButton btnEditar;
        private RjButton btnEliminar;
        private FlowLayoutPanel flowLayoutPanel3;
        private BunifuElipse bunifuElipse1;
        private Panel PanelBien;
        private Label label19;
        private RjButton rjButton1;
        private Panel PanelEditar;
        private GroupBox groupBox1;
        private RjButton btnMover;
        private RjComboBox cmbLista;
        private TextBoxPersonalizado textBoxPersonalizado1;
        private Label label18;
        private TextBoxPersonalizado textBoxPersonalizado2;
        private Label label20;
        private TextBoxPersonalizado textBoxPersonalizado3;
        private Label label21;
        private TextBoxPersonalizado textBoxPersonalizado4;
        private Label label22;
        private TextBoxPersonalizado textBoxPersonalizado5;
        private Label label23;
        private TextBoxPersonalizado textBoxPersonalizado6;
        private Label label24;
        private RjComboBox rjComboBox1;
        private Label label28;
        private RjComboBox rjComboBox2;
        private Label label30;
        private Label label31;
        private DateTimePickerPersonalizado dateTimePickerPersonalizado1;
        private Label label32;
        private TextBoxPersonalizado textBoxPersonalizado9;
        private Label label33;
        private TextBoxPersonalizado textBoxPersonalizado10;
        private Label label34;
        private RjComboBox rjComboBox3;
        private Label LblPerte;
        private Label label26;
        private TextBoxPersonalizado textBoxPersonalizado8;
        private Label label27;
        private TextBoxPersonalizado textBoxPersonalizado7;
        private Label label25;
        private DateTimePickerPersonalizado dateTimeLimite;
        private Label LabelLimite;
        private IconButton iconButton1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label35;
        private Label label36;
        private TextBox textBox1;
        private Label label37;
        private TextBox TextboxContr;
        private Label label38;
        private TextBox TextboxConfirm;
        private CheckBox checkBox1;
        private Button button1;
        private Label AvisoVacio;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage Conexion_Sql;
        private Label LabelEstado;
        private Label label51;
        private RjButton rjButton2;
        private CheckBox checkBox3;
        private Label label50;
        private Label label49;
        private TextBox TextContra;
        private TextBox TextUsuario;
        private TextBox TextBase;
        private TextBox TextPuerto;
        private TextBox TextServer;
        private Label label48;
        private Label label47;
        private Label label46;
        private Label label45;
        private Label label44;
        private Label label43;
        private RjButton rjButton3;
        private Label label58;
        private Label label56;
        private Label label55;
        private Label label54;
        private Label label53;
        private Label label52;
        private TabPage tabPage2;
        private Label label59;
        private Label label62;
        private Label label63;
        private TextBox textBox4;
        private Label label61;
        private Label label60;
        private RjComboBox rjComboBox4;
        private RjButton rjButton6;
        private RjButton rjButton5;
        private RjButton rjButton4;
        private Label label64;
        private TextBox textBox5;
        private DateTimePickerPersonalizado dateTimePickerPersonalizado2;
        private Label label65;
        private TextBoxPersonalizado textBoxPersonalizado11;
        private Label label66;
        private Panel PnlEditar2;
        private TextBoxPersonalizado TextBoxPagare;
        private Label label67;
        private Label label68;
        private TextBoxPersonalizado TextBoxRestante;
        private Label label69;
        private Label LabelPertenece;
        private Label label72;
        private GroupBox groupBox2;
        private RjComboBox CmbLista2;
        private TextBoxPersonalizado TextBoxCorreo;
        private Label label73;
        private TextBoxPersonalizado TextBoxTelefono;
        private Label label74;
        private TextBoxPersonalizado TextBoxNumExt;
        private Label label75;
        private TextBoxPersonalizado TextBoxNumInt;
        private Label label76;
        private TextBoxPersonalizado TextBoxColonia;
        private Label label77;
        private TextBoxPersonalizado TextBoxCalle;
        private Label label78;
        private Label label79;
        private RjComboBox rjComboBox7;
        private Label label80;
        private Label LabelNombreEditar2_2;
        private TextBoxPersonalizado TextBoxCredito;
        private Label label83;
        private TextBoxPersonalizado TextBoxNombre;
        private Label label84;
        private RjComboBox rjComboBox8;
        private Label label70;
        private TextBoxPersonalizado TextBoxLiquidacionIntencion;
        private TextBoxPersonalizado TextBoxQuita;
        private Panel PanelEditar2_2;
        private Label label89;
        private TextBoxPersonalizado TextBoxPago;
        private Label label86;
        private Label label85;
        private DateTimePickerPersonalizado FechaEnLista2;
        private Label label71;
        private RjComboBox ComboBoxDeFechas;
        private BackgroundWorker backgroundWorker1;
        private BackgroundWorker backgroundWorker2;
        private Panel PanelEditar3;
        private TextBoxPersonalizado TextImporte3;
        private Label label103;
        private Label label92;
        private TextBoxPersonalizado TextBoxPagare3;
        private Label label81;
        private Label LabelLista3;
        private Label label94;
        private TextBoxPersonalizado TextBoxCorreo3;
        private Label label95;
        private TextBoxPersonalizado TextBoxTelefono3;
        private Label label96;
        private TextBoxPersonalizado TextBoxNumExt3;
        private Label label97;
        private TextBoxPersonalizado TextBoxNumInt3;
        private Label label98;
        private TextBoxPersonalizado TextBoxColonia3;
        private Label label99;
        private TextBoxPersonalizado TextBoxCalle3;
        private Label label100;
        private Label label101;
        private RjComboBox ComboBoxResolucion3;
        private Label label102;
        private TextBoxPersonalizado TextBoxCredito3;
        private Label label105;
        private TextBoxPersonalizado TextBoxNombre3;
        private Label LabelNombre3;
        private RjComboBox ComboBoxPromotor3;
        private GroupBox groupBox3;
        private RjComboBox rjComboBox5;
        private Panel PanelEditarLiquidados;
        private DateTimePickerPersonalizado FechaInicioLiq;
        private Label label91;
        private Label label90;
        private RjComboBox ComBoBoxLiquidacion;
        private Label label104;
        private Label label106;
        private RjButton BottonLiq;
        private TextBoxPersonalizado TextCorreoLiq;
        private Label label107;
        private TextBoxPersonalizado TextTelefonoLiq;
        private Label label108;
        private TextBoxPersonalizado TextNumExtLiq;
        private Label label109;
        private TextBoxPersonalizado TextNumIntLiq;
        private Label label110;
        private TextBoxPersonalizado TextColoniaLiq;
        private Label label111;
        private TextBoxPersonalizado TextCalleLiq;
        private Label label112;
        private Label label113;
        private TextBoxPersonalizado TextCreditoLiq;
        private Label label115;
        private TextBoxPersonalizado TextNombreLiq;
        private Label label116;
        private RjComboBox ComboBoxPromotorLiq;
        private TextBoxPersonalizado TextBoxPagoExt;
        private Label label93;
        private RjComboBox rjComboBox9;
        private TextBoxPersonalizado TextBoxRestantepagos;
        private Label label17;
        private RjComboBox ResolucionDemanda;
        private FlowLayoutPanel flowLayoutPanel6;
        private Panel panel3;
        private RjButton Boton_Permisos;
        private Label label41;
        private TextBox textBox2;
        private Label label42;
        private TextBox textBox3;
        private CheckBox checkBox2;
        private Label label39;
        private Label label40;
        private RjComboBox comboBox1;
        private ProgressBar BarradeProgreso;
        private Label label57;
        private RjButton Button1;
        private RjButton rjButton11;
        private RjButton rjButton12;
        private RjButton btnCalcular1;
        private RjButton btnGuardar1;
        private RjButton btnMover2;
        private RjButton btnGuardar2;
        private RjButton btnMover3;
        private RjButton btnGuardarC;
        private RjButton btnEditarFechas2;
        private RjButton Botoncambiodefechamomentaneo;
        private RjButton BotonVolverEditar2;
        private RjButton BtnMover;
        private RjButton BtnGuardarCambio;
        private TextBoxPersonalizado Monto_Recomendado;
        private Label label82;
        private FlowLayoutPanel flowLayoutPanel5;
        private RjComboBox ComboBoxPromotoresListas;
        private Label labelDineroAire;
        private Label label87;
        private RjComboBox ComBoxName;
        private RjButton rjButton7;
        private Label PingLabel;
        private IconButton iconButton2;
    }
}