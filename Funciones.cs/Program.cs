using System.Globalization;
using FutureLending.Forms;

namespace FutureLending.Funciones.cs;

internal static class Program
{
    public static bool Inicio = false;
    public static string NombreDeUsuario;

    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // Continuar con otras tareas en el hilo principal
        ApplicationConfiguration.Initialize();
        InicioSesion ini = new();
        ini.ShowDialog();
        if (!Inicio) return;
        var culture = new CultureInfo("es-MX");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        // Cargar el archivo de recursos específico para "es-MX"
        var form = new Form1();
        Application.Run(form);
    }
}