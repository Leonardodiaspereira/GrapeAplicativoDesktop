using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GrapeDesktopApp
{
    public partial class FormFuncionarios : Form
    {
        private int selectedFuncionarioId; // Variável para armazenar o ID do funcionário selecionado
        private bool isAdmin; // Variável para armazenar se o usuário é administrador

        // Construtor para receber a informação se o usuário é administrador
        public FormFuncionarios(bool usuarioEhAdministrador)
        {
            InitializeComponent();
            isAdmin = usuarioEhAdministrador; // Define se o usuário logado é administrador
        }

        // Método chamado ao carregar o formulário
        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
            // Se o usuário não for administrador desativa as funcionalidades de gerenciamento
            if (!isAdmin)
            {
                MessageBox.Show("Você não tem permissão para acessar esta área.");
                this.Close(); // Fecha o formulário caso o usuário não tenha permissão
                return;
            }

            CarregarFuncionarios(); // Carrega os funcionários ao iniciar o formulário
        }

        // Método para carregar os funcionários no DataGridView
        private void CarregarFuncionarios()
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, nome, cpf, email_corporativo FROM funcionarios";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridFuncionarios.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar funcionários: {ex.Message}");
                }
            }
        }

        // Evento ao clicar no botão "Adicionar Funcionário"
        private void btnAdicionarFuncionario_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("Você não tem permissão para adicionar funcionários.");
                return;
            }

            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            if (selectedFuncionarioId == 0)
            {
                SalvarFuncionario(nome, cpf, email, senha);
            }
            else
            {
                EditarFuncionario(selectedFuncionarioId, nome, cpf, email, senha);
            }
        }

        // Método para salvar o funcionário no banco de dados
        private void SalvarFuncionario(string nome, string cpf, string email, string senha)
        {
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
                    if (result > 0)
                    {
                        MessageBox.Show("Funcionário salvo com sucesso!");
                        CarregarFuncionarios(); // Atualiza a lista de funcionários
                    }
                    else
                    {
                        MessageBox.Show("Erro ao salvar o funcionário.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar funcionário: {ex.Message}");
                }
            }
        }

        // Método para editar o funcionário
        private void EditarFuncionario(int id, string nome, string cpf, string email, string senha)
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE funcionarios SET nome = @nome, cpf = @cpf, email_corporativo = @EmailCorporativo, senha = @senha WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@cpf", cpf);
                    command.Parameters.AddWithValue("@EmailCorporativo", email);
                    command.Parameters.AddWithValue("@senha", senha);
                    command.Parameters.AddWithValue("@id", id);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Funcionário atualizado com sucesso!");
                        CarregarFuncionarios(); // Atualiza a lista de funcionários
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar o funcionário.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar funcionário: {ex.Message}");
                }
            }
        }

        // Evento ao clicar no botão "Editar Funcionário"
        private void btnEditarFuncionario_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("Você não tem permissão para editar funcionários.");
                return;
            }

            if (dataGridFuncionarios.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridFuncionarios.SelectedRows[0];
                selectedFuncionarioId = Convert.ToInt32(row.Cells["id"].Value);
                txtNome.Text = row.Cells["nome"].Value.ToString();
                txtCPF.Text = row.Cells["cpf"].Value.ToString();
                txtEmail.Text = row.Cells["email_corporativo"].Value.ToString();
                // Senha não é exibida por motivos de segurança
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para editar.");
            }
        }

        // Evento ao clicar no botão "Excluir Funcionário"
        private void btnExcluirFuncionario_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("Você não tem permissão para excluir funcionários.");
                return;
            }

            if (dataGridFuncionarios.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridFuncionarios.SelectedRows[0];
                int funcionarioId = Convert.ToInt32(row.Cells["id"].Value);

                ExcluirFuncionario(funcionarioId);
            }
            else
            {
                MessageBox.Show("Selecione um funcionário para excluir.");
            }
        }

        // Método para excluir o funcionário
        private void ExcluirFuncionario(int id)
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM funcionarios WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Funcionário excluído com sucesso!");
                        CarregarFuncionarios();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o funcionário.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir funcionário: {ex.Message}");
                }
            }
        }
    }
}
