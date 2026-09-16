using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custely.ENTITY
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Dni { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}
