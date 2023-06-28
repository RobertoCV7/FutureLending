﻿namespace FutureLending
{
    public partial class Exportar_Excel : Form
    {
        public Exportar_Excel()
        {
            InitializeComponent();
            datos();
            rjButton1.Enabled = false;
        }

        void datos()
        {

            if (Form1.Boton1 && Form1.Boton2 && Form1.Boton3 && Form1.Boton4)
            {
                comboBox1.Items.Add("Lista 1");
                comboBox1.Items.Add("Lista 2");
                comboBox1.Items.Add("Lista 3");
                comboBox1.Items.Add("Lista Liquidados");
                comboBox1.Items.Add("Todas las Listas");
            }
            else
            {
                if (Form1.Boton1)
                {
                    comboBox1.Items.Add("Lista 1");
                }
                if (Form1.Boton2)
                {

                    comboBox1.Items.Add("Lista 2");
                }
                if (Form1.Boton3)
                {
                    comboBox1.Items.Add("Lista 3");
                }
                if (Form1.Boton4)
                {
                    comboBox1.Items.Add("Lista Liquidados");
                }
            }
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
                switch (comboBox1.SelectedItem)
                {
                    case "Lista 1":
                        e2.ExportarLista1AExcel(rutaArchivo);
                        reiniciartodo();
                        break;
                    case "Lista 2":
                        e2.ExportarTabla2(rutaArchivo);
                        reiniciartodo();
                        break;
                    case "Lista 3":
                        e2.ExportarTabla3(rutaArchivo);
                        reiniciartodo();
                        break;
                    case "Lista Liquidados":
                        e2.ExportarTablaLiquidados(rutaArchivo);
                        reiniciartodo();
                        break;

                    case "Todas las Listas":
                        e2.ExportarTodasLasTablas(rutaArchivo);
                        reiniciartodo();
                        break;
                }
                this.Close();
            }
        }
        void reiniciartodo()
        {
            comboBox1.SelectedIndex = -1;
        }

        private void Exportar_Excel_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
            {
                rjButton1.Enabled = true;
            }
        }
    }
}
