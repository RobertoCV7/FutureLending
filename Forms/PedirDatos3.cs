namespace FutureLending
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
            this.Close();
        }

        private void ComboBoxResolucion3_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxResolucion3.SelectedIndex != -1)
            {
                if (ComboBoxResolucionD.SelectedIndex != -1)
                {
                    if (TextImporte3.Texts != "" || TextImporte3.Texts != null)
                    {
                        rjButton1.Enabled = true;
                    }
                }
            }
            else
            {
                rjButton1.Enabled = false;
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

        private void PedirDatos3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Mover3)
            {
                if (ComboBoxResolucion3.SelectedIndex != -1)
                {
                    if (ComboBoxResolucionD.SelectedIndex != -1)
                    {
                        if (TextImporte3.Texts != "" || TextImporte3.Texts != null)
                        {

                        }
                    }
                }
                else
                {
                    Form1.MessageB("No se puede dejar si  seleccionar nada", "Advertencia", 2);
                    e.Cancel = true;
                }
            }
   
        }
        public bool Mover3 = true;
        private void rjButton2_Click(object sender, EventArgs e)
        {
            Mover3 = false;
            this.Close();
        }
    }
}
