using JocysCom.ClassLibrary.Security.Password.Templates;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using JocysCom.PassMan.PassGen.Properties;

namespace JocysCom.PassMan.PassGen.Controls
{
	public partial class OptionsControl : UserControl
	{
		public OptionsControl()
		{
			Settings.Default.SettingsLoaded += Default_SettingsLoaded;
			InitializeComponent();
		}

		public void Initialize()
		{
			LocalUserFolderTextBox.Text = new DirectoryInfo(Application.LocalUserAppDataPath).Parent.FullName;
			//Configuration config =
			//ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
			//Console.WriteLine("Local user config path: {0}", config.FilePath); 
			//%APPDATA%\<AppName>\<AppName><AppConfigName_GUID>\<AssemblyVersion>\user.config
			// user.config will reside in the location specified by the Application.LocalUserAppDataPath
			//http://msdn.microsoft.com/en-us/library/8eyb2ct1.aspx
			//CurrentUserFolderTextBox.Text = config.FilePath;
			//http://www.blayd.co.uk/article.aspx?pageid=1013
			// http://www.app-fact.de/uploads/media/System_Configuration_en.pdf
			AllUsersFolderTextBox.Text = new DirectoryInfo(Application.CommonAppDataPath).Parent.FullName;
			RoamingUserFolderTextBox.Text = new DirectoryInfo(Application.UserAppDataPath).Parent.FullName;
			string[] names = mainForm.GeneratorPanel.Presets.Select(x => x.PresetName).ToArray();
			PassGenHelper.LoadPresets(FavPreset1ComboBox, names, Settings.Default.FavPreset1ComboBox);
			PassGenHelper.LoadPresets(FavPreset2ComboBox, names, Settings.Default.FavPreset2ComboBox);
			PassGenHelper.LoadPresets(FavPreset3ComboBox, names, Settings.Default.FavPreset3ComboBox);
			// Load settings to controls.
			FavPreset1TextBox.Text = Settings.Default.FavPreset1TextBox;
			FavPreset2TextBox.Text = Settings.Default.FavPreset2TextBox;
			FavPreset3TextBox.Text = Settings.Default.FavPreset3TextBox;
			SettingsLoaded = true;
		}

		bool SettingsLoaded;

		private void Default_SettingsLoaded(object sender, System.Configuration.SettingsLoadedEventArgs e)
		{
			if (string.IsNullOrEmpty(Settings.Default.FavPreset1TextBox))
			{
				Settings.Default.FavPreset1TextBox = GetShortName(Settings.Default.FavPreset1ComboBox);
			}
			if (string.IsNullOrEmpty(Settings.Default.FavPreset2TextBox))
			{
				Settings.Default.FavPreset2TextBox = GetShortName(Settings.Default.FavPreset2ComboBox);
			}
			if (string.IsNullOrEmpty(Settings.Default.FavPreset3TextBox))
			{
				Settings.Default.FavPreset3TextBox = GetShortName(Settings.Default.FavPreset3ComboBox);
			}
		}

		string GetShortName(string s)
		{
			if (string.IsNullOrEmpty(s)) return "";
			var word = "";
			string[] words;
			if (s.Contains(':'))
			{
				words = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
				if (words.Length > 1 && !string.IsNullOrEmpty(words[1]))
				{
					word = words[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
				}
			}
			if (string.IsNullOrEmpty(word))
			{
				word = s.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
			}
			return word;
		}

		MainForm mainForm
		{
			get { return Program.mainForm; }
		}


		void AlwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			mainForm.SetAlwaysOnTop(!Settings.Default.AlwaysOnTop);
		}

		private void MinimizeToTrayCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			mainForm.SetMinimizeToTray(!Settings.Default.MinimizeToTray);
		}

		private void StartWithWindowsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			mainForm.SetStartWithWindows(!Settings.Default.StartWithWindows);
		}

		private void StartWithWindowsStateComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			mainForm.SetStartWithWindowsState(Settings.Default.StartWithWindowsState);
		}

		private void AllowOnlyOneCopyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void SaveProgramSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void AllUsersFolderOpenButton_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(AllUsersFolderTextBox.Text);
		}

		private void RoamingUserFolderOpenButton_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(RoamingUserFolderTextBox.Text);
		}

		private void LocalUserFolderOpenButton_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(LocalUserFolderTextBox.Text);
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			BindingList<Preset> presets = mainForm.GeneratorPanel.Presets;
			for (int i = 0; i < presets.Count(); i++)
			{
				string fullName = mainForm.GeneratorPanel.GetPresetFileName(presets[i]);
				FileInfo fi = new FileInfo(fullName);
				if (fi.Exists) fi.Delete();
			}
			string selectedPresetName = mainForm.GeneratorPanel.PresetNameComboBox.Text;
			mainForm.GeneratorPanel.Presets = null;
			mainForm.LeftToolStripStatusLabel.Text = string.Format(
				"{0} presets were reset to default and reloaded",
				mainForm.GeneratorPanel.Presets.Count());
			if (mainForm.GeneratorPanel.PresetNameComboBox.Items.Contains(selectedPresetName))
			{
				mainForm.GeneratorPanel.PresetNameComboBox.Text = selectedPresetName;
			}
		}

		private void FavPreset1TextBox_Changed(object sender, EventArgs e)
		{
			var text = FavPreset1TextBox.Text;
			if (SettingsLoaded) Settings.Default.FavPreset1TextBox = text;
			mainForm.GeneratorPanel.FavPreset1Button.Text = text;
			mainForm.Preset1ToolStripMenuItem.Text = text;
		}

		private void FavPreset2TextBox_Changed(object sender, EventArgs e)
		{
			var text = FavPreset2TextBox.Text;
			if (SettingsLoaded) Settings.Default.FavPreset2TextBox = text;
			mainForm.GeneratorPanel.FavPreset2Button.Text = text;
			mainForm.Preset2ToolStripMenuItem.Text = text;
		}

		private void FavPreset3TextBox_Changed(object sender, EventArgs e)
		{
			var text = FavPreset3TextBox.Text;
			if (SettingsLoaded) Settings.Default.FavPreset3TextBox = text;
			mainForm.GeneratorPanel.FavPreset3Button.Text = text;
			mainForm.Preset3ToolStripMenuItem.Text = text;
		}

		private void FavPreset1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var text = FavPreset1ComboBox.Text;
			if (SettingsLoaded) Settings.Default.FavPreset1ComboBox = text;
		}

		private void FavPreset2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var text = FavPreset2ComboBox.Text;
			if (SettingsLoaded) Settings.Default.FavPreset2ComboBox = text;
		}

		private void FavPreset3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var text = FavPreset2ComboBox.Text;
			if (SettingsLoaded) Settings.Default.FavPreset2ComboBox = text;
		}
	}
}
