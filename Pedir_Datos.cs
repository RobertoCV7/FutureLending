using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureLending
{
    public partial class Pedir_Datos : Form
    {
        public Pedir_Datos()
        {
            InitializeComponent();
        }

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

        private void TextLiquidacionPedir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento KeyPress
                e.Handled = true;
            }
        }
    }
}
