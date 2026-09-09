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
    }
}