using FutureLending.ControlesPersonalizados;
using FutureLending.Forms;
using FutureLending.Funciones.cs;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Globalization;
using System.IO.Ports;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using Windows.Devices.Enumeration;
using Button = System.Windows.Forms.Button;
using Timer = System.Windows.Forms.Timer;

namespace FutureLending
{
    public partial class Form1 : Form
    {

        //Variable que se utiliza a la hora de borrar o editar un registro
        private string listaActual = "";
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            timer = new Timer();
            timer.Interval = 10; // Intervalo de tiempo para la animación (en milisegundos)
            timer.Tick += Timer_Tick;


        }
        private double opacity = 1.0;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarPromotoresEnComboBox(rjComboBox3, false);
            CargarPromotoresEnComboBox(cmbPromotor, false);
            Task.Run(() =>
            {
                // Actualizar los controles de la interfaz de usuario desde el hilo de UI
                this.Invoke(new Action(() =>
                {
                    CollapseMenu();
                    dateTimePickerPersonalizado2.Enabled = false;
                    rjButton6.Enabled = false;
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
                }));
            });
        }


        #region Animacion de menu
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 100;
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
            { //Expand menu
                panelMenu.Width = 250;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
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
        public static double dinero_aire = 0;
        #region Botones centrales del menu

        #region Ingresar Clientes

        private void BtnIngresarClientes_Click(object sender, EventArgs e)
        {

            EsconderPaneles(pnlClientes);
            lblTitle.Text = "Ingresar Clientes";
            CargarPromotoresEnComboBox(cmbPromotor, false);
            if (panelRg)
            {
                recargarDatosPnllRegPagos();
            }
        }
        Double credito2;
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
            foreach (ControlesPersonalizados.RJComboBox cmbDato in
                pnlClientes.Controls.OfType<ControlesPersonalizados.RJComboBox>())
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
        public static bool Boton1 { get; private set; }
        public static bool Boton2 { get; private set; }
        public static bool Boton3 { get; private set; }
        public static bool Boton4 { get; private set; }
        bool revisado = false;
        private void BtnListas_Click(object sender, EventArgs e)
        {
            CargarPromotoresEnComboBox(ComboBoxPromotoresListas, true);
            int a = 0;
            List<string> list = Accesos.ObtenerPermisosUsuario(Inicio_Sesion.NombreUsuario);
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

                            a += 1;
                            break;
                        case "lista2":
                            btnLista2.Enabled = true;
                            btnLista2.Click += BtnLista2_Click;
                            btnLista2.MouseDown += BtnLista2_MouseDown;
                            btnLista2.TabStop = true;
                            Boton2 = true;
                            a += 1;
                            break;
                        case "lista3":
                            btnLista3.Enabled = true;
                            btnLista3.Click += BtnLista3_Click;
                            btnLista3.MouseDown += BtnLista3_MouseDown;
                            btnLista3.TabStop = true;
                            Boton3 = true;
                            a += 1;
                            break;
                        case "liquidados":
                            btnLiquidados.Enabled = true;
                            btnLiquidados.Click += BtnLiquidados_Click;
                            btnLiquidados.MouseDown += BtnLiquidados_MouseDown;
                            btnLiquidados.TabStop = true;
                            Boton4 = true;
                            a += 1;
                            break;
                    }
                }
                if (a == 4)
                {
                    Habilitartodos();
                }
                a = 0;


            }

            lblTitle.Text = "Listas Completas";
            EsconderPaneles(pnlListas);
            if (panelRg)
            {
                recargarDatosPnllRegPagos();
            }
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
        private bool panelRg = false;
        //Funcion para esconder los paneles menos el enviado
        void EsconderPaneles(System.Windows.Forms.Panel panel1)
        {
            timer.Start();
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (control is System.Windows.Forms.Panel)
                {
                    System.Windows.Forms.Panel panel = (System.Windows.Forms.Panel)control;

                    // Verificar si el panel debe mantenerse visible o no
                    if (panel.Name != "panelTitleBar" && panel.Name != "panelMenu")
                    {
                        panel.Visible = false;
                    }
                }
            }
            panel1.Visible = true;
            panel1.BringToFront();
            if (panel1 == pnlRegPago)
            {
                panelRg = true;
            }
        }
        private void RjButton1_Click_1(object sender, EventArgs e)
        {
            Exportar_Excel a = new();
            a.ShowDialog();
        }
        #region Mostrar tablas en DataGridView y editar/eliminar registros
        int ListaEstado;
        private async void BtnLista1_Click(object sender, EventArgs e)
        {
            if (ComboBoxPromotoresListas.SelectedIndex != -1 && ComboBoxPromotoresListas.SelectedIndex != 0)
            {
                LabelDineroAire.Text = "";
                dinero_aire = 0;
                ListaEstado = 0;
                DesactivarBotones();
                Lectura_Base_Datos ar = new();
                List<string[]> Datos = ar.LectLista1Prom(ComboBoxPromotoresListas.SelectedItem.ToString());
                await TablaClientes.MostrarLista1Prom(gridListas, cmbCliente, BarradeProgreso, label57, Datos);
                LabelDineroAire.Text = ComboBoxPromotoresListas.SelectedItem.ToString() + " tiene $" + dinero_aire.ToString("N2") + " en Pagos pendientes";
                btnLista1.Enabled = true;
                btnLista2.Enabled = true;
                ActivarEditar();
                listaActual = "lista1";
            }
            else
            {
                LabelDineroAire.Text = "";
                ListaEstado = 0;
                DesactivarBotones();
                await TablaClientes.MostrarLista1(gridListas, cmbCliente, BarradeProgreso, label57);
                ActivarListas();
                ActivarEditar();
                listaActual = "lista1";
            }
        }

        private async void BtnLista2_Click(object sender, EventArgs e)
        {
            if (ComboBoxPromotoresListas.SelectedIndex != -1 && ComboBoxPromotoresListas.SelectedIndex != 0)
            {
                LabelDineroAire.Text = "";
                dinero_aire = 0;
                ListaEstado = 1;
                DesactivarBotones();
                Lectura_Base_Datos ar = new();
                List<string[]> datos = ar.LectLista2Prom(ComboBoxPromotoresListas.SelectedItem.ToString());
                await TablaClientes.MostrarLista2Prom(gridListas, cmbCliente, BarradeProgreso, label57, datos);
                LabelDineroAire.Text = ComboBoxPromotoresListas.SelectedItem.ToString() + " tiene $" + dinero_aire.ToString("N2") + " en Pagos pendientes";
                btnLista1.Enabled = true;
                btnLista2.Enabled = true;
                ActivarEditar();
                listaActual = "lista2";
            }
            else
            {
                LabelDineroAire.Text = "";
                ListaEstado = 1;
                DesactivarBotones();
                await TablaClientes.MostrarLista2(gridListas, cmbCliente, BarradeProgreso, label57);
                ActivarListas();
                ActivarEditar();
                listaActual = "lista2";
            }
        }

        private async void BtnLista3_Click(object sender, EventArgs e)
        {
            ListaEstado = 2;
            DesactivarBotones();

            await TablaClientes.MostrarLista3(gridListas, cmbCliente, BarradeProgreso, label57);

            ActivarListas();
            ActivarEditar();
            listaActual = "lista3";
        }

        private async void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            DesactivarBotones();

            await TablaClientes.MostrarTodos(gridListas, cmbCliente, BarradeProgreso, label57);

            ActivarListas();
        }

        private async void BtnLiquidados_Click(object sender, EventArgs e)
        {
            listaActual = "liquidados";
            ListaEstado = 3;
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
        public string[] informacion = new string[31]; //Se usa para guardar la info de la lista 1
        public string[] Informacion2 = new string[44]; //Se usa para guardar la info de la lista 2
        public string[] informacion3 = new string[15];//Se usa para guardar la info de la lista 3
        public string[] informacion4 = new string[12];//Se usa para guardar la info de liquidados
        public string[] Fechas = new string[100]; //Fechas de lista 2 inicializado en 100 por posible expansion futura
        public string[] Pagos = new string[14]; //Pagos de lista 2
        public string pertenece; //De que lista viene
        public string Cliente; //Nombre del cliente
        private string TipoPago; //Tipo de pago 

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Lecturas_Especificas a = new();
            if (ListaEstado == 0) //Si viene de la lista 1
            {
                //Cargar los promotores en el ComboBox
                CargarPromotoresEnComboBox(rjComboBox3, false);
                //Muestro el panel de editar
                EsconderPaneles(PanelEditar);
                //Limpio las listas donde es posible  mover al registro
                cmbLista.Items.Clear();
                cmbLista.Enabled = true;
                cmbLista.Items.AddRange(new string[] { "Lista 2", "Lista 3", "Liquidados" });
                //Establezco de donde viene este registro
                pertenece = "Lista 1";
                LblPerte.Text = pertenece;
                //Obtengo el nombre del cliente
                Cliente = cmbCliente.Texts;
                //Empieza leyendo su informacion de la base de datos
                informacion = a.LectName(Cliente);
                //Tuve que convertir de List<string[]> a string[] para poder usarlo en los objetos del Panel (Editar)
                textBoxPersonalizado10.Texts = Cliente;
                textBoxPersonalizado9.Texts = informacion[2]; //Credito Prestado
                textBoxPersonalizado11.Texts = informacion[3]; //Pagare generado
                dateTimePickerPersonalizado1.Value = DateTime.Parse(informacion[4]); //Fecha de Inicio
                dateTimeLimite.Value = DateTime.Parse(informacion[5]);//Fecha de su ultimo pago (Limite)
                rjComboBox1.SelectedItem = informacion[6]; //Interes Que tiene
                textBoxPersonalizado8.Texts = informacion[7]; //Monto Total del prestamo + intereses
                rjComboBox2.SelectedItem = informacion[14]; //Su forma de pago quincenales o semanales
                TipoPago = informacion[14];
                rjComboBox3.SelectedItem = informacion[0]; //Promotor que lo atiende
                textBoxPersonalizado7.Texts = informacion[15]; //Monto Restante
                textBoxPersonalizado6.Texts = informacion[8]; //Calle
                textBoxPersonalizado5.Texts = informacion[9]; //Colonia
                textBoxPersonalizado4.Texts = informacion[10]; //Numero de casa interior
                textBoxPersonalizado3.Texts = informacion[11];//Numero de casa exterior
                textBoxPersonalizado2.Texts = informacion[12];//Telefono
                textBoxPersonalizado1.Texts = informacion[13];//Correo
                //Del 16 al 29 son los datos de las 14 fechas que solo ocupan 7 si sus pagos con quincenales
            }
            else if (ListaEstado == 1) //Si viene de la lista 2
            {
                //Cargar los promotores en el ComboBox
                CargarPromotoresEnComboBox(rjComboBox8, false);
                //Llamo al panel editar de la lista 2
                EsconderPaneles(PnlEditar2);
                //Lleno el rjcombobox de promotores con la info correspondiente
                CargarPromotoresEnComboBox(rjComboBox8, false);
                //Limpio las listas donde es posible  mover al registro
                CmbLista2.Items.Clear();
                CmbLista2.Enabled = true;
                CmbLista2.Items.AddRange(new string[] { "Lista 3", "Liquidados" });
                //Nombre del registro
                Cliente = cmbCliente.Texts;
                //activar boton de fechas
                btnEditarFechas2.Enabled = true;
                //Ahora de donde viene este registro
                pertenece = "Lista 2";
                LabelPertenece.Text = pertenece;
                //Leo la informacion de ese registro en especifico
                Informacion2 = a.LectName2(Cliente);
                //Empiezo a llenar los objetos del panel editar2
                rjComboBox8.SelectedItem = Informacion2[0]; //Promotor que lo atiende
                TextBoxNombre.Texts = Cliente; //Nombre del registro
                TextBoxCredito.Texts = Informacion2[2]; //Credito Prestado
                TextBoxRestante.Texts = Informacion2[3]; //Monto Restante
                TextBoxPagare.Texts = Informacion2[4]; //Pagare generado
                TextBoxCalle.Texts = Informacion2[5]; //Calle
                TextBoxColonia.Texts = Informacion2[6]; //Colonia
                TextBoxNumInt.Texts = Informacion2[7]; //Numero de casa interior
                TextBoxNumExt.Texts = Informacion2[8]; //Numero de casa exterior
                TextBoxTelefono.Texts = Informacion2[9]; //Telefono
                TextBoxCorreo.Texts = Informacion2[10]; //Correo
                rjComboBox7.SelectedItem = Informacion2[11]; //Liquidacion o Intencion
                TextBoxLiquidacionIntencion.Texts = Informacion2[12]; //Monto de liquidacion o intencion
                TextBoxQuita.Texts = Informacion2[13]; //Monto de Quita
                TextBoxPagoExt.Texts = Informacion2[42];
                //De aqui pasa al caso de oprimir el boton para mover las fechas y pagos 
            }
            else if (ListaEstado == 2) //Si viene de la lista 3
            {
                //Cargar los promotores en el ComboBox
                CargarPromotoresEnComboBox(ComboBoxPromotor3, false);
                //Traer panel de edicion3
                EsconderPaneles(PanelEditar3);
                //Llenar el rjcombobox de promotores con la info correspondiente
                CargarPromotoresEnComboBox(ComboBoxPromotor3, false);
                //Limpio las listas donde es posible  mover al registro
                rjComboBox5.Items.Clear();
                rjComboBox5.Enabled = true;
                rjComboBox5.Items.AddRange(new string[] { "Liquidados" });
                //Nombre del registro
                Cliente = cmbCliente.Texts;
                //Leer la info
                informacion3 = a.LectName3(Cliente); //tamaño 14
                //Empiezo a llenar los objetos del panel editar3
                TextBoxNombre3.Texts = Cliente; //Nombre del registro
                TextBoxCredito3.Texts = informacion3[2]; //Credito Prestado
                TextBoxPagare3.Texts = informacion3[3]; //Pagare generado
                TextBoxCalle3.Texts = informacion3[4]; //Calle
                TextBoxColonia3.Texts = informacion3[5]; //Colonia
                TextBoxNumInt3.Texts = informacion3[6]; //Numero de casa interior
                TextBoxNumExt3.Texts = informacion3[7]; //Numero de casa exterior
                TextBoxTelefono3.Texts = informacion3[8]; //Telefono
                TextBoxCorreo3.Texts = informacion3[9]; //Correo
                ComboBoxPromotor3.SelectedItem = informacion3[0]; //Promotor que lo atiende
                ResolucionDemanda.SelectedItem = informacion3[11]; //Resolucion de la demanda
                TextImporte3.Texts = informacion3[12]; //Importe
                ComboBoxResolucion3.SelectedItem = informacion3[10]; //Resolucion
            }
            else if (ListaEstado == 3)//Si viene de liquidados
            {
                //Cargo lo promotres en el combobox de liquidados
                CargarPromotoresEnComboBox(ComboBoxPromotorLiq, false);
                //Traigo el panel editar de liquidados
                EsconderPaneles(PanelEditarLiquidados);
                //Nombre del registro
                Cliente = cmbCliente.Texts;
                //Obtenemos la informacion de ese registro en especifico
                informacion4 = a.LectName4(Cliente); //tamaño 12
                //Rellenamos los objetos del panel editar liquidados
                TextNombreLiq.Texts = Cliente; //Nombre del registro
                TextCreditoLiq.Texts = informacion4[2]; //Credito Prestado
                FechaInicioLiq.Value = DateTime.Parse(informacion4[3]); //Fecha de inicio
                ComboBoxPromotorLiq.SelectedItem = informacion4[0]; //Promotor que lo atiende
                ComBoBoxLiquidacion.SelectedItem = informacion4[10]; //De que lista viene


                TextCalleLiq.Texts = informacion4[4]; //Calle
                TextColoniaLiq.Texts = informacion4[5]; //Colonia
                TextNumIntLiq.Texts = informacion4[6]; //Numero de casa interior
                TextNumExtLiq.Texts = informacion4[7]; //Numero de casa exterior
                TextTelefonoLiq.Texts = informacion4[8]; //Telefono
                TextCorreoLiq.Texts = informacion4[9]; //Correo
            }
        }

        #region Lista1

        #endregion
        #region Lista2 
        //Seguir editando lista 2 pero las fechas y pagos
        //presionado boton guardar el pago y la asignacion de fecha en la lista 2 ademas de actualizar el Pago EXT
        bool Mover;
        private void Botoncambiodefechamomentaneo_Click(object sender, EventArgs e)
        {
            string fecha = FechaEnLista2.Value.ToString("dd/MM/yyyy");
            string pago = TextBoxPago.Texts;
            if (ComboBoxDeFechas.SelectedIndex == 0)
            {
                int indice = 14;
                Informacion2[indice] = fecha;
                Informacion2[indice + 1] = pago;
                int resta = int.Parse(Informacion2[42]) - int.Parse(pago);
                Informacion2[42] = resta.ToString();
                TextBoxPagoExt.Texts = Informacion2[42];
                if (TextBoxPagoExt.Texts == "0")
                {
                    Mover = true;
                }
                else
                {
                    Mover = false;
                }
            }
            else
            {
                int indice = 14 + (ComboBoxDeFechas.SelectedIndex * 2);
                Informacion2[indice] = fecha;
                Informacion2[indice + 1] = pago;
                int resta = int.Parse(Informacion2[42]) - int.Parse(pago);
                Informacion2[42] = resta.ToString();
                TextBoxPagoExt.Texts = Informacion2[42];
                if (TextBoxPagoExt.Texts == "0")
                {
                    Mover = true;
                }
                else
                {
                    Mover = false;
                }
            }

        }

        //Si selecciona una fecha de lista 2 se muestra en el datetimepicker
        private void ComboBoxDeFechas_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int apuntador = 0;
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

                    if (Informacion2[apuntador] == "-" || Informacion2[apuntador] == "" || Informacion2[apuntador] == null)
                    {
                        FechaEnLista2.Value = DateTime.Today;
                    }
                    else
                    {
                        FechaEnLista2.Value = DateTime.Parse(Informacion2[apuntador]);
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
                    }

                }

            }
            if (ComboBoxDeFechas.SelectedItem != null)
            {
                if (ComboBoxDeFechas.SelectedItem.ToString().Contains("Pagado"))
                {
                    ComboBoxDeFechas.SelectedIndex = -1;
                }

            }


        }
        //Si ya puso un pago se activa el boton
        private void TextBoxPago__TextChanged(object sender, EventArgs e)
        {
            if (TextBoxPago.Texts != null && TextBoxPago.Texts != "")
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
        private void BotonVolverEditar2_Click(object sender, EventArgs e)
        {
            btnEditarFechas2.Enabled = false;
            Botoncambiodefechamomentaneo.Enabled = false;
            FechaEnLista2.Enabled = false;
            EsconderPaneles(PnlEditar2);
        }
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
        #region Liquidados
        private void BottonLiq_Click(object sender, EventArgs e)
        {
            Ediciones e2 = new();
            string[] Informacion4 = informacion4;
            Informacion4[1] = TextNombreLiq.Texts; //Nombre del registro
            Informacion4[2] = TextCreditoLiq.Texts; //Credito Prestado
            Informacion4[3] = FechaInicioLiq.Value.ToString("dd/MM/yyyy"); //Fecha de inicio
            Informacion4[0] = ComboBoxPromotorLiq.SelectedItem.ToString(); //Promotor que lo atiende
            Informacion4[10] = ComBoBoxLiquidacion.SelectedItem.ToString(); //De que lista viene
            Informacion4[4] = TextCalleLiq.Texts; //Calle
            Informacion4[5] = TextColoniaLiq.Texts; //Colonia
            Informacion4[6] = TextNumIntLiq.Texts; //Numero de casa interior
            Informacion4[7] = TextNumExtLiq.Texts; //Numero de casa exterior
            Informacion4[8] = TextTelefonoLiq.Texts; //Telefono
            Informacion4[9] = TextCorreoLiq.Texts; //Correo
            Informacion4[11] = Cliente;
            bool saber2 = e2.EditarListaLiquidados(Informacion4);
            if (saber2)
            {
                EsconderPaneles(pnlListas);
                btnLiquidados.PerformClick(); //Reactualizo los datos de la lista Liquidados
            }
            else
            {
                MessageB("Error al guardar los cambios", "Alerta", 2);
            }
        }
        #endregion

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos instancia = new();
            instancia.Erase(cmbCliente.Texts, listaActual);

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
            EsconderPaneles(pnlRegPago);
            lblTitle.Text = "Registrar pago";

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
            string[] datos = instancia.LectName(ComBoxName.SelectedItem.ToString());
            int f = 0;
            for (int i = 16; i < 30; i++)
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
            string[] fechas = instancia2.LectName(ComBoxName.SelectedItem.ToString());

            if (Convert.ToDouble(txtBoxMonto.Texts) > Convert.ToDouble(fechas[15]))
            {
                MessageB("No puedes depositar mas de lo que debe", "Aviso", 2);
                txtBoxMonto.Texts = "";
            }
            else
            {
                //Leer las fechas registradas 
                int index = rjComboBox9.SelectedIndex; //Fecha seleccionada por el cliente
                index += 16;
                rjComboBox9.SelectedIndex = -1;
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
                    string[] dato = fechas;
                    dato[30] = fechas[1];
                    _ = instancia22.EditarLista1(dato);
                }
                //Resetear valores 

                recargarDatosPnllRegPagos();
                //Recargo de datos
                BtnEstadoPagos_Click(sender, e);
            }
        }
        void recargarDatosPnllRegPagos()
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
        }



        #endregion
        #region Configuracion

        private void IconButton1_Click(object sender, EventArgs e)
        {
            Boton_Permisos.Enabled = false;
            CargarPromotoresEnComboBox(rjComboBox4, false);

            lblTitle.Text = "Configuracion";
            EsconderPaneles(panel2);
            _ = new Accesos();
            string[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
            if (panelRg)
            {
                recargarDatosPnllRegPagos();
            }
        }

        private bool changingCheckedState = false;
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
        private bool changingCheckedState2 = false;
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingCheckedState2)
            {
                changingCheckedState2 = true;

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

                changingCheckedState2 = false;
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                textBox2.Text = "";
            }
            else
            {
                textBox2.Text = comboBox1.SelectedItem.ToString();
            }
        }


        private void Button3_Click(object sender, EventArgs e)
        {
            string usuario = comboBox1.SelectedItem.ToString();
            _ = new Accesos();
            Accesos.EliminarUsuario(usuario);
            comboBox1.SelectedIndex = -1;
            string[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            _ = new
            Accesos();
            string user = textBox2.Text.ToString();
            string pass = textBox3.Text.ToString();
            Accesos.EditarUsuarioContraseña(comboBox1.SelectedItem.ToString(), user, pass);
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            string[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }

        #region Edicion conexion sql

        public static bool conect;
        public static bool revisador = true;
        private readonly Lectura_Base_Datos lecturaBaseDatos = new Lectura_Base_Datos();

        private bool isTabPageLoaded = false; // Variable para rastrear si los objetos de la pestaña se han cargado

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

                    LabelEstado.Text = conect ? "Inactivo" : "Activo";
                    LabelEstado.ForeColor = conect ? Color.Red : Color.Green;
                }));
            });
        }


        private bool changingCheckedState3 = false;
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
            string server = TextServer.Text.ToString();
            string puerto = TextPuerto.Text.ToString();
            string base_de_datos = TextBase.Text.ToString();
            string usuario = TextUsuario.Text.ToString();
            string contraseña = TextContra.Text.ToString();

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(puerto) || string.IsNullOrEmpty(base_de_datos) || string.IsNullOrEmpty(usuario))
            {
                MessageB("No puede haber nada vacio", "Error", 2);
            }
            else
            {
                Properties.Settings1.Default.Servidor = server;
                Properties.Settings1.Default.Puerto = Convert.ToInt32(puerto);
                Properties.Settings1.Default.Base_de_datos = base_de_datos;
                Properties.Settings1.Default.Usuario = usuario;
                Properties.Settings1.Default.Contraseña = contraseña;
                Properties.Settings1.Default.Save();
                MessageB("Se guardaron los cambios", "Exito", 1);
            }
        }
        private async void RjButton3_ClickAsync(object sender, EventArgs e)
        {
            Lectura_Base_Datos a = new();
            revisador = false;
            await a.CheckConnection(true);
            revisador = true;
            if (!conect)
            {
                LabelEstado.Text = "Inactivo";
                LabelEstado.ForeColor = Color.Red;
            }
            else
            {
                LabelEstado.Text = "Activo";
                LabelEstado.ForeColor = Color.Green;
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


        public static void MessageB(string Mensaje, string titulo, int tipo)
        {
            Form2 a1 = new(Mensaje, titulo, tipo);
            a1.ShowDialog();
        }

        private void PanelBien_SizeChanged(object sender, EventArgs e)
        {
            label19.Height = PanelBien.Height; // Ajusta la altura del Label al tamaño del Panel
        }

        #endregion


        #region Promotores




        #region promotores principales
        static Lectura_Base_Datos lec = new();
        public static void CargarPromotoresEnComboBox(RJComboBox box, bool a)
        {
            Lectura_Base_Datos lec = new Lectura_Base_Datos();
            try
            {
                using (MySqlConnection connection = lec.Conector())
                {
                    // Crear la consulta SQL para obtener los nombres de los promotores
                    string query = "SELECT Nombre FROM promotores";

                    // Limpiar el ComboBox antes de agregar los nuevos elementos
                    box.Items.Clear();
                    box.Items.Add("Seleccionar Promotor");

                    // Ejecutar la consulta SQL y obtener los resultados
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
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
                lec.Registro_errores("Error al cargar los promotores desde la base de datos: " + ex.Message);
            }
        }
        public static void AgregarPromotor(string nombrePromotor)
        {
            try
            {
                using (MySqlConnection connection = lec.Conector())
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
                lec.Registro_errores("Error al agregar el promotor a la base de datos: " + ex.Message);
            }
        }
        public static void EditarPromotor(string nombreOriginal, string nuevoNombre)
        {
            try
            {
                using (MySqlConnection connection = lec.Conector())
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
                lec.Registro_errores("Error al editar el promotor en la base de datos: " + ex.Message);
            }
        }
        public static void EliminarPromotor(string nombrePromotor)
        {
            try
            {
                using (MySqlConnection connection = lec.Conector())
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
                lec.Registro_errores("Error al eliminar el promotor de la base de datos: " + ex.Message);
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
            EditarPromotor(rjComboBox4.SelectedItem.ToString(), textBox4.Text);
            textBox4.Text = "";
            rjComboBox4.SelectedIndex = -1;
            CargarPromotoresEnComboBox(rjComboBox4, false);
        }
        private void RjButton6_Click(object sender, EventArgs e)
        {
            EliminarPromotor(rjComboBox4.SelectedItem.ToString());
            rjComboBox4.SelectedIndex = -1;
            textBox4.Text = "";
            CargarPromotoresEnComboBox(rjComboBox4, false);

        }
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            rjButton5.Enabled = true;
        }
        private void RjButton5_Click(object sender, EventArgs e)
        {
            AgregarPromotor(textBox5.Text);
            textBox5.Text = "";
            CargarPromotoresEnComboBox(rjComboBox4, false);
        }
        #endregion

        private void RjComboBox9_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rjComboBox9.SelectedIndex != -1)
            {
                btnMarcarP.Enabled = true;
                if (rjComboBox9.SelectedItem.ToString().Contains("(PAGADA)"))
                {
                    rjComboBox9.SelectedIndex = -1;
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxPagare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxRestante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxLiquidacionIntencion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxQuita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
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

        private void Boton_Permisos_Click(object sender, EventArgs e)
        {
            Permisos_Lect per = new(comboBox1.SelectedItem.ToString());

            per.ShowDialog();
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
        private void label32_Click(object sender, EventArgs e)
        {

        }

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
            bool mensaje;
            _ = new Accesos();
            string User = textBox1.Text.ToString();
            string password = TextboxContr.Text.ToString();
            if (string.IsNullOrEmpty(User))
            {
                AvisoVacio.Text = "No puede haber nada vacio";
            }
            else
            {
                mensaje = Accesos.AgregarUsuario(User, password);
                if (mensaje == true)
                {
                    textBox1.Text = "";
                    TextboxContr.Text = "";
                    TextboxConfirm.Text = "";
                    AvisoVacio.Text = "";
                }
                else
                {
                    AvisoVacio.Text = "El usuario ya existe. No se pudo agregar";
                }
            }

            _ = new Accesos();
            string[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }

        private void rjButton11_Click(object sender, EventArgs e)
        {
            bool a = Accesos.EditarUsuarioContraseña(comboBox1.SelectedItem.ToString(), textBox2.Text, textBox3.Text);
            if (a)
            {
                comboBox1.Items.Clear();
                textBox2.Text = "";
                textBox3.Text = "";
                List<string> usuarios = Accesos.CargarUsuarios();
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

        private void rjButton12_Click(object sender, EventArgs e)
        {
            Accesos.EliminarUsuario(comboBox1.SelectedItem.ToString());
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;
            List<string> usuarios = Accesos.CargarUsuarios();
            foreach (var users in usuarios)
            {
                comboBox1.Items.Add(users);
            }
        }

        private void gridListas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBoxCredito__TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlClientes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCalcular1_Click(object sender, EventArgs e)
        {
            DateTime a = dateFechaInicio.Value;
            DateTime FechaFinal;
            int multiplicador = cmbTipo.SelectedIndex == 0 ? 14 : 15;
            FechaFinal = a.AddDays(multiplicador * 7);
            dateTimePickerPersonalizado2.Value = FechaFinal;
            String credito = txtCredito.Texts;
            credito2 = Convert.ToDouble(credito);
            _ = cmbInteres.Texts;
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
            double tasa_interes = (interes2 * credito2 / 100) * 4;
            double monto_total = credito2 + tasa_interes;
            string total2 = monto_total.ToString("N2");
            txtTotal.Texts = $"${total2}";
            double monto_segun_tipo = 0;
            string tipo = cmbTipo.Texts;
            if (tipo == "Semanales")
            {
                monto_segun_tipo = monto_total / 14;
            }
            else if (tipo == "Quincenales")
            {
                monto_segun_tipo = monto_total / 7;
            }
            string total = monto_segun_tipo.ToString("N2");
            txtTotal_I.Texts = $"${total}";
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos obj = new();
            bool ar = Lectura_Base_Datos.VerificarUsuarioEnListas(txtNombre.Texts);
            if (ar)
            {
                string Interes = cmbInteres.Texts;
                string MontoTotal = txtTotal.Texts.Replace("$", "");
                double p = (credito2 * 2);
                obj.Create("lista1", cmbPromotor.Texts, txtNombre.Texts, txtCredito.Texts, p.ToString(), dateFechaInicio.Value, dateTimePickerPersonalizado2.Value, Interes, MontoTotal, txtCalle.Texts, txtColonia.Texts, txtNumInt.Texts, txtNumExt.Texts, txtTelefono.Texts, txtCorreo.Texts, cmbTipo.SelectedItem.ToString(), MontoTotal);
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
                MessageB("El cliente ya existe en la lista", "Error", 3);
            }
        }
        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            Ediciones a = new();
            string[] Informacion3 = informacion3;
            Informacion3[1] = TextBoxNombre3.Texts; //Nombre del registro
            Informacion3[2] = TextBoxCredito3.Texts; //Credito Prestado
            Informacion3[3] = TextBoxPagare3.Texts; //Pagare generado
            Informacion3[4] = TextBoxCalle3.Texts; //Calle
            Informacion3[5] = TextBoxColonia3.Texts; //Colonia
            Informacion3[6] = TextBoxNumInt3.Texts; //Numero de casa interior
            Informacion3[7] = TextBoxNumExt3.Texts; //Numero de casa exterior
            Informacion3[8] = TextBoxTelefono3.Texts; //Telefono
            Informacion3[9] = TextBoxCorreo3.Texts; //Correo
            Informacion3[0] = ComboBoxPromotor3.SelectedItem.ToString(); //Promotor que lo atiende
            Informacion3[11] = ResolucionDemanda.SelectedItem.ToString(); //Resolucion de la demanda
            Informacion3[12] = TextImporte3.Texts; //Importe
            Informacion3[10] = ComboBoxResolucion3.SelectedItem.ToString(); //Resolucion
            Informacion3[13] = Cliente;
            bool es = a.EditarLista3(Informacion3);
            if (es)
            {
                EsconderPaneles(pnlListas);
                btnLista3.PerformClick(); //Reactualizo los datos de la lista 3
            }
            else
            {
                MessageB("Error al editar", "Alerta", 2); ;
            }
        }

        private void btnMover2_Click(object sender, EventArgs e)
        {
            Revision_Mover_Liquidados obj = new();
            obj.ShowDialog();
            if (obj.MoverLiq)
            {
                string[] Mov4 = new string[12];
                Mov4[0] = informacion3[0]; //Promotor
                Mov4[1] = informacion3[1]; //Nombre
                Mov4[2] = informacion3[2]; //Credito
                Mov4[3] = "-";//Fecha de Inicio
                Mov4[4] = informacion3[4];//Calle
                Mov4[5] = informacion3[5];//Colonia
                Mov4[6] = informacion3[6];//NumInt
                Mov4[7] = informacion3[7];//NumExt
                Mov4[8] = informacion3[8];//Telefono
                Mov4[9] = informacion3[9];//Correo
                Mov4[10] = "Lista 3";
                Lectura_Base_Datos Instancia2 = new();
                bool av2 = Instancia2.InsertarLiquidados(Mov4);
                if (av2)
                {
                    Instancia2.Erase(Cliente, "lista3");//Lo borro de la lista 3
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

        private void PanelEditar3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMover3_Click(object sender, EventArgs e)
        {
            switch (CmbLista2.SelectedIndex)
            {
                case 0://Mover a lista 3
                    PedirDatos3 a = new();
                    a.ShowDialog();
                    if (a.Mover3)
                    {
                        string[] Move3 = new string[14];
                        Move3[0] = Informacion2[0]; //Promotor
                        Move3[1] = Informacion2[1]; //Nombre
                        Move3[2] = Informacion2[2]; //Credito
                        Move3[3] = Informacion2[4];//Pagare
                        Move3[4] = Informacion2[5];//Calle
                        Move3[5] = Informacion2[6];//Colonia
                        Move3[6] = Informacion2[7];//NumInt
                        Move3[7] = Informacion2[8];//NumExt
                        Move3[8] = Informacion2[9];//Telefono
                        Move3[9] = Informacion2[10];//Correo
                        Move3[10] = a.ComboBoxResolucion3.SelectedItem.ToString();//Resolucion
                        Move3[11] = a.ComboBoxResolucionD.SelectedItem.ToString();//Resolucion Demanda Embargo o en Tramite
                        Move3[12] = a.TextImporte3.Texts;//Importe
                        Lectura_Base_Datos Instancia = new();

                        bool av = Instancia.InsertarLista3(Move3);
                        if (av)
                        {
                            Instancia.Erase(Cliente, "lista2");//Lo borro de la lista 2
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
                        string[] Mov4 = new string[12];
                        Mov4[0] = Informacion2[0]; //Promotor
                        Mov4[1] = Informacion2[1]; //Nombre
                        Mov4[2] = Informacion2[2]; //Credito
                        Mov4[3] = "-";//Fecha de Inicio
                        Mov4[4] = Informacion2[5];//Calle
                        Mov4[5] = Informacion2[6];//Colonia
                        Mov4[6] = Informacion2[7];//NumInt
                        Mov4[7] = Informacion2[8];//NumExt
                        Mov4[8] = Informacion2[9];//Telefono
                        Mov4[9] = Informacion2[10];//Correo
                        Mov4[10] = "Lista 2";
                        Lectura_Base_Datos Instancia2 = new();
                        bool av2 = Instancia2.InsertarLiquidados(Mov4);
                        if (av2)
                        {
                            Instancia2.Erase(Cliente, "lista2");//Lo borro de la lista 2
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
            int a = 1;
            //acomodamos el combobox de Fechas para agregar las fechas que se necesiten
            ComboBoxDeFechas.Items.Clear();
            string[] Info = instancia.LectName2(Cliente);
            for (int i = 14; i < 42; i += 2)
            {
                if (Info[i] == "-")
                {
                    ComboBoxDeFechas.Items.Add("Fecha " + a);

                }
                else
                {
                    ComboBoxDeFechas.Items.Add("Fecha " + a + "-Pagado");
                }

                if (i % 2 == 0)
                {
                    a++;
                }
            }
        }

        private void btnGuardarC_Click(object sender, EventArgs e)
        {
            if (Mover)
            {
                string[] Mov5 = new string[12];
                Mov5[0] = Informacion2[0]; //Promotor que lo atiende
                Mov5[1] = Informacion2[1]; //Nombre del registro
                Mov5[2] = Informacion2[2]; //Credito Prestado
                Mov5[3] = "-";//Fecha de inicio
                Mov5[4] = Informacion2[5];//Calle
                Mov5[5] = Informacion2[6];//Colonia
                Mov5[6] = Informacion2[7];//Numero de casa interior
                Mov5[7] = Informacion2[8];//Numero de casa exterior
                Mov5[8] = Informacion2[9];//Telefono
                Mov5[9] = Informacion2[10];//Correo
                Mov5[10] = "Lista 2";
                Lectura_Base_Datos instancia5 = new();
                bool rev5 = instancia5.InsertarLiquidados(Mov5);
                if (rev5)
                {
                    instancia5.Erase(Mov5[1], "lista2"); //Eliminamos el registro 
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

                Ediciones e2 = new();
                string[] InfoListaNueva2 = Informacion2;
                InfoListaNueva2[0] = rjComboBox8.SelectedItem.ToString(); //Promotor que lo atiende
                InfoListaNueva2[1] = TextBoxNombre.Texts; //Nombre del registro
                InfoListaNueva2[2] = TextBoxCredito.Texts; //Credito Prestado
                InfoListaNueva2[3] = TextBoxRestante.Texts; //Monto Restante
                InfoListaNueva2[4] = TextBoxPagare.Texts; //Pagare generado
                InfoListaNueva2[5] = TextBoxCalle.Texts; //Calle
                InfoListaNueva2[6] = TextBoxColonia.Texts; //Colonia
                InfoListaNueva2[7] = TextBoxNumInt.Texts; //Numero de casa interior
                InfoListaNueva2[8] = TextBoxNumExt.Texts; //Numero de casa exterior
                InfoListaNueva2[9] = TextBoxTelefono.Texts; //Telefono
                InfoListaNueva2[10] = TextBoxCorreo.Texts; //Correo
                InfoListaNueva2[11] = rjComboBox7.SelectedItem.ToString(); //Liquidacion o Intencion
                InfoListaNueva2[12] = TextBoxLiquidacionIntencion.Texts; //Monto de liquidacion o intencion
                InfoListaNueva2[13] = TextBoxQuita.Texts; //Monto de Quita
                InfoListaNueva2[43] = Cliente; //Nombre del que va a editar
                bool a = e2.EditarLista2(InfoListaNueva2);
                if (a)
                {
                    EsconderPaneles(pnlListas);
                    btnLista2.PerformClick(); //Reactualizo los datos de la lista 2

                }
                else
                {
                    MessageB("Error al guardar los cambios", "Advertencia", 2);
                }
            }
        }
        private double restante_original = 0;
        private int index_fecha = 0;
        private bool revertir;
        private bool unclick = true;
        private void Botoncambiodefechamomentaneo_Click_1(object sender, EventArgs e)
        {
            if (revertir)
            {
                unclick = true;
            }

            int indice = 0;
            if (unclick)
            {
                unclick = false;

                string fecha = FechaEnLista2.Value.ToString("dd/MM/yyyy");
                string pago = TextBoxPago.Texts;
                restante_original = Convert.ToDouble(Informacion2[42]);
                if (Convert.ToDouble(pago) > Convert.ToDouble(Informacion2[42]))
                {
                    MessageB("El pago no puede ser mayor al monto restante", "Advertencia", 2);
                }
                else
                {
                    indice = 14 + (ComboBoxDeFechas.SelectedIndex * 2);
                    index_fecha = indice;
                    Informacion2[indice] = fecha;
                    Informacion2[indice + 1] = pago;
                    double resta = Convert.ToDouble(Informacion2[42]) - Convert.ToDouble(pago);
                    Informacion2[42] = resta.ToString();
                    TextBoxPagoExt.Texts = Informacion2[42];
                    if (TextBoxPagoExt.Texts == "0")
                    {
                        Mover = true;
                    }
                    else
                    {
                        Mover = false;
                    }
                }
                rjButton7.Enabled = true;
            }
            else
            {

            }
        }

        private void BotonVolverEditar2_Click_1(object sender, EventArgs e)
        {
            Botoncambiodefechamomentaneo.Enabled = false;
            FechaEnLista2.Enabled = false;
            EsconderPaneles(PnlEditar2);
        }

        private void BottonLiq_Click_1(object sender, EventArgs e)
        {
            Ediciones e2 = new();
            string[] Informacion4 = informacion4;
            Informacion4[1] = TextNombreLiq.Texts; //Nombre del registro
            Informacion4[2] = TextCreditoLiq.Texts; //Credito Prestado
            Informacion4[3] = FechaInicioLiq.Value.ToString("dd/MM/yyyy"); //Fecha de inicio
            Informacion4[0] = ComboBoxPromotorLiq.SelectedItem.ToString(); //Promotor que lo atiende
            Informacion4[10] = ComBoBoxLiquidacion.SelectedItem.ToString(); //De que lista viene
            Informacion4[4] = TextCalleLiq.Texts; //Calle
            Informacion4[5] = TextColoniaLiq.Texts; //Colonia
            Informacion4[6] = TextNumIntLiq.Texts; //Numero de casa interior
            Informacion4[7] = TextNumExtLiq.Texts; //Numero de casa exterior
            Informacion4[8] = TextTelefonoLiq.Texts; //Telefono
            Informacion4[9] = TextCorreoLiq.Texts; //Correo
            Informacion4[11] = Cliente;
            bool saber2 = e2.EditarListaLiquidados(Informacion4);
            if (saber2)
            {
                EsconderPaneles(pnlListas);
                btnLiquidados.PerformClick(); //Reactualizo los datos de la lista Liquidados
            }
            else
            {
                MessageB("Error al guardar los cambios", "Alerta", 2);
            }
        }

        private void PanelEditar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnMover_Click_1(object sender, EventArgs e)
        {
            switch (cmbLista.SelectedIndex)
            {
                case 0://Mover a lista 2
                    Pedir_Datos a = new();
                    a.ShowDialog();
                    if (a.Mover2)
                    {
                        //Para mover a lista 2 copio valores que tiene la lista 1 y agrego otros que el usuario debe agregar
                        string[] InfoMov = new string[43];
                        InfoMov[0] = informacion[0]; //Promotor que lo atiende
                        InfoMov[1] = informacion[1]; //Nombre del registro
                        InfoMov[2] = informacion[2]; //Credito Prestado
                        InfoMov[3] = informacion[15]; //Monto Restante
                        InfoMov[4] = informacion[3]; //Pagare generado
                        InfoMov[5] = informacion[8]; //calle
                        InfoMov[6] = informacion[9]; //colonia
                        InfoMov[7] = informacion[10]; //Numero de casa interior
                        InfoMov[8] = informacion[11]; //Numero de casa exterior
                        InfoMov[9] = informacion[12]; //Telefono
                        InfoMov[10] = informacion[13]; //Correo
                        InfoMov[11] = a.rjComboBox2.SelectedItem.ToString(); //Su forma de pago Liquidacion o Intencion
                        #region Calculos del Excel
                        if (a.rjComboBox2.SelectedItem.ToString() == "Liquidacion")
                        {

                            InfoMov[12] = a.TextLiquidacionPedir.Texts;//Monto de Liquidacion
                            int pag = int.Parse(InfoMov[4]);
                            int liquidacion = int.Parse(InfoMov[12]);
                            uint Quita = ((uint)Convert.ToUInt64(pag)) - ((uint)Convert.ToUInt64(liquidacion)); //en Uint para que no sea negativo jamas
                            InfoMov[13] = Quita.ToString();//Monto de Quita que es la diferencia entre el liquidacion y el pagare por haber seleccionado liquidacion
                            InfoMov[42] = liquidacion.ToString();//Monto de Extencion - Al pagare se le resta el pago de intencion
                        }
                        else
                        {
                            //Se toma encuenta 10% del Pagare y se le suma a su monto restante
                            int pag = int.Parse(InfoMov[4]);
                            double quita = (pag * .90);
                            InfoMov[12] = quita.ToString();//Monto de Intencion es el 10% del pagare
                            InfoMov[13] = "0";//Monto de Quita es 0 por ser de convenio
                            InfoMov[42] = quita.ToString();//Monto de Extencion - Al pagare se le resta el pago de intencion
                        }
                        //Lleno la parte de fechas con guiones
                        for (int i = 14; i <= 41; i++)
                        {
                            InfoMov[i] = "-";
                        }
                        #endregion
                        Lectura_Base_Datos instancia = new();
                        bool rev = instancia.InsertarLista2(InfoMov);

                        if (rev)
                        {
                            //Borro el registro de la lista 1 porque si se movio al 2
                            instancia.Erase(InfoMov[1], "lista1");
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
                        string[] InfoMov3 = new string[14];
                        InfoMov3[0] = informacion[0]; //Promotor que lo atiende
                        InfoMov3[1] = informacion[1]; //Nombre del registro
                        InfoMov3[2] = informacion[2]; //Credito Prestado
                        InfoMov3[3] = informacion[3]; //Pagare generado
                        InfoMov3[4] = informacion[8]; //calle
                        InfoMov3[5] = informacion[9]; //colonia
                        InfoMov3[6] = informacion[10]; //Numero de casa interior
                        InfoMov3[7] = informacion[11]; //Numero de casa exterior
                        InfoMov3[8] = informacion[12]; //Telefono
                        InfoMov3[9] = informacion[13]; //Correo
                        InfoMov3[10] = a1.ComboBoxResolucion3.SelectedItem.ToString(); //Su forma de pago Liquidacion o Convenio
                        InfoMov3[11] = a1.ComboBoxResolucionD.SelectedItem.ToString();//Monto de Liquidacion
                        InfoMov3[12] = a1.TextImporte3.Texts;//Monto de Quita
                        Lectura_Base_Datos instancia3 = new();
                        bool rev3 = instancia3.InsertarLista3(InfoMov3);
                        if (rev3)
                        {
                            instancia3.Erase(InfoMov3[1], "lista1");
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
                        string[] InfoMov4 = new string[12];
                        InfoMov4[0] = informacion[0]; //Promotor que lo atiende
                        InfoMov4[1] = informacion[1]; //Nombre del registro
                        InfoMov4[2] = informacion[2]; //Credito Prestado
                        InfoMov4[3] = informacion[4];//Fecha de inicio
                        InfoMov4[4] = informacion[8];//Calle
                        InfoMov4[5] = informacion[9];//Colonia
                        InfoMov4[6] = informacion[10];//Numero de casa interior
                        InfoMov4[7] = informacion[11];//Numero de casa exterior
                        InfoMov4[8] = informacion[12];//Telefono
                        InfoMov4[9] = informacion[13];//Correo
                        InfoMov4[10] = "Lista 1";
                        Lectura_Base_Datos instancia4 = new();
                        bool rev4 = instancia4.InsertarLiquidados(InfoMov4);
                        if (rev4)
                        {
                            instancia4.Erase(InfoMov4[1], "lista1");
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
            Ediciones e1 = new();
            string[] Informacion = informacion; //Asigno los valores leidos anteriormente al nuevo string por si no hya cambios
            Informacion[0] = rjComboBox3.SelectedItem.ToString(); //Promotor que lo atiende
            Informacion[1] = textBoxPersonalizado10.Texts;
            Informacion[2] = textBoxPersonalizado9.Texts; //Credito Prestado
            Informacion[3] = textBoxPersonalizado11.Texts; //Pagare generado
            Informacion[4] = dateTimePickerPersonalizado1.Value.ToString("dd/MM/yyyy"); //Fecha de Inicio
            Informacion[5] = dateTimeLimite.Value.ToString("dd/MM/yyyy");//Fecha de su ultimo pago (Limite)
            Informacion[6] = rjComboBox1.SelectedItem.ToString(); //Interes Que tiene
            Informacion[7] = textBoxPersonalizado8.Texts; //Monto Total del prestamo + intereses
            Informacion[8] = textBoxPersonalizado6.Texts; //Calle
            Informacion[9] = textBoxPersonalizado5.Texts; //ColoniaIndex was outside the 
            Informacion[10] = textBoxPersonalizado4.Texts; //Numero de casa interior
            Informacion[11] = textBoxPersonalizado3.Texts;//Numero de casa exterior
            Informacion[12] = textBoxPersonalizado2.Texts;//Telefono
            Informacion[13] = textBoxPersonalizado1.Texts;//Correo
            Informacion[14] = rjComboBox2.SelectedItem.ToString(); //Su forma de pago quincenales o semanales
            Informacion[15] = textBoxPersonalizado7.Texts; //Monto Restante
            Informacion[30] = Cliente;
            if (Informacion[14] != TipoPago)
            {
                switch (rjComboBox2.SelectedItem.ToString())
                {
                    case "Semanales":
                        string[] fechSem = new string[30];

                        fechSem = SumarSemanas(Informacion[4]);
                        for (int i = 16; i <= 29; i++)
                        {
                            Informacion[i] = fechSem[i - 16];
                        }

                        break;
                    case "Quincenales":
                        string[] fechQuin = new string[30];
                        fechQuin = SumarQuincenas(Informacion[4]);
                        for (int i = 16; i <= 29; i++)
                        {
                            if (i >= 23)
                            {
                                Informacion[i] = "-";
                            }
                            else
                            {
                                Informacion[i] = fechQuin[i - 16];
                            }
                        }

                        break;
                }
            }
            bool revisar = e1.EditarLista1(Informacion);
            if (revisar)
            {
                EsconderPaneles(pnlListas);
                btnLista1.PerformClick(); //Reactualizo los datos de la lista 1
            }
            else
            {
                MessageB("Error al guardar los cambios", "Alerta", 2);
            }
        }
        public static string[] SumarSemanas(string fechaInicial)
        {
            DateTime fecha = DateTime.ParseExact(fechaInicial, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string[] fechasSumadas = new string[14];

            for (int i = 0; i < 14; i++)
            {
                fecha = fecha.AddDays(7);
                fechasSumadas[i] = fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

            return fechasSumadas;
        }
        public static string[] SumarQuincenas(string fechaInicial)
        {
            DateTime fecha = DateTime.ParseExact(fechaInicial, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string[] fechasSumadas = new string[7];

            for (int i = 0; i < 7; i++)
            {
                fecha = fecha.AddDays(15);
                fechasSumadas[i] = fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
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

        private void TextBoxNumExt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void TextBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
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
            TextBoxPagoExt.Texts = restante_original.ToString();
            TextBoxPago.Texts = "";
            Informacion2[index_fecha] = "";
            Informacion2[index_fecha + 1] = "";
            Informacion2[42] = restante_original.ToString();
            revertir = true;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BackupService ob = new();
            ob.StopBackup();
        }
        private bool changingCheckedState5 = false;
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
    }
}