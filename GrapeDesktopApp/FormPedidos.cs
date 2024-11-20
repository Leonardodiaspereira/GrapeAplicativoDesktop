using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GrapeDesktopApp
{
    public partial class FormPedidos : Form
    {
        public FormPedidos()
        {
            InitializeComponent();
        }

        // Método chamado ao carregar o formulário
        // Método chamado ao carregar o formulário
        private void FormPedidos_Load(object sender, EventArgs e)
        {
            // Adiciona os status ao comboStatus
            comboStatus.Items.Add("Preparando Pedido");


            CarregarPedidos();
        }


        // Método para carregar os pedidos no DataGridView
        private void CarregarPedidos()
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, cliente_id, valor_total, forma_pagamento, nome_completo, rua, numero, cidade, estado, cep, status, data_pedido FROM pedidos";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridPedidos.DataSource = dt;
                    CalcularValorTotal(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar pedidos: {ex.Message}");
                }
            }
        }

        // Método para calcular o valor total dos pedidos
        private void CalcularValorTotal(DataTable dt)
        {
            decimal valorTotal = 0;
            foreach (DataRow row in dt.Rows)
            {
                valorTotal += Convert.ToDecimal(row["valor_total"]);
            }
            lblValorTotal.Text = $"Valor Total: R$ {valorTotal}";
        }

        // Evento para atualizar o status do pedido
        private void btnAtualizarStatus_Click(object sender, EventArgs e)
        {
            if (dataGridPedidos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridPedidos.SelectedRows[0];
                int pedidoId = Convert.ToInt32(row.Cells["id"].Value);
                string novoStatus = comboStatus.SelectedItem.ToString();

                AtualizarStatusPedido(pedidoId, novoStatus);
            }
            else
            {
                MessageBox.Show("Selecione um pedido para atualizar o status.");
            }
        }

        // Método para atualizar o status do pedido no banco de dados
        private void AtualizarStatusPedido(int id, string status)
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE pedidos SET status = @status WHERE id = @id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@id", id);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Status atualizado com sucesso!");
                        CarregarPedidos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao atualizar o status.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar status: {ex.Message}");
                }
            }
        }

        // Evento para filtrar pedidos por data
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarPedidosPorData(dateTimePickerFiltro.Value);
        }

        // Método para filtrar pedidos por data
        private void FiltrarPedidosPorData(DateTime data)
        {
            string connectionString = "Data Source=NOTE-LEONARDO\\SQLEXPRESS;Initial Catalog=grape_fazenda;User ID=grape_user;Password=SenhaForte123;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id, cliente_id, valor_total, endereco_entrega, status FROM pedidos WHERE CONVERT(DATE, data_pedido) = @data";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@data", data);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridPedidos.DataSource = dt;
                    CalcularValorTotal(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao filtrar pedidos: {ex.Message}");
                }
            }
        }
    }
}
