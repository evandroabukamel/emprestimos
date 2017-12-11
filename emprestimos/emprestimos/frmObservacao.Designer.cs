namespace Emprestimos
{
	partial class frmObservacao
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObservacao));
			this.lblObs = new System.Windows.Forms.Label();
			this.txtObservacao = new System.Windows.Forms.TextBox();
			this.btnEmprestar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblObs
			// 
			this.lblObs.AutoSize = true;
			this.lblObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblObs.Location = new System.Drawing.Point(12, 25);
			this.lblObs.Name = "lblObs";
			this.lblObs.Size = new System.Drawing.Size(289, 20);
			this.lblObs.TabIndex = 0;
			this.lblObs.Text = "Pra quem está sendo emprestado?";
			// 
			// txtObservacao
			// 
			this.txtObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtObservacao.Location = new System.Drawing.Point(16, 59);
			this.txtObservacao.Name = "txtObservacao";
			this.txtObservacao.Size = new System.Drawing.Size(383, 26);
			this.txtObservacao.TabIndex = 1;
			// 
			// btnEmprestar
			// 
			this.btnEmprestar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnEmprestar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEmprestar.Location = new System.Drawing.Point(285, 111);
			this.btnEmprestar.Name = "btnEmprestar";
			this.btnEmprestar.Size = new System.Drawing.Size(114, 34);
			this.btnEmprestar.TabIndex = 2;
			this.btnEmprestar.Text = "Emprestar";
			this.btnEmprestar.UseVisualStyleBackColor = false;
			this.btnEmprestar.Click += new System.EventHandler(this.btnEmprestar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancelar.Location = new System.Drawing.Point(16, 111);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(114, 34);
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// frmObservacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(411, 157);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnEmprestar);
			this.Controls.Add(this.txtObservacao);
			this.Controls.Add(this.lblObs);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmObservacao";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Observação";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblObs;
		private System.Windows.Forms.TextBox txtObservacao;
		private System.Windows.Forms.Button btnEmprestar;
		private System.Windows.Forms.Button btnCancelar;
	}
}