using MySql.Data.MySqlClient;

namespace FutureLending.Funciones.cs;

public class Accesos
{
    private static readonly LecturaBaseDatos A = new();

    #region Dar Acceso

    //Funcion que revisa si el usuario y contraseña ingresados son correctos
    public static bool Accesar(string user, string password)
    {
        using var connection = A.Conector();
        try
        {
            // Consultar la base de datos para encontrar el usuario y contraseña coincidentes
            const string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Usuario", user);
            command.Parameters.AddWithValue("@Contraseña", password);
            var count = Convert.ToInt32(command.ExecuteScalar());

            if (count <= 0) return false;
            A.Registro_Usuarios(user);
            return true;
        }
        catch (Exception ex)
        {
            A.Registro_errores(ex.ToString());
            return false;
        }
    }

    #endregion

    #region AgregarUsuario

    public static bool AgregarUsuario(string nuevoUsuario, string nuevaContraseña)
    {
        using var connection = A.Conector();
        try
        {
            // Verificar si ya existe un usuario con el mismo nombre
            const string existeUsuarioQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
            using var existeUsuarioCommand = new MySqlCommand(existeUsuarioQuery, connection);
            existeUsuarioCommand.Parameters.AddWithValue("@Usuario", nuevoUsuario);
            var usuarioExistenteCount = Convert.ToInt32(existeUsuarioCommand.ExecuteScalar());

            if (usuarioExistenteCount > 0) return false;

            // Insertar el nuevo usuario en la base de datos
            const string insertarUsuarioQuery =
                "INSERT INTO Usuarios (Usuario, Contraseña, lista1, lista2, lista3, liquidados) VALUES (@Usuario, @Contraseña, @Lista1, @Lista2, @Lista3, @Liquidados)";
            using var insertarUsuarioCommand = new MySqlCommand(insertarUsuarioQuery, connection);
            insertarUsuarioCommand.Parameters.AddWithValue("@Usuario", nuevoUsuario);
            insertarUsuarioCommand.Parameters.AddWithValue("@Contraseña", nuevaContraseña);
            insertarUsuarioCommand.Parameters.AddWithValue("@Lista1", false);
            insertarUsuarioCommand.Parameters.AddWithValue("@Lista2", false);
            insertarUsuarioCommand.Parameters.AddWithValue("@Lista3", false);
            insertarUsuarioCommand.Parameters.AddWithValue("@Liquidados", false);
            insertarUsuarioCommand.ExecuteNonQuery();

            return true;
        }
        catch (Exception ex)
        {
            A.Registro_errores(ex.ToString());
        }

        return false;
    }

    #endregion

    #region EliminarUsuario

    public static bool EliminarUsuario(string nombreUsuario)
    {
        using var connection = A.Conector();
        try
        {
            // Verificar si el usuario existe
            const string existeUsuarioQuery = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
            using var existeUsuarioCommand = new MySqlCommand(existeUsuarioQuery, connection);
            existeUsuarioCommand.Parameters.AddWithValue("@Usuario", nombreUsuario);
            var usuarioExistenteCount = Convert.ToInt32(existeUsuarioCommand.ExecuteScalar());

            var eliminarUsuarioQuery = "DELETE FROM Usuarios WHERE Usuario = @Usuario";
            if (usuarioExistenteCount <= 0)
                // El usuario no existe
                return false;

            // Eliminar el usuario de la base de datos
            using var eliminarUsuarioCommand = new MySqlCommand(eliminarUsuarioQuery, connection);
            eliminarUsuarioCommand.Parameters.AddWithValue("@Usuario", nombreUsuario);
            eliminarUsuarioCommand.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            A.Registro_errores(ex.ToString());
        }

        return false;
    }

    #endregion

    #region EditarUsuarios

    //funcion que carga al combobox los usuarios que existen
    public static List<string> CargarUsuarios()
    {
        using var connection = A.Conector();
        var nombresUsuarios = new List<string>();
        try
        {
            // Consultar la base de datos para obtener los nombres de usuario
            const string query = "SELECT Usuario FROM Usuarios";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            // Obtener los nombres de usuario y almacenarlos en una lista
            while (reader.Read())
            {
                var usuario = reader.GetString("Usuario");
                nombresUsuarios.Add(usuario);
            }

            return nombresUsuarios;
        }
        catch (Exception ex)
        {
            A.Registro_errores(ex.ToString());
        }

        return null;
    }

    // Función que edita el usuario recibiendo 2 parámetros
    public static bool EditarUsuarioContraseña(string usuario, string nuevoUsuario, string nuevaContraseña)
    {
        using var connection = A.Conector();
        const string query =
            "UPDATE Usuarios SET Usuario = @NuevoUsuario, Contraseña = @NuevaContraseña WHERE Usuario = @Usuario";
        try
        {
            // Actualizar el usuario y contraseña en la base de datos
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@NuevoUsuario", nuevoUsuario);
            command.Parameters.AddWithValue("@NuevaContraseña", nuevaContraseña);
            command.Parameters.AddWithValue("@Usuario", usuario);
            command.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            A.Registro_errores(ex.ToString());
            return false;
        }
    }

    #endregion

    #region Leer permisos

    public static List<string>? ObtenerPermisosUsuario(string nombreUsuario)
    {
        using var connection = A.Conector();
        var permisos = new List<string>();
        try
        {
            // Consultar la base de datos para obtener los permisos del usuario
            const string query = "SELECT lista1, lista2, lista3, liquidados FROM Usuarios WHERE Usuario = @Usuario";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Usuario", nombreUsuario);
            using var reader = command.ExecuteReader();
            // Obtener los permisos del usuario

            if (!reader.Read()) return permisos;
            // Iterar sobre los permisos y agregar los que estén en true a la lista
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var permiso = reader.GetName(i);

                if (reader.IsDBNull(i)) continue;
                var valor = reader.GetBoolean(i);

                if (valor) permisos.Add(permiso);
            }

            return permisos;
        }
        catch (Exception ex)
        {
            var a = new LecturaBaseDatos();
            a.Registro_errores(ex.ToString());
        }

        return null;
    }

    public static bool EditarPermisosUsuario(string nombreUsuario, List<string> nuevosPermisos)
    {
        using var connection = A.Conector();
        try
        {
            // Iniciar una transacción para asegurar la atomicidad de la operación
            using var transaction = connection.BeginTransaction();
            try
            {
                // Verificar si el usuario existe
                var query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
                using var command = new MySqlCommand(query, connection, transaction);
                command.Parameters.AddWithValue("@Usuario", nombreUsuario);
                var count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    // Actualizar los permisos del usuario en la base de datos

                    // Establecer en false todos los permisos existentes
                    query =
                        "UPDATE Usuarios SET lista1 = @lista1, lista2 = @lista2, lista3 = @lista3, liquidados = @liquidados WHERE Usuario = @Usuario";
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

                // El usuario no existe
                return false;
            }
            catch (Exception ex)
            {
                // Si ocurre un error, deshacer la transacción
                transaction.Rollback();
                A.Registro_errores(ex.ToString());
            }
        }
        catch (Exception ex)
        {
            A.Registro_errores(ex.ToString());
        }

        return false;
    }

    #endregion
}