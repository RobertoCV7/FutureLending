namespace FutureLending
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CollapseMenu();
            panelDesktop.Hide();
            panelTitleBar.Hide();
            DateTime data = new DateTime();
            data = DateTime.Now;
            dateFechaInicio.Value = data;
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

        private void dateFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnIngresarClientes_Click(object sender, EventArgs e)
        {
            panelDesktop.Show();
            panelTitleBar.Show();
        }

        private void textBoxPersonalizado2__TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            String cre = txtCredito.Texts;
            Decimal credito = Convert.ToDecimal(cre);
            String por = textBoxPersonalizado2.Texts;
            Decimal porcentaje = Convert.ToDecimal(por);

            Decimal interes_total = (porcentaje * credito) / 100;
            Decimal monto_total = credito + interes_total;

            textBoxPersonalizado4.Texts = ("$") + interes_total.ToString();
            textBoxPersonalizado6.Texts = ("$") + monto_total.ToString();
            Decimal monto_segun = 0;

            if (comboBox1.Text == "Semanales")
            {
                monto_segun = monto_total / 14;
                textBoxPersonalizado5.Texts = ("$") + monto_segun.ToString();
            }
            if (comboBox1.Text == "Quincenales")
            {
                monto_segun = monto_total / 7;
                textBoxPersonalizado5.Texts = ("$") + monto_segun.ToString();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}