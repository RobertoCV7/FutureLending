using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace FutureLending
{
    public class Lectura_Base_Datos
    {
        private readonly MySqlConnection? conexion;
        private static readonly object lockObj = new();
        #region Conexion
        //verificador de cambio de puerto
        public bool cambio_puerto = false;
        public MySqlConnection Conector()
        {
            // Almacenar los valores de configuración en variables locales
            string server = Properties.Settings1.Default.Servidor;
            int port = cambio_puerto ? 3307 : Properties.Settings1.Default.Puerto;
            string database = Properties.Settings1.Default.Base_de_datos;
            string uid = Properties.Settings1.Default.Usuario;
            string pwd = Properties.Settings1.Default.Contraseña;
            string connectionString = $"server={server};port={port};database={database};uid={uid};pwd={pwd};";
            try
            {
                // Crear y abrir la conexión utilizando el bloque 'using'
                MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    // Devolver la conexión
                    return connection;
                
            }
            catch (MySqlException ex)
            {
                Registro_errores(ex.ToString());
                return null; // Devolver null en caso de error
            }
        }

        #endregion
        #region Lectura
        #region Lectura de listas especificas promotores
        public List<string[]> LectLista1Prom(string prom)
        {
            List<string[]> datos = new List<string[]>();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista1 WHERE Promotor = @Promotor";
                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Promotor", prom);

                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string[] fila = new string[10];

                            fila[0] = reader.GetString("Promotor");
                            fila[1] = reader.GetString("Nombre_Completo");
                            fila[2] = reader.GetString("Credito_Prestado");
                            fila[3] = reader.GetString("Pagare");
                            fila[4] = reader.GetString("Fecha_Inicio");
                            fila[5] = reader.GetString("Interes");
                            fila[6] = reader.GetString("Monto_Total");
                            fila[7] = reader.GetString("Tipo_pago");
                            fila[8] = reader.GetString("Monto_Restante");
                            datos.Add(fila);
                            double montoRestante;
                            if (double.TryParse(fila[8], out montoRestante))
                            {
                                Form1.dinero_aire += montoRestante;
                            }
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
                        fila[5] = reader.GetString("Tipo_de_pago");
                        fila[6] = reader.GetString("Liquidacion_Intencion");
                        fila[7] = reader.GetString("Quita");
                        fila[8] = reader.GetString("Pago_Total_EXT");
                        datos.Add(fila);
                        Form1.dinero_aire += Convert.ToDouble(fila[8]);
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
        public List<string[]> LectLista1(bool exp)
        {

            if (exp)
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
                            string[] fila = new string[45];
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
                                string dato = reader.GetString("Fecha" + (i + 1));
                                if (dato.Contains("-") && dato.Contains("/"))
                                {
                                    string[] separado = dato.Split('-');
                                    fila[16 + (i*2)] = separado[0];
                                    fila[17 + (i * 2)] = separado[1];
                                }else if (dato.Contains("/"))
                                {
                                    fila[16 + (i*2)] = dato;
                                    fila[17 + (i *2)] = "-";
                                }

                                // En caso de que alguna fecha sea nula o vacía, se asigna "-"
                                if (string.IsNullOrWhiteSpace(fila[16 + i]))
                                {
                                    fila[16 + i] = "-";
                                    fila[16 + (i + 1)] = "-";
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
            else
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
                            fila[13] = reader.GetString("Tipo_de_pago");
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
                command.ExecuteNonQuery();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
            }
        }
        #endregion
        #region Revisar existencia
        public static bool VerificarUsuarioEnListas(string nombreUsuario)
        {
            Lectura_Base_Datos a = new Lectura_Base_Datos();
            MySqlConnection connection = a.Conector();

            try
            {
                // Verificar si el usuario existe en lista2
                string queryLista2 = "SELECT COUNT(*) FROM lista2 WHERE Nombre_Completo = @nombreUsuario";
                MySqlCommand commandLista2 = new MySqlCommand(queryLista2, connection);
                commandLista2.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                int countLista2 = Convert.ToInt32(commandLista2.ExecuteScalar());

                // Verificar si el usuario existe en lista3
                string queryLista3 = "SELECT COUNT(*) FROM lista3 WHERE Nombre_Completo = @nombreUsuario";
                MySqlCommand commandLista3 = new MySqlCommand(queryLista3, connection);
                commandLista3.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                int countLista3 = Convert.ToInt32(commandLista3.ExecuteScalar());

                if (countLista2 > 0 || countLista3 > 0)
                {
                    // El usuario ya existe en lista2 o lista3
                    return false;
                }
                else
                {
                    // El usuario no existe en lista2 ni lista3
                    return true;
                }
            }
            catch (Exception ex)
            {
                a.Registro_errores("Error al verificar el usuario en las listas: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión de la base de datos
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            // En caso de excepción, retornar false por defecto
            return false;
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
            string server = Properties.Settings1.Default.Servidor;
            int port = cambio_puerto == false ? Properties.Settings1.Default.Puerto : 3307;
            string database = Properties.Settings1.Default.Base_de_datos;
            string username = Properties.Settings1.Default.Usuario;
            string password = Properties.Settings1.Default.Contraseña;
            string connectionString = $"server={server};port={port};database={database};uid={username};pwd={password}";

            using MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                await connection.OpenAsync();

                if (!revisador)
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
                if (!revisador)
                {
                    ReacomodoDeScripts();
                    Registro_errores(ex.ToString());
                    await RepairProgramAsync();
                }

                return;
            }
        }
        int attempts = 3;
        private async Task RepairProgramAsync()
        {
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var processStartInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(exeDirectory, "Scripts de reparacion e inicio automatico", "ReiniciarMysql.bat"),
                CreateNoWindow = true,
                UseShellExecute = false
            };

            var process = Process.Start(processStartInfo);
            var processExitTask = Task.Run(() => process.WaitForExit(3000));

            if (await Task.WhenAny(processExitTask, Task.Delay(3000)) != processExitTask)
            {
                process.Kill();
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

                Form1.MessageB("Cambiando de Puerto", "Alerta", 2);

                var cambioPortProcessStartInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(exeDirectory, "Scripts de reparacion e inicio automatico", "cambio_port.bat"),
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                await Task.Run(() => Process.Start(cambioPortProcessStartInfo));

                cambio_puerto = true;
            }
        }

        public static void ReacomodoDeScripts()
        {
            string path = EncontrarXampp();
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(exeDirectory, "Scripts de reparacion e inicio automatico", "ReiniciarMysql.bat");

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

            return "c:/Xampp";
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
        private static readonly object lockObject = new object(); // Objeto de bloqueo para asegurar acceso único al archivo
        public void Registro_errores(string error)
        {
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string logFilePath = $"{exeDirectory}\\Registro de Errores\\Errores.log";

            try
            {
                lock (lockObject)
                {
                    using StreamWriter writer = new StreamWriter(logFilePath, true);
                    writer.WriteLine($"[{DateTime.Now}] Error: {error}");
                }
            }
            catch (Exception ex)
            { 
                ex.ToString();
                // Si ocurre un error al registrar el error, no se hace nada para evitar un ciclo infinito
            }
        }
        public void Registro_Usuarios(string acceso)
        {
            using MySqlConnection connection = Conector();
            string query = "INSERT INTO accesos (fecha, usuario) VALUES (@fecha, @usuario)";
            try
            {
                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("f"));
                command.Parameters.AddWithValue("@usuario", acceso);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
            }
        }
        #endregion

    }
}
