using Microsoft.Data.Sqlite;
using Custely.ENTITY;

namespace Custely.DAL
{
    public class UsuarioDAL
    {
        public void AgregarUsuario(Usuario usuario)
        {
            using SqliteConnection conexion = Conexion.CrearConexion();
            conexion.Open();

            string sql = @"
                INSERT INTO Usuarios
                (
                    Nombre,
                    Apellido,
                    NombreUsuario,
                    ClaveHash,
                    Rol
                )
                VALUES
                (
                    @Nombre,
                    @Apellido,
                    @NombreUsuario,
                    @ClaveHash,
                    @Rol
                );
            ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue(
                "@Nombre",
                usuario.Nombre
            );

            comando.Parameters.AddWithValue(
                "@Apellido",
                usuario.Apellido
            );

            comando.Parameters.AddWithValue(
                "@NombreUsuario",
                usuario.NombreUsuario
            );

            comando.Parameters.AddWithValue(
                "@ClaveHash",
                usuario.ClaveHash
            );

            comando.Parameters.AddWithValue(
                "@Rol",
                usuario.Rol
            );

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                if (ex.SqliteErrorCode == 19 &&
                    ex.Message.Contains(
                        "UNIQUE constraint failed: Usuarios.NombreUsuario"
                    ))
                {
                    throw new InvalidOperationException(
                        "Ya existe un usuario con ese nombre de usuario."
                    );
                }

                throw;
            }
        }

        public Usuario? BuscarPorNombreUsuario(
            string nombreUsuario
        )
        {
            using SqliteConnection conexion = Conexion.CrearConexion();
            conexion.Open();

            string sql = @"
                SELECT
                    IdUsuario,
                    Nombre,
                    Apellido,
                    NombreUsuario,
                    ClaveHash,
                    Rol,
                    Activo
                FROM Usuarios
                WHERE NombreUsuario = @NombreUsuario
                  AND Activo = 1;
            ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue(
                "@NombreUsuario",
                nombreUsuario
            );

            using SqliteDataReader lector =
                comando.ExecuteReader();

            if (lector.Read())
            {
                return new Usuario
                {
                    IdUsuario = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Apellido = lector.GetString(2),
                    NombreUsuario = lector.GetString(3),
                    ClaveHash = lector.GetString(4),
                    Rol = lector.GetString(5),
                    Activo = lector.GetInt32(6) == 1
                };
            }

            return null;
        }

        public List<Usuario> ObtenerUsuariosActivos()
        {
            List<Usuario> usuarios =
                new List<Usuario>();

            using SqliteConnection conexion =
                Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
                SELECT
                    IdUsuario,
                    Nombre,
                    Apellido,
                    NombreUsuario,
                    ClaveHash,
                    Rol,
                    Activo
                FROM Usuarios
                WHERE Activo = 1
                ORDER BY Apellido, Nombre;
            ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            while (lector.Read())
            {
                Usuario usuario = new Usuario
                {
                    IdUsuario = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Apellido = lector.GetString(2),
                    NombreUsuario = lector.GetString(3),
                    ClaveHash = lector.GetString(4),
                    Rol = lector.GetString(5),
                    Activo = lector.GetInt32(6) == 1
                };

                usuarios.Add(usuario);
            }

            return usuarios;
        }
        public bool ExistenUsuarios()
        {
            using SqliteConnection conexion = Conexion.CrearConexion();
            conexion.Open();

            string sql = @"
        SELECT COUNT(*)
        FROM Usuarios;
    ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            long cantidad = (long)comando.ExecuteScalar()!;

            return cantidad > 0;
        }
        public void ActualizarClave(
    int idUsuario,
    string nuevaClaveHash
)
        {
            using SqliteConnection conexion = Conexion.CrearConexion();
            conexion.Open();

            string sql = @"
        UPDATE Usuarios
        SET ClaveHash = @ClaveHash
        WHERE IdUsuario = @IdUsuario
          AND Activo = 1;
    ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue(
                "@ClaveHash",
                nuevaClaveHash
            );

            comando.Parameters.AddWithValue(
                "@IdUsuario",
                idUsuario
            );

            int filasAfectadas = comando.ExecuteNonQuery();

            if (filasAfectadas == 0)
            {
                throw new InvalidOperationException(
                    "No se encontró el usuario."
                );
            }
        }
    }
}