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
    public partial class Comprobacion_Mover_Liq : Form
    {
        public Comprobacion_Mover_Liq()
        {
            InitializeComponent();
        }
        private bool click = false;
        public bool Mover4;
        private void rjButton2_Click(object sender, EventArgs e)
        {
            Mover4 = true;
            click = true;
            this.Close();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Mover4 = false;
            click = true;
            this.Close();
        }

        private void Comprobacion_Mover_Liq_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!click)
            {
                Form1.MessageB("Debes seleccionar una opcion", "Advertencia", 2);
                e.Cancel = true;
            }
        }
    }
}
