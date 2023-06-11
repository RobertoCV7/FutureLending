using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Threading.Timer;

namespace FutureLending.Funciones.cs
{
    internal class BackupService
    {
        private volatile bool isBackupRunning;
        public void StartBackup(bool continuar)
        {

            while (continuar)
            {
                // Obtener la hora actual
                DateTime now = DateTime.Now;

                // Calcular la hora en la que se ejecutará la próxima copia de seguridad
                DateTime scheduledTime = new DateTime(now.Year, now.Month, now.Day, 12, 00, 00);
                // Si ya pasó la hora programada para hoy, se programa para mañana
                if (now == scheduledTime)
                {
                    BackupDatabase(null);
                }
                else
                {
                }
            }
        }
        public void StopBackup()
        {
            Application.Exit();
        }

        private void BackupDatabase(object state)
        {
            Lectura_Base_Datos lec = new();
            // Especificar los detalles de conexión a la base de datos "prestamos" y "prestamos_copia"
            string sourceConnectionString = "Server=localhost;Database=prestamos;Uid=root;";
            string destinationConnectionString = "Server=localhost;Database=prestamos_copia;Uid=root;";

            try
            {
                using (MySqlConnection sourceConnection = new MySqlConnection(sourceConnectionString))
                {
                    // Abrir la conexión a la base de datos de origen (prestamos)
                    sourceConnection.Open();

                    using (MySqlConnection destinationConnection = new MySqlConnection(destinationConnectionString))
                    {
                        // Abrir la conexión a la base de datos de destino (prestamos_copia)
                        destinationConnection.Open();

                        // Obtener la lista de tablas en la base de datos de origen (prestamos)
                        string getTablesQuery = "SHOW TABLES";
                        using (MySqlCommand command = new MySqlCommand(getTablesQuery, sourceConnection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                // Iterar por cada tabla
                                while (reader.Read())
                                {
                                    // Obtener el nombre de la tabla
                                    string tableName = reader.GetString(0);

                                    // Copiar los datos de la tabla de origen (prestamos) a la tabla de destino (prestamos_copia)
                                    string copyTableQuery = $"INSERT INTO prestamos_copia.{tableName} SELECT * FROM prestamos.{tableName}";
                                    using (MySqlCommand copyCommand = new MySqlCommand(copyTableQuery, destinationConnection))
                                    {
                                        copyCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar errores de copia de tablas
                lec.Registro_errores("Error al copiar las tablas: " + ex.Message);
            }
        }
    }
}
