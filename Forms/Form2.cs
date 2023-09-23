namespace FutureLending.Forms;

//Lo que hace este forms es mostrar un mensaje de error, alerta o correcto 
//Basicamente remplaza el MessageBox.Show de windows forms
public partial class Form2 : Form
{
    public Form2(string text, string titulo, int situacion)
    {
        InitializeComponent();
        var rutaAplicacion = Application.StartupPath ?? throw new ArgumentNullException(nameof(text));
        Text = titulo;
        // Obtén el tamaño del formulario
        var formSize = Size;

        // Asigna el texto al Label
        Texto.Text = text;
        // Asigna el texto al Label
        Texto.Text = text;
        int a = Texto.Width;
        a = this.Width - a;
        a /= 2;
        Texto.Location = new Point(a, 23); ;

        // Ajusta el tamaño de la fuente si es necesario
        while (Texto.PreferredWidth > formSize.Width || Texto.PreferredHeight > formSize.Height)
            Texto.Font = new Font(Texto.Font.FontFamily, Texto.Font.Size - 1); // Reduce el tamaño de fuente

        Icon = situacion switch
        {
            1 => new Icon(rutaAplicacion + "\\Resources\\Correcto.ico"),
            2 => new Icon(rutaAplicacion + "\\Resources\\Alerta.ico"),
            3 => new Icon(rutaAplicacion + "\\Resources\\TodoMal.ico"),
            _ => Icon
        };
    }

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    private void RjButton1_Click(object sender, EventArgs e)
    {
        Close();
    }
}