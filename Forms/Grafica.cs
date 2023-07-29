using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Drawing;
using System.IO;
using PdfSharpCore.Pdf.IO;
using FontAwesome.Sharp;
using System.Web.Services.Description;

namespace FutureLending.Forms
{
    public partial class Grafica : Form
    {
        Chart graficaPastel;
        public Grafica()
        {
            InitializeComponent();
            // Llamar a la función para crear la gráfica de pastel      
            // Agregar el control Chart al formulario
            graficaPastel = CrearGraficaPastel(Form1.nombre, Form1.valor1, Form1.valor2);

            // Agregar el control Chart al panel en el formulario
            panel1.Controls.Add(graficaPastel);
        }


        private Chart CrearGraficaPastel(string titulo, int valor1, int valor2)
        {
            // Crear el objeto de la gráfica
            var chart = new Chart();

            // Configurar la gráfica
            chart.Location = new Point(1, 0);
            chart.Size = new Size(476, 502);

            // Agregar un ChartArea
            chart.ChartAreas.Add(new ChartArea("Area"));

            // Configurar el ChartArea para ajustar el tamaño de la gráfica
            chart.ChartAreas["Area"].Position = new ElementPosition(10, 10, 80, 70);
            chart.ChartAreas["Area"].InnerPlotPosition = new ElementPosition(0, 10, 100, 80);

            // Crear el título y ajustar su tamaño
            Title title = new Title(titulo);
            title.Font = new Font("Arial", 20, FontStyle.Bold); // Tamaño de fuente aumentado
            chart.Titles.Add(title);

            // Agregar un TextAnnotation para el texto adicional debajo del título
            TextAnnotation textAnnotation = new TextAnnotation();
            textAnnotation.Text = "Total del Credito Prestado = $" + Form1.valor3;
            textAnnotation.Font = new Font("Corbel", 16, FontStyle.Bold); // Tamaño de fuente del texto adicional
            textAnnotation.Alignment = ContentAlignment.TopCenter;
            textAnnotation.X = chart.ChartAreas["Area"].Position.X + chart.ChartAreas["Area"].InnerPlotPosition.Width - 100; // Posición X del TextAnnotation debajo del título
            textAnnotation.Y = title.Position.Y + title.Font.Height - 20; // Posición Y del TextAnnotation debajo del título
            chart.Annotations.Add(textAnnotation);

            // Agregar los datos a la gráfica
            chart.Series.Add(new Series("Data"));
            chart.Series["Data"].ChartType = SeriesChartType.Pie;

            // Agregar los puntos a la serie con el texto personalizado en la leyenda
            float porcen1 = (float)valor1 / (float)Form1.valor3 * 100;
            float porcen2 = (float)valor2 / (float)Form1.valor3 * 100;

            chart.Series["Data"].Points.AddXY(valor1, valor1);
            chart.Series["Data"].Points[0].LegendText = $"Morosidad ({porcen1.ToString("F2")}%)"; // Agregar el porcentaje en la leyenda

            chart.Series["Data"].Points.AddXY(valor2, valor2);
            chart.Series["Data"].Points[1].LegendText = $"Pagos Completos ({porcen2.ToString("F2")}%)"; // Agregar el porcentaje en la leyenda

            // Asignar el ChartArea a la Serie
            chart.Series["Data"].ChartArea = "Area";

            // Mostrar los valores en el gráfico
            chart.Series["Data"].IsValueShownAsLabel = true;

            // Agregar una leyenda
            chart.Legends.Add(new Legend("Legend"));
            chart.Legends["Legend"].Docking = Docking.Bottom; // Posicionar la leyenda debajo del gráfico
            chart.Series["Data"].Legend = "Legend";
            chart.Legends["Legend"].Font = new Font("Corbel", 16, FontStyle.Bold); // Tamaño de fuente de la leyenda "Legend"
            chart.Series["Data"].IsVisibleInLegend = true;

            return chart;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Establecer las propiedades del SaveFileDialog
            saveFileDialog.Filter = "Archivo PDF|*.pdf";
            saveFileDialog.Title = "Guardar PDF";
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.AddExtension = true;

            // Mostrar el SaveFileDialog y comprobar si el usuario hizo clic en el botón "Guardar"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta del archivo seleccionada por el usuario
                string rutaArchivoPDF = saveFileDialog.FileName;
                ExportarGraficaAPDF(graficaPastel, rutaArchivoPDF);
            }
            this.Close();
        }


        public static void ExportarGraficaAPDF(Chart chart, string rutaArchivoPDF)
        {
            // Crear un documento PDF
            PdfDocument document = new PdfDocument();

            // Agregar una página al documento
            PdfPage page = document.AddPage();

            // Obtener el objeto XGraphics para dibujar en la página
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Definir el tamaño de la gráfica en el PDF (puedes ajustar los valores según tus necesidades)
            int chartWidth = 476;
            int chartHeight = 502;

            // Crear un objeto Bitmap para guardar la gráfica como imagen
            using (Bitmap bitmap = new Bitmap(chartWidth, chartHeight))
            {
                // Renderizar la gráfica en el objeto Bitmap
                chart.DrawToBitmap(bitmap, new Rectangle(0, 0, chartWidth, chartHeight));

                // Convertir el objeto Bitmap a un array de bytes
                byte[] imageBytes;
                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    imageBytes = ms.ToArray();
                }

                // Crear un Func<Stream> que devuelva el MemoryStream con la imagen
                Func<Stream> imageStreamFunc = () => new MemoryStream(imageBytes);

                // Leer la imagen desde el Func<Stream>
                XImage xImage = XImage.FromStream(imageStreamFunc);

                // Dibujar la imagen de la gráfica en la página del PDF
                gfx.DrawImage(xImage, new XRect((page.Width - chartWidth) / 2, 50, chartWidth, chartHeight));
            }

            // Guardar el documento PDF en el archivo
            document.Save(rutaArchivoPDF);

        }
    }
}
