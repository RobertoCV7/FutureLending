using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Crypto.Tls;

namespace FutureLending
{
    internal class Lectura_Base_Datos
    {
      MySqlConnection Conector()
        {
            //creamos la conexion
            string connectionString = "server=localhost;database=prestamos;uid=root;password=;";
            MySqlConnection Connection = new MySqlConnection(connectionString);
        
            try
            {
                //abrimos la conexion
                Connection.Open();
            }
            catch(Exception ex)
            {
                //en caso de error nos muestra el error en la aplicacion
                MessageBox.Show(ex.Message);
            }

            return Connection;
        }
     
       string Lect(string tabla) 
        {
            //declaramos las variables que leeran la base de datos
            string Global = "";
            string Nombre = "", Credito = "", Fecha_inicio = "", Interes = "", Promotor = "", Calle = "", Colonia = "", Num_int = "", Num_ext = "", Telefono="", Correo="";
            int tipo_de_pago = 0;
            string[] fechas_pago = new string[14];

            MySqlConnection Connection = Conector(); //llamamos al conector
            MySqlCommand command = Connection.CreateCommand();
            
            command.CommandText = "SELECT * FROM "+tabla;//seleccionamos de donde leeremos los datos
            MySqlDataReader reader = command.ExecuteReader();
            //leemos los datos que nos arroja , tambien se podria usar un foreach
            while (reader.Read())
            {
                    Nombre = reader.GetString(0);
                    Credito = reader.GetString(1);
                    Fecha_inicio = reader.GetString(2);
                    Interes = reader.GetString(3);
                    Promotor = reader.GetString(4);
                    Calle = reader.GetString(5);
                    Colonia = reader.GetString(6);
                    Num_int = reader.GetString(7);
                    Num_ext = reader.GetString(8);
                    Telefono = reader.GetString(9);
                    Correo = reader.GetString(10);
                    tipo_de_pago = reader.GetInt32(11);
                    fechas_pago[0] = reader.GetString(12);
                    fechas_pago[1] = reader.GetString(13);
                    fechas_pago[2] = reader.GetString(14);
                    fechas_pago[3] = reader.GetString(15);
                    fechas_pago[4] = reader.GetString(16);
                    fechas_pago[5] = reader.GetString(17);
                    fechas_pago[6] = reader.GetString(18);
                    fechas_pago[7] = reader.GetString(19);
                    fechas_pago[8] = reader.GetString(20);
                    fechas_pago[9] = reader.GetString(21);
                    fechas_pago[10] = reader.GetString(22);
                    fechas_pago[11] = reader.GetString(23);
                    fechas_pago[12] = reader.GetString(24);
                    fechas_pago[13] = reader.GetString(25);
                Global += Nombre + "." + Credito + "." + Fecha_inicio + "." + Interes + "." + Promotor + "." + Calle + "." + Colonia + "." + Num_int + "." + Num_ext + "." + Telefono + "." + Correo + "." + tipo_de_pago + "." + fechas_pago[0] + "." + fechas_pago[1] + "." + fechas_pago[2] + "." + fechas_pago[3] + "." + fechas_pago[4] + "." + fechas_pago[5] + "." + fechas_pago[6] + "." + fechas_pago[7] + "." + fechas_pago[8] + "." + fechas_pago[9] + "." + fechas_pago[10] + "." + fechas_pago[11] + "." + fechas_pago[12] + "." + fechas_pago[13]+"/n";    
            }
          
            //cerramos la lectura y la conexion
            reader.Close();
            Connection.Close();
            return Global;
        }

        int Edit()//falta agregar parametros de recibido pero hasta que la base de datos este lista
        {
            //creamos la conexion
            MySqlConnection Connection = Conector(); //llamamos al conector
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "UPDATE nombre_tabla SET columna1='valor1', columna2='valor2' WHERE id=1"; //simplemente se editan los parametros

            //esto nos devuelve el numero de filas que edito
            int filasAfectadas = command.ExecuteNonQuery();
            //cerramos la conexion
            Connection.Close();
            return filasAfectadas;
        }

        int erase()//falta agregar parametros de recibido pero hasta que la base de datos este lista
        {
            MySqlConnection Connection = Conector(); //llamamos al conector
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM nombre_tabla WHERE columna1='valor1' AND columna2='valor2'"; //solo se edita

            //esto nos devuelve el numero de filas que edito
            int filasAfectadas = command.ExecuteNonQuery();
            //cerramos la conexion
            Connection.Close();
            return filasAfectadas;
        }

        void create(string Nombre, string Credito, string Fecha_inicio, string Interes, string Promotor, string Calle, string Num_int, string Num_ext, string Telefono,string Correo,int Tipo_pago)
        {

            //con esto separamos la fecha en dia, mes y año que recibimos en string y lo convertimos a int
            int[] dia = new int[3];
            char[] delimitadores = { '-' };
            int z= 0;
            string[] tokens = Fecha_inicio.Split(delimitadores);

            foreach (string token in tokens)
            {
                dia[z]=Int32.Parse(token);
                z++;
            }

            //declaracion de los array de las fechas de pago para automatico calcular
            string[] dias_de_pago = new string[14];
            string[] dias_de_pago_quincena = new string[14];

            if (Tipo_pago == 1)
            {
                for(int i=0; i<14; i++)
                {
                    //pedazo de codigo que calcula los dias de pago
                    DateTime fechaInicio = new DateTime(dia[0], dia[1], dia[2]); // Define la fecha de inicio
                    int diasASumar = 7; // dias que se suman
                    DateTime fechaFinal = fechaInicio.AddDays(diasASumar); // Suma los días a la fecha de inicio
                    dias_de_pago[i] = fechaFinal.ToString();
                }
                MySqlConnection Connection = Conector(); //llamamos al conector 
                string query = "INSERT INTO tabla (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Interes, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Fecha1, Fecha2, Fecha3, Fecha4, Fecha5, Fecha6, Fecha7, Fecha8, Fecha9, Fecha10, Fecha11, Fecha12, Fecha13, Fecha14) VALUES ('" + Nombre + "', '" + Credito + "', '" + Fecha_inicio + "' , '" + Interes + "' , '" + Promotor + "' , '" + Calle + "' ," + Num_int + "' , '" + Num_ext + "' ," + Telefono + "' , " + Tipo_pago + "', '" + dias_de_pago[0] + "' , '" + dias_de_pago[1] + "' , '" + dias_de_pago[2] + "' , '" + dias_de_pago[3] + "' , '" + dias_de_pago[4] + "' , '" + dias_de_pago[5] + "' , '" + dias_de_pago[6] + "' , '" + dias_de_pago[7] + "' , '" + dias_de_pago[8] + "' , '" + dias_de_pago[9] + "' , ' " + dias_de_pago[10] + "' , '" + dias_de_pago[11] + "' , '" + dias_de_pago[12] + "', '" + dias_de_pago[13] + "')"; //se insertan los valores
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();
                Connection.Close();

            }
            else
            {
                for(int i=0; i<7; i++)
                {
                    //pedazo de codigo que calcula los dias de pago
                    DateTime fechaInicio = new DateTime(dia[0], dia[1], dia[2]); // Define la fecha de inicio
                    int diasASumar = 15; // dias que se suman
                    DateTime fechaFinal = fechaInicio.AddDays(diasASumar); // Suma los días a la fecha de inicio
                    dias_de_pago_quincena[i] = fechaFinal.ToString();
                }
                MySqlConnection Connection = Conector(); //llamamos al conector 
                string query = "INSERT INTO tabla (Nombre_Completo, Credito_Prestado, Fecha_Inicio, Interes, Promotor, Calle, Colonia, Num_int, Num_ext, Telefono, Correo, Tipo_pago, Fecha1, Fecha2, Fecha3, Fecha4, Fecha5, Fecha6, Fecha7) VALUES ('" + Nombre + "', '" + Credito + "', '" + Fecha_inicio + "' , '" + Interes + "' , '" + Promotor + "' , '" + Calle + "' ," + Num_int + "' , '" + Num_ext + "' ," + Telefono + "' , " + Tipo_pago + "', '" + dias_de_pago_quincena[0] + "' , '" + dias_de_pago_quincena[1] + "' , '" + dias_de_pago_quincena[2] + "' , '" + dias_de_pago_quincena[3] + "' , '" + dias_de_pago_quincena[4] + "' , '" + dias_de_pago_quincena[5] + "' , '" + dias_de_pago_quincena[6] + "')"; //se insertan los valores
                MySqlCommand command = new MySqlCommand(query, Connection);
                command.ExecuteNonQuery();
                Connection.Close();

            }
        }



    }
}
