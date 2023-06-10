using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureLending.Forms
{
    public partial class Revision_Mover_Liquidados : Form
    {
        public Revision_Mover_Liquidados()
        {
            InitializeComponent();
        }
        private bool click = false;
        private void Revision_Mover_Liquidados_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!click)
            {
                Form1.MessageB("No se ha seleccionado ninguna opción", "Advertencia", 2);
                e.Cancel = true;
            }
        }
        public bool MoverLiq = true;
        private void rjButton1_Click(object sender, EventArgs e)
        {
            click = true;
            MoverLiq = false;
            this.Close();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            click = true;
            this.Close();
        }
    }
}
