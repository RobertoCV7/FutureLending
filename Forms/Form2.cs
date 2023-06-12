namespace FutureLending
{
    //Lo que hace este forms es mostrar un mensaje de error, alerta o correcto 
    //Basicamente remplaza el MessageBox.Show de windows forms
    public partial class Form2 : Form
    {
        public Form2(string text, string titulo, int situacion)
        {
            InitializeComponent();
            string rutaAplicacion = Application.StartupPath;
            this.Text = titulo;
            // Obtén el tamaño del formulario
            Size formSize = this.Size;

            // Asigna el texto al Label
            Texto.Text = text;
            Texto.TextAlign = ContentAlignment.MiddleCenter;

            // Ajusta el tamaño de la fuente si es necesario
            while (Texto.PreferredWidth > formSize.Width || Texto.PreferredHeight > formSize.Height)
            {
                Texto.Font = new Font(Texto.Font.FontFamily, Texto.Font.Size - 1); // Reduce el tamaño de fuente
            }

            if (situacion == 1)
            {
                this.Icon = new Icon(rutaAplicacion + "\\Resources\\Correcto.ico");
            }
            else if (situacion == 2)
            {
                this.Icon = new Icon(rutaAplicacion + "\\Resources\\Alerta.ico");
            }
            else if (situacion == 3)
            {
                this.Icon = new Icon(rutaAplicacion + "\\Resources\\TodoMal.ico");
            }
        }
        private void RjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
