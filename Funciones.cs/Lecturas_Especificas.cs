﻿using MySql.Data.MySqlClient;

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
                string query = "SELECT * FROM lista1 WHERE Nombre_Completo = @nombre";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);

                    try
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                fila[0] = reader.GetString(reader.GetOrdinal("Promotor"));
                                fila[1] = reader.GetString(reader.GetOrdinal("Nombre_Completo"));
                                fila[2] = reader.GetString(reader.GetOrdinal("Credito_Prestado"));
                                fila[3] = reader.GetString(reader.GetOrdinal("Pagare"));
                                fila[4] = reader.GetString(reader.GetOrdinal("Fecha_Inicio"));
                                fila[5] = reader.GetString(reader.GetOrdinal("Fecha_Termino"));
                                fila[6] = reader.GetString(reader.GetOrdinal("Interes"));
                                fila[7] = reader.GetString(reader.GetOrdinal("Monto_Total"));
                                fila[8] = reader.GetString(reader.GetOrdinal("Calle"));
                                fila[9] = reader.GetString(reader.GetOrdinal("Colonia"));
                                fila[10] = reader.GetString(reader.GetOrdinal("Num_int"));
                                fila[11] = reader.GetString(reader.GetOrdinal("Num_ext"));
                                fila[12] = reader.GetString(reader.GetOrdinal("Telefono"));
                                fila[13] = reader.GetString(reader.GetOrdinal("Correo"));
                                fila[14] = reader.GetString(reader.GetOrdinal("Tipo_pago"));
                                fila[15] = reader.GetString(reader.GetOrdinal("Monto_Restante"));

                                for (int i = 0; i < 14; i++)
                                {
                                    string fechaCampo = "Fecha" + (i + 1);
                                    int fechaIndex = reader.GetOrdinal(fechaCampo);
                                    fila[16 + i] = reader.IsDBNull(fechaIndex) ? "-" : reader.GetString(fechaIndex);
                                }
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
        public string[] LectName2(string nombre)
        {
            string[] fila = new string[44];

            using (MySqlConnection connection = con.Conector())
            {
                string query = "SELECT * FROM lista2 WHERE Nombre_Completo = @nombre";

                using MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);

                try
                {
                    using MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        fila[0] = reader.GetString(reader.GetOrdinal("Promotor"));
                        fila[1] = reader.GetString(reader.GetOrdinal("Nombre_Completo"));
                        fila[2] = reader.GetString(reader.GetOrdinal("Credito_Prestado"));
                        fila[3] = reader.GetString(reader.GetOrdinal("Monto_Restante"));
                        fila[4] = reader.GetString(reader.GetOrdinal("Pagare"));
                        fila[5] = reader.GetString(reader.GetOrdinal("Calle"));
                        fila[6] = reader.GetString(reader.GetOrdinal("Colonia"));
                        fila[7] = reader.GetString(reader.GetOrdinal("Num_int"));
                        fila[8] = reader.GetString(reader.GetOrdinal("Num_ext"));
                        fila[9] = reader.GetString(reader.GetOrdinal("Telefono"));
                        fila[10] = reader.GetString(reader.GetOrdinal("Correo"));
                        fila[11] = reader.GetString(reader.GetOrdinal("Tipo_de_pago"));
                        fila[12] = reader.GetString(reader.GetOrdinal("Liquidacion_Intencion"));
                        fila[13] = reader.GetString(reader.GetOrdinal("Quita"));

                        for (int i = 0; i < 14; i++)
                        {
                            string fechaCampo = "FECHA" + (i + 1);
                            string pagoCampo = "PAGO" + (i + 1);
                            fila[14 + (2 * i)] = reader.GetString(reader.GetOrdinal(fechaCampo));
                            fila[15 + (2 * i)] = reader.GetString(reader.GetOrdinal(pagoCampo));
                        }

                        fila[42] = reader.GetString(reader.GetOrdinal("Pago_Total_EXT"));
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
                    if (reader.Read())
                    {
                        fila[0] = reader.GetString(reader.GetOrdinal("Promotor"));
                        fila[1] = reader.GetString(reader.GetOrdinal("Nombre_Completo"));
                        fila[2] = reader.GetString(reader.GetOrdinal("Credito_Prestado"));
                        fila[3] = reader.GetString(reader.GetOrdinal("Pagare"));
                        fila[4] = reader.GetString(reader.GetOrdinal("Calle"));
                        fila[5] = reader.GetString(reader.GetOrdinal("Colonia"));
                        fila[6] = reader.GetString(reader.GetOrdinal("Num_int"));
                        fila[7] = reader.GetString(reader.GetOrdinal("Num_ext"));
                        fila[8] = reader.GetString(reader.GetOrdinal("Telefono"));
                        fila[9] = reader.GetString(reader.GetOrdinal("Correo"));
                        fila[10] = reader.GetString(reader.GetOrdinal("Tipo_de_Resolucion"));
                        fila[11] = reader.GetString(reader.GetOrdinal("Resolucion_Demanda"));
                        fila[12] = reader.GetString(reader.GetOrdinal("Importe"));
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
                            if (reader.Read())
                            {
                                fila[0] = reader.GetString(reader.GetOrdinal("Promotor"));
                                fila[1] = reader.GetString(reader.GetOrdinal("Nombre_Completo"));
                                fila[2] = reader.GetString(reader.GetOrdinal("Credito_Prestado"));
                                fila[3] = reader.GetString(reader.GetOrdinal("Fecha_Inicio"));
                                fila[4] = reader.GetString(reader.GetOrdinal("Calle"));
                                fila[5] = reader.GetString(reader.GetOrdinal("Colonia"));
                                fila[6] = reader.GetString(reader.GetOrdinal("Num_int"));
                                fila[7] = reader.GetString(reader.GetOrdinal("Num_ext"));
                                fila[8] = reader.GetString(reader.GetOrdinal("Telefono"));
                                fila[9] = reader.GetString(reader.GetOrdinal("Correo"));
                                fila[10] = reader.GetString(reader.GetOrdinal("Forma_Liquidacion"));
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
