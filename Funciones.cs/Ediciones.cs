using MySql.Data.MySqlClient;

namespace FutureLending
{
    internal class Ediciones
    {
        #region editar por nombre 
        readonly Lectura_Base_Datos con = new();

        public void Edit(string tabla, string name, string datos)
        {
            //creamos la conexion
            using MySqlConnection Connection = con.Conector();
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
                con.Registro_errores(ex.ToString());
            }
        }
        public bool EditarLista1(string[] datos)
        {
            if (datos.Length != 31)
            {
                con.Registro_errores("Falla en editar Lista1 arreglo no equivalente al numero de columnas");
                return false;
            }
            string nombreTabla = "lista1";
            string query = $"UPDATE {nombreTabla} SET Promotor=@NuevoPromotor, Nombre_Completo = @NuevoNombre, Credito_Prestado = @NuevoCredito, Pagare= @NuevoPagare, Fecha_Inicio = @NuevaFechaInicio, Fecha_Termino = @NuevaFechaTermino, Interes = @NuevoInteres, Monto_Total = @NuevoMonto,  Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Tipo_pago = @NuevoTipoPago, Monto_Restante = @NuevoMontoRestante, Fecha1 = @NuevaFecha1, Fecha2 = @NuevaFecha2, Fecha3 = @NuevaFecha3, Fecha4 = @NuevaFecha4, Fecha5 = @NuevaFecha5, Fecha6 = @NuevaFecha6, Fecha7 = @NuevaFecha7, Fecha8 = @NuevaFecha8, Fecha9 = @NuevaFecha9, Fecha10 = @NuevaFecha10, Fecha11 = @NuevaFecha11, Fecha12 = @NuevaFecha12, Fecha13 = @NuevaFecha13, Fecha14 = @NuevaFecha14 WHERE Nombre_Completo = @Nombre";
            using MySqlConnection connection = con.Conector();
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@NuevoPromotor", datos[0]);
            command.Parameters.AddWithValue("@NuevoNombre", datos[1]);
            command.Parameters.AddWithValue("@NuevoCredito", datos[2]);
            command.Parameters.AddWithValue("@NuevoPagare", datos[3]);
            command.Parameters.AddWithValue("@NuevaFechaInicio", datos[4]);
            command.Parameters.AddWithValue("@NuevaFechaTermino", datos[5]);
            command.Parameters.AddWithValue("@NuevoInteres", datos[6]);
            command.Parameters.AddWithValue("@NuevoMonto", datos[7]);
            command.Parameters.AddWithValue("@NuevaCalle", datos[8]);
            command.Parameters.AddWithValue("@NuevaColonia", datos[9]);
            command.Parameters.AddWithValue("@NuevoNumInt", datos[10]);
            command.Parameters.AddWithValue("@NuevoNumExt", datos[11]);
            command.Parameters.AddWithValue("@NuevoTelefono", datos[12]);
            command.Parameters.AddWithValue("@NuevoCorreo", datos[13]);
            command.Parameters.AddWithValue("@NuevoTipoPago", datos[14]);
            command.Parameters.AddWithValue("@NuevoMontoRestante", datos[15]);
            command.Parameters.AddWithValue("@NuevaFecha1", datos[16]);
            command.Parameters.AddWithValue("@NuevaFecha2", datos[17]);
            command.Parameters.AddWithValue("@NuevaFecha3", datos[18]);
            command.Parameters.AddWithValue("@NuevaFecha4", datos[19]);
            command.Parameters.AddWithValue("@NuevaFecha5", datos[20]);
            command.Parameters.AddWithValue("@NuevaFecha6", datos[21]);
            command.Parameters.AddWithValue("@NuevaFecha7", datos[22]);
            command.Parameters.AddWithValue("@NuevaFecha8", datos[23]);
            command.Parameters.AddWithValue("@NuevaFecha9", datos[24]);
            command.Parameters.AddWithValue("@NuevaFecha10", datos[25]);
            command.Parameters.AddWithValue("@NuevaFecha11", datos[26]);
            command.Parameters.AddWithValue("@NuevaFecha12", datos[27]);
            command.Parameters.AddWithValue("@NuevaFecha13", datos[28]);
            command.Parameters.AddWithValue("@NuevaFecha14", datos[29]);
            command.Parameters.AddWithValue("@Nombre", datos[30]);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                con.Registro_errores(ex.ToString());
                return false;
            }
        }
        public bool EditarLista2(string[] datos)
        {
            if (datos.Length != 44)
            {
                con.Registro_errores("Error: El arreglo de datos no tiene la longitud esperada.");
                return false;
            }

            string query = "UPDATE lista2 SET ";
            string[] columnNames = {
        "Promotor", "Nombre_Completo", "Credito_Prestado", "Monto_Restante",
        "Pagare", "Calle", "Colonia", "Num_int", "Num_ext", "Telefono",
        "Correo", "Tipo_de_pago", "Liquidacion_Intencion", "Quita"
    };

            string[] fechaColumnNames = new string[14];
            string[] pagoColumnNames = new string[14];

            for (int i = 0; i < 14; i++)
            {
                fechaColumnNames[i] = $"Fecha{i + 1}";
                pagoColumnNames[i] = $"Pago{i + 1}";
            }

            for (int i = 0; i < columnNames.Length; i++)
            {
                query += $"{columnNames[i]} = @{columnNames[i]}, ";
            }

            for (int i = 0; i < 14; i++)
            {
                query += $"{fechaColumnNames[i]} = @{fechaColumnNames[i]}, ";
                query += $"{pagoColumnNames[i]} = @{pagoColumnNames[i]}, ";
            }

            query += "Pago_Total_Ext = @PagoEXT ";
            query += "WHERE Nombre_Completo = @Nombre";

            using MySqlConnection connection = con.Conector();
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@Promotor", datos[0]);
            command.Parameters.AddWithValue("@Nombre_Completo", datos[1]);
            command.Parameters.AddWithValue("@Credito_Prestado", datos[2]);
            command.Parameters.AddWithValue("@Monto_Restante", datos[3]);
            command.Parameters.AddWithValue("@Pagare", datos[4]);
            command.Parameters.AddWithValue("@Calle", datos[5]);
            command.Parameters.AddWithValue("@Colonia", datos[6]);
            command.Parameters.AddWithValue("@Num_int", datos[7]);
            command.Parameters.AddWithValue("@Num_ext", datos[8]);
            command.Parameters.AddWithValue("@Telefono", datos[9]);
            command.Parameters.AddWithValue("@Correo", datos[10]);
            command.Parameters.AddWithValue("@Tipo_de_pago", datos[11]);
            command.Parameters.AddWithValue("@Liquidacion_Intencion", datos[12]);
            command.Parameters.AddWithValue("@Quita", datos[13]);

            for (int i = 0; i < 14; i++)
            {
                int index = i * 2;
                command.Parameters.AddWithValue($"@{fechaColumnNames[i]}", datos[index + 14]);
                command.Parameters.AddWithValue($"@{pagoColumnNames[i]}", datos[index + 15]);
            }

            command.Parameters.AddWithValue("@PagoEXT", datos[42]);
            command.Parameters.AddWithValue("@Nombre", datos[43]);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                con.Registro_errores(ex.ToString());
                return false;
            }
        }

        public bool EditarLista3(string[] datos)
        {
            if (datos.Length != 14)
            {
                con.Registro_errores("Error: El arreglo de datos no tiene la longitud esperada.");
                return false;
            }

            string nombreTabla = "lista3";

            string query = $"UPDATE {nombreTabla} SET Promotor=@NuevoPromotor, Nombre_Completo =@NuevoNombre, Credito_Prestado = @NuevoCredito,Pagare = @NuevoPagare, Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Tipo_de_Resolucion = @NuevoTipoResolucion, Resolucion_Demanda = @NuevoResolucionDemanda, Importe= @NuevoImporte  WHERE Nombre_Completo = @Nombre";

            using MySqlConnection connection = con.Conector();
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@NuevoPromotor", datos[0]);
            command.Parameters.AddWithValue("@NuevoNombre", datos[1]);
            command.Parameters.AddWithValue("@NuevoCredito", datos[2]);
            command.Parameters.AddWithValue("@NuevoPagare", datos[3]);
            command.Parameters.AddWithValue("@NuevaCalle", datos[4]);
            command.Parameters.AddWithValue("@NuevaColonia", datos[5]);
            command.Parameters.AddWithValue("@NuevoNumInt", datos[6]);
            command.Parameters.AddWithValue("@NuevoNumExt", datos[7]);
            command.Parameters.AddWithValue("@NuevoTelefono", datos[8]);
            command.Parameters.AddWithValue("@NuevoCorreo", datos[9]);
            command.Parameters.AddWithValue("@NuevoTipoResolucion", datos[10]);
            command.Parameters.AddWithValue("@NuevoResolucionDemanda", datos[11]);
            command.Parameters.AddWithValue("@NuevoImporte", datos[12]);
            command.Parameters.AddWithValue("@Nombre", datos[13]);

            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                con.Registro_errores(ex.ToString());
                return false;
            }
        }
        public bool EditarListaLiquidados(string[] datos)
        {
            if (datos.Length != 12)
            {
                con.Registro_errores("Error: El arreglo de datos no tiene la longitud esperada.");
                return false;
            }

            string nombreTabla = "liquidados";

            string query = $"UPDATE {nombreTabla} SET Promotor=@NuevoPromotor, Nombre_Completo=@NuevoNombre, Credito_Prestado = @NuevoCredito, Fecha_Inicio = @NuevaFechaInicio, Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Forma_Liquidacion = @NuevoFormaLiquidacion WHERE Nombre_Completo = @Nombre";

            using MySqlConnection connection = con.Conector();
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@NuevoPromotor", datos[0]);
            command.Parameters.AddWithValue("@NuevoNombre", datos[1]);
            command.Parameters.AddWithValue("@NuevoCredito", datos[2]);
            command.Parameters.AddWithValue("@NuevaFechaInicio", datos[3]);
            command.Parameters.AddWithValue("@NuevaCalle", datos[4]);
            command.Parameters.AddWithValue("@NuevaColonia", datos[5]);
            command.Parameters.AddWithValue("@NuevoNumInt", datos[6]);
            command.Parameters.AddWithValue("@NuevoNumExt", datos[7]);
            command.Parameters.AddWithValue("@NuevoTelefono", datos[8]);
            command.Parameters.AddWithValue("@NuevoCorreo", datos[9]);
            command.Parameters.AddWithValue("@NuevoFormaLiquidacion", datos[10]);
            command.Parameters.AddWithValue("@Nombre", datos[11]);
            try
            {
                command.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                con.Registro_errores(ex.ToString());
                return false;
            }
        }
        #endregion



    }
}
