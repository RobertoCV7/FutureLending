using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace FutureLending.Funciones.cs;

internal class ExportarExcel
{
    private readonly LecturaBaseDatos a = new();

    private readonly string[] nombresLisat2 =
    {
        "PROMOTOR", "NOMBRE", "CREDITO", "MONTO RESTANTE", "PAGARE",
        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
        "TIPO DE PAGO", "LIQUIDACION/INTENCION", "QUITA"
    };

    private readonly string[] nombresLista1 =
    {
        "PROMOTOR", "NOMBRE", "CREDITO", "PAGARE", "FECHA INICIO", "FECHA TERMINO", "INTERESES", "MONTO TOTAL",
        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
        "TIPO DE PAGO", "MONTO RESTANTE"
    };

    private readonly string[] nombresListas3 =
    {
        "PROMOTOR", "NOMBRE", "CREDITO", "PAGARE",
        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
        "TIPO DE RESOLUCION", "RESOLUCION DEMANDA", "IMPORTE"
    };

    private readonly string[] nombresListasLiq =
    {
        "PROMOTOR", "NOMBRE", "CREDITO", "FECHA INICIO",
        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
        "TELÉFONO", "CORREO", "FORMA DE LIQUIDACION"
    };

    public void ExportarLista1AExcel(string rutaArchivo)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        List<string> nombresColumnas = new(nombresLista1);

        for (var i = 1; i <= 15; i++)
        {
            nombresColumnas.Add("FECHA " + i);
            nombresColumnas.Add("PAGO " + i);
        }

        var datosList = a.LectLista1(true);

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Lista1");

        for (var col = 0; col < nombresColumnas.Count; col++)
        {
            var headerCell = worksheet.Cells[1, col + 1];
            headerCell.Value = nombresColumnas[col];
            headerCell.Style.Font.Bold = true;
            headerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            headerCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        for (var row = 0; row < datosList.Count; row++)
        {
            var rowData = datosList[row];
            for (var col = 0; col < rowData.Length; col++) worksheet.Cells[row + 2, col + 1].Value = rowData[col];
        }

        worksheet.Cells.AutoFitColumns();

        var file = new FileInfo(rutaArchivo);
        package.SaveAs(file);
    }

    public void ExportarTabla2(string ruta)
    {
        List<string[]> datos = a.LectLista2();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (ExcelPackage package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Lista2");
            List<string> nombresColumnas = new List<string>(nombresLisat2);
            Ediciones ed = new();
            int max = ed.ObtenerNumeroUltimaColumna("lista2");
            for (int i = 1; i <= max; i++)
            {
                nombresColumnas.Add("FECHA " + i);
                nombresColumnas.Add("PAGO " + i);
            }
            nombresColumnas.Add("PAGO TOTAL EXT");

            for (int col = 0; col < nombresColumnas.Count; col++)
            {
                ExcelRange headerCell = worksheet.Cells[1, col + 1];
                headerCell.Value = nombresColumnas[col];
                headerCell.Style.Font.Bold = true;
                headerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                headerCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }

            for (int row = 0; row < datos.Count; row++)
            {
                string[] fila = datos[row];
                for (int col = 0; col < fila.Length; col++)
                {
                    if (string.IsNullOrEmpty(fila[col]))
                    {
                        // Si PAGO_EXT está vacío, tomamos el siguiente valor y lo ponemos en la celda correspondiente.
                        if (col + 1 < fila.Length)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = fila[col + 1];
                            col++; // Incrementamos col para saltar el siguiente valor que ya hemos agregado.
                        }
                    }
                    else
                    {
                        worksheet.Cells[row + 2, col + 1].Value = fila[col];
                    }
                }
            }

            worksheet.Cells.AutoFitColumns();
            worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            package.SaveAs(new FileInfo(ruta));
        }
    }

    public void ExportarTabla3(string ruta)
    {
        var datos = a.LectLista3();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Lista3");

        for (var col = 0; col < nombresListas3.Length; col++)
        {
            var headerCell = worksheet.Cells[1, col + 1];
            headerCell.Value = nombresListas3[col];
            headerCell.Style.Font.Bold = true;
            headerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            headerCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        for (var row = 0; row < datos.Count; row++)
        {
            var fila = datos[row];
            for (var col = 0; col < fila.Length; col++) worksheet.Cells[row + 2, col + 1].Value = fila[col];
        }

        worksheet.Cells.AutoFitColumns();
        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

        package.SaveAs(new FileInfo(ruta));
    }

    public void ExportarTablaLiquidados(string ruta)
    {
        var datos = a.LectLiquidados();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Liquidados");

        for (var col = 0; col < nombresListasLiq.Length; col++)
        {
            var headerCell = worksheet.Cells[1, col + 1];
            headerCell.Value = nombresListasLiq[col];
            headerCell.Style.Font.Bold = true;
            headerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            headerCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        for (var row = 0; row < datos.Count; row++)
        {
            var fila = datos[row];
            for (var col = 0; col < fila.Length; col++) worksheet.Cells[row + 2, col + 1].Value = fila[col];
        }

        worksheet.Cells.AutoFitColumns();
        worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

        package.SaveAs(new FileInfo(ruta));
    }

    public void ExportarTodasLasTablas(string ruta)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var datosLista1 = a.LectLista1(true);
        var datosLista2 = a.LectLista2();
        var datosLista3 = a.LectLista3();
        var datosLiquidados = a.LectLiquidados();
        List<string> nombresColumnas = new(nombresLista1);

        for (var i = 1; i <= 15; i++)
        {
            nombresColumnas.Add("FECHA " + i);
            nombresColumnas.Add("PAGO " + i);
        }

        List<string> nombresColumnas2 = new(nombresLisat2);
        Ediciones ed = new();
        int max = ed.ObtenerNumeroUltimaColumna("lista2");

        for (int i = 1; i <= max; i++)
        {
            nombresColumnas2.Add("FECHA " + i);
            nombresColumnas2.Add("PAGO " + i);
        }

        nombresColumnas2.Add("PAGO_EXT");
        using var package = new ExcelPackage();
        AgregarHojaDatos(package, datosLista1, "Lista1", nombresColumnas.ToArray());
        AgregarHojaDatos(package, datosLista2, "Lista2", nombresColumnas2.ToArray());
        AgregarHojaDatos(package, datosLista3, "Lista3", nombresListas3);
        AgregarHojaDatos(package, datosLiquidados, "Liquidados", nombresListasLiq);

        package.SaveAs(new FileInfo(ruta));
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
        }

        // Agrega una hoja al libro de Excel
        var worksheet = package.Workbook.Worksheets.Add(nombreHoja);

        // Escribe los nombres de las columnas en el archivo Excel
        for (int col = 0; col < nombresColumnas.Length; col++)
        {
            ExcelRange headerCell = worksheet.Cells[1, col + 1];
            headerCell.Value = nombresColumnas[col];
            headerCell.Style.Font.Bold = true;
            headerCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            headerCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        // Escribe los datos en el archivo Excel
        for (int row = 0; row < datos.Count; row++)
        {
            string[] fila = datos[row];
            for (int col = 0; col < fila.Length; col++)
            {

                if (string.IsNullOrEmpty(fila[col]))
                {
                    // Si PAGO_EXT está vacío, tomamos el siguiente valor y lo ponemos en la celda correspondiente.
                    if (col + 1 < fila.Length)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = fila[col + 1];
                        col++; // Incrementamos col para saltar el siguiente valor que ya hemos agregado.
                    }
                }
                else
                {
                    worksheet.Cells[row + 2, col + 1].Value = fila[col];
                }
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

    private static string GetExcelColumnName(int columnNumber)
    {
        var dividend = columnNumber;
        var columnName = string.Empty;

        while (dividend > 0)
        {
            var modulo = (dividend - 1) % 26;
            columnName = Convert.ToChar('A' + modulo) + columnName;
            dividend = (dividend - modulo) / 26;
        }

        return columnName;
    }
}