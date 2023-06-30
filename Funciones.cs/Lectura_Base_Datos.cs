using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using FutureLending.Forms;
using FutureLending.Properties;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

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
        var datos = new List<string[]>();

        using var connection = Conector();
        const string query = "SELECT * FROM lista1 WHERE Promotor = @Promotor";
        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@Promotor", prom);

        try
        {
            using var reader = command.ExecuteReader();
            var fila = new string[10];
            while (reader.Read())
            {
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
                if (double.TryParse(fila[8], out var montoRestante)) Form1.DineroAire += montoRestante;
            }
        }
        catch (Exception ex)
        {
            Registro_errores(ex.ToString());
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

            using var connection = Conector();
            const string query = "SELECT * FROM lista1 ORDER BY Promotor ASC";
            using MySqlCommand command = new(query, connection);
            try
            {
                using var reader = command.ExecuteReader();
                var fila = new string[45];
                while (reader.Read())
                {
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

                    for (var i = 0; i < 14; i++)
                    {
                        var dato = reader.GetString("Fecha" + (i + 1));
                        var separado = dato.Split('-');
                        if (dato.Contains("-") && dato.Contains("/"))
                        {
                            fila[16 + i * 2] = separado[0];
                            fila[17 + i * 2] = separado[1];
                        }
                        else if (dato.Contains("/"))
                        {
                            fila[16 + i * 2] = dato;
                            fila[17 + i * 2] = "-";
                        }

                        // En caso de que alguna fecha sea nula o vacía, se asigna "-"
                        if (!string.IsNullOrWhiteSpace(fila[16 + i])) continue;
                        fila[16 + i] = "-";
                        fila[16 + i + 1] = "-";
                    }

                    datos.Add(fila);
                }
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
            }

            return datos;
        }
        else
        {
            List<string[]> datos = new();

            using var connection = Conector();
            const string query = "SELECT * FROM lista1 ORDER BY Promotor ASC";
            using MySqlCommand command = new(query, connection);
            try
            {
                using var reader = command.ExecuteReader();
                var fila = new string[30];
                while (reader.Read())
                {
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

                    for (var i = 0; i < 14; i++)
                    {
                        fila[16 + i] = reader.GetString("Fecha" + (i + 1));
                        // En caso de que alguna fecha sea nula o vacía, se asigna "-"
                        if (string.IsNullOrWhiteSpace(fila[16 + i])) fila[16 + i] = "-";
                    }

                    datos.Add(fila);
                }
            }
            catch (Exception ex)
            {
                Registro_errores(ex.ToString());
            }

            return datos;
        }
    }

    public List<string[]> LectLista2()
    {
        List<string[]> datos = new();

        using var connection = Conector();
        const string query = "SELECT * FROM lista2 ORDER BY Promotor ASC";
        using MySqlCommand command = new(query, connection);
        try
        {
            using var reader = command.ExecuteReader();
            var fila = new string[43]; // Modificar el tamaño del arreglo para ajustarlo a la cantidad de campos
            while (reader.Read())
            {
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

                for (var i = 0; i < 14; i++)
                {
                    var fechaCampo = "FECHA" + (i + 1);
                    var pagoCampo = "PAGO" + (i + 1);
                    fila[14 + i * 2] = reader.GetString(fechaCampo);
                    fila[15 + i * 2] = reader.GetString(pagoCampo);
                }

                fila[42] = reader.GetString("Pago_Total_EXT");
                datos.Add(fila);
            }
        }
        catch (Exception ex)
        {
            Registro_errores(ex.ToString());
        }

        return datos;
    }

    public List<string[]> LectLista3()
    {
        List<string[]> datos = new();

        using var connection = Conector();
        const string query = "SELECT * FROM lista3  ORDER BY Promotor ASC";
        using MySqlCommand command = new(query, connection);
        using var reader = command.ExecuteReader();
        try
        {
            var fila = new string[13]; // Modificar el tamaño del arreglo para ajustarlo a la cantidad de campos
            while (reader.Read())
            {
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

        return datos;
    }

    public List<string[]> LectLiquidados()
    {
        List<string[]> datos = new();

        using var connection = Conector();
        const string query = "SELECT * FROM liquidados ORDER BY Promotor ASC";
        using MySqlCommand command = new(query, connection);
        try
        {
            using var reader = command.ExecuteReader();
            var fila = new string[11];
            while (reader.Read())
            {
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

        return datos;
    }

    public List<string[]> LectTodos(string tabla, string lista)
    {
        List<string[]> datos = new();
        using var connection = Conector();
        try
        {
            var query = "SELECT * FROM " + tabla + " ORDER BY Promotor ASC";
            using MySqlCommand command = new(query, connection);
            using var reader = command.ExecuteReader();
            //Lee cada fila de datos en la base de datos
            while (reader.Read())
            {
                var fila2 = new string[14];
                string[] fila;
                switch (tabla)
                {
                    case "lista1":
                        fila2[0] = lista;
                        fila2[1] = reader.GetString("Promotor");
                        fila2[2] = reader.GetString("Nombre_Completo");
                        fila2[3] = reader.GetString("Credito_Prestado");
                        fila2[4] = reader.GetString("Fecha_Inicio");
                        fila2[5] = reader.GetString("Interes");
                        fila2[6] = reader.GetString("Monto_Total");
                        fila2[7] = reader.GetString("Calle");
                        fila2[8] = reader.GetString("Colonia");
                        fila2[9] = reader.GetString("Num_int");
                        fila2[10] = reader.GetString("Num_ext");
                        fila2[11] = reader.GetString("Telefono");
                        fila2[12] = reader.GetString("Correo");
                        fila2[13] = reader.GetString("Tipo_pago");
                        datos.Add(fila2);
                        break;
                    case "lista2":
                        fila = new string[14];
                    {
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
                        break;
                    }
                    case "lista3":
                    {
                        fila = new string[14];
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
                        break;
                    }
                    default:
                    {
                        fila = new string[14];
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
                        break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Registro_errores(ex.ToString());
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

    public static bool VerificarUsuarioEnListas(string nombreUsuario)
    {
        var a = new LecturaBaseDatos();
        var connection = a.Conector();

        try
        {
            // Verificar si el usuario existe en lista2
            const string queryLista2 = "SELECT COUNT(*) FROM lista2 WHERE Nombre_Completo = @nombreUsuario";
            var commandLista2 = new MySqlCommand(queryLista2, connection);
            commandLista2.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            var countLista2 = Convert.ToInt32(commandLista2.ExecuteScalar());

            // Verificar si el usuario existe en lista3
            const string queryLista3 = "SELECT COUNT(*) FROM lista3 WHERE Nombre_Completo = @nombreUsuario";
            var commandLista3 = new MySqlCommand(queryLista3, connection);
            commandLista3.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            var countLista3 = Convert.ToInt32(commandLista3.ExecuteScalar());

            return countLista2 <= 0 && countLista3 <= 0;
            // El usuario ya existe en lista2 o lista3
            // El usuario no existe en lista2 ni lista3
        }
        catch (Exception ex)
        {
            a.Registro_errores("Error al verificar el usuario en las listas: " + ex.Message);
        }
        finally
        {
            // Cerrar la conexión de la base de datos
            if (connection.State == ConnectionState.Open) connection.Close();
        }

        // En caso de excepción, retornar false por defecto
        return false;
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
        using var connection = Conector();
        StringBuilder queryBuilder = new();
        queryBuilder.Append(
            "INSERT INTO lista2 (Promotor, Nombre_Completo, Credito_Prestado, Monto_Restante, Pagare, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_de_pago, Liquidacion_Intencion, Quita, FECHA1, PAGO1, FECHA2, PAGO2, FECHA3, PAGO3, FECHA4, PAGO4, FECHA5, PAGO5, FECHA6, PAGO6, FECHA7, PAGO7, FECHA8, PAGO8, FECHA9, PAGO9, FECHA10, PAGO10, FECHA11, PAGO11, FECHA12, PAGO12, FECHA13, PAGO13, FECHA14, PAGO14,Pago_Total_EXT)");
        queryBuilder.Append(
            " VALUES (@Promotor, @Nombre, @Credito, @MontoRestante, @Pagare, @Calle, @Colonia, @NumInt, @NumExt, @Telefono, @Correo, @TipoPago, @LiquidacionIntencion, @Quita, @Fecha1, @Pago1, @Fecha2, @Pago2, @Fecha3, @Pago3, @Fecha4, @Pago4, @Fecha5, @Pago5, @Fecha6, @Pago6, @Fecha7, @Pago7, @Fecha8, @Pago8, @Fecha9, @Pago9, @Fecha10, @Pago10, @Fecha11, @Pago11, @Fecha12, @Pago12, @Fecha13, @Pago13, @Fecha14, @Pago14,@PagoEXT)");
        var query = queryBuilder.ToString();
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
                ReacomodoDeScripts();
                Registro_errores(ex.ToString());
                await RepairProgramAsync();
            }
            else
            {
                Form1.Conect = false;
            }
        }
    }

    public int Attempts = 3;

    private async Task RepairProgramAsync()
    {
        var exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var processStartInfo = new ProcessStartInfo
        {
            FileName = Path.Combine(exeDirectory, "Scripts de reparacion e inicio automatico", "ReiniciarMysql.bat"),
            CreateNoWindow = true,
            UseShellExecute = false
        };

        var process = Process.Start(processStartInfo);
        var processExitTask = Task.Run(() => process.WaitForExit(3000));

        if (await Task.WhenAny(processExitTask, Task.Delay(3000)) != processExitTask) process.Kill();

        if (process.ExitCode != 0 && process.ExitCode != -1073741510)
        {
            Attempts--;

            while (Attempts > 0)
                try
                {
                    await CheckConnection(false);
                    return;
                }
                catch (Exception ex)
                {
                    Attempts--;
                    Registro_errores(ex.ToString());
                }

            Form1.MessageB("Cambiando de Puerto", "Alerta", 2);

            var cambioPortProcessStartInfo = new ProcessStartInfo
            {
                FileName = Path.Combine(exeDirectory, "Scripts de reparacion e inicio automatico", "cambio_port.bat"),
                CreateNoWindow = true,
                UseShellExecute = false
            };

            await Task.Run(() => Process.Start(cambioPortProcessStartInfo));

            CambioPuerto = true;
        }
    }

    public static void ReacomodoDeScripts()
    {
        var path = EncontrarXampp();
        var exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var filePath = Path.Combine(exeDirectory, "Scripts de reparacion e inicio automatico", "ReiniciarMysql.bat");

        // Lee el contenido del archivo .bat
        var contenido = File.ReadAllText(filePath);

        // Verifica si el valor ya está presente en el archivo .bat
        if (contenido.Contains("cd /d " + path)) return;

        // Realiza las modificaciones necesarias
        contenido = contenido.Replace("cd /d E:\\Xampp", "cd /d " + path);

        // Guarda los cambios en el archivo
        File.WriteAllText(filePath, contenido);
    }

    public static string EncontrarXampp()
    {
        var xamppPath = GetXamppInstallationPath();

        return !string.IsNullOrEmpty(xamppPath) ? xamppPath : "c:/Xampp";
    }

    private static string? GetXamppInstallationPath()
    {
        const string xamppRegistryPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\XAMPP";

        using (var key = Registry.LocalMachine.OpenSubKey(xamppRegistryPath))
        {
            if (key != null)
            {
                var installLocation = key.GetValue("InstallLocation") as string;

                if (!string.IsNullOrEmpty(installLocation)) return installLocation;
            }
        }

        // Buscar en todas las unidades en caso de no encontrar en el Registro
        var drives = DriveInfo.GetDrives();

        foreach (var drive in drives)
        {
            if (drive.DriveType != DriveType.Fixed || !drive.IsReady) continue;
            var drivePath = Path.Combine(drive.RootDirectory.FullName, "Xampp");
            if (Directory.Exists(drivePath)) return drivePath;
        }

        return null;
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