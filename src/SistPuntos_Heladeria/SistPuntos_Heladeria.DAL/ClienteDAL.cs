using Microsoft.Data.Sqlite;
using SistPuntos_Heladeria.ENTITY;

namespace SistPuntos_Heladeria.DAL
{
    public class ClienteDAL
    {
        public void AgregarCliente(Cliente cliente)
        {
            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
        INSERT INTO Clientes
        (Dni, Nombre, Apellido, Telefono)
        VALUES
        (@Dni, @Nombre, @Apellido, @Telefono);
    ";

            using SqliteCommand comando = new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue("@Dni", cliente.Dni);
            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                if (ex.SqliteErrorCode == 19 &&
                    ex.Message.Contains("UNIQUE constraint failed: Clientes.Dni"))
                {
                    throw new InvalidOperationException(
                        "Ya existe un cliente con ese DNI."
                    );
                }

                throw;
            }
        }
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
          SELECT
          IdCliente,
          Dni,
          Nombre,
          Apellido,
          Telefono
           FROM Clientes
          WHERE Activo = 1
          ORDER BY Apellido, Nombre;
           ";
           

            using SqliteCommand comando = new SqliteCommand(sql, conexion);
            using SqliteDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cliente cliente = new Cliente
                {
                    IdCliente = lector.GetInt32(0),
                    Dni = lector.GetString(1),
                    Nombre = lector.GetString(2),
                    Apellido = lector.GetString(3),
                    Telefono = lector.GetString(4)
                };

                clientes.Add(cliente);
            }

            return clientes;
        }
        public Cliente? BuscarPorDni(string dni)
        {
            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
           SELECT
          IdCliente,
          Dni,
          Nombre,
          Apellido,
          Telefono
          FROM Clientes
         WHERE Dni = @Dni
         AND Activo = 1;
           ";

            using SqliteCommand comando = new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue("@Dni", dni);

            using SqliteDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                return new Cliente
                {
                    IdCliente = lector.GetInt32(0),
                    Dni = lector.GetString(1),
                    Nombre = lector.GetString(2),
                    Apellido = lector.GetString(3),
                    Telefono = lector.GetString(4)
                };
            }

            return null;
        }
        public void ModificarCliente(Cliente cliente)
        {
            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
        UPDATE Clientes
        SET
            Dni = @Dni,
            Nombre = @Nombre,
            Apellido = @Apellido,
            Telefono = @Telefono
            WHERE IdCliente = @IdCliente
            AND Activo = 1;
            ";

            using SqliteCommand comando = new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue("@Dni", cliente.Dni);
            comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            comando.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);

            try
            {
                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    throw new InvalidOperationException(
                        "No se encontró el cliente que se quería modificar."
                    );
                }
            }
            catch (SqliteException ex)
            {
                if (ex.SqliteErrorCode == 19 &&
                    ex.Message.Contains("UNIQUE constraint failed: Clientes.Dni"))
                {
                    throw new InvalidOperationException(
                        "Ya existe otro cliente con ese DNI."
                    );
                }

                throw;
            }
        }
        public void DarDeBajaCliente(int idCliente)
        {
            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
        UPDATE Clientes
        SET Activo = 0
        WHERE IdCliente = @IdCliente
          AND Activo = 1;
    ";

            using SqliteCommand comando = new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue("@IdCliente", idCliente);

            int filasAfectadas = comando.ExecuteNonQuery();

            if (filasAfectadas == 0)
            {
                throw new InvalidOperationException(
                    "No se encontró un cliente activo para dar de baja."
                );
            }
        }
    }
}