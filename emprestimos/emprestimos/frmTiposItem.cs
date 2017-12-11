using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Emprestimos
{
	public partial class frmTiposItem : Form
	{
		// MySQL connection attributes
		public static MySqlConnection dbConn;
		public static MySqlDataAdapter dbAdapter;
		public DataSet dbDataSet;
		private MySqlDataAdapter dataAdapter;
		private BindingSource bSource = new BindingSource();

		public frmTiposItem()
		{
			InitializeComponent();

			// Defines dataset
			dbDataSet = new DataSet();
			// Defines connection string
			dbConn = DBConnection.create();
		}

		// Inicializa o form carregando o DataGrid
		private void frmTiposItem_Load(object sender, EventArgs e)
		{
			// Reload the data from the database
			dgvTiposItem.DataSource = bSource;
			GetData();
		}

		// Recarrega o DataGrid
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			// Reload the data from the database
			GetData();
		}

		// Atualiza a tabela com o conteúdo do DataGrid
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			// Open MySQL connection
			using (dbConn = DBConnection.create())
			{
				// Stored procedure for insert
				MySqlCommand mysqlInsert = new MySqlCommand("INSERT INTO tipo_item(id, descricao) VALUES(TRIM(@id), TRIM(@descricao))", dbConn);
				mysqlInsert.Parameters.Add("@id", MySqlDbType.Int16, 11, "id");
				mysqlInsert.Parameters.Add("@descricao", MySqlDbType.VarChar, 64, "descricao");
				dataAdapter.InsertCommand = mysqlInsert;

				// Stored procedure for update
				MySqlCommand mysqlUpdate = new MySqlCommand("UPDATE tipo_item SET id=TRIM(@id), descricao=TRIM(@descricao) WHERE id=@id", dbConn);
				mysqlUpdate.Parameters.Add("@id", MySqlDbType.Int16, 11, "id");
				mysqlUpdate.Parameters.Add("@descricao", MySqlDbType.VarChar, 64, "descricao");
				dataAdapter.UpdateCommand = mysqlUpdate;

				// Stored procedure for delete
				MySqlCommand mysqlDelete = new MySqlCommand("");
				dataAdapter.DeleteCommand = mysqlDelete;

				dataAdapter.Update((DataTable)bSource.DataSource);
			}
			dbConn.Close();
		}

		// Obtem os dados da tabela e coloca no DataGrid
		private void GetData()
		{
			// Open MySQL connection
			using (dbConn = DBConnection.create())
			{
				string sqlGetTiposItem = "SELECT `id`, `descricao` FROM `tipo_item` ORDER BY `descricao` ASC;";
				using (MySqlCommand dbComGetTipoItem = new MySqlCommand(sqlGetTiposItem, dbConn))
				{
					dataAdapter = new MySqlDataAdapter(dbComGetTipoItem);

					DataTable table = new DataTable();
					dataAdapter.Fill(table);
					bSource.DataSource = table;

					// Resize the DataGridView columns to fit the newly loaded content.
					dgvTiposItem.AutoResizeColumns(
						DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
				}
			}
			dbConn.Close();
		}

		private void dgvTiposItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
