

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
            ApplicationConfiguration.Initialize();
            Inicio_Sesion inicio_Sesion = new Inicio_Sesion();
            inicio_Sesion.ShowDialog();
            if (iniciado)
            {

                Application.Run(new Form1());
            }

        }
        public static bool iniciado = false;
        public static string NombreUsuario;
    }
    
}