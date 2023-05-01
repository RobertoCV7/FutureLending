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
        //Muestra en la tabla los datos de la lista correspondiente
        public static void MostrarTablaListas(string lista, DataGridView gridListas)
        {
            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "PROMOTOR",
                                        "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.", "TELÉFONO",
                                        "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);
            //Añade los strings de cada fecha a la lista
            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
            }

            //Lectura de datos de la lista correspondiente
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> datos = instancia.Lect(lista);

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            gridListas.ColumnCount = ObtenerColumnas(datos);
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

        //Muestra en la tabla los datos de todos los clientes y su lista perteneciente
        public static void MostrarTodos(DataGridView gridListas)
        {
            //Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"LISTA", "NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES",
                                        "PROMOTOR", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
                                        "TELÉFONO", "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>(); //Lista con los nombres de las columnas
            nombresColumnas.AddRange(nombresString);
            //Añade los strings de cada fecha a la lista
            for (int i = 1; i <= 14; i++)
            {
                nombresColumnas.Add("FECHA " + i);
            }

            //Lectura de datos de todas las listas
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            List<string[]> lista1 = instancia.Lect("lista1");
            List<string[]> lista2 = instancia.Lect("lista2");
            List<string[]> lista3 = instancia.Lect("lista3");
            //Rango de que abarca cada lista
            int rangoLista1 = lista1.Count;
            int rangoLista2 = lista1.Count + lista2.Count;
            int rangoLista3 = lista1.Count + lista2.Count + lista3.Count;
            //Se juntan todas las listas
            List<string[]> todos = new List<string[]>(rangoLista3);
            todos.AddRange(lista1);
            todos.AddRange(lista2);
            todos.AddRange(lista3);

            //Añade las columnas correspondientes a la tabla y el nombre de cada una
            //Se añade uno por la columna de lista
            gridListas.ColumnCount = ObtenerColumnas(todos) + 1; ;
            for (int i = 0; i < gridListas.ColumnCount; i++)
            {
                gridListas.Columns[i].Name = nombresColumnas[i];
            }

            //Se añaden las filas y el contenido respectivo de cada celda
            gridListas.RowCount = todos.Count;
            for (int i = 0; i < gridListas.RowCount; i++)
            {
                for (int j = 0; j < gridListas.ColumnCount - 1; j++)
                {
                    //Muestra la lista a la que pertenece el cliente
                    if (i < rangoLista1) gridListas.Rows[i].Cells[0].Value = 1;
                    if (i >= rangoLista1 && i < rangoLista2) gridListas.Rows[i].Cells[0].Value = 2;
                    if (i >= rangoLista2 && i < rangoLista3) gridListas.Rows[i].Cells[0].Value = 3;

                    gridListas.Rows[i].Cells[j + 1].Value = todos[i][j];
                }
            }
        }

        //Para determinar si son necesarias 26 o 19 columnas para las fechas
        static int ObtenerColumnas(List<string[]> datos)
        {
            int fechas = 19;
            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i][11] == "Semanal")
                {
                    fechas = 26;
                    return fechas;
                }
            }
            return fechas;
        }
    }
}
