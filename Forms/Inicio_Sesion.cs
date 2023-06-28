using FutureLending.Funciones.cs;

namespace FutureLending
{
    public partial class Inicio_Sesion : Form
    {
        public Inicio_Sesion()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            BackupService ob = new();
            ob.StopBackup();
            this.Close();

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            bool cerrar;
            cerrar = Accesos.Accesar(TextUsuario.Text, TextContra.Text);
            if (cerrar)
            {
                Program.inicio = true;
                Program.NombreDeUsuario = TextUsuario.Text;
                this.Close();
            }
            else
            {
                Mensaje.Text = "Usuario o Contraseña incorrectos ";
            }
        }

        private void BtnTodosSistemas_Click(object sender, EventArgs e)
        {
            using (Configuracion_Inicio_Sesion a = new Configuracion_Inicio_Sesion())
            {
                a.ShowDialog();
            }
        }

        private void TextUsuario_TextChanged(object sender, EventArgs e)
        {
            if (TextUsuario.Text != null && TextUsuario.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void Inicio_Sesion_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
