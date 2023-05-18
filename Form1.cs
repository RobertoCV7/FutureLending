using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using FutureLending.ControlesPersonalizados;
using MySqlX.XDevAPI.Relational;
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
            cmbCliente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            ComBoxName.AutoCompleteMode = AutoCompleteMode.Suggest;
            ComBoxName.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //Para una visualización más rápida de los datos mediante virtualización
            gridListas.VirtualMode = false;
            TablaClientes.AñadirEvento(gridListas);
        }

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

        private void BtnIngresarClientes_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Ingresar Clientes";
            pnlClientes.BringToFront();
        }

        private void BtnListas_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Listas Completas";
            pnlListas.BringToFront();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos obj = new();
            string Interes = cmbInteres.Texts.Replace("%", "");
            string MontoTotal = txtTotal.Texts.Replace("$", "");
            obj.Create("lista1", txtNombre.Texts, txtCredito.Texts, dateFechaInicio.Value, Interes, MontoTotal, cmbPromotor.Texts, txtCalle.Texts, txtColonia.Texts, txtNumInt.Texts, txtNumExt.Texts, txtTelefono.Texts, txtCorreo.Texts, cmbTipo.SelectedIndex, MontoTotal);
            //Borrar datos para poder agregar de nuevo 
            txtNombre.Texts = "";
            txtCredito.Texts = "";
            dateFechaInicio.Value = new DateTime(2023, 5, 14, 16, 8, 19, 357);
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

        private void BtnTodosSistemas_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos instancia = new();
            _ = instancia.CheckConnection();
        }

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
            Lectura_Base_Datos instancia = new();
            string list;
            if (CombBoxLista.Texts == "Lista 1")
            {
                list = "lista1";
            }
            else { list = "lista2"; }
            string[] datos = instancia.LectName(list, ComBoxName.Texts);
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
                txtBoxCredito.Texts = datos[1];
            }



        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            String credito = txtCredito.Texts;
            Double credito2 = Convert.ToDouble(credito);
            String interes = cmbInteres.Texts;
            string nuevoString = interes.Replace("%", ""); // Elimina los % para poder calcular
            Double interes2 = Convert.ToDouble(nuevoString);
            double tasa_interes = interes2 * credito2 / 100;
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
        string[] informacion = new string[28];
        string[] informacion3 = new string[15];
        string Cliente;
        private void BtnEditar_Click(object sender, EventArgs e)
        {


            Lectura_Base_Datos a = new();

            string pertenece = "";
            string lista = "";
            LabelLimite.Hide();
            dateTimeLimite.Hide();
            if (ListaEstado == 0)
            {
                PanelEditar.BringToFront();
                pertenece = "Lista 1";
                lista = "lista1";
                cmbLista.Items.AddRange(new string[] { "Lista 2", "Lista 3", "Liquidados" });
                LblPerte.Text = pertenece;
                Cliente = cmbCliente.Texts;
                textBoxPersonalizado10.Texts = Cliente;
                //Empieza
                informacion = a.LectName(lista, Cliente);
                textBoxPersonalizado9.Texts = informacion[1];
                dateTimePickerPersonalizado1.Value = DateTime.Parse(informacion[2]);
                switch (informacion[3])
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
                textBoxPersonalizado8.Texts = informacion[4];
                if (informacion[12] == "0")
                {
                    rjComboBox2.SelectedIndex = 0;
                }
                else
                {
                    rjComboBox2.SelectedIndex = 1;
                }

                if (informacion[5] == "Ramon")
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
                textBoxPersonalizado7.Texts = informacion[13];
                textBoxPersonalizado6.Texts = informacion[6];
                textBoxPersonalizado5.Texts = informacion[7];
                textBoxPersonalizado4.Texts = informacion[8];
                textBoxPersonalizado3.Texts = informacion[9];
                textBoxPersonalizado2.Texts = informacion[10];
                textBoxPersonalizado1.Texts = informacion[11];
            }
            else if (ListaEstado == 1)
            {
                PanelEditar.BringToFront();
                Cliente = cmbCliente.Texts;
                LabelLimite.Show();
                dateTimeLimite.Show();
                pertenece = "Lista 2";
                lista = "lista2";
                cmbLista.Items.AddRange(new string[] { "Lista 1", "Lista 3", "Liquidados" });
                informacion3 = a.LectName2(Cliente);
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
                if (informacion3[12] == "0")
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
                if (DateTime.TryParse(informacion[14], out DateTime parsedDate))
                {
                    dateTimeLimite.Value = parsedDate;
                }
                else
                {
                    dateTimeLimite.Value = DateTime.Now;
                }









            }
            else if (ListaEstado == 2)
            {
                LabelLimite.Hide();
                dateTimeLimite.Hide();
                pertenece = "Lista 3";
                lista = "lista3";
                cmbLista.Items.AddRange(new string[] { "Lista 1", "Lista 2", "Liquidados" });
                PanelEditar.BringToFront();
                Cliente = cmbCliente.Texts;
                pertenece = "Lista 2";
                lista = "lista2";
                cmbLista.Items.AddRange(new string[] { "Lista 1", "Lista 3", "Liquidados" });
                informacion3 = a.LectName3(Cliente);
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
                if (informacion3[12] == "0")
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

                Cliente = cmbCliente.Texts;
                informacion3 = a.LectName4(Cliente);
                PanelEditar.BringToFront();
                LabelLimite.Text = "Fecha Ultimo";
                label25.Hide();

                textBoxPersonalizado7.Hide();
                pertenece = "Lista Liquidados";
                lista = "liquidados";
                LblPerte.Text = pertenece;
                cmbLista.Items.AddRange(new string[] { "Lista 1", "Lista 2", "Lista 3" });
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
                if (informacion3[13] == "0")
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
        private void btnMover_Click(object sender, EventArgs e)
        {

        }

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

        private void BtnMarcarP_Click(object sender, EventArgs e)
        {
            //Validar que se encuentre esa fecha
            bool band = false;
            int index = 0;
            //Obtener el valor seleccionado de fecha 
            DateTime fecha = DateTimeReg.Value;
            string Fecha = fecha.ToString("dd/MM/yyyy");
            //Leer las fechas registradas 
            Lectura_Base_Datos instancia = new();
            string list;
            if (CombBoxLista.Texts == "Lista 1")
            {
                list = "lista1";
            }
            else { list = "lista2"; }
            string[] datos = instancia.LectName(list, ComBoxName.Texts);
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
                    obj.CreateLiquidados(1, datos); //Agregarlo en liquidados
                    obj.Erase(ComBoxName.Texts, "lista1"); //Lo elimino de lista 1
                }
                else
                {
                    Fecha += "-" + txtBoxMonto.Texts;
                    string update = "Fecha" + index + "='" + Fecha + "'" + ", Monto_Restante='" + Convert.ToString(totRes) + "'";
                    Lectura_Base_Datos instancia2 = new();
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
            //En caso de que el cliente ya termino de pagar todo, se pasa a liquidados ***FALTA


        }
        #region Llenado de datos y verificación *Ingresar clientes*

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

        private void rjButton1_Click_1(object sender, EventArgs e)
        {
            Exportar_Excel a = new();
            a.ShowDialog();
        }

        private void btnGuardarCambio_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos a = new();
            if (ListaEstado == 0)
            {
                string[] informacion2 = new string[29];
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
                a.EditarLista1(informacion2);
                pnlListas.BringToFront();
            }
            else if (ListaEstado == 1)
            {
                string[] informacion2 = new string[16];
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
                informacion2[13] = Cliente;
                a.EditarLista2(informacion2);
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
                a.EditarLista3(informacion2);
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
                a.EditarListaLiquidados(informacion5);
                pnlListas.BringToFront();

            }

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Usuarios";
            Accesos a = new();
            panel2.BringToFront();
            string[] usuarios = a.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }
        private bool changingCheckedState = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool mensaje;
            Accesos a = new();
            string User = textBox1.Text.ToString();
            string password = TextboxContr.Text.ToString();
            if (string.IsNullOrEmpty(User))
            {
                AvisoVacio.Text = "No puede haber nada vacio";
            }
            else
            {
                mensaje = a.AgregarUsuario(User, password);
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
            Accesos a2 = new();
            panel2.BringToFront();
            string[] usuarios = a2.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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


        private void button3_Click(object sender, EventArgs e)
        {
            string usuario = comboBox1.SelectedItem.ToString();
            Accesos a = new();
            a.EliminarUsuario(usuario);
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            Accesos a = new();
            string user = textBox2.Text.ToString();
            string pass = textBox3.Text.ToString();
            a.EditarUsuarioContraseña(user, pass);
            textBox2.Text = "";
            textBox3.Text = "";
            AvisoVacio2.Text = "";
            comboBox1.SelectedIndex = -1;

            panel2.BringToFront();
            string[] usuarios = a.CargarUsuarios().ToArray();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(usuarios);
        }
    }
}