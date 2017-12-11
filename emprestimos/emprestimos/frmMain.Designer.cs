namespace Emprestimos
{
	partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.btnFormTiposItem = new System.Windows.Forms.Button();
			this.btnFormItens = new System.Windows.Forms.Button();
			this.itemBox = new System.Windows.Forms.ListBox();
			this.loggedLabel = new System.Windows.Forms.Label();
			this.btnAddFree = new System.Windows.Forms.Button();
			this.btnDelFree = new System.Windows.Forms.Button();
			this.emprestimoBox = new System.Windows.Forms.ListBox();
			this.freeLabel = new System.Windows.Forms.Label();
			this.lblDeveloper = new System.Windows.Forms.Label();
			this.btnFormHistory = new System.Windows.Forms.Button();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.lblBarcode = new System.Windows.Forms.Label();
			this.txtMatricula = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEmprestarObs = new System.Windows.Forms.Button();
			this.gpbPesqUsuario = new System.Windows.Forms.GroupBox();
			this.txtPesqUsuario = new System.Windows.Forms.TextBox();
			this.btnPesquisar = new System.Windows.Forms.Button();
			this.gpbPesqUsuario.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnFormTiposItem
			// 
			this.btnFormTiposItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFormTiposItem.BackColor = System.Drawing.Color.PaleTurquoise;
			this.btnFormTiposItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFormTiposItem.Location = new System.Drawing.Point(1009, 27);
			this.btnFormTiposItem.Name = "btnFormTiposItem";
			this.btnFormTiposItem.Size = new System.Drawing.Size(163, 73);
			this.btnFormTiposItem.TabIndex = 7;
			this.btnFormTiposItem.Text = "Tipos de Item";
			this.btnFormTiposItem.UseVisualStyleBackColor = false;
			this.btnFormTiposItem.Click += new System.EventHandler(this.btnFormTiposItem_Click);
			// 
			// btnFormItens
			// 
			this.btnFormItens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFormItens.BackColor = System.Drawing.Color.PaleTurquoise;
			this.btnFormItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFormItens.Location = new System.Drawing.Point(1009, 114);
			this.btnFormItens.Name = "btnFormItens";
			this.btnFormItens.Size = new System.Drawing.Size(163, 73);
			this.btnFormItens.TabIndex = 8;
			this.btnFormItens.Text = "Itens";
			this.btnFormItens.UseVisualStyleBackColor = false;
			this.btnFormItens.Click += new System.EventHandler(this.btnFormItens_Click);
			// 
			// itemBox
			// 
			this.itemBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.itemBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.itemBox.FormattingEnabled = true;
			this.itemBox.ItemHeight = 19;
			this.itemBox.Location = new System.Drawing.Point(12, 27);
			this.itemBox.MinimumSize = new System.Drawing.Size(286, 633);
			this.itemBox.Name = "itemBox";
			this.itemBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.itemBox.Size = new System.Drawing.Size(323, 631);
			this.itemBox.TabIndex = 1;
			this.itemBox.SelectedIndexChanged += new System.EventHandler(this.itemBox_SelectedIndexChanged);
			// 
			// loggedLabel
			// 
			this.loggedLabel.AutoSize = true;
			this.loggedLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loggedLabel.Location = new System.Drawing.Point(9, 6);
			this.loggedLabel.Name = "loggedLabel";
			this.loggedLabel.Size = new System.Drawing.Size(92, 18);
			this.loggedLabel.TabIndex = 6;
			this.loggedLabel.Text = "Itens Livres";
			// 
			// btnAddFree
			// 
			this.btnAddFree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddFree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnAddFree.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddFree.Location = new System.Drawing.Point(351, 67);
			this.btnAddFree.MinimumSize = new System.Drawing.Size(108, 62);
			this.btnAddFree.Name = "btnAddFree";
			this.btnAddFree.Size = new System.Drawing.Size(190, 62);
			this.btnAddFree.TabIndex = 2;
			this.btnAddFree.Text = "Emprestar >>";
			this.btnAddFree.UseVisualStyleBackColor = false;
			this.btnAddFree.Click += new System.EventHandler(this.btnAddFree_Click);
			// 
			// btnDelFree
			// 
			this.btnDelFree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelFree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnDelFree.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelFree.Location = new System.Drawing.Point(351, 283);
			this.btnDelFree.MinimumSize = new System.Drawing.Size(108, 62);
			this.btnDelFree.Name = "btnDelFree";
			this.btnDelFree.Size = new System.Drawing.Size(190, 62);
			this.btnDelFree.TabIndex = 4;
			this.btnDelFree.Text = "<<  Devolver ";
			this.btnDelFree.UseVisualStyleBackColor = false;
			this.btnDelFree.Click += new System.EventHandler(this.btnDelFree_Click);
			// 
			// emprestimoBox
			// 
			this.emprestimoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.emprestimoBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.emprestimoBox.FormattingEnabled = true;
			this.emprestimoBox.ItemHeight = 19;
			this.emprestimoBox.Location = new System.Drawing.Point(560, 27);
			this.emprestimoBox.MinimumSize = new System.Drawing.Size(285, 565);
			this.emprestimoBox.Name = "emprestimoBox";
			this.emprestimoBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.emprestimoBox.Size = new System.Drawing.Size(428, 555);
			this.emprestimoBox.TabIndex = 3;
			this.emprestimoBox.SelectedIndexChanged += new System.EventHandler(this.emprestimoBox_SelectedIndexChanged);
			// 
			// freeLabel
			// 
			this.freeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.freeLabel.AutoSize = true;
			this.freeLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.freeLabel.Location = new System.Drawing.Point(557, 6);
			this.freeLabel.Name = "freeLabel";
			this.freeLabel.Size = new System.Drawing.Size(140, 18);
			this.freeLabel.TabIndex = 11;
			this.freeLabel.Text = "Itens Emprestados";
			// 
			// lblDeveloper
			// 
			this.lblDeveloper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDeveloper.AutoSize = true;
			this.lblDeveloper.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDeveloper.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.lblDeveloper.Location = new System.Drawing.Point(949, 657);
			this.lblDeveloper.Name = "lblDeveloper";
			this.lblDeveloper.Size = new System.Drawing.Size(77, 15);
			this.lblDeveloper.TabIndex = 22;
			this.lblDeveloper.Text = "lblDeveloper";
			this.lblDeveloper.DoubleClick += new System.EventHandler(this.lblDeveloper_DoubleClick);
			// 
			// btnFormHistory
			// 
			this.btnFormHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFormHistory.BackColor = System.Drawing.Color.PaleTurquoise;
			this.btnFormHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFormHistory.Location = new System.Drawing.Point(1009, 200);
			this.btnFormHistory.Name = "btnFormHistory";
			this.btnFormHistory.Size = new System.Drawing.Size(163, 73);
			this.btnFormHistory.TabIndex = 9;
			this.btnFormHistory.Text = "Histórico";
			this.btnFormHistory.UseVisualStyleBackColor = false;
			this.btnFormHistory.Click += new System.EventHandler(this.btnFormHistory_Click);
			// 
			// txtBarcode
			// 
			this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtBarcode.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBarcode.Location = new System.Drawing.Point(12, 680);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(223, 26);
			this.txtBarcode.TabIndex = 5;
			this.txtBarcode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtBarcode_MouseClick);
			this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
			this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
			// 
			// lblBarcode
			// 
			this.lblBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblBarcode.AutoSize = true;
			this.lblBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBarcode.ForeColor = System.Drawing.Color.Red;
			this.lblBarcode.Location = new System.Drawing.Point(241, 681);
			this.lblBarcode.Name = "lblBarcode";
			this.lblBarcode.Size = new System.Drawing.Size(94, 20);
			this.lblBarcode.TabIndex = 24;
			this.lblBarcode.Text = "lblBarcode";
			this.lblBarcode.Click += new System.EventHandler(this.lblBarcode_Click);
			// 
			// txtMatricula
			// 
			this.txtMatricula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMatricula.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMatricula.Location = new System.Drawing.Point(775, 611);
			this.txtMatricula.Name = "txtMatricula";
			this.txtMatricula.Size = new System.Drawing.Size(213, 26);
			this.txtMatricula.TabIndex = 6;
			this.txtMatricula.TextChanged += new System.EventHandler(this.txtMatricula_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(695, 614);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 18);
			this.label1.TabIndex = 26;
			this.label1.Text = "Filtragem";
			// 
			// btnEmprestarObs
			// 
			this.btnEmprestarObs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEmprestarObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnEmprestarObs.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEmprestarObs.Location = new System.Drawing.Point(351, 160);
			this.btnEmprestarObs.MinimumSize = new System.Drawing.Size(108, 62);
			this.btnEmprestarObs.Name = "btnEmprestarObs";
			this.btnEmprestarObs.Size = new System.Drawing.Size(190, 62);
			this.btnEmprestarObs.TabIndex = 27;
			this.btnEmprestarObs.Text = "Emprestar por outro >>";
			this.btnEmprestarObs.UseVisualStyleBackColor = false;
			this.btnEmprestarObs.Click += new System.EventHandler(this.btnEmprestarObs_Click);
			// 
			// gpbPesqUsuario
			// 
			this.gpbPesqUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gpbPesqUsuario.Controls.Add(this.btnPesquisar);
			this.gpbPesqUsuario.Controls.Add(this.txtPesqUsuario);
			this.gpbPesqUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gpbPesqUsuario.Location = new System.Drawing.Point(1009, 292);
			this.gpbPesqUsuario.Name = "gpbPesqUsuario";
			this.gpbPesqUsuario.Size = new System.Drawing.Size(163, 116);
			this.gpbPesqUsuario.TabIndex = 28;
			this.gpbPesqUsuario.TabStop = false;
			this.gpbPesqUsuario.Text = "Pesquisar usuário";
			// 
			// txtPesqUsuario
			// 
			this.txtPesqUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPesqUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPesqUsuario.Location = new System.Drawing.Point(6, 29);
			this.txtPesqUsuario.Name = "txtPesqUsuario";
			this.txtPesqUsuario.Size = new System.Drawing.Size(151, 26);
			this.txtPesqUsuario.TabIndex = 0;
			this.txtPesqUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesqUsuario_KeyDown);
			// 
			// btnPesquisar
			// 
			this.btnPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPesquisar.BackColor = System.Drawing.Color.PaleTurquoise;
			this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPesquisar.Location = new System.Drawing.Point(6, 61);
			this.btnPesquisar.Name = "btnPesquisar";
			this.btnPesquisar.Size = new System.Drawing.Size(151, 49);
			this.btnPesquisar.TabIndex = 10;
			this.btnPesquisar.Text = "Pesquisar";
			this.btnPesquisar.UseVisualStyleBackColor = false;
			this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 722);
			this.Controls.Add(this.gpbPesqUsuario);
			this.Controls.Add(this.btnEmprestarObs);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtMatricula);
			this.Controls.Add(this.lblBarcode);
			this.Controls.Add(this.txtBarcode);
			this.Controls.Add(this.btnFormHistory);
			this.Controls.Add(this.lblDeveloper);
			this.Controls.Add(this.itemBox);
			this.Controls.Add(this.loggedLabel);
			this.Controls.Add(this.btnAddFree);
			this.Controls.Add(this.btnDelFree);
			this.Controls.Add(this.emprestimoBox);
			this.Controls.Add(this.freeLabel);
			this.Controls.Add(this.btnFormItens);
			this.Controls.Add(this.btnFormTiposItem);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Empréstimos";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.gpbPesqUsuario.ResumeLayout(false);
			this.gpbPesqUsuario.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnFormTiposItem;
		private System.Windows.Forms.Button btnFormItens;
		private System.Windows.Forms.ListBox itemBox;
		private System.Windows.Forms.Label loggedLabel;
		private System.Windows.Forms.Button btnAddFree;
		private System.Windows.Forms.Button btnDelFree;
		private System.Windows.Forms.ListBox emprestimoBox;
		private System.Windows.Forms.Label freeLabel;
		private System.Windows.Forms.Label lblDeveloper;
		private System.Windows.Forms.Button btnFormHistory;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.Label lblBarcode;
		private System.Windows.Forms.TextBox txtMatricula;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnEmprestarObs;
		private System.Windows.Forms.GroupBox gpbPesqUsuario;
		private System.Windows.Forms.Button btnPesquisar;
		private System.Windows.Forms.TextBox txtPesqUsuario;
	}
}

