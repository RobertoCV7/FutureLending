namespace FutureLending.Forms
{
    //Este forms pide los daros faltantes para mover algun usuario de lista1 o lista 2 a la lista 3
    public partial class PedirDatos3 : Form
    {
        public PedirDatos3()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBoxResolucion3_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxResolucion3.SelectedIndex != -1)
            {
                uno = true;
                Activar();
            }
            else
            {
                uno = false;
                Activar();
            }

        }

        private void TextImporte3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void Activar()
        {
            if (uno && dos && tres)
            {
                rjButton1.Enabled = true;

            }
            else
            {
                rjButton1.Enabled = false;
            }
        }

        private void PedirDatos3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Mover3) return;
            if (ComboBoxResolucion3.SelectedIndex != -1)
            {
                // ReSharper disable once RedundantJumpStatement
                if (ComboBoxResolucionD.SelectedIndex == -1)return;
            }
            else
            {
                Form1.MessageB("No se puede dejar si  seleccionar nada", "Advertencia", 2);
                e.Cancel = true;
            }

        }
        public bool Mover3 = true;

        public void rjButton2_Click(object sender, EventArgs e)
        {
            Mover3 = false;
            Close();
        }
        private bool uno;
        private bool dos;
        private bool tres;
        private void ComboBoxResolucionD_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxResolucion3.SelectedIndex != -1)
            {
                dos = true;
                Activar();
            }
            else
            {
                dos = false;
                Activar();
            }
        }

        private void TextImporte3TextChanged2EventHandler(object sender, EventArgs e)
        {
            if (TextImporte3.Texts != "")
            {
                tres = true;
                Activar();
            }
            else
            {
                tres = false;
                Activar();
            }
        }
    }
}
