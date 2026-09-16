using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Custely.DAL;

namespace Custely.BLL
{
    public static class InicializadorSistema
    {
        public static void Inicializar()
        {
            InicializadorBaseDatos.Inicializar();
        }

    }
}
