namespace FutureLending
{
    //Este forms pide los datos faltantes para mover el registro de la lista 1 a la lista 2
    public partial class Pedir_Datos : Form
    {
        public Pedir_Datos()
        {
            InitializeComponent();
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
                    TextLiquidacionPedir.Text = "0";
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
            this.Close();
        }

        private void TextLiquidacionPedir__TextChanged(object sender, EventArgs e)
        {
            if (TextLiquidacionPedir.Texts != "")
            {
                BotonDeingresarPedir.Enabled = true;
            }
            else
            {
                BotonDeingresarPedir.Enabled = false;
            }
        }
        private bool mostrado = false;
        private void TextLiquidacionPedir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }

        private void Pedir_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Mover2)
            {
                if (rjComboBox2.SelectedIndex != -1)
                {
                    if (rjComboBox2.SelectedIndex != 0)
                    {
                        if (TextLiquidacionPedir.Texts == "" || TextLiquidacionPedir.Texts == null)
                        {
                            if (!mostrado)
                            {
                                Form1.MessageB("No puedes dejar nada sin seleccionar", "Aviso", 2);
                                e.Cancel = true;
                                mostrado = true;
                            }
                        }
                    }
                }
                else
                {
                    if (!mostrado)
                    {
                        Form1.MessageB("No puedes dejar nada sin seleccionar", "Aviso", 2);
                        e.Cancel = true;
                        mostrado = true;
                    }

                }
            }
           
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Mover2 = false;
            this.Close();   
        }
    }
}
