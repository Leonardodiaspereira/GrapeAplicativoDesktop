using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GrapeDesktopApp
{
    public partial class FormProdutos : Form
    {
        private int selectedProductId; // Variável para armazenar o ID do produto selecionado

        public FormProdutos()
        {
            InitializeComponent();
        }

        // Método chamado ao carregar o formulário
        private void FormProdutos_Load(object sender, EventArgs e)
        {
            CarregarProdutos(); // Chama o método para carregar os produtos já cadastrados
        }

        // Método para carregar os produtos no DataGridView
        private void CarregarProdutos()
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, nome, valor_por_kg, quantidade_em_estoque FROM produtos";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridProdutos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar produtos: {ex.Message}");
                }
            }
        }

        // Evento ao clicar no botão Salvar Produto
        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {
            string nomeProduto = txtNomeProduto.Text;
            string valorPorKg = txtValorPorKg.Text;
            string quantidadeEstoque = txtQuantidadeEstoque.Text;

            if (string.IsNullOrEmpty(nomeProduto) || string.IsNullOrEmpty(valorPorKg) || string.IsNullOrEmpty(quantidadeEstoque))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            if (!decimal.TryParse(valorPorKg, out decimal valorKg))
            {
                MessageBox.Show("Insira um valor válido para o preço por kg.");
                return;
            }

            if (!int.TryParse(quantidadeEstoque, out int quantidade))
            {
                MessageBox.Show("Insira um valor válido para a quantidade em estoque.");
                return;
            }

            if (selectedProductId == 0)
            {
                // Se nenhum produto foi selecionado, insere um novo produto
                SalvarProduto(nomeProduto, valorKg, quantidade);
            }
            else
            {
                // Se um produto foi selecionado, edita o produto existente
                EditarProduto(selectedProductId, nomeProduto, valorKg, quantidade);
            }
        }

        // Método que salva o produto no banco de dados
        private void SalvarProduto(string nome, decimal valorPorKg, int quantidadeEstoque)
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO produtos (nome, valor_por_kg, quantidade_em_estoque) VALUES (@nome, @valorPorKg, @quantidadeEstoque)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@valorPorKg", valorPorKg);
                    command.Parameters.AddWithValue("@quantidadeEstoque", quantidadeEstoque);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Produto salvo com sucesso!");
                        CarregarProdutos();
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao salvar o produto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar produto: {ex.Message}");
                }
            }
        }

        // Método que atualiza (edita) o produto no banco de dados
        private void EditarProduto(int id, string nome, decimal valorPorKg, int quantidadeEstoque)
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE produtos SET nome = @nome, valor_por_kg = @valorPorKg, quantidade_em_estoque = @quantidadeEstoque WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nome", nome);
                    command.Parameters.AddWithValue("@valorPorKg", valorPorKg);
                    command.Parameters.AddWithValue("@quantidadeEstoque", quantidadeEstoque);
                    command.Parameters.AddWithValue("@id", id);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Produto atualizado com sucesso!");
                        CarregarProdutos();
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar o produto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar produto: {ex.Message}");
                }
            }
        }

        // Evento ao clicar no botão Editar Produto
        private void btnEditarProduto_Click(object sender, EventArgs e)
        {
            if (dataGridProdutos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridProdutos.SelectedRows[0];
                selectedProductId = Convert.ToInt32(row.Cells["id"].Value);
                txtNomeProduto.Text = row.Cells["nome"].Value.ToString();
                txtValorPorKg.Text = row.Cells["valor_por_kg"].Value.ToString();
                txtQuantidadeEstoque.Text = row.Cells["quantidade_em_estoque"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um produto para editar.");
            }
        }

        // Evento ao clicar no botão Excluir Produto
        private void btnExcluirProduto_Click(object sender, EventArgs e)
        {
            if (dataGridProdutos.SelectedRows.Count > 0)
            {
                int produtoId = Convert.ToInt32(dataGridProdutos.SelectedRows[0].Cells["id"].Value);

                DialogResult result = MessageBox.Show("Tem certeza que deseja excluir este produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ExcluirProduto(produtoId);
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para excluir.");
            }
        }

        // Método para excluir o produto do banco de dados
        private void ExcluirProduto(int produtoId)
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM produtos WHERE id = @produtoId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@produtoId", produtoId);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Produto excluído com sucesso!");
                        CarregarProdutos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir o produto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir produto: {ex.Message}");
                }
            }
        }

        // Método para limpar os campos após salvar ou editar
        private void LimparCampos()
        {
            txtNomeProduto.Clear();
            txtValorPorKg.Clear();
            txtQuantidadeEstoque.Clear();
            selectedProductId = 0;
        }
    }
}
