

using FutureLending.Forms;

namespace FutureLending.Funciones.cs
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var inicioSesion = new Inicio_Sesion();
            inicioSesion.ShowDialog();
            if (Iniciado)
            {

                // Establecer el idioma de la aplicación en español México
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-MX");

                Application.Run(new Form1());
            }
        }
        public static bool Iniciado = false;
        public static string NombreUsuario;
    }
    
}