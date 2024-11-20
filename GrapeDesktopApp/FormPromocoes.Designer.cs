namespace GrapeDesktopApp
{
    partial class FormPromocoes
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
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.txtTextoPromocao = new System.Windows.Forms.TextBox();
            this.dataGridEmails = new System.Windows.Forms.DataGridView();
            this.SelectEmail = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEnviarNewsletter = new System.Windows.Forms.Button();
            this.labelAssunto = new System.Windows.Forms.Label();
            this.labelTextoPromocao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmails)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAssunto
            // 
            this.txtAssunto.Location = new System.Drawing.Point(303, 28);
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(460, 22);
            this.txtAssunto.TabIndex = 0;
            // 
            // txtTextoPromocao
            // 
            this.txtTextoPromocao.Location = new System.Drawing.Point(303, 83);
            this.txtTextoPromocao.Multiline = true;
            this.txtTextoPromocao.Name = "txtTextoPromocao";
            this.txtTextoPromocao.Size = new System.Drawing.Size(460, 100);
            this.txtTextoPromocao.TabIndex = 1;
            // 
            // dataGridEmails
            // 
            this.dataGridEmails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridEmails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectEmail});
            this.dataGridEmails.Location = new System.Drawing.Point(10, 208);
            this.dataGridEmails.Name = "dataGridEmails";
            this.dataGridEmails.RowHeadersWidth = 51;
            this.dataGridEmails.Size = new System.Drawing.Size(970, 150);
            this.dataGridEmails.TabIndex = 2;
            this.dataGridEmails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEmails_CellContentClick);
            // 
            // SelectEmail
            // 
            this.SelectEmail.HeaderText = "Selecionar";
            this.SelectEmail.MinimumWidth = 6;
            this.SelectEmail.Name = "SelectEmail";
            this.SelectEmail.Width = 60;
            // 
            // btnEnviarNewsletter
            // 
            this.btnEnviarNewsletter.Location = new System.Drawing.Point(440, 378);
            this.btnEnviarNewsletter.Name = "btnEnviarNewsletter";
            this.btnEnviarNewsletter.Size = new System.Drawing.Size(150, 30);
            this.btnEnviarNewsletter.TabIndex = 3;
            this.btnEnviarNewsletter.Text = "Enviar Newsletter";
            this.btnEnviarNewsletter.UseVisualStyleBackColor = true;
            this.btnEnviarNewsletter.Click += new System.EventHandler(this.btnEnviarNewsletter_Click);
            // 
            // labelAssunto
            // 
            this.labelAssunto.AutoSize = true;
            this.labelAssunto.Location = new System.Drawing.Point(303, 8);
            this.labelAssunto.Name = "labelAssunto";
            this.labelAssunto.Size = new System.Drawing.Size(58, 16);
            this.labelAssunto.TabIndex = 4;
            this.labelAssunto.Text = "Assunto:";
            // 
            // labelTextoPromocao
            // 
            this.labelTextoPromocao.AutoSize = true;
            this.labelTextoPromocao.Location = new System.Drawing.Point(303, 63);
            this.labelTextoPromocao.Name = "labelTextoPromocao";
            this.labelTextoPromocao.Size = new System.Drawing.Size(107, 16);
            this.labelTextoPromocao.TabIndex = 5;
            this.labelTextoPromocao.Text = "Corpo do E-mail:";
            // 
            // FormPromocoes
            // 
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(992, 420);
            this.Controls.Add(this.labelAssunto);
            this.Controls.Add(this.labelTextoPromocao);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.txtTextoPromocao);
            this.Controls.Add(this.dataGridEmails);
            this.Controls.Add(this.btnEnviarNewsletter);
            this.Name = "FormPromocoes";
            this.Text = "Promoções";
            this.Load += new System.EventHandler(this.FormPromocoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.TextBox txtTextoPromocao;
        private System.Windows.Forms.DataGridView dataGridEmails;
        private System.Windows.Forms.Button btnEnviarNewsletter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectEmail;
        private System.Windows.Forms.Label labelAssunto;   // Label para o Assunto
        private System.Windows.Forms.Label labelTextoPromocao;   // Label para o Corpo do E-mail
    }
}
