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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = Properties.Settings1.Default.Usuario;
            string contra = Properties.Settings1.Default.Contraseña;
            string usuariop = TextUsuario.Text.ToString();
            string contrap = TextContra.Text.ToString();
            bool cerrar = false;
            if (usuario.Equals(usuariop) && contra.Equals(contrap))
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
            if(cerrar == true)
            {
                this.Close();
            }


        }
    }
}
