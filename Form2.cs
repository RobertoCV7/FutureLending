using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace FutureLending
{
    public partial class Form2 : Form
    {
        public Form2(string text, string titulo, int situacion)
        {
            InitializeComponent();
            string rutaAplicacion = Application.StartupPath;
            this.Text = titulo;
            Texto.Text = text;
            if (situacion == 1)
            {
                this.Icon = new Icon(rutaAplicacion + "\\Resources\\Correcto.ico");
                Image gif = Image.FromFile(rutaAplicacion + "\\Resources\\bailando.gif");
                pictureBox1.Image = gif;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
#pragma warning disable CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
                ImageAnimator.Animate(gif, OnFrameChanged);
#pragma warning restore CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
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
        private void OnFrameChanged(object sender, EventArgs e)
        {
            // Actualizar el PictureBox para mostrar el nuevo fotograma
            pictureBox1.Invalidate();
        }
        private void RjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
