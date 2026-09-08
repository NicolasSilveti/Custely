namespace SistPuntos_Heladeria.UI
{
    using SistPuntos_Heladeria.BLL;
    using SistPuntos_Heladeria.ENTITY;
    public partial class Form1 : Form
    {
        private readonly ClienteBLL clienteBLL = new ClienteBLL();
        private int? idClienteSeleccionado = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente
                {
                    Dni = txtDni.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text
                };


                clienteBLL.AgregarCliente(cliente);
                CargarClientes();

                MessageBox.Show(
                    "Cliente agregado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtDni.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelefono.Clear();
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


        private void Form1_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = clienteBLL.ObtenerClientes();

            if (dgvClientes.Columns["IdCliente"] != null)
                dgvClientes.Columns["IdCliente"].Visible = false;

            if (dgvClientes.Columns["Activo"] != null)
                dgvClientes.Columns["Activo"].Visible = false;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente? cliente = clienteBLL.BuscarPorDni(txtDni.Text);

                if (cliente == null)
                {
                    idClienteSeleccionado = null;

                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtTelefono.Clear();

                    MessageBox.Show(
                        "No se encontró un cliente con ese DNI.",
                        "Cliente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                idClienteSeleccionado = cliente.IdCliente;

                txtDni.Text = cliente.Dni;
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtTelefono.Text = cliente.Telefono;
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

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (idClienteSeleccionado == null)
                {
                    MessageBox.Show(
                        "Primero debe buscar y seleccionar un cliente.",
                        "Cliente no seleccionado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                Cliente cliente = new Cliente
                {
                    IdCliente = idClienteSeleccionado.Value,
                    Dni = txtDni.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Telefono = txtTelefono.Text
                };

                clienteBLL.ModificarCliente(cliente);

                CargarClientes();

                MessageBox.Show(
                    "Cliente modificado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
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

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (idClienteSeleccionado == null)
                {
                    MessageBox.Show(
                        "Primero debe buscar y seleccionar un cliente.",
                        "Cliente no seleccionado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de que desea dar de baja a este cliente?",
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.No)
                {
                    return;
                }

                clienteBLL.DarDeBajaCliente(idClienteSeleccionado.Value);

                CargarClientes();

                idClienteSeleccionado = null;

                txtDni.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtTelefono.Clear();

                MessageBox.Show(
                    "Cliente dado de baja correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
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
    }
}
