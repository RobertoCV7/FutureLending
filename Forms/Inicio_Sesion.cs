using FutureLending.Funciones.cs;

namespace FutureLending.Forms;

public partial class InicioSesion : Form
{
    public InicioSesion()
    {
        InitializeComponent();
        button1.Enabled = false;
    }

    private void PictureBox2_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        var cerrar = Accesos.Accesar(TextUsuario.Text, TextContra.Text);
        if (cerrar)
        {
            Program.Inicio = true;
            Program.NombreDeUsuario = TextUsuario.Text;
            Close();
        }
        else
        {
            Mensaje.Text = @"Usuario o Contraseña incorrectos ";
        }
    }

    private void BtnTodosSistemas_Click(object sender, EventArgs e)
    {
        using var a = new ConfiguracionInicioSesion();
        a.ShowDialog();
    }

    private void TextUsuario_TextChanged(object sender, EventArgs e)
    {
        button1.Enabled = !string.IsNullOrEmpty(TextUsuario.Text);
    }

    private void Inicio_Sesion_FormClosing(object sender, FormClosingEventArgs e)
    {
    }
}