using FutureLending.ControlesPersonalizados;

namespace FutureLending.Funciones.cs;

internal class TablaClientes
{
    private static readonly LecturaBaseDatos Instancia = new();

    //Muestra en la tabla los datos de la lista 1
    public static async Task MostrarLista1(DataGridView gridListas,
        RjComboBox cmbCliente, ProgressBar bar, Label lab)
    {
        // Se borran los registros
        LimpiarDatos(gridListas, cmbCliente);

        // Arreglo de strings con los nombres de cada columna
        string[] nombresString =
        {
            "PROMOTOR", "NOMBRE", "CREDITO", "PAGARE", "FECHA INICIO", "FECHA TERMINO", "INTERESES", "MONTO TOTAL",
            "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
            "TIPO DE PAGO", "MONTO RESTANTE"
        };

        // Añade los strings de cada fecha y pago a la lista
        List<string> nombresColumnas = new(nombresString);
        for (var i = 1; i <= 14; i++) nombresColumnas.Add("FECHA " + i);
        // Lectura de datos de la lista correspondiente en un hilo separado
        var datosList = await Task.Run(() => Instancia.LectLista1(false));
        // Añade las columnas correspondientes a la tabla y el nombre de cada una
        gridListas.ColumnCount = nombresColumnas.Count;
        AñadirEncabezado(nombresColumnas, gridListas);
        // Agrega los datos al DataGridView en un hilo separado y los nombres al ComboBox
        await AñadirDatos(datosList, gridListas, cmbCliente, false, bar, lab);
    }

    //Muestra en la tabla los datos de la lista 2
    public static async Task MostrarLista2(DataGridView gridListas,
        RjComboBox cmbCliente, ProgressBar bar, Label lab)
    {
        //Se borran los registros
        LimpiarDatos(gridListas, cmbCliente);

        //Arreglo de strings con los nombres de cada columna
        string[] nombresString2 =
        {
            "PROMOTOR", "NOMBRE", "CREDITO", "MONTO RESTANTE", "PAGARE",
            "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
            "TIPO DE PAGO", "LIQUIDACION/CONVENIO", "QUITA"
        };
        List<string> nombresColumnas2 = new(nombresString2);
        for (var i = 1; i <= 14; i++)
        {
            nombresColumnas2.Add("FECHA " + i);
            nombresColumnas2.Add("PAGO " + i);
        }

        nombresColumnas2.Add("Pago EXT");

        // Lectura de datos de la lista correspondiente en un hilo separado
        var datosList = await Task.Run(() => Instancia.LectLista2());
        //Añade las columnas correspondientes a la tabla y el nombre de cada una

        gridListas.ColumnCount = nombresColumnas2.Count;
        AñadirEncabezado(nombresColumnas2, gridListas);

        // Agrega los datos al DataGridView en un hilo separado
        await AñadirDatos(datosList, gridListas, cmbCliente, false, bar, lab);
    }

    //Muestra en la tabla los datos de la lista 3
    public static async Task MostrarLista3(DataGridView gridListas,
        RjComboBox cmbCliente, ProgressBar bar, Label lab)
    {
        //Se borran los registros
        LimpiarDatos(gridListas, cmbCliente);

        //Arreglo de strings con los nombres de cada columna
        string[] nombresString =
        {
            "PROMOTOR", "NOMBRE", "CREDITO", "PAGARE",
            "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
            "TIPO DE RESOLUCION", "RESOLUCION DEMANDA", "IMPORTE"
        };
        List<string> nombresColumnas = new(); //Lista con los nombres de las columnas
        nombresColumnas.AddRange(nombresString);

        // Lectura de datos de la lista correspondiente en un hilo separado
        var datosList = await Task.Run(() => Instancia.LectLista3());

        //Añade las columnas correspondientes a la tabla y el nombre de cada una
        gridListas.ColumnCount = nombresColumnas.Count;
        AñadirEncabezado(nombresColumnas, gridListas);

        // Agrega los datos al DataGridView en un hilo separado
        await AñadirDatos(datosList, gridListas, cmbCliente, false, bar, lab);
    }

    //Muestra en la tabla los datos de la liquidados
    public static async Task MostrarLiquidados(DataGridView gridListas,
        RjComboBox cmbCliente, ProgressBar bar, Label lab)
    {
        //Se borran los registros
        LimpiarDatos(gridListas, cmbCliente);

        //Arreglo de strings con los nombres de cada columna
        string[] nombresString =
        {
            "PROMOTOR", "NOMBRE", "CREDITO", "FECHA INICIO",
            "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
            "TELÉFONO", "CORREO", "FORMA DE LIQUIDACION"
        };
        List<string> nombresColumnas = new(); //Lista con los nombres de las columnas
        nombresColumnas.AddRange(nombresString);

        // Lectura de datos de la lista correspondiente en un hilo separado
        var datosList = await Task.Run(() => Instancia.LectLiquidados());

        //Añade las columnas correspondientes a la tabla y el nombre de cada una
        gridListas.ColumnCount = nombresColumnas.Count;
        AñadirEncabezado(nombresColumnas, gridListas);

        // Agrega los datos al DataGridView en un hilo separado
        await AñadirDatos(datosList, gridListas, cmbCliente, false, bar, lab);
    }

    //Muestra en la tabla los datos de todos los clientes y su lista perteneciente
    public static async Task MostrarTodos(DataGridView gridListas,
        RjComboBox cmbCliente, ProgressBar bar, Label lab)
    {
        //Se borran los registros
        LimpiarDatos(gridListas, cmbCliente);

        //Arreglo de strings con los nombres de cada columna
        string[] nombresString =
        {
            "LISTA", "PROMOTOR", "NOMBRE", "CREDITO",
            "FECHA INICIO", "INTERES", "MONTO TOTAL", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
            "TELÉFONO", "CORREO", "TIPO DE PAGO"
        };
        List<string> nombresColumnas = new(); //Lista con los nombres de las columnas
        nombresColumnas.AddRange(nombresString);

        //Lectura de datos comunes de todas las listas y clientes liquidados en un hilo separado
        var datosList = await Task.Run(() =>
        {
            var todas = Instancia.LectTodos("lista1", "1");
            todas.AddRange(Instancia.LectTodos("lista2", "2"));
            todas.AddRange(Instancia.LectTodos("lista3", "3"));
            todas.AddRange(Instancia.LectTodos("liquidados", "Liquidados"));
            return todas;
        });

        //Añade las columnas correspondientes a la tabla y el nombre de cada una
        //Se añade uno por la columna de lista
        gridListas.ColumnCount = nombresColumnas.Count;
        AñadirEncabezado(nombresColumnas, gridListas);

        // Agrega los datos al DataGridView en un hilo separado
        await AñadirDatos(datosList, gridListas, cmbCliente, true, bar, lab);
    }


    //Añade los datos en cualquier tabla
    private static void AñadirEncabezado(List<string> nombresColumnas, DataGridView gridListas)
    {
        for (var i = 0; i < gridListas.ColumnCount; i++) gridListas.Columns[i].Name = nombresColumnas[i];
    }

    //Borra el contenido de la tabla
    private static void LimpiarDatos(DataGridView gridListas,
        RjComboBox cmbCliente)
    {
        gridListas.Rows.Clear();
        gridListas.Columns.Clear();
        cmbCliente.Items.Clear();
        cmbCliente.SelectedItem = -1;
        cmbCliente.Texts = cmbCliente.Tag.ToString();
    }

    //Añade los datos a la tabla y ComboBox
    private static async Task AñadirDatos(List<string[]> datosList, DataGridView gridListas, RjComboBox cmbCliente,
        bool todos, ProgressBar bar, Label lab)
    {
        if (datosList.Count == 0)
        {
            bar.Visible = false;
            return;
        }

        bar.Maximum = 100;
        bar.Minimum = 0;

        var porcentajePaso = 100.0 / datosList.Count;
        var mostrarBarraProgreso = datosList.Count > 100;
        var mostrarTextoCargando = mostrarBarraProgreso;

        if (!mostrarBarraProgreso)
        {
            bar.Visible = false;
        }
        else
        {
            bar.Visible = true;
            lab.Visible = true;
        }

        await Task.Run(() =>
        {
            var i = 0;

            foreach (object[] row in datosList)
            {
                gridListas.Invoke(() =>
                {
                    gridListas.Rows.Add(row);

                    if (mostrarBarraProgreso)
                    {
                        var valorProgressBar = (int)Math.Ceiling((i + 1) * porcentajePaso);

                        bar.Invoke(() =>
                        {
                            bar.Value = valorProgressBar;

                            if (valorProgressBar == 100)
                            {
                                bar.Visible = false;
                                bar.Value = 0;
                                lab.Visible = false;
                            }
                            else
                            {
                                if (mostrarTextoCargando) lab.Text = @"Cargando...(" + valorProgressBar + @"%)";
                            }
                        });
                    }

                    i++;
                });

                if (!todos)
                    cmbCliente.Invoke(() => { cmbCliente.Items.Add(row[1]); });
            }
        });
    }


    #region Muestra solo a los promotores

    public static async Task MostrarLista1Prom(DataGridView gridListas,
        RjComboBox cmbCliente, ProgressBar bar, Label lab, List<string[]> info)
    {
        // Se borran los registros
        LimpiarDatos(gridListas, cmbCliente);

        // Arreglo de strings con los nombres de cada columna
        string[] nombresString =
        {
            "PROMOTOR", "NOMBRE", "CREDITO", "PAGARE", "FECHA INICIO", "INTERESES", "MONTO TOTAL",
            "TIPO DE PAGO", "MONTO RESTANTE"
        };
        List<string> nombresColumnas = new(nombresString);
        // Añade las columnas correspondientes a la tabla y el nombre de cada una
        gridListas.ColumnCount = nombresColumnas.Count;
        AñadirEncabezado(nombresColumnas, gridListas);
        // Agrega los datos al DataGridView en un hilo separado y los nombres al ComboBox
        await AñadirDatos(info, gridListas, cmbCliente, false, bar, lab);
    }

    public static async Task MostrarLista2Prom(DataGridView gridListas,
        RjComboBox cmbCliente, ProgressBar bar, Label lab, List<string[]> info)
    {
        //Se borran los registros
        LimpiarDatos(gridListas, cmbCliente);
        //Arreglo de strings con los nombres de cada columna
        string[] nombresString2 =
        {
            "PROMOTOR", "NOMBRE", "CREDITO", "MONTO RESTANTE", "PAGARE",
            "TIPO DE PAGO", "LIQUIDACION/CONVENIO", "QUITA"
        };
        List<string> nombresColumnas2 = new(nombresString2);
        nombresColumnas2.Add("Pago EXT");
        gridListas.ColumnCount = nombresColumnas2.Count;
        AñadirEncabezado(nombresColumnas2, gridListas);
        // Agrega los datos al DataGridView en un hilo separado
        await AñadirDatos(info, gridListas, cmbCliente, false, bar, lab);
    }

    #endregion
}