using SistPuntos_Heladeria.DAL;
using SistPuntos_Heladeria.ENTITY;

namespace SistPuntos_Heladeria.BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL usuarioDAL =
            new UsuarioDAL();

        public void AgregarUsuario(
            string nombre,
            string apellido,
            string nombreUsuario,
            string clave,
            string rol
        )
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException(
                    "El nombre no puede estar vacío."
                );

            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException(
                    "El apellido no puede estar vacío."
                );

            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException(
                    "El nombre de usuario no puede estar vacío."
                );

            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException(
                    "La clave no puede estar vacía."
                );

            if (rol != RolesUsuario.Admin &&
                rol != RolesUsuario.Empleado)
            {
                throw new ArgumentException(
                    "El rol seleccionado no es válido."
                );
            }

            Usuario usuario = new Usuario
            {
                Nombre = nombre.Trim(),
                Apellido = apellido.Trim(),
                NombreUsuario = nombreUsuario.Trim(),
                ClaveHash = SeguridadClave.CrearHash(clave),
                Rol = rol,
                Activo = true
            };

            usuarioDAL.AgregarUsuario(usuario);
        }

        public Usuario? ValidarUsuario(
            string nombreUsuario,
            string clave
        )
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(clave))
            {
                return null;
            }

            Usuario? usuario =
                usuarioDAL.BuscarPorNombreUsuario(
                    nombreUsuario.Trim()
                );

            if (usuario == null)
            {
                return null;
            }

            bool claveCorrecta =
                SeguridadClave.VerificarClave(
                    clave,
                    usuario.ClaveHash
                );

            if (!claveCorrecta)
            {
                return null;
            }

            return usuario;
        }

        public List<Usuario> ObtenerUsuariosActivos()
        {
            return usuarioDAL.ObtenerUsuariosActivos();
        }
        public bool ExistenUsuarios()
        {
            return usuarioDAL.ExistenUsuarios();
        }
        public void RestablecerClave(
    int idUsuario,
    string nuevaClave
)
        {
            if (idUsuario <= 0)
            {
                throw new ArgumentException(
                    "El usuario no es válido."
                );
            }

            if (string.IsNullOrWhiteSpace(nuevaClave))
            {
                throw new ArgumentException(
                    "La nueva clave no puede estar vacía."
                );
            }

            string nuevaClaveHash =
                SeguridadClave.CrearHash(nuevaClave);

            usuarioDAL.ActualizarClave(
                idUsuario,
                nuevaClaveHash
            );
        }
    }
}