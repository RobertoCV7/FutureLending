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
    public partial class Inicio_Sesion : Form
    {
        public Inicio_Sesion()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string usuariop = TextUsuario.Text.ToString();
            string contrap = TextContra.Text.ToString();
            bool cerrar;
            cerrar= Accesos.Accesar(usuariop, contrap);
            if (cerrar== true)
            {
                // Crear e iniciar el nuevo formulario
                Form1 form2 = new Form1();
                form2.Show();
                this.Hide();
            }
            else
            {
                Mensaje.Text = "Usuario o Contraseña incorrectos ";
            }
        }
        private void Inicio_Sesion_Load(object sender, EventArgs e)
        {

        }

        private void TextContra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
