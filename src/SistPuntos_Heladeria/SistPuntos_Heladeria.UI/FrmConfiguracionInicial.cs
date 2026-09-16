using SistPuntos_Heladeria.BLL;
using SistPuntos_Heladeria.ENTITY;

namespace SistPuntos_Heladeria.UI
{
    public partial class FrmConfiguracionInicial : Form
    {
        private readonly UsuarioBLL usuarioBLL =
            new UsuarioBLL();

        public FrmConfiguracionInicial()
        {
            InitializeComponent();
        }

        private void btnCrearAdministrador_Click(
            object? sender,
            EventArgs e
        )
        {
            try
            {
                if (txtClave.Text != txtRepetirClave.Text)
                {
                    MessageBox.Show(
                        "Las claves no coinciden.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                usuarioBLL.AgregarUsuario(
                    txtNombre.Text,
                    txtApellido.Text,
                    txtNombreUsuario.Text,
                    txtClave.Text,
                    RolesUsuario.Admin
                );

                MessageBox.Show(
                    "Administrador creado correctamente.",
                    "Configuración inicial",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

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

        private void FrmConfiguracionInicial_Load(object sender, EventArgs e)
        {

        }
    }
}