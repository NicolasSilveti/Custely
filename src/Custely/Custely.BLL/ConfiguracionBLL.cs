using Custely.DAL;
using Custely.ENTITY;

namespace Custely.BLL
{
    public class ConfiguracionBLL
    {
        private readonly ConfiguracionDAL configuracionDAL =
            new ConfiguracionDAL();

        public Configuracion ObtenerConfiguracion()
        {
            Configuracion? configuracion =
                configuracionDAL.ObtenerConfiguracion();

            if (configuracion == null)
            {
                throw new InvalidOperationException(
                    "No existe una configuración del sistema."
                );
            }

            return configuracion;
        }

        public void ActualizarPesosPorPunto(decimal pesosPorPunto)
        {
            if (pesosPorPunto <= 0)
            {
                throw new ArgumentException(
                    "El valor de pesos por punto debe ser mayor a cero."
                );
            }

            configuracionDAL.ActualizarPesosPorPunto(
                pesosPorPunto
            );
        }
    }
}