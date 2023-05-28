using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureLending
{
    internal class Lecturas_Especificas
    {
        #region Lectura de datos especificos
        Lectura_Base_Datos con = new();
        public string[] LectName(string nombre)
        {
            string[] fila = new string[31];

            using (MySqlConnection connection = con.Conector())
            {
                string query = "SELECT * FROM lista1 Where Nombre_Completo = @nombre";
                using MySqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
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
                        for (int i = 0; i < 14; i++)
                        {
                            fila[16 + i] = reader.GetString("Fecha" + (i + 1));
                            // En caso de que alguna fecha sea nula o vacía, se asigna "-"
                            if (string.IsNullOrWhiteSpace(fila[16 + i]))
                            {
                                fila[16 + i] = "-";
                            }
                        }

                     
                    }
                }
                catch (Exception ex)
                {
                    con.Registro_errores(ex.ToString());
                }
            }

            return fila;
        }
        public string[] LectName2(string nombre)
        {
            string[] fila = new string[42]; // Modificar el tamaño del arreglo para ajustarlo a la cantidad de campos
            using (MySqlConnection connection = con.Conector())
            {
          
                string query = "SELECT * FROM lista2 WHERE Nombre_Completo = @nombre";

                using MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    using MySqlDataReader reader = command.ExecuteReader();
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

                        for (int i = 0; i < 14; i++)
                        {
                            string fechaCampo = "FECHA" + (i + 1);
                            string pagoCampo = "PAGO" + (i + 1);
                                fila[14 + (2*i)] = reader.GetString(fechaCampo);
                                fila[15 + (2*i)] = reader.GetString(pagoCampo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    con.Registro_errores(ex.ToString());
                }
            }
            return fila;
        }
        public string[] LectName3(string nombre)
        {
            string[] fila = new string[14];
            using (MySqlConnection connection = con.Conector())
            {
                string query = "SELECT * FROM lista3 WHERE Nombre_Completo = @nombre";
                
                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
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
                    }
                }
                catch (Exception ex)
                {
                    con.Registro_errores(ex.ToString());
                }
            }

            return fila;
        }
        public string[] LectName4(string nombre)
        {
            string[] fila = new string[12];

            using (MySqlConnection connection = con.Conector())
            {
            
                string query = "SELECT * FROM liquidados WHERE Nombre_Completo = @nombre";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
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

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        con.Registro_errores(ex.ToString());
                    }
                }
            }

         
            return fila;
        }

        #endregion
    }
}
