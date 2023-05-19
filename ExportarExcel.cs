using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Style;
using OfficeOpenXml;

namespace FutureLending
{
    internal class ExportarExcel
    {
        readonly Lectura_Base_Datos a = new();

        string[] Nombres_Lista1 = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                              "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                              "TIPO DE PAGO", "MONTO RESTANTE"};
        string[] Nombres_Lisat2 = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERES", "MONTO TOTAL", "PROMOTOR",
                                "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                                "TIPO DE PAGO", "MONTO RESTANTE", "FECHA LÍMITE" };
        string[] Nombres_Listas3 = { "NOMBRE", "CREDITO", "FECHA INICIO", "INTERES", "MONTO TOTAL", "PROMOTOR",
                                "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                                "TIPO DE PAGO","MONTO RESTANTE"}; 
    string[] Nombres_ListasLiq = { "NOMBRE", "CREDITO", "FECHA INICIO", "FECHA ÚLTIMO PAGO", "INTERESES",
                              "MONTO TOTAL", "PROMOTOR", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
                              "TELÉFONO", "CORREO", "TIPO DE PAGO"};


        public void ExportarLista1AExcel(string rutaArchivo)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;        
            // Añade los strings de cada fecha y pago a la lista
            List<string> nombresColumnas = new (Nombres_Lista1);
            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
                nombresColumnas.Add("PAGO " + i);
            }

            // Lectura de datos de la lista correspondiente en un hilo separado
            List<string[]> datosList = a.LectLista1();

            // Crear el archivo Excel y la hoja de trabajo
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Lista1");

            // Añadir los nombres de las columnas
            for (int col = 0; col < nombresColumnas.Count; col++)
            {
                worksheet.Cells[1, col + 1].Value = nombresColumnas[col];
                worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                worksheet.Cells[1, col + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, col + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }

            // Agregar los datos a las filas del archivo Excel
            for (int row = 0; row < datosList.Count; row++)
            {
                string[] rowData = datosList[row];
                for (int col = 0; col < rowData.Length; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = rowData[col];
                }
            }

            // Ajustar el ancho de las columnas
            worksheet.Cells.AutoFitColumns();

            // Guardar el archivo Excel
            FileInfo file = new(rutaArchivo);
            package.SaveAs(file);
        }
        public void ExportarTabla2(string ruta)
        {
            List<string[]> datos = a.LectLista2();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Crea un nuevo archivo Excel
            using var package = new ExcelPackage();
            // Agrega una hoja al libro de Excel
            var worksheet = package.Workbook.Worksheets.Add("Lista2");

            // Escribe los nombres de las columnas en el archivo Excel
            for (int col = 0; col < Nombres_Lisat2.Length; col++)
            {
                worksheet.Cells[1, col + 1].Value = Nombres_Lisat2[col];
                worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                worksheet.Cells[1, col + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, col + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }

            // Escribe los datos en el archivo Excel
            for (int row = 0; row < datos.Count; row++)
            {
                string[] fila = datos[row];
                for (int col = 0; col < fila.Length; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = fila[col];
                }
            }

            // Aplica formato a los datos en el archivo Excel
            worksheet.Cells.AutoFitColumns();
            worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            // Guarda el archivo Excel en el disco
            package.SaveAs(ruta);
        }
        public void ExportarTabla3(string ruta)
        {
            List<string[]> datos = a.LectLista3();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Crea un nuevo archivo Excel
            using var package = new ExcelPackage();
            // Agrega una hoja al libro de Excel
            var worksheet = package.Workbook.Worksheets.Add("Lista3");

            // Escribe los nombres de las columnas en el archivo Excel
            for (int col = 0; col < Nombres_Listas3.Length; col++)
            {
                worksheet.Cells[1, col + 1].Value = Nombres_Listas3[col];
                worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                worksheet.Cells[1, col + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, col + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }

            // Escribe los datos en el archivo Excel
            for (int row = 0; row < datos.Count; row++)
            {
                string[] fila = datos[row];
                for (int col = 0; col < fila.Length; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = fila[col];
                }
            }

            // Aplica formato a los datos en el archivo Excel
            worksheet.Cells.AutoFitColumns();
            worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            // Guarda el archivo Excel en el disco
            package.SaveAs(ruta);
        }
        public void ExportarTablaLiquidados(string ruta)
        {
            List<string[]> datos = a.LectLiquidados();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Crea un nuevo archivo Excel
            using var package = new ExcelPackage();
            // Agrega una hoja al libro de Excel
            var worksheet = package.Workbook.Worksheets.Add("Liquidados");

            // Escribe los nombres de las columnas en el archivo Excel
            for (int col = 0; col < Nombres_ListasLiq.Length; col++)
            {
                worksheet.Cells[1, col + 1].Value = Nombres_ListasLiq[col];
                worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                worksheet.Cells[1, col + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, col + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }

            // Escribe los datos en el archivo Excel
            for (int row = 0; row < datos.Count; row++)
            {
                string[] fila = datos[row];
                for (int col = 0; col < fila.Length; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = fila[col];
                }
            }

            // Aplica formato a los datos en el archivo Excel
            worksheet.Cells.AutoFitColumns();
            worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            // Guarda el archivo Excel en el disco
            package.SaveAs(ruta);
        }

        public void ExportarTodasLasTablas(string ruta)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<string[]> datosLista1 = a.LectLista1();
            List<string[]> datosLista2 = a.LectLista2();
            List<string[]> datosLista3 = a.LectLista3();
            List<string[]> datosLiquidados = a.LectLiquidados();

                    // Crea un nuevo archivo Excel

            List<string> nombresColumnas = new(Nombres_Lista1);
            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
                nombresColumnas.Add("PAGO " + i);
            }
            using var package = new ExcelPackage();
            // Agrega una hoja para cada lista de datos
            AgregarHojaDatos(package, datosLista1, "Lista1", nombresColumnas.ToArray());
            AgregarHojaDatos(package, datosLista2, "Lista2", Nombres_Lisat2);
            AgregarHojaDatos(package, datosLista3, "Lista3", Nombres_Listas3);
            AgregarHojaDatos(package, datosLiquidados, "Liquidados", Nombres_ListasLiq);

            // Guarda el archivo Excel en el disco
            package.SaveAs(ruta);
        }

        private static void AgregarHojaDatos(ExcelPackage package, List<string[]> datos, string nombreHoja, string[] nombresColumnas)
        {
            if (string.IsNullOrWhiteSpace(nombreHoja) || nombreHoja.Length > 31 || nombreHoja.Any(c => Path.GetInvalidFileNameChars().Contains(c)))
            {
                throw new ArgumentException("El nombre de la hoja no es válido.");
            }

            // Verifica los nombres de las columnas
            if (nombresColumnas.Length > 16384)
            {
                throw new ArgumentException("El número de columnas excede el límite máximo.");
            }

            // Verifica si los datos están vacíos
            if (datos.Count == 0)
            {
                return;
                throw new ArgumentException("Los datos están vacíos. No se puede agregar una hoja vacía.");
            }
            // Verifica el nombre de la hoja
            if (string.IsNullOrWhiteSpace(nombreHoja) || nombreHoja.Length > 31 || nombreHoja.Any(c => Path.GetInvalidFileNameChars().Contains(c)))
            {
                throw new ArgumentException("El nombre de la hoja no es válido.");
            }

            // Verifica los nombres de las columnas
            if (nombresColumnas.Length > 16384)
            {
                throw new ArgumentException("El número de columnas excede el límite máximo.");
            }

            // Agrega una hoja al libro de Excel
            var worksheet = package.Workbook.Worksheets.Add(nombreHoja);
        

            // Escribe los nombres de las columnas en el archivo Excel
            for (int col = 0; col < nombresColumnas.Length; col++)
            {
                worksheet.Cells[1, col + 1].Value = nombresColumnas[col];
                worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                worksheet.Cells[1, col + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, col + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }

            // Escribe los datos en el archivo Excel
            for (int row = 0; row < datos.Count; row++)
            {
                string[] fila = datos[row];
                for (int col = 0; col < fila.Length; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = fila[col];
                }
            }

            // Ajusta automáticamente el ancho de las columnas
            worksheet.Cells.AutoFitColumns();

            // Establece el formato de las celdas para los datos numéricos
            for (int col = 0; col < nombresColumnas.Length; col++)
            {
                string columnName = GetExcelColumnName(col + 1);
                var columnCells = worksheet.Cells[$"{columnName}2:{columnName}{datos.Count + 1}"];
                columnCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            }
        }

        // Función auxiliar para obtener el nombre de columna de Excel a partir de su índice
        private static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;

            while (dividend > 0)
            {
                int modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }

        
    }
}
