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
        private static List<string[]> datos = new List<string[]>();

        //Muestra en la tabla los datos de todos los clientes y su lista perteneciente
        public static async Task MostrarTodos(DataGridView gridListas, int a)
        {
            // Se borran los registros
            LimpiarTabla(gridListas);

            // Arreglo de strings con los nombres de cada columna
            string[] nombresString = {"LISTA", "NOMBRE", "CREDITO", "FECHA INICIO", "INTERESES", "MONTO TOTAL",
                                "PROMOTOR", "CALLE", "COLONIA", "NÚM. INT.", "NÚM. EXT.",
                                "TELÉFONO", "CORREO", "TIPO DE PAGO"};
            List<string> nombresColumnas = new List<string>(nombresString);

            // Lectura de datos comunes de todas las listas y clientes liquidados
            datos.Clear();

            // Lista de tareas para la lectura de datos
            List<Task<List<string[]>>> tasks = new List<Task<List<string[]>>>();
            if(a== 4)
            {
                tasks.Add(LecturaAsync("lista1", "1"));
                tasks.Add(LecturaAsync("lista2", "2"));
                tasks.Add(LecturaAsync("lista3", "3"));
                tasks.Add(LecturaAsync("liquidados", "Liquidados"));
            }
            else if(a == 1)
            {
                tasks.Add(LecturaAsync("lista1", "1"));
            }
            else if(a == 2)
            {
                tasks.Add(LecturaAsync("lista2", "2"));
            }
            else if(a == 3)
            {
                tasks.Add(LecturaAsync("lista3", "3"));
            } 
            else if(a == 5)
            {
                tasks.Add(LecturaAsync("liquidados", "Liquidados"));
            }
           

            // Esperar a que todas las tareas se completen
            await Task.WhenAll(tasks);

            // Obtener los resultados de las tareas completadas
            foreach (var task in tasks)
            {
                datos.AddRange(await task);
            }

            // Añade las columnas correspondientes a la tabla y el nombre de cada una
            // Se añade uno por la columna de lista
            gridListas.ColumnCount = 14;
            AñadirDatos(nombresColumnas, gridListas);
        }

        static async Task<List<string[]>> LecturaAsync(string lista, string listaNombre)
        {
            Lectura_Base_Datos instancia = new Lectura_Base_Datos();
            return instancia.LectTodos(lista, listaNombre);
        }

        // Para determinar si son necesarias 26 o 19 columnas para las fechas
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

        // Añade los datos en cualquier tabla
        static void AñadirDatos(List<string> nombresColumnas, DataGridView gridListas)
        {
            for (int i = 0; i < gridListas.ColumnCount; i++)
            {
                gridListas.Columns[i].Name = nombresColumnas[i];
            }

            // Se añaden las filas
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
            gridListas.CellValueNeeded += new DataGridViewCellValueEventHandler(gridListas_CellValueNeeded);
        }

        private static void gridListas_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            e.Value = datos[e.RowIndex][e.ColumnIndex];
        }
    }
}
