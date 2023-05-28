﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureLending
{
    internal class Ediciones
    {
        #region editar por nombre 
        Lectura_Base_Datos con = new();

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
        public void EditarLista1(string[] datos)
        {
            if (datos.Length != 30)
            {
                con.Registro_errores("Falla en editar Lista1 arreglo no equivalente al numero de columnas");
                return;
            }
            string nombreTabla = "lista1";
            string query = $"UPDATE {nombreTabla} SET Promotor=@NuevoPromotor, Nombre_Completo = @NuevoNombre, Credito_Prestado = @NuevoCredito, Pagare= @NuevoPagare, Fecha_Inicio = @NuevaFechaInicio, Fecha_Termino = @NuevaFechaTermino, Interes = @NuevoInteres, Monto_Total = @NuevoMonto,  Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Tipo_pago = @NuevoTipoPago, Monto_Restante = @NuevoMontoRestante, Fecha1 = @NuevaFecha1, Fecha2 = @NuevaFecha2, Fecha3 = @NuevaFecha3, Fecha4 = @NuevaFecha4, Fecha5 = @NuevaFecha5, Fecha6 = @NuevaFecha6, Fecha7 = @NuevaFecha7, Fecha8 = @NuevaFecha8, Fecha9 = @NuevaFecha9, Fecha10 = @NuevaFecha10, Fecha11 = @NuevaFecha11, Fecha12 = @NuevaFecha12, Fecha13 = @NuevaFecha13, Fecha14 = @NuevaFecha14 WHERE Nombre_Completo = @Nombre";
            using MySqlConnection connection = con.Conector();
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@NuevoPromotor", datos[0]);
            command.Parameters.AddWithValue("@NuevoNombre", datos[1]);
            command.Parameters.AddWithValue("@NuevoCredito", datos[1]);
            command.Parameters.AddWithValue("@NuevoPagare", datos[2]);
            command.Parameters.AddWithValue("@NuevaFechaInicio", datos[2]);
            command.Parameters.AddWithValue("@NuevaFechaTermino", datos[3]);
            command.Parameters.AddWithValue("@NuevoInteres", datos[4]);
            command.Parameters.AddWithValue("@NuevoMonto", datos[5]);
            command.Parameters.AddWithValue("@NuevaCalle", datos[6]);
            command.Parameters.AddWithValue("@NuevaColonia", datos[7]);
            command.Parameters.AddWithValue("@NuevoNumInt", datos[8]);
            command.Parameters.AddWithValue("@NuevoNumExt", datos[9]);
            command.Parameters.AddWithValue("@NuevoTelefono", datos[10]);
            command.Parameters.AddWithValue("@NuevoCorreo", datos[11]);
            command.Parameters.AddWithValue("@NuevoTipoPago", datos[12]);
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
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Registro_errores(ex.ToString());
            }
        }
        public bool EditarLista2(string[] datos)
        {
            if (datos.Length != 42)
            {
                con.Registro_errores("Error: El arreglo de datos no tiene la longitud esperada.");
                return false;
            }

            string query = $"UPDATE lista2 SET Promotor = @NuevoPromotor, Nombre_Completo = @NuevoNombre, Credito_Prestado = @NuevoCredito, Monto_Restante = @NuevoMontoRestante, Pagare = @NuevoPagare, Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Tipo_de_pago = @NuevoTipoPago, Liquidacion_Intencion = @NuevoLiquidacionIntencion, Quita = @NuevoQuita, ";

            for (int i = 0; i < 14; i++)
            {
             
                if(i==13)
                {
                    query += $"FECHA{i + 1} = @NuevaFecha{i + 1}, ";
                    query += $"PAGO{i + 1} = @NuevoPago{i + 1} ";
                }
                else
                {
                    query += $"FECHA{i + 1} = @NuevaFecha{i + 1}, ";
                    query += $"PAGO{i + 1} = @NuevoPago{i + 1}, ";
                }
            }

            query += $"WHERE Nombre_Completo = '{datos[41]}'";


            using MySqlConnection connection = con.Conector();
            using MySqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@NuevoPromotor", datos[0]);
            command.Parameters.AddWithValue("@NuevoNombre", datos[1]);
            command.Parameters.AddWithValue("@NuevoCredito", datos[2]);
            command.Parameters.AddWithValue("@NuevoMontoRestante", datos[3]);
            command.Parameters.AddWithValue("@NuevoPagare", datos[4]);
            command.Parameters.AddWithValue("@NuevaCalle", datos[5]);
            command.Parameters.AddWithValue("@NuevaColonia", datos[6]);
            command.Parameters.AddWithValue("@NuevoNumInt", datos[7]);
            command.Parameters.AddWithValue("@NuevoNumExt", datos[8]);
            command.Parameters.AddWithValue("@NuevoTelefono", datos[9]);
            command.Parameters.AddWithValue("@NuevoCorreo", datos[10]);
            command.Parameters.AddWithValue("@NuevoTipoPago", datos[11]);
            command.Parameters.AddWithValue("@NuevoLiquidacionIntencion", datos[12]); 
            command.Parameters.AddWithValue("@NuevoQuita", datos[13]);
            for (int i = 0; i < 14; i++)
            {
                int index = i * 2;
                command.Parameters.AddWithValue($"@NuevaFecha{i + 1}", datos[index + 14]);
                command.Parameters.AddWithValue($"@NuevoPago{i + 1}", datos[index + 15]);
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
        public void EditarLista3(string[] datos)
        {
            if (datos.Length != 13)
            {
                con.Registro_errores("Error: El arreglo de datos no tiene la longitud esperada.");
                return;
            }

            string nombreTabla = "lista3";

            string query = $"UPDATE {nombreTabla} SET Promotor=@NuevoPromotor, Nombre_Completo =@NuevoNombre, Credito_Prestado = @NuevoCredito,Pagare = @NuevoPagare, Calle = @NuevaCalle, Colonia = @NuevaColonia, Num_int = @NuevoNumInt, Num_ext = @NuevoNumExt, Telefono = @NuevoTelefono, Correo = @NuevoCorreo, Tipo_de_Resolucion = @NuevoTipoResolucion, Resolucion_Demanda = @NuevoResolucionDemanda, Importe= @NuevoImporte  WHERE Nombre_Completo = @Nombre";

            using MySqlConnection connection =  con.Conector();
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
            command.Parameters.AddWithValue("@NuevoTipoResolucion", int.Parse(datos[10]));
            command.Parameters.AddWithValue("@NuevoResolucionDemanda", datos[11]);
            command.Parameters.AddWithValue("@NuevoImporte", datos[12]);
            command.Parameters.AddWithValue("@Nombre", datos[13]);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                con.Registro_errores(ex.ToString());
            }
        }
        public void EditarListaLiquidados(string[] datos)
        {
            if (datos.Length != 15)
            {
                con.Registro_errores("Error: El arreglo de datos no tiene la longitud esperada.");
                return;
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
            }
            catch (MySqlException ex)
            {
                con.Registro_errores(ex.ToString());
            }
        }
        #endregion



    }
}