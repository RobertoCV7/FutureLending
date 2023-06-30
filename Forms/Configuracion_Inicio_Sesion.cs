namespace FutureLending
{
    public partial class Configuracion_Inicio_Sesion : Form
    {
        public Configuracion_Inicio_Sesion()
        {
            InitializeComponent();
            PingLabel.Hide();
            rjButton3_Click(null, null);
        }
        Lectura_Base_Datos a = new();
        private CancellationTokenSource cancellationTokenSource; // Variable para cancelar la tarea
        private async void rjButton3_Click(object sender, EventArgs e)
        {

            await a.CheckConnection(true);

            if (!Form1.conect)
            {
                LabelEstado.Text = "Inactivo";
                LabelEstado.ForeColor = Color.Red;
                LabelEstado.Location = new Point(266, 90);
                PingLabel.Hide();
                PingLabel.Location = new Point(577, 11);
            }
            else
            {
                LabelEstado.Text = "Activo";
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

                if (Form1.conect)
                {

                    string Pin = await Task.Run(() => a.Ping());
                    if (Convert.ToInt32(Pin) > 75 && Convert.ToInt32(Pin) < 120)
                    {
                        PingLabel.ForeColor = Color.Orange;
                        PingLabel.Text = "Ping: " + Pin;
                    }
                    else if (Convert.ToInt32(Pin) >= 120)
                    {
                        PingLabel.ForeColor = Color.Red;
                        PingLabel.Text = "Ping: " + Pin;
                    }
                    else
                    {
                        PingLabel.ForeColor = Color.Green;
                        PingLabel.Text = "Ping: " + Pin;
                    }
                }
                else
                {
                    cancellationTokenSource.Cancel(); // Detener la tarea si la conexión no está activa
                }
            }
        }
        private bool isTabPageLoaded = false;
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
            string server = TextServer.Text.ToString();
            string puerto = TextPuerto.Text.ToString();
            string base_de_datos = TextBase.Text.ToString();
            string usuario = TextUsuario.Text.ToString();
            string contraseña = TextContra.Text.ToString();

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(puerto) || string.IsNullOrEmpty(base_de_datos) || string.IsNullOrEmpty(usuario))
            {
                Form1.MessageB("No puede haber nada vacio", "Error", 2);
            }
            else
            {
                Properties.Settings1.Default.Servidor = server;
                Properties.Settings1.Default.Puerto = Convert.ToInt32(puerto);
                Properties.Settings1.Default.Base_de_datos = base_de_datos;
                Properties.Settings1.Default.Usuario = usuario;
                Properties.Settings1.Default.Contraseña = contraseña;
                Properties.Settings1.Default.Save();
                Form1.MessageB("Se guardaron los cambios", "Exito", 1);
            }
        }

        private async void rjButton1_Click(object sender, EventArgs e)
        {
            Lectura_Base_Datos a = new();
            await a.CheckConnection(false);
        }
        private bool changingCheckedState3 = false;
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
    }
}
