using System;
using System.Windows.Forms;

namespace Emprestimos
{
	/// <summary>
	/// This form calls the AdicionarEmprestimo method from the frmMain.
	/// </summary>
	public partial class frmObservacao : Form
	{
		public frmObservacao()
		{
			InitializeComponent();
		}
		
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		// Chama o método de adicionar observação
		private void btnEmprestar_Click(object sender, EventArgs e)
		{
			frmMain.Instance.AdicionarEmprestimo(txtObservacao.Text);
			Close();
		}
	}
}
