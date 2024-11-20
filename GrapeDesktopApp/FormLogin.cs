using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GrapeDesktopApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        // Método chamado ao carregar o formulário
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Criando o label para exibir a mensagem de boas-vindas
            Label lblBemVindo = new Label();
            lblBemVindo.Text = "Bem-vindo ao Grape Desktop - Gerenciamento";
            lblBemVindo.Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold);
            lblBemVindo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#800080"); // Cor roxa
            lblBemVindo.AutoSize = true;
            lblBemVindo.Location = new System.Drawing.Point(50, 20); // Define a localização no formulário (ajuste conforme necessário)

            // Adicionando o label ao formulário
            this.Controls.Add(lblBemVindo);
        }

        // Método chamado quando o botão Login é clicado
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            // Verifica se os campos de usuário e senha foram preenchidos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha os campos de usuário e senha.");
                return;
            }

            // Verifica se o login é válido e obtém se o usuário é administrador
            bool isAdmin;
            if (VerificarLogin(usuario, senha, out isAdmin))
            {
                MessageBox.Show("Login bem-sucedido!");

                // Esconde a tela de login
                this.Hide();

                // Redireciona para o menu principal
                FormMenu formMenu = new FormMenu(isAdmin);
                formMenu.ShowDialog();

                // Após fechar o menu, a tela de login será fechada
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.");
            }
        }

        // Método que verifica o login no banco de dados e verifica se é administrador
        private bool VerificarLogin(string usuario, string senha, out bool isAdmin)
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123";
            isAdmin = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT is_admin FROM funcionarios WHERE email_corporativo = @usuario AND senha = @senha";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@senha", senha);

                    object result = command.ExecuteScalar();

                    // Se o resultado não for nulo, significa que as credenciais são válidas
                    if (result != null)
                    {
                        isAdmin = Convert.ToBoolean(result);
                        return true;
                    }

                    // Caso contrário, retorna false
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao verificar login: {ex.Message}");
                    return false;
                }
            }
        }

        // Evento chamado quando o usuário clica no botão "Criar Conta"
        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            // Abre a tela de cadastro de forma modal
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.ShowDialog();
        }
    }
}
