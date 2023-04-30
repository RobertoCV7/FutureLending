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
            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "PROMOTOR",
                                        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO",
                                        "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);
            //Añade los strings de cada fecha a la lista
            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
            }

            //Lectura de datos de la lista 1
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> datos = instancia.Lect("lista1");

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = ObtenerColumnas(datos);
            for (int i = 0; i < gridListas.ColumnCount; i++)
            {
                gridListas.Columns[i].Name = nombresColumnas[i];
            }

            //Se añaden las filas y el contenido respectivo de cada celda
            gridListas.RowCount = datos.Count;
            for (int i = 0; i < gridListas.RowCount; i++)
            {
                for(int j = 0; j < gridListas.ColumnCount; j++)
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