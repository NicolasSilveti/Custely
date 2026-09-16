using System.Security.Cryptography;

namespace SistPuntos_Heladeria.BLL
{
    public static class SeguridadClave
    {
        private const int Iteraciones = 600000;
        private const int TamanoSalt = 16;
        private const int TamanoHash = 32;

        public static string CrearHash(string clave)
        {
            if (string.IsNullOrWhiteSpace(clave))
            {
                throw new ArgumentException(
                    "La clave no puede estar vacía."
                );
            }

            byte[] salt =
                RandomNumberGenerator.GetBytes(TamanoSalt);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                clave,
                salt,
                Iteraciones,
                HashAlgorithmName.SHA256,
                TamanoHash
            );

            return $"{Iteraciones}." +
                   $"{Convert.ToBase64String(salt)}." +
                   $"{Convert.ToBase64String(hash)}";
        }

        public static bool VerificarClave(
            string clave,
            string hashGuardado
        )
        {
            if (string.IsNullOrWhiteSpace(clave) ||
                string.IsNullOrWhiteSpace(hashGuardado))
            {
                return false;
            }

            string[] partes = hashGuardado.Split('.');

            if (partes.Length != 3)
            {
                return false;
            }

            if (!int.TryParse(partes[0], out int iteraciones))
            {
                return false;
            }

            try
            {
                byte[] salt =
                    Convert.FromBase64String(partes[1]);

                byte[] hashOriginal =
                    Convert.FromBase64String(partes[2]);

                byte[] hashIngresado =
                    Rfc2898DeriveBytes.Pbkdf2(
                        clave,
                        salt,
                        iteraciones,
                        HashAlgorithmName.SHA256,
                        hashOriginal.Length
                    );

                return CryptographicOperations.FixedTimeEquals(
                    hashOriginal,
                    hashIngresado
                );
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}