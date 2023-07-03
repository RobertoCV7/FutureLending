using System;
using System.ComponentModel;
using System.Globalization;
using FutureLending.ControlesPersonalizados;
using FutureLending.Funciones.cs;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Button = System.Windows.Forms.Button;
using Timer = System.Windows.Forms.Timer;

namespace FutureLending.Forms
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
            PingLabel.Hide();

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
            Task.Run(() =>
            {
                // Actualizar los controles de la interfaz de usuario desde el hilo de UI
                this.Invoke(() =>
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
                });
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
                    menuButton.Text = @"   " + menuButton.Tag;
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
        public static double DineroAire;
        #region Botones centrales del menu

        #region Ingresar Clientes
        private bool cambioEnPromotores = true;
        private void BtnIngresarClientes_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            EsconderPaneles(pnlClientes);
            lblTitle.Text = @"Ingresar Clientes";
            if (cambioEnPromotores)
            {
                CargarPromotoresEnComboBox(cmbPromotor, false);
                cambioEnPromotores = false;
            }
            if (panelRg)
            {
                RecargarDatosPnllRegPagos();
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
        bool revisado;
        private bool cambioenPromotoresListas = true;
        private void BtnListas_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            if (cambioenPromotoresListas)
            {
                CargarPromotoresEnComboBox(ComboBoxPromotoresListas, true);
                cambioenPromotoresListas = false;
            }
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
            if (panelRg)
            {
                RecargarDatosPnllRegPagos();
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
                panelRg = true;
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
            if (ComboBoxPromotoresListas.SelectedIndex != -1 && ComboBoxPromotoresListas.SelectedIndex != 0)
            {
                LabelDineroAire.Text = "";
                DineroAire = 0;
                listaEstado = 0;
                DesactivarBotones();
                Lectura_Base_Datos ar = new();
                List<string[]> datos = ar.LectLista1Prom(ComboBoxPromotoresListas.SelectedItem.ToString());
                await TablaClientes.MostrarLista1Prom(gridListas, cmbCliente, BarradeProgreso, label57, datos);
                LabelDineroAire.Text = ComboBoxPromotoresListas.SelectedItem + @" tiene $" + DineroAire.ToString("N2") + @" en Pagos pendientes";
                btnLista1.Enabled = true;
                btnLista2.Enabled = true;
                ActivarEditar();
                listaActual = "lista1";
            }
            else
            {
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
            if (ComboBoxPromotoresListas.SelectedIndex != -1 && ComboBoxPromotoresListas.SelectedIndex != 0)
            {
                LabelDineroAire.Text = "";
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
            listaEstado = 2;
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
        public string[] Informacion2 = new string[44]; //Se usa para guardar la info de la lista 2
        public string[] Informacion3 = new string[15];//Se usa para guardar la info de la lista 3
        public string[] Informacion4 = new string[12];//Se usa para guardar la info de liquidados
        public string Pertenece; //De que lista viene
        public string Cliente; //Nombre del cliente
        private string tipoPago; //Tipo de pago 
        private string[] temporal = new string[31];
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Lecturas_Especificas lecturasEspecificas = new();
            if (listaEstado == 0) //Si viene de la lista 1
            {
                //Cargar los promotores en el ComboBox
                CargarPromotoresEnComboBox(rjComboBox3, false);
                //Muestro el panel de editar
                EsconderPaneles(PanelEditar);
                //Limpio las listas donde es posible  mover al registro
                cmbLista.Items.Clear();
                cmbLista.Enabled = true;
                cmbLista.Items.AddRange(new object[] { "Lista 2", "Lista 3", "Liquidados" });
                //Establezco de donde viene este registro
                Pertenece = "Lista 1";
                LblPerte.Text = Pertenece;
                //Obtengo el nombre del cliente
                Cliente = cmbCliente.Texts;
                //Empieza leyendo su informacion de la base de datos
                Informacion = lecturasEspecificas.LectName(Cliente);
                temporal = lecturasEspecificas.LectName(Cliente);
                //Tuve que convertir de List<string[]> a string[] para poder usarlo en los objetos del Panel (Editar)
                textBoxPersonalizado10.Texts = Cliente;
                textBoxPersonalizado9.Texts = Informacion[2]; //Credito Prestado
                textBoxPersonalizado11.Texts = Informacion[3]; //Pagare generado
                dateTimePickerPersonalizado1.Value = DateTime.Parse(Informacion[4]); //Fecha de Inicio
                dateTimeLimite.Value = DateTime.Parse(Informacion[5]);//Fecha de su ultimo pago (Limite)
                rjComboBox1.SelectedItem = Informacion[6]; //Interes Que tiene
                textBoxPersonalizado8.Texts = Informacion[7]; //Monto Total del prestamo + intereses
                rjComboBox2.SelectedItem = Informacion[14]; //Su forma de pago quincenales o semanales
                tipoPago = Informacion[14];
                rjComboBox3.SelectedItem = Informacion[0]; //Promotor que lo atiende
                textBoxPersonalizado7.Texts = Informacion[15]; //Monto Restante
                textBoxPersonalizado6.Texts = Informacion[8]; //Calle
                textBoxPersonalizado5.Texts = Informacion[9]; //Colonia
                textBoxPersonalizado4.Texts = Informacion[10]; //Numero de casa interior
                textBoxPersonalizado3.Texts = Informacion[11];//Numero de casa exterior
                textBoxPersonalizado2.Texts = Informacion[12];//Telefono
                textBoxPersonalizado1.Texts = Informacion[13];//Correo
                //Del 16 al 29 son los datos de las 14 fechas que solo ocupan 7 si sus pagos con quincenales
            }
            else if (listaEstado == 1) //Si viene de la lista 2
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
                CmbLista2.Items.AddRange(new object[] { "Lista 3", "Liquidados" });
                //Nombre del registro
                Cliente = cmbCliente.Texts;
                //activar boton de fechas
                btnEditarFechas2.Enabled = true;
                //Ahora de donde viene este registro
                Pertenece = "Lista 2";
                LabelPertenece.Text = Pertenece;
                //Leo la informacion de ese registro en especifico
                Informacion2 = lecturasEspecificas.LectName2(Cliente);
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
            else if (listaEstado == 2) //Si viene de la lista 3
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
                rjComboBox5.Items.AddRange(new object[] { "Liquidados" });
                //Nombre del registro
                Cliente = cmbCliente.Texts;
                //Leer la info
                Informacion3 = lecturasEspecificas.LectName3(Cliente); //tamaño 14
                //Empiezo a llenar los objetos del panel editar3
                TextBoxNombre3.Texts = Cliente; //Nombre del registro
                TextBoxCredito3.Texts = Informacion3[2]; //Credito Prestado
                TextBoxPagare3.Texts = Informacion3[3]; //Pagare generado
                TextBoxCalle3.Texts = Informacion3[4]; //Calle
                TextBoxColonia3.Texts = Informacion3[5]; //Colonia
                TextBoxNumInt3.Texts = Informacion3[6]; //Numero de casa interior
                TextBoxNumExt3.Texts = Informacion3[7]; //Numero de casa exterior
                TextBoxTelefono3.Texts = Informacion3[8]; //Telefono
                TextBoxCorreo3.Texts = Informacion3[9]; //Correo
                ComboBoxPromotor3.SelectedItem = Informacion3[0]; //Promotor que lo atiende
                ResolucionDemanda.SelectedItem = Informacion3[11]; //Resolucion de la demanda
                TextImporte3.Texts = Informacion3[12]; //Importe
                ComboBoxResolucion3.SelectedItem = Informacion3[10]; //Resolucion
            }
            else if (listaEstado == 3)//Si viene de liquidados
            {
                //Cargo lo promotres en el combobox de liquidados
                CargarPromotoresEnComboBox(ComboBoxPromotorLiq, false);
                //Traigo el panel editar de liquidados
                EsconderPaneles(PanelEditarLiquidados);
                //Nombre del registro
                Cliente = cmbCliente.Texts;
                //Obtenemos la informacion de ese registro en especifico
                Informacion4 = lecturasEspecificas.LectName4(Cliente); //tamaño 12
                //Rellenamos los objetos del panel editar liquidados
                TextNombreLiq.Texts = Cliente; //Nombre del registro
                TextCreditoLiq.Texts = Informacion4[2]; //Credito Prestado
                FechaInicioLiq.Value = DateTime.Parse(Informacion4[3]); //Fecha de inicio
                ComboBoxPromotorLiq.SelectedItem = Informacion4[0]; //Promotor que lo atiende
                ComBoBoxLiquidacion.SelectedItem = Informacion4[10]; //De que lista viene


                TextCalleLiq.Texts = Informacion4[4]; //Calle
                TextColoniaLiq.Texts = Informacion4[5]; //Colonia
                TextNumIntLiq.Texts = Informacion4[6]; //Numero de casa interior
                TextNumExtLiq.Texts = Informacion4[7]; //Numero de casa exterior
                TextTelefonoLiq.Texts = Informacion4[8]; //Telefono
                TextCorreoLiq.Texts = Informacion4[9]; //Correo
            }
        }

        #region Lista1

        #endregion
        #region Lista2 
        //Seguir editando lista 2 pero las fechas y pagos
        //presionado boton guardar el pago y la asignacion de fecha en la lista 2 ademas de actualizar el Pago EXT
        bool mover;

        //Si selecciona una fecha de lista 2 se muestra en el datetimepicker
        private void ComboBoxDeFechas_OnSelectedIndexChanged(object sender, EventArgs e)
        {
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

                    if (Informacion2[apuntador] == "-" || Informacion2[apuntador] == "")
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

                    if (Informacion2[apuntador] == "-" || Informacion2[apuntador] == "")
                    {
                        FechaEnLista2.Value = DateTime.Today;
                    }
                    else
                    {
                        FechaEnLista2.Value = DateTime.Parse(Informacion2[apuntador]);
                    }

                }

            }

            if (ComboBoxDeFechas.SelectedItem.ToString().Contains("Pagado"))
            {
                ComboBoxDeFechas.SelectedIndex = -1;
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
        }



        #endregion
        #region Configuracion

        private void IconButton1_Click(object sender, EventArgs e)
        {
            Boton_Permisos.Enabled = false;
            CargarPromotoresEnComboBox(rjComboBox4, false);

            lblTitle.Text = @"Configuracion";
            EsconderPaneles(panel2);
            _ = new Accesos();
            object[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
            if (panelRg)
            {
                RecargarDatosPnllRegPagos();
            }
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

        private static readonly Lectura_Base_Datos Lec = new();
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
            EditarPromotor(rjComboBox4.SelectedItem.ToString(), textBox4.Text);
            cambioEnPromotores = true;
            cambioenPromotoresListas = true;
            textBox4.Text = "";
            rjComboBox4.SelectedIndex = -1;
            CargarPromotoresEnComboBox(rjComboBox4, false);
        }
        private void RjButton6_Click(object sender, EventArgs e)
        {
            EliminarPromotor(rjComboBox4.SelectedItem.ToString());
            cambioEnPromotores = true;
            cambioenPromotoresListas = true;
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
            cambioEnPromotores = true;
            cambioenPromotoresListas = true;
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

            _ = new Accesos();
            object[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }

        private void rjButton11_Click(object sender, EventArgs e)
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

        private void rjButton12_Click(object sender, EventArgs e)
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
            DateTime dateTime = dateFechaInicio.Value;
            int multiplicador = cmbTipo.SelectedIndex == 0 ? 14 : 15;
            var fechaFinal = dateTime.AddDays(multiplicador * 7);
            dateTimePickerPersonalizado2.Value = fechaFinal;
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
            Lectura_Base_Datos obj = new();
            bool ar = Lectura_Base_Datos.VerificarUsuarioEnListas(txtNombre.Texts);
            if (ar)
            {
                string interes = cmbInteres.Texts;
                string montoTotal = txtTotal.Texts.Replace("$", "");
                double p = (credito2 * 2);
                obj.Create("lista1", cmbPromotor.Texts, txtNombre.Texts, txtCredito.Texts, p.ToString(CultureInfo.InvariantCulture), dateFechaInicio.Value, dateTimePickerPersonalizado2.Value, interes, montoTotal, txtCalle.Texts, txtColonia.Texts, txtNumInt.Texts, txtNumExt.Texts, txtTelefono.Texts, txtCorreo.Texts, cmbTipo.SelectedItem.ToString(), montoTotal);
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
                MessageB("El cliente ya existe en la Base de datos ", "Error", 3);
            }
        }
        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            Ediciones ediciones = new();
            string[] strings = this.Informacion3;
            strings[1] = TextBoxNombre3.Texts; //Nombre del registro
            strings[2] = TextBoxCredito3.Texts; //Credito Prestado
            strings[3] = TextBoxPagare3.Texts; //Pagare generado
            strings[4] = TextBoxCalle3.Texts; //Calle
            strings[5] = TextBoxColonia3.Texts; //Colonia
            strings[6] = TextBoxNumInt3.Texts; //Numero de casa interior
            strings[7] = TextBoxNumExt3.Texts; //Numero de casa exterior
            strings[8] = TextBoxTelefono3.Texts; //Telefono
            strings[9] = TextBoxCorreo3.Texts; //Correo
            strings[0] = ComboBoxPromotor3.SelectedItem.ToString(); //Promotor que lo atiende
            strings[11] = ResolucionDemanda.SelectedItem.ToString(); //Resolucion de la demanda
            strings[12] = TextImporte3.Texts; //Importe
            strings[10] = ComboBoxResolucion3.SelectedItem.ToString(); //Resolucion
            strings[13] = Cliente;
            bool es = ediciones.EditarLista3(strings);
            if (es)
            {
                EsconderPaneles(pnlListas);
                btnLista3.PerformClick(); //Reactualizo los datos de la lista 3
            }
            else
            {
                MessageB("Error al editar", "Alerta", 2);
            }
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

        private void PanelEditar3_Paint(object sender, PaintEventArgs e)
        {

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
            string[] info = instancia.LectName2(Cliente);
            for (int i = 14; i < 42; i += 2)
            {
                if (info[i] == "-")
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

        private void btnGuardarC_Click(object sender, EventArgs e)
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

                Ediciones e2 = new();
                string[] infoListaNueva2 = Informacion2;
                infoListaNueva2[0] = rjComboBox8.SelectedItem.ToString(); //Promotor que lo atiende
                infoListaNueva2[1] = TextBoxNombre.Texts; //Nombre del registro
                infoListaNueva2[2] = TextBoxCredito.Texts; //Credito Prestado
                infoListaNueva2[3] = TextBoxRestante.Texts; //Monto Restante
                infoListaNueva2[4] = TextBoxPagare.Texts; //Pagare generado
                infoListaNueva2[5] = TextBoxCalle.Texts; //Calle
                infoListaNueva2[6] = TextBoxColonia.Texts; //Colonia
                infoListaNueva2[7] = TextBoxNumInt.Texts; //Numero de casa interior
                infoListaNueva2[8] = TextBoxNumExt.Texts; //Numero de casa exterior
                infoListaNueva2[9] = TextBoxTelefono.Texts; //Telefono
                infoListaNueva2[10] = TextBoxCorreo.Texts; //Correo
                infoListaNueva2[11] = rjComboBox7.SelectedItem.ToString(); //Liquidacion o Intencion
                infoListaNueva2[12] = TextBoxLiquidacionIntencion.Texts; //Monto de liquidacion o intencion
                infoListaNueva2[13] = TextBoxQuita.Texts; //Monto de Quita
                infoListaNueva2[43] = Cliente; //Nombre del que va a editar
                bool editarLista2 = e2.EditarLista2(infoListaNueva2);
                if (editarLista2)
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
        private double restanteOriginal;
        private int indexFecha;
        private bool revertir;
        private bool unclick = true;
        private void Botoncambiodefechamomentaneo_Click_1(object sender, EventArgs e)
        {
            if (revertir)
            {
                unclick = true;
            }

            int indice;
            if (unclick)
            {
                unclick = false;

                string fecha = FechaEnLista2.Value.ToString("dd/MM/yyyy");
                string pago = TextBoxPago.Texts;
                restanteOriginal = Convert.ToDouble(Informacion2[42]);
                if (Convert.ToDouble(pago) > Convert.ToDouble(Informacion2[42]))
                {
                    MessageB("El pago no puede ser mayor al monto restante", "Advertencia", 2);
                }
                else
                {
                    indice = 14 + (ComboBoxDeFechas.SelectedIndex * 2);
                    indexFecha = indice;
                    Informacion2[indice] = fecha;
                    Informacion2[indice + 1] = pago;
                    double resta = Convert.ToDouble(Informacion2[42]) - Convert.ToDouble(pago);
                    Informacion2[42] = resta.ToString(CultureInfo.InvariantCulture);
                    TextBoxPagoExt.Texts = Informacion2[42];
                    if (TextBoxPagoExt.Texts == "0")
                    {
                        mover = true;
                    }
                    else
                    {
                        mover = false;
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
            string[] informacion4 = this.Informacion4;
            informacion4[1] = TextNombreLiq.Texts; //Nombre del registro
            informacion4[2] = TextCreditoLiq.Texts; //Credito Prestado
            informacion4[3] = FechaInicioLiq.Value.ToString("dd/MM/yyyy"); //Fecha de inicio
            informacion4[0] = ComboBoxPromotorLiq.SelectedItem.ToString(); //Promotor que lo atiende
            informacion4[10] = ComBoBoxLiquidacion.SelectedItem.ToString(); //De que lista viene
            informacion4[4] = TextCalleLiq.Texts; //Calle
            informacion4[5] = TextColoniaLiq.Texts; //Colonia
            informacion4[6] = TextNumIntLiq.Texts; //Numero de casa interior
            informacion4[7] = TextNumExtLiq.Texts; //Numero de casa exterior
            informacion4[8] = TextTelefonoLiq.Texts; //Telefono
            informacion4[9] = TextCorreoLiq.Texts; //Correo
            informacion4[11] = Cliente;
            bool saber2 = e2.EditarListaLiquidados(informacion4);
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
                    Pedir_Datos pedirDatos = new();
                    pedirDatos.ShowDialog();
                    if (pedirDatos.Mover2)
                    {
                        //Para mover a lista 2 copio valores que tiene la lista 1 y agrego otros que el usuario debe agregar
                        string[] infoMov = new string[43];
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
                        #region Calculos del Excel
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
                            double quita = (pag * .90);
                            infoMov[12] = quita.ToString(CultureInfo.InvariantCulture);//Monto de Intencion es el 10% del pagare
                            infoMov[13] = "0";//Monto de Quita es 0 por ser de convenio
                            infoMov[42] = quita.ToString(CultureInfo.InvariantCulture);//Monto de Extencion - Al pagare se le resta el pago de intencion
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
            Ediciones e1 = new();
            string[] informacion = this.Informacion; //Asigno los valores leidos anteriormente al nuevo string por si no hya cambios
            informacion[0] = rjComboBox3.SelectedItem.ToString(); //Promotor que lo atiende
            informacion[1] = textBoxPersonalizado10.Texts;
            informacion[2] = textBoxPersonalizado9.Texts; //Credito Prestado
            informacion[3] = textBoxPersonalizado11.Texts; //Pagare generado
            informacion[4] = dateTimePickerPersonalizado1.Value.ToString("dd/MM/yyyy"); //Fecha de Inicio
            informacion[5] = dateTimeLimite.Value.ToString("dd/MM/yyyy");//Fecha de su ultimo pago (Limite)
            informacion[6] = rjComboBox1.SelectedItem.ToString(); //Interes Que tiene
            informacion[7] = textBoxPersonalizado8.Texts; //Monto Total del prestamo + intereses
            informacion[8] = textBoxPersonalizado6.Texts; //Calle
            informacion[9] = textBoxPersonalizado5.Texts; //ColoniaIndex was outside the 
            informacion[10] = textBoxPersonalizado4.Texts; //Numero de casa interior
            informacion[11] = textBoxPersonalizado3.Texts;//Numero de casa exterior
            informacion[12] = textBoxPersonalizado2.Texts;//Telefono
            informacion[13] = textBoxPersonalizado1.Texts;//Correo
            informacion[14] = rjComboBox2.SelectedItem.ToString(); //Su forma de pago quincenales o semanales
            informacion[15] = textBoxPersonalizado7.Texts; //Monto Restante
            informacion[30] = Cliente;
            if (informacion[14] != tipoPago || dateTimePickerPersonalizado1.Value.ToString("d") != temporal[4])
            {
                switch (rjComboBox2.SelectedItem)
                {
                    case "Semanales":
                        string[] fechSem;

                        fechSem = SumarSemanas(dateTimePickerPersonalizado1.Value.ToString("d"));
                        for (int i = 16; i <= 29; i++)
                        {
                            informacion[i] = fechSem[i - 16];
                        }

                        break;
                    case "Quincenales":
                        string[] fechQuin;
                        fechQuin = SumarQuincenas(dateTimePickerPersonalizado1.Value.ToString("d"));
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
            bool revisar = e1.EditarLista1(informacion);
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
            TextBoxPagoExt.Texts = restanteOriginal.ToString(CultureInfo.InvariantCulture);
            TextBoxPago.Texts = "";
            Informacion2[indexFecha] = "";
            Informacion2[indexFecha + 1] = "";
            Informacion2[42] = restanteOriginal.ToString(CultureInfo.InvariantCulture);
            revertir = true;

        }

        private bool changingCheckedState5;
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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }



        private void dateTimePickerPersonalizado1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = new();
            switch (rjComboBox2.SelectedItem)
            {
                case "Semanales":
                    dateTime = dateTimePickerPersonalizado1.Value;
                    var fechaFinal = dateTime.AddDays(7 * 14);
                    dateTimeLimite.Value = Convert.ToDateTime(fechaFinal.ToString("d"));
                    break;
                case "Quincenales":
                    dateTime = dateTimePickerPersonalizado1.Value;
                    fechaFinal = dateTime.AddDays(15 * 7);
                    dateTimeLimite.Value = Convert.ToDateTime(fechaFinal.ToString("d"));
                    break;
            }


        }

        private void rjComboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePickerPersonalizado1_ValueChanged(null, null);
        }
    }
}