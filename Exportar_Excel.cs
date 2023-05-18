using FutureLending.ControlesPersonalizados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureLending
{
    public partial class Exportar_Excel : Form
    {
        public Exportar_Excel()
        {
            InitializeComponent();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

            ExportarExcel e2 = new();
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*",
                Title = "Guardar archivo"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        e2.ExportarLista1AExcel(rutaArchivo);
                        reiniciartodo();
                        break;
                    case 1:
                        e2.ExportarTabla2(rutaArchivo);
                        reiniciartodo();
                        break;
                    case 2:
                        e2.ExportarTabla3(rutaArchivo);
                        reiniciartodo();
                        break;
                    case 3:
                        e2.ExportarTablaLiquidados(rutaArchivo);
                        reiniciartodo();
                        break;

                    case 4:
                        e2.ExportarTodasLasTablas(rutaArchivo);
                        reiniciartodo();
                        break;
                }
            }
        }
        void reiniciartodo()
        {
            comboBox1.SelectedIndex = -1;
        }
    }
}
