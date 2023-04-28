using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Crypto.Tls;
using System.Diagnostics;
using System.Globalization;

namespace FutureLending
{
    public class Lectura_Base_Datos
    {
        //verificador de cambio de puerto
        public bool cambio_puerto = false;
        MySqlConnection Conector()
        {
            // creamos la conexión verificando si se ha cambiado el puerto
            string server = "localhost";
            int port = cambio_puerto ? 3307 : 3306;
            string database = "prestamos";
            string uid = "root";
            string pwd = "";
            string connectionString = $"server={server};port={port};database={database};uid={uid};pwd={pwd};";

            MySqlConnection connection = null;

            try
            {
                // creamos la conexión
                connection = new MySqlConnection(connectionString);

                // abrimos la conexión
                connection.Open();
            }
            catch (MySqlException ex)
            {
                // en caso de error, manejamos la excepción y mostramos un mensaje al usuario
                MessageBox.Show($"Error de conexión: {ex.Message}");
            }

            // devolvemos la conexión, puede ser nula en caso de error
            return connection;
        }
        public List<string[]> Lect(string tabla)
        {
            List<string[]> datos = new List<string[]>();
            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM " + tabla;
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string[] fila = new string[26];
                            fila[0] = reader.GetString("Nombre_Completo");
                            fila[1] = reader.GetString("Credito_Prestado");
                            fila[2] = reader.GetString("Fecha_Inicio");
                            fila[3] = reader.GetString("Interes");
                            fila[4] = reader.GetString("Promotor");
                            fila[5] = reader.GetString("Calle");
                            fila[6] = reader.GetString("Colonia");
                            fila[7] = reader.GetString("Num_int");
                            fila[8] = reader.GetString("Num_ext");
                            fila[9] = reader.GetString("Telefono");
                            fila[10] = reader.GetString("Correo");
                            fila[11] = reader.GetInt32("Tipo_pago").ToString();
                            for (int i = 0; i < 14; i++)
                            {
                                fila[i + 12] = reader.GetString("Fecha" + (i + 1));
                            }
                            datos.Add(fila);
                        }
                    }
                }
            }
            /*
            StringBuilder sb = new StringBuilder();
            foreach (string[] fila in datos)
            {
                sb.Append(string.Join(".", fila));
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
            */
            return datos;
        }

        int Edit()//falta agregar parametros de recibido pero hasta que la base de datos este lista
        {
            //creamos la conexion
            MySqlConnection Connection = Conector(); //llamamos al conector
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "UPDATE nombre_tabla SET columna1='valor1', columna2='valor2' WHERE id=1"; //simplemente se editan los parametros

            //esto nos devuelve el numero de filas que edito
            int filasAfectadas = command.ExecuteNonQuery();
            //cerramos la conexion
            Connection.Close();
            return filasAfectadas;
        }

        int erase()//falta agregar parametros de recibido pero hasta que la base de datos este lista
        {
            MySqlConnection Connection = Conector(); //llamamos al conector
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM nombre_tabla WHERE columna1='valor1' AND columna2='valor2'"; //solo se edita

            //esto nos devuelve el numero de filas que edito
            int filasAfectadas = command.ExecuteNonQuery();
            //cerramos la conexion
            Connection.Close();
            return filasAfectadas;
        }

        void create(string Nombre, string Credito, string Fecha_inicio, string Interes, string Promotor, string Calle, string Num_int, string Num_ext, string Telefono, string Correo, int Tipo_pago)
        {
            DateTime fechaInicio;
            if (!DateTime.TryParseExact(Fecha_inicio, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicio))
            {
                throw new ArgumentException("Fecha_inicio invalida");
            }

            string[] dias_de_pago;
            if (Tipo_pago == 1)
            {
                dias_de_pago = Enumerable.Range(0, 14)
                    .Select(i => fechaInicio.AddDays(7 * i + 7).ToString("yyyy-MM-dd"))
                    .ToArray();
            }
            else
            {
                dias_de_pago = Enumerable.Range(0, 7)
                    .Select(i => fechaInicio.AddDays(15 * i + 15).ToString("yyyy-MM-dd"))
                    .ToArray();
            }

            using (MySqlConnection connection = Conector())
            {
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO tabla (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Interes, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago");
                for (int i = 1; i <= dias_de_pago.Length; i++)
                {
                    queryBuilder.Append(", Fecha").Append(i);
                }
                queryBuilder.Append(") VALUES (@Nombre, @Credito, @Fecha_inicio, @Interes, @Promotor, @Calle, @Colonia, @Num_int, @Num_ext, @Telefono, @Correo, @Tipo_pago");
                for (int i = 0; i < dias_de_pago.Length; i++)
                {
                    queryBuilder.Append(", @Fecha").Append(i + 1);
                }
                queryBuilder.Append(")");
                string query = queryBuilder.ToString();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Credito", Credito);
                    command.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio);
                    command.Parameters.AddWithValue("@Interes", Interes);
                    command.Parameters.AddWithValue("@Promotor", Promotor);
                    command.Parameters.AddWithValue("@Calle", Calle);
                    command.Parameters.AddWithValue("@Colonia", Num_int);
                    command.Parameters.AddWithValue("@Num_int", Num_int);
                    command.Parameters.AddWithValue("@Num_ext", Num_ext);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@Correo", Correo);
                    command.Parameters.AddWithValue("@Tipo_pago", Tipo_pago);
                    for (int i = 0; i < dias_de_pago.Length; i++)
                    {
                        command.Parameters.AddWithValue("@Fecha" + (i + 1), dias_de_pago[i]);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        public async Task CheckConnection()
        {
            string server = "localhost";
            int port = cambio_puerto ? 3307 : 3306;
            string database = "prestamos";
            string username = "root";
            string password = "";

            string connectionString = $"server={server};port={port};database={database};uid={username};pwd={password}";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    MessageBox.Show("El programa funciona correctamente.");
                }
                catch (Exception ex)
                {
                    await RepairProgramAsync();
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        int attempts = 3;
        private async Task RepairProgramAsync()
        {
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var tcs = new TaskCompletionSource<object>();
            var process = Process.Start($"{exeDirectory}\\Scripts de reparacion e inicio automatico\\ReiniciarXampp.bat");
            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => tcs.TrySetResult(null);
            await tcs.Task;
            if (process.ExitCode != 0 && process.ExitCode != -1073741510)
            {
                attempts--;
                while (attempts > 0)
                {
                    try
                    {
                        await CheckConnection();
                        return;
                    }
                    catch (Exception ex)
                    {
                        attempts--;
                    }
                }
                await Task.Run(() => Process.Start($"{exeDirectory}\\Scripts de reparacion e inicio automatico\\cambio_port.bat").WaitForExit());
                cambio_puerto = true;
                MessageBox.Show("No se pudo reparar de manera ordinaria, cambiaremos el puerto de conexion porfavor espere");
            }
        }

    }
}
