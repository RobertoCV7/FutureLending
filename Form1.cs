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
            rjButton4.Enabled = false;
            rjButton5.Enabled = false;
            cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComBoxName.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComBoxName.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            gridListas.VirtualMode = false;
            TablaClientes.AñadirEvento(gridListas);
        }
        public string[] informacion = new string[30]; //Se usa para guardar la info de la lista 1
        public string[] Informacion2 = new string[44]; //Se usa para guardar la info de la lista 2
        public string[] informacion3 = new string[15];
        public string[] Fechas = new string[100]; //Fechas de lista 2 inicializado en 100 por posible expansion futura
        public string[] Pagos = new string[14]; //Pagos de lista 2
        public string pertenece; //De que lista viene
        public string Cliente; //Nombre del cliente
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
        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            DateTime a = dateFechaInicio.Value;
            DateTime FechaFinal;
            int multiplicador = cmbTipo.SelectedIndex == 0 ? 14 : 15;
            FechaFinal = a.AddDays(multiplicador * 7);
            dateTimePickerPersonalizado2.Value = FechaFinal;
            String credito = txtCredito.Texts;
            Double credito2 = Convert.ToDouble(credito);
            String interes = cmbInteres.Texts;
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
            txtTotal.Texts = $"${monto_total}";
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
            int p = int.Parse(MontoTotal) * 2;

            obj.Create("lista1", cmbPromotor.Texts, txtNombre.Texts, txtCredito.Texts, p.ToString(), dateFechaInicio.Value, dateTimePickerPersonalizado2.Value, Interes, MontoTotal, txtCalle.Texts, txtColonia.Texts, txtNumInt.Texts, txtNumExt.Texts, txtTelefono.Texts, txtCorreo.Texts, cmbTipo.SelectedItem.ToString(), MontoTotal);
            //Borrar datos para poder agregar de nuevo 
            txtNombre.Texts = "";
            txtCredito.Texts = "";
            dateFechaInicio.Value = DateTime.Now;
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
            if (CombBoxLista.SelectedIndex == -1 || ComBoxName.SelectedIndex == -1)
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
        private void BtnGuardarCambio_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos a = new();
            if (ListaEstado == 0)
            {
                string[] informacion2 = new string[30];
                for (int i = 0; i < informacion.Length; i++)
                {
                    informacion2[i] = informacion[i];
                }

                informacion2[0] = string.IsNullOrEmpty(textBoxPersonalizado10.Texts) ? informacion[0] : textBoxPersonalizado10.Texts;
                informacion2[1] = string.IsNullOrEmpty(textBoxPersonalizado9.Texts) ? informacion[1] : textBoxPersonalizado9.Texts;
                informacion2[2] = dateTimePickerPersonalizado1.Value.ToString("dd/MM/yyyy");
                informacion2[3] = string.IsNullOrEmpty(rjComboBox1.Texts) ? informacion[3] : rjComboBox1.Texts;
                informacion2[4] = string.IsNullOrEmpty(textBoxPersonalizado8.Texts) ? informacion[4] : textBoxPersonalizado8.Texts;
                informacion2[5] = string.IsNullOrEmpty(rjComboBox3.Texts) ? informacion[5] : rjComboBox3.Texts;
                informacion2[6] = string.IsNullOrEmpty(textBoxPersonalizado6.Texts) ? informacion[6] : textBoxPersonalizado6.Texts;
                informacion2[7] = string.IsNullOrEmpty(textBoxPersonalizado5.Texts) ? informacion[7] : textBoxPersonalizado5.Texts;
                informacion2[8] = string.IsNullOrEmpty(textBoxPersonalizado4.Texts) ? informacion[8] : textBoxPersonalizado4.Texts;
                informacion2[9] = string.IsNullOrEmpty(textBoxPersonalizado3.Texts) ? informacion[9] : textBoxPersonalizado3.Texts;
                informacion2[10] = string.IsNullOrEmpty(textBoxPersonalizado2.Texts) ? informacion[10] : textBoxPersonalizado2.Texts;
                informacion2[11] = string.IsNullOrEmpty(textBoxPersonalizado1.Texts) ? informacion[11] : textBoxPersonalizado1.Texts;
                if (rjComboBox2.Texts == "Semanal")
                {
                    informacion2[12] = "0";
                }
                else
                {
                    informacion2[12] = "1";
                    for (int i = 0; i < 14; i++)
                    {
                        informacion2[14 + i] = string.IsNullOrEmpty(informacion[14 + i]) ? "-" : informacion[14 + i];
                    }
                }
                informacion2[13] = string.IsNullOrEmpty(textBoxPersonalizado7.Texts) ? informacion[13] : textBoxPersonalizado7.Texts;
                informacion2[28] = Cliente;
                Ediciones a2 = new();
                a2.EditarLista1(informacion2);
                pnlListas.BringToFront();
            }
            else if (ListaEstado == 2)
            {
                string[] informacion2 = new string[15];
                for (int i = 0; i < 14; i++)
                {
                    informacion2[i] = informacion3[i];
                }
                informacion2[0] = string.IsNullOrEmpty(textBoxPersonalizado10.Texts) ? informacion3[0] : textBoxPersonalizado10.Texts;
                informacion2[1] = string.IsNullOrEmpty(textBoxPersonalizado9.Texts) ? informacion3[1] : textBoxPersonalizado9.Texts;
                informacion2[2] = dateTimePickerPersonalizado1.Value.ToString("dd/MM/yyyy");
                informacion2[3] = string.IsNullOrEmpty(rjComboBox1.Texts) ? informacion3[3] : rjComboBox1.Texts;
                informacion2[4] = string.IsNullOrEmpty(textBoxPersonalizado8.Texts) ? informacion3[4] : textBoxPersonalizado8.Texts;
                informacion2[5] = string.IsNullOrEmpty(rjComboBox3.Texts) ? informacion3[5] : rjComboBox3.Texts;
                informacion2[6] = string.IsNullOrEmpty(textBoxPersonalizado6.Texts) ? informacion3[6] : textBoxPersonalizado6.Texts;
                informacion2[7] = string.IsNullOrEmpty(textBoxPersonalizado5.Texts) ? informacion3[7] : textBoxPersonalizado5.Texts;
                informacion2[8] = string.IsNullOrEmpty(textBoxPersonalizado4.Texts) ? informacion3[8] : textBoxPersonalizado4.Texts;
                informacion2[9] = string.IsNullOrEmpty(textBoxPersonalizado3.Texts) ? informacion3[9] : textBoxPersonalizado3.Texts;
                informacion2[10] = string.IsNullOrEmpty(textBoxPersonalizado2.Texts) ? informacion3[10] : textBoxPersonalizado2.Texts;
                informacion2[11] = string.IsNullOrEmpty(textBoxPersonalizado1.Texts) ? informacion3[11] : textBoxPersonalizado1.Texts;
                if (rjComboBox2.Texts == "Semanal")
                {
                    informacion2[12] = "0";
                }
                else
                {
                    informacion2[12] = "1";
                }
                informacion2[13] = string.IsNullOrEmpty(textBoxPersonalizado7.Texts) ? informacion3[13] : textBoxPersonalizado7.Texts;
                informacion2[14] = Cliente;
                Ediciones a2 = new();
                a2.EditarLista3(informacion2);
                pnlListas.BringToFront();
            }
            else if (ListaEstado == 3)
            {
                string[] informacion5 = new string[15];
                for (int i = 0; i < 14; i++)
                {
                    informacion5[i] = informacion3[i];
                }
                informacion5[0] = string.IsNullOrEmpty(textBoxPersonalizado10.Texts) ? informacion3[0] : textBoxPersonalizado10.Texts;
                informacion5[1] = string.IsNullOrEmpty(textBoxPersonalizado9.Texts) ? informacion3[1] : textBoxPersonalizado9.Texts;
                informacion5[2] = dateTimePickerPersonalizado1.Value.ToString("dd/MM/yyyy");
                informacion5[3] = dateTimeLimite.Value.ToString("dd/MM/yyyy");
                informacion5[4] = string.IsNullOrEmpty(rjComboBox1.Texts) ? informacion3[3] : rjComboBox1.Texts;
                informacion5[5] = string.IsNullOrEmpty(textBoxPersonalizado8.Texts) ? informacion3[4] : textBoxPersonalizado8.Texts;
                informacion5[6] = string.IsNullOrEmpty(rjComboBox3.Texts) ? informacion3[5] : rjComboBox3.Texts;
                informacion5[7] = string.IsNullOrEmpty(textBoxPersonalizado6.Texts) ? informacion3[6] : textBoxPersonalizado6.Texts;
                informacion5[8] = string.IsNullOrEmpty(textBoxPersonalizado5.Texts) ? informacion3[7] : textBoxPersonalizado5.Texts;
                informacion5[9] = string.IsNullOrEmpty(textBoxPersonalizado4.Texts) ? informacion3[8] : textBoxPersonalizado4.Texts;
                informacion5[10] = string.IsNullOrEmpty(textBoxPersonalizado3.Texts) ? informacion3[9] : textBoxPersonalizado3.Texts;
                informacion5[11] = string.IsNullOrEmpty(textBoxPersonalizado2.Texts) ? informacion3[10] : textBoxPersonalizado2.Texts;
                informacion5[12] = string.IsNullOrEmpty(textBoxPersonalizado1.Texts) ? informacion3[11] : textBoxPersonalizado1.Texts;
                if (rjComboBox2.Texts == "Semanal")
                {
                    informacion5[13] = "0";
                }
                else
                {
                    informacion5[13] = "1";
                }
                informacion5[14] = Cliente;
                Ediciones a2 = new();
                a2.EditarListaLiquidados(informacion5);
                pnlListas.BringToFront();

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
            ListaEstado = 0;
            var mostrarListaTask = TablaClientes.MostrarLista1(gridListas, cmbCliente);

            while (!mostrarListaTask.IsCompleted)
            {
                DesactivarBotones();
                await Task.Delay(100);
            }
            ActivarListas();
            ActivarEditar();
            listaActual = "lista1";
        }

        private async void BtnLista2_Click(object sender, EventArgs e)
        {
            ListaEstado = 1;
            var mostrarListaTask = TablaClientes.MostrarLista2(gridListas, cmbCliente);
            while (!mostrarListaTask.IsCompleted)
            {
                DesactivarBotones();
                await Task.Delay(100);
            }
            ActivarListas();
            ActivarEditar();
            listaActual = "lista2";
        }

        private async void BtnLista3_Click(object sender, EventArgs e)
        {
            ListaEstado = 2;
            var mostrarListaTask = TablaClientes.MostrarLista3(gridListas, cmbCliente);
            while (!mostrarListaTask.IsCompleted)
            {
                DesactivarBotones();
                await Task.Delay(100);
            }
            ActivarListas();
            ActivarEditar();
            listaActual = "lista3";
        }

        private async void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            var mostrarListaTask = TablaClientes.MostrarTodos(gridListas, cmbCliente);
            while (!mostrarListaTask.IsCompleted)
            {
                DesactivarBotones();
                await Task.Delay(100);
            }
            //En este no se activa para editar
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            CargarPromotoresEnComboBox(rjComboBox3);

            Lecturas_Especificas a = new();
            LabelLimite.Hide();
            dateTimeLimite.Hide();


            if (ListaEstado == 0) //Si viene de la lista 1
            {
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
                textBoxPersonalizado10.Texts = Cliente;
                //Empieza leyendo su informacion de la base de datos
                informacion = a.LectName(Cliente);
              
                //Tuve que convertir de List<string[]> a string[] para poder usarlo en los objetos del Panel (Editar)
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
                //De aqui pasa al caso de oprimir el boton para mover las fechas y pagos 
            }
            else if (ListaEstado == 2)
            {
                cmbLista.Items.Clear();
                cmbLista.Enabled = true;
                PanelEditar.BringToFront();
                LabelLimite.Hide();
                dateTimeLimite.Hide();
                pertenece = "Lista 3";
                LblPerte.Text = pertenece;
                cmbLista.Items.AddRange(new string[] { "Liquidados" });
                Cliente = cmbCliente.Texts;
                List<string[]> list = a.LectName3(Cliente);
                informacion3 = list.SelectMany(x => x).ToArray();
                textBoxPersonalizado10.Texts = informacion3[0];
                textBoxPersonalizado9.Texts = informacion3[1];
                dateTimePickerPersonalizado1.Value = DateTime.Parse(informacion3[2]);
                switch (informacion3[3])
                {
                    case "7":
                        rjComboBox1.SelectedIndex = 0;
                        break;
                    case "8":
                        rjComboBox1.SelectedIndex = 1;
                        break;
                    case "10":
                        rjComboBox1.SelectedIndex = 2;
                        break;
                }
                textBoxPersonalizado8.Texts = informacion3[4];
                if (informacion3[12] == "0" || informacion3[12] == "Semanal")
                {
                    rjComboBox2.SelectedIndex = 0;
                }
                else
                {
                    rjComboBox2.SelectedIndex = 1;
                }
                if (informacion3[5] == "Ramon")
                {
                    rjComboBox3.SelectedIndex = 0;
                }
                else if (informacion[5] == "Roberto")
                {
                    rjComboBox3.SelectedIndex = 1;
                }
                else
                {
                    rjComboBox3.SelectedIndex = 2;
                }
                textBoxPersonalizado6.Texts = informacion3[6];
                textBoxPersonalizado5.Texts = informacion3[7];
                textBoxPersonalizado4.Texts = informacion3[8];
                textBoxPersonalizado3.Texts = informacion3[9];
                textBoxPersonalizado2.Texts = informacion3[10];
                textBoxPersonalizado1.Texts = informacion3[11];
                textBoxPersonalizado7.Texts = informacion3[13];

            }
            else if (ListaEstado == 3)
            {
                cmbLista.Items.Clear();
                Cliente = cmbCliente.Texts;
                List<string[]> list = a.LectName4(Cliente);
                informacion3 = list.SelectMany(x => x).ToArray();
                PanelEditar.BringToFront();
                LabelLimite.Text = "Fecha Ultimo";
                label25.Hide();
                textBoxPersonalizado7.Hide();
                pertenece = "Lista Liquidados";
                LblPerte.Text = pertenece;
                cmbLista.Enabled = false;
                textBoxPersonalizado10.Texts = informacion3[0];
                textBoxPersonalizado9.Texts = informacion3[1];
                dateTimePickerPersonalizado1.Value = DateTime.Parse(informacion3[2]);
                string intervalo = informacion3[3].Split('-')[0];
                dateTimeLimite.Value = DateTime.Parse(intervalo);
                switch (informacion3[4])
                {
                    case "7":
                        rjComboBox1.SelectedIndex = 0;
                        break;
                    case "8":
                        rjComboBox1.SelectedIndex = 1;
                        break;
                    case "10":
                        rjComboBox1.SelectedIndex = 2;
                        break;
                }
                textBoxPersonalizado8.Texts = informacion3[5];
                if (informacion3[13] == "0" || informacion3[12] == "Semanal")
                {
                    rjComboBox2.SelectedIndex = 0;
                }
                else
                {
                    rjComboBox2.SelectedIndex = 1;
                }
                if (informacion3[6] == "Ramon")
                {
                    rjComboBox3.SelectedIndex = 0;
                }
                else if (informacion[6] == "Roberto")
                {
                    rjComboBox3.SelectedIndex = 1;
                }
                else
                {
                    rjComboBox3.SelectedIndex = 2;
                }
                textBoxPersonalizado6.Texts = informacion3[7];
                textBoxPersonalizado5.Texts = informacion3[8];
                textBoxPersonalizado4.Texts = informacion3[9];
                textBoxPersonalizado3.Texts = informacion3[10];
                textBoxPersonalizado2.Texts = informacion3[11];
                textBoxPersonalizado1.Texts = informacion3[12];
            }
        }


        #region Lista2 Editar
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
        //presionado boton guardar el pago y la asignacion de fecha
        private void Botoncambiodefechamomentaneo_Click(object sender, EventArgs e)
        {
            string fecha = FechaEnLista2.Value.ToString("dd/MM/yyyy");
            string pago = TextBoxPago.Texts;
            if (ComboBoxDeFechas.SelectedIndex == 0)
            {
                int indice = 14;
                Informacion2[indice] = fecha;
                Informacion2[indice + 1] = pago;
            }
            else
            {
                int indice = 14 + (ComboBoxDeFechas.SelectedIndex * 2);
                Informacion2[indice] = fecha;
                Informacion2[indice + 1] = pago;
            }
     
        }

        
        private void rjButton7_Click(object sender, EventArgs e) //Guarda los cambios usando ListEdit2 
        {
            Ediciones e2 = new Ediciones();
            string[] InfoListaNueva2 = Informacion2;
            InfoListaNueva2[0] = rjComboBox8.SelectedItem.ToString(); //Promotor que lo atiende
           InfoListaNueva2[1]= TextBoxNombre.Texts; //Nombre del registro
            InfoListaNueva2[2] = TextBoxCredito.Texts; //Credito Prestado
            InfoListaNueva2[3] = TextBoxRestante.Texts; //Monto Restante
           InfoListaNueva2[4]= TextBoxPagare.Texts; //Pagare generado
           InfoListaNueva2[5]= TextBoxCalle.Texts; //Calle
            InfoListaNueva2[6]=TextBoxColonia.Texts; //Colonia
            InfoListaNueva2[7]=TextBoxNumInt.Texts; //Numero de casa interior
            InfoListaNueva2[8]=TextBoxNumExt.Texts; //Numero de casa exterior
            InfoListaNueva2[9]=TextBoxTelefono.Texts; //Telefono
            InfoListaNueva2[10]=TextBoxCorreo.Texts; //Correo
            InfoListaNueva2[11]= rjComboBox7.SelectedItem.ToString(); //Liquidacion o Intencion
            InfoListaNueva2[12]=TextBoxLiquidacionIntencion.Texts; //Monto de liquidacion o intencion
            InfoListaNueva2[13]=TextBoxQuita.Texts; //Monto de Quita
            InfoListaNueva2[41] = Cliente;
           
           bool a= e2.EditarLista2(InfoListaNueva2);
            if (a)
            {
                pnlListas.BringToFront();
            }
            else
            {
                MessageBox.Show("Error al guardar los cambios");
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
                if(ComboBoxDeFechas.SelectedIndex == 0)
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
                    int apuntador = ComboBoxDeFechas.SelectedIndex + (14+2);
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
            if (gridListas.Rows.Count > 1)
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
        private void BtnMover_Click(object sender, EventArgs e) //boton para mover
        {

            string proviene = LblPerte.Text;
            if (proviene == "Lista 1")
            {
                proviene = "lista1";
            }
            else if (proviene == "Lista 2")
            {
                proviene = "lista2";
            }
            else if (proviene == "Lista 3")
            {
                proviene = "lista3";
            }
            string Nombre = textBoxPersonalizado10.Texts;
            string Credito = textBoxPersonalizado9.Texts;
            string Fecha_Inicio = dateTimePickerPersonalizado1.Value.ToString("dd/MM/yyyy");
            string Interes = rjComboBox1.SelectedItem.ToString().Split("%")[0];
            string Monto = textBoxPersonalizado8.Texts;
            string promotor = rjComboBox3.SelectedItem.ToString();
            string calle = textBoxPersonalizado6.Texts;
            string colonia = textBoxPersonalizado5.Texts;
            string num_int = textBoxPersonalizado4.Texts;
            string num_ext = textBoxPersonalizado3.Texts;
            string telefono = textBoxPersonalizado2.Texts;
            string correo = textBoxPersonalizado1.Texts;
            int tipo_pago;
            if (rjComboBox2.SelectedItem.ToString() == "Semanales")
            {
                tipo_pago = 0;
            }
            else
            {
                tipo_pago = 1;
            }
            Lectura_Base_Datos lec = new();

            switch (cmbLista.SelectedItem.ToString())
            {
                case "Lista 2": //lista2
                    LabelLimite.Text = "Fecha Limite";
                    string Fecha_Ultimo1 = dateTimeLimite.Value.ToString("dd/MM/yyyy");
                    string Monto_Restante = textBoxPersonalizado7.Texts;
                    string[] datos1 = new string[]{
    Nombre,
    Credito,
    Fecha_Inicio,
    Interes,
    Monto,
    promotor,
    calle,
    colonia,
    num_int,
    num_ext,
    telefono,
    correo
};
                    string[] arrayCompleto1 = datos1.Concat(new string[] { tipo_pago.ToString() }).ToArray();
                    string[] arrayCompleto2 = arrayCompleto1.Concat(new string[] { Monto_Restante, Fecha_Ultimo1 }).ToArray();
                    lec.Erase(Nombre, proviene);
                    lec.InsertarLista2(arrayCompleto2);
                    pnlListas.BringToFront();
                    break;
                case "Lista 3": //lista 3
                    string Monto_Restante2 = textBoxPersonalizado7.Texts;
                    string[] datitos = new string[]
                    {
                        Nombre,
                        Credito,
                        Fecha_Inicio,
                        Interes,
                        Monto,
                        promotor,
                        calle,
                        colonia,
                        num_int,
                        num_ext,
                        telefono,
                        correo
                    };
                    string[] completito = datitos.Concat(new string[] { tipo_pago.ToString(), Monto_Restante2 }).ToArray();
                    lec.Erase(Nombre, proviene);
                    lec.InsertarLista3(completito);
                    pnlListas.BringToFront();
                    break;
                case "Liquidados": //lista liquidados
                    string Fecha_Ultimo = dateTimeLimite.Value.ToString("dd/MM/yyyy");
                    string[] datos = new string[]{
    Nombre,
    Credito,
    Fecha_Inicio,
    Fecha_Ultimo,
    Interes,
    Monto,
    promotor,
    calle,
    colonia,
    num_int,
    num_ext,
    telefono,
    correo
};
                    string[] arrayCompleto = datos.Concat(new string[] { tipo_pago.ToString() }).ToArray();
                    lec.Erase(Nombre, proviene);
                    lec.InsertarLiquidados(arrayCompleto);
                    pnlListas.BringToFront();
                    break;
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
            lblTitle.Text = "Registrar pago";
            pnlRegPago.BringToFront();

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
            List<string[]> lista2 = instancia.LectLista2();

            // Unir las listas en una sola lista
            List<string[]> listaTotal = new(lista1);
            listaTotal.AddRange(lista2);

            // Agregar los nombres a ComBoxName
            // Acceder a los controles se realiza en el hilo de interfaz de usuario principal
            ComBoxName.BeginInvoke((MethodInvoker)delegate
            {
                ComBoxName.Items.Clear();
                foreach (string[] item in listaTotal)
                {
                    ComBoxName.Items.Add(item[0]);
                }
            });
        }
        private void BtnBuscarC_Click(object sender, EventArgs e)
        {
            //Buscar el cliente por nombre dentro de la base de datos para registrar un nuevo pago semanal/quincenal
            //Mostramos en el form

            //Agregamos los datos del cliente al form
            Lecturas_Especificas instancia = new();
            string[] datos;
            if (CombBoxLista.Texts == "Lista 1")
            {
                datos = instancia.LectName(ComBoxName.Texts);
               
            }
            else
            {
                datos = instancia.LectName(ComBoxName.Texts);
           
            }

            if (datos[1] == null)
            {
                Form2 a = new("No se encontro al usuario en esa Lista", "Advertencia", 2);
                a.ShowDialog();
            }
            else
            {
                lblCredito.Visible = true;
                txtBoxCredito.Visible = true;
                txtBoxMonto.Visible = true;
                lblFecha.Visible = true;
                lblMonto.Visible = true;
                DateTimeReg.Visible = true;
                btnMarcarP.Visible = true;
                txtBoxCredito.Texts = datos[4];
            }
        }
        private void BtnMarcarP_Click(object sender, EventArgs e)
        {
            //Validar que se encuentre esa fecha
            bool band = false;
            int index = 0;
            //Obtener el valor seleccionado de fecha 
            DateTime fecha = DateTimeReg.Value;
            string Fecha = fecha.ToString("dd/MM/yyyy");
            //Leer las fechas registradas 
            Lecturas_Especificas instancia = new();
            string list;
            string[] datos;
            if (CombBoxLista.Texts == "Lista 1")
            {
                list = "lista1";

                datos = instancia.LectName2(ComBoxName.Texts);
            
                for (int i = 14; i < datos.Length; i++)
                {
                    if (datos[i] != null)
                    {

                        string datos2 = datos[i].Replace("-", "");
                        if (datos2 == Fecha)
                        {
                            band = true;
                            index = i - 13;
                        }
                    }

                }
            }
            else
            {
                list = "lista2";
                datos = instancia.LectName2(ComBoxName.Texts);
                
                if (datos[14] == Fecha) { band = true; }
            }

            if (!band)
            {
                Form2 a = new("El cliente no cuenta con esa fecha", "Advertencia", 2);
                a.ShowDialog();
            }
            //Marcar como pagada en la base de datos
            if (band)
            {
                //Restar el nuevo pago al monto restante 
                double totRes = (Convert.ToDouble(datos[13])) - (Convert.ToDouble(txtBoxMonto.Texts));
                //Si el monto restante es 0, entonces se pasa a liquidados 
                if (totRes == 0)
                {
                    Lectura_Base_Datos obj = new();
                    if (list == "lista1")
                    {
                        obj.CreateLiquidados(1, datos); //Agregarlo en liquidados
                        obj.Erase(ComBoxName.Texts, "lista1"); //Lo elimino de lista 1
                    }
                    else
                    {
                        obj.CreateLiquidados(2, datos); //Agregarlo en liquidados
                        obj.Erase(ComBoxName.Texts, "lista2"); //Lo elimino de lista 1
                    }

                }
                else
                {
                    Fecha += "-" + txtBoxMonto.Texts;
                    string update = "Fecha" + index + "='" + Fecha + "'" + ", Monto_Restante='" + Convert.ToString(totRes) + "'";
                    Ediciones  instancia2 = new();
                    instancia2.Edit(list, ComBoxName.Texts, update);
                }
                //Resetear valores 
                ComBoxName.SelectedIndex = -1; ComBoxName.Texts = "Introduzca nombre";
                CombBoxLista.SelectedIndex = -1; CombBoxLista.Texts = "Introduzca lista";
                btnBuscarC.Enabled = false;
                txtBoxCredito.Visible = false;
                txtBoxMonto.Visible = false; txtBoxMonto.Texts = "";
                lblCredito.Visible = false;
                lblMonto.Visible = false;
                lblFecha.Visible = false;
                DateTimeReg.Visible = false;
                btnMarcarP.Visible = false;
            }
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






     
    }
}