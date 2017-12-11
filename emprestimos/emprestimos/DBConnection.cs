/**
 * SILL2 - Server (Sistema Individual LimitLogin v2.0)
 * 
 * Author: Evandro Abu Kamel
 * Company: Pontifícia Universidade Católica de Minas Gerais
 * Copyright: Evandro Abu Kamel © 2011
 * Description: This file contains an abstract class and a method that is responsable to read the configuration file
 *				to access the database. The method parse the lines of the file and creates a MySqlConnection, returning it. 
 **/

using System;
using System.Windows.Forms;
using System.IO;
using Ini;
using MySql.Data.MySqlClient;
using System.Data;

namespace Emprestimos
{
	/**
	 * This class is responsable to read the configuration file, named "dbconnect.cfg", that must be
	 * in the same directory of the executable file "sill2-client".
	 */
	public abstract class DBConnection
	{
		private static string fileServer, domain, dbServer, database, port, user, password;
		public static MySqlConnection connection = null;

		/**
		 * This method reads to configuration file and save its values.
		 */
		public static MySqlConnection create()
		{
			IniFile localConfigFile, serverConfigFile;

			// Try to read the configuration file for database connection
			try
			{
				localConfigFile = new IniFile(@"" + Directory.GetCurrentDirectory() + "\\emprestimos-config.ini");
				fileServer = localConfigFile.IniReadValue("Config", "FileServer");

				// Sets the connection variables
				dbServer = localConfigFile.IniReadValue("Config", "DbServer");
				domain = localConfigFile.IniReadValue("Config", "Domain");
				database = localConfigFile.IniReadValue("Config", "Database");
				port = localConfigFile.IniReadValue("Config", "Port");
				user = localConfigFile.IniReadValue("Config", "User");
				password = localConfigFile.IniReadValue("Config", "Password");

				// Create the MySQL connection
				try
				{
					connection = new MySqlConnection("server=" + dbServer + "; port=" + port + "; database=" + database + "; uid=" + user + "; pwd=" + password + "");
				}
				catch (MySqlException ex)
				{
					MessageBox.Show("sill2-server: The MySQL connection could not be created.\n" + ex.Message);
				}
				catch (Exception ex)
				{
					MessageBox.Show("sill2-server: The MySQL connection could not be created.\n" + ex.Message);
				}
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show("sill2-server: The configuration file could not be found.\n" + ex.Message);
			}
			catch (DirectoryNotFoundException ex)
			{
				MessageBox.Show("sill2-server: The specified path is invalid.\n" + ex.Message);
			}
			catch (IOException ex)
			{
				MessageBox.Show("sill2-server: The path includes an incorrect or invalid syntax for file name, directory name, or volume label.\n" + ex.Message);
			}

			return connection;
		}

		/* Return the domain name */
		public static string getDomain()
		{
			return domain;
		}
	}
}