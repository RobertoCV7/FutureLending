using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FutureLending.Funciones.cs;
using FutureLending.Forms;

namespace FutureLending.Forms
{
    public partial class Administrador_Acceso : Form
    {
        public Administrador_Acceso()
        {
            InitializeComponent();
            rjButton1.Enabled = false;
            label4.Hide();
        }
        bool Correcto = false;
        private void rjButton1_Click(object sender, EventArgs e)
        {
            Accesos a = new();
            Correcto = a.ValidarAsministrador(TextBoxUsuario.Texts, TextBoxContra.Texts);
            if (Correcto)
            {
                Form1.admin = true;
                this.Close();

            }
            else
            {
                label4.Show();
                Form1.admin = false;
            }

        }

        private void TextBoxUsuario__TextChanged(object sender, EventArgs e)
        {
            if (TextBoxUsuario.Texts != "")
            {
                rjButton1.Enabled = true;
            }
            else
            {
                rjButton1.Enabled = false;
            }

        }
    }
}
