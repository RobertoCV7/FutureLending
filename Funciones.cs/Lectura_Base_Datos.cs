using FutureLending.Forms;
using FutureLending.Funciones.cs;
using FutureLending.Properties;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace FutureLending;

public class LecturaBaseDatos
{
    private static readonly object LockObj = new();

    #region Ping

    public string Ping()
    {
        var connection = Conector();
        var stopwatch = new Stopwatch();
        // Inicia el cronómetro
        stopwatch.Start();
        // Realiza el ping
        connection.Ping();
        // Detiene el cronómetro
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds.ToString();
    }

    #endregion

    #region Conexion

    //verificador de cambio de puerto
    public bool CambioPuerto;

    public MySqlConnection Conector()
    {
        // Almacenar los valores de configuración en variables locales
        var server = Settings1.Default.Servidor;
        var port = CambioPuerto ? 3307 : Settings1.Default.Puerto;
        var database = Settings1.Default.Base_de_datos;
        var uid = Settings1.Default.Usuario;
        var pwd = Settings1.Default.Contraseña;
        var connectionString = $"server={server};port={port};database={database};uid={uid};pwd={pwd};";
        try
        {
            // Crear y abrir la conexión utilizando el bloque 'using'
            var connection = new MySqlConnection(connectionString);
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
                Form1.DineroAire = 0;
                Form1.MontoTotal = 0;
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
                        double montoTotal;
                        if (double.TryParse(fila[8], out montoRestante))
                        {
                            Form1.DineroAire += montoRestante;
                        }
                        if (double.TryParse(fila[6], out montoTotal))
                        {
                            Form1.MontoTotal += montoTotal;
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

        using var connection = Conector();
        const string query = "SELECT * FROM lista2 Where Promotor = @Promotor";
        using MySqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@Promotor", prom);
        try
        {
            Form1.DineroAire = 0;
            Form1.MontoTotal = 0;
            using var reader = command.ExecuteReader();
            var fila = new string[43]; // Modificar el tamaño del arreglo para ajustarlo a la cantidad de campos
            while (reader.Read())
            {
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
                Form1.DineroAire += Convert.ToDouble(fila[8]);
                Form1.MontoTotal += Convert.ToDouble(fila[2]);
            }
        }
        catch (Exception ex)
        {
            Registro_errores(ex.ToString());
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
                        string[] fila = new string[50];
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

                        for (int i = 0; i < 15; i++)
                        {
                            string dato;


                            if (!reader.IsDBNull("Fecha" + (i + 1)))
                            {
                                dato = reader.GetString("Fecha" + (i + 1));
                            }
                            else
                            {

                                dato = "*";
                            }

                            if (dato.Contains("-") && dato.Contains("/"))
                            {
                                string[] separado = dato.Split('-');
                                fila[16 + (i * 2)] = separado[0];
                                fila[17 + (i * 2)] = separado[1];
                            }
                            else if (dato.Contains("/"))
                            {
                                fila[16 + (i * 2)] = dato;
                                fila[17 + (i * 2)] = "-";
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
                        string[] fila = new string[31];
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

                        for (int i = 0; i < 15; i++)
                        {
                            if (!reader.IsDBNull("Fecha" + (i + 1)))
                            {
                                fila[16 + i] = reader.GetString("Fecha" + (i + 1));
                            }
                            else
                            {

                                fila[16 + i] = "*";
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
                Ediciones ed = new();
                int max = ed.ObtenerNumeroColumnas("lista2");
                int maxfor = ed.ObtenerNumeroUltimaColumna("lista2");
                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] fila = new string[max + 1]; // Modificar el tamaño del arreglo para ajustarlo a la cantidad de campos
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
                    fila[max] = reader.GetString("Pago_Total_EXT");
                    for (int i = 0; i < maxfor; i++)
                    {
                        string fechaCampo = "FECHA" + (i + 1);
                        string pagoCampo = "PAGO" + (i + 1);
                        fila[14 + (i * 2)] = reader.IsDBNull(reader.GetOrdinal(fechaCampo)) || reader.GetString(fechaCampo) == "-" ? "/" : reader.GetString(fechaCampo);
                        fila[15 + (i * 2)] = reader.IsDBNull(reader.GetOrdinal(pagoCampo)) || reader.GetString(pagoCampo) == "-" ? "/" : reader.GetString(pagoCampo);
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
    public List<string[]> LectTodos(string tabla, string lista)
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
    public bool BorrarAval(string Nombre_Completo)
    {
        using (MySqlConnection connection = Conector())
        {
            string query = "DELETE FROM Avales WHERE Nombre_Completo = @Nombre_Completo";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre_Completo", Nombre_Completo);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                    return false;
                }
            }
        }
    }
    public void Erase(string nombre, string tabla)
    {
        //Llamamos al conector
        using var Connection = Conector();
        using var command = Connection.CreateCommand();
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

    public static int VerificarUsuarioEnListas(string nombreUsuario)
    {
        LecturaBaseDatos a = new();
        MySqlConnection connection = a.Conector();

        try
        {
            // Convertir el nombre de usuario a minúsculas
            string nombreUsuarioMin = nombreUsuario.ToLower();

            // Verificar si el usuario existe en lista2 (ignorando mayúsculas y minúsculas)
            string queryLista2 = "SELECT COUNT(*) FROM lista2 WHERE LOWER(Nombre_Completo) = @nombreUsuario";
            MySqlCommand commandLista2 = new MySqlCommand(queryLista2, connection);
            commandLista2.Parameters.AddWithValue("@nombreUsuario", nombreUsuarioMin);
            int countLista2 = Convert.ToInt32(commandLista2.ExecuteScalar());

            // Verificar si el usuario existe en lista3 (ignorando mayúsculas y minúsculas)
            string queryLista3 = "SELECT COUNT(*) FROM lista3 WHERE LOWER(Nombre_Completo) = @nombreUsuario";
            MySqlCommand commandLista3 = new MySqlCommand(queryLista3, connection);
            commandLista3.Parameters.AddWithValue("@nombreUsuario", nombreUsuarioMin);
            int countLista3 = Convert.ToInt32(commandLista3.ExecuteScalar());

            if (countLista2 > 0)
            {
                return 2;
            }
            else if (countLista3 > 0)
            {
                return 3;
            }

            return 0;
        }
        catch (Exception ex)
        {
            a.Registro_errores("Error al verificar el usuario en las listas: " + ex.Message);
        }
        finally
        {
            // Cerrar la conexión de la base de datos
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        return 0;
    }

    public string VerificarLiquidados(string nombre)
    {
        using (MySqlConnection connection = Conector())
        {
            // Convertir el nombre a minúsculas
            string nombreMin = nombre.ToLower();

            string query = $"SELECT Forma_Liquidacion FROM liquidados WHERE LOWER(Nombre_Completo) = @Nombre";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", nombreMin);

                try
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                    return null;
                }
            }
        }

        return null; // Si no se encuentra ningún registro con el nombre dado
    }


    #endregion

    #region Crear registros, solo en la lista 1 y liquidados

    public void Create(string lista, string promotor, string nombre, string credito, string pagare,
        DateTime Fecha_inicio, DateTime Fecha_Termino, string interes, string Monto_Total, string Calle, string Colonia,
        string Num_int, string Num_ext, string Telefono, string Correo, string Tipo_pago, string Monto_Restante)
    {
        DateTime fechaInicio;
        fechaInicio = Fecha_inicio.Date;
        var cantidadFechas = Tipo_pago == "Semanales" ? 14 : 7;
        var dias_de_pago = new string[cantidadFechas];

        var incremento = Tipo_pago == "Semanales" ? 7 : 15;
        for (var i = 0; i < cantidadFechas; i++)
            dias_de_pago[i] = fechaInicio.AddDays(incremento * (i + 1)).ToString("dd/MM/yyyy");

        using var connection = Conector();
        StringBuilder queryBuilder = new();
        queryBuilder.Append("INSERT INTO ");
        queryBuilder.Append(lista);
        queryBuilder.Append(
            " (Promotor, Nombre_Completo, Credito_Prestado, Pagare, Fecha_Inicio, Fecha_Termino, Interes, Monto_Total, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Monto_Restante");

        for (var i = 1; i <= cantidadFechas; i++)
        {
            queryBuilder.Append(", Fecha");
            queryBuilder.Append(i);
        }

        queryBuilder.Append(
            ") VALUES (@Promotor, @Nombre, @Credito, @Pagare, @Fecha_inicio, @Fecha_Termino, @Interes, @Monto_Total, @Calle, @Colonia, @Num_int, @Num_ext, @Telefono, @Correo, @Tipo_pago, @Monto_Restante");

        for (var i = 1; i <= cantidadFechas; i++)
        {
            queryBuilder.Append(", @Fecha");
            queryBuilder.Append(i);
        }

        queryBuilder.Append(')');

        var consulta = queryBuilder.ToString();

        using MySqlCommand command = new(consulta, connection);

        command.Parameters.AddWithValue("@Promotor", promotor);
        command.Parameters.AddWithValue("@Nombre", nombre);
        command.Parameters.AddWithValue("@Credito", credito);
        command.Parameters.AddWithValue("@Pagare", pagare);
        command.Parameters.AddWithValue("@Fecha_inicio", Fecha_inicio.ToString("dd/MM/yyyy"));
        command.Parameters.AddWithValue("@Fecha_Termino", Fecha_Termino.ToString("dd/MM/yyyy"));
        command.Parameters.AddWithValue("@Interes", interes);
        command.Parameters.AddWithValue("@Monto_Total", Monto_Total);
        command.Parameters.AddWithValue("@Calle", Calle);
        command.Parameters.AddWithValue("@Colonia", Colonia);
        command.Parameters.AddWithValue("@Num_int", Num_int);
        command.Parameters.AddWithValue("@Num_ext", Num_ext);
        command.Parameters.AddWithValue("@Telefono", Telefono);
        command.Parameters.AddWithValue("@Correo", Correo);
        command.Parameters.AddWithValue("@Tipo_pago", Tipo_pago);
        command.Parameters.AddWithValue("@Monto_Restante", Monto_Restante);

        for (var i = 1; i <= 14; i++)
            command.Parameters.AddWithValue("@Fecha" + i, i <= dias_de_pago.Length ? dias_de_pago[i - 1] : "-");
        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            if (ex.ToString().Contains("Duplicate entry"))
                Form1.MessageB("Este usuario ya existe!!!", "Alerta", 2);
            else
                Registro_errores(ex.ToString());
        }
    }

    public bool InsertarLiquidados(string[] datos)
    {
        using var connection = Conector();
        StringBuilder queryBuilder = new();
        queryBuilder.Append(
            "INSERT INTO liquidados (Promotor, Nombre_Completo, Credito_Prestado, Fecha_Inicio, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Forma_Liquidacion)");
        queryBuilder.Append(
            " VALUES (@Promotor, @Nombre, @Credito, @FechaI, @Calle, @Colonia, @NumI, @NumE, @Telefono, @Correo, @FormaLiquidacion)");
        var query = queryBuilder.ToString();

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
        queryBuilder.Append("INSERT INTO lista2 (Promotor, Nombre_Completo, Credito_Prestado, Monto_Restante, Pagare, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_de_pago, Liquidacion_Intencion, Quita, Pago_Total_EXT)");

        // Agregar los campos de fechas y pagos dinámicamente
        Ediciones ed = new();

        int numFechasPagos = ed.ObtenerNumeroUltimaColumna("lista2"); // Número de pares de campos (FECHA y PAGO)
        for (int i = 1; i <= numFechasPagos; i++)
        {
            queryBuilder.Append($", FECHA{i}, PAGO{i}");
        }

        queryBuilder.Append(" VALUES (@Promotor, @Nombre, @Credito, @MontoRestante, @Pagare, @Calle, @Colonia, @NumInt, @NumExt, @Telefono, @Correo, @TipoPago, @LiquidacionIntencion, @Quita, @PagoEXT");

        // Agregar los parámetros de fechas y pagos dinámicamente
        for (int i = 1; i <= numFechasPagos; i++)
        {
            queryBuilder.Append($", @Fecha{i}, @Pago{i}");
        }

        queryBuilder.Append(")");
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
        command.Parameters.AddWithValue("@PagoEXT", valores[42]);

        // Agregar los parámetros de fechas y pagos dinámicamente
        for (int i = 1; i <= numFechasPagos; i++)
        {
            int fechaIndex = 14 + (i - 1) * 2;
            int pagoIndex = fechaIndex + 1;
            string fechaParam = valores[fechaIndex] ?? "-";
            string pagoParam = valores[pagoIndex] ?? "-";
            command.Parameters.AddWithValue($"@Fecha{i}", fechaParam);
            command.Parameters.AddWithValue($"@Pago{i}", pagoParam);
        }

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
        using var connection = Conector();
        StringBuilder queryBuilder = new();
        queryBuilder.Append(
            "INSERT INTO lista3 (Promotor, Nombre_Completo, Credito_Prestado, Pagare, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_de_Resolucion, Resolucion_Demanda, Importe)");
        queryBuilder.Append(
            " VALUES (@Promotor, @Nombre, @Credito, @Pagare, @Calle, @Colonia, @NumInt, @NumExt, @Telefono, @Correo, @TipoResolucion, @ResolucionDemanda, @Importe)");
        var query = queryBuilder.ToString();

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

    public bool CrearAvales(string[] datos)
    {
        using MySqlConnection connection = Conector();
        StringBuilder queryBuilder = new();
        queryBuilder.Append("INSERT INTO Avales (Nombre_Completo, Aval1_Nombre, Aval1_Calle, Aval1_Colonia, Aval1_Num_int, Aval1_Num_ext, Aval1_Telefono, Aval1_Correo,Aval2_Nombre,Aval2_Calle,Aval2_Colonia,Aval2_Num_int,Aval2_Num_ext,Aval2_Telefono,Aval2_Correo)");
        queryBuilder.Append(" VALUES (@Nombre_Completo, @Aval1_Nombre, @Aval1_Calle, @Aval1_Colonia, @Aval1_Num_int, @Aval1_Num_ext, @Aval1_Telefono, @Aval1_Correo,@Aval2_Nombre,@Aval2_Calle,@Aval2_Colonia,@Aval2_Num_int,@Aval2_Num_ext,@Aval2_Telefono,@Aval2_Correo)");
        string query = queryBuilder.ToString();

        using MySqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@Nombre_Completo", datos[0]);
        command.Parameters.AddWithValue("@Aval1_Nombre", datos[1]);
        command.Parameters.AddWithValue("@Aval1_Calle", datos[2]);
        command.Parameters.AddWithValue("@Aval1_Colonia", datos[3]);
        command.Parameters.AddWithValue("@Aval1_Num_int", datos[4]);
        command.Parameters.AddWithValue("@Aval1_Num_ext", datos[5]);
        command.Parameters.AddWithValue("@Aval1_Telefono", datos[6]);
        command.Parameters.AddWithValue("@Aval1_Correo", datos[7]);
        command.Parameters.AddWithValue("@Aval2_Nombre", datos[8]);
        command.Parameters.AddWithValue("@Aval2_Calle", datos[9]);
        command.Parameters.AddWithValue("@Aval2_Colonia", datos[10]);
        command.Parameters.AddWithValue("@Aval2_Num_int", datos[11]);
        command.Parameters.AddWithValue("@Aval2_Num_ext", datos[12]);
        command.Parameters.AddWithValue("@Aval2_Telefono", datos[13]);
        command.Parameters.AddWithValue("@Aval2_Correo", datos[14]);
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
    public string[] ObtenerAvales(string Nombre_Completo)
    {
        List<string> datosRecuperados = new List<string>();

        using (MySqlConnection connection = Conector())
        {
            string query = "SELECT Aval1_Nombre, Aval1_Calle, Aval1_Colonia, Aval1_Num_int, Aval1_Num_ext, Aval1_Telefono, Aval1_Correo, Aval2_Nombre, Aval2_Calle, Aval2_Colonia, Aval2_Num_int, Aval2_Num_ext, Aval2_Telefono, Aval2_Correo FROM Avales WHERE Nombre_Completo = @Nombre_Completo";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre_Completo", Nombre_Completo);

                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader.GetName(i) != "Nombre_Completo")
                                {
                                    datosRecuperados.Add(reader.GetString(i));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Registro_errores(ex.ToString());
                    return null;
                }
            }
        }

        return datosRecuperados.ToArray();
    }
    public bool Existencia_Aval(string Nombre)
    {
        MySqlConnection connection = Conector();
        string query = "SELECT COUNT(*) FROM Avales WHERE Nombre_Completo = @Nombre_Completo";
        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Nombre_Completo", Nombre);
            try
            {
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception Ex)
            {
                Registro_errores(Ex.ToString());
                return false;
            }

        }

    } //Funcion que sirve para saber si existe un aval en la base de datos

    #endregion

    #endregion

    #region reparar conexion

    public async Task CheckConnection(bool revisador)
    {
        var server = Settings1.Default.Servidor;
        var port = CambioPuerto == false ? Settings1.Default.Puerto : 3307;
        var database = Settings1.Default.Base_de_datos;
        var username = Settings1.Default.Usuario;
        var password = Settings1.Default.Contraseña;
        var connectionString = $"server={server};port={port};database={database};uid={username};pwd={password}";

        await using var connection = new MySqlConnection(connectionString);

        try
        {
            await connection.OpenAsync();

            if (!revisador)
                Form1.MessageB("La Aplicacion Funciona Correctamente", "Funcionando", 1);
            else
                Form1.Conect = true;
        }
        catch (Exception ex)
        {
            if (!revisador)
            {
                Form1.MessageB("La Aplicacion no se puede conectar a la base de datos", "Error", 3);
                Registro_errores(ex.ToString());
            }
            else
            {
                Form1.Conect = false;
            }
        }
    }

    #endregion

    #region registros

    private static readonly object lockObject = new(); // Objeto de bloqueo para asegurar acceso único al archivo

    public void Registro_errores(string error)
    {
        var exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var logFilePath = $"{exeDirectory}\\Registro de Errores\\Errores.log";

        try
        {
            lock (lockObject)
            {
                using var writer = new StreamWriter(logFilePath, true);
                writer.WriteLine($"[{DateTime.Now}] Error: {error}");
            }
        }
        catch (Exception ex)
        {
            var s = ex.ToString();
            // Si ocurre un error al registrar el error, no se hace nada para evitar un ciclo infinito
        }
    }

    public void Registro_Usuarios(string acceso)
    {
        using var connection = Conector();
        const string query = "INSERT INTO accesos (fecha, usuario) VALUES (@fecha, @usuario)";
        using var command = new MySqlCommand(query, connection);
        try
        {
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