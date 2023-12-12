using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using FutureLending.Controles_personalizados;
using FutureLending.ControlesPersonalizados;
using FutureLending.Funciones.cs;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;
using Button = System.Windows.Forms.Button;
using Timer = System.Windows.Forms.Timer;

namespace FutureLending.Forms
{
    public partial class Form1 : Form
    {

        //Variable que se utiliza a la hora de borrar o editar un registro

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            timer = new Timer();
            timer.Interval = 100; // Intervalo de tiempo para la animación (en milisegundos)
            timer.Tick += Timer_Tick;
            PingLabel.Hide();

        }
        //Declaracion de variables 
        //privadas
        private string listaActual = "";
        private Timer timer;
        private double opacity = 1.0;
        private bool cambioEnPromotores = true;
        private double restanteOriginal;
        private int indexFecha;
        private bool revertir;
        private bool unclick = true;
        private string[] InformacionPagos = new string[45];
        private bool Guardar = false;
        private bool changingCheckedState5;
        private bool Aval = false;
        private string[] Avales = new string[15];
        private string[] NuevosAvales = new string[16];
        private int panel = 0;
        private static readonly Lectura_Base_Datos Lec = new();
        private static bool requierAdmin2 = false;
        private static string[] datos = new string[50];
        private Double credito2;
        private bool revisado;
        //publicas
        public static double DineroAire;
        public static double MontoTotal;
        public static bool admin = false;
        public static bool Guar = true;
        public static string Liq = null;
        public static string Nom;
        public static string Lis;
        public static string nombre;
        public static int valor1;
        public static int valor2;
        public static int valor3;
        public static bool Boton1 { get; private set; }
        public static bool Boton2 { get; private set; }
        public static bool Boton3 { get; private set; }
        public static bool Boton4 { get; private set; }






        private void Form1_Load(object sender, EventArgs e)
        {
            CargaMasiva();
            Task.Run(() =>
            {
                // Actualizar los controles de la interfaz de usuario desde el hilo de UI
                this.Invoke(() =>
                {
                    CollapseMenu();
                    dateTimePickerPersonalizado2.Enabled = false;
                    rjButton8.Enabled = false;
                    DateTimePago15.Hide();
                    DateTimePago15.Enabled = false;
                    rjButton6.Enabled = false;
                    BtnGraficar.Hide();
                    rjComboBox9.Visible = false;
                    rjButton4.Enabled = false;
                    rjButton7.Enabled = false;
                    Botoncambiodefechamomentaneo.Enabled = false;
                    TextBoxPagoExt.Enabled = false;
                    label57.Visible = false;
                    btnCalcular1.Enabled = false;
                    BarradeProgreso.Visible = false;
                    label17.Visible = false;
                    ComboBoxPromotoresListas.Enabled = true;
                    rjButton5.Enabled = false;
                    label82.Visible = false;
                    Monto_Recomendado.Visible = false;
                    cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
                    ComBoxName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    ComBoxName.AutoCompleteSource = AutoCompleteSource.ListItems;
                    this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                    dateTimePickerPersonalizado2.Enabled = false;
                    //Ocultar Objetos para Reutilizarlos
                    BtnAvalesEditar.Hide();
                    groupBox1.Hide();
                    textBoxPersonalizado11.Hide();

                });
            });
        }

        //Cargar todos los promotores solo 1 vez y si se modifican se recargan de manera global asi no se llama cada vez

        void CargaMasiva()
        {
            if (cambioEnPromotores)
            {
                CargarPromotoresEnComboBox(cmbPromotor, false);
                CargarPromotoresEnComboBox(ComboBoxPromotoresListas, true);
                CargarPromotoresEnComboBox(rjComboBox4, false);
                cambioEnPromotores = false;
            }
        }
        #region Animacion de menu
        private void Timer_Tick(object sender, EventArgs e)
        {
            opacity -= 0.05; // Cantidad en la que disminuir la opacidad en cada intervalo
            if (opacity <= 0)
            {
                timer.Stop();
                // Realizar acciones después de que se complete la animación
            }
            else
            {
                panel1.BackColor = Color.FromArgb((int)(255 * opacity), panel1.BackColor);
            }
        }
        private void CollapseMenu()
        {
            const int collapsedWidth = 100;
            const int expandedWidth = 250;

            if (panelMenu.Width > collapsedWidth)
            {
                panelMenu.Width = collapsedWidth;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;

                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                panelMenu.Width = expandedWidth;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;

                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = $"   {menuButton.Tag}";
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }
        #endregion

        #region Botones centrales del menu

        #region Ingresar Clientes

        private void BtnIngresarClientes_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            Guardar = false;
            EsconderPaneles(pnlClientes);
            lblTitle.Text = @"Ingresar Clientes";
            agregar();
        }

        private void SoloNumerosDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && (((Controles_personalizados.TextBoxPersonalizado)sender).Texts.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void SoloNumerosEnteros(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private bool VerificarLlenadoGuardar()
        {
            //Verificar que están los datos llenos para activar los botones
            bool activar = true;
            //TextBox
            foreach (Controles_personalizados.TextBoxPersonalizado txtDato in pnlClientes.Controls.OfType<Controles_personalizados.TextBoxPersonalizado>())
            {
                // Omitir la verificación para ciertos controles
                if (txtDato.Name == "txtNumInt" || txtDato.Name == "txtNumExt")
                {
                    continue; // Saltar a la siguiente iteración del bucle e ignora esos controles
                }

                if (string.IsNullOrEmpty(txtDato.Texts))
                {
                    activar = false;
                    return activar;
                }
            }

            // Verificar si los campos "txtNumInt" y "txtNumExt" están vacíos si ambos lo estan no activa el boton
            if (string.IsNullOrEmpty(txtNumInt.Texts) && string.IsNullOrEmpty(txtNumExt.Texts))
            {
                activar = false;
                return activar;
            }
            //ComboBox
            foreach (var cmbDato in
                pnlClientes.Controls.OfType<RJComboBox>())
            {
                if (cmbDato.SelectedIndex == -1)
                {
                    activar = false;
                    return activar;
                }
            }
            return activar;
        }

        private void ActivarBtnGuardar(object sender, EventArgs e)
        {
            btnGuardar1.Enabled = VerificarLlenadoGuardar();
            rjButton8.Enabled = true;
        }

        private bool VerificarLlenadoCalcular()
        {
            //Verificar que están los datos llenos para activar los botones
            bool activar = true;
            //TextBox
            if (string.IsNullOrEmpty(txtCredito.Texts))
            {
                activar = false;
                return activar;
            }
            //ComboBox
            if (cmbInteres.SelectedIndex == -1 ||
                cmbTipo.SelectedIndex == -1)
            {
                activar = false;
                return activar;
            }
            return activar;
        }

        private void ActivarBtnCalcular(object sender, EventArgs e)
        {
            btnCalcular1.Enabled = VerificarLlenadoCalcular();
        }

        private bool VerificarLlenadoBuscar()
        {
            //Verificar que están los datos llenos para activar los botones
            bool activar = true;
            //ComboBox
            if (ComBoxName.SelectedIndex == -1)
            {
                activar = false;
                return activar;
            }
            return activar;
        }
        private void ActivarBtnBuscar(object sender, EventArgs e)
        {
            btnBuscarC.Enabled = VerificarLlenadoBuscar();
        }

        private void ActivarBtnMarcar(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxMonto.Texts))
            {
                btnMarcarP.Enabled = false;
            }
            else
            {
                if (rjComboBox9.SelectedIndex == -1 || rjComboBox9.Texts == "Seleccione la fecha")
                {
                    btnMarcarP.Enabled = false;
                }
                else
                {
                    btnMarcarP.Enabled = true;
                }
            }
        }
        #endregion

        #region Listas

        private void BtnListas_Click(object sender, EventArgs e)
        {
            BtnAgregarColumnas.Hide();
            cancellationTokenSource?.Cancel();
            Guardar = false;
            ComboBoxPromotoresListas.SelectedIndex = 0;
            int i = 0;
            List<string> list = Accesos.ObtenerPermisosUsuario(Program.NombreUsuario);
            if (list != null && !revisado)
            {
                revisado = true;
                // Bloquear y deshabilitar todos los botones por defecto
                Deshabilitartodos();
                btnLista1.Enabled = false;
                btnLista1.Click -= BtnLista1_Click;
                btnLista1.MouseDown -= BtnLista1_MouseDown;
                btnLista1.TabStop = false;

                btnLista2.Enabled = false;
                btnLista2.Click -= BtnLista2_Click;
                btnLista2.MouseDown -= BtnLista2_MouseDown;
                btnLista2.TabStop = false;

                btnLista3.Enabled = false;
                btnLista3.Click -= BtnLista3_Click;
                btnLista3.MouseDown += BtnLista3_MouseDown;
                btnLista3.TabStop = false;



                btnLiquidados.Enabled = false;
                btnLiquidados.Click -= BtnLiquidados_Click;
                btnLiquidados.MouseDown += BtnLiquidados_MouseDown;
                btnLiquidados.TabStop = false;



                // Desbloquear y habilitar los botones especificados en la lista
                foreach (string item in list)
                {
                    switch (item)
                    {
                        case "lista1":
                            btnLista1.Enabled = true;
                            btnLista1.Click += BtnLista1_Click;
                            btnLista1.MouseDown += BtnLista1_MouseDown;
                            btnLista1.TabStop = true;
                            Boton1 = true;

                            i += 1;
                            break;
                        case "lista2":
                            btnLista2.Enabled = true;
                            btnLista2.Click += BtnLista2_Click;
                            btnLista2.MouseDown += BtnLista2_MouseDown;
                            btnLista2.TabStop = true;
                            Boton2 = true;
                            i += 1;
                            break;
                        case "lista3":
                            btnLista3.Enabled = true;
                            btnLista3.Click += BtnLista3_Click;
                            btnLista3.MouseDown += BtnLista3_MouseDown;
                            btnLista3.TabStop = true;
                            Boton3 = true;
                            i += 1;
                            break;
                        case "liquidados":
                            btnLiquidados.Enabled = true;
                            btnLiquidados.Click += BtnLiquidados_Click;
                            btnLiquidados.MouseDown += BtnLiquidados_MouseDown;
                            btnLiquidados.TabStop = true;
                            Boton4 = true;
                            i += 1;
                            break;
                    }
                }
                if (i == 4)
                {
                    Habilitartodos();
                }
            }

            lblTitle.Text = @"Listas Completas";
            EsconderPaneles(pnlListas);

        }
        void Habilitartodos()
        {
            btnMostrarTodos.Enabled = true;
            btnMostrarTodos.Click += BtnMostrarTodos_Click;
            btnMostrarTodos.MouseDown += BtnMostrarTodos_MouseDown;
            btnMostrarTodos.TabStop = true;
            btnMostrarTodos.FlatStyle = FlatStyle.Flat;

        }
        void Deshabilitartodos()
        {
            btnMostrarTodos.Enabled = false;
            btnMostrarTodos.Click -= BtnMostrarTodos_Click;
            btnMostrarTodos.MouseDown -= BtnMostrarTodos_MouseDown;
            btnMostrarTodos.TabStop = false;

        }
        private bool panelRg;
        //Funcion para esconder los paneles menos el enviado
        void EsconderPaneles(Panel panel112Panel1)
        {
            timer.Start();
            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    var panel = (Panel)control;

                    // Verificar si el panel debe mantenerse visible o no
                    if (panel.Name != "panelTitleBar" && panel.Name != "panelMenu")
                    {
                        panel.Visible = false;
                    }
                }
            }
            panel112Panel1.Visible = true;
            panel112Panel1.BringToFront();
            if (panel112Panel1 == pnlRegPago)
            {
                RecargarDatosPnllRegPagos();
            }
        }
        private void RjButton1_Click_1(object sender, EventArgs e)
        {
            Exportar_Excel excel = new();
            excel.ShowDialog();
        }
        #region Mostrar tablas en DataGridView y editar/eliminar registros
        int listaEstado;
        private async void BtnLista1_Click(object sender, EventArgs e)
        {
            BtnAgregarColumnas.Hide();
            if (ComboBoxPromotoresListas.SelectedIndex != -1 && ComboBoxPromotoresListas.SelectedIndex != 0)
            {
                BtnGraficar.Show();
                DineroAire = 0;
                listaEstado = 0;
                DesactivarBotones();
                Lectura_Base_Datos ar = new();
                List<string[]> datos = ar.LectLista1Prom(ComboBoxPromotoresListas.SelectedItem.ToString());
                await TablaClientes.MostrarLista1Prom(gridListas, cmbCliente, BarradeProgreso, label57, datos);
                LabelDineroAire.Text = $"{ComboBoxPromotoresListas.SelectedItem} tiene ${DineroAire:N2} en Pagos pendientes";
                btnLista1.Enabled = true;
                btnLista2.Enabled = true;
                ActivarEditar();
                listaActual = "lista1";
            }
            else
            {
                BtnGraficar.Hide();
                LabelDineroAire.Text = "";
                listaEstado = 0;
                DesactivarBotones();
                await TablaClientes.MostrarLista1(gridListas, cmbCliente, BarradeProgreso, label57);
                ActivarListas();
                ActivarEditar();
                listaActual = "lista1";
            }
        }

        private async void BtnLista2_Click(object sender, EventArgs e)
        {
            BtnAgregarColumnas.Show();
            if (ComboBoxPromotoresListas.SelectedIndex != -1 && ComboBoxPromotoresListas.SelectedIndex != 0)
            {
                BtnGraficar.Show();
                DineroAire = 0;
                listaEstado = 1;
                DesactivarBotones();
                Lectura_Base_Datos ar = new();
                List<string[]> datos = ar.LectLista2Prom(ComboBoxPromotoresListas.SelectedItem.ToString());
                await TablaClientes.MostrarLista2Prom(gridListas, cmbCliente, BarradeProgreso, label57, datos);
                LabelDineroAire.Text = ComboBoxPromotoresListas.SelectedItem + @" tiene $" + DineroAire.ToString("N2") + @" en Pagos pendientes";
                btnLista1.Enabled = true;
                btnLista2.Enabled = true;
                ActivarEditar();
                listaActual = "lista2";
            }
            else
            {
                BtnGraficar.Hide();
                LabelDineroAire.Text = "";
                listaEstado = 1;
                DesactivarBotones();
                await TablaClientes.MostrarLista2(gridListas, cmbCliente, BarradeProgreso, label57);
                ActivarListas();
                ActivarEditar();
                listaActual = "lista2";
            }
        }

        private async void BtnLista3_Click(object sender, EventArgs e)
        {
            BtnGraficar.Hide();
            BtnAgregarColumnas.Hide();
            listaEstado = 2;
            DesactivarBotones();
            await TablaClientes.MostrarLista3(gridListas, cmbCliente, BarradeProgreso, label57);
            ActivarListas();
            ActivarEditar();
            listaActual = "lista3";
        }

        private async void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            BtnGraficar.Hide();
            BtnAgregarColumnas.Hide();
            DesactivarBotones();
            await TablaClientes.MostrarTodos(gridListas, cmbCliente, BarradeProgreso, label57);
            ActivarListas();
        }

        private async void BtnLiquidados_Click(object sender, EventArgs e)
        {
            BtnAgregarColumnas.Hide();
            BtnGraficar.Hide();
            listaActual = "liquidados";
            listaEstado = 3;
            var mostrarListaTask = TablaClientes.MostrarLiquidados(gridListas, cmbCliente, BarradeProgreso, label57);
            while (!mostrarListaTask.IsCompleted)
            {
                DesactivarBotones();
                await Task.Delay(100);
            }
            ActivarListas();
            ActivarEditar();
        }

        //Activa los botones de editar y eliminar hasta que seleccione un cliente
        private void CmbCliente_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex != -1)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
        //Declaraciones Globales
        public string[] Informacion = new string[31]; //Se usa para guardar la info de la lista 1
        public string[] Informacion2 = new string[100]; //Se usa para guardar la info de la lista 2
        public string[] Informacion3 = new string[15];//Se usa para guardar la info de la lista 3
        public string[] Informacion4 = new string[12];//Se usa para guardar la info de liquidados
        public string Pertenece; //De que lista viene
        public string Cliente; //Nombre del cliente
        private string tipoPago; //Tipo de pago 
        private string[] temporal = new string[31];

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Guardar = false;
            editaravales = true;
            Lecturas_Especificas lecturasEspecificas = new();
            if (listaEstado == 0) //Si viene de la lista 1
            {
                //Limpio las listas donde es posible  mover al registro
                cmbLista.Items.Clear();
                cmbLista.Enabled = true;
                cmbLista.Items.AddRange(new object[] { "Lista 2", "Lista 3", "Liquidados" });
                //Establezco de donde viene este registro y llamo a la funcion de los datos 
                cmbTipo.Items.Clear();
                cmbTipo.Items.AddRange(new object[] { "Semanales", "Quincenales" });
                editar1("Lista 1");
                //Obtengo el nombre del cliente
                Cliente = cmbCliente.Texts;
                //Empieza leyendo su informacion de la base de datos
                Informacion = lecturasEspecificas.LectName(Cliente);
                temporal = lecturasEspecificas.LectName(Cliente);
                //Tuve que convertir de List<string[]> a string[] para poder usarlo en los objetos del Panel (Editar)
                txtNombre.Texts = Cliente;//Nombre del Cliente
                txtCredito.Texts = Informacion[2];//Credito Prestado
                textBoxPersonalizado11.Texts = Informacion[3]; //Pagare generado
                dateFechaInicio.Value = DateTime.Parse(Informacion[4]);//Fecha de Inicio
                dateTimePickerPersonalizado2.Value = DateTime.Parse(Informacion[5]);//Fecha de su ultimo pago (Limite)
                cmbInteres.SelectedItem = Informacion[6];//Interes Que tiene
                txtTotal_I.Texts = Informacion[7];//Monto Total del prestamo + intereses
                cmbTipo.SelectedItem = Informacion[14]; //Su forma de pago quincenales o semanales
                tipoPago = Informacion[14];
                cmbPromotor.SelectedItem = Informacion[0];//Promotor que lo atiende
                txtTotal.Texts = Informacion[15];//Monto Restante
                txtCalle.Texts = Informacion[8];//Calle
                txtColonia.Texts = Informacion[9];//Colonia
                txtNumInt.Texts = Informacion[10];//Numero de casa interior
                txtNumExt.Texts = Informacion[11];//Numero de casa exterior
                txtTelefono.Texts = Informacion[12];//Telefono
                txtCorreo.Texts = Informacion[13];//Correo
                //Del 16 al 29 son los datos de las 14 fechas que solo ocupan 7 si sus pagos con quincenales
            }
            else if (listaEstado == 1) //Si viene de la lista 2
            {

                TextBoxPagoExt.Enabled = false;
                groupBox2.Show();

                //Limpio las listas donde es posible  mover al registro
                CmbLista2.Items.Clear();
                CmbLista2.Enabled = true;
                CmbLista2.Items.AddRange(new object[] { "Lista 3", "Liquidados" });
                cmbTipo.Items.Clear();
                cmbTipo.Items.AddRange(new object[] { "Liquidacion", "Intencion" });
                //Nombre del registro
                Cliente = cmbCliente.Texts;
                editar2("Lista 2");
                //activar boton de fechas
                btnEditarFechas2.Enabled = true;

                //Leo la informacion de ese registro en especifico
                Informacion2 = lecturasEspecificas.LectName2(Cliente);
                //Empiezo a llenar los objetos del panel editar2
                cmbPromotor.SelectedItem = Informacion2[0]; //Promotor que lo atiende
                txtNombre.Texts = Cliente; //Nombre del registro
                txtCredito.Texts = Informacion2[2]; //Credito Prestado
                txtTotal.Texts = Informacion2[3]; //Monto Restante
                TextBoxRestante.Texts = Informacion2[4]; //Pagare generado
                txtCalle.Texts = Informacion2[5]; //Calle
                txtColonia.Texts = Informacion2[6]; //Colonia
                txtNumInt.Texts = Informacion2[7]; //Numero de casa interior
                txtNumExt.Texts = Informacion2[8]; //Numero de casa exterior
                txtTelefono.Texts = Informacion2[9]; //Telefono
                txtCorreo.Texts = Informacion2[10]; //Correo
                if (Informacion2[11] == "Liquidacion")
                {
                    cmbTipo.SelectedIndex = 0;
                }
                else
                {
                    cmbTipo.SelectedIndex = 1;
                }
                txtTotal_I.Texts = Informacion2[12]; //Monto de liquidacion o intencion
                TextBoxQuita.Texts = Informacion2[13]; //Monto de Quita
                Ediciones ed = new();
                int max = ed.ObtenerNumeroColumnas("lista2");
                TextBoxPagoExt.Texts = Informacion2[max];
                //De aqui pasa al caso de oprimir el boton para mover las fechas y pagos 
            }
            else if (listaEstado == 2) //Si viene de la lista 3
            {
                //Traer panel de edicion3
                editar3("Lista 3");
                //Llenar el rjcombobox de promotores con la info correspondiente
                //Limpio las listas donde es posible  mover al registro
                rjComboBox5.Items.Clear();
                rjComboBox5.Enabled = true;
                rjComboBox5.Items.AddRange(new object[] { "Liquidados" });
                //Nombre del registro
                Cliente = cmbCliente.Texts;
                //Leer la info
                Informacion3 = lecturasEspecificas.LectName3(Cliente); //tamaño 14
                //Empiezo a llenar los objetos del panel editar3
                txtNombre.Texts = Cliente; //Nombre del registro
                txtCredito.Texts = Informacion3[2]; //Credito Prestado
                textBoxPersonalizado11.Texts = Informacion3[3]; //Pagare generado
                txtCalle.Texts = Informacion3[4]; //Calle
                txtColonia.Texts = Informacion3[5]; //Colonia
                txtNumInt.Texts = Informacion3[6]; //Numero de casa interior
                txtNumExt.Texts = Informacion3[7]; //Numero de casa exterior
                txtTelefono.Texts = Informacion3[8]; //Telefono
                txtCorreo.Texts = Informacion3[9]; //Correo
                cmbPromotor.SelectedItem = Informacion3[0]; //Promotor que lo atiende
                ResolucionDemanda.SelectedItem = Informacion3[11]; //Resolucion de la demanda
                txtTotal.Texts = Informacion3[12]; //Importe
                ComboBoxResolucion3.SelectedItem = Informacion3[10]; //Resolucion
            }
            else if (listaEstado == 3)//Si viene de liquidados
            {

                //Nombre del registro
                Cliente = cmbCliente.Texts;
                //Obtenemos la informacion de ese registro en especifico
                Informacion4 = lecturasEspecificas.LectName4(Cliente); //tamaño 12
                editarliq("Liquidados");
                //Rellenamos los objetos del panel editar liquidados
                txtNombre.Texts = Cliente; //Nombre del registro
                txtCredito.Texts = Informacion4[2]; //Credito Prestado
                DateTime fechaInicio;
                if (DateTime.TryParse(Informacion4[3], out fechaInicio))
                {
                    dateFechaInicio.Value = fechaInicio;
                }
                else
                {
                    dateFechaInicio.Enabled = false;
                }
                cmbPromotor.SelectedItem = Informacion4[0]; //Promotor que lo atiende
                if (Informacion4[10] == "Lista1" || Informacion[10] == "Lista 1")
                {
                    ComBoBoxLiquidacion.SelectedIndex = 0;
                }
                else if (Informacion4[10] == "Lista2" || Informacion[10] == "Lista 2")
                {
                    ComBoBoxLiquidacion.SelectedIndex = 1;
                }
                else
                {
                    ComBoBoxLiquidacion.SelectedIndex = 2;
                }

                txtCalle.Texts = Informacion4[4]; //Calle
                txtColonia.Texts = Informacion4[5]; //Colonia
                txtNumInt.Texts = Informacion4[6]; //Numero de casa interior
                txtNumExt.Texts = Informacion4[7]; //Numero de casa exterior
                txtTelefono.Texts = Informacion4[8]; //Telefono
                txtCorreo.Texts = Informacion4[9]; //Correo
            }
        }

        #region Lista1

        #endregion
        #region Lista2 
        //Seguir editando lista 2 pero las fechas y pagos
        //presionado boton guardar el pago y la asignacion de fecha en la lista 2 ademas de actualizar el Pago EXT
        bool mover;

        //Si selecciona una fecha de lista 2 se muestra en el datetimepicker

        private static bool requierAdmin = false;
        private static double PagoOriginal = 0;
        private void ComboBoxDeFechas_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if (ComboBoxDeFechas.SelectedItem != null)
            {
                if (ComboBoxDeFechas.SelectedItem.ToString().Contains("Pagado"))
                {
                    requierAdmin = true;
                }
            }
            int apuntador;
            FechaEnLista2.Enabled = true;
            if (string.IsNullOrEmpty(Informacion2[2]))
            {
                FechaEnLista2.Value = DateTime.Today;
            }
            else
            {
                if (ComboBoxDeFechas.SelectedIndex == 0)
                {
                    apuntador = 14;

                    if (Informacion2[apuntador] == "-" || Informacion2[apuntador] == null || Informacion2[apuntador] == "")
                    {
                        FechaEnLista2.Value = DateTime.Today;
                    }
                    else
                    {
                        FechaEnLista2.Value = DateTime.Parse(Informacion2[apuntador]);
                        TextBoxPago.Texts = Informacion2[apuntador + 1];
                        PagoOriginal = Convert.ToDouble(Informacion2[apuntador + 1]);
                    }
                }
                else
                {
                    if (ComboBoxDeFechas.SelectedIndex != -1)
                    {
                        apuntador = ((ComboBoxDeFechas.SelectedIndex * 2) + (14));
                    }
                    else
                    {
                        apuntador = 14;
                    }
                    if (Informacion2[apuntador] == "-" || Informacion2[apuntador] == "" || Informacion2[apuntador] == null)
                    {
                        FechaEnLista2.Value = DateTime.Today;
                    }
                    else
                    {
                        FechaEnLista2.Value = DateTime.Parse(Informacion2[apuntador]);
                        TextBoxPago.Texts = Informacion2[apuntador + 1];
                        PagoOriginal = Convert.ToDouble(Informacion2[apuntador + 1]);
                    }

                }

            }




        }
        //Si ya puso un pago se activa el boton
        private void TextBoxPago__TextChanged(object sender, EventArgs e)
        {
            if (TextBoxPago.Texts != "")
            {
                if (ComboBoxDeFechas.SelectedIndex != -1)
                {
                    Botoncambiodefechamomentaneo.Enabled = true;
                }
            }
            else
            {
                Botoncambiodefechamomentaneo.Enabled = false;
            }

        }
        //De editar lista 2_2 a editar lista 2
        private void CmbLista2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbLista2.SelectedIndex != -1)
            {
                btnMover3.Enabled = true;

            }
            else
            {
                btnMover3.Enabled = false;
            }
        }

        #endregion
        #region Lista3

        private void RjComboBox5_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rjComboBox5.SelectedIndex != -1)
            {
                btnMover2.Enabled = true;

            }
            else
            {
                btnMover2.Enabled = false;
            }
        }
        #endregion

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos instancia = new();
            instancia.Erase(cmbCliente.Texts, listaActual);
            instancia.BorrarAval(cmbCliente.Texts);//Borra los avales de ese cliente
            //Verifica de cuál lista se eliminó y la recarga
            if (listaActual == "lista1") btnLista1.PerformClick();
            else if (listaActual == "lista2") btnLista2.PerformClick();
            else if (listaActual == "lista3") btnLista3.PerformClick();
            else if (listaActual == "liquidados") btnLiquidados.PerformClick();
        }

        //Para desactivar los botones mientras se imprime una tabla
        private void DesactivarBotones()
        {

            btnLista1.Enabled = false;
            btnLista2.Enabled = false;
            btnLista3.Enabled = false;
            btnMostrarTodos.Enabled = false;
            btnLiquidados.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            cmbCliente.Enabled = false;
            rjButton1.Enabled = false;
        }

        //Se reactivan los botones una vez se imprime la tabla
        private void ActivarListas()
        {
            if (Boton1)
            {
                btnLista1.Enabled = true;
            }
            if (Boton2)
            {
                btnLista2.Enabled = true;
            }
            if (Boton3)
            {
                btnLista3.Enabled = true;
            }
            if (Boton4)
            {
                btnLiquidados.Enabled = true;
            }
            if (!Boton1 || !Boton2 || !Boton3 || !Boton4)
            {

            }
            else
            {
                btnMostrarTodos.Enabled = true;
            }
            rjButton1.Enabled = true;

        }

        private void ActivarEditar()
        {
            if (gridListas.Rows.Count > 0)
            {
                cmbCliente.Enabled = true;
            }
        }

        #endregion
        #region Cambio de listas
        private void CmbLista_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLista.SelectedIndex != -1)
            {
                BtnMover.Enabled = true;
            }
            else
            {
                BtnMover.Enabled = false;
            }

        }








        #endregion

        #endregion

        #region Reparacion
        private void BtnTodosSistemas_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos instancia = new();
            _ = instancia.CheckConnection(false);
        }
        #endregion

        #region Estado de Pagos
        private void BtnEstadoPagos_Click(object sender, EventArgs e)
        {
            Guardar = false;
            cancellationTokenSource?.Cancel();
            EsconderPaneles(pnlRegPago);
            lblTitle.Text = @"Registrar pago";
            // Iniciar el hilo de fondo
            BackgroundWorker worker = new();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Operaciones intensivas (lectura de datos, procesamiento, etc.)
            Lectura_Base_Datos instancia = new();
            List<string[]> lista1 = instancia.LectLista1(false);
            // Agregar los nombres a ComBoxName
            // Acceder a los controles se realiza en el hilo de interfaz de usuario principal
            ComBoxName.BeginInvoke((MethodInvoker)delegate
            {
                ComBoxName.Items.Clear();
                foreach (string[] item in lista1)
                {
                    ComBoxName.Items.Add(item[1]);
                }
            });
        }

        private void BtnBuscarC_Click(object sender, EventArgs e)
        {
            //Buscar el cliente por nombre dentro de la base de datos para registrar un nuevo pago semanal/quincenal

            //Agregamos los datos del cliente al form
            rjComboBox9.Texts = "Seleccione la Fecha";
            Lecturas_Especificas instancia = new();
            datos = instancia.LectName(ComBoxName.SelectedItem.ToString());
            int f = 0;
            for (int i = 16; i < 31; i++)
            {
                if (datos[i].Contains("/"))
                {
                    if (datos[i].Contains("-"))
                    {
                        rjComboBox9.Items.Add(datos[i] + "-(PAGADA)");
                        f++;
                    }
                    else
                    {

                        rjComboBox9.Items.Add(datos[i]);

                        f++;
                    }
                }
                else
                {

                    rjComboBox9.Items.Add("FECHA 15");

                }
            }
            label17.Visible = true;
            lblCredito.Visible = true;
            txtBoxCredito.Visible = true;
            txtBoxMonto.Visible = true;
            lblFecha.Visible = true;
            lblMonto.Visible = true;
            rjComboBox9.Visible = true;
            btnMarcarP.Visible = true;
            TextBoxRestantepagos.Visible = true;
            TextBoxRestantepagos.Texts = datos[15];
            TextBoxRestantepagos.Enabled = false;
            txtBoxCredito.Texts = datos[7];
            Monto_Recomendado.Visible = true;
            label82.Visible = true;
            Monto_Recomendado.Texts = (Convert.ToDouble(datos[7]) / Convert.ToDouble(f)).ToString("N2");

        }
        private void BtnMarcarP_Click(object sender, EventArgs e)
        {
            //Obtener el valor seleccionado de fecha por el nombre del cliente
            Lecturas_Especificas instancia2 = new();
            string[] fecha2 = instancia2.LectName(ComBoxName.SelectedItem.ToString());
            string[] fechas = new string[45];
            for (int i = 0; i < fecha2.Length; i++)
            {
                fechas[i] = fecha2[i];
            }

            if (Convert.ToDouble(txtBoxMonto.Texts) > Convert.ToDouble(fechas[15]))
            {
                MessageB("No puedes depositar mas de lo que debe", "Aviso", 2);
                txtBoxMonto.Texts = "";
            }
            else
            {
                //Leer las fechas registradas 
                int index = rjComboBox9.SelectedIndex + 16; //Fecha seleccionada por el cliente
                rjComboBox9.SelectedIndex = -1;
                if (requierAdmin2)
                {
                    requierAdmin2 = false;
                    Administrador_Acceso acc = new();
                    acc.ShowDialog();
                    if (admin)
                    {
                        string[] pag = datos[index].Split("-");

                        if (Convert.ToDouble(pag[1]) > Convert.ToDouble(txtBoxMonto.Texts))
                        {
                            double diferencia = Convert.ToDouble(pag[1]) - Convert.ToDouble(txtBoxMonto.Texts);
                            double suma = Convert.ToDouble(fechas[15]) + diferencia;
                            string[] fecha = datos[index].Split("-");
                            fechas[index] = fecha[0] + "-" + txtBoxMonto.Texts;
                            fechas[15] = suma.ToString("N2");
                            string[] dato = new string[45];
                            for (int i = 0; i < fechas.Length; i++)
                            {
                                dato[i] = fechas[i];

                            }
                            dato[31] = fechas[1];
                            Ediciones instancia22 = new();
                            _ = instancia22.EditarLista1(dato);
                        }
                        else
                        {
                            double diferencia = Convert.ToDouble(txtBoxMonto.Texts) - Convert.ToDouble(pag[1]);
                            double resta = Convert.ToDouble(fechas[15]) - diferencia;
                            string[] fecha = datos[index].Split("-");
                            fechas[index] = fecha[0] + "-" + txtBoxMonto.Texts;
                            fechas[15] = resta.ToString("N2");
                            string[] dato = new string[45];
                            for (int i = 0; i < fechas.Length; i++)
                            {
                                dato[i] = fechas[i];

                            }
                            dato[31] = fechas[1];
                            Ediciones instancia22 = new();
                            _ = instancia22.EditarLista1(dato);
                        }
                    }
                    else
                    {
                        RecargarDatosPnllRegPagos();
                    }

                }
                else
                {

                    if (index == 30)
                    {
                        Ediciones instancia22 = new();
                        //Resta del pago al monto restante
                        double totRes2 = (Convert.ToDouble(fechas[15])) - (Convert.ToDouble(txtBoxMonto.Texts));
                        DateTime a = new();
                        a = Convert.ToDateTime(DateTimePago15.Value);
                        string fecha = a.ToString("dd/MM/yyyy");
                        fechas[index] = fecha + "-" + txtBoxMonto.Texts;
                        fechas[15] = totRes2.ToString("N2");
                        string[] dato = new string[45];
                        for (int i = 0; i < fechas.Length; i++)
                        {
                            dato[i] = fechas[i];
                        }
                        dato[31] = fechas[1];
                        _ = instancia22.EditarLista1(dato);
                    }
                    else
                    {
                        //Restar el nuevo pago al monto restante 
                        double totRes = (Convert.ToDouble(fechas[15])) - (Convert.ToDouble(txtBoxMonto.Texts));
                        //Si el monto restante es 0, entonces se pasa a liquidados 
                        if (totRes == 0)
                        {
                            Lectura_Base_Datos obj = new();
                            string[] mov = new string[12];
                            mov[0] = fechas[0];//Promotor
                            mov[1] = fechas[1];//Nombre
                            mov[2] = fechas[2];//Credito
                            mov[3] = fechas[4];//fecha inicio
                            mov[4] = fechas[8];//Calle
                            mov[5] = fechas[9];//Colonia
                            mov[6] = fechas[10];//Num_ext
                            mov[7] = fechas[11];//Num_int
                            mov[8] = fechas[12];//Telefono
                            mov[9] = fechas[13];//Correo
                            mov[10] = "Lista1";//Lista
                            obj.InsertarLiquidados(mov);//Lo mueve a liquidados
                            obj.Erase(ComBoxName.Texts, "lista1"); //Lo elimino de lista 1
                        }
                        else
                        {
                            fechas[index] += "-" + txtBoxMonto.Texts;
                            fechas[15] = totRes.ToString("N2");//Asigno el nuevo monto restante
                            Ediciones instancia22 = new();
                            string[] dato = new string[45];
                            for (int i = 0; i < fechas.Length; i++)
                            {
                                dato[i] = fechas[i];
                            }

                            dato[31] = fechas[1];
                            _ = instancia22.EditarLista1(dato);
                        }
                    }

                }
                //Resetear valores 
                RecargarDatosPnllRegPagos();
                //Recargo de datos
                BtnEstadoPagos_Click(sender, e);
            }
        }

        private void RecargarDatosPnllRegPagos()
        {
            ComBoxName.SelectedIndex = -1;
            ComBoxName.Texts = "Introduzca nombre";
            btnBuscarC.Enabled = false;
            rjComboBox9.Items.Clear();
            rjComboBox9.Visible = false;
            txtBoxCredito.Visible = false;
            txtBoxMonto.Visible = false; txtBoxMonto.Texts = "";
            lblCredito.Visible = false;
            label82.Visible = false;
            TextBoxRestantepagos.Visible = false;
            Monto_Recomendado.Visible = false;
            lblMonto.Visible = false;
            lblFecha.Visible = false;
            label17.Visible = false;
            btnMarcarP.Visible = false;
            rjComboBox9.SelectedIndex = -1;
            DateTimePago15.Location = new Point(211, 622);
            DateTimePago15.Hide();
            DateTimePago15.Enabled = false;
            Monto_Recomendado.Location = new Point(298, 306);
            Monto_Recomendado.Visible = false;
            label82.Text = "Monto Fijo:";

        }



        #endregion
        #region Configuracion

        private void IconButton1_Click(object sender, EventArgs e)
        {
            Boton_Permisos.Enabled = false;
            Guardar = false;
            lblTitle.Text = @"Configuracion";
            EsconderPaneles(panel2);
            _ = new Accesos();
            object[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }

        private bool changingCheckedState;
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingCheckedState)
            {
                changingCheckedState = true;

                if (checkBox1.Checked)
                {
                    // Desactivar el uso de contraseña
                    TextboxContr.UseSystemPasswordChar = false;
                    TextboxConfirm.UseSystemPasswordChar = false;
                }
                else
                {
                    // Activar el uso de contraseña
                    TextboxContr.UseSystemPasswordChar = true;
                    TextboxConfirm.UseSystemPasswordChar = true;
                }

                changingCheckedState = false;
            }
        }


        #region Edicion conexion sql

        public static bool Conect;
        public static bool Revisador = true;

        private bool isTabPageLoaded; // Variable para rastrear si los objetos de la pestaña se han cargado

        private async void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                await LoadTabPage0Async();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (!isTabPageLoaded)
                {
                    await LoadTabPage1Async();
                    isTabPageLoaded = true;
                }
            }
            else
            {
                // Lógica para otros índices del TabControl
            }
        }

        private async Task LoadTabPage0Async()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(await Task.Run(() => Accesos.CargarUsuarios().ToArray()));
        }

        private async Task LoadTabPage1Async()
        {
            await Task.Run(() =>
            {
                // Cargar y preparar los objetos de la pestaña 1 en segundo plano

                // Actualizar la interfaz de usuario una vez que los objetos estén listos
                Invoke((Action)(() =>
                {
                    TextServer.Text = Properties.Settings1.Default.Servidor;
                    TextPuerto.Text = Properties.Settings1.Default.Puerto.ToString();
                    TextBase.Text = Properties.Settings1.Default.Base_de_datos;
                    TextUsuario.Text = Properties.Settings1.Default.Usuario;
                    TextContra.Text = Properties.Settings1.Default.Contraseña;

                    LabelEstado.Text = Conect ? "Inactivo" : "Activo";
                    LabelEstado.ForeColor = Conect ? Color.Red : Color.Green;
                }));
            });
        }


        private bool changingCheckedState3;
        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingCheckedState3)
            {
                changingCheckedState3 = true;

                if (checkBox3.Checked)
                {
                    // Desactivar el uso de contraseña
                    TextContra.UseSystemPasswordChar = false;

                }
                else
                {
                    // Activar el uso de contraseña
                    TextContra.UseSystemPasswordChar = true;
                }

                changingCheckedState3 = false;
            }
        }
        private void RjButton2_Click(object sender, EventArgs e)
        {
            string server = TextServer.Text;
            string puerto = TextPuerto.Text;
            string baseDeDatos = TextBase.Text;
            string usuario = TextUsuario.Text;
            string contraseña = TextContra.Text;

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(puerto) || string.IsNullOrEmpty(baseDeDatos) || string.IsNullOrEmpty(usuario))
            {
                MessageB("No puede haber nada vacio", "Error", 2);
            }
            else
            {
                Properties.Settings1.Default.Servidor = server;
                Properties.Settings1.Default.Puerto = Convert.ToInt32(puerto);
                Properties.Settings1.Default.Base_de_datos = baseDeDatos;
                Properties.Settings1.Default.Usuario = usuario;
                Properties.Settings1.Default.Contraseña = contraseña;
                Properties.Settings1.Default.Save();
                MessageB("Se guardaron los cambios", "Exito", 1);
            }
        }
        private CancellationTokenSource cancellationTokenSource; // Variable para cancelar la tarea
        private async void RjButton3_ClickAsync(object sender, EventArgs e)
        {
            Lectura_Base_Datos baseDatos = new();
            Revisador = false;
            await baseDatos.CheckConnection(true);
            Revisador = true;
            if (!Conect)
            {
                LabelEstado.Text = @"Inactivo";
                LabelEstado.ForeColor = Color.Red;
                LabelEstado.Location = new Point(751, 162);
                PingLabel.Hide();
                PingLabel.Location = new Point(966, 12);
            }
            else
            {
                LabelEstado.Text = @"Activo";
                LabelEstado.ForeColor = Color.Green;
                LabelEstado.Location = new Point(648, 161);
                PingLabel.Location = new Point(831, 163);
                cancellationTokenSource = new CancellationTokenSource();
                await Ping();
            }
        }
        Lectura_Base_Datos a = new();
        private async Task Ping()
        {
            PingLabel.Show();
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                await a.CheckConnection(true);

                if (Form1.Conect)
                {

                    string pin = await Task.Run(() => a.Ping());
                    if (Convert.ToInt32(pin) > 75 && Convert.ToInt32(pin) < 120)
                    {
                        PingLabel.ForeColor = Color.Orange;
                        PingLabel.Text = @"Ping: " + pin;
                    }
                    else if (Convert.ToInt32(pin) >= 120)
                    {
                        PingLabel.ForeColor = Color.Red;
                        PingLabel.Text = @"Ping: " + pin;
                    }
                    else
                    {
                        PingLabel.ForeColor = Color.Green;
                        PingLabel.Text = @"Ping: " + pin;
                    }
                }
                else
                {
                    cancellationTokenSource.Cancel(); // Detener la tarea si la conexión no está activa
                }
            }
        }
        #endregion
        #endregion
        #endregion

        #region Cosas Generales
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        public static void MessageB(string mensaje, string titulo, int tipo)
        {
            Form2 a1 = new(mensaje, titulo, tipo);
            a1.ShowDialog();
        }

        private void PanelBien_SizeChanged(object sender, EventArgs e)
        {
            label19.Height = PanelBien.Height; // Ajusta la altura del Label al tamaño del Panel
        }

        #endregion


        #region Promotores




        #region promotores principales


        public static void CargarPromotoresEnComboBox(RJComboBox box, bool a)
        {
            try
            {
                using (MySqlConnection connection = Lec.Conector())
                {
                    // Crear la consulta SQL para obtener los nombres de los promotores
                    string query = "SELECT Nombre FROM promotores";

                    // Limpiar el ComboBox antes de agregar los nuevos elementos
                    box.Items.Clear();
                    // Ejecutar la consulta SQL y obtener los resultados
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (a)
                            {
                                box.Items.Add("Promotor:");
                            }
                            // Agregar los nombres de los promotores al ComboBox
                            while (reader.Read())
                            {
                                string nombrePromotor = reader.GetString(0);
                                box.Items.Add(nombrePromotor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra al leer o cargar desde la base de datos
                Lec.Registro_errores("Error al cargar los promotores desde la base de datos: " + ex.Message);
            }
        }
        public static void AgregarPromotor(string nombrePromotor)
        {
            try
            {
                using (MySqlConnection connection = Lec.Conector())
                {
                    string query = "INSERT INTO promotores (Nombre) VALUES (@nombre)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombrePromotor);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Lec.Registro_errores("Error al agregar el promotor a la base de datos: " + ex.Message);
            }
        }
        public static void EditarPromotor(string nombreOriginal, string nuevoNombre)
        {
            try
            {
                using (MySqlConnection connection = Lec.Conector())
                {
                    string query = "UPDATE promotores SET Nombre = @nuevoNombre WHERE Nombre = @nombreOriginal";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreOriginal", nombreOriginal);
                        command.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Lec.Registro_errores("Error al editar el promotor en la base de datos: " + ex.Message);
            }
        }
        public static void EliminarPromotor(string nombrePromotor)
        {
            try
            {
                using (MySqlConnection connection = Lec.Conector())
                {
                    string query = "DELETE FROM promotores WHERE Nombre = @nombre";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombrePromotor);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Lec.Registro_errores("Error al eliminar el promotor de la base de datos: " + ex.Message);
            }
        }
        #endregion


        private void RjComboBox4_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rjComboBox4.SelectedIndex != -1)
            {
                rjButton6.Enabled = true;
                textBox4.Text = rjComboBox4.SelectedItem.ToString();
            }

        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            rjButton4.Enabled = true;
        }
        private void RjButton4_Click(object sender, EventArgs e)
        {

            Administrador_Acceso admin2 = new();
            admin2.ShowDialog();
            if (admin)
            {
                EditarPromotor(rjComboBox4.SelectedItem.ToString(), textBox4.Text);
                textBox4.Text = "";
                rjComboBox4.SelectedIndex = -1;
                cambioEnPromotores = true;
                CargaMasiva();
            }
        }
        private void RjButton6_Click(object sender, EventArgs e)
        {

            Administrador_Acceso admin2 = new();
            admin2.ShowDialog();
            if (admin)
            {
                EliminarPromotor(rjComboBox4.SelectedItem.ToString());
                rjComboBox4.SelectedIndex = -1;
                textBox4.Text = "";
                cambioEnPromotores = true;
                CargaMasiva();
            }

        }
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            rjButton5.Enabled = true;
        }
        private void RjButton5_Click(object sender, EventArgs e)
        {

            Administrador_Acceso admin2 = new();
            admin2.ShowDialog();
            if (admin)
            {
                AgregarPromotor(textBox5.Text);
                textBox5.Text = "";
                cambioEnPromotores = true;
                CargaMasiva();
            }
        }
        #endregion


        private void RjComboBox9_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rjComboBox9.SelectedIndex != -1)
            {
                btnMarcarP.Enabled = true;

                if (rjComboBox9.SelectedItem.ToString().Contains("(PAGADA)"))
                {
                    requierAdmin2 = true;
                    string[] pago = datos[rjComboBox9.SelectedIndex + 16].Split("-");
                    txtBoxMonto.Texts = pago[1];
                }
                if (rjComboBox9.SelectedIndex == 14)
                {
                    Monto_Recomendado.Location = new Point(33, 611);
                    Monto_Recomendado.Visible = false;
                    label82.Text = "Fecha:";
                    DateTimePago15.Location = new Point(298, 315);
                    DateTimePago15.Show();
                    DateTimePago15.Enabled = true;
                }
                else
                {
                    DateTimePago15.Location = new Point(211, 622);
                    DateTimePago15.Hide();
                    DateTimePago15.Enabled = false;
                    Monto_Recomendado.Location = new Point(298, 306);
                    Monto_Recomendado.Visible = true;
                    label82.Text = "Monto Fijo:";
                }
            }
            else
            {
                btnMarcarP.Enabled = false;
            }
        }
        #region limitar a ingresar numeros
        private void TextBoxPago_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBoxCredito_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBoxPagare_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBoxRestante_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBoxLiquidacionIntencion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBoxQuita_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TextBoxPagare3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextImporte3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxCredito3__TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxCredito3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void textBoxPersonalizado11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void textBoxPersonalizado8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void textBoxPersonalizado7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextCreditoLiq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }
        #endregion

        #region Permisos de lectura       
        private void Boton_Permisos_Click(object sender, EventArgs e)
        {
            Administrador_Acceso acc = new();
            acc.ShowDialog();
            if (admin)
            {
                Permisos_Lect a = new(comboBox1.SelectedItem.ToString());
                a.ShowDialog();
            }
        }

        private void BtnLista1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void BtnLista2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void BtnLista3_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void BtnLiquidados_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void BtnMostrarTodos_MouseDown(object sender, MouseEventArgs e)
        {

        }
        #endregion

        private void comboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                Boton_Permisos.Enabled = true;
                textBox2.Text = comboBox1.SelectedItem.ToString();
            }
            else
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                Boton_Permisos.Enabled = false;
            }
        }

        private void Button1_Click_2(object sender, EventArgs e)
        {

            Administrador_Acceso admin2 = new();
            admin2.ShowDialog();
            if (admin)
            {

                bool mensaje;
                _ = new Accesos();
                string user = textBox1.Text;
                string password = TextboxContr.Text;
                if (string.IsNullOrEmpty(user))
                {
                    AvisoVacio.Text = @"No puede haber nada vacio";
                }
                else
                {
                    mensaje = Accesos.AgregarUsuario(user, password);
                    if (mensaje)
                    {
                        textBox1.Text = "";
                        TextboxContr.Text = "";
                        TextboxConfirm.Text = "";
                        AvisoVacio.Text = "";
                    }
                    else
                    {
                        AvisoVacio.Text = @"El usuario ya existe. No se pudo agregar";
                    }
                }
            }

            _ = new Accesos();
            object[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }

        private void rjButton11_Click(object sender, EventArgs e)
        {
            Administrador_Acceso admin2 = new();
            admin2.ShowDialog();
            if (admin)
            {
                bool editarUsuarioContraseña = Accesos.EditarUsuarioContraseña(comboBox1.SelectedItem.ToString(), textBox2.Text, textBox3.Text);
                if (editarUsuarioContraseña)
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                    List<string> usuarios = Accesos.CargarUsuarios();
                    comboBox1.Items.Clear();
                    foreach (var users in usuarios)
                    {
                        comboBox1.Items.Add(users);
                    }
                    comboBox1.SelectedIndex = -1;
                }
                else
                {
                    MessageB("Error al editar al usuario", "Error", 3);
                }
            }
        }

        private void rjButton12_Click(object sender, EventArgs e)
        {
            Administrador_Acceso admin2 = new();
            admin2.ShowDialog();
            if (admin)
            {
                Accesos.EliminarUsuario(comboBox1.SelectedItem.ToString());
                textBox2.Text = "";
                comboBox1.SelectedIndex = -1;
                List<string> usuarios = Accesos.CargarUsuarios();
                comboBox1.Items.Clear();
                foreach (var users in usuarios)
                {
                    comboBox1.Items.Add(users);
                }
            }
        }
        private void btnCalcular1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = dateFechaInicio.Value;
            int multiplicador = cmbTipo.SelectedIndex == 0 ? 14 : 15;
            DateTime fechaFinal = dateTime.AddDays(multiplicador * 7);
            dateTimePickerPersonalizado2.Value = fechaFinal;

            string credito = txtCredito.Texts;
            double credito2 = Convert.ToDouble(credito);

            string nuevoString;

            if (cmbInteres.Texts == "Preferencial")
            {
                nuevoString = "7";
            }
            else if (cmbInteres.Texts == "Premier")
            {
                nuevoString = "8";
            }
            else
            {
                nuevoString = "10";
            }

            Double interes2 = Convert.ToDouble(nuevoString);
            double tasaInteres = (interes2 * credito2 / 100) * 4;
            double montoTotal;
            montoTotal = credito2 + tasaInteres;
            string total2 = montoTotal.ToString("N2");
            txtTotal.Texts = $"${total2}";
            double montoSegunTipo = 0;
            string tipo = cmbTipo.Texts;
            if (tipo == "Semanales")
            {
                montoSegunTipo = montoTotal / 14;
            }
            else if (tipo == "Quincenales")
            {
                montoSegunTipo = montoTotal / 7;
            }
            string total = montoSegunTipo.ToString("N2");
            txtTotal_I.Texts = $"${total}";
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {

            string list = "";
            int ar = 0;
            Lectura_Base_Datos obj = new();
            ar = Lectura_Base_Datos.VerificarUsuarioEnListas(txtNombre.Texts);
            string lista = obj.VerificarLiquidados(txtNombre.Texts);
            if (ar != 0)
            {

                if (ar == 2)
                {
                    list = "Lista 2";
                }
                else
                {
                    list = "Lista 3";
                }
                Nom = txtNombre.Texts;
                Lis = list;
                Existencia ex = new();
                ex.ShowDialog();
            }
            if (lista != null)
            {
                Liq = lista;
                Nom = txtNombre.Texts;
                Lis = "Liquidados";
                Existencia ex = new();
                ex.ShowDialog();
            }

            if (Guar)
            {
                string interes = cmbInteres.Texts;
                string montoTotal = txtTotal.Texts.Replace("$", "");
                double p = (credito2 * 2);
                obj.Create("lista1", cmbPromotor.Texts, txtNombre.Texts, txtCredito.Texts, p.ToString(CultureInfo.InvariantCulture), dateFechaInicio.Value, dateTimePickerPersonalizado2.Value, interes, montoTotal, txtCalle.Texts, txtColonia.Texts, txtNumInt.Texts, txtNumExt.Texts, txtTelefono.Texts, txtCorreo.Texts, cmbTipo.SelectedItem.ToString(), montoTotal);
                obj.CrearAvales(Avales); //Agrega los avales a la base de datos
                //Borrar datos para poder agregar de nuevo 
                txtNombre.Texts = "";
                txtCredito.Texts = "";
                dateFechaInicio.Value = DateTime.Now;
                dateTimePickerPersonalizado2.Value = DateTime.Now;
                cmbInteres.Texts = "Seleccione un interés";
                cmbTipo.Texts = "Seleccione un tipo de pago";
                cmbPromotor.Texts = "Seleccione al promotor";
                txtTotal.Texts = "";
                txtTotal_I.Texts = "";
                txtCalle.Texts = "";
                txtColonia.Texts = "";
                txtNumExt.Texts = "";
                txtNumInt.Texts = "";
                txtTelefono.Texts = "";
                txtCorreo.Texts = "";
            }
            else
            {
                txtNombre.Texts = "";
                txtCredito.Texts = "";
                dateFechaInicio.Value = DateTime.Now;
                dateTimePickerPersonalizado2.Value = DateTime.Now;
                cmbInteres.Texts = "Seleccione un interés";
                cmbTipo.Texts = "Seleccione un tipo de pago";
                cmbPromotor.Texts = "Seleccione al promotor";
                txtTotal.Texts = "";
                txtTotal_I.Texts = "";
                txtCalle.Texts = "";
                txtColonia.Texts = "";
                txtNumExt.Texts = "";
                txtNumInt.Texts = "";
                txtTelefono.Texts = "";
                txtCorreo.Texts = "";
                TextBoxNombreaval1.Texts = "";
                TextBoxCalleaval1.Texts = "";
                TextBoxColoniaaval1.Texts = "";
                TextBoxNumIntaval1.Texts = "";
                TextBoxNumExtaval1.Texts = "";
                TextBoxTelefonoaval1.Texts = "";
                TextBoxCorreoaval1.Texts = "";
                TextBoxNombreaval2.Texts = "";
                TextBoxCalleaval2.Texts = "";
                TextBoxColoniaaval2.Texts = "";
                TextBoxNumIntaval2.Texts = "";
                TextBoxNumExtaval2.Texts = "";
                TextBoxTelefonoaval2.Texts = "";
                TextBoxCorreoaval2.Texts = "";
            }
        }
        private void btnGuardar2_Click(object sender, EventArgs e)
        {

        }

        private void btnMover2_Click(object sender, EventArgs e)
        {
            Revision_Mover_Liquidados obj = new();
            obj.ShowDialog();
            if (obj.MoverLiq)
            {
                string[] mov4 = new string[12];
                mov4[0] = Informacion3[0]; //Promotor
                mov4[1] = Informacion3[1]; //Nombre
                mov4[2] = Informacion3[2]; //Credito
                mov4[3] = "-";//Fecha de Inicio
                mov4[4] = Informacion3[4];//Calle
                mov4[5] = Informacion3[5];//Colonia
                mov4[6] = Informacion3[6];//NumInt
                mov4[7] = Informacion3[7];//NumExt
                mov4[8] = Informacion3[8];//Telefono
                mov4[9] = Informacion3[9];//Correo
                mov4[10] = "Lista 3";
                Lectura_Base_Datos instancia2 = new();
                bool av2 = instancia2.InsertarLiquidados(mov4);
                if (av2)
                {
                    instancia2.Erase(Cliente, "lista3");//Lo borro de la lista 3
                    EsconderPaneles(pnlListas);
                    btnLiquidados.PerformClick();
                }
                else
                {
                    MessageB("Error al mover a liquidados", "Error", 2);
                }
            }
            else
            {
                MessageB("Mover a liquidados cancelado", "Alerta", 2);
            }

        }
        private void btnMover3_Click(object sender, EventArgs e)
        {
            switch (CmbLista2.SelectedIndex)
            {
                case 0://Mover a lista 3
                    PedirDatos3 datos3 = new();
                    datos3.ShowDialog();
                    if (datos3.Mover3)
                    {
                        string[] move3 = new string[14];
                        move3[0] = Informacion2[0]; //Promotor
                        move3[1] = Informacion2[1]; //Nombre
                        move3[2] = Informacion2[2]; //Credito
                        move3[3] = Informacion2[4];//Pagare
                        move3[4] = Informacion2[5];//Calle
                        move3[5] = Informacion2[6];//Colonia
                        move3[6] = Informacion2[7];//NumInt
                        move3[7] = Informacion2[8];//NumExt
                        move3[8] = Informacion2[9];//Telefono
                        move3[9] = Informacion2[10];//Correo
                        move3[10] = datos3.ComboBoxResolucion3.SelectedItem.ToString();//Resolucion
                        move3[11] = datos3.ComboBoxResolucionD.SelectedItem.ToString();//Resolucion Demanda Embargo o en Tramite
                        move3[12] = datos3.TextImporte3.Texts;//Importe
                        Lectura_Base_Datos instancia = new();

                        bool av = instancia.InsertarLista3(move3);
                        if (av)
                        {
                            instancia.Erase(Cliente, "lista2");//Lo borro de la lista 2
                            EsconderPaneles(pnlListas);
                            btnLista3.PerformClick();
                        }
                        else
                        {
                            MessageB("Error al mover a lista 3", "Error", 2);
                        }
                    }
                    else
                    {
                        MessageB("Mover a lista 3 cancelado", "Mensaje", 1);
                    }

                    break;
                case 1://mover a liquidados
                    Revision_Mover_Liquidados obj = new();
                    obj.ShowDialog();
                    if (obj.MoverLiq)
                    {
                        string[] mov4 = new string[12];
                        mov4[0] = Informacion2[0]; //Promotor
                        mov4[1] = Informacion2[1]; //Nombre
                        mov4[2] = Informacion2[2]; //Credito
                        mov4[3] = "-";//Fecha de Inicio
                        mov4[4] = Informacion2[5];//Calle
                        mov4[5] = Informacion2[6];//Colonia
                        mov4[6] = Informacion2[7];//NumInt
                        mov4[7] = Informacion2[8];//NumExt
                        mov4[8] = Informacion2[9];//Telefono
                        mov4[9] = Informacion2[10];//Correo
                        mov4[10] = "Lista 2";
                        Lectura_Base_Datos instancia2 = new();
                        bool av2 = instancia2.InsertarLiquidados(mov4);
                        if (av2)
                        {
                            instancia2.Erase(Cliente, "lista2");//Lo borro de la lista 2
                            EsconderPaneles(pnlListas);
                            btnLiquidados.PerformClick();
                        }
                        else
                        {
                            MessageB("Error al mover a liquidados", "Error", 2);
                        }
                    }
                    else
                    {
                        MessageB("Mover a liquidados cancelado", "Mensaje", 1);
                    }
                    break;
            }
        }

        private void btnEditarFechas2_Click(object sender, EventArgs e)
        {
            TextBoxPago.Texts = "";
            LabelNombreEditar2_2.Text = Cliente;
            ComboBoxDeFechas.SelectedIndex = -1;
            Lecturas_Especificas instancia = new();
            EsconderPaneles(PanelEditar2_2);
            int i1 = 1;
            //acomodamos el combobox de Fechas para agregar las fechas que se necesiten
            ComboBoxDeFechas.Items.Clear();
            if (!Guardar)
            {
                Ediciones ed = new();
                int max = ed.ObtenerNumeroUltimaColumna("lista2");
                string[] info = instancia.LectName2(Cliente);
                for (int i = 0; i < (max * 2); i += 2)
                {
                    if (info[i + 14] == "-" || info[i + 14] == null)
                    {
                        ComboBoxDeFechas.Items.Add("Fecha " + i1);

                    }
                    else
                    {
                        ComboBoxDeFechas.Items.Add("Fecha " + i1 + "-Pagado");
                    }

                    if (i % 2 == 0)
                    {
                        i1++;
                    }
                }
            }
            else
            {
                for (int i = 1; i < 15; i++)
                {
                    ComboBoxDeFechas.Items.Add("Fecha " + i);
                }
            }

        }


        private void Botoncambiodefechamomentaneo_Click_1(object sender, EventArgs e)
        {
            if (!Guardar)
            {
                int indice;
                if (unclick)
                {
                    string fecha = FechaEnLista2.Value.ToString("dd/MM/yyyy");
                    string pago = TextBoxPago.Texts;
                    Ediciones ed = new();
                    int max = ed.ObtenerNumeroColumnas("lista2");
                    restanteOriginal = Convert.ToDouble(Informacion2[max]);
                    if (Convert.ToDouble(pago) > Convert.ToDouble(Informacion2[max]))
                    {
                        MessageB("El pago no puede ser mayor al monto restante", "Advertencia", 2);
                    }
                    else
                    {
                        if (Convert.ToDouble(pago) < PagoOriginal)
                        {
                            Administrador_Acceso a = new();
                            a.ShowDialog();
                            if (admin)
                            {
                                indice = 14 + (ComboBoxDeFechas.SelectedIndex * 2);
                                indexFecha = indice;
                                Informacion2[indice] = fecha;
                                Informacion2[indice + 1] = pago;
                                double diferencia = PagoOriginal - Convert.ToDouble(pago);
                                double suma = Convert.ToDouble(Informacion2[max]) + diferencia;
                                Informacion2[42] = suma.ToString(CultureInfo.InvariantCulture);
                                TextBoxPagoExt.Texts = Informacion2[max];
                                if (TextBoxPagoExt.Texts == "0")
                                {
                                    mover = true;
                                }
                                else
                                {
                                    mover = false;
                                }
                            }
                            else
                            {
                                ComboBoxDeFechas_OnSelectedIndexChanged(null, null);
                            }
                        }
                        else
                        {
                            if (requierAdmin)
                            {
                                Administrador_Acceso a = new();
                                a.ShowDialog();
                                if (admin)
                                {
                                    indice = 14 + (ComboBoxDeFechas.SelectedIndex * 2);
                                    indexFecha = indice;
                                    Informacion2[indice] = fecha;
                                    Informacion2[indice + 1] = pago;
                                    double resta2 = Convert.ToDouble(Informacion2[max]) - Convert.ToDouble(pago);
                                    Informacion2[max] = resta2.ToString(CultureInfo.InvariantCulture);
                                    TextBoxPagoExt.Texts = Informacion2[max];
                                    if (TextBoxPagoExt.Texts == "0")
                                    {
                                        mover = true;
                                    }
                                    else
                                    {
                                        mover = false;
                                    }
                                }
                                else
                                {
                                    ComboBoxDeFechas_OnSelectedIndexChanged(null, null);
                                }
                            }
                            else
                            {
                                indice = 14 + (ComboBoxDeFechas.SelectedIndex * 2);
                                indexFecha = indice;
                                Informacion2[indice] = fecha;
                                Informacion2[indice + 1] = pago;
                                double resta = Convert.ToDouble(Informacion2[max]) - Convert.ToDouble(pago);
                                Informacion2[max] = resta.ToString(CultureInfo.InvariantCulture);
                                TextBoxPagoExt.Texts = Informacion2[max];
                                if (TextBoxPagoExt.Texts == "0")
                                {
                                    mover = true;
                                }
                                else
                                {
                                    mover = false;
                                }
                            }

                        }
                    }
                    rjButton7.Enabled = true;
                }

            }
            else
            {
                int indice;
                string fecha = FechaEnLista2.Value.ToString("dd/MM/yyyy");
                string pago = TextBoxPago.Texts;

                if (Convert.ToDouble(pago) > Convert.ToDouble(TextBoxPagoExt.Texts))
                {
                    MessageB("El pago no puede ser mayor al monto restante", "Advertencia", 2);
                }
                else
                {
                    indice = 14 + (ComboBoxDeFechas.SelectedIndex * 2);
                    indexFecha = indice;
                    InformacionPagos[indice] = fecha;
                    InformacionPagos[indice + 1] = pago;
                    double resta = Convert.ToDouble(TextBoxPagoExt.Texts) - Convert.ToDouble(pago);
                    InformacionPagos[42] = resta.ToString(CultureInfo.InvariantCulture);
                    TextBoxPagoExt.Texts = InformacionPagos[42];
                    if (TextBoxPagoExt.Texts == "0")
                    {
                        mover = true;
                    }
                    else
                    {
                        mover = false;
                    }

                    rjButton7.Enabled = true;
                }
            }

        }

        private void BotonVolverEditar2_Click_1(object sender, EventArgs e)
        {
            Botoncambiodefechamomentaneo.Enabled = false;
            FechaEnLista2.Enabled = false;
            editar2("Lista 2");
        }

        private void BottonLiq_Click_1(object sender, EventArgs e)
        {
            Ediciones e2 = new();
            string[] informacion4 = this.Informacion4;
            informacion4[1] = txtNombre.Texts; //Nombre del registro
            informacion4[2] = txtCredito.Texts; //Credito Prestado
            informacion4[3] = dateFechaInicio.Value.ToString("dd/MM/yyyy") ?? "-";
            informacion4[0] = cmbPromotor.SelectedItem.ToString(); //Promotor que lo atiende
            informacion4[10] = ComBoBoxLiquidacion.SelectedItem.ToString(); //De que lista viene
            informacion4[4] = txtCalle.Texts; //Calle
            informacion4[5] = txtColonia.Texts; //Colonia
            informacion4[6] = txtNumInt.Texts; //Numero de casa interior
            informacion4[7] = txtNumExt.Texts; //Numero de casa exterior
            informacion4[8] = txtTelefono.Texts; //Telefono
            informacion4[9] = txtCorreo.Texts; //Correo
            informacion4[11] = Cliente;
            bool saber2 = e2.EditarListaLiquidados(informacion4);
            bool er = e2.EditarAval(Cliente, NuevosAvales);
            if (saber2)
            {
                Lectura_Base_Datos obj = new();
                bool Existe = obj.Existencia_Aval(Cliente);
                if (Existe)
                {
                    if (e2.EditarAval(txtNombre.Texts, NuevosAvales))
                    {
                        EsconderPaneles(pnlListas);
                        btnLiquidados.PerformClick(); //Reactualizo los datos de la lista 2

                    }
                    else
                    {
                        MessageB("Error al guardar los avales", "Advertencia", 2);
                    }
                }
                else
                {
                    string[] DatosAvales = new string[16];
                    DatosAvales[0] = Cliente; //Convertirmos al orden para guardado
                    for (int i = 1; i < 15; i++)
                    {
                        DatosAvales[i] = NuevosAvales[i];
                    }

                    bool creado = obj.CrearAvales(DatosAvales);
                    if (creado)
                    {
                        EsconderPaneles(pnlListas);
                        btnLiquidados.PerformClick(); //Reactualizo los datos de la lista 2

                    }
                    else
                    {
                        MessageB("Error al guardar los avales", "Advertencia", 2);
                    }
                }
            }
            else
            {
                MessageB("Error al guardar los cambios", "Alerta", 2);
            }
        }

        private void BtnMover_Click_1(object sender, EventArgs e)
        {
            switch (cmbLista.SelectedIndex)
            {
                case 0://Mover a lista 2
                    Pedir_Datos pedirDatos = new();
                    pedirDatos.ShowDialog();
                    if (pedirDatos.Mover2)
                    {
                        //Para mover a lista 2 copio valores que tiene la lista 1 y agrego otros que el usuario debe agregar
                        string[] infoMov = new string[100];
                        infoMov[0] = Informacion[0]; //Promotor que lo atiende
                        infoMov[1] = Informacion[1]; //Nombre del registro
                        infoMov[2] = Informacion[2]; //Credito Prestado
                        infoMov[3] = Informacion[15]; //Monto Restante
                        infoMov[4] = Informacion[3]; //Pagare generado
                        infoMov[5] = Informacion[8]; //calle
                        infoMov[6] = Informacion[9]; //colonia
                        infoMov[7] = Informacion[10]; //Numero de casa interior
                        infoMov[8] = Informacion[11]; //Numero de casa exterior
                        infoMov[9] = Informacion[12]; //Telefono
                        infoMov[10] = Informacion[13]; //Correo
                        infoMov[11] = pedirDatos.rjComboBox2.SelectedItem.ToString(); //Su forma de pago Liquidacion o Intencion
                        #region Calculos Automaticos para el cambio
                        if (pedirDatos.rjComboBox2.SelectedItem.ToString() == "Liquidacion")
                        {

                            infoMov[12] = pedirDatos.TextLiquidacionPedir.Texts;//Monto de Liquidacion
                            int pag = int.Parse(infoMov[4]);
                            int liquidacion = int.Parse(infoMov[12]);
                            uint quita = ((uint)Convert.ToUInt64(pag)) - ((uint)Convert.ToUInt64(liquidacion)); //en Uint para que no sea negativo jamas
                            infoMov[13] = quita.ToString();//Monto de Quita que es la diferencia entre el liquidacion y el pagare por haber seleccionado liquidacion
                            infoMov[42] = liquidacion.ToString();//Monto de Extencion - Al pagare se le resta el pago de intencion
                        }
                        else
                        {
                            //Se toma encuenta 10% del Pagare y se le suma a su monto restante
                            int pag = int.Parse(infoMov[4]);
                            infoMov[12] = (pag * .10).ToString(CultureInfo.InvariantCulture);//Monto de Intencion
                            infoMov[13] = "0";//Monto de Quita es 0 por ser de convenio
                            infoMov[42] = (pag * .90).ToString(CultureInfo.InvariantCulture);//Monto de Extencion - Al pagare se le resta el pago de intencion
                        }
                        //Lleno la parte de fechas con guiones
                        for (int i = 14; i <= 41; i++)
                        {
                            infoMov[i] = "-";
                        }
                        #endregion
                        Lectura_Base_Datos instancia = new();
                        bool rev = instancia.InsertarLista2(infoMov);

                        if (rev)
                        {
                            //Borro el registro de la lista 1 porque si se movio al 2
                            instancia.Erase(infoMov[1], "lista1");
                            EsconderPaneles(pnlListas);
                            btnLista2.PerformClick(); //Reactualizo los datos de la lista  2
                        }
                        else
                        {
                            MessageB("Error al mover el registro", "Aviso", 2);
                        }
                    }
                    else
                    {
                        MessageB("Movimiento a lista 2 cancelado", "Aviso", 2);
                    }
                    break;
                case 1: //Para mover a lista 3
                    PedirDatos3 a1 = new();
                    a1.ShowDialog();
                    if (a1.Mover3)
                    {
                        string[] infoMov3 = new string[14];
                        infoMov3[0] = Informacion[0]; //Promotor que lo atiende
                        infoMov3[1] = Informacion[1]; //Nombre del registro
                        infoMov3[2] = Informacion[2]; //Credito Prestado
                        infoMov3[3] = Informacion[3]; //Pagare generado
                        infoMov3[4] = Informacion[8]; //calle
                        infoMov3[5] = Informacion[9]; //colonia
                        infoMov3[6] = Informacion[10]; //Numero de casa interior
                        infoMov3[7] = Informacion[11]; //Numero de casa exterior
                        infoMov3[8] = Informacion[12]; //Telefono
                        infoMov3[9] = Informacion[13]; //Correo
                        infoMov3[10] = a1.ComboBoxResolucion3.SelectedItem.ToString(); //Su forma de pago Liquidacion o Convenio
                        infoMov3[11] = a1.ComboBoxResolucionD.SelectedItem.ToString();//Monto de Liquidacion
                        infoMov3[12] = a1.TextImporte3.Texts;//Monto de Quita
                        Lectura_Base_Datos instancia3 = new();
                        bool rev3 = instancia3.InsertarLista3(infoMov3);
                        if (rev3)
                        {
                            instancia3.Erase(infoMov3[1], "lista1");
                            EsconderPaneles(pnlListas);
                            btnLista3.PerformClick(); //Reactualizo los datos de la lista  3
                        }
                        else
                        {
                            MessageB("Error al mover el registro", "Aviso", 2);
                        }
                    }
                    else
                    {
                        MessageB("Cancelado movimiento a lista 3", "Aviso", 2);
                    }
                    break;
                case 2: //Para mover a liquidados
                    Revision_Mover_Liquidados obj = new();
                    obj.ShowDialog();
                    if (obj.MoverLiq)
                    {
                        string[] infoMov4 = new string[12];
                        infoMov4[0] = Informacion[0]; //Promotor que lo atiende
                        infoMov4[1] = Informacion[1]; //Nombre del registro
                        infoMov4[2] = Informacion[2]; //Credito Prestado
                        infoMov4[3] = Informacion[4];//Fecha de inicio
                        infoMov4[4] = Informacion[8];//Calle
                        infoMov4[5] = Informacion[9];//Colonia
                        infoMov4[6] = Informacion[10];//Numero de casa interior
                        infoMov4[7] = Informacion[11];//Numero de casa exterior
                        infoMov4[8] = Informacion[12];//Telefono
                        infoMov4[9] = Informacion[13];//Correo
                        infoMov4[10] = "Lista 1";
                        Lectura_Base_Datos instancia4 = new();
                        bool rev4 = instancia4.InsertarLiquidados(infoMov4);
                        if (rev4)
                        {
                            instancia4.Erase(infoMov4[1], "lista1");
                            EsconderPaneles(pnlListas);
                            btnLiquidados.PerformClick(); //Reactualizo los datos de la lista Liquidados
                        }
                        else
                        {
                            MessageB("Error al mover el registro", "Aviso", 2);
                        }
                    }
                    else
                    {
                        MessageB("Cancelado movimiento a liquidados", "Aviso", 2);
                    }
                    break;
            }
        }

        private void BtnGuardarCambio_Click(object sender, EventArgs e)
        {
            if (lista == 1)
            {


                Ediciones e1 = new();
                string[] informacion = new string[50]; //Asigno los valores leidos anteriormente al nuevo string por si no hya cambios
                for (int i = 0; i < this.Informacion.Length; i++)
                {
                    informacion[i] = this.Informacion[i];
                }
                informacion[0] = cmbPromotor.SelectedItem.ToString() ?? "Seleccione un promotor"; //Promotor que lo atiende
                informacion[1] = txtNombre.Texts;
                informacion[2] = txtCredito.Texts; //Credito Prestado
                informacion[3] = textBoxPersonalizado11.Texts; //Pagare generado
                informacion[4] = dateFechaInicio.Value.ToString("dd/MM/yyyy"); //Fecha de Inicio
                informacion[5] = dateTimePickerPersonalizado2.Value.ToString("dd/MM/yyyy");//Fecha de su ultimo pago (Limite)
                informacion[6] = cmbInteres.SelectedItem.ToString(); //Interes Que tiene
                informacion[7] = txtTotal_I.Texts; //Monto Total del prestamo + intereses
                informacion[8] = txtCalle.Texts; //Calle
                informacion[9] = txtColonia.Texts; //ColoniaIndex was outside the 
                informacion[10] = txtNumInt.Texts; //Numero de casa interior
                informacion[11] = txtNumExt.Texts;//Numero de casa exterior
                informacion[12] = txtTelefono.Texts;//Telefono
                informacion[13] = txtCorreo.Texts;//Correo
                informacion[14] = cmbTipo.SelectedItem.ToString(); //Su forma de pago quincenales o semanales
                informacion[15] = txtTotal.Texts; //Monto Restante
                informacion[31] = Cliente;
                if (informacion[14] != tipoPago || dateFechaInicio.Value.ToString("d") != temporal[4])
                {
                    switch (cmbTipo.SelectedItem)
                    {
                        case "Semanales":
                            string[] fechSem;

                            fechSem = SumarSemanas(dateFechaInicio.Value.ToString("d"));
                            for (int i = 16; i <= 29; i++)
                            {
                                informacion[i] = fechSem[i - 16];
                            }

                            break;
                        case "Quincenales":
                            string[] fechQuin;
                            fechQuin = SumarQuincenas(dateFechaInicio.Value.ToString("d"));
                            for (int i = 16; i <= 29; i++)
                            {
                                if (i >= 23)
                                {
                                    informacion[i] = "-";
                                }
                                else
                                {
                                    informacion[i] = fechQuin[i - 16];
                                }
                            }
                            break;
                    }
                }
                Ediciones e2 = new();
                bool revisar = e1.EditarLista1(informacion);
                if (revisar)
                {
                    Lectura_Base_Datos obj = new();
                    bool Existe = obj.Existencia_Aval(txtNombre.Texts);
                    if (Existe)
                    {
                        if (e2.EditarAval(txtNombre.Texts, NuevosAvales))
                        {
                            EsconderPaneles(pnlListas);
                            btnLista1.PerformClick(); //Reactualizo los datos de la lista 2
                        }
                        else
                        {
                            MessageB("Error al guardar los avales", "Advertencia", 2);
                        }
                    }
                    else
                    {
                        string[] DatosAvales = new string[16];
                        DatosAvales[0] = txtNombre.Texts; //Convertirmos al orden para guardado
                        for (int i = 1; i < 15; i++)
                        {
                            DatosAvales[i] = Avales[i];
                        }

                        bool creado = obj.CrearAvales(DatosAvales);
                        if (creado)
                        {
                            EsconderPaneles(pnlListas);
                            btnLista1.PerformClick(); //Reactualizo los datos de la lista 2
                        }
                        else
                        {
                            MessageB("Error al guardar los avales", "Advertencia", 2);
                        }
                    }
                }
                else
                {
                    MessageB("Error al guardar los cambios", "Alerta", 2);
                }

                BtnAvalesEditar.Enabled = true;
            }
            else if (lista == 2)
            {
                if (mover)
                {
                    string[] mov5 = new string[12];
                    mov5[0] = Informacion2[0]; //Promotor que lo atiende
                    mov5[1] = Informacion2[1]; //Nombre del registro
                    mov5[2] = Informacion2[2]; //Credito Prestado
                    mov5[3] = "-";//Fecha de inicio
                    mov5[4] = Informacion2[5];//Calle
                    mov5[5] = Informacion2[6];//Colonia
                    mov5[6] = Informacion2[7];//Numero de casa interior
                    mov5[7] = Informacion2[8];//Numero de casa exterior
                    mov5[8] = Informacion2[9];//Telefono
                    mov5[9] = Informacion2[10];//Correo
                    mov5[10] = "Lista 2";
                    Lectura_Base_Datos instancia5 = new();
                    bool rev5 = instancia5.InsertarLiquidados(mov5);

                    if (rev5)
                    {
                        instancia5.Erase(mov5[1], "lista2"); //Eliminamos el registro 
                        EsconderPaneles(pnlListas);
                        btnLiquidados.PerformClick(); //Reactualizo los datos de la lista Liquidados ya que se paso para alla
                    }
                    else
                    {
                        MessageB("Error a Mover a Liquidados", "Advertencia", 2);
                    }
                }
                else
                {
                    if (!Guardar) //Si es false es porque esta editando y no guardando
                    {
                        Ediciones e2 = new();
                        string[] infoListaNueva2 = new string[100];
                        for (int i = 0; i < (Informacion2.Count()); i++)
                        {
                            infoListaNueva2[i] = Informacion2[i];
                        }
                        int max = e2.ObtenerNumeroColumnas("lista2");
                        infoListaNueva2[0] = cmbPromotor.SelectedItem.ToString(); //Promotor que lo atiende
                        infoListaNueva2[1] = txtNombre.Texts; //Nombre del registro
                        infoListaNueva2[2] = txtCredito.Texts; //Credito Prestado
                        infoListaNueva2[3] = txtTotal.Texts; //Monto Restante
                        infoListaNueva2[4] = TextBoxRestante.Texts; //Pagare generado
                        infoListaNueva2[5] = txtCalle.Texts; //Calle
                        infoListaNueva2[6] = txtColonia.Texts; //Colonia
                        infoListaNueva2[7] = txtNumInt.Texts; //Numero de casa interior
                        infoListaNueva2[8] = txtNumExt.Texts; //Numero de casa exterior
                        infoListaNueva2[9] = txtTelefono.Texts; //Telefono
                        infoListaNueva2[10] = txtCorreo.Texts; //Correo
                        infoListaNueva2[11] = cmbTipo.SelectedItem.ToString(); //Liquidacion o Intencion
                        infoListaNueva2[12] = txtTotal_I.Texts; //Monto de liquidacion o intencion
                        infoListaNueva2[13] = TextBoxQuita.Texts; //Monto de Quita
                        infoListaNueva2[max + 1] = Cliente; //Nombre del que va a editar
                        bool editarLista2 = e2.EditarLista2(infoListaNueva2);


                        if (editarLista2)
                        {
                            Lectura_Base_Datos obj = new();
                            bool Existe = obj.Existencia_Aval(txtNombre.Texts);
                            if (Existe)
                            {
                                if (e2.EditarAval(txtNombre.Texts, NuevosAvales))
                                {
                                    EsconderPaneles(pnlListas);
                                    btnLista2.PerformClick(); //Reactualizo los datos de la lista 2

                                }
                                else
                                {
                                    MessageB("Error al guardar los avales", "Advertencia", 2);
                                }
                            }
                            else
                            {
                                string[] DatosAvales = new string[17];
                                DatosAvales[0] = txtNombre.Texts; //Convertirmos al orden para guardado
                                for (int i = 1; i < 15; i++)
                                {
                                    DatosAvales[i] = NuevosAvales[i - 1];
                                }

                                bool creado = obj.CrearAvales(DatosAvales);
                                if (creado)
                                {
                                    EsconderPaneles(pnlListas);
                                    btnLista2.PerformClick(); //Reactualizo los datos de la lista 2

                                }
                                else
                                {
                                    MessageB("Error al guardar los avales", "Advertencia", 2);
                                }
                            }

                        }
                        else
                        {
                            MessageB("Error al guardar los cambios", "Advertencia", 2);
                        }

                    }
                    else //Si es verdadero esta guardando un usuario y no editandolo
                    {
                        Guardar = false;
                        Lectura_Base_Datos obj = new();
                        string[] infoListaNueva2 = new string[100];

                        for (int i = 0; i < InformacionPagos.Length; i++)
                        {
                            infoListaNueva2[i] = InformacionPagos[i];
                        }
                        infoListaNueva2[0] = cmbPromotor.SelectedItem.ToString(); //Promotor que lo atiende
                        infoListaNueva2[1] = txtNombre.Texts; //Nombre del registro
                        infoListaNueva2[2] = txtCredito.Texts; //Credito Prestado
                        infoListaNueva2[3] = txtTotal.Texts; //Monto Restante
                        infoListaNueva2[4] = TextBoxRestante.Texts; //Pagare generado
                        infoListaNueva2[5] = txtCalle.Texts; //Calle
                        infoListaNueva2[6] = txtColonia.Texts; //Colronia
                        infoListaNueva2[7] = txtNumInt.Texts; //Numeoo de casa exterior
                        infoListaNueva2[8] = txtNumExt.Texts; //Numerefono
                        infoListaNueva2[9] = txtTelefono.Texts; //Tel de casa interior
                        infoListaNueva2[10] = txtCorreo.Texts; //Correo
                        infoListaNueva2[11] = cmbTipo.SelectedItem.ToString(); //Liquidacion o Intencion
                        infoListaNueva2[12] = txtTotal_I.Texts; //Monto de liquidacion o intencion
                        infoListaNueva2[13] = TextBoxQuita.Texts; //Monto de Quita
                        infoListaNueva2[42] = TextBoxPagoExt.Texts;
                        if (obj.InsertarLista2(infoListaNueva2))
                        {
                            Ediciones e2 = new();
                            bool Existe = obj.Existencia_Aval(txtNombre.Texts);

                            if (Existe)
                            {

                                if (e2.EditarAval(txtNombre.Texts, NuevosAvales))
                                {

                                    EsconderPaneles(pnlListas);
                                    btnLista2.PerformClick(); //Reactualizo los datos de la lista 2
                                    cmbPromotor.SelectedItem = -1;
                                    cmbPromotor.Texts = "Seleccione un promotor";
                                    txtNombre.Texts = "";
                                    txtCredito.Texts = "";
                                    TextBoxRestante.Texts = "";
                                    txtTotal.Texts = "";
                                    txtCalle.Texts = "";
                                    txtColonia.Texts = "";
                                    txtNumInt.Texts = "";
                                    txtNumExt.Texts = "";
                                    txtTelefono.Texts = "";
                                    txtCorreo.Texts = "";
                                    cmbTipo.SelectedItem = -1;
                                    cmbTipo.Texts = "Seleccione una opcion";
                                    txtTotal_I.Texts = "";
                                    TextBoxQuita.Texts = "";
                                }
                                else
                                {
                                    MessageB("Error al guardar los avales", "Advertencia", 2);
                                }
                            }
                            else
                            {

                                string[] DatosAvales = new string[16];
                                DatosAvales[0] = txtNombre.Texts; //Convertirmos al orden para guardado
                                for (int i = 1; i < 15; i++)
                                {
                                    DatosAvales[i] = Avales[i - 1];
                                }

                                bool creado = obj.CrearAvales(DatosAvales);
                                if (creado)
                                {
                                    EsconderPaneles(pnlListas);
                                    btnLista2.PerformClick(); //Reactualizo los datos de la lista 2
                                    cmbPromotor.SelectedItem = -1;
                                    cmbPromotor.Texts = "Seleccione un promotor";
                                    txtNombre.Texts = "";
                                    txtCredito.Texts = "";
                                    txtTotal.Texts = "";
                                    TextBoxRestante.Texts = "";
                                    txtCalle.Texts = "";
                                    txtColonia.Texts = "";
                                    txtNumInt.Texts = "";
                                    txtNumExt.Texts = "";
                                    txtTelefono.Texts = "";
                                    txtCorreo.Texts = "";
                                    cmbTipo.SelectedItem = -1;
                                    cmbTipo.Texts = "Seleccione una opcion";
                                    txtTotal_I.Texts = "";
                                    TextBoxQuita.Texts = "";
                                }
                                else
                                {
                                    MessageB("Error al guardar los avales", "Advertencia", 2);
                                }
                            }

                        }
                        else
                        {
                            MessageB("Error al ingresar el usuario", "Alerta", 2);
                        }

                    }


                }
            }
            else
            {
                Ediciones ediciones = new();
                string[] strings = this.Informacion3;
                strings[1] = txtNombre.Texts; //Nombre del registro
                strings[2] = txtCredito.Texts; //Credito Prestado
                strings[3] = textBoxPersonalizado11.Texts; //Pagare generado
                strings[4] = txtCalle.Texts; //Calle
                strings[5] = txtColonia.Texts; //Colonia
                strings[6] = txtNumInt.Texts; //Numero de casa interior
                strings[7] = txtNumExt.Texts; //Numero de casa exterior
                strings[8] = txtTelefono.Texts; //Telefono
                strings[9] = txtCorreo.Texts; //Correo
                strings[0] = cmbPromotor.SelectedItem.ToString(); //Promotor que lo atiende
                strings[11] = ResolucionDemanda.SelectedItem.ToString(); //Resolucion de la demanda
                strings[12] = txtTotal.Texts; //Importe
                strings[10] = ComboBoxResolucion3.SelectedItem.ToString(); //Resolucion
                strings[13] = Cliente;
                bool es = ediciones.EditarLista3(strings);
                if (es)
                {
                    Ediciones e2 = new();
                    Lectura_Base_Datos obj = new();
                    bool Existe = obj.Existencia_Aval(txtNombre.Texts);
                    if (Existe)
                    {
                        if (e2.EditarAval(txtNombre.Texts, NuevosAvales))
                        {
                            editar3("Lista 3");
                            btnLista3.PerformClick();

                        }
                        else
                        {
                            MessageB("Error al guardar los avales", "Advertencia", 2);
                        }
                    }
                    else
                    {
                        string[] DatosAvales = new string[16];
                        DatosAvales[0] = txtNombre.Texts; //Convertirmos al orden para guardado
                        for (int i = 1; i < 15; i++)
                        {
                            DatosAvales[i] = Avales[i];
                        }

                        bool creado = obj.CrearAvales(DatosAvales);
                        if (creado)
                        {
                            editar3("Lista 3");
                            btnLista3.PerformClick(); //Reactualizo los datos de la lista 2

                        }
                        else
                        {
                            MessageB("Error al guardar los avales", "Advertencia", 2);
                        }
                    }
                }
                else
                {
                    MessageB("Error al editar", "Alerta", 2);
                }
            }
        }
        public static string[] SumarSemanas(string fechaInicial)
        {
            DateTime fecha = Convert.ToDateTime(fechaInicial);
            string[] fechasSumadas = new string[14];

            for (int i = 0; i < 14; i++)
            {
                fecha = fecha.AddDays(7);
                fechasSumadas[i] = fecha.ToString("d");
            }

            return fechasSumadas;
        }
        public static string[] SumarQuincenas(string fechaInicial)
        {
            DateTime fecha = Convert.ToDateTime(fechaInicial);
            string[] fechasSumadas = new string[7];

            for (int i = 0; i < 7; i++)
            {
                fecha = fecha.AddDays(15);
                fechasSumadas[i] = fecha.ToString("d");
            }

            return fechasSumadas;
        }
        private void textBoxPersonalizado4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        #region KeyPress
        private void TextNumIntLiq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxNumInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxNumInt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxNumExt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void textBoxPersonalizado3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void textBoxPersonalizado2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void textBoxPersonalizado9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxTelefono3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }
        private void TextTelefonoLiq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextNumExtLiq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        #endregion

        private void ComboBoxPromotoresListas_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxPromotoresListas.SelectedIndex != -1 && ComboBoxPromotoresListas.SelectedIndex != 0)
            {
                btnLista3.Enabled = false;
                btnLiquidados.Enabled = false;
                btnMostrarTodos.Enabled = false;
                rjButton1.Enabled = false;
            }
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            TextBoxPagoExt.Texts = restanteOriginal.ToString(CultureInfo.InvariantCulture);
            TextBoxPago.Texts = "";
            Informacion2[indexFecha] = "";
            Informacion2[indexFecha + 1] = "";
            Informacion2[42] = restanteOriginal.ToString(CultureInfo.InvariantCulture);

        }


        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (!changingCheckedState5)
            {
                changingCheckedState5 = true;

                if (checkBox2.Checked)
                {
                    // Desactivar el uso de contraseña
                    textBox3.UseSystemPasswordChar = false;

                }
                else
                {
                    // Activar el uso de contraseña
                    textBox3.UseSystemPasswordChar = true;
                }

                changingCheckedState5 = false;

            }
        }

        #region Boton de reincio
        private void iconButton2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        #endregion
        private void dateTimePickerPersonalizado1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = new();
            switch (cmbTipo.SelectedItem)
            {
                case "Semanales":
                    dateTime = dateFechaInicio.Value;
                    var fechaFinal = dateTime.AddDays(7 * 14);
                    dateTimePickerPersonalizado2.Value = Convert.ToDateTime(fechaFinal.ToString("d"));
                    break;
                case "Quincenales":
                    dateTime = dateFechaInicio.Value;
                    fechaFinal = dateTime.AddDays(15 * 7);
                    dateTimePickerPersonalizado2.Value = Convert.ToDateTime(fechaFinal.ToString("d"));
                    break;
            }


        }

        private void rjComboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePickerPersonalizado1_ValueChanged(null, null);
        }

        private void iconButton3_Click(object sender, EventArgs e)//Boton para ingresar cliente a la lista 2
        {
            listaEstado = 4;
            Guardar = true;
            groupBox2.Hide(); //Escondemos el apartado para mover el usuario
            editar2("Lista 2");
            TextBoxPagoExt.Enabled = true;
            cmbPromotor.SelectedItem = -1;
            cmbPromotor.Texts = "Seleccione un promotor";
            txtNombre.Texts = "";
            txtCredito.Texts = "";
            TextBoxRestante.Texts = "";
            txtTotal.Texts = "";
            txtCalle.Texts = "";
            txtColonia.Texts = "";
            txtNumInt.Texts = "";
            txtNumExt.Texts = "";
            txtTelefono.Texts = "";
            txtCorreo.Texts = "";
            cmbTipo.SelectedItem = -1;
            cmbTipo.Texts = "Seleccione una opcion";
            txtTotal_I.Texts = "";
            TextBoxQuita.Texts = "";
            TextBoxPagoExt.Texts = "";
        }

        #region GridListas
        private void gridListas_Scroll(object sender, ScrollEventArgs e)
        {

            if (ComboBoxPromotoresListas.SelectedIndex == 0)
            {
                if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                {
                    // Obtener el desplazamiento horizontal actual
                    int horizontalOffset = gridListas.HorizontalScrollingOffset;

                    // Asegurarse de que las dos primeras columnas estén siempre visibles
                    if (gridListas.Columns.Count > 0)
                    {
                        gridListas.Columns[0].Frozen = true;
                        gridListas.Columns[1].Frozen = true;
                    }


                    // Recorrer todas las columnas a partir de la tercera columna
                    for (int i = 2; i < gridListas.ColumnCount; i++)
                    {
                        // Obtener el ancho de la columna actual
                        int columnWidth = gridListas.Columns[i].Width;

                        // Verificar si la columna actual está completamente visible
                        if (horizontalOffset >= gridListas.Columns.GetColumnsWidth(DataGridViewElementStates.Visible))
                        {
                            // Hacer visible la siguiente columna
                            gridListas.Columns[i].Visible = true;

                            // Actualizar el desplazamiento horizontal para incluir el ancho de la columna actual
                            horizontalOffset += columnWidth;

                            // Ocultar la columna actual para mantener solo dos columnas visibles
                            gridListas.Columns[i].Visible = false;
                        }
                        else
                        {
                            // La columna actual está visible, así que la mostramos
                            gridListas.Columns[i].Visible = true;
                        }
                    }
                }
            }

        }

        private void gridListas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Obtener el índice de la fila actual
            int rowIndex = e.RowIndex;

            // Alternar colores para las filas
            Color evenRowColor = ColorTranslator.FromHtml("#778899");
            Color oddRowColor = ColorTranslator.FromHtml("#CCCCCC");
            // Establecer el color de fondo de la fila actual
            if (rowIndex % 2 == 0)
            {
                // Fila par
                gridListas.Rows[rowIndex].DefaultCellStyle.BackColor = evenRowColor;
            }
            else
            {
                // Fila impar
                gridListas.Rows[rowIndex].DefaultCellStyle.BackColor = oddRowColor;
            }
        }
        #endregion

        #region Avales

        private void BtnGuardarAval_Click(object sender, EventArgs e)
        {

            if (editaravales)
            {
                NuevosAvales[0] = TextBoxNombreaval1.Texts;
                NuevosAvales[1] = TextBoxCalleaval1.Texts;
                NuevosAvales[2] = TextBoxColoniaaval1.Texts;
                NuevosAvales[3] = TextBoxNumIntaval1.Texts;
                NuevosAvales[4] = TextBoxNumExtaval1.Texts;
                NuevosAvales[5] = TextBoxTelefonoaval1.Texts;
                NuevosAvales[6] = TextBoxCorreoaval1.Texts;
                NuevosAvales[7] = TextBoxNombreaval2.Texts;
                NuevosAvales[8] = TextBoxCalleaval2.Texts;
                NuevosAvales[9] = TextBoxColoniaaval2.Texts;
                NuevosAvales[10] = TextBoxNumIntaval2.Texts;
                NuevosAvales[11] = TextBoxNumExtaval2.Texts;
                NuevosAvales[12] = TextBoxTelefonoaval2.Texts;
                NuevosAvales[13] = TextBoxCorreoaval2.Texts;
                if (listaEstado == 0)
                {
                    pnlClientes.BringToFront();
                    pnlClientes.Visible = true;
                    editaravales = false;
                    BtnAvalesEditar.Enabled = false;

                }
                else if (listaEstado == 1)
                {
                    editar2("Lista 2");
                    editaravales = false;
                }
                else if (listaEstado == 2)
                {
                    editar3("Lista 3");
                    editaravales = false;
                }
                else if (listaEstado == 3)
                {

                    editaravales = false;

                }
            }
            else
            {
                Avales[0] = txtNombre.Texts;
                Avales[1] = TextBoxNombreaval1.Texts;
                Avales[2] = TextBoxCalleaval1.Texts;
                Avales[3] = TextBoxColoniaaval1.Texts;
                Avales[4] = TextBoxNumIntaval1.Texts;
                Avales[5] = TextBoxNumExtaval1.Texts;
                Avales[6] = TextBoxTelefonoaval1.Texts;
                Avales[7] = TextBoxCorreoaval1.Texts;
                Avales[8] = TextBoxNombreaval2.Texts;
                Avales[9] = TextBoxCalleaval2.Texts;
                Avales[10] = TextBoxColoniaaval2.Texts;
                Avales[11] = TextBoxNumIntaval2.Texts;
                Avales[12] = TextBoxNumExtaval2.Texts;
                Avales[13] = TextBoxTelefonoaval2.Texts;
                Avales[14] = TextBoxCorreoaval2.Texts;
                //Vaciamos los valores
                TextBoxNombreaval1.Texts = "";
                TextBoxCalleaval1.Texts = "";
                TextBoxColoniaaval1.Texts = "";
                TextBoxNumIntaval1.Texts = "";
                TextBoxNumExtaval1.Texts = "";
                TextBoxTelefonoaval1.Texts = "";
                TextBoxCorreoaval1.Texts = "";
                TextBoxNombreaval2.Texts = "";
                TextBoxCalleaval2.Texts = "";
                TextBoxColoniaaval2.Texts = "";
                TextBoxNumIntaval2.Texts = "";
                TextBoxNumExtaval2.Texts = "";
                TextBoxTelefonoaval2.Texts = "";
                TextBoxCorreoaval2.Texts = "";
                if (listaEstado == 4)
                {
                    editar2("Lista 2");
                    listaEstado = 0;
                }
                else
                {
                    pnlClientes.BringToFront();
                    pnlClientes.Visible = true;
                }

            }
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
            editaravales = false;
            PnlAvales.BringToFront();
            PnlAvales.Visible = true;
        }
        private bool editaravales = false;
        private void BtnAvalesEditar_Click(object sender, EventArgs e)//Boton para editar avales
        {
            //Primero leemos los datos del aval
            Lectura_Base_Datos er = new();
            string[] datos = er.ObtenerAvales(cmbCliente.Texts);
            LabelAvalCliente.Text = cmbCliente.Texts;
            if (datos == null || datos.Length < 14)
            {
                // Si datos es nulo o no tiene al menos 14 elementos, llenar campos con cadenas vacías
                TextBoxNombreaval1.Texts = "";
                TextBoxCalleaval1.Texts = "";
                TextBoxColoniaaval1.Texts = "";
                TextBoxNumIntaval1.Texts = "";
                TextBoxNumExtaval1.Texts = "";
                TextBoxTelefonoaval1.Texts = "";
                TextBoxCorreoaval1.Texts = "";
                TextBoxNombreaval2.Texts = "";
                TextBoxCalleaval2.Texts = "";
                TextBoxColoniaaval2.Texts = "";
                TextBoxNumIntaval2.Texts = "";
                TextBoxNumExtaval2.Texts = "";
                TextBoxTelefonoaval2.Texts = "";
                TextBoxCorreoaval2.Texts = "";
            }
            else
            {
                // Si datos no es nulo y tiene al menos 14 elementos, llenar campos con valores de datos
                TextBoxNombreaval1.Texts = datos[0] ?? "";
                TextBoxCalleaval1.Texts = datos[1] ?? "";
                TextBoxColoniaaval1.Texts = datos[2] ?? "";
                TextBoxNumIntaval1.Texts = datos[3] ?? "";
                TextBoxNumExtaval1.Texts = datos[4] ?? "";
                TextBoxTelefonoaval1.Texts = datos[5] ?? "";
                TextBoxCorreoaval1.Texts = datos[6] ?? "";
                TextBoxNombreaval2.Texts = datos[7] ?? "";
                TextBoxCalleaval2.Texts = datos[8] ?? "";
                TextBoxColoniaaval2.Texts = datos[9] ?? "";
                TextBoxNumIntaval2.Texts = datos[10] ?? "";
                TextBoxNumExtaval2.Texts = datos[11] ?? "";
                TextBoxTelefonoaval2.Texts = datos[12] ?? "";
                TextBoxCorreoaval2.Texts = datos[13] ?? "";
            }
            //Ahora mostramos el panel de avales
            PnlAvales.BringToFront();
            PnlAvales.Visible = true;
        }
        private void rjButton9_Click(object sender, EventArgs e)
        {
            if (listaEstado != 4)
            {
                editaravales = true;
                BtnAvalesEditar_Click(null, null);
            }
            else
            {
                editaravales = false;
                PnlAvales.BringToFront();
                PnlAvales.Visible = true;
            }
        }

        private void rjButton10_Click(object sender, EventArgs e)
        {
            editaravales = true;
            BtnAvalesEditar_Click(null, null);
        }

        private void rjButton13_Click(object sender, EventArgs e)
        {
            editaravales = true;
            BtnAvalesEditar_Click(null, null);
        }
        private void rjButton14_Click(object sender, EventArgs e)
        {
            TextBoxNombreaval1.Texts = "";
            TextBoxCalleaval1.Texts = "";
            TextBoxColoniaaval1.Texts = "";
            TextBoxNumIntaval1.Texts = "";
            TextBoxNumExtaval1.Texts = "";
            TextBoxTelefonoaval1.Texts = "";
            TextBoxCorreoaval1.Texts = "";
            TextBoxNombreaval2.Texts = "";
            TextBoxCalleaval2.Texts = "";
            TextBoxColoniaaval2.Texts = "";
            TextBoxNumIntaval2.Texts = "";
            TextBoxNumExtaval2.Texts = "";
            TextBoxTelefonoaval2.Texts = "";
            TextBoxCorreoaval2.Texts = "";
        }
        #endregion

        public int lista = 0;

        #region Agregar Columnas
        private void BtnAgregarColumnas_Click(object sender, EventArgs e)
        {
            Agregar_Columnas ag = new();
            ag.ShowDialog();
        }
        #endregion

        #region Grafica de promotores

        private void BtnGraficar_Click(object sender, EventArgs e)
        {
            double total = MontoTotal - DineroAire;
            valor1 = Convert.ToInt32(DineroAire);
            valor2 = Convert.ToInt32(total);
            valor3 = Convert.ToInt32(MontoTotal);
            nombre = ComboBoxPromotoresListas.SelectedItem.ToString();
            Grafica gra = new();
            gra.ShowDialog();
        }
        #endregion

        #region Funciones para Reutilizacion de Panel


        //Con esta funcion escondemos todos los objetos compartidos del panel de clientes para cuando se llame en situacion especifica otro tipo de gestion
        //que comparte el panel solo llamar los  objetos que se necesitan y no batallar con esconderlos y llamarlos cada vez que se necesite
        public void OcultarControlesEnControl<T>(T container) where T : Control
        {
            foreach (Control control in container.Controls)
            {
                control.Hide();


            }
        }

        #region Agregar Clientes
        void subsecuente_agregar()
        {
            lista = 0;
            List<TextBoxPersonalizado> textBoxes = new List<TextBoxPersonalizado>
{
    txtTotal_I, txtTotal, txtCorreo, txtTelefono, txtNumExt, txtNumInt, txtColonia, txtCalle,
    txtCredito, txtNombre
};

            // Asignar .Texts = "" a los controles de la lista
            foreach (var textBox in textBoxes)
            {
                textBox.Texts = "";
            }
            rjButton8.Show();
            label87.Show();
            btnCalcular1.Show();
            btnGuardar1.Show();
            dateTimePickerPersonalizado2.Show();
            label65.Show();
            cmbInteres.Show();
            txtTotal_I.Show();
            txtTotal.Show();
            txtCorreo.Show();
            label15.Show();
            txtTelefono.Show();
            label14.Show();
            txtNumExt.Show();
            txtNumInt.Show();
            txtColonia.Show();
            label11.Show();
            label13.Show();
            label12.Show();
            txtCalle.Show();
            label3.Show();
            label10.Show();
            label9.Show();
            label7.Show();
            label6.Show();
            cmbTipo.Show();
            label5.Show();
            label16.Show();
            label4.Show();
            dateFechaInicio.Show();
            txtCredito.Show();
            label2.Show();
            txtNombre.Show();
            label1.Show();
            cmbPromotor.Show();
            cmbPromotor.SelectedIndex = -1;
            cmbPromotor.Texts = "Seleccione un promotor";
            cmbTipo.Items.Clear();
            cmbTipo.Texts = "Seleccione una opcion";
            cmbTipo.Items.AddRange(new object[] { "Semanales", "Quincenales" });
        }

        public void agregar()
        {
            //llamo a la funcion para esconder todos los objetos compartidos 
            OcultarControlesEnControl(pnlClientes);
            //despues activo solo los que necesito para este caso 
            subsecuente_agregar();
            //Asignacion de datos de personalizacion a los objetos asi como de posicionamiento y tamaño
            //Generacion de Fuentes de texto para los distintos objetos 
            Font nuevaFuente3 = new Font("Dubai", 13.79f);
            Font nuevaFuente = new Font("SimSun", 23.75f);
            Font nuevaFuente4 = new Font("Dubai", 16.19f);
            //Boton de calculo
            rjButton8.Location = new Point(805, 508);
            //label subtitulo 
            label87.Location = new Point(133, 11);
            label87.Text = "Informacion:";
            label87.Font = nuevaFuente;
            //Boton de calculo
            btnCalcular1.Location = new Point(544, 566);
            //Boton de Guardado
            btnGuardar1.Location = new Point(805, 588);
            btnGuardar1.Text = "Guardar";
            btnGuardar1.Size = new Size(196, 63);
            //DateTimePicker de fecha final
            dateTimePickerPersonalizado2.Location = new Point(255, 271);
            dateTimePickerPersonalizado2.Font = nuevaFuente3;
            dateTimePickerPersonalizado2.Size = new Size(445, 52);
            //label de Fecha Final o fecha limite
            label65.Location = new Point(24, 278);
            label65.Text = "Fecha Final:";
            //opciones de intereses (Combobox)
            cmbInteres.Location = new Point(255, 332);
            //TextBox de Monto Total
            txtTotal_I.Location = new Point(331, 589);
            txtTotal_I.Size = new Size(157, 47);
            txtTotal_I.Texts = "";
            txtTotal_I.Font = nuevaFuente3;
            //Label Monto Total 
            label16.Location = new Point(19, 601);
            label16.Text = "Monto Total:";
            //TextBox de Monto Total con Intereses
            txtTotal.Location = new Point(331, 529);
            txtTotal.Size = new Size(157, 47);
            txtTotal.Texts = "";
            //textbox Correo
            txtCorreo.Location = new Point(745, 450);
            txtCorreo.Text = "";
            //label Correo
            label15.Location = new Point(741, 414);
            label15.Text = "Correo:";
            //TextBox de Telefono
            txtTelefono.Location = new Point(745, 357);
            txtTelefono.Texts = "";
            //label Telefono
            label14.Location = new Point(741, 319);
            label14.Text = "Telefono:";
            //TextBox de Numero Exterior
            txtNumExt.Location = new Point(940, 249);
            txtNumExt.Texts = "";
            //label Numero Exterior
            label13.Location = new Point(940, 216);
            label13.Text = "Num. Ext.:";
            //TextBox de Numero Interior
            txtNumInt.Location = new Point(745, 249);
            txtNumInt.Texts = "";
            //label Numero Interior
            label12.Location = new Point(741, 218);
            label12.Text = "Num. Int.:";
            //TextBox de Colonia
            txtColonia.Location = new Point(745, 164);
            txtColonia.Texts = "";
            //label Colonia
            label11.Location = new Point(741, 134);
            label11.Text = "Colonia:";
            //TextBox de Calle
            txtCalle.Location = new Point(745, 76);
            txtCalle.Texts = "";
            //label Calle
            label10.Location = new Point(741, 45);
            label10.Text = "Calle:";
            //label Subtitulo superior derecha
            label9.Location = new Point(826, 10);
            label9.Text = "Direccion:";
            //label de monto total con interes
            label7.Location = new Point(19, 547);
            label7.Text = "Monto Total con Interes:";
            //label Promotor: 
            label6.Location = new Point(24, 489);
            label6.Text = "Promotor:";
            //Combobox de tipo de pago
            cmbTipo.Location = new Point(255, 404);
            cmbTipo.Font = nuevaFuente3;
            cmbTipo.Size = new Size(445, 52);
            //label tipo de pago
            label5.Location = new Point(24, 420);
            label5.Text = "Tipo de Pago:";
            //label de interes
            label4.Location = new Point(24, 335);
            label4.Text = "Interes:";
            //DateTimePicker de fecha de inicio
            dateFechaInicio.Location = new Point(255, 199);
            dateFechaInicio.Font = nuevaFuente3;
            dateFechaInicio.Size = new Size(445, 52);
            dateTimePickerPersonalizado2.Font = nuevaFuente3;
            //label de fecha de inicio
            label3.Location = new Point(24, 210);
            label3.Text = "Fecha de Inicio:";
            //Textbox Credito Prestado
            txtCredito.Location = new Point(255, 111);
            txtCredito.Font = nuevaFuente4;
            txtCredito.Size = new Size(445, 52);
            txtCredito.Texts = "";
            //label Credito Prestado
            label2.Location = new Point(24, 135);
            label2.Text = "Credito Prestado:";
            //Textbox Nombre
            txtNombre.Location = new Point(255, 59);
            txtNombre.Font = nuevaFuente4;
            txtNombre.Size = new Size(445, 52);
            txtNombre.Texts = "";
            //label Nombre
            label1.Location = new Point(24, 67);
            label1.Text = "Nombre Completo:";
            //Combobox de promotor
            cmbPromotor.Location = new Point(255, 471);
            cmbPromotor.Font = nuevaFuente3;
            cmbPromotor.Size = new Size(445, 52);
        }

        #endregion

        #region editar1
        void subsecuente_editar1()
        {
            lista = 1;
            BtnAvalesEditar.Show();
            textBoxPersonalizado11.Show();
            label66.Show();
            dateTimePickerPersonalizado2.Show();
            label65.Show();
            txtTotal.Show();
            label7.Show();
            txtTotal_I.Show();
            label16.Show();
            label87.Show();
            groupBox1.Show();
            txtCorreo.Show();
            label15.Show();
            txtTelefono.Show();
            label14.Show();
            txtNumExt.Show();
            label13.Show();
            txtNumInt.Show();
            label12.Show();
            txtColonia.Show();
            label11.Show();
            txtCalle.Show();
            label3.Show();
            label10.Show();
            cmbInteres.Show();
            label4.Show();
            cmbPromotor.Show();
            label6.Show();
            cmbTipo.Show();
            label5.Show();
            dateFechaInicio.Show();
            txtCredito.Show();
            label2.Show();
            txtNombre.Show();
            BtnGuardarCambio.Show();
            label1.Show();

        }
        public void editar1(string pertenece)
        {
            //llamo al panel que reutilizare
            EsconderPaneles(pnlClientes);
            lblTitle.Text = @"Editar Cliente";
            //Escondo todos los objetos 
            OcultarControlesEnControl(pnlClientes);
            //despues activo solo los que necesito para este caso
            subsecuente_editar1();

            //ahora establezo los datos para la pestañana  editar a clientes de la lista 1
            BtnAvalesEditar.Location = new Point(761, 587);
            BtnAvalesEditar.Show();
            Font bold = new Font("Dubai", 13.79f, FontStyle.Bold);
            Font bold2 = new Font("Dubai", 11.79f, FontStyle.Bold);
            Font nuevaFuete5 = new Font("Corbel", 18f, FontStyle.Bold);
            Font nuevaFuente3 = new Font("Corbel", 12.75f, FontStyle.Bold);
            Font nuevaFuente4 = new Font("Corbel", 16.2f);
            Font nuevaFuente = new Font("Corbel", 27.75f);
            Font nuevaFuente2 = new Font("Corbel", 12.75f);
            Font nuevaFuente6 = new Font("Corbel", 13.8f, FontStyle.Bold);
            //Aqui comienza la reutilizacion de los objetos
            //Boton de Guardado
            BtnGuardarCambio.Location = new Point(994, 589);
            //TexBox Pagare 
            textBoxPersonalizado11.Location = new Point(242, 180);
            textBoxPersonalizado11.Show();
            textBoxPersonalizado11.Font = nuevaFuente3;
            textBoxPersonalizado11.Size = new Size(358, 40);
            //label Pagare
            label66.Location = new Point(23, 192);
            label66.Font = nuevaFuete5;
            //DateTimePicker de fecha final
            dateTimePickerPersonalizado2.Location = new Point(242, 274); //Fecha Final
            dateTimePickerPersonalizado2.Font = nuevaFuente2;
            dateTimePickerPersonalizado2.Size = new Size(358, 40);
            //label de Fecha Final o fecha limite
            label65.Location = new Point(23, 282);
            label65.Text = "Fecha Limite:";
            //TextBox de Monto Restante
            txtTotal.Location = new Point(793, 490);
            txtTotal.Size = new Size(358, 45);
            txtTotal.Font = nuevaFuente3;
            txtTotal.Enabled = true;
            //Label Monto Restante
            label7.Location = new Point(787, 452);
            label7.Text = "Monto Restante:";
            //TextBox de Monto Total con Intereses
            txtTotal_I.Location = new Point(242, 385); //Monto Total 
            txtTotal_I.Font = nuevaFuente3;
            txtTotal_I.Size = new Size(358, 45);
            txtTotal_I.Enabled = true;
            //label credito prestado o monto total
            label16.Location = new Point(23, 396);
            label16.Text = "Monto Total:";
            //label Titulo
            label87.Location = new Point(23, 16);
            label87.Text = "Lista de Origen: " + pertenece;
            label87.Font = nuevaFuente;
            //Grupo box para mover de lista 
            groupBox1.Location = new Point(23, 585);
            groupBox1.Show();
            //Txbox de correo
            txtCorreo.Location = new Point(793, 400);
            txtCorreo.Font = bold;
            //label correo
            label15.Location = new Point(787, 362);
            //txtbox de telefono
            txtTelefono.Location = new Point(793, 311);
            txtTelefono.Font = bold;
            //label telefono
            label14.Location = new Point(787, 270);
            //txtbox de numero exterior
            txtNumExt.Location = new Point(959, 216);
            txtNumExt.Font = bold;
            //label numero exterior
            label13.Location = new Point(951, 188);
            //txtbox de numero interior
            txtNumInt.Location = new Point(793, 219);
            txtNumInt.Font = bold;
            //label numero interior
            label12.Location = new Point(787, 189);
            //txtbox de colonia
            txtColonia.Location = new Point(793, 134);
            txtColonia.Font = bold;
            //label colonia
            label11.Location = new Point(787, 107);
            //txtbox de calle
            txtCalle.Location = new Point(793, 54);
            txtCalle.Font = bold;
            //label calle
            label10.Location = new Point(790, 30);
            //combobox de interes
            cmbInteres.Location = new Point(242, 320);
            cmbInteres.Font = bold;
            cmbInteres.Size = new Size(358, 45);
            //label interes
            label4.Location = new Point(23, 331);
            //combobox de promotor
            cmbPromotor.Location = new Point(242, 511);
            cmbPromotor.Font = bold;
            cmbPromotor.Size = new Size(358, 45);
            //label promotor
            label6.Location = new Point(23, 519);
            //combobox de tipo de pago
            cmbTipo.Location = new Point(242, 442);
            cmbTipo.Font = bold;
            cmbTipo.Size = new Size(358, 45);
            //label tipo de pago
            label5.Location = new Point(23, 456);
            //datetime de fecha de inicio
            dateFechaInicio.Location = new Point(242, 234);
            dateFechaInicio.Font = nuevaFuente2;
            dateFechaInicio.Size = new Size(358, 40);
            //label fecha de inicio
            label3.Location = new Point(23, 240);
            label3.Text = "Fecha de Inicio:";
            //texox de credito prestado
            txtCredito.Location = new Point(242, 135);
            txtCredito.Font = bold2;
            txtCredito.Size = new Size(358, 40);
            //label credito prestado
            label2.Location = new Point(23, 145);
            //textbox de nombre
            txtNombre.Location = new Point(242, 83);
            txtNombre.Font = bold2;
            txtNombre.Size = new Size(358, 40);
            //label nombre
            label1.Location = new Point(23, 93);
        }

        #endregion

        #region Eidtar lista 2
        void subsecuente_editar2()
        {
            lista = 2;
            BtnGuardarCambio.Show();
            label66.Show();
            TextBoxRestante.Show();
            txtNombre.Show();
            label1.Show();
            txtCredito.Show();
            label2.Show();
            cmbTipo.Show();
            label5.Show();
            txtCorreo.Show();
            label15.Show();
            txtTelefono.Show();
            label14.Show();
            txtNumExt.Show();
            label13.Show();
            txtNumInt.Show();
            label12.Show();
            txtColonia.Show();
            label11.Show();
            txtCalle.Show();
            label10.Show();
            groupBox2.Show();
            label87.Show();
            TextBoxRestante.Show();
            txtTotal.Show();
            label7.Show();
            txtTotal_I.Show();
            label16.Show();
            TextBoxQuita.Show();
            label4.Show();
            btnEditarFechas2.Show();
            BtnAvalesEditar.Show();
            cmbPromotor.Show();
            label6.Show();
            label66.Show();
            txtTotal.Enabled = true;
            txtTotal_I.Enabled = true;
        }

        void editar2(string pertenece)
        {
            //Llamo al panel que usare como reutilizacion
            EsconderPaneles(pnlClientes);
            lblTitle.Text = @"Editar Cliente";
            //Escondo todos los objetos
            OcultarControlesEnControl(pnlClientes);
            //despues activo solo los que necesito para este caso
            subsecuente_editar2();
            //Asignacion de datos de personalizacion a los objetos asi como de posicionamiento y tamaño
            Font nuevaFuente = new Font("Corbel", 16.2f, FontStyle.Bold);
            Font nuevaFuente1 = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
            Font nuevaFuente2 = new Font("Corbel", 24f, FontStyle.Bold);
            //textbox de nombre
            txtNombre.Location = new Point(290, 71);
            txtNombre.Font = nuevaFuente;
            txtNombre.Size = new Size(371, 47);
            //label nombre
            label1.Location = new Point(33, 79);
            label1.Text = "Nombre Completo:";
            label1.Font = nuevaFuente1;
            //textbox de credito prestado
            txtCredito.Location = new Point(290, 126);
            txtCredito.Font = nuevaFuente;
            txtCredito.Size = new Size(371, 47);
            //label credito prestado
            label2.Location = new Point(33, 145);
            label2.Text = "Credito:";
            label2.Font = nuevaFuente1;
            //combobox de tipo de pago
            cmbTipo.Location = new Point(290, 296);
            cmbTipo.Font = nuevaFuente;
            cmbTipo.Size = new Size(371, 47);
            //label tipo de pago
            label5.Location = new Point(33, 316);
            label5.Text = "Tipo de Pago:";
            label5.Font = nuevaFuente1;
            //textbox Correo
            txtCorreo.Location = new Point(753, 427);
            txtCorreo.Font = nuevaFuente;
            //label correo
            label15.Location = new Point(744, 394);
            label15.Text = "Correo:";
            label15.Font = nuevaFuente1;
            //textbox telefono
            txtTelefono.Location = new Point(753, 338);
            txtTelefono.Font = nuevaFuente;
            //label telefono
            label14.Location = new Point(744, 311);
            label14.Text = "Telefono:";
            label14.Font = nuevaFuente1;
            //textbox numero exterior
            txtNumExt.Location = new Point(942, 238);
            txtNumExt.Font = nuevaFuente;
            txtNumExt.Size = new Size(151, 47);
            //label numero exterior
            label13.Location = new Point(946, 208);
            label13.Text = "Num. Ext.:";
            label13.Font = nuevaFuente1;
            //textbox numero interior
            txtNumInt.Location = new Point(753, 239);
            txtNumInt.Font = nuevaFuente;
            txtNumInt.Size = new Size(151, 47);
            //label numero interior
            label12.Location = new Point(744, 213);
            label12.Text = "Num. Int.:";
            label12.Font = nuevaFuente1;
            //textbox colonia
            txtColonia.Location = new Point(753, 155);
            txtColonia.Font = nuevaFuente;
            //label colonia
            label11.Location = new Point(744, 125);
            label11.Text = "Colonia:";
            label11.Font = nuevaFuente1;
            //textbox calle
            txtCalle.Location = new Point(753, 75);
            txtCalle.Font = nuevaFuente;
            //label calle
            label10.Location = new Point(744, 46);
            label10.Text = "Calle:";
            label10.Font = nuevaFuente1;
            //grupo de movimiento 2
            groupBox2.Location = new Point(38, 566);
            groupBox2.Show();
            //label Titulo
            label87.Location = new Point(31, 24);
            label87.Text = "Lista de Origen: " + pertenece;
            //txt Monto Restante
            TextBoxRestante.Location = new Point(290, 236);
            TextBoxRestante.Font = nuevaFuente;
            //txtPagare
            txtTotal.Location = new Point(290, 182);
            txtTotal.Font = nuevaFuente;
            txtTotal.Size = new Size(371, 47);
            //label Pagare
            label7.Location = new Point(33, 249);
            label7.Text = "Pagare:";
            label7.Font = nuevaFuente1;
            //txt Liquidacion Intencion
            txtTotal_I.Location = new Point(290, 432);
            txtTotal_I.Font = nuevaFuente;
            txtTotal_I.Size = new Size(371, 47);
            //label Liquidacion Intencion
            label16.Location = new Point(33, 450);
            label16.Text = "Liquidacion/Intencion:";
            label16.Font = nuevaFuente1;
            //TxtBox Quita
            TextBoxQuita.Show();
            TextBoxQuita.Location = new Point(290, 483);
            TextBoxQuita.Font = nuevaFuente;
            TextBoxQuita.Size = new Size(373, 47);
            //label quita
            label4.Location = new Point(33, 498);
            label4.Text = "Quita:";
            label4.Font = nuevaFuente1;
            //btnEditarFechas
            btnEditarFechas2.Show();
            btnEditarFechas2.Location = new Point(764, 492);
            //btn Avales
            BtnAvalesEditar.Location = new Point(964, 492);
            BtnAvalesEditar.Show();
            BtnAvalesEditar.Size = new Size(153, 60);
            //combobox de promotor
            cmbPromotor.Location = new Point(290, 374);
            cmbPromotor.Font = nuevaFuente;
            cmbPromotor.Size = new Size(371, 47);
            //label promotor
            label6.Location = new Point(33, 389);
            label6.Text = "Promotor:";
            label6.Font = nuevaFuente1;
            //label Monto Restante
            label66.Location = new Point(33, 198);
            label66.Text = "Monto restante:";
            label66.Font = nuevaFuente1;
        }

        #endregion

        #region Editar Lista 3
        void subsecuente_editar3()
        {

            txtNombre.Show();
            label1.Show();
            txtCredito.Show();
            label2.Show();
            BtnAvalesEditar.Show();
            BtnGuardarCambio.Show();
            txtCalle.Show();
            label10.Show();
            txtColonia.Show();
            label11.Show();
            txtNumInt.Show();
            label12.Show();
            txtNumExt.Show();
            label13.Show();
            txtTelefono.Show();
            label14.Show();
            txtCorreo.Show();
            label15.Show();
            label87.Show();
            textBoxPersonalizado11.Show();
            label66.Show();
            ResolucionDemanda.Show();
            label4.Show();
            ComboBoxResolucion3.Show();
            label3.Show();
            cmbPromotor.Show();
            groupBox3.Show();
            label6.Show();
            txtTotal.Show();
            label7.Show();

        }

        void editar3(string pertenece)
        {
            //Llamo al panel que usare como reutilizacion
            EsconderPaneles(pnlClientes);
            lblTitle.Text = @"Editar Cliente";
            //Escondo todos los objetos
            OcultarControlesEnControl(pnlClientes);
            //despues activo solo los que necesito para este caso
            subsecuente_editar3();


            Font nuevaFuente = new Font("Corbel", 16.2f, FontStyle.Bold);
            Font fuenteintermedia = new Font("Corbel", 13.8f, FontStyle.Bold);
            Font nuevaFuente1 = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
            Font nuevaFuente2 = new Font("Corbel", 24f, FontStyle.Bold);

            //txtNombre
            txtNombre.Location = new Point(270, 97);
            txtNombre.Font = nuevaFuente1;
            txtNombre.Size = new Size(414, 38);
            //label Nombre
            label1.Location = new Point(31, 104);
            label1.Font = nuevaFuente;
            label1.Text = "Nombre Completo:";
            //txt Credito prestado
            txtCredito.Location = new Point(270, 143);
            txtCredito.Font = nuevaFuente1;
            txtCredito.Size = new Size(414, 38);
            //label Credito prestado
            label2.Location = new Point(31, 161);
            label2.Font = nuevaFuente;
            label2.Text = "Credito Prestado:";
            //txt Calle
            txtCalle.Location = new Point(744, 65);
            txtCalle.Font = nuevaFuente;
            //label Calle
            label10.Location = new Point(744, 37);
            label10.Font = nuevaFuente;
            label10.Text = "Calle:";
            //txt Colonia
            txtColonia.Location = new Point(744, 147);
            txtColonia.Font = nuevaFuente;
            //label Colonia
            label11.Location = new Point(744, 118);
            label11.Font = nuevaFuente;
            label11.Text = "Colonia:";
            //txt Num Int
            txtNumInt.Location = new Point(744, 245);
            txtNumInt.Size = new Size(151, 47);
            txtNumInt.Font = nuevaFuente;
            //label Num Int
            label12.Location = new Point(744, 210);
            label12.Font = nuevaFuente;
            label12.Text = "Num. Int.:";
            //txtNumExt
            txtNumExt.Location = new Point(947, 246);
            txtNumExt.Size = new Size(151, 47);
            txtNumExt.Font = nuevaFuente;
            //label Num Ext
            label13.Location = new Point(952, 207);
            label13.Font = nuevaFuente;
            label13.Text = "Num. Ext.:";
            //txt Telefono
            txtTelefono.Location = new Point(744, 344);
            txtTelefono.Font = nuevaFuente;
            //label Telefono
            label14.Location = new Point(744, 315);
            label14.Font = nuevaFuente;
            label14.Text = "Telefono:";
            //txt Correo
            txtCorreo.Location = new Point(744, 449);
            txtCorreo.Font = nuevaFuente;
            //label Correo
            label15.Location = new Point(744, 415);
            label15.Font = nuevaFuente;
            label15.Text = "Correo:";
            //label Titulo
            label87.Location = new Point(26, 33);
            label87.Text = "Lista de Origen: " + pertenece;
            label87.Font = nuevaFuente2;
            //textBox Pagare
            textBoxPersonalizado11.Location = new Point(270, 200);
            textBoxPersonalizado11.Font = nuevaFuente;
            textBoxPersonalizado11.Size = new Size(414, 38);
            //label Pagare
            label66.Location = new Point(31, 217);
            label66.Font = nuevaFuente;
            label66.Text = "Pagare:";
            //combobox resolucion demanda
            ResolucionDemanda.Location = new Point(270, 394);
            ResolucionDemanda.Font = fuenteintermedia;
            ResolucionDemanda.Size = new Size(416, 54);
            //label resolucion demanda
            label4.Location = new Point(31, 410);
            label4.Font = nuevaFuente;
            label4.Text = "Resolucion Demanda:";
            //combobox tipo de resolucio
            ComboBoxResolucion3.Location = new Point(270, 271);
            ComboBoxResolucion3.Font = fuenteintermedia;
            ComboBoxResolucion3.Size = new Size(416, 54);
            //label tipo de resolucion
            label3.Location = new Point(31, 287);
            label3.Font = nuevaFuente;
            label3.Text = "Tipo de Resolucion:";
            //combobox de promotor
            cmbPromotor.Location = new Point(270, 336);
            cmbPromotor.Font = fuenteintermedia;
            cmbPromotor.Size = new Size(414, 38);
            //label promotor
            label6.Location = new Point(31, 352);
            label6.Font = nuevaFuente;
            label6.Text = "Promotor:";
            //txtImporte
            txtTotal.Location = new Point(270, 465);
            txtTotal.Font = fuenteintermedia;
            txtTotal.Size = new Size(414, 48);
            txtTotal.Enabled = true;
            //label importe
            label7.Location = new Point(31, 481);
            label7.Font = nuevaFuente;
            label7.Text = "Importe:";
            //btnGuardar
            BtnGuardarCambio.Location = new Point(798, 599);
            BtnGuardarCambio.Text = "Guardar";
            BtnGuardarCambio.Size = new Size(210, 65);
            //btnAvales
            BtnAvalesEditar.Location = new Point(793, 509);
            BtnAvalesEditar.Size = new Size(210, 65);
            //groupBox
            groupBox3.Location = new Point(47, 573);


        }

        #endregion

        #region Editar Liquidados

        void subsecuente_editarliq()
        {
            lista = 4;
            BtnAvalesEditar.Show();
            txtNombre.Show();
            txtCredito.Show();
            dateFechaInicio.Show();
            cmbPromotor.Show();
            ComBoBoxLiquidacion.Show();
            label1.Show();
            txtCalle.Show();
            label10.Show();
            txtColonia.Show();
            label11.Show();
            txtNumInt.Show();
            label12.Show();
            txtNumExt.Show();
            label13.Show();
            txtTelefono.Show();
            label14.Show();
            txtCorreo.Show();
            label15.Show();
            label87.Show();
            label65.Show();
            label6.Show();
            label3.Show();
            BottonLiq.Show();
            ComBoBoxLiquidacion.Show();
            label2.Show();
        }

        void editarliq(string pertenece)
        {
            //Primero llamo al panel que reutilizare
            EsconderPaneles(pnlClientes);
            lblTitle.Text = @"Editar Cliente";
            //Escondo todos los objetos
            OcultarControlesEnControl(pnlClientes);
            //despues activo solo los que necesito para este caso
            subsecuente_editarliq();
            //Asignacion de datos de personalizacion a los objetos asi como de posicionamiento y tamaño

            Font nuevaFuente = new Font("Corbel", 16.2f, FontStyle.Bold);
            Font nuevaFuente1 = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold);
            Font nuevaFuente2 = new Font("Corbel", 24f, FontStyle.Bold);

            //boton avales
            BtnAvalesEditar.Location = new Point(477, 581);
            BtnAvalesEditar.Show();
            //txtNombre
            txtNombre.Location = new Point(268, 94);
            txtNombre.Font = nuevaFuente1;
            txtNombre.Size = new Size(458, 50);
            //txtCredito
            txtCredito.Location = new Point(268, 180);
            txtCredito.Font = nuevaFuente1;
            txtCredito.Size = new Size(458, 50);
            //dateFechaInicio 
            dateFechaInicio.Location = new Point(268, 267);
            dateFechaInicio.Font = nuevaFuente;
            dateFechaInicio.Size = new Size(458, 50);
            //cmbPromotor
            cmbPromotor.Location = new Point(268, 346);
            cmbPromotor.Font = nuevaFuente;
            cmbPromotor.Size = new Size(458, 50);
            //ComBoBoxLiquidacion
            ComBoBoxLiquidacion.Location = new Point(268, 452);
            ComBoBoxLiquidacion.Font = nuevaFuente;
            ComBoBoxLiquidacion.Size = new Size(458, 50);
            //label Nombre
            label1.Location = new Point(18, 103);
            label1.Font = nuevaFuente;
            label1.Text = "Nombre Completo:";
            //txt Calle
            txtCalle.Location = new Point(822, 66);
            txtCalle.Font = nuevaFuente;
            //label Calle
            label10.Location = new Point(816, 25);
            label10.Font = nuevaFuente;
            label10.Text = "Calle:";
            //txt Credito prestado
            label2.Location = new Point(18, 190);
            label2.Font = nuevaFuente;
            label2.Text = "Credito Prestado:";
            //txt Colonia
            txtColonia.Location = new Point(822, 160);
            txtColonia.Font = nuevaFuente;
            //label Colonia
            label11.Location = new Point(816, 116);
            label11.Font = nuevaFuente;
            label11.Text = "Colonia:";
            //txt Num Int
            txtNumInt.Location = new Point(822, 248);
            txtNumInt.Size = new Size(115, 42);
            txtNumInt.Font = nuevaFuente;
            //label Num Int
            label12.Location = new Point(816, 212);
            label12.Font = nuevaFuente;
            label12.Text = "Num. Int.:";
            //txtNumExt
            txtNumExt.Location = new Point(960, 248);
            txtNumExt.Size = new Size(115, 42);
            txtNumExt.Font = nuevaFuente;
            //label Num Ext
            label13.Location = new Point(960, 213);
            label13.Font = nuevaFuente;
            label13.Text = "Num. Ext.:";
            //txt Telefono
            txtTelefono.Location = new Point(822, 342);
            txtTelefono.Font = nuevaFuente;
            //label Telefono
            label14.Location = new Point(816, 298);
            label14.Font = nuevaFuente;
            label14.Text = "Telefono:";
            //txt Correo
            txtCorreo.Location = new Point(822, 459);
            txtCorreo.Font = nuevaFuente;
            //label Correo
            label15.Location = new Point(816, 418);
            label15.Font = nuevaFuente;
            label15.Text = "Correo:";
            //label Titulo
            label87.Location = new Point(18, 22);
            label87.Text = "Lista de Origen: " + pertenece;
            label87.Font = nuevaFuente2;
            //label Fecha de Inicio
            label65.Location = new Point(18, 269);
            label65.Text = "Fecha del Prestamo:";
            label65.Font = nuevaFuente;
            //label Promotor
            label6.Location = new Point(18, 365);
            label6.Font = nuevaFuente;
            label6.Text = "Promotor:";

            //label Forma de Liquidacion
            label3.Location = new Point(18, 472);
            label3.Text = "Forma de Liquidacion:";
            label3.Font = nuevaFuente;

        }

        #endregion

        #endregion


    }
}