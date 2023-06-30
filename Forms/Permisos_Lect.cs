using FutureLending.Funciones.cs;

namespace FutureLending
{
    //Este Forms muestra los permisos que cada usuario tiene acerca de la lectura de las listas ademas de las exportaciones
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
