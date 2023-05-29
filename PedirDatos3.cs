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
                rjButton1.Enabled = true;
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
    }
}
