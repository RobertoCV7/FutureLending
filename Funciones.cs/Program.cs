using System.Globalization;
using ResourceManager = System.Resources.ResourceManager;

namespace FutureLending
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Continuar con otras tareas en el hilo principal
            ApplicationConfiguration.Initialize();
            Inicio_Sesion ini = new();
            ini.ShowDialog();
            if (inicio)
            {
                Lectura_Base_Datos a = new();
                a.CheckConnection(true);
                CultureInfo culture = new CultureInfo("es-MX");
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;

                // Cargar el archivo de recursos específico para "es-MX"
                ResourceManager resourceManager = new ResourceManager("Form1.es-MX", typeof(Form1).Assembly);
                Form1 form = new Form1();
                Application.Run(form);
            }

        }
        public static bool inicio = false;
        public static string NombreDeUsuario;
    }
}