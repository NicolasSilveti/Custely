using Custely.BLL;
using Custely.ENTITY;

namespace Custely.UI
{
    public partial class FrmAutorizacion : Form
    {
        private readonly UsuarioBLL usuarioBLL =
            new UsuarioBLL();

        public Usuario? UsuarioAutorizado { get; private set; }

        public FrmAutorizacion()
        {
            InitializeComponent();
        }

        private void btnAutorizar_Click(object? sender, EventArgs e)
        {
            try
            {
                Usuario? usuario = usuarioBLL.ValidarUsuario(
                    txtNombreUsuario.Text,
                    txtClave.Text
                );

                if (usuario == null)
                {
                    MessageBox.Show(
                        "Usuario o clave incorrectos.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (usuario.Rol != RolesUsuario.Admin)
                {
                    MessageBox.Show(
                        "Esta acción requiere permisos de administrador.",
                        "Acceso denegado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                UsuarioAutorizado = usuario;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmAutorizacion_Load(object sender, EventArgs e)
        {

        }
    }
}