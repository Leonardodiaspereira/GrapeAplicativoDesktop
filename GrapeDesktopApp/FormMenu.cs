using System;
using System.Windows.Forms;

namespace GrapeDesktopApp
{
    public partial class FormMenu : Form
    {
        private bool isAdmin; // Variável para armazenar se o usuário é administrador

        public FormMenu(bool usuarioEhAdministrador)
        {
            InitializeComponent();
            isAdmin = usuarioEhAdministrador; // Define se o usuário logado é administrador
        }

        // Método chamado ao carregar o formulário
        private void FormMenu_Load(object sender, EventArgs e)
        {
            // Se o usuário não for administrador, o botão "Gerenciar Funcionários" não será exibido
            if (!isAdmin)
            {
                btnGerenciarFuncionarios.Visible = false;
            }
        }

        // Evento para Gerenciamento de Produtos
        private void btnGerenciarProdutos_Click(object sender, EventArgs e)
        {
            FormProdutos formProdutos = new FormProdutos();
            formProdutos.ShowDialog(); // Abre a tela de gerenciamento de produtos
        }

        // Evento para Gerenciamento de Funcionários
        private void btnGerenciarFuncionarios_Click(object sender, EventArgs e)
        {
            FormFuncionarios formFuncionarios = new FormFuncionarios(isAdmin); // Passa a informação se é administrador
            formFuncionarios.ShowDialog(); // Abre a tela de gerenciamento de funcionários
        }

        // Evento para Gerenciamento de Pedidos
        private void btnGerenciarPedidos_Click(object sender, EventArgs e)
        {
            FormPedidos formPedidos = new FormPedidos();
            formPedidos.ShowDialog(); // Abre a tela de gerenciamento de pedidos
        }

        // Evento para Promoções
        private void btnPromocoes_Click(object sender, EventArgs e)
        {
            FormPromocoes formPromocoes = new FormPromocoes();
            formPromocoes.ShowDialog(); // Abre a tela de promoções
        }

        // Evento para o botão Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Fecha o aplicativo
        }
    }
}
