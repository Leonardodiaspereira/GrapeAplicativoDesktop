using System;
using System.Windows.Forms;

namespace GrapeDesktopApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Primeira tela de login
                FormLogin formLogin = new FormLogin();
                Application.Run(formLogin);  // FormLogin será o ponto de entrada principal.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
