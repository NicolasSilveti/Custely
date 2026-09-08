using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistPuntos_Heladeria.DAL;

namespace SistPuntos_Heladeria.BLL
{
    public static class InicializadorSistema
    {
        public static void Inicializar()
        {
            InicializadorBaseDatos.Inicializar();
        }

    }
}
