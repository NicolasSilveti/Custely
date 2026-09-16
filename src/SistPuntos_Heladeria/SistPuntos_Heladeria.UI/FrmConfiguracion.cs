using SistPuntos_Heladeria.BLL;
using SistPuntos_Heladeria.ENTITY;

namespace SistPuntos_Heladeria.UI
{
    public partial class FrmConfiguracion : Form
    {
        private readonly ConfiguracionBLL configuracionBLL =
            new ConfiguracionBLL();

        public FrmConfiguracion()
        {
            InitializeComponent();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                Configuracion configuracion =
                    configuracionBLL.ObtenerConfiguracion();

                txtPesosPorPunto.Text =
                    configuracion.PesosPorPunto.ToString("0.00");
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

        private void btnGuardarConfiguracion_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(
                    txtPesosPorPunto.Text,
                    out decimal pesosPorPunto
                ))
                {
                    MessageBox.Show(
                        "Ingrese un valor válido.",
                        "Valor inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de cambiar la configuración a ${pesosPorPunto:0.00} por punto?",
                    "Confirmar configuración",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.No)
                {
                    return;
                }

                configuracionBLL.ActualizarPesosPorPunto(
                    pesosPorPunto
                );

                MessageBox.Show(
                    "Configuración actualizada correctamente.",
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

        private void btnAutorizar_Click(object sender, EventArgs e)
        {

        }
    }
}