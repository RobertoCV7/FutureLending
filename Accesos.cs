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
            Lectura_Base_Datos a = new();
            try
            {
                // Leer el archivo JSON
                JArray usuariosArray = JArray.Parse(File.ReadAllText(jsonFilePath));
                foreach (JObject usuarioObj in usuariosArray.Cast<JObject>())
                {
                    string usuario = usuarioObj["Usuario1"].ToString();
                    string contra = usuarioObj["Contraseña1"].ToString();

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
        }

        public  bool AgregarUsuario(string nuevoUsuario, string nuevaContraseña)
        {
            Lectura_Base_Datos a = new();
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string json = File.ReadAllText(directorioProyecto + "\\Usuarios.json");
            // Deserializar el JSON en una lista de usuarios
            List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

            usuarios ??= new List<Usuario>();

            // Verificar si ya existe un usuario con el mismo nombre
            if (usuarios.Exists(u => u.Usuario1 == nuevoUsuario))
            {
                //AvisoVacio.Text = "El usuario ya existe. No se pudo agregar";
                return false;
            }

            // Agregar el nuevo usuario a la lista
            usuarios.Add(new Usuario { Usuario1 = nuevoUsuario, Contraseña1 = nuevaContraseña });

            // Serializar el objeto contenedor a JSON
            string nuevoJson = JsonConvert.SerializeObject(usuarios, Formatting.Indented);

            // Guardar el JSON actualizado en el archivo
            string direct = directorioProyecto + "\\Usuarios.json";
            File.WriteAllText(direct, nuevoJson);
            return true;
        }
        #endregion

        #region EditarUsuarios
        //funcion que carga al combobox los usuarios que existen
        public List<string>  CargarUsuarios()
        {
            Lectura_Base_Datos a = new();
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = directorioProyecto + "\\Usuarios.json";

            try
            {
                // Leer el archivo JSON
                JArray jsonArray = JArray.Parse(File.ReadAllText(jsonFilePath));

                // Obtener solo los nombres de usuario
                List<string> nombresUsuarios = new();
                foreach (JObject usuarioObj in jsonArray.Cast<JObject>())
                {
                    string usuario = usuarioObj["Usuario1"].ToString();
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
        //funcion que edita el usuario recibiendo 2 parametros
        public  void EditarUsuarioContraseña(string usuario, string nuevaContraseña)
        {
            Lectura_Base_Datos a = new();
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = directorioProyecto + "\\Usuarios.json";

            try
            {
                // Leer el archivo JSON
                JArray usuarios = JArray.Parse(File.ReadAllText(jsonFilePath));

                // Buscar el usuario correspondiente
                foreach (JObject usuarioObj in usuarios.Cast<JObject>())
                {
                    string nombreUsuario = usuarioObj["Usuario1"].ToString();
                    if (nombreUsuario.Equals(usuario))
                    {
                        // Actualizar la contraseña
                        usuarioObj["Contraseña1"] = nuevaContraseña;
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
        public bool EliminarUsuario(string nombreUsuario)
        {
            Lectura_Base_Datos a = new();
            string directorioProyecto = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = directorioProyecto + "\\Usuarios.json";

            try
            {
                // Leer el archivo JSON
                JArray jsonArray = JArray.Parse(File.ReadAllText(jsonFilePath));

                // Buscar el usuario por nombre
                JObject usuarioObj = jsonArray.FirstOrDefault(u => u["Usuario1"].ToString() == nombreUsuario) as JObject;

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


    }
}