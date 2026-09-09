using Microsoft.Data.Sqlite;
using SistPuntos_Heladeria.ENTITY;

namespace SistPuntos_Heladeria.DAL
{
    public class MovimientoPuntosDAL
    {
        public void AgregarMovimiento(MovimientoPuntos movimiento)
        {
            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
                INSERT INTO MovimientosPuntos
                (
                    IdCliente,
                    Fecha,
                    Tipo,
                    Puntos,
                    MontoCentavos,
                    Descripcion
                )
                VALUES
                (
                    @IdCliente,
                    @Fecha,
                    @Tipo,
                    @Puntos,
                    @MontoCentavos,
                    @Descripcion
                );
            ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue(
                "@IdCliente",
                movimiento.IdCliente
            );

            comando.Parameters.AddWithValue(
                "@Fecha",
                movimiento.Fecha.ToString("yyyy-MM-dd HH:mm:ss")
            );

            comando.Parameters.AddWithValue(
                "@Tipo",
                movimiento.Tipo
            );

            comando.Parameters.AddWithValue(
                "@Puntos",
                movimiento.Puntos
            );

            long montoCentavos =
                (long)Math.Round(movimiento.Monto * 100);

            comando.Parameters.AddWithValue(
                "@MontoCentavos",
                montoCentavos
            );

            comando.Parameters.AddWithValue(
                "@Descripcion",
                movimiento.Descripcion
            );

            comando.ExecuteNonQuery();
        }
        public List<MovimientoPuntos> ObtenerMovimientosPorCliente(int idCliente)
        {
            List<MovimientoPuntos> movimientos =
                new List<MovimientoPuntos>();

            using SqliteConnection conexion = Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
        SELECT
            IdMovimiento,
            IdCliente,
            Fecha,
            Tipo,
            Puntos,
            MontoCentavos,
            Descripcion
        FROM MovimientosPuntos
        WHERE IdCliente = @IdCliente
        ORDER BY Fecha DESC;
    ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue(
                "@IdCliente",
                idCliente
            );

            using SqliteDataReader lector =
                comando.ExecuteReader();

            while (lector.Read())
            {
                long montoCentavos =
                    lector.GetInt64(5);

                MovimientoPuntos movimiento =
                    new MovimientoPuntos
                    {
                        IdMovimiento = lector.GetInt32(0),
                        IdCliente = lector.GetInt32(1),
                        Fecha = DateTime.Parse(
                            lector.GetString(2)
                        ),
                        Tipo = lector.GetString(3),
                        Puntos = lector.GetInt32(4),
                        Monto = montoCentavos / 100m,
                        Descripcion = lector.GetString(6)
                    };

                movimientos.Add(movimiento);
            }

            return movimientos;
        }
        public int ObtenerSaldoPuntos(int idCliente)
        {
            using SqliteConnection conexion =
                Conexion.CrearConexion();

            conexion.Open();

            string sql = @"
        SELECT COALESCE(SUM(Puntos), 0)
        FROM MovimientosPuntos
        WHERE IdCliente = @IdCliente;
    ";

            using SqliteCommand comando =
                new SqliteCommand(sql, conexion);

            comando.Parameters.AddWithValue(
                "@IdCliente",
                idCliente
            );

            object? resultado =
                comando.ExecuteScalar();

            return Convert.ToInt32(resultado);
        }
    }
}