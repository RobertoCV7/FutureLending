using FutureLending.Funciones.cs;

namespace FutureLending.Forms
{
    //Este Forms muestra los permisos que cada usuario tiene acerca de la lectura de las listas ademas de las exportaciones
    public partial class PermisosLect : Form
    {
        public readonly string Nombre1;
        public PermisosLect(string nombre)
        {
            InitializeComponent();
            Label_User.Text = nombre;
            Nombre1 = nombre;
            Cargarpermisos(nombre);
        }

        private void Cargarpermisos(string name)
        {
            var perm = Accesos.ObtenerPermisosUsuario(name);
            foreach (var indice in perm.Select(permiso => checkedListBox1.FindStringExact(permiso)).Where(indice => indice != ListBox.NoMatches))
            {
                checkedListBox1.SetItemChecked(indice, true);
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            var permisosSeleccionados = (from object item in checkedListBox1.CheckedItems select item.ToString()).ToList();
            Accesos.EditarPermisosUsuario(Nombre1, permisosSeleccionados);
            Close();
        }
    }
}
