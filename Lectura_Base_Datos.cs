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
using System.Configuration;
using Microsoft.Win32;

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
            //mejora de seguridad
            string uid = Properties.Settings1.Default.Usuario;
            string pwd = Properties.Settings1.Default.Contraseña;
            string connectionString = $"server={server};port={port};database={database};uid={uid};pwd={pwd};";
            MySqlConnection? connection = null;
            try
            {
                // creamos la conexión
                connection = new MySqlConnection(connectionString);

                // abrimos la conexión
                connection.Open();
            }
            catch (MySqlException ex)
            {
                registro_errores(ex.ToString());
            }

            // devolvemos la conexión, puede ser nula en caso de error
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return connection;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }

        public List<string[]> LectLista1()
        {
            List<string[]> datos = new List<string[]>();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                string[] fila = new string[42];
                                fila[0] = reader.GetString("Nombre_Completo");
                                fila[1] = reader.GetString("Credito_Prestado");
                                fila[2] = reader.GetString("Fecha_Inicio");
                                fila[3] = reader.GetString("Interes");
                                fila[4] = reader.GetString("Monto_Total");
                                fila[5] = reader.GetString("Promotor");
                                fila[6] = reader.GetString("Calle");
                                fila[7] = reader.GetString("Colonia");
                                fila[8] = reader.GetString("Num_int");
                                fila[9] = reader.GetString("Num_ext");
                                fila[10] = reader.GetString("Telefono");
                                fila[11] = reader.GetString("Correo");

                                //Verifica si el tipo de pago es semanal (0) o quincenal (1)
                                int tipoPago = reader.GetInt32("Tipo_pago");
                                fila[12] = ((tipoPago == 0) ? "Semanal" : "Quincenal");

                                fila[13] = (reader.GetString("Monto_Pagado"));

                                for (int i = 0; i < 14; i++)
                                {
                                    string[] fechaYPago = reader.GetString("Fecha" + (i + 1)).Split("-");
                                    fila[14 + i * 2] = fechaYPago[0];
                                    fila[15 + i * 2] = fechaYPago[1];
                                    //En caso de que sólo tenga 7 fechas
                                    if (string.IsNullOrWhiteSpace(fila[14 + i * 2]))
                                    {
                                        fila[14 + i * 2] = "-";
                                        fila[15 + i * 2] = "-";
                                    }
                                }

                                datos.Add(fila);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        registro_errores(ex.ToString());
                    }
                }
            }

            return datos;
        }

        public List<string[]> LectLista2()
        {
            List<string[]> datos = new List<string[]>();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista2";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string[] fila = new string[16];
                                fila[0] = reader.GetString("Nombre_Completo");
                                fila[1] = reader.GetString("Credito_Prestado");
                                fila[2] = reader.GetString("Fecha_Inicio");
                                fila[3] = reader.GetString("Interes");
                                fila[4] = reader.GetString("Monto_Total");
                                fila[5] = reader.GetString("Promotor");
                                fila[6] = reader.GetString("Calle");
                                fila[7] = reader.GetString("Colonia");
                                fila[8] = reader.GetString("Num_int");
                                fila[9] = reader.GetString("Num_ext");
                                fila[10] = reader.GetString("Telefono");
                                fila[11] = reader.GetString("Correo");
                                fila[12] = reader.GetInt32("Tipo_pago") == 0 ? "Semanal" : "Quincenal";
                                fila[13] = reader.GetString("Monto_Pagado");
                                fila[14] = reader.GetString("Monto_Restante");
                                fila[15] = reader.GetString("Fecha_Limite");
                                datos.Add(fila);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        registro_errores(ex.ToString());
                    }
                }
            }

            return datos;
        }

        public List<string[]> LectLista3()
        {
            List<string[]> datos = new List<string[]>();
            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista3";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            //Lee cada fila de datos en la base de datos
                            while (reader.Read())
                            {
                                string[] fila = new string[15];
                                fila[0] = reader.GetString("Nombre_Completo");
                                fila[1] = reader.GetString("Credito_Prestado");
                                fila[2] = reader.GetString("Fecha_Inicio");
                                fila[3] = reader.GetString("Interes");
                                fila[4] = reader.GetString("Monto_Total");
                                fila[5] = reader.GetString("Promotor");
                                fila[6] = reader.GetString("Calle");
                                fila[7] = reader.GetString("Colonia");
                                fila[8] = reader.GetString("Num_int");
                                fila[9] = reader.GetString("Num_ext");
                                fila[10] = reader.GetString("Telefono");
                                fila[11] = reader.GetString("Correo");
                                //Verifica si el tipo de pago es semanal (0) o quincenal (1)
                                fila[12] = reader.GetInt32("Tipo_pago") == 0 ? "Semanal" : "Quincenal";
                                fila[13] = reader.GetString("Monto_Pagado");
                                fila[14] = reader.GetString("Monto_Restante");

                                datos.Add(fila);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        registro_errores(ex.ToString());
                    }
                }
            }
            return datos;
        }

        public List<string[]> LectLiquidados()
        {
            List<string[]> datos = new List<string[]>();
            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM liquidados";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            //Lee cada fila de datos en la base de datos
                            while (reader.Read())
                            {
                                string[] fila = new string[14];
                                fila[0] = reader.GetString("Nombre_Completo");
                                fila[1] = reader.GetString("Credito_Prestado");
                                fila[2] = reader.GetString("Fecha_Inicio");
                                fila[3] = reader.GetString("Fecha_Ultimo_Pago");
                                fila[4] = reader.GetString("Interes");
                                fila[5] = reader.GetString("Monto_Total");
                                fila[6] = reader.GetString("Promotor");
                                fila[7] = reader.GetString("Calle");
                                fila[8] = reader.GetString("Colonia");
                                fila[9] = reader.GetString("Num_int");
                                fila[10] = reader.GetString("Num_ext");
                                fila[11] = reader.GetString("Telefono");
                                fila[12] = reader.GetString("Correo");
                                //Verifica si el tipo de pago es semanal (0) o quincenal (1)
                                fila[13] = reader.GetInt32("Tipo_pago") == 0 ? "Semanal" : "Quincenal";
                                datos.Add(fila);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        registro_errores(ex.ToString());
                    }
                }
            }
            return datos;
        }
        public List<string[]> LectTodos(string tabla, string lista)
        {
            List<string[]> datos = new List<string[]>();
            using (MySqlConnection connection = Conector())
            {
                try
                {
                    string query = "SELECT * FROM " + tabla;
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            //Lee cada fila de datos en la base de datos
                            while (reader.Read())
                            {
                                string[] fila = new string[14];
                                fila[0] = lista;
                                fila[1] = reader.GetString("Nombre_Completo");
                                fila[2] = reader.GetString("Credito_Prestado");
                                fila[3] = reader.GetString("Fecha_Inicio");
                                fila[4] = reader.GetString("Interes");
                                fila[5] = reader.GetString("Monto_Total");
                                fila[6] = reader.GetString("Promotor");
                                fila[7] = reader.GetString("Calle");
                                fila[8] = reader.GetString("Colonia");
                                fila[9] = reader.GetString("Num_int");
                                fila[10] = reader.GetString("Num_ext");
                                fila[11] = reader.GetString("Telefono");
                                fila[12] = reader.GetString("Correo");
                                //Verifica si el tipo de pago es semanal (0) o quincenal (1)
                                fila[13] = reader.GetInt32("Tipo_pago") == 0 ? "Semanal" : "Quincenal";
                                datos.Add(fila);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    registro_errores(ex.ToString());
                }
            }
            return datos;
        }
        //Leer por un nombre en especifico 
        public string[] LectName(string tabla, string name)
        {
            string[] fila = new string[26];
            using (MySqlConnection connection = Conector())
            {
                try
                {
                    string query = "SELECT * FROM " + tabla + " WHERE Nombre_Completo = @name";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                fila[0] = reader.GetString("Nombre_Completo");
                                fila[1] = reader.GetString("Credito_Prestado");
                                fila[2] = reader.GetString("Fecha_Inicio");
                                fila[3] = reader.GetString("Interes");
                                fila[4] = reader.GetString("Monto_Total");
                                fila[5] = reader.GetString("Promotor");
                                fila[6] = reader.GetString("Calle");
                                fila[7] = reader.GetString("Colonia");
                                fila[8] = reader.GetString("Num_int");
                                fila[9] = reader.GetString("Num_ext");
                                fila[10] = reader.GetString("Telefono");
                                fila[11] = reader.GetString("Correo");
                                fila[12] = reader.GetInt32("Tipo_pago") == 0 ? "Semanal" : "Quincenal";
                                fila[13] = reader.GetString("Monto_Pagado");

                                int fechaCount = fila[12] == "Semanal" ? 14 : 7;

                                for (int i = 0; i < fechaCount; i++)
                                {
                                    fila[i + 14] = reader.GetString("Fecha" + (i + 1));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    registro_errores(ex.ToString());
                }
            }
            return fila;
        }
        //Editar por un nombre especifico
        public void Edit(string tabla, string name, string datos)//falta agregar parametros de recibido pero hasta que la base de datos este lista
        {
            //creamos la conexion
            using(MySqlConnection Connection = Conector())
            {
                try
                {
                    string query = "UPDATE " + tabla + " SET "+ datos + "WHERE Nombre_Completo = @name";
                    using(MySqlCommand command = new MySqlCommand(query, Connection))
                    {
                        command.Parameters.AddWithValue("@name",name) ;
                        

                        //esto nos devuelve el numero de filas que edito
                        command.ExecuteNonQuery();
                        //cerramos la conexion
                        Connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    registro_errores(ex.ToString());
                }
            }
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

        public void create(string lista, string Nombre, string Credito, DateTime Fecha_inicio, string Interes, string Monto_Total, string Promotor, string Calle, string Colonia, string Num_int, string Num_ext, string Telefono, string Correo, int Tipo_pago, string Monto_Pagado)
        {
            DateTime fechaInicio = Fecha_inicio;
            string fechainicio = fechaInicio.ToString("dd/MM/yyyy");

            string[] dias_de_pago;
            if (Tipo_pago == 0)
            {
                dias_de_pago = Enumerable.Range(0, 14)
                    .Select(i => fechaInicio.AddDays(7 * i + 7).ToString("dd/MM/yyyy"))
                    .ToArray();
            }
            else
            {
                dias_de_pago = Enumerable.Range(0, 7)
                    .Select(i => fechaInicio.AddDays(15 * i + 15).ToString("dd/MM/yyyy"))
                    .ToArray();
            }

            using (MySqlConnection connection = Conector())
            {
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("INSERT INTO " + lista + " (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Interes, Monto_Total, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Monto_Pagado");
                for (int i = 1; i <= 14; i++)
                {
                    queryBuilder.Append(", Fecha").Append(i);
                }
                queryBuilder.Append(") VALUES (@Nombre, @Credito, @Fecha_inicio, @Interes, @Monto_Total, @Promotor, @Calle, @Colonia, @Num_int, @Num_ext, @Telefono, @Correo, @Tipo_pago, @Monto_Pagado");
                for (int i = 0; i < 14; i++)
                {
                    queryBuilder.Append(", @Fecha").Append(i + 1);
                }
                queryBuilder.Append(")");
                string query = queryBuilder.ToString();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Credito", Credito);
                    command.Parameters.AddWithValue("@Fecha_inicio", fechainicio);
                    command.Parameters.AddWithValue("@Interes", Interes);
                    command.Parameters.AddWithValue("@Monto_Total", Monto_Total);
                    command.Parameters.AddWithValue("@Promotor", Promotor);
                    command.Parameters.AddWithValue("@Calle", Calle);
                    command.Parameters.AddWithValue("@Colonia", Colonia);
                    command.Parameters.AddWithValue("@Num_int", Num_int);
                    command.Parameters.AddWithValue("@Num_ext", Num_ext);
                    command.Parameters.AddWithValue("@Telefono", Telefono);
                    command.Parameters.AddWithValue("@Correo", Correo);
                    command.Parameters.AddWithValue("@Tipo_pago", Tipo_pago);
                    command.Parameters.AddWithValue("@Monto_Pagado", Monto_Pagado);
                    for (int i = 0; i < dias_de_pago.Length; i++)
                    {
                        command.Parameters.AddWithValue("@Fecha" + (i + 1), dias_de_pago[i] + "-");
                    }
                    if(Tipo_pago == 1)
                    {
                        for(int i = 7; i < 14; i++)
                        {
                            command.Parameters.AddWithValue("@Fecha" + (i + 1), "-");
                        }
                    }
                    try
                    {
                        command.ExecuteNonQuery();
                    }catch(Exception ex)
                    {
                        registro_errores(ex.ToString());
                    }
                   
                   
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
                    registro_errores(ex.ToString());
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
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            var tcs = new TaskCompletionSource<object>();
            var processStartInfo = new ProcessStartInfo
            {
                FileName = $"{exeDirectory}\\Scripts de reparacion e inicio automatico\\ReiniciarMysql.bat",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            var process = Process.Start(processStartInfo);
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            process.EnableRaisingEvents = true;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
#pragma warning disable CS8625 // No se puede convertir un literal NULL en un tipo de referencia que no acepta valores NULL.
            process.Exited += (s, e) => tcs.TrySetResult(null);
#pragma warning restore CS8625 // No se puede convertir un literal NULL en un tipo de referencia que no acepta valores NULL.
            await Task.WhenAny(tcs.Task, Task.Delay(3000)); // Espera hasta que se complete la tarea o hasta 3 segundos
            if (!process.HasExited) // Si el proceso aún no se ha cerrado después de esperar 3 segundos
            {
                process.Kill(); // Forzar la finalización del proceso
            }
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
                        registro_errores(ex.ToString());
                    }
                }
                MessageBox.Show("No se pudo reparar de manera ordinaria, cambiaremos el puerto de conexion porfavor espere");
                var processStartInfo2 = new ProcessStartInfo
                {
                    FileName = $"{exeDirectory}\\Scripts de reparacion e inicio automatico\\cambio_port.bat",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                await Task.Run(() => Process.Start(processStartInfo2));
                cambio_puerto = true;
            }
        }

       public void reacomodo_de_scripts()
        {
            string path = encontrar_xampp();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            string filePath = $"{exeDirectory}\\Scripts de reparacion e inicio automatico\\ReiniciarMysql.bat";
            // Lee el contenido del archivo .bat
            string contenido = File.ReadAllText(filePath);
            // Verifica si el valor ya está presente en el archivo .bat
            if (contenido.Contains("cd /d " + path))
            {
                Console.WriteLine("El valor ya está presente en el archivo .bat. No se realizaron modificaciones.");
                return;
            }
            // Realiza las modificaciones necesarias
            contenido = contenido.Replace("cd /d E:\\Xampp", "cd /d " + path);
            // Guarda los cambios en el archivo
            File.WriteAllText(filePath, contenido);
        }

        public string encontrar_xampp()
        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            string xamppPath = GetXamppInstallationPath();
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            if (!string.IsNullOrEmpty(xamppPath))
            {
                return xamppPath;
            }
            else
            {
                return "c:/Xampp";
            }
        }

        static string? GetXamppInstallationPath()
        {
            string xamppRegistryPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\XAMPP";

#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(xamppRegistryPath))
            {
                if (key != null)
                {
                    string installLocation = key.GetValue("InstallLocation") as string;
                    if (!string.IsNullOrEmpty(installLocation))
                    {
                        return installLocation;
                    }
                }
            }
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL

            // Buscar en todas las unidades en caso de no encontrar en el Registro
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Fixed && drive.IsReady)
                {
                    string drivePath = Path.Combine(drive.RootDirectory.FullName, "Xampp");
                    if (Directory.Exists(drivePath))
                    {
                        return drivePath;
                        
                    }
                }
            }

            return null;
        }
       private void registro_errores(string error)
        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            string logFilePath = $"{exeDirectory}\\Registro de Errores\\Errores.log";
            try
            {
                // Crea un StreamWriter para escribir en el archivo de registro
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    // Escribe la información del error en el archivo
                    writer.WriteLine($"[{DateTime.Now}] Error: {error}");
                }
            }
            catch (Exception ex)
            {
                registro_errores(ex.ToString());
           
            }

        }
    }


   

    }
