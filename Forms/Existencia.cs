namespace FutureLending.Forms
{
    public partial class Existencia : Form
    {
        public static string Nombre;
        public static string Lista;
        public static string ListaLiq = null;
        public Existencia()
        {
            InitializeComponent();
            label4.Hide();
            LabelLiquidacion.Hide();
            LabelNombre.Text = Nombre;
            LabelLista.Text = Lista;
            if (ListaLiq != "" && ListaLiq != null)
            {
                LabelLiquidacion.Text = ListaLiq;
                label4.Show();
                LabelLiquidacion.Show();
            }


        }
        private bool cerrar = false;
        private void rjButton2_Click(object sender, EventArgs e)
        {
            Form1.Guar = true;
            cerrar = true;
            this.Close();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Form1.Guar = false;
            cerrar = true;
            this.Close();
        }

        private void Existencia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrar)
            {
                e.Cancel = true;
            }

        }
    }
}
