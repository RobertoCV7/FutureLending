﻿using System;
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
        private static List<string[]> datos = new List<string[]>();

        //Muestra en la tabla los datos de la lista 1
        public static async Task MostrarLista1(DataGridView gridListas)
        {
            // Se borran los registros
            LimpiarTabla(gridListas);

            // Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                              "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                              "TIPO DE PAGO", "MONTO PAGADO"};

            // Añade los strings de cada fecha y pago a la lista
            List<string> nombresColumnas = new List<string>(nombresString);
            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
                nombresColumnas.Add("PAGO " + i);
            }

            // Lectura de datos de la lista correspondiente en un hilo separado
            List<string[]> datosList = await Task.Run(() =>
            {
                Lectura_Base_Datos instancia = new Lectura_Base_Datos();
                return instancia.LectLista1();
            });

            // Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = ObtenerColumnas();
            AñadirDatos(nombresColumnas, gridListas);

            // Agrega los datos al DataGridView en un hilo separado
            await Task.Run(() =>
            {
                foreach (string[] row in datosList)
                {
                    gridListas.Invoke(new Action(() =>
                    {
                        gridListas.Rows.Add(row);
                    }));
                }
            });
        }
        //Muestra en la tabla los datos de la lista 2
        public static void MostrarLista2(DataGridView gridListas)
        {
            //Se borran los registros
            LimpiarTabla(gridListas);

            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                                "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                                "TIPO DE PAGO", "MONTO PAGADO", "MONTO RESTANTE", "FECHA LÍMITE"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            //Lectura de datos de la lista correspondiente en un hilo separado
            List<string[]>? datosList = null;
            Thread readThread = new Thread(() =>
            {
                Lectura_Base_Datos instancia = new Lectura_Base_Datos();
                datosList = instancia.LectLista2();
            });
            readThread.Start();

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = 16;
            AñadirDatos(nombresColumnas, gridListas);

            //Espera a que termine la lectura antes de agregar los datos al DataGridView
            readThread.Join();

            //Agrega los datos al DataGridView en un hilo separado
            Thread writeThread = new Thread(() =>
            {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                foreach (string[] row in datosList)
                {
                    gridListas.Invoke(new Action(() =>
                    {
                        gridListas.Rows.Add(row);
                    }));
                }
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            });
            writeThread.Start();
        }

        //Muestra en la tabla los datos de la lista 3
        public static void MostrarLista3(DataGridView gridListas)
        {
            //Se borran los registros
            LimpiarTabla(gridListas);

            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                                "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                                "TIPO DE PAGO", "MONTO PAGADO", "MONTO RESTANTE"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            //Lectura de datos de la lista correspondiente en un hilo separado
            List<string[]> datosList = null;
            Thread readThread = new Thread(() =>
            {
                Lectura_Base_Datos instancia = new Lectura_Base_Datos();
                datosList = instancia.LectLista3();
            });
            readThread.Start();

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = 15;
            AñadirDatos(nombresColumnas, gridListas);

            //Espera a que termine la lectura antes de agregar los datos al DataGridView
            readThread.Join();

            //Agrega los datos al DataGridView en un hilo separado
            Thread writeThread = new Thread(() =>
            {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                foreach (string[] row in datosList)
                {
                    gridListas.Invoke(new Action(() =>
                    {
                        gridListas.Rows.Add(row);
                    }));
                }
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            });
            writeThread.Start();
        }

        //Muestra en la tabla los datos de la liquidados
        public static void MostrarLiquidados(DataGridView gridListas)
        {
            //Se borran los registros
            LimpiarTabla(gridListas);

            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "FECHA ÚLTIMO PAGO", "INTERESES",
                              "MONTO TOTAL", "PROMOTOR", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
                              "TELÉFONO", "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            //Lectura de datos de la lista correspondiente en un hilo separado
            List<string[]> datosList = null;
            Thread readThread = new Thread(() =>
            {
                Lectura_Base_Datos instancia = new Lectura_Base_Datos();
                datosList = instancia.LectLista2();
            });
            readThread.Start();

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = 14;
            AñadirDatos(nombresColumnas, gridListas);

            //Espera a que termine la lectura antes de agregar los datos al DataGridView
            readThread.Join();

            //Agrega los datos al DataGridView en un hilo separado
            Thread writeThread = new Thread(() =>
            {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                foreach (string[] row in datosList)
                {
                    gridListas.Invoke(new Action(() =>
                    {
                        gridListas.Rows.Add(row);
                    }));
                }
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            });
            writeThread.Start();
        }

        //Muestra en la tabla los datos de todos los clientes y su lista perteneciente
        public static void MostrarTodos(DataGridView gridListas)
        {
            //Se borran los registros
            LimpiarTabla(gridListas);

            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"LISTA", "NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL",
                            "PROMOTOR", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
                            "TELÉFONO", "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            //Lectura de datos comunes de todas las listas y clientes liquidados en un hilo separado
            List<string[]> datosList = null;
            Thread readThread = new Thread(() =>
            {
                Lectura_Base_Datos instancia = new Lectura_Base_Datos();
                datosList = new List<string[]>();
                datosList.AddRange(instancia.LectTodos("lista1", "1"));
                datosList.AddRange(instancia.LectTodos("lista2", "2"));
                datosList.AddRange(instancia.LectTodos("lista3", "3"));
                datosList.AddRange(instancia.LectTodos("liquidados", "Liquidados"));
            });
            readThread.Start();

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            //Se añade uno por la columna de lista
            gridListas.ColumnCount = 14;
            AñadirDatos(nombresColumnas, gridListas);

            //Espera a que termine la lectura antes de agregar los datos al DataGridView
            readThread.Join();

            //Agrega los datos al DataGridView en un hilo separado
            Thread writeThread = new Thread(() =>
            {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                foreach (string[] row in datosList)
                {
                    gridListas.Invoke(new Action(() =>
                    {
                        gridListas.Rows.Add(row);
                    }));
                }
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            });
            writeThread.Start();
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
        static void AñadirDatos(List<string> nombresColumnas, DataGridView gridListas)
        {
            for (int i = 0; i < gridListas.ColumnCount; i++)
            {
                gridListas.Columns[i].Name = nombresColumnas[i];
            }

            //Se añaden las filas
            gridListas.RowCount = datos.Count;
        }

        //Borra el contenido de la tabla
        static void LimpiarTabla(DataGridView gridListas)
        {
            gridListas.Rows.Clear();
            gridListas.Columns.Clear();
        }

        public static void AñadirEvento(DataGridView gridListas)
        {
            //Se encarga del evento para la virtualización e immpresión de datos en la tabla
#pragma warning disable CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
            gridListas.CellValueNeeded += new DataGridViewCellValueEventHandler(gridListas_CellValueNeeded);
#pragma warning restore CS8622 // La nulabilidad de los tipos de referencia del tipo de parámetro no coincide con el delegado de destino (posiblemente debido a los atributos de nulabilidad).
        }

        private static void gridListas_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = datos[e.RowIndex][e.ColumnIndex];
        }
    }
}