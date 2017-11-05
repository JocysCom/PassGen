using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;
using System.Data.EntityClient;

namespace JocysCom.ClassLibrary.Controls
{
	public partial class ConnectionOptionsControl : UserControl
	{
		public ConnectionOptionsControl()
		{
			InitializeComponent();
		}

		JocysCom.ClassLibrary.Configuration.AppConfig ac;


		public void InitPresets()
		{
			ac = new JocysCom.ClassLibrary.Configuration.AppConfig();
			var di = new System.IO.DirectoryInfo(ac.AppRootPath.FullName + @"\Data\Presets");
			PresetComboBox.Enabled = di.Exists;
			if (di.Exists)
			{
				var fis = di.GetFiles("App.*.Config");
				foreach (var item in fis)
				{
					PresetComboBox.Items.Add(item.Name.Substring("App.".Length, item.Name.Length - "App..Config".Length));
				}
			}
		}

		#region Database Connections

		private void InitConnections()
		{
			var connections = System.Configuration.ConfigurationManager.ConnectionStrings;
			ConnectionsDataGridView.Rows.Clear();
			for (int i = 0; i < connections.Count; i++)
			{
				var conn = connections[i];
				ConnectionsDataGridView.Rows.Add(new object[] { null, conn.Name, conn.ConnectionString, "Properties..." });
			}
		}


		public void SetConnection(string key, string value)
		{
			// Update control view.
			var row = ConnectionsDataGridView.Rows.Cast<DataGridViewRow>().First(x => (string)x.Cells[NameColumn.Name].Value == key);
			row.Cells[ConnectionStringColumn.Name].Value = value;
			// Get the configuration file.
			var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
			// Modify connection string.
			config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
			// Save the configuration file.
			config.Save(System.Configuration.ConfigurationSaveMode.Modified);
			// Force a reload of a changed section.
			System.Configuration.ConfigurationManager.RefreshSection(config.ConnectionStrings.SectionInformation.Name);
			// Fix: Unrecognized attribute 'configProtectionProvider'
			System.Configuration.ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
			var e = new EventArgs();
			if (ConnectionChanged != null) ConnectionChanged(this, e);
			//Properties.PublicSettings.Default.Reload();
			// Reload other settings.
			//Engine.Properties.PublicSettings.Default.Reload();
		}

		public event EventHandler ConnectionChanged;

		#endregion

		private void PresetComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Get the application configuration file path.
			var path = string.Format(@"{0}\Data\Presets\App.{1}.Config", ac.AppRootPath.FullName, PresetComboBox.Text);
			// string exeFilePath = System.IO.Path.Combine(
			//Environment.CurrentDirectory, configFileName);
			// Map to the application configuration file.
			var configFile = new ExeConfigurationFileMap { ExeConfigFilename = path };
			// Get the configuration file
			var config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
			var connections = System.Configuration.ConfigurationManager.ConnectionStrings;
			for (int i = 0; i < connections.Count; i++)
			{
				var name = connections[i].Name;
				var cs = config.ConnectionStrings.ConnectionStrings.Cast<ConnectionStringSettings>().FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
				if (cs != null) SetConnection(name, cs.ConnectionString);
			}
		}

		private void ConnectionsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			var row = ConnectionsDataGridView.Rows[e.RowIndex];
			var cell = row.Cells[e.ColumnIndex];
			if (e.ColumnIndex == PropertiesColumn.Index)
			{
				var dcd = new Microsoft.Data.ConnectionUI.DataConnectionDialog();
				//Adds all the standard supported databases
				//DataSource.AddStandardDataSources(dcd);
				//allows you to add datasources, if you want to specify which will be supported
				dcd.DataSources.Add(Microsoft.Data.ConnectionUI.DataSource.SqlDataSource);
				dcd.SetSelectedDataProvider(Microsoft.Data.ConnectionUI.DataSource.SqlDataSource,
											Microsoft.Data.ConnectionUI.DataProvider.SqlDataProvider);
				var name = (string)row.Cells[NameColumn.Name].Value;
				var connections = System.Configuration.ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>();
				var conn = connections.First(x => x.Name == name);
				var value = conn.ConnectionString;
				EntityConnection ec = null;
				// Extract simplified connection string from entity.
				if (conn.ConnectionString.StartsWith("metadata="))
				{
					ec = new EntityConnection(conn.ConnectionString);
					value = ec.StoreConnection.ConnectionString;
				}
				dcd.ConnectionString = value;
				Microsoft.Data.ConnectionUI.DataConnectionDialog.Show(dcd);
				if (dcd.DialogResult == DialogResult.OK)
				{
					value = dcd.ConnectionString;
					// Restore entity framwork complex connection.
					if (ec != null)
					{
						ec.StoreConnection.ConnectionString = value;
						value = ec.ConnectionString;
					}
					SetConnection(name, value);
				}
			}
		}

		private void ConnectionsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			var e2 = new DataGridViewCellEventArgs(PropertiesColumn.Index, e.RowIndex);
			ConnectionsDataGridView_CellClick(sender, e2);
		}

		int gridHeight = 0;
		int groupHeight = 0;
		int logHeight = 0;
		int logTop = 0;

		private void ConnectionOptionsControl_Load(object sender, EventArgs e)
		{
			// Store original size.
			LogsTextBox.Dock = DockStyle.None;
			gridHeight = ConnectionsDataGridView.Height;
			groupHeight = DatabaseConnectionsGroupBox.Height;
			logTop = LogsTextBox.Top;
			logHeight = LogsTextBox.Size.Height;
			ConnectionsDataGridView.Resize += new EventHandler(ConnectionsDataGridView_Resize);
			ConnectionsDataGridView.AutoSize = true;
			// Bind data.
			InitPresets();
			InitConnections();
		}

		private void ConnectionsDataGridView_Resize(object sender, EventArgs e)
		{
			// Resize control
			var change = ConnectionsDataGridView.Height - gridHeight;
			DatabaseConnectionsGroupBox.Height = groupHeight + change;
			LogsTextBox.Top = logTop + change;
			LogsTextBox.Height = LogsTextBox.Parent.Height - LogsTextBox.Top - 4;
		}

		private void ConnectionsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			var row = ConnectionsDataGridView.Rows[e.RowIndex];
			var value = (string)row.Cells[ConnectionStringColumn.Name].Value;
			if (ConnectionsDataGridView.Columns[e.ColumnIndex].Name == ConnectionStringColumn.Name)
			{
				if (value.StartsWith("metadata="))
				{
					value = new EntityConnection(value).StoreConnection.ConnectionString;
				}
				var regex = new Regex("(Password|PWD)\\s*=([^;]*)([;]*)", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				e.Value = regex.Replace(value, "$1=<hidden>$3");
			}
			if (ConnectionsDataGridView.Columns[e.ColumnIndex].Name == TypeColumn.Name)
			{
				e.Value = value.StartsWith("metadata=") ? ConnectionTypeImageList.Images["Data_Entity"] : ConnectionTypeImageList.Images["Data"];
			}
		}

	}

}
