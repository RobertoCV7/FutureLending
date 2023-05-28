using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using FutureLending.ControlesPersonalizados;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Automation;
using System.Windows.Forms;

namespace FutureLending
{
    public partial class Form1 : Form
    {

        //Variable que se utiliza a la hora de borrar o editar un registro
        private string listaActual = "";

        public Form1()
        {
            InitializeComponent();
            CollapseMenu();
            CargarPromotoresEnComboBox(rjComboBox3);
            CargarPromotoresEnComboBox(cmbPromotor);
            dateTimePickerPersonalizado2.Enabled = false;
            rjButton6.Enabled = false;
            rjComboBox9.Visible = false;
            rjButton4.Enabled = false;
            label17.Visible = false;
            rjButton5.Enabled = false;
            cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComBoxName.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComBoxName.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            gridListas.VirtualMode = false;
            TablaClientes.AñadirEvento(gridListas);
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

        #region Botones centrales del menu

        #region Ingresar Clientes

        private void BtnIngresarClientes_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Ingresar Clientes";
            pnlClientes.BringToFront();
            CargarPromotoresEnComboBox(cmbPromotor);
            dateTimePickerPersonalizado2.Enabled = false;

        }
        Double credito2;
        private void BtnCalcular_Click(object sender, EventArgs e)
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
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos obj = new();
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
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
            btnGuardar.Enabled = VerificarLlenadoGuardar();
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
            btnCalcular.Enabled = VerificarLlenadoCalcular();
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
            else { btnMarcarP.Enabled = true; }
        }
        #endregion

        #region Listas
        private void BtnListas_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Listas Completas";
            pnlListas.BringToFront();
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
            ListaEstado = 0;
            DesactivarBotones();

            await TablaClientes.MostrarLista1(gridListas, cmbCliente);

            ActivarListas();
            ActivarEditar();
            listaActual = "lista1";
        }

        private async void BtnLista2_Click(object sender, EventArgs e)
        {
            ListaEstado = 1;
            DesactivarBotones();

            await TablaClientes.MostrarLista2(gridListas, cmbCliente);

            ActivarListas();
            ActivarEditar();
            listaActual = "lista2";
        }

        private async void BtnLista3_Click(object sender, EventArgs e)
        {
            ListaEstado = 2;
            DesactivarBotones();

            await TablaClientes.MostrarLista3(gridListas, cmbCliente);

            ActivarListas();
            ActivarEditar();
            listaActual = "lista3";
        }

        private async void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            DesactivarBotones();

            await TablaClientes.MostrarTodos(gridListas, cmbCliente);

            ActivarListas();
        }

        private async void BtnLiquidados_Click(object sender, EventArgs e)
        {
            ListaEstado = 3;
            var mostrarListaTask = TablaClientes.MostrarLiquidados(gridListas, cmbCliente);
            while (!mostrarListaTask.IsCompleted)
            {
                DesactivarBotones();
                await Task.Delay(100);
            }
            ActivarListas();
            ActivarEditar();
            listaActual = "liquidados";
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
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Lecturas_Especificas a = new();
            if (ListaEstado == 0) //Si viene de la lista 1
            {
                //Cargar los promotores en el ComboBox
                CargarPromotoresEnComboBox(rjComboBox3);
                //Muestro el panel de editar
                PanelEditar.BringToFront();
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
                CargarPromotoresEnComboBox(rjComboBox8);
                //Llamo al panel editar de la lista 2
                PnlEditar2.BringToFront();
                //Lleno el rjcombobox de promotores con la info correspondiente
                CargarPromotoresEnComboBox(rjComboBox8);
                //Limpio las listas donde es posible  mover al registro
                CmbLista2.Items.Clear();
                CmbLista2.Enabled = true;
                CmbLista2.Items.AddRange(new string[] { "Lista 3", "Liquidados" });
                //Nombre del registro
                Cliente = cmbCliente.Texts;
                //activar boton de fechas
                BotonEditarFechas2.Enabled = true;
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
                CargarPromotoresEnComboBox(ComboBoxPromotor3);
                //Traer panel de edicion3
                PanelEditar3.BringToFront();
                //Llenar el rjcombobox de promotores con la info correspondiente
                CargarPromotoresEnComboBox(ComboBoxPromotor3);
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
                TextResolucionDemanda.Texts = informacion3[11]; //Resolucion de la demanda
                TextImporte3.Texts = informacion3[12]; //Importe
                ComboBoxResolucion3.SelectedItem = informacion3[10]; //Resolucion
            }
            else if (ListaEstado == 3)//Si viene de liquidados
            {
                //Cargo lo promotres en el combobox de liquidados
                CargarPromotoresEnComboBox(ComboBoxPromotorLiq);
                //Traigo el panel editar de liquidados
                PanelEditarLiquidados.BringToFront();
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
            bool revisar = e1.EditarLista1(Informacion);
            if (revisar)
            {
                pnlListas.BringToFront();
                btnLista1.PerformClick(); //Reactualizo los datos de la lista 1
            }
            else
            {
                MessageBox.Show("Error al guardar los cambios");
            }
        }
        private void BtnMover_Click(object sender, EventArgs e) //boton para mover lista 1 a cualquier otra lista
        {
            switch (cmbLista.SelectedIndex)
            {
                case 0://Mover a lista 2
                    Pedir_Datos a = new();
                    a.ShowDialog();
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
                        InfoMov[42] = InfoMov[4];//Monto de Extencion - Al pagare se le resta el pago de intencion
                    }
                    else
                    {
                        //Se toma encuenta 10% del Pagare y se le suma a su monto restante
                        int pag = int.Parse(InfoMov[4]);
                        double quita = (pag * .10);
                        MessageBox.Show("" + quita + " 10% de pagare");
                        InfoMov[12] = quita.ToString();//Monto de Intencion es el 10% del pagare
                        InfoMov[13] = "0";//Monto de Quita es 0 por ser de convenio
                        double Ext = ((uint)Convert.ToUInt64(pag)) - ((uint)Convert.ToUInt64(pag)); //en Uint para que no sea negativo jamas 
                        InfoMov[42] = Ext.ToString();//Monto de Extencion - Al pagare se le resta el pago de intencion
                    }
                    #endregion
                    for (int i = 14; i < 42; i++)
                    {
                        InfoMov[i] = "-";
                    }

                    Lectura_Base_Datos instancia = new();
                    bool rev = instancia.InsertarLista2(InfoMov);

                    if (rev)
                    {
                        //Borro el registro de la lista 1 porque si se movio al 2
                        instancia.Erase(InfoMov[1], "lista1");
                        pnlListas.BringToFront();
                        btnLista2.PerformClick(); //Reactualizo los datos de la lista  2
                    }
                    else
                    {
                        MessageB("Error al mover el registro", "Aviso", 2);
                    }
                    break;
                case 1: //Para mover a lista 3
                    PedirDatos3 a1 = new();
                    string[] InfoMov3 = new string[13];
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
                        pnlListas.BringToFront();
                        btnLista3.PerformClick(); //Reactualizo los datos de la lista  3
                    }
                    else
                    {
                        MessageB("Error al mover el registro", "Aviso", 2);
                    }
                    break;
                case 2: //Para mover a liquidados
                    string[] InfoMov4 = new string[11];
                    InfoMov4[0] = informacion[0]; //Promotor que lo atiende
                    InfoMov4[1] = informacion[1]; //Nombre del registro
                    InfoMov4[2] = informacion[2]; //Credito Prestado
                    InfoMov4[4] = informacion[5];//Fecha de inicio
                    InfoMov4[5] = informacion[8];//Calle
                    InfoMov4[6] = informacion[9];//Colonia
                    InfoMov4[7] = informacion[10];//Numero de casa interior
                    InfoMov4[8] = informacion[11];//Numero de casa exterior
                    InfoMov4[9] = informacion[12];//Telefono
                    InfoMov4[10] = informacion[13];//Correo
                    InfoMov4[11] = "Lista 1";
                    Lectura_Base_Datos instancia4 = new();
                    bool rev4 = instancia4.InsertarLiquidados(InfoMov4);
                    if (rev4)
                    {
                        instancia4.Erase(InfoMov4[1], "lista1");
                        pnlListas.BringToFront();
                        btnLiquidados.PerformClick(); //Reactualizo los datos de la lista Liquidados
                    }
                    else
                    {
                        MessageB("Error al mover el registro", "Aviso", 2);
                    }
                    break;
            }

        }

        #endregion
        #region Lista2 
        //Seguir editando lista 2 pero las fechas y pagos
        private void BotonEditarFechas2_Click(object sender, EventArgs e)
        {
            PanelEditar2_2.BringToFront();
            //acomodamos el combobox de Fechas para agregar las fechas que se necesiten
            ComboBoxDeFechas.Items.Clear();
            for (int i = 0; i < 14; i++)
            {
                ComboBoxDeFechas.Items.Add("Fecha " + (i + 1));
            }
        }
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
        private void RjButton7_Click(object sender, EventArgs e) //Guarda los cambios usando ListEdit2 
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
                    pnlListas.BringToFront();
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
                    pnlListas.BringToFront();
                    btnLista2.PerformClick(); //Reactualizo los datos de la lista 2

                }
                else
                {
                    MessageB("Error al guardar los cambios", "Advertencia", 2);
                }
            }
        }

        //Si selecciona una fecha de lista 2 se muestra en el datetimepicker
        private void ComboBoxDeFechas_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            FechaEnLista2.Enabled = true;
            if (string.IsNullOrEmpty(Informacion2[2]))
            {
                FechaEnLista2.Value = DateTime.Today;
            }
            else
            {
                if (ComboBoxDeFechas.SelectedIndex == 0)
                {
                    int apuntador = 14;

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
                    int apuntador = ComboBoxDeFechas.SelectedIndex + (14 + 2);
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
        }
        //Si ya puso un pago se activa el boton
        private void TextBoxPago__TextChanged(object sender, EventArgs e)
        {
            if (TextBoxPago.Texts != null && TextBoxPago.Texts != "")
            {
                Botoncambiodefechamomentaneo.Enabled = true;
            }
            else
            {
                Botoncambiodefechamomentaneo.Enabled = false;
            }

        }
        //De editar lista 2_2 a editar lista 2
        private void BotonVolverEditar2_Click(object sender, EventArgs e)
        {
            BotonEditarFechas2.Enabled = false;
            Botoncambiodefechamomentaneo.Enabled = false;
            FechaEnLista2.Enabled = false;
            PnlEditar2.BringToFront();
        }

        private void RjButton8_Click(object sender, EventArgs e)//Mover de Lista 2 a lista 3 o liquidados
        {
            switch (CmbLista2.SelectedIndex)
            {
                case 0://Mover a lista 3
                    PedirDatos3 a = new();
                    a.ShowDialog();
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
                        pnlListas.BringToFront();
                        btnLista3.PerformClick();
                    }
                    else
                    {
                        MessageB("Error al mover a lista 3", "Error", 2);
                    }
                    break;
                case 1://mover a liquidados
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
                        pnlListas.BringToFront();
                        btnLiquidados.PerformClick();
                    }
                    else
                    {
                        MessageB("Error al mover a liquidados", "Error", 2);
                    }

                    break;
            }
        }
        private void CmbLista2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbLista2.SelectedIndex != -1)
            {
                rjButton8.Enabled = true;

            }
            else
            {
                rjButton8.Enabled = false;
            }
        }

        #endregion
        #region Lista3
        private void BotonGuardar3_Click(object sender, EventArgs e)
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
            Informacion3[11] = TextResolucionDemanda.Texts; //Resolucion de la demanda
            Informacion3[12] = TextImporte3.Texts; //Importe
            Informacion3[10] = ComboBoxResolucion3.SelectedItem.ToString(); //Resolucion
            Informacion3[13] = Cliente;
            bool es = a.EditarLista3(Informacion3);
            if (es)
            {
                pnlListas.BringToFront();
                btnLista3.PerformClick(); //Reactualizo los datos de la lista 3
            }
            else
            {
                MessageBox.Show("Error al editar");
            }
        }
        private void RjButton9_Click(object sender, EventArgs e)//Mover de Lista 3 a Liquidados
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
                pnlListas.BringToFront();
                btnLiquidados.PerformClick();
            }
            else
            {
                MessageB("Error al mover a liquidados", "Error", 2);
            }
        }
        private void RjComboBox5_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rjComboBox5.SelectedIndex != -1)
            {
                rjButton9.Enabled = true;

            }
            else
            {
                rjButton9.Enabled = false;
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
                pnlListas.BringToFront();
                btnLiquidados.PerformClick(); //Reactualizo los datos de la lista Liquidados
            }
            else
            {
                MessageBox.Show("Error al guardar los cambios");
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
            btnLista1.Enabled = true;
            btnLista2.Enabled = true;
            btnLista3.Enabled = true;
            btnMostrarTodos.Enabled = true;
            btnLiquidados.Enabled = true;
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
                btnMover.Enabled = true;
            }
            else
            {
                btnMover.Enabled = false;
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
            pnlRegPago.BringToFront();
            lblTitle.Text = "Registrar pago";

            // Iniciar el hilo de fondo
            BackgroundWorker worker = new();
#pragma warning disable CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
            worker.DoWork += Worker_DoWork;
#pragma warning restore CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
            worker.RunWorkerAsync();
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Operaciones intensivas (lectura de datos, procesamiento, etc.)
            Lectura_Base_Datos instancia = new();
            List<string[]> lista1 = instancia.LectLista1();
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
            Lecturas_Especificas instancia = new();
            string[] datos = instancia.LectName(ComBoxName.SelectedItem.ToString());
            if (datos[1] != ComBoxName.SelectedItem.ToString())
            {
                MessageB("No se encontro al usuario en esa Lista", "Advertencia", 2);
            }
            else
            {
                for (int i = 16; i < datos.Length; i++)
                {
                    if (datos[i] != null && datos[i] != "-")
                    {
                        rjComboBox9.Items.Add(datos[i]);
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
                txtBoxCredito.Texts = datos[2];
            }
        }
        private void BtnMarcarP_Click(object sender, EventArgs e)
        {
            //Obtener el valor seleccionado de fecha por el nombre del cliente
            Lecturas_Especificas instancia2 = new();
            string[] fechas = instancia2.LectName(ComBoxName.SelectedItem.ToString());
            //Leer las fechas registradas 
            int index = rjComboBox9.SelectedIndex; //Fecha seleccionada por el cliente
            index += 16;
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
                fechas[15] = totRes.ToString();//Asigno el nuevo monto restante
                Ediciones instancia22 = new();
                string[] dato = fechas;
                dato[30] = fechas[1];
                _ = instancia22.EditarLista1(dato);
            }
            //Resetear valores 
            ComBoxName.SelectedIndex = -1; ComBoxName.Texts = "Introduzca nombre";
            btnBuscarC.Enabled = false;
            rjComboBox9.Items.Clear();
            rjComboBox9.Visible = false;
            txtBoxCredito.Visible = false;
            txtBoxMonto.Visible = false; txtBoxMonto.Texts = "";
            lblCredito.Visible = false;
            TextBoxRestantepagos.Visible = false;
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
            CargarPromotoresEnComboBox(rjComboBox4);
            lblTitle.Text = "Configuracion";
            panel2.BringToFront();
            _ = new Accesos();
            string[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
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

        private void Button1_Click(object sender, EventArgs e)
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
            AvisoVacio2.Text = "";
            comboBox1.SelectedIndex = -1;
            string[] usuarios = Accesos.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }

        #region Edicion conexion sql

        public bool conect;
        public bool revisador = true;
        private async void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lectura_Base_Datos a = new();
            if (tabControl1.SelectedIndex == 0)
            {
                _ = new Accesos();
                string[] usuarios = Accesos.CargarUsuarios().ToArray();
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(usuarios);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                TextServer.Text = Properties.Settings1.Default.Servidor;
                TextPuerto.Text = Properties.Settings1.Default.Puerto.ToString();
                TextBase.Text = Properties.Settings1.Default.Base_de_datos;
                TextUsuario.Text = Properties.Settings1.Default.Usuario;
                TextContra.Text = Properties.Settings1.Default.Contraseña;
                await a.CheckConnection(true);
                revisador = true;
                if (conect)
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
            else
            {

            }
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
            if (conect)
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


        public class Promotor
        {
            public string Nombre { get; set; }
        }

        public static void CargarPromotoresEnComboBox(RJComboBox box)
        {
            Lectura_Base_Datos lec = new();
            try
            {
                // Ruta del archivo JSON
                string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Promotores.json");

                // Leer el archivo JSON
                string json = File.ReadAllText(jsonFilePath);

                // Deserializar el JSON en una lista de objetos Promotor
                var promotores = JsonConvert.DeserializeObject<dynamic>(json);

                // Obtener los nombres de los promotores
                var nombresPromotores = promotores.promotores.ToObject<string[]>();

                // Limpiar el ComboBox antes de agregar los nuevos elementos
                box.Items.Clear();

                // Agregar los nombres de los promotores al ComboBox
                box.Items.AddRange(nombresPromotores);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra al leer o cargar el JSON
                lec.Registro_errores("Error al cargar los promotores: " + ex.Message);
            }
        }
        public static void AgregarPromotor(string nombre)
        {
            Lectura_Base_Datos lec = new();
            try
            {
                string jsonFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Promotores.json";

                // Leer el archivo JSON actual
                string json = File.ReadAllText(jsonFilePath);

                // Deserializar el JSON en un objeto dynamic
                dynamic jsonObject = JsonConvert.DeserializeObject(json);

                // Obtener la lista de promotores
                List<string> promotores = jsonObject.promotores.ToObject<List<string>>();

                // Agregar el nuevo promotor a la lista
                promotores.Add(nombre);

                // Serializar la lista de promotores de nuevo a JSON
                string nuevoJson = JsonConvert.SerializeObject(new { promotores });

                // Escribir el JSON actualizado en el archivo
                File.WriteAllText(jsonFilePath, nuevoJson);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra al leer o escribir el JSON
                lec.Registro_errores("Error al agregar el promotor: " + ex.Message);
            }
        }
        public static void EditarPromotor(string nombreOriginal, string nombreEditado)
        {
            Lectura_Base_Datos lec = new();
            try
            {
                string jsonFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Promotores.json";

                // Leer el archivo JSON actual
                string json = File.ReadAllText(jsonFilePath);

                // Deserializar el JSON en un objeto dynamic
                dynamic jsonObject = JsonConvert.DeserializeObject(json);

                // Obtener la lista de promotores
                List<string> promotores = jsonObject.promotores.ToObject<List<string>>();

                // Buscar el nombre original en la lista
                int index = promotores.IndexOf(nombreOriginal);
                if (index != -1)
                {
                    // Actualizar el nombre en la lista
                    promotores[index] = nombreEditado;

                    // Serializar la lista de promotores de nuevo a JSON
                    string nuevoJson = JsonConvert.SerializeObject(new { promotores });

                    // Escribir el JSON actualizado en el archivo
                    File.WriteAllText(jsonFilePath, nuevoJson);
                }
                else
                {
                    MessageB("El promotor no existe en el JSON.", "Aviso", 2);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra al leer o escribir el JSON
                lec.Registro_errores("Error al editar el promotor: " + ex.Message);
            }
        }

        public static void EliminarPromotor(string nombre)
        {
            Lectura_Base_Datos lec = new();
            try
            {
                string jsonFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Promotores.json";

                // Leer el archivo JSON actual
                string json = File.ReadAllText(jsonFilePath);

                // Deserializar el JSON en un objeto dynamic
                dynamic jsonObject = JsonConvert.DeserializeObject(json);

                // Obtener la lista de promotores
                List<string> promotores = jsonObject.promotores.ToObject<List<string>>();

                // Buscar el nombre en la lista
                if (promotores.Contains(nombre))
                {
                    // Eliminar el nombre de la lista
                    promotores.Remove(nombre);

                    // Serializar la lista de promotores de nuevo a JSON
                    string nuevoJson = JsonConvert.SerializeObject(new { promotores });

                    // Escribir el JSON actualizado en el archivo
                    File.WriteAllText(jsonFilePath, nuevoJson);
                }
                else
                {
                    MessageB("El promotor no existe en el JSON.", "Aviso", 2);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra al leer o escribir el JSON
                lec.Registro_errores("Error al eliminar el promotor: " + ex.Message);
            }
        }
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
            CargarPromotoresEnComboBox(rjComboBox4);
        }
        private void RjButton6_Click(object sender, EventArgs e)
        {
            EliminarPromotor(rjComboBox4.SelectedItem.ToString());
            rjComboBox4.SelectedIndex = -1;
            textBox4.Text = "";
            CargarPromotoresEnComboBox(rjComboBox4);

        }
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            rjButton5.Enabled = true;
        }
        private void RjButton5_Click(object sender, EventArgs e)
        {
            AgregarPromotor(textBox5.Text);
            textBox5.Text = "";
            CargarPromotoresEnComboBox(rjComboBox4);
        }
        #endregion


        private void RjComboBox9_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rjComboBox9.SelectedIndex != -1)
            {
                btnMarcarP.Enabled = true;
            }
            else
            {
                btnMarcarP.Enabled = false;
            }
        }
    }
}