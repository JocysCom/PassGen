// http://www.west-wind.com/presentations/dynamicCode/DynamicCode.htm
// http://www.codeproject.com/KB/dotnet/DotNetScript.aspx
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JocysCom.ClassLibrary.Controls.DynamicCompile
{
	public partial class DcControl : UserControl
	{
		public DcControl()
		{
			InitializeComponent();
		}

		public void LoadScript(LanguageType language, string contents)
		{
			UpdateStats();
			LanguageToolStripComboBox.Text = language.ToString();
			CodeTextBox.Text = contents;
		}

		public void LoadFile(string fileName)
		{
			string contents;
			try
			{
				contents = File.ReadAllText(fileName);
			}
			catch (Exception) { return; }
			var extension = Path.GetExtension(fileName);
			var ln = LanguageType.CSharp;
			switch (extension)
			{
				case ".cs":
					ln = LanguageType.CSharp;
					break;
				case ".vb":
					ln = LanguageType.VB;
					break;
				case ".js":
					ln = LanguageType.JScript;
					break;
				default:
					throw new NotSupportedException(extension);
			}
			if (AutoLoadToolStripButton.Checked)
			{
				var fi = new FileInfo(fileName);
				CodeFileSystemWatcher.Path = fi.DirectoryName;
				CodeFileSystemWatcher.Filter = fi.Name;
				CodeFileSystemWatcher.EnableRaisingEvents = true;
			}
			else
			{
				CodeFileSystemWatcher.EnableRaisingEvents = false;
			}
			LoadScript(ln, contents);
		}

		private LanguageType CurrentLanguage => (LanguageType)Enum.Parse(typeof(LanguageType), (string)LanguageToolStripComboBox.SelectedItem);

		public void Clear()
		{
			CodeTextBox.Text = string.Empty;
			ClearOutput();
		}

		public void ClearOutput()
		{
			ErrorsTextBox.Text = string.Empty;
			OutputTextBox.Text = string.Empty;
			OutputDataGridView.DataSource = null;
		}

		public bool Check()
		{
			ClearOutput();
			var code = CodeTextBox.Text.Trim();
			var selected = EntryToolStripComboBox.Text;
			var engine = new DcEngine(code, CurrentLanguage, string.Empty);
			var entryPoints = engine.GetEntryPoints(true);
			if (engine.ErrorsLog.Length > 0)
			{
				ErrorsTextBox.AppendText(engine.ErrorsLog.ToString());
			}
			EntryToolStripComboBox.Items.Clear();
			if (entryPoints.Length > 0)
				EntryToolStripComboBox.Items.AddRange(entryPoints);
			if (EntryToolStripComboBox.Items.Contains(selected))
			{
				EntryToolStripComboBox.Text = selected;
			}
			else if (EntryToolStripComboBox.Items.Count == 1)
			{
				EntryToolStripComboBox.Text = EntryToolStripComboBox.Items.Cast<string>().First();
			}
			if (AutoRunToolStripButton.Checked && EntryToolStripComboBox.Text.Length > 0)
				Run();
			return true;
		}

		public void Run(params object[] parameters)
		{
			var code = CodeTextBox.Text.Trim();
			var entry = EntryToolStripComboBox.Text;
			if (code == "")
				return;
			if (entry == "")
				entry = "Main";
			var engine = new DcEngine(code, CurrentLanguage, entry);
			var results = engine.Run(parameters);
			if (results == null)
			{
				OutputTextBox.Text = "null";
			}
			else if (results.GetType() == typeof(string))
			{
				OutputTextBox.Text = (string)results;
			}
			else if (results.GetType().FullName.StartsWith("System.Collections.Generic.List"))
			{
				OutputDataGridView.Dock = DockStyle.Fill;
				OutputDataGridView.BringToFront();
				OutputDataGridView.DataSource = results;
			}
			else
			{
				OutputTextBox.Dock = DockStyle.Fill;
				OutputTextBox.BringToFront();
				OutputTextBox.Text = results.GetType().FullName;
			}
			if (engine.ErrorsLog.Length > 0)
			{
				ErrorsTextBox.Text = engine.ErrorsLog.ToString();
			}
		}

		private int changed = 0;
		private int loaded = 0;

		private void CodeFileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
		{
			changed++;
			UpdateStats();
			if (e.ChangeType == WatcherChangeTypes.Changed)
			{
				// Stop current timer.
				RunTimer.Stop();
				// Restart it again.
				RunTimer.Start();
			}
		}

		private void DcControl_Load(object sender, EventArgs e)
		{
			OutputTextBox.Dock = DockStyle.Fill;
			OutputTextBox.BringToFront();
			LanguageToolStripComboBox.SelectedIndex = 0;
			var autoRun = AutoRunToolStripButton.Checked;
			if (autoRun)
				AutoRunToolStripButton.Checked = false;
			var fi = new FileInfo(FileToolStripStatusLabel.Text);
			if (fi.Exists)
				LoadFile(FileToolStripStatusLabel.Text);
			if (autoRun)
				AutoRunToolStripButton.Checked = true;
			UpdateStats();
		}


		private void RunTimer_Tick(object sender, EventArgs e)
		{
			RunTimer.Stop();
			loaded++;
			UpdateStats();
			LoadFile(FileToolStripStatusLabel.Text);
		}

		private void AutoLoadToolStripButton_Click(object sender, EventArgs e)
		{
			CodeFileSystemWatcher.EnableRaisingEvents = AutoLoadToolStripButton.Checked;
			AutoLoadToolStripButton.Checked = !AutoLoadToolStripButton.Checked;
		}

		private void AutoRunToolStripButton_Click(object sender, EventArgs e)
		{
			AutoRunToolStripButton.Checked = !AutoRunToolStripButton.Checked;
		}

		private void ReloadToolStripButton_Click(object sender, EventArgs e)
		{
			LoadFile(FileToolStripStatusLabel.Text);
		}

		private void RunToolStripButton_Click(object sender, EventArgs e)
		{
			// we use a new thread to run it
			//new Thread(new ThreadStart(RunTheProg)).Start();
			if (!SupressRunDefaultFunction)
				Run("cde");
		}

		public bool SupressRunDefaultFunction;

		#region Events

		private void OpenToolStripButton_Click(object sender, EventArgs e)
		{
			var fi = new FileInfo(FileToolStripStatusLabel.Text);
			OpenCodeFileDialog.InitialDirectory = fi.DirectoryName;
			OpenCodeFileDialog.RestoreDirectory = true;
			OpenCodeFileDialog.DefaultExt = "*.cs; *.vb";
			if (OpenCodeFileDialog.ShowDialog() != DialogResult.OK)
				return;
			FileToolStripStatusLabel.Text = OpenCodeFileDialog.FileName;
			LoadFile(FileToolStripStatusLabel.Text);
		}

		private void SaveToolStripButton_Click(object sender, EventArgs e)
		{

		}

		private void CheckToolStripButton_Click(object sender, EventArgs e)
		{
			Check();
		}

		private void ErrorsTextBox_TextChanged(object sender, EventArgs e)
		{
			if (ErrorsTextBox.Text.Length > 0)
			{
				ResultsTabControl.SelectedTab = ErrorsTabPage;
			}
		}

		private void OutputTextBox_TextChanged(object sender, EventArgs e)
		{
			if (OutputTextBox.Text.Length > 0)
			{
				ResultsTabControl.SelectedTab = OutputTabPage;
			}
		}

		private void LanguageToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var rx = new Regex(@"\s*");
			var current = rx.Replace(CodeTextBox.Text.Trim(), "");
			var replace = string.IsNullOrEmpty(current);
			var keys = (LanguageType[])Enum.GetValues(typeof(LanguageType));
			for (var i = 0; i < keys.Length; i++)
			{
				var template = Templates[keys[i]];
				if (template == null)
					template = "";
				if (current == rx.Replace(template, ""))
				{
					replace = true;
					break;
				}
			}
			var language = (LanguageType)Enum.Parse(typeof(LanguageType), LanguageToolStripComboBox.Text);
			switch (language)
			{
				case LanguageType.CSharp:
					CodeTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
					break;
				case LanguageType.VB:
					CodeTextBox.Language = FastColoredTextBoxNS.Language.VB;
					break;
				case LanguageType.JScript:
					CodeTextBox.Language = FastColoredTextBoxNS.Language.JS;
					break;
				default:
					CodeTextBox.Language = FastColoredTextBoxNS.Language.Custom;
					break;
			}
			if (replace)
				CodeTextBox.Text = Templates[language];
			Check();
		}

		#endregion

		private void UpdateStats()
		{
			ChangedToolStripStatusLabel.Text = string.Format("Changed: {0}", changed);
			LoadedToolStripStatusLabel.Text = string.Format("Loaded: {0}", loaded);
		}

		private Dictionary<LanguageType, string> _Templates;

		private Dictionary<LanguageType, string> Templates
		{
			get
			{
				if (_Templates == null)
				{
					_Templates = new Dictionary<LanguageType, string>
					{
						{ LanguageType.CSharp, Helper.FindResource<string>(@"DynamicCompile.Templates.CSharp.cs") },
						{ LanguageType.JScript, Helper.FindResource<string>(@"DynamicCompile.Templates.JScript.js") },
						{ LanguageType.VB, Helper.FindResource<string>(@"DynamicCompile.Templates.VB.vb") }
					};
				}
				return _Templates;
			}
		}

		private readonly object providerLock = new object();


		private void ResultsTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ResultsTabControl.SelectedTab == CodeTabPage)
			{
				var key = (LanguageType)Enum.Parse(typeof(LanguageType), LanguageToolStripComboBox.Text);
				CodeLineTextBox.Text = JocysCom.ClassLibrary.Text.Helper.ToLiteral(CodeTextBox.Text.Trim(), key.ToString());
			}
		}
	}
}
