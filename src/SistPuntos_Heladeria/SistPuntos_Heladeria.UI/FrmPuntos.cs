using SistPuntos_Heladeria.BLL;
using SistPuntos_Heladeria.ENTITY;

namespace SistPuntos_Heladeria.UI
{
    public partial class FrmPuntos : Form
    {
        private readonly ClienteBLL clienteBLL = new ClienteBLL();

        private readonly MovimientoPuntosBLL movimientoPuntosBLL =
            new MovimientoPuntosBLL();

        private int? idClienteSeleccionado = null;

        public FrmPuntos()
        {
            InitializeComponent();

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente? cliente =
                    clienteBLL.BuscarPorDni(txtDni.Text);

                if (cliente == null)
                {
                    idClienteSeleccionado = null;

                    lblCliente.Text = "Cliente: -";
                    lblPuntosActuales.Text =
                        "Puntos actuales: 0";

                    MessageBox.Show(
                        "No se encontró un cliente con ese DNI.",
                        "Cliente no encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }

                idClienteSeleccionado = cliente.IdCliente;

                lblCliente.Text =
                    $"Cliente: {cliente.Nombre} {cliente.Apellido}";

                int puntosActuales =
                    movimientoPuntosBLL.ObtenerSaldoPuntos(
                        cliente.IdCliente
                    );

                lblPuntosActuales.Text =
                    $"Puntos actuales: {puntosActuales}";
                CargarMovimientos();
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

        private void btnRegistrarCompra_Click(object sender, EventArgs e)
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

                if (!decimal.TryParse(
                    txtMontoCompra.Text,
                    out decimal monto
                ))
                {
                    MessageBox.Show(
                        "Ingrese un monto válido.",
                        "Monto inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                movimientoPuntosBLL.RegistrarCompra(
                    idClienteSeleccionado.Value,
                    monto
                );

                int puntosActuales =
                    movimientoPuntosBLL.ObtenerSaldoPuntos(
                        idClienteSeleccionado.Value
                    );

                lblPuntosActuales.Text =
                    $"Puntos actuales: {puntosActuales}";

                CargarMovimientos();

                txtMontoCompra.Clear();

                dgvMovimientos.DataSource = null;

                MessageBox.Show(
                    "Compra registrada correctamente.",
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
        private void FrmPuntos_Load(object sender, EventArgs e)
        {
        }
        private void CargarMovimientos()
        {
            if (idClienteSeleccionado == null)
            {
                dgvMovimientos.DataSource = null;
                return;
            }

            dgvMovimientos.DataSource = null;

            dgvMovimientos.DataSource =
                movimientoPuntosBLL.ObtenerMovimientosPorCliente(
                    idClienteSeleccionado.Value
                );
        }

        private void btnCanjearPuntos_Click(object sender, EventArgs e)
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

                if (!int.TryParse(
                    txtPuntosCanje.Text,
                    out int puntosACanjear
                ))
                {
                    MessageBox.Show(
                        "Ingrese una cantidad de puntos válida.",
                        "Cantidad inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
                DialogResult respuesta = MessageBox.Show(
                $"¿Está seguro de que desea canjear {puntosACanjear} puntos?",
                "Confirmar canje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.No)
                {
                    return;
                }
                movimientoPuntosBLL.RegistrarCanje(
                    idClienteSeleccionado.Value,
                    puntosACanjear
                );

                int puntosActuales =
                    movimientoPuntosBLL.ObtenerSaldoPuntos(
                        idClienteSeleccionado.Value
                    );

                lblPuntosActuales.Text =
                    $"Puntos actuales: {puntosActuales}";

                CargarMovimientos();

                txtPuntosCanje.Clear();

                MessageBox.Show(
                    "Canje registrado correctamente.",
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