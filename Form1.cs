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

        private void rjButton2_Click(object sender, EventArgs e)
        {

        }

        private void dateFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateFechaInicio.Value.ToString("yyyy-MM-dd"));
        }

        private void pnlListas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTodosSistemas_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            instancia.CheckConnection();
        }

        private void btnLista1_Click(object sender, EventArgs e)
        {
            string lista = "lista1";
            MostrarTablaListas(lista);
        }

        private void btnEstadoPagos_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Registrar pago";
            pnlRegPago.BringToFront();
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click_1(object sender, EventArgs e)
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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPersonalizado1__TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxPersonalizado2__TextChanged(object sender, EventArgs e)
        {
        }

        private void rjButton2_Click_2(object sender, EventArgs e)
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
            MostrarTablaListas(lista);
        }

        private void btnLista3_Click(object sender, EventArgs e)
        {
            string lista = "lista3";
            MostrarTablaListas(lista);
        }

        //Muestra en la tabla los datos de la lista correspondiente
        void MostrarTablaListas(string lista)
        {
            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "PROMOTOR",
                                        "CALLE", "COLONIA", "N�M. INT.", "N�M. EXT.", "TEL�FONO",
                                        "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);
            //A�ade los strings de cada fecha a la lista
            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
            }

            //Lectura de datos de la lista 1
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> datos = instancia.Lect(lista);

            //A�ade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = ObtenerColumnas(datos);
            for (int i = 0; i < gridListas.ColumnCount; i++)
            {
                gridListas.Columns[i].Name = nombresColumnas[i];
            }

            //Se a�aden las filas y el contenido respectivo de cada celda
            gridListas.RowCount = datos.Count;
            for (int i = 0; i < gridListas.RowCount; i++)
            {
                for (int j = 0; j < gridListas.ColumnCount; j++)
                {
                    gridListas.Rows[i].Cells[j].Value = datos[i][j];
                }
            }
        }

        //Para determinar si son necesarias 26 o 19 columnas para las fechas
        int ObtenerColumnas(List<string[]> datos)
        {
            int fechas = 19;
            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i][11] == "Semanal")
                {
                    fechas = 26;
                    return fechas;
                }
            }
            return fechas;
        }
    }
}