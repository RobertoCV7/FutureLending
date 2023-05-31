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
