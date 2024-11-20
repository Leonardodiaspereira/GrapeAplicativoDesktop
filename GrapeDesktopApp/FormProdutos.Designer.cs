namespace GrapeDesktopApp
{
    partial class FormProdutos
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
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.txtValorPorKg = new System.Windows.Forms.TextBox();
            this.txtQuantidadeEstoque = new System.Windows.Forms.TextBox();
            this.btnSalvarProduto = new System.Windows.Forms.Button();
            this.btnEditarProduto = new System.Windows.Forms.Button();
            this.btnExcluirProduto = new System.Windows.Forms.Button();
            this.dataGridProdutos = new System.Windows.Forms.DataGridView();
            this.labelNomeProduto = new System.Windows.Forms.Label();
            this.labelValorPorKg = new System.Windows.Forms.Label();
            this.labelQuantidadeEstoque = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(362, 18);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(200, 22);
            this.txtNomeProduto.TabIndex = 0;
            // 
            // txtValorPorKg
            // 
            this.txtValorPorKg.Location = new System.Drawing.Point(362, 58);
            this.txtValorPorKg.Name = "txtValorPorKg";
            this.txtValorPorKg.Size = new System.Drawing.Size(200, 22);
            this.txtValorPorKg.TabIndex = 1;
            // 
            // txtQuantidadeEstoque
            // 
            this.txtQuantidadeEstoque.Location = new System.Drawing.Point(362, 98);
            this.txtQuantidadeEstoque.Name = "txtQuantidadeEstoque";
            this.txtQuantidadeEstoque.Size = new System.Drawing.Size(200, 22);
            this.txtQuantidadeEstoque.TabIndex = 2;
            // 
            // btnSalvarProduto
            // 
            this.btnSalvarProduto.Location = new System.Drawing.Point(362, 138);
            this.btnSalvarProduto.Name = "btnSalvarProduto";
            this.btnSalvarProduto.Size = new System.Drawing.Size(200, 30);
            this.btnSalvarProduto.TabIndex = 3;
            this.btnSalvarProduto.Text = "Salvar Produto";
            this.btnSalvarProduto.UseVisualStyleBackColor = true;
            this.btnSalvarProduto.Click += new System.EventHandler(this.btnSalvarProduto_Click);
            // 
            // btnEditarProduto
            // 
            this.btnEditarProduto.Location = new System.Drawing.Point(362, 178);
            this.btnEditarProduto.Name = "btnEditarProduto";
            this.btnEditarProduto.Size = new System.Drawing.Size(200, 30);
            this.btnEditarProduto.TabIndex = 4;
            this.btnEditarProduto.Text = "Editar Produto";
            this.btnEditarProduto.UseVisualStyleBackColor = true;
            this.btnEditarProduto.Click += new System.EventHandler(this.btnEditarProduto_Click);
            // 
            // btnExcluirProduto
            // 
            this.btnExcluirProduto.Location = new System.Drawing.Point(362, 218);
            this.btnExcluirProduto.Name = "btnExcluirProduto";
            this.btnExcluirProduto.Size = new System.Drawing.Size(200, 30);
            this.btnExcluirProduto.TabIndex = 5;
            this.btnExcluirProduto.Text = "Excluir Produto";
            this.btnExcluirProduto.UseVisualStyleBackColor = true;
            this.btnExcluirProduto.Click += new System.EventHandler(this.btnExcluirProduto_Click);
            // 
            // dataGridProdutos
            // 
            this.dataGridProdutos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProdutos.Location = new System.Drawing.Point(30, 270);
            this.dataGridProdutos.Name = "dataGridProdutos";
            this.dataGridProdutos.RowHeadersWidth = 51;
            this.dataGridProdutos.RowTemplate.Height = 24;
            this.dataGridProdutos.Size = new System.Drawing.Size(850, 200);
            this.dataGridProdutos.TabIndex = 6;
            // 
            // labelNomeProduto
            // 
            this.labelNomeProduto.AutoSize = true;
            this.labelNomeProduto.Location = new System.Drawing.Point(262, 18);
            this.labelNomeProduto.Name = "labelNomeProduto";
            this.labelNomeProduto.Size = new System.Drawing.Size(94, 16);
            this.labelNomeProduto.TabIndex = 7;
            this.labelNomeProduto.Text = "Nome Produto";
            // 
            // labelValorPorKg
            // 
            this.labelValorPorKg.AutoSize = true;
            this.labelValorPorKg.Location = new System.Drawing.Point(262, 58);
            this.labelValorPorKg.Name = "labelValorPorKg";
            this.labelValorPorKg.Size = new System.Drawing.Size(81, 16);
            this.labelValorPorKg.TabIndex = 8;
            this.labelValorPorKg.Text = "Valor por Kg";
            // 
            // labelQuantidadeEstoque
            // 
            this.labelQuantidadeEstoque.AutoSize = true;
            this.labelQuantidadeEstoque.Location = new System.Drawing.Point(262, 98);
            this.labelQuantidadeEstoque.Name = "labelQuantidadeEstoque";
            this.labelQuantidadeEstoque.Size = new System.Drawing.Size(84, 16);
            this.labelQuantidadeEstoque.TabIndex = 9;
            this.labelQuantidadeEstoque.Text = "Qtd. Estoque";
            // 
            // FormProdutos
            // 
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(913, 500);
            this.Controls.Add(this.labelQuantidadeEstoque);
            this.Controls.Add(this.labelValorPorKg);
            this.Controls.Add(this.labelNomeProduto);
            this.Controls.Add(this.dataGridProdutos);
            this.Controls.Add(this.btnExcluirProduto);
            this.Controls.Add(this.btnEditarProduto);
            this.Controls.Add(this.btnSalvarProduto);
            this.Controls.Add(this.txtQuantidadeEstoque);
            this.Controls.Add(this.txtValorPorKg);
            this.Controls.Add(this.txtNomeProduto);
            this.Name = "FormProdutos";
            this.Text = "Gerenciamento de Produtos";
            this.Load += new System.EventHandler(this.FormProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.TextBox txtValorPorKg;
        private System.Windows.Forms.TextBox txtQuantidadeEstoque;
        private System.Windows.Forms.Button btnSalvarProduto;
        private System.Windows.Forms.Button btnEditarProduto;
        private System.Windows.Forms.Button btnExcluirProduto;
        private System.Windows.Forms.DataGridView dataGridProdutos;
        private System.Windows.Forms.Label labelNomeProduto;
        private System.Windows.Forms.Label labelValorPorKg;
        private System.Windows.Forms.Label labelQuantidadeEstoque;
    }
}
