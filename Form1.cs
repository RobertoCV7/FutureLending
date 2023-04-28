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
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "PROMOTOR",
                                        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO",
                                        "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>();
            nombresColumnas.AddRange(nombresString);

            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
            }

            gridListas.ColumnCount = 26;

            for (int i = 0; i < gridListas.ColumnCount; i++)
            {
                gridListas.Columns[i].Name = nombresColumnas[i];
            }
        }
    }
}