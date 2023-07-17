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
    public partial class Existencia : Form
    {
        public static string Nombre;
        public static string Lista ;
        public static string ListaLiq;
        public Existencia()
        {
            InitializeComponent();
            LabelNombre.Text = Nombre;
            LabelLista.Text = Lista;
            if (ListaLiq != "")
            {
                LabelLiquidacion.Text = ListaLiq;
            }
            else
            {
                label4.Hide();
                LabelLiquidacion.Hide();
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
