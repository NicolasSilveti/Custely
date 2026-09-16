using SistPuntos_Heladeria.BLL;
using SistPuntos_Heladeria.ENTITY;

namespace SistPuntos_Heladeria.UI
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioBLL usuarioBLL =
            new UsuarioBLL();

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            cmbRol.Items.Clear();
            cmbRol.Items.Add(RolesUsuario.Admin);
            cmbRol.Items.Add(RolesUsuario.Empleado);

            cmbRol.SelectedIndex = 1;

            CargarUsuarios();
        }

        private void btnAgregarUsuario_Click(
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

                if (cmbRol.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Seleccione un rol.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string rol =
                    cmbRol.SelectedItem.ToString()!;

                usuarioBLL.AgregarUsuario(
                    txtNombre.Text,
                    txtApellido.Text,
                    txtNombreUsuario.Text,
                    txtClave.Text,
                    rol
                );

                MessageBox.Show(
                    "Usuario creado correctamente.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarCampos();
                CargarUsuarios();
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

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource =
                usuarioBLL.ObtenerUsuariosActivos();

            if (dgvUsuarios.Columns["IdUsuario"] != null)
                dgvUsuarios.Columns["IdUsuario"].Visible = false;

            if (dgvUsuarios.Columns["ClaveHash"] != null)
                dgvUsuarios.Columns["ClaveHash"].Visible = false;

            if (dgvUsuarios.Columns["Activo"] != null)
                dgvUsuarios.Columns["Activo"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNombreUsuario.Clear();
            txtClave.Clear();
            txtRepetirClave.Clear();

            cmbRol.SelectedIndex = 1;
        }
    }
}