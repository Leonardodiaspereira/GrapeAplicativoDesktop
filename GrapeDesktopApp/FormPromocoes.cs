using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Configuration;

namespace GrapeDesktopApp
{
    public partial class FormPromocoes : Form
    {
        public FormPromocoes()
        {
            InitializeComponent();
        }

        private void FormPromocoes_Load(object sender, EventArgs e)
        {
            CarregarEmails();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void CarregarEmails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GrapeDesktopApp.Properties.Settings.grape_fazendaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Conexão com o banco de dados estabelecida com sucesso.", "Conexão Bem-Sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string query = "SELECT email FROM dbo.promocoes";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dtEmails = new DataTable();
                    adapter.Fill(dtEmails);

                    if (dtEmails.Rows.Count > 0)
                    {
                        string emailLog = string.Join(", ", dtEmails.AsEnumerable().Select(r => r["email"].ToString()));
                        MessageBox.Show($"E-mails encontrados: {emailLog}", "E-mails Carregados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Adiciona uma coluna de checkbox para selecionar os e-mails
                        dataGridEmails.Columns.Clear();
                        dataGridEmails.DataSource = dtEmails;

                        // Adiciona coluna de checkbox para seleção
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                        {
                            Name = "SelectEmail",
                            HeaderText = "Selecionar",
                            Width = 60
                        };
                        dataGridEmails.Columns.Insert(0, checkBoxColumn);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum e-mail encontrado na tabela de promoções.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"Erro no banco de dados: {sqlEx.Message}\nCódigo do erro: {sqlEx.Number}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar e-mails: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEnviarNewsletter_Click(object sender, EventArgs e)
        {
            try
            {
                string assunto = txtAssunto.Text;
                string corpoEmail = txtTextoPromocao.Text;

                if (string.IsNullOrEmpty(assunto) || string.IsNullOrEmpty(corpoEmail))
                {
                    MessageBox.Show("Preencha todos os campos.");
                    return;
                }

                if (dataGridEmails.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum e-mail encontrado na lista. Por favor, cadastre e-mails.");
                    return;
                }

                // Configurações SMTP para o Gmail
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)  // Usar a porta 587 para TLS
                {
                    Credentials = new NetworkCredential("grapepimunip@gmail.com", "epanzxqmnodexvsf"), // Seu e-mail e senha de aplicativo do Gmail
                    EnableSsl = true,  // Habilitar SSL para uma conexão segura
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 30000  // Definir o timeout para 30 segundos
                };

                // Criar a mensagem de e-mail
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("grapepimunip@gmail.com"),  // O seu e-mail
                    Subject = assunto,
                    Body = corpoEmail,
                    IsBodyHtml = false  // Define que o corpo do e-mail é texto simples
                };

                bool destinatarioEncontrado = false;

                // Percorrer todas as linhas do DataGridView e enviar somente para os e-mails selecionados
                foreach (DataGridViewRow row in dataGridEmails.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["SelectEmail"].Value); // Verifica se o checkbox está marcado
                    if (isSelected)
                    {
                        var email = row.Cells["email"].Value?.ToString(); // Obtém o e-mail da coluna "email"
                        if (!string.IsNullOrWhiteSpace(email) && IsValidEmail(email))
                        {
                            mail.To.Add(new MailAddress(email));
                            destinatarioEncontrado = true;
                        }
                    }
                }

                if (!destinatarioEncontrado)
                {
                    MessageBox.Show("Nenhum e-mail válido foi selecionado.");
                    return;
                }

                // Enviar o e-mail
                client.Send(mail);
                MessageBox.Show("Newsletter enviada com sucesso!");
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show($"Erro SMTP ao enviar e-mail: {smtpEx.Message}\n{smtpEx.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar e-mail: {ex.Message}\n{ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridEmails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
