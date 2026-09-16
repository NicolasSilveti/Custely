using Custely.DAL;
using Custely.ENTITY;

namespace Custely.BLL
{
    public class MovimientoPuntosBLL
    {
        private readonly MovimientoPuntosDAL movimientoPuntosDAL =
            new MovimientoPuntosDAL();

        private readonly ConfiguracionDAL configuracionDAL =
            new ConfiguracionDAL();

        public void RegistrarCompra(
            int idCliente,
            decimal monto
        )
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "El cliente seleccionado no es válido."
                );
            }

            if (monto <= 0)
            {
                throw new ArgumentException(
                    "El monto debe ser mayor a cero."
                );
            }

            Configuracion? configuracion =
                configuracionDAL.ObtenerConfiguracion();

            if (configuracion == null)
            {
                throw new InvalidOperationException(
                    "No existe una configuración de puntos."
                );
            }

            if (configuracion.PesosPorPunto <= 0)
            {
                throw new InvalidOperationException(
                    "La configuración de puntos no es válida."
                );
            }

            int puntosGanados =
                (int)Math.Floor(
                    monto / configuracion.PesosPorPunto
                );

            MovimientoPuntos movimiento =
                new MovimientoPuntos
                {
                    IdCliente = idCliente,
                    Fecha = DateTime.Now,
                    Tipo = "Carga",
                    Puntos = puntosGanados,
                    Monto = monto,
                    Descripcion = "Compra"
                };

            movimientoPuntosDAL.AgregarMovimiento(movimiento);
        }
        public void RegistrarCanje(
    int idCliente,
    int puntosACanjear
)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "El cliente seleccionado no es válido."
                );
            }

            if (puntosACanjear <= 0)
            {
                throw new ArgumentException(
                    "La cantidad de puntos a canjear debe ser mayor a cero."
                );
            }

            int saldoActual =
                movimientoPuntosDAL.ObtenerSaldoPuntos(idCliente);

            if (puntosACanjear > saldoActual)
            {
                throw new InvalidOperationException(
                    "El cliente no tiene suficientes puntos para realizar el canje."
                );
            }

            MovimientoPuntos movimiento =
                new MovimientoPuntos
                {
                    IdCliente = idCliente,
                    Fecha = DateTime.Now,
                    Tipo = "Canje",
                    Puntos = -puntosACanjear,
                    Monto = 0,
                    Descripcion = "Canje de puntos"
                };

            movimientoPuntosDAL.AgregarMovimiento(movimiento);
        }
        public List<MovimientoPuntos> ObtenerMovimientosPorCliente(int idCliente)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "El cliente seleccionado no es válido."
                );
            }

            return movimientoPuntosDAL.ObtenerMovimientosPorCliente(idCliente);
        }
        public int ObtenerSaldoPuntos(int idCliente)
        {
            if (idCliente <= 0)
            {
                throw new ArgumentException(
                    "El cliente seleccionado no es válido."
                );
            }

            return movimientoPuntosDAL.ObtenerSaldoPuntos(idCliente);
        }
    }
}