namespace Emprestimos
{
	partial class frmHistory
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistory));
			this.dtp2 = new System.Windows.Forms.DateTimePicker();
			this.dtp1 = new System.Windows.Forms.DateTimePicker();
			this.datagridHist = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.lblData = new System.Windows.Forms.Label();
			this.lblUser = new System.Windows.Forms.Label();
			this.txtItem = new System.Windows.Forms.TextBox();
			this.lblItem = new System.Windows.Forms.Label();
			this.txtObservacao = new System.Windows.Forms.TextBox();
			this.lblObservacao = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.datagridHist)).BeginInit();
			this.SuspendLayout();
			// 
			// dtp2
			// 
			this.dtp2.CalendarFont = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp2.Location = new System.Drawing.Point(400, 54);
			this.dtp2.Margin = new System.Windows.Forms.Padding(4);
			this.dtp2.Name = "dtp2";
			this.dtp2.Size = new System.Drawing.Size(301, 25);
			this.dtp2.TabIndex = 3;
			this.dtp2.ValueChanged += new System.EventHandler(this.dtp2_ValueChanged);
			// 
			// dtp1
			// 
			this.dtp1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtp1.Location = new System.Drawing.Point(400, 14);
			this.dtp1.Margin = new System.Windows.Forms.Padding(4);
			this.dtp1.Name = "dtp1";
			this.dtp1.Size = new System.Drawing.Size(301, 25);
			this.dtp1.TabIndex = 2;
			this.dtp1.ValueChanged += new System.EventHandler(this.dtp1_ValueChanged);
			// 
			// datagridHist
			// 
			this.datagridHist.AllowUserToAddRows = false;
			this.datagridHist.AllowUserToDeleteRows = false;
			this.datagridHist.AllowUserToOrderColumns = true;
			this.datagridHist.AllowUserToResizeRows = false;
			this.datagridHist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.datagridHist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.datagridHist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.datagridHist.Location = new System.Drawing.Point(8, 144);
			this.datagridHist.Margin = new System.Windows.Forms.Padding(13);
			this.datagridHist.Name = "datagridHist";
			this.datagridHist.ReadOnly = true;
			this.datagridHist.Size = new System.Drawing.Size(940, 556);
			this.datagridHist.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(376, 54);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(16, 18);
			this.label1.TabIndex = 13;
			this.label1.Text = "a";
			// 
			// txtUser
			// 
			this.txtUser.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUser.Location = new System.Drawing.Point(117, 14);
			this.txtUser.Margin = new System.Windows.Forms.Padding(4);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(179, 25);
			this.txtUser.TabIndex = 1;
			this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
			// 
			// lblData
			// 
			this.lblData.AutoSize = true;
			this.lblData.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblData.Location = new System.Drawing.Point(353, 16);
			this.lblData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblData.Name = "lblData";
			this.lblData.Size = new System.Drawing.Size(40, 18);
			this.lblData.TabIndex = 9;
			this.lblData.Text = "Data";
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUser.Location = new System.Drawing.Point(46, 17);
			this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(63, 18);
			this.lblUser.TabIndex = 7;
			this.lblUser.Text = "Usuário";
			// 
			// txtItem
			// 
			this.txtItem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtItem.Location = new System.Drawing.Point(117, 57);
			this.txtItem.Margin = new System.Windows.Forms.Padding(4);
			this.txtItem.Name = "txtItem";
			this.txtItem.Size = new System.Drawing.Size(179, 25);
			this.txtItem.TabIndex = 14;
			this.txtItem.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
			// 
			// lblItem
			// 
			this.lblItem.AutoSize = true;
			this.lblItem.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblItem.Location = new System.Drawing.Point(71, 60);
			this.lblItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblItem.Name = "lblItem";
			this.lblItem.Size = new System.Drawing.Size(38, 18);
			this.lblItem.TabIndex = 15;
			this.lblItem.Text = "Item";
			// 
			// txtObservacao
			// 
			this.txtObservacao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtObservacao.Location = new System.Drawing.Point(117, 102);
			this.txtObservacao.Margin = new System.Windows.Forms.Padding(4);
			this.txtObservacao.Name = "txtObservacao";
			this.txtObservacao.Size = new System.Drawing.Size(179, 25);
			this.txtObservacao.TabIndex = 16;
			this.txtObservacao.TextChanged += new System.EventHandler(this.txtObservacao_TextChanged);
			// 
			// lblObservacao
			// 
			this.lblObservacao.AutoSize = true;
			this.lblObservacao.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblObservacao.Location = new System.Drawing.Point(15, 105);
			this.lblObservacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblObservacao.Name = "lblObservacao";
			this.lblObservacao.Size = new System.Drawing.Size(94, 18);
			this.lblObservacao.TabIndex = 17;
			this.lblObservacao.Text = "Observação";
			// 
			// frmHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(957, 722);
			this.Controls.Add(this.txtObservacao);
			this.Controls.Add(this.lblObservacao);
			this.Controls.Add(this.txtItem);
			this.Controls.Add(this.lblItem);
			this.Controls.Add(this.dtp2);
			this.Controls.Add(this.dtp1);
			this.Controls.Add(this.datagridHist);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtUser);
			this.Controls.Add(this.lblData);
			this.Controls.Add(this.lblUser);
			this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmHistory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Empréstimos - Histórico";
			this.Load += new System.EventHandler(this.frmHistory_Load);
			((System.ComponentModel.ISupportInitialize)(this.datagridHist)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtp2;
		private System.Windows.Forms.DateTimePicker dtp1;
		private System.Windows.Forms.DataGridView datagridHist;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Label lblData;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.TextBox txtItem;
		private System.Windows.Forms.Label lblItem;
		private System.Windows.Forms.TextBox txtObservacao;
		private System.Windows.Forms.Label lblObservacao;
	}
}