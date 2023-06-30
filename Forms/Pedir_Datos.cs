namespace FutureLending.Forms
{
    //Este forms pide los datos faltantes para mover el registro de la lista 1 a la lista 2
    public partial class PedirDatos : Form
    {
        public PedirDatos()
        {
            InitializeComponent();
            FormClosing += Pedir_Datos_FormClosing;
        }
        public bool Mover2 = true;
        public void rjComboBox2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rjComboBox2.SelectedIndex != -1)
            {
                BotonDeingresarPedir.Enabled = true;

                if (rjComboBox2.SelectedIndex == 1)
                {
                    TextLiquidacionPedir.Enabled = false;
                    TextLiquidacionPedir.Text = @"0";
                }
                else
                {
                    TextLiquidacionPedir.Enabled = true;
                    TextLiquidacionPedir.Text = "";
                    BotonDeingresarPedir.Enabled = false;
                }
            }
            else
            {
                BotonDeingresarPedir.Enabled = false;
            }
        }

        private void BotonDeingresarPedir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextLiquidacionPedirTextChanged2EventHandler(object sender, EventArgs e)
        {
            BotonDeingresarPedir.Enabled = TextLiquidacionPedir.Texts != "";
        }

        private void TextLiquidacionPedir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        public bool Mostrado;
        private void Pedir_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Mover2) return;
            if (rjComboBox2.SelectedIndex == -1 || rjComboBox2.SelectedIndex == 1) return;
            if (TextLiquidacionPedir.Texts != "") return;
            Form1.MessageB("No se puede dejar el campo vacio", "Advertencia", 2);
            Mostrado = true;
            e.Cancel = true;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Mover2 = false;
            Close();
        }
    }
}
