using FutureLending.Properties;

namespace FutureLending.Forms;

public partial class ConfiguracionInicioSesion : Form
{
    private readonly LecturaBaseDatos a = new();
    private CancellationTokenSource cancellationTokenSource; // Variable para cancelar la tarea
    private bool changingCheckedState3;
    private bool isTabPageLoaded;

    public ConfiguracionInicioSesion()
    {
        InitializeComponent();
        PingLabel.Hide();
        rjButton3_Click(null, null);
    }

    private async void rjButton3_Click(object sender, EventArgs e)
    {
        await a.CheckConnection(true);

        if (!Form1.Conect)
        {
            LabelEstado.Text = @"Inactivo";
            LabelEstado.ForeColor = Color.Red;
            LabelEstado.Location = new Point(266, 90);
            PingLabel.Hide();
            PingLabel.Location = new Point(577, 11);
        }
        else
        {
            LabelEstado.Text = @"Activo";
            LabelEstado.ForeColor = Color.Green;
            LabelEstado.Location = new Point(143, 89);
            PingLabel.Location = new Point(386, 89);

            cancellationTokenSource = new CancellationTokenSource();
            await Ping();
        }
    }

    private async Task Ping()
    {
        PingLabel.Show();
        while (!cancellationTokenSource.Token.IsCancellationRequested)
        {
            await a.CheckConnection(true);

            if (Form1.Conect)
            {
                var pin = await Task.Run(() => a.Ping());
                switch (Convert.ToInt32(pin))
                {
                    case > 75 and < 120:
                        PingLabel.ForeColor = Color.Orange;
                        PingLabel.Text = @"Ping: " + pin;
                        break;
                    case >= 120:
                        PingLabel.ForeColor = Color.Red;
                        PingLabel.Text = @"Ping: " + pin;
                        break;
                    default:
                        PingLabel.ForeColor = Color.Green;
                        PingLabel.Text = @"Ping: " + pin;
                        break;
                }
            }
            else
            {
                cancellationTokenSource.Cancel(); // Detener la tarea si la conexión no está activa
            }
        }
    }

    private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (tabControl1.SelectedIndex)
        {
            case 0:
                break;
            case 1:
                {
                    if (!isTabPageLoaded)
                    {
                        await LoadTabPage1Async();
                        isTabPageLoaded = true;
                    }

                    break;
                }
        }
    }

    private async Task LoadTabPage1Async()
    {
        await Task.Run(() =>
        {
            Invoke((Action)(() =>
            {
                TextServer.Text = Settings1.Default.Servidor;
                TextPuerto.Text = Settings1.Default.Puerto.ToString();
                TextBase.Text = Settings1.Default.Base_de_datos;
                TextUsuario.Text = Settings1.Default.Usuario;
                TextContra.Text = Settings1.Default.Contraseña;
            }));
        });
    }

    private void rjButton2_Click(object sender, EventArgs e)
    {
        var server = TextServer.Text;
        var puerto = TextPuerto.Text;
        var baseDeDatos = TextBase.Text ?? throw new ArgumentNullException(nameof(sender));
        var usuario = TextUsuario.Text;
        var contraseña = TextContra.Text;

        if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(puerto) || string.IsNullOrEmpty(baseDeDatos) ||
            string.IsNullOrEmpty(usuario))
        {
            Form1.MessageB("No puede haber nada vacio", "Error", 2);
        }
        else
        {
            Settings1.Default.Servidor = server;
            Settings1.Default.Puerto = Convert.ToInt32(puerto);
            Settings1.Default.Base_de_datos = baseDeDatos;
            Settings1.Default.Usuario = usuario;
            Settings1.Default.Contraseña = contraseña;
            Settings1.Default.Save();
            Form1.MessageB("Se guardaron los cambios", "Exito", 1);
        }
    }

    private async void rjButton1_Click(object sender, EventArgs e)
    {
        LecturaBaseDatos datos = new();
        await datos.CheckConnection(false);
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
        if (changingCheckedState3) return;
        changingCheckedState3 = true;

        // Desactivar el uso de contraseña
        TextContra.UseSystemPasswordChar = !checkBox3.Checked;
        // Activar el uso de contraseña
        changingCheckedState3 = false;
    }
}