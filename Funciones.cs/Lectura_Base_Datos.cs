using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace FutureLending
{
    public class Lectura_Base_Datos
    {
#pragma warning disable CS0649 // El campo 'Lectura_Base_Datos.conexion' nunca se asigna y siempre tendrá el valor predeterminado null
        private readonly MySqlConnection? conexion;
#pragma warning restore CS0649 // El campo 'Lectura_Base_Datos.conexion' nunca se asigna y siempre tendrá el valor predeterminado null
        private static readonly object lockObj = new();
        #region Conexion
        //verificador de cambio de puerto
        public bool cambio_puerto = false;


        public MySqlConnection Conector()
        {

            // Creamos la conexión verificando si se ha cambiado el puerto usando el archivo de configuración
            string server = Properties.Settings1.Default.Servidor;
            int port;
            if (cambio_puerto == false)
            {
                port = Properties.Settings1.Default.Puerto;
            }
            else
            {
                Properties.Settings1.Default.Puerto = 3307;
                port = Properties.Settings1.Default.Puerto;
            }
            string database = Properties.Settings1.Default.Base_de_datos;
            string uid = Properties.Settings1.Default.Usuario;
            string pwd = Properties.Settings1.Default.Contraseña;

            string connectionString = $"server={server};port={port};database={database};uid={uid};pwd={pwd};";
            MySqlConnection? connection = null;

            lock (lockObj) // Bloqueo para asegurar el acceso exclusivo
            {
                try
                {
                    // Creamos la conexión
                    connection = new MySqlConnection(connectionString);

                    // Abrimos la conexión
                    connection.Open();
                }
                catch (MySqlException ex)
                {
                    Registro_errores(ex.ToString());
                }
            }

            // Devolvemos la conexión, que puede ser nula en caso de error
            return connection;
        }
        #endregion
        #region Lectura
        #region Lectura de listas especificas promotores
        public List<string[]> LectLista1Prom(string prom)
        {
            List<string[]> datos = new();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista1 Where Promotor = @Promotor";
                using MySqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Promotor", prom);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] fila = new string[30];
                        fila[0] = reader.GetString("Promotor");
                        fila[1] = reader.GetString("Nombre_Completo");
                        fila[2] = reader.GetString("Credito_Prestado");
                        fila[3] = reader.GetString("Pagare");
                        fila[4] = reader.GetString("Fecha_Inicio");
                        fila[5] = reader.GetString("Fecha_Termino");
                        fila[6] = reader.GetString("Interes");
                        fila[7] = reader.GetString("Monto_Total");
                        fila[8] = reader.GetString("Calle");
                        fila[9] = reader.GetString("Colonia");
                        fila[10] = reader.GetString("Num_int");
                        fila[11] = reader.GetString("Num_ext");
                        fila[12] = reader.GetString("Telefono");
                        fila[13] = reader.GetString("Correo");
                        fila[14] = reader.GetString("Tipo_pago");
                        fila[15] = reader.GetString("Monto_Restante");

                        for (int i = 0; i < 14; i++)
                        {
                            fila[16 + i] = reader.GetString("Fecha" + (i + 1));
                            // En caso de que alguna fecha sea nula o vacía, se asigna "-"
                            if (string.IsNullOrWhiteSpace(fila[16 + i]))
                            {
                                fila[16 + i] = "-";
                            }
                        }

                        datos.Add(fila);
                        Form1.dinero_aire += Convert.ToDouble(fila[15]);
                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                }
            }

            return datos;
        }
        public List<string[]> LectLista2Prom(string prom)
        {
            List<string[]> datos = new();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista2 Where Promotor = @Promotor";
                using MySqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@Promotor", prom);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] fila = new string[43]; // Modificar el tamaño del arreglo para ajustarlo a la cantidad de campos

                        fila[0] = reader.GetString("Promotor");
                        fila[1] = reader.GetString("Nombre_Completo");
                        fila[2] = reader.GetString("Credito_Prestado");
                        fila[3] = reader.GetString("Monto_Restante");
                        fila[4] = reader.GetString("Pagare");
                        fila[5] = reader.GetString("Calle");
                        fila[6] = reader.GetString("Colonia");
                        fila[7] = reader.GetString("Num_int");
                        fila[8] = reader.GetString("Num_ext");
                        fila[9] = reader.GetString("Telefono");
                        fila[10] = reader.GetString("Correo");
                        fila[11] = reader.GetString("Tipo_de_pago");
                        fila[12] = reader.GetString("Liquidacion_Intencion");
                        fila[13] = reader.GetString("Quita");

                        for (int i = 0; i < 14; i++)
                        {
                            string fechaCampo = "FECHA" + (i + 1);
                            string pagoCampo = "PAGO" + (i + 1);
                            fila[14 + (i * 2)] = reader.GetString(fechaCampo);
                            fila[15 + (i * 2)] = reader.GetString(pagoCampo);

                        }
                        fila[42] = reader.GetString("Pago_Total_EXT");
                        datos.Add(fila);
                        Form1.dinero_aire += Convert.ToDouble(fila[42]);
                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                }
            }

            return datos;
        }

        #endregion


        #region Lectura de Listas general
        public List<string[]> LectLista1()
        {
            List<string[]> datos = new();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista1 ORDER BY Promotor ASC";
                using MySqlCommand command = new(query, connection);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] fila = new string[30];
                        fila[0] = reader.GetString("Promotor");
                        fila[1] = reader.GetString("Nombre_Completo");
                        fila[2] = reader.GetString("Credito_Prestado");
                        fila[3] = reader.GetString("Pagare");
                        fila[4] = reader.GetString("Fecha_Inicio");
                        fila[5] = reader.GetString("Fecha_Termino");
                        fila[6] = reader.GetString("Interes");
                        fila[7] = reader.GetString("Monto_Total");
                        fila[8] = reader.GetString("Calle");
                        fila[9] = reader.GetString("Colonia");
                        fila[10] = reader.GetString("Num_int");
                        fila[11] = reader.GetString("Num_ext");
                        fila[12] = reader.GetString("Telefono");
                        fila[13] = reader.GetString("Correo");
                        fila[14] = reader.GetString("Tipo_pago");
                        fila[15] = reader.GetString("Monto_Restante");

                        for (int i = 0; i < 14; i++)
                        {
                            fila[16 + i] = reader.GetString("Fecha" + (i + 1));
                            // En caso de que alguna fecha sea nula o vacía, se asigna "-"
                            if (string.IsNullOrWhiteSpace(fila[16 + i]))
                            {
                                fila[16 + i] = "-";
                            }
                        }

                        datos.Add(fila);
                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                }
            }

            return datos;
        }
        public List<string[]> LectLista2()
        {
            List<string[]> datos = new();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista2 ORDER BY Promotor ASC";
                using MySqlCommand command = new(query, connection);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] fila = new string[43]; // Modificar el tamaño del arreglo para ajustarlo a la cantidad de campos

                        fila[0] = reader.GetString("Promotor");
                        fila[1] = reader.GetString("Nombre_Completo");
                        fila[2] = reader.GetString("Credito_Prestado");
                        fila[3] = reader.GetString("Monto_Restante");
                        fila[4] = reader.GetString("Pagare");
                        fila[5] = reader.GetString("Calle");
                        fila[6] = reader.GetString("Colonia");
                        fila[7] = reader.GetString("Num_int");
                        fila[8] = reader.GetString("Num_ext");
                        fila[9] = reader.GetString("Telefono");
                        fila[10] = reader.GetString("Correo");
                        fila[11] = reader.GetString("Tipo_de_pago");
                        fila[12] = reader.GetString("Liquidacion_Intencion");
                        fila[13] = reader.GetString("Quita");

                        for (int i = 0; i < 14; i++)
                        {
                            string fechaCampo = "FECHA" + (i + 1);
                            string pagoCampo = "PAGO" + (i + 1);
                            fila[14 + (i * 2)] = reader.GetString(fechaCampo);
                            fila[15 + (i * 2)] = reader.GetString(pagoCampo);

                        }
                        fila[42] = reader.GetString("Pago_Total_EXT");
                        datos.Add(fila);
                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                }
            }

            return datos;
        }
        public List<string[]> LectLista3()
        {
            List<string[]> datos = new();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista3";
                using MySqlCommand command = new(query, connection);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] fila = new string[13]; // Modificar el tamaño del arreglo para ajustarlo a la cantidad de campos

                        fila[0] = reader.GetString("Promotor");
                        fila[1] = reader.GetString("Nombre_Completo");
                        fila[2] = reader.GetString("Credito_Prestado");
                        fila[3] = reader.GetString("Pagare");
                        fila[4] = reader.GetString("Calle");
                        fila[5] = reader.GetString("Colonia");
                        fila[6] = reader.GetString("Num_int");
                        fila[7] = reader.GetString("Num_ext");
                        fila[8] = reader.GetString("Telefono");
                        fila[9] = reader.GetString("Correo");
                        fila[10] = reader.GetString("Tipo_de_Resolucion");
                        fila[11] = reader.GetString("Resolucion_Demanda");
                        fila[12] = reader.GetString("Importe");

                        datos.Add(fila);
                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                }
            }

            return datos;
        }
        public List<string[]> LectLiquidados()
        {
            List<string[]> datos = new();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM liquidados ORDER BY Promotor ASC";
                using MySqlCommand command = new(query, connection);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] fila = new string[11];
                        fila[0] = reader.GetString("Promotor");
                        fila[1] = reader.GetString("Nombre_Completo");
                        fila[2] = reader.GetString("Credito_Prestado");
                        fila[3] = reader.GetString("Fecha_Inicio");
                        fila[4] = reader.GetString("Calle");
                        fila[5] = reader.GetString("Colonia");
                        fila[6] = reader.GetString("Num_int");
                        fila[7] = reader.GetString("Num_ext");
                        fila[8] = reader.GetString("Telefono");
                        fila[9] = reader.GetString("Correo");
                        fila[10] = reader.GetString("Forma_Liquidacion");

                        datos.Add(fila);
                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                }
            }

            return datos;
        }
        public List<string[]>  LectTodos(string tabla, string lista)
        {
            List<string[]> datos = new();
            using (MySqlConnection connection = Conector())
            {
                try
                {
                    string query = "SELECT * FROM " + tabla + " ORDER BY Promotor ASC";
                    using MySqlCommand command = new(query, connection);
                    using MySqlDataReader reader = command.ExecuteReader();
                    //Lee cada fila de datos en la base de datos
                    while (reader.Read())
                    {
                        if (tabla == "lista1")
                        {
                            string[] fila = new string[14];
                            fila[0] = lista;
                            fila[1] = reader.GetString("Promotor");
                            fila[2] = reader.GetString("Nombre_Completo");
                            fila[3] = reader.GetString("Credito_Prestado");
                            fila[4] = reader.GetString("Fecha_Inicio");
                            fila[5] = reader.GetString("Interes");
                            fila[6] = reader.GetString("Monto_Total");
                            fila[7] = reader.GetString("Calle");
                            fila[8] = reader.GetString("Colonia");
                            fila[9] = reader.GetString("Num_int");
                            fila[10] = reader.GetString("Num_ext");
                            fila[11] = reader.GetString("Telefono");
                            fila[12] = reader.GetString("Correo");
                            fila[13] = reader.GetString("Tipo_pago");
                            datos.Add(fila);
                        }
                        else if (tabla == "lista2")
                        {
                            string[] fila = new string[14];
                            fila[0] = lista;
                            fila[1] = reader.GetString("Promotor");
                            fila[2] = reader.GetString("Nombre_Completo");
                            fila[3] = reader.GetString("Credito_Prestado");
                            fila[4] = "-";
                            fila[5] = "-";
                            fila[6] = "-";
                            fila[7] = reader.GetString("Calle");
                            fila[8] = reader.GetString("Colonia");
                            fila[9] = reader.GetString("Num_int");
                            fila[10] = reader.GetString("Num_ext");
                            fila[11] = reader.GetString("Telefono");
                            fila[12] = reader.GetString("Correo");
                            fila[13] = reader.GetString("Tipo_pago");
                            datos.Add(fila);
                        }
                        else if (tabla == "lista3")
                        {
                            string[] fila = new string[14];
                            fila[0] = lista;
                            fila[1] = reader.GetString("Promotor");
                            fila[2] = reader.GetString("Nombre_Completo");
                            fila[3] = reader.GetString("Credito_Prestado");
                            fila[4] = "-";
                            fila[5] = "-";
                            fila[6] = "-";
                            fila[7] = reader.GetString("Calle");
                            fila[8] = reader.GetString("Colonia");
                            fila[9] = reader.GetString("Num_int");
                            fila[10] = reader.GetString("Num_ext");
                            fila[11] = reader.GetString("Telefono");
                            fila[12] = reader.GetString("Correo");
                            fila[13] = reader.GetString("Tipo_de_Resolucion");
                            datos.Add(fila);
                        }
                        else
                        {
                            string[] fila = new string[14];
                            fila[0] = lista;
                            fila[1] = reader.GetString("Promotor");
                            fila[2] = reader.GetString("Nombre_Completo");
                            fila[3] = reader.GetString("Credito_Prestado");
                            fila[4] = reader.GetString("Fecha_Inicio");
                            fila[5] = "-";
                            fila[6] = "-";
                            fila[7] = reader.GetString("Calle");
                            fila[8] = reader.GetString("Colonia");
                            fila[9] = reader.GetString("Num_int");
                            fila[10] = reader.GetString("Num_ext");
                            fila[11] = reader.GetString("Telefono");
                            fila[12] = reader.GetString("Correo");
                            fila[13] = reader.GetString("Forma_Liquidacion");
                            datos.Add(fila);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                }
            }
            return datos;
        }
        #endregion
        #endregion
        #region editar, borrar y crear


        #region Borrar General
        public void Erase(string nombre, string tabla)
        {
            //Llamamos al conector
            using MySqlConnection Connection = Conector();
            using MySqlCommand command = Connection.CreateCommand();
            try
            {
                command.CommandText = "DELETE FROM " + tabla + " WHERE Nombre_Completo = '" + nombre + "'";

                //esto nos devuelve el numero de filas que edito
                int filasAfectadas = command.ExecuteNonQuery();
                //cerramos la conexion
                Connection.Close();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
            }
        }
        #endregion
        #region Crear registros, solo en la lista 1 y liquidados
        public void Create(string lista, string Promotor, string Nombre, string Credito, string Pagare, DateTime Fecha_inicio, DateTime Fecha_Termino, string Interes, string Monto_Total, string Calle, string Colonia, string Num_int, string Num_ext, string Telefono, string Correo, string Tipo_pago, string Monto_Restante)
        {
            DateTime fechaInicio = Fecha_inicio.Date;
            int cantidadFechas = Tipo_pago == "Semanales" ? 14 : 7;
            string[] dias_de_pago = new string[cantidadFechas];

            int incremento = Tipo_pago == "Semanales" ? 7 : 15;

            for (int i = 0; i < cantidadFechas; i++)
            {
                dias_de_pago[i] = fechaInicio.AddDays(incremento * (i + 1)).ToString("dd/MM/yyyy");
            }

            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO ");
            queryBuilder.Append(lista);
            queryBuilder.Append(" (Promotor, Nombre_Completo, Credito_Prestado, Pagare, Fecha_Inicio, Fecha_Termino, Interes, Monto_Total, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Monto_Restante");

            for (int i = 1; i <= cantidadFechas; i++)
            {
                queryBuilder.Append(", Fecha");
                queryBuilder.Append(i);
            }

            queryBuilder.Append(") VALUES (@Promotor, @Nombre, @Credito, @Pagare, @Fecha_inicio, @Fecha_Termino, @Interes, @Monto_Total, @Calle, @Colonia, @Num_int, @Num_ext, @Telefono, @Correo, @Tipo_pago, @Monto_Restante");

            for (int i = 1; i <= cantidadFechas; i++)
            {
                queryBuilder.Append(", @Fecha");
                queryBuilder.Append(i);
            }

            queryBuilder.Append(')');

            string consulta = queryBuilder.ToString();

            using MySqlCommand command = new(consulta, connection);

            command.Parameters.AddWithValue("@Promotor", Promotor);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Credito", Credito);
            command.Parameters.AddWithValue("@Pagare", Pagare);
            command.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio.ToString("dd/MM/yyyy"));
            command.Parameters.AddWithValue("@Fecha_Termino", Fecha_Termino.ToString("dd/MM/yyyy"));
            command.Parameters.AddWithValue("@Interes", Interes);
            command.Parameters.AddWithValue("@Monto_Total", Monto_Total);
            command.Parameters.AddWithValue("@Calle", Calle);
            command.Parameters.AddWithValue("@Colonia", Colonia);
            command.Parameters.AddWithValue("@Num_int", Num_int);
            command.Parameters.AddWithValue("@Num_ext", Num_ext);
            command.Parameters.AddWithValue("@Telefono", Telefono);
            command.Parameters.AddWithValue("@Correo", Correo);
            command.Parameters.AddWithValue("@Tipo_pago", Tipo_pago);
            command.Parameters.AddWithValue("@Monto_Restante", Monto_Restante);

            for (int i = 1; i <= 14; i++)
            {
                if (i <= dias_de_pago.Length)
                {
                    command.Parameters.AddWithValue("@Fecha" + i, dias_de_pago[i - 1]);
                }
                else
                {
                    command.Parameters.AddWithValue("@Fecha" + i, "-");
                }
            }


            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());

                if (ex.ToString().Contains("Duplicate entry"))
                {
                    Form1.MessageB("Este usuario ya existe!!!", "Alerta", 2);
                }
            }
        }
        public bool InsertarLiquidados(string[] datos)
        {
            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO liquidados (Promotor, Nombre_Completo, Credito_Prestado, Fecha_Inicio, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Forma_Liquidacion)");
            queryBuilder.Append(" VALUES (@Promotor, @Nombre, @Credito, @FechaI, @Calle, @Colonia, @NumI, @NumE, @Telefono, @Correo, @FormaLiquidacion)");
            string query = queryBuilder.ToString();

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Promotor", datos[0]);
            command.Parameters.AddWithValue("@Nombre", datos[1]);
            command.Parameters.AddWithValue("@Credito", datos[2]);
            command.Parameters.AddWithValue("@FechaI", datos[3]);
            command.Parameters.AddWithValue("@Calle", datos[4]);
            command.Parameters.AddWithValue("@Colonia", datos[5]);
            command.Parameters.AddWithValue("@NumI", datos[6]);
            command.Parameters.AddWithValue("@NumE", datos[7]);
            command.Parameters.AddWithValue("@Telefono", datos[8]);
            command.Parameters.AddWithValue("@Correo", datos[9]);
            command.Parameters.AddWithValue("@FormaLiquidacion", datos[10]);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
                return false;
            }
        }
        public bool InsertarLista2(string[] valores)
        {
            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO lista2 (Promotor, Nombre_Completo, Credito_Prestado, Monto_Restante, Pagare, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_de_pago, Liquidacion_Intencion, Quita, FECHA1, PAGO1, FECHA2, PAGO2, FECHA3, PAGO3, FECHA4, PAGO4, FECHA5, PAGO5, FECHA6, PAGO6, FECHA7, PAGO7, FECHA8, PAGO8, FECHA9, PAGO9, FECHA10, PAGO10, FECHA11, PAGO11, FECHA12, PAGO12, FECHA13, PAGO13, FECHA14, PAGO14,Pago_Total_EXT)");
            queryBuilder.Append(" VALUES (@Promotor, @Nombre, @Credito, @MontoRestante, @Pagare, @Calle, @Colonia, @NumInt, @NumExt, @Telefono, @Correo, @TipoPago, @LiquidacionIntencion, @Quita, @Fecha1, @Pago1, @Fecha2, @Pago2, @Fecha3, @Pago3, @Fecha4, @Pago4, @Fecha5, @Pago5, @Fecha6, @Pago6, @Fecha7, @Pago7, @Fecha8, @Pago8, @Fecha9, @Pago9, @Fecha10, @Pago10, @Fecha11, @Pago11, @Fecha12, @Pago12, @Fecha13, @Pago13, @Fecha14, @Pago14,@PagoEXT)");
            string query = queryBuilder.ToString();

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Promotor", valores[0]);
            command.Parameters.AddWithValue("@Nombre", valores[1]);
            command.Parameters.AddWithValue("@Credito", valores[2]);
            command.Parameters.AddWithValue("@MontoRestante", valores[3]);
            command.Parameters.AddWithValue("@Pagare", valores[4]);
            command.Parameters.AddWithValue("@Calle", valores[5]);
            command.Parameters.AddWithValue("@Colonia", valores[6]);
            command.Parameters.AddWithValue("@NumInt", valores[7]);
            command.Parameters.AddWithValue("@NumExt", valores[8]);
            command.Parameters.AddWithValue("@Telefono", valores[9]);
            command.Parameters.AddWithValue("@Correo", valores[10]);
            command.Parameters.AddWithValue("@TipoPago", valores[11]);
            command.Parameters.AddWithValue("@LiquidacionIntencion", valores[12]);
            command.Parameters.AddWithValue("@Quita", valores[13]);
            command.Parameters.AddWithValue("@Fecha1", valores[14]);
            command.Parameters.AddWithValue("@Pago1", valores[15]);
            command.Parameters.AddWithValue("@Fecha2", valores[16]);
            command.Parameters.AddWithValue("@Pago2", valores[17]);
            command.Parameters.AddWithValue("@Fecha3", valores[18]);
            command.Parameters.AddWithValue("@Pago3", valores[19]);
            command.Parameters.AddWithValue("@Fecha4", valores[20]);
            command.Parameters.AddWithValue("@Pago4", valores[21]);
            command.Parameters.AddWithValue("@Fecha5", valores[22]);
            command.Parameters.AddWithValue("@Pago5", valores[23]);
            command.Parameters.AddWithValue("@Fecha6", valores[24]);
            command.Parameters.AddWithValue("@Pago6", valores[25]);
            command.Parameters.AddWithValue("@Fecha7", valores[26]);
            command.Parameters.AddWithValue("@Pago7", valores[27]);
            command.Parameters.AddWithValue("@Fecha8", valores[28]);
            command.Parameters.AddWithValue("@Pago8", valores[29]);
            command.Parameters.AddWithValue("@Fecha9", valores[30]);
            command.Parameters.AddWithValue("@Pago9", valores[31]);
            command.Parameters.AddWithValue("@Fecha10", valores[32]);
            command.Parameters.AddWithValue("@Pago10", valores[33]);
            command.Parameters.AddWithValue("@Fecha11", valores[34]);
            command.Parameters.AddWithValue("@Pago11", valores[35]);
            command.Parameters.AddWithValue("@Fecha12", valores[36]);
            command.Parameters.AddWithValue("@Pago12", valores[37]);
            command.Parameters.AddWithValue("@Fecha13", valores[38]);
            command.Parameters.AddWithValue("@Pago13", valores[39]);
            command.Parameters.AddWithValue("@Fecha14", valores[40]);
            command.Parameters.AddWithValue("@Pago14", valores[41]);
            command.Parameters.AddWithValue("@PagoEXT", valores[42]);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
                return false;
            }
        }
        public bool InsertarLista3(string[] valores)
        {
            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO lista3 (Promotor, Nombre_Completo, Credito_Prestado, Pagare, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_de_Resolucion, Resolucion_Demanda, Importe)");
            queryBuilder.Append(" VALUES (@Promotor, @Nombre, @Credito, @Pagare, @Calle, @Colonia, @NumInt, @NumExt, @Telefono, @Correo, @TipoResolucion, @ResolucionDemanda, @Importe)");
            string query = queryBuilder.ToString();

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Promotor", valores[0]);
            command.Parameters.AddWithValue("@Nombre", valores[1]);
            command.Parameters.AddWithValue("@Credito", valores[2]);
            command.Parameters.AddWithValue("@Pagare", valores[3]);
            command.Parameters.AddWithValue("@Calle", valores[4]);
            command.Parameters.AddWithValue("@Colonia", valores[5]);
            command.Parameters.AddWithValue("@NumInt", valores[6]);
            command.Parameters.AddWithValue("@NumExt", valores[7]);
            command.Parameters.AddWithValue("@Telefono", valores[8]);
            command.Parameters.AddWithValue("@Correo", valores[9]);
            command.Parameters.AddWithValue("@TipoResolucion", valores[10]);
            command.Parameters.AddWithValue("@ResolucionDemanda", valores[11]);
            command.Parameters.AddWithValue("@Importe", valores[12]);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
                return false;
            }
        }

        #endregion
        #endregion
        #region reparar conexion
        public async Task CheckConnection(bool revisador)
        {
            Form1 a = new();
            ReacomodoDeScripts();
            string server = Properties.Settings1.Default.Servidor;
            int port;
            if (cambio_puerto == false)
            {
                port = Properties.Settings1.Default.Puerto;
            }
            else
            {
                Properties.Settings1.Default.Puerto = 3307;
                port = Properties.Settings1.Default.Puerto;
            }
            string database = Properties.Settings1.Default.Base_de_datos;
            string username = Properties.Settings1.Default.Usuario;
            string password = Properties.Settings1.Default.Contraseña;
            string connectionString = $"server={server};port={port};database={database};uid={username};pwd={password}";
            using MySqlConnection connection = new(connectionString);
            try
            {
                await connection.OpenAsync();
                if (revisador == false)
                {
                    Form1.MessageB("La Aplicacion Funciona Correctamente", "Funcionando", 1);
                }
                else
                {
                    Form1.conect = true;
                }
            }
            catch (Exception ex)
            {
                if (revisador == false)
                {
                    Registro_errores(ex.ToString());
                    await RepairProgramAsync();
                }
                else
                {
                    return;
                }

            }
            finally
            {
                connection.Close();
            }
        }
        int attempts = 3;

        public MySqlConnection? Conexion => conexion;

        private async Task RepairProgramAsync()
        {
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var tcs = new TaskCompletionSource<object>();
            var processStartInfo = new ProcessStartInfo
            {
                FileName = $"{exeDirectory}\\Scripts de reparacion e inicio automatico\\ReiniciarMysql.bat",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            var process = Process.Start(processStartInfo);
            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => tcs.TrySetResult(null);
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
                        await CheckConnection(false);
                        return;
                    }
                    catch (Exception ex)
                    {
                        attempts--;
                        Registro_errores(ex.ToString());
                    }
                }
                Form1.MessageB("Cambiando de Puerto", "Cambio de Puerto", 2);
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

        public static void ReacomodoDeScripts()
        {
            string path = EncontrarXampp();
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = $"{exeDirectory}\\Scripts de reparacion e inicio automatico\\ReiniciarMysql.bat";
            // Lee el contenido del archivo .bat
            string contenido = File.ReadAllText(filePath);
            // Verifica si el valor ya está presente en el archivo .bat
            if (contenido.Contains("cd /d " + path))
            {
                return;
            }
            // Realiza las modificaciones necesarias
            contenido = contenido.Replace("cd /d E:\\Xampp", "cd /d " + path);
            // Guarda los cambios en el archivo
            File.WriteAllText(filePath, contenido);
        }

        public static string EncontrarXampp()
        {
            string xamppPath = GetXamppInstallationPath();
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
        #endregion
        #region registros
        public void Registro_errores(string error)
        {
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string logFilePath = $"{exeDirectory}\\Registro de Errores\\Errores.log";
            try
            {
                // Crea un StreamWriter para escribir en el archivo de registro
                using StreamWriter writer = new(logFilePath, true);
                // Escribe la información del error en el archivo
                writer.WriteLine(value: $"[{DateTime.Now}] Error: {error}");
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());

            }

        }
        public void Registro_Usuarios(string acceso)
        {
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string logFilePath = $"{exeDirectory}\\Registro de Errores\\RegistroInicios.log";
            try
            {
                // Crea un StreamWriter para escribir en el archivo de registro
                using StreamWriter writer = new(logFilePath, true);
                // Escribe la información del error en el archivo
                writer.WriteLine($"[{DateTime.Now}] Acceso este usuario: {acceso}");
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());

            }

        }



        #endregion

    }
}
