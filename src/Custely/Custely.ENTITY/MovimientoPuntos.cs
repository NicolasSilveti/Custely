using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custely.ENTITY
{
    public class MovimientoPuntos
    {
        public int IdMovimiento { get; set; }

        public int IdCliente { get; set; }

        public DateTime Fecha { get; set; }

        public string Tipo { get; set; } = string.Empty;

        public int Puntos { get; set; }

        public decimal Monto { get; set; }

        public string Descripcion { get; set; } = string.Empty;
    }
}
