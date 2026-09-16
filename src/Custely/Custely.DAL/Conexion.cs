using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

namespace Custely.DAL
{
    public static class Conexion
    {
        private static string ObtenerRutaBaseDatos()
        {
            DirectoryInfo? carpetaActual =
                new DirectoryInfo(AppContext.BaseDirectory);

            while (carpetaActual != null)
            {
                string carpetaData =
                    Path.Combine(carpetaActual.FullName, "Data");

                string carpetaSrc =
                    Path.Combine(carpetaActual.FullName, "src");

                if (Directory.Exists(carpetaData) &&
                    Directory.Exists(carpetaSrc))
                {
                    return Path.Combine(
                        carpetaData,
                        "Custely.db"
                    );
                }

                carpetaActual = carpetaActual.Parent;
            }

            throw new DirectoryNotFoundException(
                "No se encontró la carpeta raíz del sistema."
            );
        }

        public static SqliteConnection CrearConexion()
        {
            string rutaBaseDatos = ObtenerRutaBaseDatos();

            string cadenaConexion =
                $"Data Source={rutaBaseDatos};Foreign Keys=True";

            return new SqliteConnection(cadenaConexion);
        }
    }
}
