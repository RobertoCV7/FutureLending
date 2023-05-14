using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Utilities;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Automation;

namespace FutureLending
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CollapseMenu();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //Para una visualizaci�n m�s r�pida de los datos mediante virtualizaci�n
            gridListas.VirtualMode = true;
            TablaClientes.A�adirEvento(gridListas);
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
                panelMenu.Width = 230;
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
            obj.Create("lista1", txtNombre.Texts, txtCredito.Texts, dateFechaInicio.Value, Interes, MontoTotal, cmbPromotor.Texts, txtCalle.Texts, txtColonia.Texts, txtNumInt.Texts, txtNumExt.Texts, txtTelefono.Texts, txtCorreo.Texts, cmbTipo.SelectedIndex, "0");
            //Borrar datos para poder agregar de nuevo 
            txtNombre.Texts = "";
            txtCredito.Texts = "";
            dateFechaInicio.Value = new DateTime(2023, 5, 14, 16, 8, 19, 357);
            cmbInteres.Texts = "Seleccione un inter�s";
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
            Lectura_Base_Datos.ReacomodoDeScripts();
            _ = instancia.CheckConnection();
        }

        private void BtnEstadoPagos_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Registrar pago";
            pnlRegPago.BringToFront();

            // Iniciar el hilo de fondo
            BackgroundWorker worker = new();
#pragma warning disable CS8622 // La nulabilidad de los tipos de referencia del tipo de par�metro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
            worker.DoWork += Worker_DoWork;
#pragma warning restore CS8622 // La nulabilidad de los tipos de referencia del tipo de par�metro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
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
                MessageBox.Show("No se encontro al usuario en esa Lista");
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

        private void BtnLista1_Click(object sender, EventArgs e)
        {
            _ = TablaClientes.MostrarTodos(gridListas, 1);
        }

        private void BtnLista2_Click(object sender, EventArgs e)
        {
            _ = TablaClientes.MostrarTodos(gridListas, 2);
        }

        private void BtnLista3_Click(object sender, EventArgs e)
        {
            _ = TablaClientes.MostrarTodos(gridListas, 3);
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            _ = TablaClientes.MostrarTodos(gridListas, 4);
        }

        private void BtnLiquidados_Click(object sender, EventArgs e)
        {
            _ = TablaClientes.MostrarTodos(gridListas, 5);
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
            if (!band) { MessageBox.Show("El cliente no cuenta con esa fecha."); }
            //Marcar como pagada en la base de datos
            if (band)
            {
                Fecha += "-" + txtBoxMonto.Texts;
                string update = "Fecha" + index + "='" + Fecha + "'";
                Lectura_Base_Datos instancia2 = new();
                instancia2.Edit(list, ComBoxName.Texts, update);
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
        #region Llenado de datos y verificaci�n *Ingresar clientes*

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
            //Verificar que est�n los datos llenos para activar los botones
            bool activar = true;
            //TextBox
            foreach (Controles_personalizados.TextBoxPersonalizado txtDato in pnlClientes.Controls.OfType<Controles_personalizados.TextBoxPersonalizado>())
            {
                // Omitir la verificaci�n para ciertos controles
                if (txtDato.Name == "txtNumInt" || txtDato.Name == "txtNumExt")
                {
                    continue; // Saltar a la siguiente iteraci�n del bucle e ignora esos controles
                }

                if (string.IsNullOrEmpty(txtDato.Texts))
                {
                    activar = false;
                    return activar;
                }
            }

            // Verificar si los campos "txtNumInt" y "txtNumExt" est�n vac�os si ambos lo estan no activa el boton
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
            //Verificar que est�n los datos llenos para activar los botones
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
            //Verificar que est�n los datos llenos para activar los botones
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


    }
}