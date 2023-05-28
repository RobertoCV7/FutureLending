using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Microsoft.Win32;
using System.Data;
using Bunifu.Framework.UI;
using System.Data.SqlClient;

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
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return connection;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }
        public void CerrarConexion()
        {
    
            if (Conexion != null && Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
                Conexion.Dispose();
            }

        }


        #endregion
        #region Lectura
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
            List<string[]> datos = new List<string[]>();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista2";
                using MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string[] fila = new string[41]; // Modificar el tamaño del arreglo para ajustarlo a la cantidad de campos

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
                            string fechaCampo = "FECHA" + (i + 1).ToString();
                            string pagoCampo = "PAGO" + (i + 1).ToString();
                            if (i == 0)
                            {
                                fila[14] = reader.GetString(fechaCampo);
                                fila[15] = reader.GetString(pagoCampo);
                            }
                            else
                            {
                                fila[16 + (i + 1)] = reader.GetString(fechaCampo);
                                fila[17 + (i + 1)] = reader.GetString(pagoCampo);
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
        public List<string[]> LectLista3()
        {
            List<string[]> datos = new List<string[]>();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista3";
                using MySqlCommand command = new MySqlCommand(query, connection);
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
                    }
                    catch (Exception ex)
                    {
                        Registro_errores(ex.ToString());
                    }
                }
            }

            return datos;
        }
        public List<string[]> LectTodos(string tabla, string lista)
        {
            List<string[]> datos = new();
            using (MySqlConnection connection = Conector())
            {
                try
                {
                    string query = "SELECT * FROM " + tabla;
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
            string fechainicio = Fecha_inicio.ToString("dd/MM/yyyy");
            string fechafinal = Fecha_Termino.ToString("dd/MM/yyyy");
            string[] dias_de_pago = new string[14];
            if (Tipo_pago == "Semanal")
            {
                for (int i = 0; i < 14; i++)
                {
                    dias_de_pago[i] = fechaInicio.AddDays(14 * (i + 1)).ToString("dd/MM/yyyy");
                }
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    dias_de_pago[i] = fechaInicio.AddDays(15 * (i + 1)).ToString("dd/MM/yyyy");
                }

            }

            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO " + lista + " (Promotor, Nombre_Completo, Credito_Prestado, Pagare, Fecha_Inicio, Fecha_Termino, Interes, Monto_Total, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Monto_Restante");
            for (int i = 1; i <= 14; i++)
            {
                queryBuilder.Append(", Fecha").Append(i);
            }
            queryBuilder.Append(") VALUES (@Promotor, @Nombre, @Credito, @Pagare, @Fecha_inicio, @Fecha_Termino, @Interes, @Monto_Total, @Calle, @Colonia, @Num_int, @Num_ext, @Telefono, @Correo, @Tipo_pago, @Monto_Restante");
            for (int i = 1; i <= 14; i++)
            {
                queryBuilder.Append(", @Fecha").Append(i);
            }
            queryBuilder.Append(')');
            string query = queryBuilder.ToString();
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Promotor", Promotor);
            command.Parameters.AddWithValue("@Nombre", Nombre);
            command.Parameters.AddWithValue("@Credito", Credito);
            command.Parameters.AddWithValue("@Pagare", Pagare);
            command.Parameters.AddWithValue("@Fecha_inicio", fechainicio);
            command.Parameters.AddWithValue("@Fecha_Termino", fechafinal);
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
            for (int i = 0; i < dias_de_pago.Length; i++)
            {
                if (dias_de_pago[i] == null)
                {
                    command.Parameters.AddWithValue("@Fecha" + (i + 1), "-");
                }
                else
                {
                    command.Parameters.AddWithValue("@Fecha" + (i + 1), dias_de_pago[i]);
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
        public void CreateLiquidados(int lista, string[] datos)
        {
            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO liquidados (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Fecha_Ultimo_Pago, Interes, Monto_Total, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago");
            queryBuilder.Append(") VALUES (@Nombre, @Credito, @FechaI, @FechaUP, @Interes, @Monto, @Promotor, @Calle, @Colonia, @NumI, @NumE, @Telefono, @Correo, @TipoP)");
            string query = queryBuilder.ToString();
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Nombre", datos[0]);
            command.Parameters.AddWithValue("@Credito", datos[1]);
            command.Parameters.AddWithValue("@FechaI", datos[2]);
            if(lista == 1)
            {
                string[] fecha;
                fecha = datos[12] == "0" ? datos[27].Split("-") : datos[20].Split("-");
                command.Parameters.AddWithValue("@FechaUP", fecha[0]);
            }
            else
            {
                command.Parameters.AddWithValue("@FechaUP", datos[14]);
            }
            
            command.Parameters.AddWithValue("@Interes", datos[3]);
            command.Parameters.AddWithValue("@Monto", datos[4]);
            command.Parameters.AddWithValue("@Promotor", datos[5]);
            command.Parameters.AddWithValue("@Calle", datos[6]);
            command.Parameters.AddWithValue("@Colonia", datos[7]);
            command.Parameters.AddWithValue("@NumI", datos[8]);
            command.Parameters.AddWithValue("@NumE", datos[9]);
            command.Parameters.AddWithValue("@Telefono", datos[10]);
            command.Parameters.AddWithValue("@Correo", datos[11]);
            command.Parameters.AddWithValue("@TipoP", lista);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
            }
        }
        public void InsertarLiquidados(string[] datos)
        {
            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO liquidados (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Fecha_Ultimo_Pago, Interes, Monto_Total, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago)");
            queryBuilder.Append(" VALUES (@Nombre, @Credito, @FechaI, @FechaUP, @Interes, @Monto, @Promotor, @Calle, @Colonia, @NumI, @NumE, @Telefono, @Correo, @TipoP)");
            string query = queryBuilder.ToString();

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Nombre", datos[0]);
            command.Parameters.AddWithValue("@Credito", datos[1]);
            command.Parameters.AddWithValue("@FechaI", datos[2]);
            command.Parameters.AddWithValue("@FechaUP", datos[3]);
            command.Parameters.AddWithValue("@Interes", datos[4]);
            command.Parameters.AddWithValue("@Monto", datos[5]);
            command.Parameters.AddWithValue("@Promotor", datos[6]);
            command.Parameters.AddWithValue("@Calle", datos[7]);
            command.Parameters.AddWithValue("@Colonia", datos[8]);
            command.Parameters.AddWithValue("@NumI", datos[9]);
            command.Parameters.AddWithValue("@NumE", datos[10]);
            command.Parameters.AddWithValue("@Telefono", datos[11]);
            command.Parameters.AddWithValue("@Correo", datos[12]);
            command.Parameters.AddWithValue("@TipoP", datos[13]);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
            }
        }
        public void InsertarLista2(string[] valores)
        {
            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO lista2 (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Interes, Monto_Total, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Monto_Restante, Fecha_Limite)");
            queryBuilder.Append(" VALUES (@Nombre, @Credito, @FechaInicio, @Interes, @Monto, @Promotor, @Calle, @Colonia, @NumInt, @NumExt, @Telefono, @Correo, @TipoPago, @MontoRestante, @FechaLimite)");
            string query = queryBuilder.ToString();

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Nombre", valores[0]);
            command.Parameters.AddWithValue("@Credito", valores[1]);
            command.Parameters.AddWithValue("@FechaInicio", valores[2]);
            command.Parameters.AddWithValue("@Interes", valores[3]);
            command.Parameters.AddWithValue("@Monto", valores[4]);
            command.Parameters.AddWithValue("@Promotor", valores[5]);
            command.Parameters.AddWithValue("@Calle", valores[6]);
            command.Parameters.AddWithValue("@Colonia", valores[7]);
            command.Parameters.AddWithValue("@NumInt", valores[8]);
            command.Parameters.AddWithValue("@NumExt", valores[9]);
            command.Parameters.AddWithValue("@Telefono", valores[10]);
            command.Parameters.AddWithValue("@Correo", valores[11]);
            command.Parameters.AddWithValue("@TipoPago", valores[12]);
            command.Parameters.AddWithValue("@MontoRestante", valores[13]);
            command.Parameters.AddWithValue("@FechaLimite", valores[14]);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
            }
        }
        public void InsertarLista3(string[] valores)
        {
            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO lista3 (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Interes, Monto_Total, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Monto_Restante)");
            queryBuilder.Append(" VALUES (@Nombre, @Credito, @FechaInicio, @Interes, @Monto, @Promotor, @Calle, @Colonia, @NumInt, @NumExt, @Telefono, @Correo, @TipoPago, @MontoRestante)");
            string query = queryBuilder.ToString();

            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Nombre", valores[0]);
            command.Parameters.AddWithValue("@Credito", valores[1]);
            command.Parameters.AddWithValue("@FechaInicio", valores[2]);
            command.Parameters.AddWithValue("@Interes", valores[3]);
            command.Parameters.AddWithValue("@Monto", valores[4]);
            command.Parameters.AddWithValue("@Promotor", valores[5]);
            command.Parameters.AddWithValue("@Calle", valores[6]);
            command.Parameters.AddWithValue("@Colonia", valores[7]);
            command.Parameters.AddWithValue("@NumInt", valores[8]);
            command.Parameters.AddWithValue("@NumExt", valores[9]);
            command.Parameters.AddWithValue("@Telefono", valores[10]);
            command.Parameters.AddWithValue("@Correo", valores[11]);
            command.Parameters.AddWithValue("@TipoPago", valores[12]);
            command.Parameters.AddWithValue("@MontoRestante", valores[13]);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
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
                if(revisador == false)
                {
                    Form1.MessageB("La Aplicacion Funciona Correctamente", "Funcionando", 1);
                }
                else
                {
                    a.conect = true;
                }
            }
            catch (Exception ex)
            {
                if(revisador == false)
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
       public  void Registro_errores(string error)
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
