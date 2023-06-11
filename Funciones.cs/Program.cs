using FutureLending.Funciones.cs;

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
            BackupService backupService = new BackupService();

            // Ejecutar StartBackup() en un hilo separado
            Task backupTask = Task.Run(() => backupService.StartBackup(true));

            // Continuar con otras tareas en el hilo principal
            ApplicationConfiguration.Initialize();
            Application.Run(new Inicio_Sesion());

            // Esperar a que finalice la copia de seguridad en el hilo separado

        }

    }
}