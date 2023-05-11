using Org.BouncyCastle.Utilities;
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void btnIngresarClientes_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Ingresar Clientes";
            pnlClientes.BringToFront();
        }

        private void btnListas_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Listas Completas";
            pnlListas.BringToFront();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos obj = new Lectura_Base_Datos();
            string Interes = cmbInteres.Texts.Replace("%", "");
            string MontoTotal = txtTotal.Texts.Replace("$", "");
            obj.create("lista1", txtNombre.Texts, txtCredito.Texts, dateFechaInicio.Value, Interes, MontoTotal, cmbPromotor.Texts, txtCalle.Texts, txtColonia.Texts, txtNumInt.Texts, txtNumExt.Texts, txtTelefono.Texts, txtCorreo.Texts, cmbTipo.SelectedIndex, "0");
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

        private void btnTodosSistemas_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            instancia.reacomodo_de_scripts();
            instancia.CheckConnection();
        }

        private void btnLista1_Click(object sender, EventArgs e)
        {
            TablaClientes.MostrarLista1(gridListas);
        }

        private void btnEstadoPagos_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Registrar pago";
            pnlRegPago.BringToFront();
            //Colocar en el ComBoxName a todas las personas que se pueden buscar 
            ComBoxName.Items.Clear();
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> lista1 = instancia.LectLista1();
            List<string[]> lista2 = instancia.LectLista2();
            //Agregamos los nombres de las dos listas
            for (int i = 0; i < lista1.Count; i++)
            {
                ComBoxName.Items.Add(lista1[i][0]);
            }
            for (int i = 0; i < lista2.Count; i++)
            {
                ComBoxName.Items.Add(lista2[i][0]);
            }
        }

        private void btnBuscarC_Click(object sender, EventArgs e)
        {
            //Buscar el cliente por nombre dentro de la base de datos para registrar un nuevo pago semanal/quincenal
            //Mostramos en el form
            lblCredito.Visible = true;
            txtBoxCredito.Visible = true;
            txtBoxMonto.Visible = true;
            lblFecha.Visible = true;
            lblMonto.Visible = true;
            DateTimeReg.Visible = true;
            btnMarcarP.Visible = true;
            //Agregamos los datos del cliente al form
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            string list;
            if (CombBoxLista.Texts == "Lista 1")
            {
                list = "lista1";
            }
            else { list = "lista2"; }
            string[] datos = instancia.LectName(list, ComBoxName.Texts);
            txtBoxCredito.Texts = datos[1];
            txtBoxMonto.Texts = datos[2];

        }

        private void btnCalcular_Click(object sender, EventArgs e)
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

        private void btnLista2_Click(object sender, EventArgs e)
        {
            TablaClientes.MostrarLista2(gridListas);
        }

        private void btnLista3_Click(object sender, EventArgs e)
        {
            TablaClientes.MostrarLista3(gridListas);
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            TablaClientes.MostrarTodos(gridListas);
        }

        private void btnLiquidados_Click(object sender, EventArgs e)
        {
            TablaClientes.MostrarLiquidados(gridListas);
        }

        private void btnMarcarP_Click(object sender, EventArgs e)
        {
            //Validar que se encuentre esa fecha
            bool band = false;
            //Obtener el valor seleccionado de fecha 
            string fecha = Convert.ToString(DateTimeReg.Value.ToShortDateString());
            label18.Text = fecha;
            //Leer las fechas registradas 
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            string list;
            if (CombBoxLista.Texts == "Lista 1")
            {
                list = "lista1";
            }
            else { list = "lista2"; }
            string[] datos = instancia.LectName(list, ComBoxName.Texts);
            for (int i = 12; i < datos.Length; i++)
            {
                if (datos[i] == fecha)
                {
                    band = true;
                }
            }
            if (!band) { MessageBox.Show("El cliente no cuenta con esa fecha."); }
            //Marcar como pagada ***
            if (band)
            {
                fecha += " - PAGADA";
                label18.Text = fecha;
                //Agregarlo a la base de datos modificado *** FALTA

            }
            //En caso de que el cliente ya termino de pagar todo, se pasa a liquidados ***FALTA
            //Si no pagan a tiempo el interes crece *** FALTA
        }

        private void pnlClientes_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Llenado de datos y verificación *Ingresar clientes*

        private void SoloNumerosDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as Controles_personalizados.TextBoxPersonalizado).Texts.IndexOf('.') > -1))
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
            foreach (Controles_personalizados.TextBoxPersonalizado txtDato in
                pnlClientes.Controls.OfType<Controles_personalizados.TextBoxPersonalizado>())
            {
                if (string.IsNullOrEmpty(txtDato.Texts))
                {
                    activar = false;
                    return activar;
                }
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

        #endregion
    }
}