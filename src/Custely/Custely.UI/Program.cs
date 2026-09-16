using Custely.BLL;

namespace Custely.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            InicializadorSistema.Inicializar();

            UsuarioBLL usuarioBLL =
                new UsuarioBLL();

            if (!usuarioBLL.ExistenUsuarios())
            {
                using FrmConfiguracionInicial frmConfiguracionInicial =
                    new FrmConfiguracionInicial();

                DialogResult resultado =
                    frmConfiguracionInicial.ShowDialog();

                if (resultado != DialogResult.OK)
                {
                    return;
                }
            }

            Application.Run(new Form1());
        }
    }
}