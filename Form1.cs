namespace FutureLending
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CollapseMenu();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            MessageBox.Show(dateFechaInicio.Value.ToString("yyyy-MM-dd"));
        }

        private void btnTodosSistemas_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            instancia.CheckConnection();
        }

        private void btnLista1_Click(object sender, EventArgs e)
        {
            string lista = "lista1";
            TablaClientes.MostrarTablaListas(lista, gridListas);
        }

        private void btnEstadoPagos_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Registrar pago";
            pnlRegPago.BringToFront();
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
            DateTime1.Visible = true;
            btnMarcarP.Visible = true;
            //Agregamos los datos del cliente al form
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            string[] datos = instancia.LectName("lista1", ComBoxName.Texts);
            txtBoxCredito.Texts = datos[1];
            txtBoxMonto.Texts = datos[2];//FALTA AGREGAR MONTO A LA BASE DE DATOS *PENDIENTE
            //Validar que se encuentre esa fecha ***

            //Marcar como pagada ***

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            String credito = txtCredito.Texts;
            Double credito2 = Convert.ToDouble(credito);
            String interes = txtInteres.Texts;
            Double interes2 = Convert.ToDouble(interes);

            Double tasa_interes = (interes2 * credito2) / 100;
            Double monto_total = credito2 + tasa_interes;

            textBoxPersonalizado1.Texts = ("$") + monto_total.ToString();
            Double monto_segun_tipo = 0;

            if (cmbTipo.Texts == "Semanales")
            {
                monto_segun_tipo = monto_total / 14;
                textBoxPersonalizado2.Texts = ("$") + monto_segun_tipo.ToString();
            }
            if (cmbTipo.Texts == "Quincenales")
            {
                monto_segun_tipo = monto_total / 7;
                textBoxPersonalizado2.Texts = ("$") + monto_segun_tipo.ToString();
            }
        }

        private void btnLista2_Click(object sender, EventArgs e)
        {
            string lista = "lista2";
            TablaClientes.MostrarTablaListas(lista, gridListas);
        }

        private void btnLista3_Click(object sender, EventArgs e)
        {
            string lista = "lista3";
            TablaClientes.MostrarTablaListas(lista, gridListas);
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            TablaClientes.MostrarTodos(gridListas);
        }

        private void btnLiquidados_Click(object sender, EventArgs e)
        {
            string tabla = "liquidados";
            TablaClientes.MostrarTablaListas(tabla, gridListas);
        }
    }
}