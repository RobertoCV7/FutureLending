﻿using MySql.Data.MySqlClient;

namespace FutureLending
{
    internal class Ediciones
    {
        #region editar por nombre 
        readonly Lectura_Base_Datos con = new();
        public bool EditarLista1(string[] datos)
        {
            if (datos.Length != 31)
            {
                con.Registro_errores("Falla en editar Lista1: arreglo no equivalente al número de columnas");
                return false;
            }

            string nombreTabla = "lista1";
            string query = $"UPDATE {nombreTabla} SET " +
                "Promotor = @NuevoPromotor, Nombre_Completo = @NuevoNombre, Credito_Prestado = @NuevoCredito, " +
                "Pagare = @NuevoPagare, Fecha_Inicio = @NuevaFechaInicio, Fecha_Termino = @NuevaFechaTermino, " +
                "Interes = @NuevoInteres, Monto_Total = @NuevoMonto, Calle = @NuevaCalle, Colonia = @NuevaColonia, " +
                "Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, " +
                "Tipo_pago = @NuevoTipoPago, Monto_Restante = @NuevoMontoRestante, Fecha1 = @NuevaFecha1, " +
                "Fecha2 = @NuevaFecha2, Fecha3 = @NuevaFecha3, Fecha4 = @NuevaFecha4, Fecha5 = @NuevaFecha5, " +
                "Fecha6 = @NuevaFecha6, Fecha7 = @NuevaFecha7, Fecha8 = @NuevaFecha8, Fecha9 = @NuevaFecha9, " +
                "Fecha10 = @NuevaFecha10, Fecha11 = @NuevaFecha11, Fecha12 = @NuevaFecha12, Fecha13 = @NuevaFecha13, " +
                "Fecha14 = @NuevaFecha14 WHERE Nombre_Completo = @Nombre";

            using MySqlConnection connection = con.Conector();
            using MySqlCommand command = new(query, connection);

            // Asignar parámetros dinámicamente
            string[] parametros = {
        "@NuevoPromotor", "@NuevoNombre", "@NuevoCredito", "@NuevoPagare", "@NuevaFechaInicio", "@NuevaFechaTermino",
        "@NuevoInteres", "@NuevoMonto", "@NuevaCalle", "@NuevaColonia", "@NuevoNumInt", "@NuevoNumExt",
        "@NuevoTelefono", "@NuevoCorreo", "@NuevoTipoPago", "@NuevoMontoRestante", "@NuevaFecha1", "@NuevaFecha2",
        "@NuevaFecha3", "@NuevaFecha4", "@NuevaFecha5", "@NuevaFecha6", "@NuevaFecha7", "@NuevaFecha8",
        "@NuevaFecha9", "@NuevaFecha10", "@NuevaFecha11", "@NuevaFecha12", "@NuevaFecha13", "@NuevaFecha14", "@Nombre"
    };

            for (int i = 0; i < parametros.Length; i++)
            {
                command.Parameters.AddWithValue(parametros[i], datos[i]);
            }

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

            // Asignar parámetros dinámicamente
            string[] parametros = {
        "@Promotor", "@Nombre_Completo", "@Credito_Prestado", "@Monto_Restante", "@Pagare",
        "@Calle", "@Colonia", "@Num_int", "@Num_ext", "@Telefono", "@Correo", "@Tipo_de_pago",
        "@Liquidacion_Intencion", "@Quita"
    };

            for (int i = 0; i < parametros.Length; i++)
            {
                command.Parameters.AddWithValue(parametros[i], datos[i]);
            }

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

            // Asignar parámetros dinámicamente
            string[] parametros = {
        "@NuevoPromotor", "@NuevoNombre", "@NuevoCredito", "@NuevoPagare", "@NuevaCalle",
        "@NuevaColonia", "@NuevoNumInt", "@NuevoNumExt", "@NuevoTelefono", "@NuevoCorreo",
        "@NuevoTipoResolucion", "@NuevoResolucionDemanda", "@NuevoImporte", "@Nombre"
    };

            for (int i = 0; i < parametros.Length; i++)
            {
                command.Parameters.AddWithValue(parametros[i], datos[i]);
            }

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

            // Asignar parámetros dinámicamente
            string[] parametros = {
        "@NuevoPromotor", "@NuevoNombre", "@NuevoCredito", "@NuevaFechaInicio", "@NuevaCalle",
        "@NuevaColonia", "@NuevoNumInt", "@NuevoNumExt", "@NuevoTelefono", "@NuevoCorreo",
        "@NuevoFormaLiquidacion", "@Nombre"
    };

            for (int i = 0; i < parametros.Length; i++)
            {
                command.Parameters.AddWithValue(parametros[i], datos[i]);
            }

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
