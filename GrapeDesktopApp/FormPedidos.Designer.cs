namespace GrapeDesktopApp
{
    partial class FormPedidos
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
            this.dataGridPedidos = new System.Windows.Forms.DataGridView();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.btnAtualizarStatus = new System.Windows.Forms.Button();
            this.dateTimePickerFiltro = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.lblValorTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridPedidos
            // 
            this.dataGridPedidos.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.dataGridPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPedidos.Location = new System.Drawing.Point(20, 50);
            this.dataGridPedidos.Name = "dataGridPedidos";
            this.dataGridPedidos.RowHeadersWidth = 51;
            this.dataGridPedidos.Size = new System.Drawing.Size(1295, 333);
            this.dataGridPedidos.TabIndex = 0;
            // 
            // comboStatus
            // 
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "Em trânsito",
            "Concluído",
            "Cancelado"});
            this.comboStatus.Location = new System.Drawing.Point(33, 418);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(220, 24);
            this.comboStatus.TabIndex = 1;
            // 
            // btnAtualizarStatus
            // 
            this.btnAtualizarStatus.Location = new System.Drawing.Point(273, 418);
            this.btnAtualizarStatus.Name = "btnAtualizarStatus";
            this.btnAtualizarStatus.Size = new System.Drawing.Size(150, 30);
            this.btnAtualizarStatus.TabIndex = 2;
            this.btnAtualizarStatus.Text = "Atualizar Status";
            this.btnAtualizarStatus.UseVisualStyleBackColor = true;
            this.btnAtualizarStatus.Click += new System.EventHandler(this.btnAtualizarStatus_Click);
            // 
            // dateTimePickerFiltro
            // 
            this.dateTimePickerFiltro.Location = new System.Drawing.Point(33, 468);
            this.dateTimePickerFiltro.Name = "dateTimePickerFiltro";
            this.dateTimePickerFiltro.Size = new System.Drawing.Size(240, 22);
            this.dateTimePickerFiltro.TabIndex = 3;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(293, 468);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(150, 30);
            this.btnFiltrar.TabIndex = 4;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(33, 518);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(79, 16);
            this.lblValorTotal.TabIndex = 5;
            this.lblValorTotal.Text = "Valor Total: ";
            // 
            // FormPedidos
            // 
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1338, 614);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dateTimePickerFiltro);
            this.Controls.Add(this.btnAtualizarStatus);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.dataGridPedidos);
            this.Name = "FormPedidos";
            this.Text = "Gerenciamento de Pedidos";
            this.Load += new System.EventHandler(this.FormPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dataGridPedidos;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Button btnAtualizarStatus;
        private System.Windows.Forms.DateTimePicker dateTimePickerFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Label lblValorTotal;
    }
}
