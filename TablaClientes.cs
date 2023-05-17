using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureLending
{
    internal class TablaClientes
    {
        //Aquí se guardan los datos de todas las consultas
        private static readonly List<string[]> datos = new();

        //Muestra en la tabla los datos de la lista 1
        public static async Task MostrarLista1(DataGridView gridListas, 
            ControlesPersonalizados.RJComboBox cmbCliente)
        {
            // Se borran los registros
            LimpiarDatos(gridListas, cmbCliente);

            // Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                              "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                              "TIPO DE PAGO", "MONTO RESTANTE"};

            // Añade los strings de cada fecha y pago a la lista
            List<string> nombresColumnas = new(nombresString);
            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
                nombresColumnas.Add("PAGO " + i);
            }

            // Lectura de datos de la lista correspondiente en un hilo separado
            List<string[]> datosList = await Task.Run(() =>
            {
                Lectura_Base_Datos instancia = new();
                return instancia.LectLista1();
            });

            // Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = ObtenerColumnas();
            AñadirEncabezado(nombresColumnas, gridListas);

            // Agrega los datos al DataGridView en un hilo separado y los nombres al ComboBox
            await AñadirDatos(datosList, gridListas, cmbCliente, false);
        }

        //Muestra en la tabla los datos de la lista 2
        public static async Task MostrarLista2(DataGridView gridListas,
            ControlesPersonalizados.RJComboBox cmbCliente)
        {
            //Se borran los registros
            LimpiarDatos(gridListas, cmbCliente);

            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                                "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                                "TIPO DE PAGO", "MONTO PAGADO", "MONTO RESTANTE", "FECHA LÍMITE"};
            List<string> nombresColumnas = new(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            // Lectura de datos de la lista correspondiente en un hilo separado
            List<string[]> datosList = await Task.Run(() =>
            {
                Lectura_Base_Datos instancia = new();
                return instancia.LectLista2();
            });

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = 16;
            AñadirEncabezado(nombresColumnas, gridListas);

            // Agrega los datos al DataGridView en un hilo separado
            await AñadirDatos(datosList, gridListas, cmbCliente,  false);
        }

        //Muestra en la tabla los datos de la lista 3
        public static async Task MostrarLista3(DataGridView gridListas,
            ControlesPersonalizados.RJComboBox cmbCliente)
        {
            //Se borran los registros
            LimpiarDatos(gridListas, cmbCliente);

            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                                "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                                "TIPO DE PAGO", "MONTO PAGADO", "MONTO RESTANTE"};
            List<string> nombresColumnas = new(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            // Lectura de datos de la lista correspondiente en un hilo separado
            List<string[]> datosList = await Task.Run(() =>
            {
                Lectura_Base_Datos instancia = new();
                return instancia.LectLista3();
            });

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = 15;
            AñadirEncabezado(nombresColumnas, gridListas);

            // Agrega los datos al DataGridView en un hilo separado
            await AñadirDatos(datosList, gridListas, cmbCliente, false);
        }

        //Muestra en la tabla los datos de la liquidados
        public static async Task MostrarLiquidados(DataGridView gridListas, 
            ControlesPersonalizados.RJComboBox cmbCliente)
        {
            //Se borran los registros
            LimpiarDatos(gridListas, cmbCliente);

            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "FECHA ÚLTIMO PAGO", "INTERESES",
                              "MONTO TOTAL", "PROMOTOR", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
                              "TELÉFONO", "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            // Lectura de datos de la lista correspondiente en un hilo separado
            List<string[]> datosList = await Task.Run(() =>
            {
                Lectura_Base_Datos instancia = new();
                return instancia.LectLiquidados();
            });

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = 14;
            AñadirEncabezado(nombresColumnas, gridListas);

            // Agrega los datos al DataGridView en un hilo separado
            await AñadirDatos(datosList, gridListas, cmbCliente, false);
        }

        //Muestra en la tabla los datos de todos los clientes y su lista perteneciente
        public static async Task MostrarTodos(DataGridView gridListas,
            ControlesPersonalizados.RJComboBox cmbCliente)
        {
            //Se borran los registros
            LimpiarDatos(gridListas, cmbCliente);

            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"LISTA", "NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL",
                            "PROMOTOR", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
                            "TELÉFONO", "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            //Lectura de datos comunes de todas las listas y clientes liquidados en un hilo separado
            List<string[]> datosList = await Task.Run(() =>
            {
                Lectura_Base_Datos instancia = new();
                List<string[]> todas = instancia.LectTodos("lista1", "1");
                todas.AddRange(instancia.LectTodos("lista2", "2"));
                todas.AddRange(instancia.LectTodos("lista3", "3"));
                todas.AddRange(instancia.LectTodos("liquidados", "Liquidados"));
                return todas;
            });

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            //Se añade uno por la columna de lista
            gridListas.ColumnCount = 14;
            AñadirEncabezado(nombresColumnas, gridListas);

            // Agrega los datos al DataGridView en un hilo separado
            await AñadirDatos(datosList, gridListas, cmbCliente, true);
        }

        //Para determinar si son necesarias 26 o 19 columnas para las fechas
        static int ObtenerColumnas()
        {
            int fechas = 28;
            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i][12] == "Semanal")
                {
                    fechas = 42;
                    return fechas;
                }
            }
            return fechas;
        }

        //Añade los datos en cualquier tabla
        static void AñadirEncabezado(List<string> nombresColumnas, DataGridView gridListas)
        {
            for (int i = 0; i < gridListas.ColumnCount; i++)
            {
                gridListas.Columns[i].Name = nombresColumnas[i];
            }
        }

        //Borra el contenido de la tabla
        static void LimpiarDatos(DataGridView gridListas,
            ControlesPersonalizados.RJComboBox cmbCliente)
        {
            gridListas.Rows.Clear();
            gridListas.Columns.Clear();
            cmbCliente.Items.Clear();
            cmbCliente.SelectedItem = -1;
#pragma warning disable CS8601 // Posible asignación de referencia nula
            cmbCliente.Texts = cmbCliente.Tag.ToString();
#pragma warning restore CS8601 // Posible asignación de referencia nula
        }

        //Añade los datos a la tabla y ComboBox
        static async Task AñadirDatos(List<string[]> datosList, DataGridView gridListas,
            ControlesPersonalizados.RJComboBox cmbCliente, bool todos)
        {
            await Task.Run(() =>
            {
                foreach (string[] row in datosList)
                {
                    gridListas.Invoke(new Action(() =>
                    {
                        gridListas.Rows.Add(row);
                    }));
                    if (!todos)
                    {
                        cmbCliente.Invoke(new Action(() =>
                        {
                            cmbCliente.Items.Add(row[0]);
                        }));
                    }
                }
            });
        }

        public static void AñadirEvento(DataGridView gridListas)
        {
            //Se encarga del evento para la virtualización e immpresión de datos en la tabla
#pragma warning disable CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
            gridListas.CellValueNeeded += new DataGridViewCellValueEventHandler(GridListas_CellValueNeeded);
#pragma warning restore CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
        }

        private static void GridListas_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = datos[e.RowIndex][e.ColumnIndex];
        }
    }
}