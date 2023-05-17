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
 

        MySqlConnection Conector()
        {
            // Creamos la conexión verificando si se ha cambiado el puerto
            string server = "localhost";
            int port = cambio_puerto ? 3307 : 3306;
            string database = "prestamos";
            // Mejora de seguridad
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
        public List<string[]> LectLista1()
        {
            List<string[]> datos = new();

            using (MySqlConnection connection = Conector())
            {
                string query = "SELECT * FROM lista1";
                using MySqlCommand command = new(query, connection);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
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

                        fila[13] = (reader.GetString("Monto_Restante"));

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
                string query = "SELECT * FROM lista2";
                using MySqlCommand command = new(query, connection);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
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
                string query = "SELECT * FROM liquidados";
                using MySqlCommand command = new(query, connection);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
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
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
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
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                }
            }
            return datos;
        }

        //Leer por un nombre en especifico 
        public string[] LectName(string tabla, string name)
        {
            string[] fila = new string[28];
            using (MySqlConnection connection = Conector())
            {
                try
                {
                    string query = "SELECT * FROM " + tabla + " WHERE Nombre_Completo = @name";
                    using MySqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@name", name);
                    using MySqlDataReader reader = command.ExecuteReader();
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
                        fila[13] = reader.GetString("Monto_Restante");

                        int fechaCount = fila[12] == "Semanal" ? 14 : 7;

                        for (int i = 0; i < fechaCount; i++)
                        {
                            fila[i + 14] = reader.GetString("Fecha" + (i + 1));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                }
            }
            return fila;
        }
        //Editar por un nombre especifico
        #endregion

        #region editar, borrar y crear
        public void Edit(string tabla, string name, string datos)//falta agregar parametros de recibido pero hasta que la base de datos este lista
        {
            //creamos la conexion
            using MySqlConnection Connection = Conector();
            try
            {
                string query = "UPDATE " + tabla + " SET " + datos + "WHERE Nombre_Completo = @name";
                using MySqlCommand command = new(query, Connection);
                command.Parameters.AddWithValue("@name", name);


                //esto nos devuelve el numero de filas que edito
                command.ExecuteNonQuery();
                //cerramos la conexion
                Connection.Close();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
            }
        }
        public void EditarLista1(string[] datos)
        {
            if (datos.Length != 29)
            {
                Registro_errores("Falla en editar Lista1 arreglo no equivalente al numero de columnas");
                return;
            }
            string nombreTabla = "lista1"; 
            string query = $"UPDATE {nombreTabla} SET Nombre_Completo = @NuevoNombre, Credito_Prestado = @NuevoCredito, Fecha_Inicio = @NuevaFechaInicio, Interes = @NuevoInteres, Monto_Total = @NuevoMonto, Promotor = @NuevoPromotor, Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Tipo_pago = @NuevoTipoPago, Monto_Restante = @NuevoMontoRestante, Fecha1 = @NuevaFecha1, Fecha2 = @NuevaFecha2, Fecha3 = @NuevaFecha3, Fecha4 = @NuevaFecha4, Fecha5 = @NuevaFecha5, Fecha6 = @NuevaFecha6, Fecha7 = @NuevaFecha7, Fecha8 = @NuevaFecha8, Fecha9 = @NuevaFecha9, Fecha10 = @NuevaFecha10, Fecha11 = @NuevaFecha11, Fecha12 = @NuevaFecha12, Fecha13 = @NuevaFecha13, Fecha14 = @NuevaFecha14 WHERE Nombre_Completo = @Nombre";
            using MySqlConnection connection = Conector();
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@NuevoNombre", datos[0]);
            command.Parameters.AddWithValue("@NuevoCredito", datos[1]);
            command.Parameters.AddWithValue("@NuevaFechaInicio", datos[2]);
            command.Parameters.AddWithValue("@NuevoInteres", datos[3]);
            command.Parameters.AddWithValue("@NuevoMonto", datos[4]);
            command.Parameters.AddWithValue("@NuevoPromotor", datos[5]);
            command.Parameters.AddWithValue("@NuevaCalle", datos[6]);
            command.Parameters.AddWithValue("@NuevaColonia", datos[7]);
            command.Parameters.AddWithValue("@NuevoNumInt", datos[8]);
            command.Parameters.AddWithValue("@NuevoNumExt", datos[9]);
            command.Parameters.AddWithValue("@NuevoTelefono", datos[10]);
            command.Parameters.AddWithValue("@NuevoCorreo", datos[11]);
            command.Parameters.AddWithValue("@NuevoTipoPago", int.Parse(datos[12]));
            command.Parameters.AddWithValue("@NuevoMontoRestante", datos[13]);
            command.Parameters.AddWithValue("@NuevaFecha1", datos[14]);
            command.Parameters.AddWithValue("@NuevaFecha2", datos[15]);
            command.Parameters.AddWithValue("@NuevaFecha3", datos[16]);
            command.Parameters.AddWithValue("@NuevaFecha4", datos[17]);
            command.Parameters.AddWithValue("@NuevaFecha5", datos[18]);
            command.Parameters.AddWithValue("@NuevaFecha6", datos[19]);
            command.Parameters.AddWithValue("@NuevaFecha7", datos[20]);
            command.Parameters.AddWithValue("@NuevaFecha8", datos[21]);
            command.Parameters.AddWithValue("@NuevaFecha9", datos[22]);
            command.Parameters.AddWithValue("@NuevaFecha10", datos[23]);
            command.Parameters.AddWithValue("@NuevaFecha11", datos[24]);
            command.Parameters.AddWithValue("@NuevaFecha12", datos[25]);
            command.Parameters.AddWithValue("@NuevaFecha13", datos[26]);
            command.Parameters.AddWithValue("@NuevaFecha14", datos[27]);
            command.Parameters.AddWithValue("@Nombre", datos[28]);
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Registro_errores(ex.ToString());
            }
        }
        public void EditarLista2(string[] datos)
        {
            if (datos.Length != 16)
            {
                Registro_errores("Error: El arreglo de datos no tiene la longitud esperada.");
                return;
            }

            string nombreTabla = "lista2"; 

            string query = $"UPDATE {nombreTabla} SET Nombre_Completo = @NuevoNombre, Credito_Prestado = @NuevoCredito, Fecha_Inicio = @NuevaFechaInicio, Interes = @NuevoInteres, Monto_Total = @NuevoMonto, Promotor = @NuevoPromotor, Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Tipo_pago = @NuevoTipoPago, Monto_Restante = @NuevoMontoRestante, Fecha_Limite = @NuevaFechaLimite WHERE Nombre_Completo = @Nombre";

            using (MySqlConnection connection = Conector())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NuevoNombre", datos[0]);
                    command.Parameters.AddWithValue("@NuevoCredito", datos[1]);
                    command.Parameters.AddWithValue("@NuevaFechaInicio", datos[2]);
                    command.Parameters.AddWithValue("@NuevoInteres", datos[3]);
                    command.Parameters.AddWithValue("@NuevoMonto", datos[4]);
                    command.Parameters.AddWithValue("@NuevoPromotor", datos[5]);
                    command.Parameters.AddWithValue("@NuevaCalle", datos[6]);
                    command.Parameters.AddWithValue("@NuevaColonia", datos[7]);
                    command.Parameters.AddWithValue("@NuevoNumInt", datos[8]);
                    command.Parameters.AddWithValue("@NuevoNumExt", datos[9]);
                    command.Parameters.AddWithValue("@NuevoTelefono", datos[10]);
                    command.Parameters.AddWithValue("@NuevoCorreo", datos[11]);
                    command.Parameters.AddWithValue("@NuevoTipoPago", int.Parse(datos[12]));
                    command.Parameters.AddWithValue("@NuevoMontoRestante", datos[13]);
                    command.Parameters.AddWithValue("@NuevaFechaLimite", datos[14]);
                    command.Parameters.AddWithValue("@Nombre", datos[15]);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Registro actualizado correctamente.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Registro_errores(ex.ToString());
                    }
                }
            }
        }
        public void EditarLista3(string[] datos)
        {
            if (datos.Length != 15)
            {
                Registro_errores("Error: El arreglo de datos no tiene la longitud esperada.");
                return;
            }

            string nombreTabla = "lista3"; 

            string query = $"UPDATE {nombreTabla} SET Credito_Prestado = @NuevoCredito, Fecha_Inicio = @NuevaFechaInicio, Interes = @NuevoInteres, Monto_Total = @NuevoMonto, Promotor = @NuevoPromotor, Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Tipo_pago = @NuevoTipoPago, Monto_Restante = @NuevoMontoRestante WHERE Nombre_Completo = @Nombre";

            using (MySqlConnection connection = Conector())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NuevoCredito", datos[0]);
                    command.Parameters.AddWithValue("@NuevaFechaInicio", datos[1]);
                    command.Parameters.AddWithValue("@NuevoInteres", datos[2]);
                    command.Parameters.AddWithValue("@NuevoMonto", datos[3]);
                    command.Parameters.AddWithValue("@NuevoPromotor", datos[4]);
                    command.Parameters.AddWithValue("@NuevaCalle", datos[5]);
                    command.Parameters.AddWithValue("@NuevaColonia", datos[6]);
                    command.Parameters.AddWithValue("@NuevoNumInt", datos[7]);
                    command.Parameters.AddWithValue("@NuevoNumExt", datos[8]);
                    command.Parameters.AddWithValue("@NuevoTelefono", datos[9]);
                    command.Parameters.AddWithValue("@NuevoCorreo", datos[10]);
                    command.Parameters.AddWithValue("@NuevoTipoPago", int.Parse(datos[11]));
                    command.Parameters.AddWithValue("@NuevoMontoRestante", datos[12]);
                    command.Parameters.AddWithValue("@Nombre", datos[13]);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Registro actualizado correctamente.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Registro_errores(ex.ToString());
                    }
                }
            }
        }
        public void EditarListaLiquidados(string[] datos)
        {
            if (datos.Length != 14)
            {
                Registro_errores("Error: El arreglo de datos no tiene la longitud esperada.");
                return;
            }

            string nombreTabla = "liquidados";

            string query = $"UPDATE {nombreTabla} SET Credito_Prestado = @NuevoCredito, Fecha_Inicio = @NuevaFechaInicio, Fecha_Ultimo_Pago = @NuevaFechaUltimoPago, Interes = @NuevoInteres, Monto_Total = @NuevoMonto, Promotor = @NuevoPromotor, Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Tipo_pago = @NuevoTipoPago WHERE Nombre_Completo = @Nombre";

            using (MySqlConnection connection = Conector())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NuevoCredito", datos[0]);
                    command.Parameters.AddWithValue("@NuevaFechaInicio", datos[1]);
                    command.Parameters.AddWithValue("@NuevaFechaUltimoPago", datos[2]);
                    command.Parameters.AddWithValue("@NuevoInteres", datos[3]);
                    command.Parameters.AddWithValue("@NuevoMonto", datos[4]);
                    command.Parameters.AddWithValue("@NuevoPromotor", datos[5]);
                    command.Parameters.AddWithValue("@NuevaCalle", datos[6]);
                    command.Parameters.AddWithValue("@NuevaColonia", datos[7]);
                    command.Parameters.AddWithValue("@NuevoNumInt", datos[8]);
                    command.Parameters.AddWithValue("@NuevoNumExt", datos[9]);
                    command.Parameters.AddWithValue("@NuevoTelefono", datos[10]);
                    command.Parameters.AddWithValue("@NuevoCorreo", datos[11]);
                    command.Parameters.AddWithValue("@NuevoTipoPago", int.Parse(datos[12]));
                    command.Parameters.AddWithValue("@Nombre", datos[13]);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Registro actualizado correctamente.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Registro_errores(ex.ToString());
                    }
                }
            }
        }
        private void InsertarRegistro(string tablaOrigen, string tablaDestino, string nombreCompleto, string creditoPrestado, string fechaInicio, string interes, string montoTotal, string promotor, string calle, string colonia, string numInt, string numExt, string telefono, string correo, int tipoPago)
        {
        
            // Consulta SQL para insertar el registro en la tabla de destino
            string insertQuery = "INSERT INTO " + tablaDestino + " (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Interes, Monto_Total, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Monto_Restante) " +
                                "VALUES (@NombreCompleto, @CreditoPrestado, @FechaInicio, @Interes, @MontoTotal, @Promotor, @Calle, @Colonia, @NumInt, @NumExt, @Telefono, @Correo, @TipoPago, @MontoRestante)";

            // Consulta SQL para eliminar el registro de la tabla de origen
            string deleteQuery = "DELETE FROM " + tablaOrigen + " WHERE Nombre_Completo = @NombreCompleto";
            using (MySqlConnection connection = Conector())

            // Iniciar una transacción para garantizar la atomicidad de las operaciones
            using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Crear un comando para la inserción en la tabla de destino y asignar los parámetros
                        using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection, transaction))
                        {
                            insertCommand.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                            insertCommand.Parameters.AddWithValue("@CreditoPrestado", creditoPrestado);
                            insertCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                            insertCommand.Parameters.AddWithValue("@Interes", interes);
                            insertCommand.Parameters.AddWithValue("@MontoTotal", montoTotal);
                            insertCommand.Parameters.AddWithValue("@Promotor", promotor);
                            insertCommand.Parameters.AddWithValue("@Calle", calle);
                            insertCommand.Parameters.AddWithValue("@Colonia", colonia);
                            insertCommand.Parameters.AddWithValue("@NumInt", numInt);
                            insertCommand.Parameters.AddWithValue("@NumExt", numExt);
                            insertCommand.Parameters.AddWithValue("@Telefono", telefono);
                            insertCommand.Parameters.AddWithValue("@Correo", correo);
                            insertCommand.Parameters.AddWithValue("@TipoPago", tipoPago);
                            insertCommand.Parameters.AddWithValue("@MontoRestante", montoTotal);

                            // Ejecutar la consulta de inserción
                            insertCommand.ExecuteNonQuery();
                        }

                        // Crear un comando para la eliminación en la tabla de origen y asignar el parámetro
                        using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection, transaction))
                        {
                            deleteCommand.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);

                            // Ejecutar la consulta de eliminación
                            deleteCommand.ExecuteNonQuery();
                        }

                        // Confirmar la transacción si todas las consultas se ejecutaron correctamente
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Ocurrió un error, deshacer la trans
        transaction.Rollback();
                        Console.WriteLine("Error: " + ex.Message);
                        throw;
                    }
                conexion.Close();
                }
        }


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

        public void Create(string lista, string Nombre, string Credito, DateTime Fecha_inicio, string Interes, string Monto_Total, string Promotor, string Calle, string Colonia, string Num_int, string Num_ext, string Telefono, string Correo, int Tipo_pago, string Monto_Restante)
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

            using MySqlConnection connection = Conector();
            StringBuilder queryBuilder = new();
            queryBuilder.Append("INSERT INTO " + lista + " (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Interes, Monto_Total, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Monto_Restante");
            for (int i = 1; i <= 14; i++)
            {
                queryBuilder.Append(", Fecha").Append(i);
            }
            queryBuilder.Append(") VALUES (@Nombre, @Credito, @Fecha_inicio, @Interes, @Monto_Total, @Promotor, @Calle, @Colonia, @Num_int, @Num_ext, @Telefono, @Correo, @Tipo_pago, @Monto_Restante");
            for (int i = 0; i < 14; i++)
            {
                queryBuilder.Append(", @Fecha").Append(i + 1);
            }
            queryBuilder.Append(')');
            string query = queryBuilder.ToString();
            using MySqlCommand command = new(query, connection);
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
            command.Parameters.AddWithValue("@Monto_Restante", Monto_Restante);
            for (int i = 0; i < dias_de_pago.Length; i++)
            {
                command.Parameters.AddWithValue("@Fecha" + (i + 1), dias_de_pago[i] + "-");
            }
            if (Tipo_pago == 1)
            {
                for (int i = 7; i < 14; i++)
                {
                    command.Parameters.AddWithValue("@Fecha" + (i + 1), "-");
                }
            }
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
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
            string[] fecha;
            fecha = datos[12] == "0" ? datos[27].Split("-") : datos[20].Split("-");
            command.Parameters.AddWithValue("@FechaUP", fecha[0]);
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
        #endregion

        #region reparar conexion
        public async Task CheckConnection()
        {
            ReacomodoDeScripts();
            string server = "localhost";
            int port = cambio_puerto ? 3307 : 3306;
            string database = "prestamos";
            string username = "root";
            string password = "";

            string connectionString = $"server={server};port={port};database={database};uid={username};pwd={password}";
            using MySqlConnection connection = new(connectionString);
            try
            {
                await connection.OpenAsync();
                Form1.MessageB("La Aplicacion Funciona Correctamente","Funcionando",1);
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
                await RepairProgramAsync();
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
                writer.WriteLine($"[{new DateTime(2023, 5, 14, 16, 14, 57, 143)}] Error: {error}");
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
                writer.WriteLine($"[{new DateTime(2023, 5, 14, 16, 14, 57, 143)}] Acceso este usuario: {acceso}");
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());

            }

        }



        #endregion

    }
}
