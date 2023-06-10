namespace FutureLending
{
    public partial class Inicio_Sesion : Form
    {
        public static string NombreUsuario { get; private set; }
        public Inicio_Sesion()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                form2.Size = new(1600, 900);
                form2.Show();

                this.Hide();
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

    }
}
