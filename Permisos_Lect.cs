using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FutureLending.Accesos;

namespace FutureLending
{
    public partial class Permisos_Lect : Form
    {
        string nombre1;
        public Permisos_Lect(string nombre)
        {
            InitializeComponent();
            Label_User.Text = nombre;
            nombre1 = nombre;
            cargarpermisos(nombre);
        }
        void cargarpermisos(string name)
        {

            List<string> perm = Accesos.ObtenerPermisosUsuario(name);
            foreach (var permiso in perm)
            {
                int indice = checkedListBox1.FindStringExact(permiso);
                if (indice != ListBox.NoMatches)
                {
                    checkedListBox1.SetItemChecked(indice, true);
                }
            }



        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            List<string> permisosSeleccionados = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                permisosSeleccionados.Add(item.ToString());
            }
            Accesos.EditarPermisosUsuario(nombre1, permisosSeleccionados);
            this.Close();
        }
    }
}
