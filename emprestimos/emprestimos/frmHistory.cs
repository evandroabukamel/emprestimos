using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Emprestimos
{
	public partial class frmHistory : Form
	{
		// MySQL connection attributes
		public static MySqlConnection dbConn;
		public static MySqlDataAdapter dbAdapter;
		public DataSet dbDataSet;
		private string histQuery;
		private MySqlDataAdapter dataAdapter;
		private BindingSource bSource = new BindingSource();

		public frmHistory()
		{
			InitializeComponent();

			// Defines dataset
			dbDataSet = new DataSet();
		}

		// Inicializa o form carregando o DataGrid
		private void frmHistory_Load(object sender, EventArgs e)
		{
			try
			{
                // Inits the SQL Query
                histQuery = "SET lc_time_names = 'pt_BR'; " +
						"SELECT " + 
							" item.descricao AS item, " + 
							" `usuario`, " +
							" DATE_FORMAT(`retirada`, '%a, %e %b %Y, %H:%i:%s') AS `fretirada`, " + 
							" DATE_FORMAT(`devolucao`, '%a, %e %b %Y, %H:%i:%s') AS `fdevolucao`, " + 
							" `conferente`, " +
							" `observacao` " + 
						" FROM `emprestimo` " + 
						" INNER JOIN item ON item.id = emprestimo.item_id ";

                // Create data adapter
                executeQuery();

                // Sets the datagrid headers
                datagridHist.Columns[0].HeaderText = "Item";
                datagridHist.Columns[0].Width = 130;
                datagridHist.Columns[1].HeaderText = "Usuário";
                datagridHist.Columns[1].Width = 80;
                datagridHist.Columns[2].HeaderText = "Retirada";
                datagridHist.Columns[2].Width = 155;
                datagridHist.Columns[3].HeaderText = "Devolução";
                datagridHist.Columns[3].Width = 155;
                datagridHist.Columns[4].HeaderText = "Conferente";
                datagridHist.Columns[4].Width = 80;
				datagridHist.Columns[5].HeaderText = "Observação";
				datagridHist.Columns[5].Width = 200;

				// Resize the DataGridView columns to fit the newly loaded content.
				//this.datagridHist.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			}
			catch (Exception ex)
			{
				MessageBox.Show("emprestimo: The data could not be bind to the data grid.\n" + ex.Message);
			}
		}

		/* Generates the query string and execute the command */
		private void executeQuery()
		{
			// Set cursor as hourglass
			Cursor.Current = Cursors.WaitCursor;

			// Open MySQL connection
			using (MySqlConnection tempConn = DBConnection.create())
			{
				string query = " ";
				int waux = 0, haux = 0;

				// Verifies if all fields are empty
				if (txtUser.TextLength == 0
					&& txtObservacao.TextLength == 0
					&& txtItem.TextLength == 0
					&& dtp1.Value.Date == DateTime.Today.Date
					&& dtp2.Value.Date == DateTime.Today.Date)
				{
					query += " WHERE DATE(retirada)=DATE(NOW()) ORDER BY retirada DESC;";
				}
				else // If same field is filled mount the where query
				{
					query += " WHERE ";

					if (dtp1.Value.Date <= DateTime.Today)
					{
						if (waux > 0)
							query += " AND ";
						query += " DATE(retirada) >= '" + dtp1.Value.Date.ToString("yyyy-MM-dd") + "' ";
						waux++;
					}
					if (dtp2.Value.Date <= DateTime.Today)
					{
						if (waux > 0)
							query += " AND ";
						query += " DATE(retirada) <= '" + dtp2.Value.Date.ToString("yyyy-MM-dd") + "' ";
						waux++;
					}
					if (txtUser.TextLength > 0)
					{
						if (waux > 0)
							query += " AND ";
						query += " usuario = '" + txtUser.Text.Trim() + "' ";
						waux++;
					}
					if (txtObservacao.TextLength > 0)
					{
						if (waux > 0)
							query += " AND ";
						query += " LOWER(observacao) LIKE LOWER('%" + txtObservacao.Text.Trim() + "%') ";
						waux++;
					}

					if (txtItem.TextLength > 0)
					{
						if (haux == 0)
							query += " HAVING ";
						if (haux > 0)
							query += " AND ";
						query += " LOWER(item) LIKE LOWER('%" + txtItem.Text.Trim() + "%') ";
						haux++;
					}

					query += " ORDER BY retirada DESC LIMIT 1000;";
				}
				
				// Creates the dataAdapter
				using (MySqlCommand historyComm = new MySqlCommand(histQuery + query, tempConn))
				{
					dataAdapter = new MySqlDataAdapter(historyComm);
					DataTable table = new DataTable();
					dataAdapter.Fill(table);
					bSource.DataSource = table;
                    datagridHist.DataSource = table;
				}
				tempConn.Close();
			}

			// Set cursor as default arrow
			Cursor.Current = Cursors.Default;
		}

		private void txtUser_TextChanged(object sender, EventArgs e)
		{
            // Create data adapter
            executeQuery();
		}

		private void dtp1_ValueChanged(object sender, EventArgs e)
		{
            // Create data adapter
            executeQuery();
		}

		private void dtp2_ValueChanged(object sender, EventArgs e)
		{
            // Create data adapter
            executeQuery();
		}

		private void txtItem_TextChanged(object sender, EventArgs e)
		{
			// Create data adapter
			executeQuery();
		}

		private void txtObservacao_TextChanged(object sender, EventArgs e)
		{
			// Create data adapter
			executeQuery();
		}
	}
}
