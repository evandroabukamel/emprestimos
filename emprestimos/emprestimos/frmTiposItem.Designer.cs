namespace Emprestimos
{
	partial class frmTiposItem
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTiposItem));
			this.dgvTiposItem = new System.Windows.Forms.DataGridView();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvTiposItem)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvTiposItem
			// 
			this.dgvTiposItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvTiposItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTiposItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descricao});
			this.dgvTiposItem.Location = new System.Drawing.Point(12, 12);
			this.dgvTiposItem.Name = "dgvTiposItem";
			this.dgvTiposItem.Size = new System.Drawing.Size(305, 296);
			this.dgvTiposItem.TabIndex = 0;
			this.dgvTiposItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTiposItem_CellContentClick);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRefresh.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRefresh.Location = new System.Drawing.Point(12, 314);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(115, 31);
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "Recarregar";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUpdate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdate.Location = new System.Drawing.Point(208, 314);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(109, 31);
			this.btnUpdate.TabIndex = 2;
			this.btnUpdate.Text = "Salvar";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// id
			// 
			this.id.DataPropertyName = "id";
			this.id.HeaderText = "Código";
			this.id.MinimumWidth = 50;
			this.id.Name = "id";
			this.id.ReadOnly = true;
			this.id.Width = 65;
			// 
			// descricao
			// 
			this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.descricao.DataPropertyName = "descricao";
			this.descricao.HeaderText = "Descrição";
			this.descricao.MinimumWidth = 20;
			this.descricao.Name = "descricao";
			// 
			// frmTiposItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 357);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.dgvTiposItem);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTiposItem";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tipos de Item";
			this.Load += new System.EventHandler(this.frmTiposItem_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvTiposItem)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvTiposItem;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
	}
}