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
            dateFechaInicio.Value=data;
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
    }
}