using FutureLending.Funciones.cs;

namespace FutureLending.Forms
{
    public partial class Agregar_Columnas : Form
    {
        public Agregar_Columnas()
        {
            InitializeComponent();
        }

        private void textBoxPersonalizado1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Ediciones ed = new();
            ed.AgregarColumnasTabla(Convert.ToInt32(textBoxPersonalizado1.Texts));
            this.Close();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
