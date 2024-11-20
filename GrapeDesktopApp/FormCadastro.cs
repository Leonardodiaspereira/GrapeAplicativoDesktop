using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GrapeDesktopApp
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
        {
            InitializeComponent();
        }

        // Método chamado quando o botão Criar Conta é clicado
        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            // Verifica se todos os campos foram preenchidos
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            // Salva os dados no banco de dados
            if (SalvarUsuario(nome, cpf, email, senha))
            {
                MessageBox.Show("Conta criada com sucesso!");
                this.Close(); // Fecha a tela de criação de conta
            }
            else
            {
                MessageBox.Show("Erro ao criar conta.");
            }
        }

        // Método que salva os dados do usuário no banco de dados
        private bool SalvarUsuario(string nome, string cpf, string email, string senha)
        {
            // String de conexão 
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO funcionarios (nome, cpf, email_corporativo, senha) VALUES (@nome, @cpf, @EmailCorporativo, @senha)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@cpf", cpf);
                    command.Parameters.AddWithValue("@EmailCorporativo", email);
                    command.Parameters.AddWithValue("@senha", senha);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar o usuário: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
