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
        public static string NombreUsuario { get; private set; }
        public Inicio_Sesion()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string usuario1;
        private void Button1_Click(object sender, EventArgs e)
        {
            string usuariop = TextUsuario.Text.ToString();
            NombreUsuario = usuariop;
            string contrap = TextContra.Text.ToString();
            bool cerrar;
            cerrar = Accesos.Accesar(usuariop, contrap);
            if (cerrar == true)
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

        private async void btnTodosSistemas_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos a = new();
            await a.CheckConnection(false);
        }
    }
}
