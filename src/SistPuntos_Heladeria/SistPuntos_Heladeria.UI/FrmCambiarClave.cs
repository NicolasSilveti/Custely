using SistPuntos_Heladeria.BLL;
using SistPuntos_Heladeria.ENTITY;

namespace SistPuntos_Heladeria.UI
{
    public partial class FrmCambiarClave : Form
    {
        private readonly UsuarioBLL usuarioBLL =
            new UsuarioBLL();

        private readonly Usuario usuario;

        public FrmCambiarClave(Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;
        }

        private void btnCambiarClave_Click(object? sender, EventArgs e)
        {
            try
            {
                if (txtNuevaClave.Text != txtRepetirClave.Text)
                {
                    MessageBox.Show(
                        "Las claves no coinciden.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                usuarioBLL.RestablecerClave(
                    usuario.IdUsuario,
                    txtNuevaClave.Text
                );

                MessageBox.Show(
                    "La clave fue cambiada correctamente.",
                    "Éxito",
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

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}