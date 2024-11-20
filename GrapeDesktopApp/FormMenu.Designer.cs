namespace GrapeDesktopApp
{
    partial class FormMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnGerenciarProdutos = new System.Windows.Forms.Button();
            this.btnGerenciarFuncionarios = new System.Windows.Forms.Button();
            this.btnGerenciarPedidos = new System.Windows.Forms.Button();
            this.btnPromocoes = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGerenciarProdutos
            // 
            this.btnGerenciarProdutos.Location = new System.Drawing.Point(100, 50);
            this.btnGerenciarProdutos.Name = "btnGerenciarProdutos";
            this.btnGerenciarProdutos.Size = new System.Drawing.Size(250, 40);
            this.btnGerenciarProdutos.TabIndex = 0;
            this.btnGerenciarProdutos.Text = "Gerenciamento de Produtos";
            this.btnGerenciarProdutos.UseVisualStyleBackColor = true;
            this.btnGerenciarProdutos.Click += new System.EventHandler(this.btnGerenciarProdutos_Click);
            // 
            // btnGerenciarFuncionarios
            // 
            this.btnGerenciarFuncionarios.Location = new System.Drawing.Point(100, 110);
            this.btnGerenciarFuncionarios.Name = "btnGerenciarFuncionarios";
            this.btnGerenciarFuncionarios.Size = new System.Drawing.Size(250, 40);
            this.btnGerenciarFuncionarios.TabIndex = 1;
            this.btnGerenciarFuncionarios.Text = "Gerenciamento de Funcionários";
            this.btnGerenciarFuncionarios.UseVisualStyleBackColor = true;
            this.btnGerenciarFuncionarios.Click += new System.EventHandler(this.btnGerenciarFuncionarios_Click);
            // 
            // btnGerenciarPedidos
            // 
            this.btnGerenciarPedidos.Location = new System.Drawing.Point(100, 170);
            this.btnGerenciarPedidos.Name = "btnGerenciarPedidos";
            this.btnGerenciarPedidos.Size = new System.Drawing.Size(250, 40);
            this.btnGerenciarPedidos.TabIndex = 2;
            this.btnGerenciarPedidos.Text = "Gerenciamento de Pedidos";
            this.btnGerenciarPedidos.UseVisualStyleBackColor = true;
            this.btnGerenciarPedidos.Click += new System.EventHandler(this.btnGerenciarPedidos_Click);
            // 
            // btnPromocoes
            // 
            this.btnPromocoes.Location = new System.Drawing.Point(100, 230);
            this.btnPromocoes.Name = "btnPromocoes";
            this.btnPromocoes.Size = new System.Drawing.Size(250, 40);
            this.btnPromocoes.TabIndex = 3;
            this.btnPromocoes.Text = "Promoções";
            this.btnPromocoes.UseVisualStyleBackColor = true;
            this.btnPromocoes.Click += new System.EventHandler(this.btnPromocoes_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(450, 330);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(100, 30);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // FormMenu
            // 
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnPromocoes);
            this.Controls.Add(this.btnGerenciarPedidos);
            this.Controls.Add(this.btnGerenciarFuncionarios);
            this.Controls.Add(this.btnGerenciarProdutos);
            this.Name = "FormMenu";
            this.Text = "Menu Principal";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnGerenciarProdutos;
        private System.Windows.Forms.Button btnGerenciarFuncionarios;
        private System.Windows.Forms.Button btnGerenciarPedidos;
        private System.Windows.Forms.Button btnPromocoes;
        private System.Windows.Forms.Button btnSair;
    }
}
