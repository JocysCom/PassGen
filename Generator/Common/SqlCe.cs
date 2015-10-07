using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using JocysCom.ClassLibrary.Controls;

namespace JocysCom.PassMan.PassGen.Common
{
	public partial class SqlCe
	{
		//http://arcanecode.wordpress.com/arcane-lessons/

		public SqlCe(string fileName, string password)
		{
			FileInfo file = new FileInfo(fileName);
			// http://msdn.microsoft.com/en-us/library/system.data.sqlserverce.sqlceconnection.connectionstring%28VS.80%29.aspx
			//
			//data source
			//The file path and name of the SQL Mobile database.
			//
			//password
			//The database password, which can be up to 40 characters in length.
			// If not specified, the default value is no password. This property is
			// required if you enable encryption on the database. If you specify a password,
			// encryption is automatically enabled on the database.
			//
			//encrypt
			//A Boolean value that determines whether or not the database is encrypted.
			// Must be set to true to enable encryption or false for no encryption.
			// If not specified, the default value is false. If you enable encryption,
			// you must also specify a password with the password property.
			// If you specify a password, encryption is enabled regardless of how you set this property.
			//
			// encryption mode=ppc2003 compatibility;
			Connection = new SqlCeConnection(getConnection(fileName, password));
		}

		private string getConnection(string fileName, string password)
		{
			string connectionString;
			if (string.IsNullOrEmpty(password))
			{
				connectionString = string.Format("Data Source=\"{0}\";", fileName);
			}
			else
			{
				connectionString = string.Format("Data Source=\"{0}\"; Encryption Mode=ppc2003 compatibility; Password=\"{1}\"", fileName, password);
			}
			return connectionString;
		}

		SqlCeConnection Connection;

		public void Create(bool overwrite)
		{
			FileInfo file = new FileInfo(Connection.DataSource);
			if (file.Exists)
			{
				if (overwrite)
				{
					try
					{
						file.Delete();
					}
					catch (Exception)
					{
						MessageBox.Show(string.Format("Failed to delete \"{0}\".", file.FullName),
							"SQL CE Create", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
				}
				else
				{
					MessageBox.Show(string.Format("File \"{0}\" already exists.", file.FullName),
						"SQL CE Create", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			SqlCeEngine en = new SqlCeEngine(Connection.ConnectionString);
			en.CreateDatabase();
		}

		public bool ChangePassword(string oldPassword, string newPassword)
		{
			SqlCeEngine engine = new SqlCeEngine(Connection.ConnectionString);
			string newConnection = getConnection(Connection.DataSource, newPassword);
			engine.Upgrade(newConnection);
			Connection = new SqlCeConnection(newConnection);
			return true;
		}

		public void ExecuteScript(string sqlScript)
		{
			if (Connection.State == System.Data.ConnectionState.Closed)
			{
				Connection.Open();
			}
			//SqlCeEngine en = new SqlCeEngine(Connection.ConnectionString);
			SqlCeCommand cmd = new SqlCeCommand(sqlScript, Connection);
			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (SqlCeException sqlEx)
			{
				MessageBoxForm.Show(string.Format(
					"Executing on:\r\n{0}\r\n\r\n{1}\r\n\r\n{2}",
					Connection.ConnectionString, sqlScript, sqlEx.ToString()
					), "SQL CE Error",
				  MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format(
					"Executing on:\r\n{0}\r\n\r\n{1}\r\n\r\n{2}",
					Connection.ConnectionString, sqlScript, ex.ToString()
					), "SQL CE Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Connection.Close();

			}

		}
	}
}