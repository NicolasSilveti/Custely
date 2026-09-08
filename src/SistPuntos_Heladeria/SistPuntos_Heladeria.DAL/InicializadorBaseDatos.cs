using Microsoft.Data.Sqlite;

namespace SistPuntos_Heladeria.DAL
{
    public static class InicializadorBaseDatos
    {
        public static void Inicializar()
        {
            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS Clientes (
                    IdCliente INTEGER PRIMARY KEY AUTOINCREMENT,
                    Dni TEXT NOT NULL UNIQUE,
                    Nombre TEXT NOT NULL,
                    Apellido TEXT NOT NULL,
                    Telefono TEXT NOT NULL,
                    Activo INTEGER NOT NULL DEFAULT 1
                );

                CREATE TABLE IF NOT EXISTS MovimientosPuntos (
                    IdMovimiento INTEGER PRIMARY KEY AUTOINCREMENT,
                    IdCliente INTEGER NOT NULL,
                    Fecha TEXT NOT NULL,
                    Tipo TEXT NOT NULL,
                    Puntos INTEGER NOT NULL,
                    MontoCentavos INTEGER NOT NULL,
                    Descripcion TEXT NOT NULL,
                    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
                );

                CREATE TABLE IF NOT EXISTS Configuracion (
                    IdConfiguracion INTEGER PRIMARY KEY AUTOINCREMENT,
                    PesosPorPuntoCentavos INTEGER NOT NULL
                );
            ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            comando.ExecuteNonQuery();

            string agregarActivo = @"
                ALTER TABLE Clientes
                ADD COLUMN Activo INTEGER NOT NULL DEFAULT 1;
            ";

            try
            {
                using SqliteCommand comandoActivo =
                    new SqliteCommand(agregarActivo, conexion);

                comandoActivo.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                if (!ex.Message.Contains("duplicate column name"))
                {
                    throw;
                }
            }
        }
    }
}