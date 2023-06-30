using FutureLending.Funciones.cs;

namespace FutureLending.Forms
{
    public partial class Configuracion_Inicio_Sesion : Form
    {
        public Configuracion_Inicio_Sesion()
        {
            InitializeComponent();
            PingLabel.Hide();
            rjButton3_Click(null, null);
        }

        private static readonly Lectura_Base_Datos A = new();

        private CancellationTokenSource cancellationTokenSource; // Variable para cancelar la tarea

        private async void rjButton3_Click(object sender, EventArgs e)
        {
            await A.CheckConnection(true);

            if (!Form1.Conect)
            {
                LabelEstado.Text = @"Inactivo";
                LabelEstado.ForeColor = Color.Red;
                LabelEstado.Location = new Point(276, 111);
                PingLabel.Hide();
                PingLabel.Location = new Point(491, 14);
            }
            else
            {
                LabelEstado.Text = @"Activo";
                LabelEstado.ForeColor = Color.Green;
                LabelEstado.Location = new Point(149, 112);
                PingLabel.Location = new Point(384, 112);

                cancellationTokenSource = new CancellationTokenSource();
                await Ping();
            }
        }

        private async Task Ping()
        {
            PingLabel.Show();
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                await A.CheckConnection(true);

                var pin = await Task.Run(() => A.Ping());
                if (Form1.Conect)
                {
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
        private bool isTabPageLoaded;
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            {

            }
            else if (tabControl1.SelectedIndex == 1)
            {
                if (!isTabPageLoaded)
                {
                    await LoadTabPage1Async();
                    isTabPageLoaded = true;
                }
            }
            else
            {

            }
        }
        private async Task LoadTabPage1Async()
        {
            await Task.Run(() =>
            {
                Invoke((Action)(() =>
                {
                    TextServer.Text = Properties.Settings1.Default.Servidor;
                    TextPuerto.Text = Properties.Settings1.Default.Puerto.ToString();
                    TextBase.Text = Properties.Settings1.Default.Base_de_datos;
                    TextUsuario.Text = Properties.Settings1.Default.Usuario;
                    TextContra.Text = Properties.Settings1.Default.Contraseña;
                }));
            });
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            var server = TextServer.Text;
            var puerto = TextPuerto.Text;
            var baseDeDatos = TextBase.Text;
            var usuario = TextUsuario.Text;
            var contraseña = TextContra.Text;

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(puerto) || string.IsNullOrEmpty(baseDeDatos) || string.IsNullOrEmpty(usuario))
            {
                Form1.MessageB("No puede haber nada vacio", "Error", 2);
            }
            else
            {
                Properties.Settings1.Default.Servidor = server;
                Properties.Settings1.Default.Puerto = Convert.ToInt32(puerto);
                Properties.Settings1.Default.Base_de_datos = baseDeDatos;
                Properties.Settings1.Default.Usuario = usuario;
                Properties.Settings1.Default.Contraseña = contraseña;
                Properties.Settings1.Default.Save();
                Form1.MessageB("Se guardaron los cambios", "Exito", 1);
            }
        }

        private async void rjButton1_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos baseDatos = new();
            await baseDatos.CheckConnection(false);
        }
        private bool changingCheckedState3;
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!changingCheckedState3)
            {
                changingCheckedState3 = true;

                if (checkBox3.Checked)
                {
                    // Desactivar el uso de contraseña
                    TextContra.UseSystemPasswordChar = false;

                }
                else
                {
                    // Activar el uso de contraseña
                    TextContra.UseSystemPasswordChar = true;
                }

                changingCheckedState3 = false;
            }
        }

        private void Configuracion_Inicio_Sesion_Load(object sender, EventArgs e)
        {

        }
    }
}
