using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace FutureLending.Forms
{
    public partial class Existencia : Form
    {
        string nombre = Form1.Nom;
        string lista = Form1.Lis;
        string liquidacion = Form1.Liq;

        public Existencia()
        {
            InitializeComponent();
            cargar();

        }
        void cargar()
        {
            LabelNombre.Text = nombre;
            LabelLista.Text = lista;
            if (liquidacion != null)
            {
                LabelLiquidacion.Text = liquidacion;
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
