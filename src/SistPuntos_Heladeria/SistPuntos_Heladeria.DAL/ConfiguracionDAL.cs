using Microsoft.Data.Sqlite;
using SistPuntos_Heladeria.ENTITY;

namespace SistPuntos_Heladeria.DAL
{
    public class ConfiguracionDAL
    {
        public Configuracion? ObtenerConfiguracion()
        {
            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
                SELECT
                    IdConfiguracion,
                    PesosPorPuntoCentavos
                FROM Configuracion
                ORDER BY IdConfiguracion
                LIMIT 1;
            ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            if (lector.Read())
            {
                long pesosPorPuntoCentavos =
                    lector.GetInt64(1);

                return new Configuracion
                {
                    IdConfiguracion = lector.GetInt32(0),
                    PesosPorPunto =
                        pesosPorPuntoCentavos / 100m
                };
            }

            return null;
        }
        public void ActualizarPesosPorPunto(decimal pesosPorPunto)
        {
            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            long pesosPorPuntoCentavos =
                (long)Math.Round(pesosPorPunto * 100);

            string sql = @"
        UPDATE Configuracion
        SET PesosPorPuntoCentavos = @PesosPorPuntoCentavos
        WHERE IdConfiguracion = (
            SELECT IdConfiguracion
            FROM Configuracion
            ORDER BY IdConfiguracion
            LIMIT 1
        );
    ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue(
                "@PesosPorPuntoCentavos",
                pesosPorPuntoCentavos
            );

            int filasAfectadas = comando.ExecuteNonQuery();

            if (filasAfectadas == 0)
            {
                throw new InvalidOperationException(
                    "No se encontró la configuración del sistema."
                );
            }
        }
    }
}