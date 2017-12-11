/**
 * Emprestimos - Programa para emprestimo de chaves e equipamentos para alunos e professores.
 * 
 * Author: Evandro Abu Kamel
 * Company: Pontifícia Universidade Católica de Minas Gerais
 * Copyright: Evandro Abu Kamel © 2017
 * Description: This is the file of the formMain class, responsable for the application main window.
 **/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Emprestimos
{
	public partial class frmMain : Form
	{
		private string version = " v1.17.11";
		public static frmMain Instance;

		// List of items and emprestimos
		private ArrayList itemList;
		public static ArrayList mainList;
		private ArrayList emprestimoList;

		// Items selected from listboxes
		private object[] selectedItems;
		private object[] selectedEmprestimos;

		// MRE
		private readonly ManualResetEvent pauseItemsEvent = new ManualResetEvent(true);
		private readonly ManualResetEvent pauseEmprestimosEvent = new ManualResetEvent(true);
        private bool realoadItems = false;
        private bool realoadEmprestimos = false;

        // Workers
        BackgroundWorker workerItemList = new BackgroundWorker();
		BackgroundWorker workerEmprestimos = new BackgroundWorker();

		// Callbacks
		public delegate void ItemBoxCallback(ListBox lb);
		public delegate void EmprestimoBoxCallback(ListBox lb);

		// MySQL connection attributes
		public static MySqlConnection dbConn;
		public static MySqlDataAdapter dbAdapter;
		public static DataSet dbDataSet;

		public frmMain()
		{
			InitializeComponent();
			Instance = this;

            // Set Version and Developer
            Text += version;
            lblDeveloper.Text = "Desenvolvido por Evandro Abu Kamel \nevandro.ak@pucminas.br";
			lblBarcode.Text = "<- Clique aqui para usar o leitor de código de barras!";

			// Creates and starts the worker for refresh the itemdBox
			try
			{
				workerItemList.DoWork += new DoWorkEventHandler(workerItemList_DoWork);
				workerItemList.RunWorkerAsync();
				selectedItems = new object[itemBox.SelectedItems.Count];
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			// Creates and starts the worker for refresh the emprestimoBox
			try
			{
				workerEmprestimos.DoWork += new DoWorkEventHandler(workerEmprestimos_DoWork);
				workerEmprestimos.RunWorkerAsync();
				selectedEmprestimos = new object[emprestimoBox.SelectedItems.Count];
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnFormTiposItem_Click(object sender, EventArgs e)
		{
			Form formTiposItemInstance = new frmTiposItem();
			formTiposItemInstance.Show();
		}

		private void btnFormItens_Click(object sender, EventArgs e)
		{
			Form formItensInstance = new frmItens();
			formItensInstance.Show();
		}

		private void btnFormHistory_Click(object sender, EventArgs e)
		{
			Form fornHistInstance = new frmHistory();
			fornHistInstance.Show();
		}

		/* Get the free items from database and load them in a arraylist */
		async private Task<ArrayList> getItems()
		{
			// Creates the auxiliars objects
			ArrayList list = new ArrayList();

			// Open MySQL connection
			using (MySqlConnection tempConn = DBConnection.create())
			{
				try
				{
					tempConn.Open();

					string sqlGetItemComm = "SELECT DISTINCT CONCAT(T1.id, ' | ', T1.descricao) AS item FROM `item` T1 " +
							" LEFT OUTER JOIN `emprestimo` T2 ON T1.id = T2.item_id " +
							" WHERE " +
								" T1.id NOT IN (" +
										" SELECT T3.item_id FROM `emprestimo` T3 WHERE T3.devolucao IS NULL AND T3.item_id = T1.id) " +
								" OR T2.item_id IS NULL " +
							" ORDER BY T1.tipo_item_id ASC, T1.id ASC;";
                    
					using (MySqlCommand getItemComm = new MySqlCommand(sqlGetItemComm, tempConn))
					using (MySqlDataReader itemsList = await getItemComm.ExecuteReaderAsync())
					{
						// Reads each row from DataReader
						while (itemsList.Read())
						{
							list.Add(itemsList.GetString("item"));
						}

						itemsList.Close();
						itemsList.Dispose();
						tempConn.Close();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("emprestimo: Connection could not be established.\n" + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			return list;
		}

		/* Get the emprestimos from database and load them in a arraylist */
		async private Task<ArrayList> getEmprestimos()
		{
			// Creates the auxiliars objects
			ArrayList list = new ArrayList();

			// Open MySQL connection
			using (MySqlConnection tempConn = DBConnection.create())
			{
				try
				{
					tempConn.Open();

					string sqlGetEmprestimoComm = "SELECT CONCAT(T2.id, ' | ', T2.descricao, ' | ', T1.usuario, ' | ', IFNULL(T1.observacao, '')) AS emprestimo FROM `emprestimo` T1 " +
							" INNER JOIN `item` T2 ON T1.item_id = T2.id " +
							" WHERE T1.devolucao IS NULL " +
							" ORDER BY T1.item_id ASC;";

					using (MySqlCommand getEmprestimoComm = new MySqlCommand(sqlGetEmprestimoComm, tempConn))
					using (MySqlDataReader emprestimosList = await getEmprestimoComm.ExecuteReaderAsync())
					{
						// Reads each row from DataReader
						while (emprestimosList.Read())
						{
							list.Add(emprestimosList.GetString("emprestimo"));
						}

						emprestimosList.Close();
						tempConn.Close();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("emprestimo: Connection could not be established.\n" + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			return list;
		}

		/* Load the users logged from arraylist to a listbox and make it reload */
		public async void itemBoxLoad(ListBox lb)
		{
			Application.DoEvents();
			if (lb.InvokeRequired)
			{
				ItemBoxCallback fbc = new ItemBoxCallback(itemBoxLoad);
                Invoke(fbc, new object[] { lb });
			}
			else
			{
                itemList = new ArrayList();
                itemList = await getItems();

				lb.Items.Clear();

				// Loads the userList to a listbox
				foreach (string item in itemList)
				{
					lb.Items.Add(item);
				}

				lb.Refresh();
				//lb.Update();
				Application.DoEvents();

				foreach (string item in selectedItems)
				{
					if (lb.Items.Contains(item))
					{
						lb.SelectedItems.Add(item);
					}
				}
			}
		}

		/* Load the users logged from arraylist to a listbox and make it reload */
		public async void emprestimoBoxLoad(ListBox lb)
		{
			Application.DoEvents();
			if (lb.InvokeRequired)
			{
				EmprestimoBoxCallback fbc = new EmprestimoBoxCallback(emprestimoBoxLoad);
                Invoke(fbc, new object[] { lb });
			}
			else
			{
                emprestimoList = new ArrayList();
                emprestimoList = await getEmprestimos();

				lb.Items.Clear();

				// Loads the userList to a listbox
				foreach (string emprestimo in emprestimoList)
				{
					lb.Items.Add(emprestimo);
				}

				lb.Refresh();
				//lb.Update();
				Application.DoEvents();

				foreach (string item in selectedEmprestimos)
				{
					if (lb.Items.Contains(item))
					{
						lb.SelectedItems.Add(item);
					}
				}
			}
		}

		void workerItemList_DoWork(object sender, DoWorkEventArgs e)
		{
			//Glorious time-consuming code that no longer blocks!
			while (true)
			{
                itemBoxLoad(itemBox);
                Application.DoEvents();
                if (realoadItems == false && pauseItemsEvent.WaitOne(30000))
                {
                    pauseItemsEvent.Reset();
                }
                else
                {
                    pauseItemsEvent.Set();
                    realoadItems = false;
                }
            }
        }
		
		void workerEmprestimos_DoWork(object sender, DoWorkEventArgs e)
		{
			//Glorious time-consuming code that no longer blocks!
			while (true)
			{
                emprestimoBoxLoad(emprestimoBox);
				Application.DoEvents();
                if (realoadEmprestimos == false && pauseEmprestimosEvent.WaitOne(30000))
                {
                    pauseEmprestimosEvent.Reset();
                }
                else
                {
                    pauseEmprestimosEvent.Set();
                    realoadEmprestimos = false;
                }
            }
        }

        /* Get the selected values od Items */
        private void itemBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedItems = new object[itemBox.SelectedItems.Count];
            itemBox.SelectedItems.CopyTo(selectedItems, 0);
		}

		/* Get the selected values of Emprestimos */
		private void emprestimoBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			selectedEmprestimos = new object[emprestimoBox.SelectedItems.Count];
            emprestimoBox.SelectedItems.CopyTo(selectedEmprestimos, 0);
		}

		private void btnAddFree_Click(object sender, EventArgs e)
		{
			AdicionarEmprestimo("");
		}

		public void AdicionarEmprestimo(string obs)
		{ 
			Cursor.Current = Cursors.WaitCursor;
			// If there is some selected item
			if (itemBox.SelectedItems.Count > 0)
			{
				// Create MySQL connection
				using (MySqlConnection tempConn = DBConnection.create())
				{
					try
					{
						// Open the connection
						tempConn.Open();

						string userName;
						bool credential, success = false;
						int returnCode;
						string displayName = "";
						string userLastOU = "";
						do
						{
							// Verifies user credentials
							userName = null;
							credential = GetCredentialsVistaAndUp(DBConnection.getDomain(), out userName, out returnCode);

							// If Cancel clicked
							if (returnCode == 1223) return;

							// Get user info
							GetDomainUserInfo(userName.ToString(), out displayName, out userLastOU);

							// Pergunta se o usuário pode receber o item
							DialogResult dialogResult = MessageBox.Show("USUÁRIO: " + userName + "\nNOME: " + displayName + "\nSETOR / CURSO: " + userLastOU
								+ "\n\nVocê confirma o empréstimo?", 
								"Confirmar empréstimo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
							
							Application.DoEvents();

							if (returnCode != 1223 && dialogResult == DialogResult.Yes)
							{
								if (credential && itemBox.SelectedItems.Count > 0)
								{
									for (int i = 0; i < itemBox.SelectedItems.Count; i++)
									{
										// Retrieves each of the selected items
										string item = itemBox.SelectedItems[i].ToString();
										string[] itemData = item.Split('|');
										item = itemData[0].Trim();

										// Verifies if the item is availeble
										bool itemAvailable = true;
										string sqlVerifiesItemAvailable = "SELECT id FROM `emprestimo` WHERE item_id = " + item + " AND devolucao IS NULL;";
										using (MySqlCommand verifiesItemAvailableComm = new MySqlCommand(sqlVerifiesItemAvailable, tempConn))
										using (MySqlDataReader itemAvailableList = verifiesItemAvailableComm.ExecuteReader())
										{
											if (itemAvailableList.HasRows)
												itemAvailable = false;
										}

										if (itemAvailable)
										{
											// Adds a new emprestimo
											string sqlAddEmprestimoComm = "INSERT INTO `emprestimo`(`item_id`, `retirada`, `usuario`, `observacao`) " +
																			" VALUES(" + item + ", NOW(), '" + userName + "', '" + obs.ToString() + "');";
											using (MySqlCommand addEmprestimoComm = new MySqlCommand(sqlAddEmprestimoComm, tempConn))
											{
												success = addEmprestimoComm.ExecuteNonQuery() > 0;
											}
										}
										else
										{
											MessageBox.Show("Este ítem não está disponível para empréstimo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
										}
									}

									if (success)
									{
										MessageBox.Show(String.Format("Item(s) emprestado(s) para {0} do curso {1}.", displayName.ToUpper(), userLastOU.ToUpper()),
											"Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
									}
								}
								else
								{
									MessageBox.Show("Usuário ou senha incoretos!");
								}
							}
						} while (credential == false && returnCode != 1223);

						realoadItems = true;
						pauseItemsEvent.Set();
						realoadEmprestimos = true;
						pauseEmprestimosEvent.Set();
					}
					catch (MySqlException ex)
					{
						MessageBox.Show("emprestimo: Houve algum problema durante a realização do empréstimo.\n" + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					catch (Exception ex)
					{
						MessageBox.Show("emprestimo: Houve algum erro no processo do empréstimo.\n" + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					tempConn.Close();
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void btnEmprestarObs_Click(object sender, EventArgs e)
		{
			if (itemBox.SelectedItems.Count > 0)
			{
				Form frmObservacao = new frmObservacao();
				frmObservacao.Show();
			}
		}

		/* Finish the loan of a item */
		private void btnDelFree_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			// If there is some selected item
			if (emprestimoBox.SelectedItems.Count > 0)
			{
				// Create MySQL connection
				using (MySqlConnection tempConn = DBConnection.create())
				{
					try
					{
						// Open the connection
						tempConn.Open();

						string userName;
						bool credential, success = false;
						int returnCode;
						do
						{
							// Verifies user credentials
							userName = null;
							credential = GetCredentialsVistaAndUp(DBConnection.getDomain(), out userName, out returnCode);
							Application.DoEvents();

							if (returnCode != 1223)
							{
								if (credential && emprestimoBox.SelectedItems.Count > 0)
								{
									for (int i = 0; i < emprestimoBox.SelectedItems.Count; i++)
									{
										// Retrieves each of the selected items
										string item = emprestimoBox.SelectedItems[i].ToString();
										string[] itemData = item.Split('|');
										item = itemData[0].Trim();
										string itemDesc = itemData[1].Trim();
										string usuario = itemData[2].Trim();

										// Verifica se o usuario autenticado foi o que retirou o item
										//if (userName.CompareTo(usuario) == 0)
										//{
										// Adds a new emprestimo
										string sqlFinishEmprestimoComm = "UPDATE `emprestimo` SET " +
																			" devolucao = NOW(), " +
																			" conferente = '" + userName + "' " +
																		" WHERE item_id = " + item +
																			" AND usuario = '" + usuario + "' " +
																			" AND devolucao IS NULL;";
										using (MySqlCommand finishEmprestimoComm = new MySqlCommand(sqlFinishEmprestimoComm, tempConn))
										{
											success = finishEmprestimoComm.ExecuteNonQuery() > 0;
										}
										//}
										//else
										//{
										//	MessageBox.Show("O item " + itemDesc + " não foi retirado por " + userName);
										//}
									}

									if (success)
									{
										MessageBox.Show("Item(s) devolvido(s) com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
									}
								}
								else
								{
									MessageBox.Show("Usuário ou senha incoretos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								}
							}
						} while (credential == false && returnCode != 1223);

						realoadItems = true;
						pauseItemsEvent.Set();
						realoadEmprestimos = true;
						pauseEmprestimosEvent.Set();
					}
					catch (MySqlException ex)
					{
						MessageBox.Show("emprestimo: Houve algum problema durante a devolução do ítem.\n" + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					catch (Exception ex)
					{
						MessageBox.Show("emprestimo: Houve algum erro no processo da devolução.\n" + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					tempConn.Close();
				}
			}
			Cursor.Current = Cursors.Default;
		}
		
		// Os métodos abaixo fazem parte do processo de autenticação do usuario.
		[DllImport("ole32.dll")]
		public static extern void CoTaskMemFree(IntPtr ptr);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct CREDUI_INFO
		{
			public int cbSize;
			public IntPtr hwndParent;
			public string pszMessageText;
			public string pszCaptionText;
			public IntPtr hbmBanner;
		}

		[DllImport("credui.dll", CharSet = CharSet.Auto)]
		private static extern bool CredUnPackAuthenticationBuffer(int dwFlags,
																   IntPtr pAuthBuffer,
																   uint cbAuthBuffer,
																   StringBuilder pszUserName,
																   ref int pcchMaxUserName,
																   StringBuilder pszDomainName,
																   ref int pcchMaxDomainame,
																   StringBuilder pszPassword,
																   ref int pcchMaxPassword);

		[DllImport("credui.dll", CharSet = CharSet.Auto)]
		private static extern int CredUIPromptForWindowsCredentials(ref CREDUI_INFO notUsedHere,
																	 int authError,
																	 ref uint authPackage,
																	 IntPtr InAuthBuffer,
																	 uint InAuthBufferSize,
																	 out IntPtr refOutAuthBuffer,
																	 out uint refOutAuthBufferSize,
																	 ref bool fSave,
																	 int flags);

		public static bool GetCredentialsVistaAndUp(string serverName, out string userName, out int returnCode)
		{
			CREDUI_INFO credui = new CREDUI_INFO();
			credui.pszCaptionText = "Autenticação";
			credui.pszMessageText = "Por favor, entre com usuário e senha para " + serverName;
			credui.cbSize = Marshal.SizeOf(credui);
			uint authPackage = 0;
			IntPtr outCredBuffer = new IntPtr();
			uint outCredSize;
			bool save = false;
			int result = CredUIPromptForWindowsCredentials(ref credui,
														   0,
														   ref authPackage,
														   IntPtr.Zero,
														   0,
														   out outCredBuffer,
														   out outCredSize,
														   ref save,
														   1 /* Generic */);
			/*
			 * CredUIPromptForWindowsCredentials RETURNS
			 * 0	=	OK
			 * 
			 * 1223	=	ERROR_CANCELLED
			 */
			var usernameBuf = new StringBuilder(100);
			var passwordBuf = new StringBuilder(100);
			var domainBuf = new StringBuilder(100);

			// Verifies the credentials
			bool valid = false;
			userName = null;

			int maxUserName = 100;
			int maxDomain = 100;
			int maxPassword = 100;
			//if (result == 0)
			{
				if (CredUnPackAuthenticationBuffer(0, outCredBuffer, outCredSize, usernameBuf, ref maxUserName,
												   domainBuf, ref maxDomain, passwordBuf, ref maxPassword))
				{
					//TODO: ms documentation says we should call this but i can't get it to work
					//SecureZeroMem(outCredBuffer, outCredSize);

					// Verifies the credentials
					using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain))
					{
						valid = domainContext.ValidateCredentials(usernameBuf.ToString(), passwordBuf.ToString());
					}

					// Clear the memory allocated by CredUIPromptForWindowsCredentials 
					CoTaskMemFree(outCredBuffer);
					/*networkCredential = new NetworkCredential()
					{
						UserName = usernameBuf.ToString(),
						Password = passwordBuf.ToString(),
						Domain = domainBuf.ToString()
					};*/
					userName = usernameBuf.ToString();
				}
			}

			returnCode = result;
			return valid;
		}

		private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}

		private void lblDeveloper_DoubleClick(object sender, EventArgs e)
		{
			
		}


		/* Detects if hit ENTER and clear the input */
		private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.ToString() == Keys.Enter.ToString()) 
			{
				txtBarcode.Clear();
			}
		}

		/* Get the item code and select it on the itemsBox */
		private void txtBarcode_TextChanged(object sender, EventArgs e)
		{
			string barcode = txtBarcode.Text.Trim();
			
			if (barcode.StartsWith("0990") && barcode.EndsWith("90") && barcode.Length == 10)
			{
				string item = parseItem(barcode);
				int index = itemBox.FindString(item + " |");
				if (index >= 0) 
				{
					itemBox.SetSelected(index, true);
				}
				else
				{
					MessageBox.Show("Esse item não existe ou já está emprestado para alguém.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				txtBarcode.Focus();
            }

			// http://online-barcode-generator.net/ - Interleaved 2 of 5 
			// exemplo de codigo de item: 0990xxxx90
		}

		/* Parse the barcode readed to get the Matricula */
		public string parseMatricula(string barcode)
		{
			string result = "";
			if (barcode.StartsWith("0100"))
			{
				result = barcode.Substring(4, 6);
            }
			return result;
		}

		/* Parse the barcode readed to get a Item code */
		public string parseItem(string barcode)
		{
			string result = "";
			
			if (barcode.StartsWith("0990") && barcode.EndsWith("90") && barcode.Length == 10)
			{
				// Gets the item code and remove the zeroes at the start
				result = barcode.Substring(4, 4);
				result = Int32.Parse(result).ToString();
			}
			return result;
		}

		/* Clear the selected items */
		private void txtBarcode_MouseClick(object sender, MouseEventArgs e)
		{
			itemBox.SelectedItems.Clear();
		}

		/* Get the Temprestimos from the given Matricula */
		private void txtMatricula_TextChanged(object sender, EventArgs e)
		{
			string matricula = txtMatricula.Text.Trim();
			if (matricula.Length > 0)
			{
				emprestimoBox.ClearSelected();
				for (int i = 0; i < emprestimoBox.Items.Count; i++)
				{
					if(emprestimoBox.Items[i].ToString().Contains(matricula))
					{
						emprestimoBox.SetSelected(i, true);
					}
				}
			}
			else
			{
				emprestimoBox.ClearSelected();
			}
		}

		private void lblBarcode_Click(object sender, EventArgs e)
		{

		}


		/* Pesquisa o nome completo e a OU de um usuário */
		private void btnPesquisar_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			string usuario = txtPesqUsuario.Text.Trim();
			string displayName = "", userLastOU = "";

			if (usuario != String.Empty)
			{
				// Get user parent OU
				GetDomainUserInfo(usuario, out displayName, out userLastOU);
				MessageBox.Show("USUÁRIO: " + usuario + "\nNOME: " + displayName + "\nSETOR / CURSO: " + userLastOU, "Dados do usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			Cursor.Current = Cursors.Default;
		}

		/* Busca o nome e a OU do usuário */
		private void GetDomainUserInfo(string username, out string displayName, out string userLastOU)
		{
			displayName = "";
			userLastOU = "";

			// Get user user info
			using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain))
			{
				try
				{
					// Retreive a user
					UserPrincipal user = UserPrincipal.FindByIdentity(domainContext, username.ToString());

					// Retreive the container
					DirectoryEntry deUser = user.GetUnderlyingObject() as DirectoryEntry;
					DirectoryEntry deUserContainer = deUser.Parent;
					string[] ouList = deUserContainer.Properties["distinguishedName"].Value.ToString().Split(',');
					displayName = deUser.Properties["DisplayName"].Value.ToString();
					userLastOU = ouList.Length > 0 ? ouList[0].Replace("OU=", "") : "NAO ENCONTRADO";
				}
				catch (Exception ex)
				{
					MessageBox.Show("emprestimo: Houve algum erro ao pesquisar o usuário.\n" + ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/* Ao teclar ENTER executa o clique no botão Pesquisar */
		private void txtPesqUsuario_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnPesquisar_Click(this, new EventArgs());
			}
		}
	}
}
