using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace FutureLending
{
      public class Accesos
        {
        #region Dar Acceso
        //Funcion que revisa si el usuario y contraseña ingresados son correctos
        public static bool Accesar(string user, string password)
        {
            string jsonFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Usuarios.json";
            Lectura_Base_Datos a = new Lectura_Base_Datos();
            try
            {
                // Leer el archivo JSON
                JArray usuariosArray = JArray.Parse(File.ReadAllText(jsonFilePath));
                foreach (JObject usuarioObj in usuariosArray.Cast<JObject>())
                {
                    string usuario = usuarioObj["Usuario"].ToString();
                    string contra = usuarioObj["Contraseña"].ToString();

                    if (usuario.Equals(user) && contra.Equals(password))
                    {
                        a.Registro_Usuarios(user);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                a.Registro_errores(ex.ToString());
                return false;
            }
        }
        #endregion

        #region AgregarUsuario

        public class Usuario
        {
            public string? Usuario1 { get; set; }
            public string? Contraseña1 { get; set; }
            public Permisos Permiso { get; set; }
        }

        public class Permisos
        {
            public bool lista1 { get; set; } = true;
            public bool lista2 { get; set; } = true;
            public bool lista3 { get; set; } = true;
            public bool liquidados { get; set; } = true;
        }

        public static bool AgregarUsuario(string nuevoUsuario, string nuevaContraseña)
        {
            Lectura_Base_Datos a = new Lectura_Base_Datos();
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = directorioProyecto + "\\Usuarios.json";

            try
            {
                // Leer el archivo JSON
                JArray jsonArray = JArray.Parse(File.ReadAllText(jsonFilePath));

                // Verificar si ya existe un usuario con el mismo nombre
                if (jsonArray.Any(u => u["Usuario"].ToString() == nuevoUsuario))
                {
                    return false;
                }

                // Crear el nuevo objeto de usuario con los permisos establecidos en false
                JObject nuevoUsuarioObj = new JObject();
                nuevoUsuarioObj["Usuario"] = nuevoUsuario;
                nuevoUsuarioObj["Contraseña"] = nuevaContraseña;

                JObject permisosObj = new JObject();
                permisosObj["lista1"] = false;
                permisosObj["lista2"] = false;
                permisosObj["lista3"] = false;
                permisosObj["liquidados"] = false;

                nuevoUsuarioObj["Permisos"] = permisosObj;

                // Agregar el nuevo usuario al arreglo JSON
                jsonArray.Add(nuevoUsuarioObj);

                // Guardar el JSON actualizado en el archivo
                File.WriteAllText(jsonFilePath, jsonArray.ToString());

                return true;
            }
            catch (Exception ex)
            {
                a.Registro_errores(ex.ToString());
            }

            return false;
        }

        #endregion

        #region EditarUsuarios
        //funcion que carga al combobox los usuarios que existen
        public static List<string>? CargarUsuarios()
        {
            Lectura_Base_Datos a = new Lectura_Base_Datos();
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = directorioProyecto + "\\Usuarios.json";

            try
            {
                // Leer el archivo JSON
                JArray jsonArray = JArray.Parse(File.ReadAllText(jsonFilePath));

                // Obtener solo los nombres de usuario
                List<string> nombresUsuarios = new List<string>();
                foreach (JObject usuarioObj in jsonArray.Cast<JObject>())
                {
                    string usuario = usuarioObj["Usuario"].ToString();
                    nombresUsuarios.Add(usuario);
                }

                // Agregar los nombres de usuario al ComboBox
                return nombresUsuarios;
            }
            catch (Exception ex)
            {
                a.Registro_errores(ex.ToString());
            }
            return null;
        }

        // Función que edita el usuario recibiendo 2 parámetros
        public static void EditarUsuarioContraseña(string usuario, string nuevoUsuario, string nuevaContraseña)
        {
            Lectura_Base_Datos a = new Lectura_Base_Datos();
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = directorioProyecto + "\\Usuarios.json";

            try
            {
                // Leer el archivo JSON
                JArray usuarios = JArray.Parse(File.ReadAllText(jsonFilePath));

                // Buscar el usuario correspondiente
                foreach (JObject usuarioObj in usuarios.Cast<JObject>())
                {
                    string nombreUsuario = usuarioObj["Usuario"].ToString();
                    if (nombreUsuario.Equals(usuario))
                    {
                        // Obtener los permisos actuales antes de actualizar el objeto de usuario
                        JToken permisos = usuarioObj["Permisos"];

                        // Crear un nuevo objeto de usuario con el nombre y contraseña actualizados
                        JObject nuevoUsuarioObj = new JObject();
                        nuevoUsuarioObj["Usuario"] = nuevoUsuario;
                        nuevoUsuarioObj["Contraseña"] = nuevaContraseña;
                        nuevoUsuarioObj["Permisos"] = permisos;

                        // Reemplazar el objeto de usuario original con el nuevo objeto
                        usuarios[usuarios.IndexOf(usuarioObj)] = nuevoUsuarioObj;

                        break;
                    }
                }

                // Guardar los cambios en el archivo JSON
                File.WriteAllText(jsonFilePath, usuarios.ToString());
            }
            catch (Exception ex)
            {
                a.Registro_errores(ex.ToString());
            }
        }

        #endregion

        #region EliminarUsuario
        public static bool EliminarUsuario(string nombreUsuario)
        {
            Lectura_Base_Datos a = new Lectura_Base_Datos();
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = directorioProyecto + "\\Usuarios.json";

            try
            {
                // Leer el archivo JSON
                JArray jsonArray = JArray.Parse(File.ReadAllText(jsonFilePath));

                // Buscar el usuario por nombre
                JObject usuarioObj = jsonArray.FirstOrDefault(u => u["Usuario"].ToString() == nombreUsuario) as JObject;

                // Verificar si se encontró el usuario
                if (usuarioObj != null)
                {
                    // Eliminar el usuario del arreglo JSON
                    jsonArray.Remove(usuarioObj);

                    // Serializar el objeto contenedor a JSON
                    string nuevoJson = jsonArray.ToString();

                    // Guardar el JSON actualizado en el archivo
                    File.WriteAllText(jsonFilePath, nuevoJson);
                    return true;
                }
                else
                {
                    // El usuario no existe
                    return false;
                }
            }
            catch (Exception ex)
            {
                a.Registro_errores(ex.ToString());
            }

            return false;
        }
        #endregion

        #region Leer permisos
        public static List<string> ObtenerPermisosUsuario(string nombreUsuario)
        {
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = directorioProyecto + "\\Usuarios.json";

            try
            {
                // Leer el archivo JSON
                JArray jsonArray = JArray.Parse(File.ReadAllText(jsonFilePath));

                // Buscar el usuario por nombre
                JObject usuarioObj = jsonArray.FirstOrDefault(u => u["Usuario"].ToString() == nombreUsuario) as JObject;

                // Verificar si se encontró el usuario
                if (usuarioObj != null)
                {
                    // Obtener los permisos del usuario
                    JObject permisosObj = usuarioObj["Permisos"] as JObject;

                    // Crear una lista para almacenar los permisos
                    List<string> permisos = new List<string>();

                    // Iterar sobre los permisos y agregar los que estén en true a la lista
                    foreach (KeyValuePair<string, JToken> permiso in permisosObj)
                    {
                        if (permiso.Value.Type == JTokenType.Boolean && (bool)permiso.Value)
                        {
                            permisos.Add(permiso.Key);
                        }
                    }

                    return permisos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los permisos del usuario: " + ex.ToString());
            }

            return null;
        }

        public static bool EditarPermisosUsuario(string nombreUsuario, List<string> nuevosPermisos)
        {
            Lectura_Base_Datos a = new Lectura_Base_Datos();
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = directorioProyecto + "\\Usuarios.json";

            try
            {
                // Leer el archivo JSON
                JArray jsonArray = JArray.Parse(File.ReadAllText(jsonFilePath));

                // Buscar el usuario por nombre
                JObject usuarioObj = jsonArray.FirstOrDefault(u => u["Usuario"].ToString() == nombreUsuario) as JObject;

                // Verificar si se encontró el usuario
                if (usuarioObj != null)
                {
                    // Obtener el objeto de permisos del usuario
                    JObject permisosObj = usuarioObj["Permisos"] as JObject;

                    // Establecer en false todos los permisos existentes
                    foreach (var permisoProp in permisosObj.Properties())
                    {
                        permisoProp.Value = false;
                    }

                    // Establecer en true los nuevos permisos recibidos
                    foreach (var permiso in nuevosPermisos)
                    {
                        if (permisosObj.ContainsKey(permiso))
                        {
                            permisosObj[permiso] = true;
                        }
                    }

                    // Guardar los cambios en el archivo JSON
                    File.WriteAllText(jsonFilePath, jsonArray.ToString());
                    return true;
                }
            }
            catch (Exception ex)
            {
                a.Registro_errores(ex.ToString());
            }

            return false;
        }




        #endregion
    }
}