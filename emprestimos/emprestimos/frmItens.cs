using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Emprestimos
{
	public partial class frmItens : Form
	{
		// MySQL connection attributes
		public static MySqlConnection dbConn;
		public static MySqlDataAdapter dbAdapter;
		public DataSet dbDataSet;
		private MySqlDataAdapter dataAdapter;
		private BindingSource bSource = new BindingSource();

		public frmItens()
		{
			InitializeComponent();

			// Defines dataset
			dbDataSet = new DataSet();
			// Defines connection string
			dbConn = DBConnection.create();
		}

		// Inicializa o form carregando o DataGrid
		private void frmItens_Load(object sender, EventArgs e)
		{
			// Open MySQL connection
			using (dbConn = DBConnection.create())
			{
				// Adiciona a coluna de combobox para o campo tipo_item_id
				string sqlGetTiposItem = "SELECT `id`, `descricao` FROM `tipo_item` ORDER BY `descricao` ASC;";
				using (MySqlCommand dbComGetTipoItem = new MySqlCommand(sqlGetTiposItem, dbConn))
				{
					MySqlDataAdapter daTiposItem = new MySqlDataAdapter(dbComGetTipoItem);
					DataGridViewComboBoxColumn colbox = new DataGridViewComboBoxColumn();
					DataTable table = new DataTable();
					daTiposItem.Fill(table);
					colbox.DataSource = table;
					colbox.HeaderText = "Tipo de Item";
					colbox.Name = "tipo_item_id";
					colbox.DataPropertyName = "tipo_item_id";
					colbox.ValueMember = "id";
					colbox.DisplayMember = "descricao";
					colbox.FlatStyle = FlatStyle.Standard;
					colbox.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
					dgvItens.Columns.Add(colbox);
				}
			}

			// Reload the data from the database
			dgvItens.DataSource = bSource;
	
			dbConn.Close();

			GetData();
		}

		// Obtem os dados da tabela e coloca no DataGrid
		private void GetData()
		{
			// Open MySQL connection
			using (dbConn = DBConnection.create())
			{
				string sqlGetItens = "SELECT `id`, `descricao`, `tipo_item_id` FROM `item` ORDER BY `descricao` ASC;";
				using (MySqlCommand dbComGetTipoItem = new MySqlCommand(sqlGetItens, dbConn))
				{
					dataAdapter = new MySqlDataAdapter(dbComGetTipoItem);

					DataTable table = new DataTable();
					dataAdapter.Fill(table);
					bSource.DataSource = table;
					dgvItens.DataSource = bSource;

					// Resize the DataGridView columns to fit the newly loaded content.
					dgvItens.AutoResizeColumns(
						DataGridViewAutoSizeColumnsMode.AllCells);
				}
			}
			dbConn.Close();
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
				try
				{
					// Stored procedure for insert
					MySqlCommand mysqlInsert = new MySqlCommand("INSERT INTO item(id, descricao, tipo_item_id) VALUES(TRIM(@id), TRIM(@descricao), TRIM(@tipo_item_id))", dbConn);
					mysqlInsert.Parameters.Add("@id", MySqlDbType.Int16, 11, "id");
					mysqlInsert.Parameters.Add("@descricao", MySqlDbType.VarChar, 64, "descricao");
					mysqlInsert.Parameters.Add("@tipo_item_id", MySqlDbType.Int16, 11, "tipo_item_id");
					dataAdapter.InsertCommand = mysqlInsert;

					// Stored procedure for update
					MySqlCommand mysqlUpdate = new MySqlCommand("UPDATE item SET id=TRIM(@id), descricao=TRIM(@descricao), tipo_item_id=TRIM(@tipo_item_id) WHERE id=@id", dbConn);
					mysqlUpdate.Parameters.Add("@id", MySqlDbType.Int16, 11, "id");
					mysqlUpdate.Parameters.Add("@descricao", MySqlDbType.VarChar, 64, "descricao");
					mysqlUpdate.Parameters.Add("@tipo_item_id", MySqlDbType.Int16, 11, "tipo_item_id");
					dataAdapter.UpdateCommand = mysqlUpdate;

					// Stored procedure for delete
					MySqlCommand mysqlDelete = new MySqlCommand("");
					dataAdapter.DeleteCommand = mysqlDelete;

					dataAdapter.Update((DataTable)bSource.DataSource);

					MessageBox.Show("Cadastro salvo com sucesso!");
				}
				catch (MySqlException ex)
				{
					MessageBox.Show("Operação inválida de banco de dados. \n" + ex.Message);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Exceção ao executar gravação. \n" + ex.Message);
				}
			}
			dbConn.Close();
		}
	}
}
