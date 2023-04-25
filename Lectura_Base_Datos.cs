using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FutureLending
{
    internal class Lectura_Base_Datos
    {

     
       string Lect() //falta agregar parametros de recibido pero hasta que la base de datos este lista
        {
            //creamos la conexion
            string connectionString = "server=localhost;database=prestamos;uid=root;password=;";
            MySqlConnection Connection = new MySqlConnection(connectionString);
            //abrimos la conexion
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            //seleccionamos de donde leeremos los datos
            command.CommandText = "SELECT * FROM nombre_tabla";
            MySqlDataReader reader = command.ExecuteReader();
            //leemos los datos que nos arroja
            string columna1 = "";
                int columna2 = 0;
            while (reader.Read())
            {
                 columna1 = reader.GetString(0);
                 columna2 = reader.GetInt32(1);
            }

            string Global = " " + columna1 + columna2;

            //cerramos la lectura y la conexion
            reader.Close();
            Connection.Close();
            return Global;
        }

        int Edit()//falta agregar parametros de recibido pero hasta que la base de datos este lista
        {
            //creamos la conexion
            string connectionString = "server=localhost;database=prestamos;uid=root;password=;";
            MySqlConnection Connection = new MySqlConnection(connectionString);
            //abrimos la conexion
            Connection.Open();
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
            //creamos la conexion
            string connectionString = "server=localhost;database=prestamos;uid=root;password=;";
            MySqlConnection Connection = new MySqlConnection(connectionString);
            //abrimos la conexion
            Connection.Open();
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM nombre_tabla WHERE columna1='valor1' AND columna2='valor2'"; //solo se edita

            //esto nos devuelve el numero de filas que edito
            int filasAfectadas = command.ExecuteNonQuery();
            //cerramos la conexion
            Connection.Close();
            return filasAfectadas;
        }




    }
}
