using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureLending
{
    internal class TablaClientes
    {
        //Muestra en la tabla los datos de la lista 1
        public static void MostrarLista1(DataGridView gridListas)
        {
            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                                        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO", 
                                        "TIPO DE PAGO", "MONTO PAGADO"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);
            //Añade los strings de cada fecha y pago a la lista
            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
                nombresColumnas.Add("PAGO " + i);
            }

            //Lectura de datos de la lista correspondiente
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> datos = instancia.LectLista1();

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = ObtenerColumnas(datos);
            AñadirDatos(nombresColumnas, gridListas, datos);
        }

        //Muestra en la tabla los datos de la lista 2
        public static void MostrarLista2(DataGridView gridListas)
        {
            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                                        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                                        "TIPO DE PAGO", "MONTO PAGADO", "MONTO RESTANTE", "FECHA LÍMITE"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            //Lectura de datos de la lista correspondiente
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> datos = instancia.LectLista2();

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = 16;
            AñadirDatos(nombresColumnas, gridListas, datos);
        }

        //Muestra en la tabla los datos de la lista 3
        public static void MostrarLista3(DataGridView gridListas)
        {
            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL", "PROMOTOR",
                                        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO", "CORREO",
                                        "TIPO DE PAGO", "MONTO PAGADO", "MONTO RESTANTE"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            //Lectura de datos de la lista correspondiente
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> datos = instancia.LectLista3();

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = 15;
            AñadirDatos(nombresColumnas, gridListas, datos);
        }

        //Muestra en la tabla los datos de la liquidados
        public static void MostrarLiquidados(DataGridView gridListas)
        {
            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "FECHA ÚLTIMO PAGO", "INTERESES", 
                                      "MONTO TOTAL", "PROMOTOR", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", 
                                      "TELÉFONO", "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            //Lectura de datos de la lista correspondiente
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> datos = instancia.LectLiquidados();

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = 14;
            AñadirDatos(nombresColumnas, gridListas, datos);
        }

        //Muestra en la tabla los datos de todos los clientes y su lista perteneciente
        public static void MostrarTodos(DataGridView gridListas)
        {
            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"LISTA", "NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL",
                                        "PROMOTOR", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
                                        "TELÉFONO", "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);

            //Lectura de datos comunes de todas las listas y clientes liquidados
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> datos = instancia.LectTodos("lista1", "1");
            datos.AddRange(instancia.LectTodos("lista2", "2"));
            datos.AddRange(instancia.LectTodos("lista3", "3"));
            datos.AddRange(instancia.LectTodos("liquidados", "Liquidados"));

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            //Se añade uno por la columna de lista
            gridListas.ColumnCount = 14;
            AñadirDatos(nombresColumnas, gridListas, datos);
        }

        //Para determinar si son necesarias 26 o 19 columnas para las fechas
        static int ObtenerColumnas(List<string[]> datos)
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
        static void AñadirDatos(List<string> nombresColumnas, DataGridView gridListas, List<string[]> datos)
        {
            for (int i = 0; i < gridListas.ColumnCount; i++)
            {
                gridListas.Columns[i].Name = nombresColumnas[i];
            }

            //Se añaden las filas y el contenido respectivo de cada celda
            gridListas.RowCount = datos.Count;
            for (int i = 0; i < gridListas.RowCount; i++)
            {
                for (int j = 0; j < gridListas.ColumnCount; j++)
                {
                    gridListas.Rows[i].Cells[j].Value = datos[i][j];
                }
            }
        }
    }
}
