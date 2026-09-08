using SistPuntos_Heladeria.BLL;

namespace SistPuntos_Heladeria.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            InicializadorSistema.Inicializar();

            Application.Run(new Form1());
        }
    }
}