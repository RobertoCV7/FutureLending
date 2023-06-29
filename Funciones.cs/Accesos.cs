using MySql.Data.MySqlClient;
using System.Data;

namespace FutureLending
{
    public class Accesos
    {
        static Lectura_Base_Datos a = new Lectura_Base_Datos();
        #region Dar Acceso
        //Funcion que revisa si el usuario y contraseña ingresados son correctos
        public static bool Accesar(string user, string password)
        {


            using (MySqlConnection connection = a.Conector())
            {
                try
                {
                    // Consultar la base de datos para encontrar el usuario y contraseña coincidentes
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", user);
                        command.Parameters.AddWithValue("@Contraseña", password);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            a.Registro_Usuarios(user);
                            return true;
                        }

                        return false;
                    }
                }
                catch (Exception ex)
                {
                    a.Registro_errores(ex.ToString());
                    return false;
                }
            }

        }
        #endregion
        #region AgregarUsuario
        public static bool AgregarUsuario(string nuevoUsuario, string nuevaContraseña)
        {
            using (MySqlConnection connection = a.Conector())
            {
                try
                {
                    // Verificar si ya existe un usuario con el mismo nombre
                    string existeUsuarioQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
                    using (MySqlCommand existeUsuarioCommand = new MySqlCommand(existeUsuarioQuery, connection))
                    {
                        existeUsuarioCommand.Parameters.AddWithValue("@Usuario", nuevoUsuario);
                        int usuarioExistenteCount = Convert.ToInt32(existeUsuarioCommand.ExecuteScalar());

                        if (usuarioExistenteCount > 0)
                        {
                            return false;
                        }
                    }

                    // Insertar el nuevo usuario en la base de datos
                    string insertarUsuarioQuery = "INSERT INTO Usuarios (Usuario, Contraseña, lista1, lista2, lista3, liquidados) VALUES (@Usuario, @Contraseña, @Lista1, @Lista2, @Lista3, @Liquidados)";
                    using (MySqlCommand insertarUsuarioCommand = new MySqlCommand(insertarUsuarioQuery, connection))
                    {
                        insertarUsuarioCommand.Parameters.AddWithValue("@Usuario", nuevoUsuario);
                        insertarUsuarioCommand.Parameters.AddWithValue("@Contraseña", nuevaContraseña);
                        insertarUsuarioCommand.Parameters.AddWithValue("@Lista1", false);
                        insertarUsuarioCommand.Parameters.AddWithValue("@Lista2", false);
                        insertarUsuarioCommand.Parameters.AddWithValue("@Lista3", false);
                        insertarUsuarioCommand.Parameters.AddWithValue("@Liquidados", false);
                        insertarUsuarioCommand.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    a.Registro_errores(ex.ToString());
                }

            }

            return false;
        }

        #endregion
        #region EditarUsuarios
        //funcion que carga al combobox los usuarios que existen
        public static List<string> CargarUsuarios()
        {
            using (MySqlConnection connection = a.Conector())
            {
                try
                {
                    // Consultar la base de datos para obtener los nombres de usuario
                    string query = "SELECT Usuario FROM Usuarios";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        List<string> nombresUsuarios = new List<string>();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Obtener los nombres de usuario y almacenarlos en una lista
                            while (reader.Read())
                            {
                                string usuario = reader.GetString("Usuario");
                                nombresUsuarios.Add(usuario);
                            }
                        }

                        return nombresUsuarios;
                    }
                }
                catch (Exception ex)
                {
                    a.Registro_errores(ex.ToString());
                }

            }

            return null;
        }
        // Función que edita el usuario recibiendo 2 parámetros
        public static bool EditarUsuarioContraseña(string usuario, string nuevoUsuario, string nuevaContraseña)
        {
            using (MySqlConnection connection = a.Conector())
            {
                try
                {
                    // Actualizar el usuario y contraseña en la base de datos
                    string query = "UPDATE Usuarios SET Usuario = @NuevoUsuario, Contraseña = @NuevaContraseña WHERE Usuario = @Usuario";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NuevoUsuario", nuevoUsuario);
                        command.Parameters.AddWithValue("@NuevaContraseña", nuevaContraseña);
                        command.Parameters.AddWithValue("@Usuario", usuario);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    a.Registro_errores(ex.ToString());
                    return false;
                }
            }
        }
        #endregion
        #region EliminarUsuario
        public static bool EliminarUsuario(string nombreUsuario)
        {
            using (MySqlConnection connection = a.Conector())
            {
                try
                {
                    // Verificar si el usuario existe
                    string existeUsuarioQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
                    using (MySqlCommand existeUsuarioCommand = new MySqlCommand(existeUsuarioQuery, connection))
                    {
                        existeUsuarioCommand.Parameters.AddWithValue("@Usuario", nombreUsuario);
                        int usuarioExistenteCount = Convert.ToInt32(existeUsuarioCommand.ExecuteScalar());

                        if (usuarioExistenteCount > 0)
                        {
                            // Eliminar el usuario de la base de datos
                            string eliminarUsuarioQuery = "DELETE FROM Usuarios WHERE Usuario = @Usuario";
                            using (MySqlCommand eliminarUsuarioCommand = new MySqlCommand(eliminarUsuarioQuery, connection))
                            {
                                eliminarUsuarioCommand.Parameters.AddWithValue("@Usuario", nombreUsuario);
                                eliminarUsuarioCommand.ExecuteNonQuery();
                            }

                            return true;
                        }
                        else
                        {
                            // El usuario no existe
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    a.Registro_errores(ex.ToString());
                }
            }
            return false;
        }
        #endregion
        #region Leer permisos
        public static List<string>? ObtenerPermisosUsuario(string nombreUsuario)
        {
            using (MySqlConnection connection = a.Conector())
            {
                try
                {
                    // Consultar la base de datos para obtener los permisos del usuario
                    string query = "SELECT lista1, lista2, lista3, liquidados FROM Usuarios WHERE Usuario = @Usuario";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Usuario", nombreUsuario);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Obtener los permisos del usuario
                            List<string> permisos = new List<string>();

                            if (reader.Read())
                            {
                                // Iterar sobre los permisos y agregar los que estén en true a la lista
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    string permiso = reader.GetName(i);

                                    if (!reader.IsDBNull(i))
                                    {
                                        bool valor = reader.GetBoolean(i);

                                        if (valor)
                                        {
                                            permisos.Add(permiso);
                                        }
                                    }
                                }
                            }
                            return permisos;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los permisos del usuario: " + ex.ToString());
                }
            }
            return null;
        }
        public static bool EditarPermisosUsuario(string nombreUsuario, List<string> nuevosPermisos)
        {
            using (MySqlConnection connection = a.Conector())
            {
                try
                {
                    // Iniciar una transacción para asegurar la atomicidad de la operación
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Verificar si el usuario existe
                            string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
                            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@Usuario", nombreUsuario);
                                int count = Convert.ToInt32(command.ExecuteScalar());

                                if (count > 0)
                                {
                                    // Actualizar los permisos del usuario en la base de datos

                                    // Establecer en false todos los permisos existentes
                                    query = "UPDATE Usuarios SET lista1 = @lista1, lista2 = @lista2, lista3 = @lista3, liquidados = @liquidados WHERE Usuario = @Usuario";
                                    command.CommandText = query;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@lista1", false);
                                    command.Parameters.AddWithValue("@lista2", false);
                                    command.Parameters.AddWithValue("@lista3", false);
                                    command.Parameters.AddWithValue("@liquidados", false);
                                    command.Parameters.AddWithValue("@Usuario", nombreUsuario);
                                    command.ExecuteNonQuery();

                                    // Establecer en true los nuevos permisos recibidos
                                    foreach (var permiso in nuevosPermisos)
                                    {
                                        query = $"UPDATE Usuarios SET {permiso} = @Valor WHERE Usuario = @Usuario";
                                        command.CommandText = query;
                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@Valor", true);
                                        command.Parameters.AddWithValue("@Usuario", nombreUsuario);
                                        command.ExecuteNonQuery();
                                    }

                                    // Confirmar la transacción
                                    transaction.Commit();

                                    return true;
                                }
                                else
                                {
                                    // El usuario no existe
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Si ocurre un error, deshacer la transacción
                            transaction.Rollback();
                            a.Registro_errores(ex.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    a.Registro_errores(ex.ToString());
                }
            }
            return false;
        }
        #endregion
    }
}