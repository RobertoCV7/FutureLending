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
      MySqlConnection Conector()
        {
            //creamos la conexion
            string connectionString = "server=localhost;database=prestamos;uid=root;password=;";
            MySqlConnection Connection = new MySqlConnection(connectionString);
            //abrimos la conexion
            Connection.Open();
            return Connection;
        }
     
       string Lect() //falta agregar parametros de recibido pero hasta que la base de datos este lista
        {
            //declaramos las variables que leeran la base de datos
            string columna1 = "";
            int columna2 = 0;
            MySqlConnection Connection = Conector(); //llamamos al conector
            MySqlCommand command = Connection.CreateCommand();
            
            command.CommandText = "SELECT * FROM nombre_tabla";//seleccionamos de donde leeremos los datos
            MySqlDataReader reader = command.ExecuteReader();
            //leemos los datos que nos arroja , tambien se podria usar un foreach
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

        void create()
        {
            MySqlConnection Connection = Conector(); //llamamos al conector 
            string query = "INSERT INTO tabla (campo1, campo2, campo3) VALUES ('valor1', 'valor2', 'valor3')";//se insertan los valores
            MySqlCommand command = new MySqlCommand(query, Connection);
            command.ExecuteNonQuery();
            Connection.Close();
        }



    }
}
