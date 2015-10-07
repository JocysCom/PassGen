namespace JocysCom.PassMan.PassGen.Controls
{
	partial class OptionsControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AllUsersFolderTextBox = new System.Windows.Forms.TextBox();
			this.LocalUserFolderTextBox = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.AutoOptionsGroupBox = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ResetButton = new System.Windows.Forms.Button();
			this.nudAutoGenerateTimerSeconds = new System.Windows.Forms.NumericUpDown();
			this.GenerateOnCopyCheckBox = new System.Windows.Forms.CheckBox();
			this.CopyOnGenerateCheckBox = new System.Windows.Forms.CheckBox();
			this.CopyPasswordWhenStartCheckBox = new System.Windows.Forms.CheckBox();
			this.GeneratePasswordOnStartCheckBox = new System.Windows.Forms.CheckBox();
			this.OpenPasswordListFileAfterSaveCheckBox = new System.Windows.Forms.CheckBox();
			this.GenerateTimerCheckBox = new System.Windows.Forms.CheckBox();
			this.SaveProgramSettingsCheckBox = new System.Windows.Forms.CheckBox();
			this.ProgramStartGroupBox = new System.Windows.Forms.GroupBox();
			this.StartWithWindowsStateComboBox = new System.Windows.Forms.ComboBox();
			this.MinimizeOnCloseCheckBox = new System.Windows.Forms.CheckBox();
			this.AllowOnlyOneCopyCheckBox = new System.Windows.Forms.CheckBox();
			this.MinimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
			this.StartWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
			this.AlwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
			this.DataAndConfigurationGroupBox = new System.Windows.Forms.GroupBox();
			this.LocalUserFolderOpenButton = new System.Windows.Forms.Button();
			this.RoamingUserFolderOpenButton = new System.Windows.Forms.Button();
			this.AllUsersFolderOpenButton = new System.Windows.Forms.Button();
			this.AllUsersFolderLabel = new System.Windows.Forms.Label();
			this.RoamingUserFolderLabel = new System.Windows.Forms.Label();
			this.LocalUserFolderLabel = new System.Windows.Forms.Label();
			this.RoamingUserFolderTextBox = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.FavPreset3ComboBox = new System.Windows.Forms.ComboBox();
			this.FavPreset2ComboBox = new System.Windows.Forms.ComboBox();
			this.FavPreset1ComboBox = new System.Windows.Forms.ComboBox();
			this.FavPreset3TextBox = new System.Windows.Forms.TextBox();
			this.FavPreset2TextBox = new System.Windows.Forms.TextBox();
			this.FavPreset1TextBox = new System.Windows.Forms.TextBox();
			this.AutoOptionsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudAutoGenerateTimerSeconds)).BeginInit();
			this.ProgramStartGroupBox.SuspendLayout();
			this.DataAndConfigurationGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// AllUsersFolderTextBox
			// 
			this.AllUsersFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AllUsersFolderTextBox.Location = new System.Drawing.Point(6, 32);
			this.AllUsersFolderTextBox.Name = "AllUsersFolderTextBox";
			this.AllUsersFolderTextBox.ReadOnly = true;
			this.AllUsersFolderTextBox.Size = new System.Drawing.Size(424, 20);
			this.AllUsersFolderTextBox.TabIndex = 0;
			// 
			// LocalUserFolderTextBox
			// 
			this.LocalUserFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LocalUserFolderTextBox.Location = new System.Drawing.Point(6, 110);
			this.LocalUserFolderTextBox.Name = "LocalUserFolderTextBox";
			this.LocalUserFolderTextBox.ReadOnly = true;
			this.LocalUserFolderTextBox.Size = new System.Drawing.Size(424, 20);
			this.LocalUserFolderTextBox.TabIndex = 0;
			// 
			// AutoOptionsGroupBox
			// 
			this.AutoOptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AutoOptionsGroupBox.Controls.Add(this.label1);
			this.AutoOptionsGroupBox.Controls.Add(this.ResetButton);
			this.AutoOptionsGroupBox.Controls.Add(this.nudAutoGenerateTimerSeconds);
			this.AutoOptionsGroupBox.Controls.Add(this.GenerateOnCopyCheckBox);
			this.AutoOptionsGroupBox.Controls.Add(this.CopyOnGenerateCheckBox);
			this.AutoOptionsGroupBox.Controls.Add(this.CopyPasswordWhenStartCheckBox);
			this.AutoOptionsGroupBox.Controls.Add(this.GeneratePasswordOnStartCheckBox);
			this.AutoOptionsGroupBox.Controls.Add(this.OpenPasswordListFileAfterSaveCheckBox);
			this.AutoOptionsGroupBox.Controls.Add(this.GenerateTimerCheckBox);
			this.AutoOptionsGroupBox.Controls.Add(this.SaveProgramSettingsCheckBox);
			this.AutoOptionsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.AutoOptionsGroupBox.Location = new System.Drawing.Point(146, 253);
			this.AutoOptionsGroupBox.Name = "AutoOptionsGroupBox";
			this.AutoOptionsGroupBox.Size = new System.Drawing.Size(374, 322);
			this.AutoOptionsGroupBox.TabIndex = 107;
			this.AutoOptionsGroupBox.TabStop = false;
			this.AutoOptionsGroupBox.Text = "Auto Options:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(87, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(175, 13);
			this.label1.TabIndex = 70;
			this.label1.Text = "- reset all presets to default settings:";
			// 
			// ResetButton
			// 
			this.ResetButton.Location = new System.Drawing.Point(6, 163);
			this.ResetButton.Name = "ResetButton";
			this.ResetButton.Size = new System.Drawing.Size(75, 23);
			this.ResetButton.TabIndex = 69;
			this.ResetButton.Text = "Reset";
			this.ResetButton.UseVisualStyleBackColor = true;
			this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// nudAutoGenerateTimerSeconds
			// 
			this.nudAutoGenerateTimerSeconds.Enabled = false;
			this.nudAutoGenerateTimerSeconds.Location = new System.Drawing.Point(147, 192);
			this.nudAutoGenerateTimerSeconds.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nudAutoGenerateTimerSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudAutoGenerateTimerSeconds.Name = "nudAutoGenerateTimerSeconds";
			this.nudAutoGenerateTimerSeconds.Size = new System.Drawing.Size(48, 20);
			this.nudAutoGenerateTimerSeconds.TabIndex = 49;
			this.nudAutoGenerateTimerSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.nudAutoGenerateTimerSeconds.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudAutoGenerateTimerSeconds.Visible = false;
			// 
			// GenerateOnCopyCheckBox
			// 
			this.GenerateOnCopyCheckBox.AutoSize = true;
			this.GenerateOnCopyCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.GenerateOnCopy;
			this.GenerateOnCopyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.GenerateOnCopyCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "GenerateOnCopy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.GenerateOnCopyCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.GenerateOnCopyCheckBox.Location = new System.Drawing.Point(6, 67);
			this.GenerateOnCopyCheckBox.Name = "GenerateOnCopyCheckBox";
			this.GenerateOnCopyCheckBox.Size = new System.Drawing.Size(194, 18);
			this.GenerateOnCopyCheckBox.TabIndex = 68;
			this.GenerateOnCopyCheckBox.Text = "Generate after [Copy] button press";
			// 
			// CopyOnGenerateCheckBox
			// 
			this.CopyOnGenerateCheckBox.AutoSize = true;
			this.CopyOnGenerateCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.CopyOnGenerate;
			this.CopyOnGenerateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CopyOnGenerateCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "CopyOnGenerate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.CopyOnGenerateCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.CopyOnGenerateCheckBox.Location = new System.Drawing.Point(6, 19);
			this.CopyOnGenerateCheckBox.Name = "CopyOnGenerateCheckBox";
			this.CopyOnGenerateCheckBox.Size = new System.Drawing.Size(183, 18);
			this.CopyOnGenerateCheckBox.TabIndex = 67;
			this.CopyOnGenerateCheckBox.Text = "Copy to clipboard after generate";
			// 
			// CopyPasswordWhenStartCheckBox
			// 
			this.CopyPasswordWhenStartCheckBox.AutoSize = true;
			this.CopyPasswordWhenStartCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.CopyPasswordWhenStart;
			this.CopyPasswordWhenStartCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "CopyPasswordWhenStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.CopyPasswordWhenStartCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.CopyPasswordWhenStartCheckBox.Location = new System.Drawing.Point(6, 139);
			this.CopyPasswordWhenStartCheckBox.Name = "CopyPasswordWhenStartCheckBox";
			this.CopyPasswordWhenStartCheckBox.Size = new System.Drawing.Size(156, 18);
			this.CopyPasswordWhenStartCheckBox.TabIndex = 67;
			this.CopyPasswordWhenStartCheckBox.Text = "Copy password when start";
			// 
			// GeneratePasswordOnStartCheckBox
			// 
			this.GeneratePasswordOnStartCheckBox.AutoSize = true;
			this.GeneratePasswordOnStartCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.GeneratePasswordOnStart;
			this.GeneratePasswordOnStartCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.GeneratePasswordOnStartCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "GeneratePasswordOnStart", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.GeneratePasswordOnStartCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.GeneratePasswordOnStartCheckBox.Location = new System.Drawing.Point(6, 115);
			this.GeneratePasswordOnStartCheckBox.Name = "GeneratePasswordOnStartCheckBox";
			this.GeneratePasswordOnStartCheckBox.Size = new System.Drawing.Size(176, 18);
			this.GeneratePasswordOnStartCheckBox.TabIndex = 67;
			this.GeneratePasswordOnStartCheckBox.Text = "Generate password when start";
			// 
			// OpenPasswordListFileAfterSaveCheckBox
			// 
			this.OpenPasswordListFileAfterSaveCheckBox.AutoSize = true;
			this.OpenPasswordListFileAfterSaveCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.OpenPasswordListFileAfterSave;
			this.OpenPasswordListFileAfterSaveCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "OpenPasswordListFileAfterSave", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.OpenPasswordListFileAfterSaveCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.OpenPasswordListFileAfterSaveCheckBox.Location = new System.Drawing.Point(6, 43);
			this.OpenPasswordListFileAfterSaveCheckBox.Name = "OpenPasswordListFileAfterSaveCheckBox";
			this.OpenPasswordListFileAfterSaveCheckBox.Size = new System.Drawing.Size(187, 18);
			this.OpenPasswordListFileAfterSaveCheckBox.TabIndex = 67;
			this.OpenPasswordListFileAfterSaveCheckBox.Text = "Open password list file after save";
			// 
			// GenerateTimerCheckBox
			// 
			this.GenerateTimerCheckBox.AutoSize = true;
			this.GenerateTimerCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.GenerateTimer;
			this.GenerateTimerCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "GenerateTimer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.GenerateTimerCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.GenerateTimerCheckBox.Location = new System.Drawing.Point(6, 192);
			this.GenerateTimerCheckBox.Name = "GenerateTimerCheckBox";
			this.GenerateTimerCheckBox.Size = new System.Drawing.Size(250, 18);
			this.GenerateTimerCheckBox.TabIndex = 67;
			this.GenerateTimerCheckBox.Text = "Generate password every                   seconds";
			this.GenerateTimerCheckBox.Visible = false;
			// 
			// SaveProgramSettingsCheckBox
			// 
			this.SaveProgramSettingsCheckBox.AutoSize = true;
			this.SaveProgramSettingsCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.SaveProgramSettings;
			this.SaveProgramSettingsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.SaveProgramSettingsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "SaveProgramSettings", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.SaveProgramSettingsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.SaveProgramSettingsCheckBox.Location = new System.Drawing.Point(6, 91);
			this.SaveProgramSettingsCheckBox.Name = "SaveProgramSettingsCheckBox";
			this.SaveProgramSettingsCheckBox.Size = new System.Drawing.Size(171, 18);
			this.SaveProgramSettingsCheckBox.TabIndex = 67;
			this.SaveProgramSettingsCheckBox.Text = "Save program settings on exit";
			this.SaveProgramSettingsCheckBox.CheckedChanged += new System.EventHandler(this.SaveProgramSettingsCheckBox_CheckedChanged);
			// 
			// ProgramStartGroupBox
			// 
			this.ProgramStartGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.ProgramStartGroupBox.Controls.Add(this.StartWithWindowsStateComboBox);
			this.ProgramStartGroupBox.Controls.Add(this.MinimizeOnCloseCheckBox);
			this.ProgramStartGroupBox.Controls.Add(this.AllowOnlyOneCopyCheckBox);
			this.ProgramStartGroupBox.Controls.Add(this.MinimizeToTrayCheckBox);
			this.ProgramStartGroupBox.Controls.Add(this.StartWithWindowsCheckBox);
			this.ProgramStartGroupBox.Controls.Add(this.AlwaysOnTopCheckBox);
			this.ProgramStartGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ProgramStartGroupBox.Location = new System.Drawing.Point(3, 253);
			this.ProgramStartGroupBox.Name = "ProgramStartGroupBox";
			this.ProgramStartGroupBox.Size = new System.Drawing.Size(137, 322);
			this.ProgramStartGroupBox.TabIndex = 104;
			this.ProgramStartGroupBox.TabStop = false;
			this.ProgramStartGroupBox.Text = "Program Start:";
			// 
			// StartWithWindowsStateComboBox
			// 
			this.StartWithWindowsStateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "StartWithWindowsState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.StartWithWindowsStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.StartWithWindowsStateComboBox.FormattingEnabled = true;
			this.StartWithWindowsStateComboBox.Items.AddRange(new object[] {
            "Maximized",
            "Normal",
            "Minimized"});
			this.StartWithWindowsStateComboBox.Location = new System.Drawing.Point(18, 43);
			this.StartWithWindowsStateComboBox.Name = "StartWithWindowsStateComboBox";
			this.StartWithWindowsStateComboBox.Size = new System.Drawing.Size(90, 21);
			this.StartWithWindowsStateComboBox.TabIndex = 93;
			this.StartWithWindowsStateComboBox.SelectedIndexChanged += new System.EventHandler(this.StartWithWindowsStateComboBox_SelectedIndexChanged);
			// 
			// MinimizeOnCloseCheckBox
			// 
			this.MinimizeOnCloseCheckBox.AutoSize = true;
			this.MinimizeOnCloseCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.MinimizeOnClose;
			this.MinimizeOnCloseCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "MinimizeOnClose", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.MinimizeOnCloseCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.MinimizeOnCloseCheckBox.Location = new System.Drawing.Point(6, 142);
			this.MinimizeOnCloseCheckBox.Name = "MinimizeOnCloseCheckBox";
			this.MinimizeOnCloseCheckBox.Size = new System.Drawing.Size(116, 18);
			this.MinimizeOnCloseCheckBox.TabIndex = 92;
			this.MinimizeOnCloseCheckBox.Text = "Minimize on Close";
			this.MinimizeOnCloseCheckBox.Visible = false;
			this.MinimizeOnCloseCheckBox.CheckedChanged += new System.EventHandler(this.MinimizeToTrayCheckBox_CheckedChanged);
			// 
			// AllowOnlyOneCopyCheckBox
			// 
			this.AllowOnlyOneCopyCheckBox.AutoSize = true;
			this.AllowOnlyOneCopyCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.AllowOnlyOneCopy;
			this.AllowOnlyOneCopyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AllowOnlyOneCopyCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "AllowOnlyOneCopy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.AllowOnlyOneCopyCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.AllowOnlyOneCopyCheckBox.Location = new System.Drawing.Point(6, 118);
			this.AllowOnlyOneCopyCheckBox.Name = "AllowOnlyOneCopyCheckBox";
			this.AllowOnlyOneCopyCheckBox.Size = new System.Drawing.Size(126, 18);
			this.AllowOnlyOneCopyCheckBox.TabIndex = 92;
			this.AllowOnlyOneCopyCheckBox.Text = "Allow only one copy";
			this.AllowOnlyOneCopyCheckBox.CheckedChanged += new System.EventHandler(this.AllowOnlyOneCopyCheckBox_CheckedChanged);
			// 
			// MinimizeToTrayCheckBox
			// 
			this.MinimizeToTrayCheckBox.AutoSize = true;
			this.MinimizeToTrayCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.MinimizeToTray;
			this.MinimizeToTrayCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MinimizeToTrayCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "MinimizeToTray", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.MinimizeToTrayCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.MinimizeToTrayCheckBox.Location = new System.Drawing.Point(6, 94);
			this.MinimizeToTrayCheckBox.Name = "MinimizeToTrayCheckBox";
			this.MinimizeToTrayCheckBox.Size = new System.Drawing.Size(108, 18);
			this.MinimizeToTrayCheckBox.TabIndex = 92;
			this.MinimizeToTrayCheckBox.Text = "Minimize to Tray";
			this.MinimizeToTrayCheckBox.CheckedChanged += new System.EventHandler(this.MinimizeToTrayCheckBox_CheckedChanged);
			// 
			// StartWithWindowsCheckBox
			// 
			this.StartWithWindowsCheckBox.AutoSize = true;
			this.StartWithWindowsCheckBox.Checked = true;
			this.StartWithWindowsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.StartWithWindowsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.StartWithWindowsCheckBox.Location = new System.Drawing.Point(6, 19);
			this.StartWithWindowsCheckBox.Name = "StartWithWindowsCheckBox";
			this.StartWithWindowsCheckBox.Size = new System.Drawing.Size(123, 18);
			this.StartWithWindowsCheckBox.TabIndex = 67;
			this.StartWithWindowsCheckBox.Text = "Start with Windows";
			this.StartWithWindowsCheckBox.CheckedChanged += new System.EventHandler(this.StartWithWindowsCheckBox_CheckedChanged);
			// 
			// AlwaysOnTopCheckBox
			// 
			this.AlwaysOnTopCheckBox.AutoSize = true;
			this.AlwaysOnTopCheckBox.Checked = global::JocysCom.PassMan.PassGen.Properties.Settings.Default.AlwaysOnTop;
			this.AlwaysOnTopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AlwaysOnTopCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::JocysCom.PassMan.PassGen.Properties.Settings.Default, "AlwaysOnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.AlwaysOnTopCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.AlwaysOnTopCheckBox.Location = new System.Drawing.Point(6, 70);
			this.AlwaysOnTopCheckBox.Name = "AlwaysOnTopCheckBox";
			this.AlwaysOnTopCheckBox.Size = new System.Drawing.Size(102, 18);
			this.AlwaysOnTopCheckBox.TabIndex = 91;
			this.AlwaysOnTopCheckBox.Text = "Always on Top";
			this.AlwaysOnTopCheckBox.CheckedChanged += new System.EventHandler(this.AlwaysOnTopCheckBox_CheckedChanged);
			// 
			// DataAndConfigurationGroupBox
			// 
			this.DataAndConfigurationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DataAndConfigurationGroupBox.Controls.Add(this.LocalUserFolderOpenButton);
			this.DataAndConfigurationGroupBox.Controls.Add(this.RoamingUserFolderOpenButton);
			this.DataAndConfigurationGroupBox.Controls.Add(this.AllUsersFolderOpenButton);
			this.DataAndConfigurationGroupBox.Controls.Add(this.AllUsersFolderLabel);
			this.DataAndConfigurationGroupBox.Controls.Add(this.RoamingUserFolderLabel);
			this.DataAndConfigurationGroupBox.Controls.Add(this.LocalUserFolderLabel);
			this.DataAndConfigurationGroupBox.Controls.Add(this.RoamingUserFolderTextBox);
			this.DataAndConfigurationGroupBox.Controls.Add(this.LocalUserFolderTextBox);
			this.DataAndConfigurationGroupBox.Controls.Add(this.AllUsersFolderTextBox);
			this.DataAndConfigurationGroupBox.Location = new System.Drawing.Point(3, 3);
			this.DataAndConfigurationGroupBox.Name = "DataAndConfigurationGroupBox";
			this.DataAndConfigurationGroupBox.Size = new System.Drawing.Size(517, 138);
			this.DataAndConfigurationGroupBox.TabIndex = 105;
			this.DataAndConfigurationGroupBox.TabStop = false;
			this.DataAndConfigurationGroupBox.Text = "Data and Configuration Folders:";
			// 
			// LocalUserFolderOpenButton
			// 
			this.LocalUserFolderOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LocalUserFolderOpenButton.Location = new System.Drawing.Point(436, 108);
			this.LocalUserFolderOpenButton.Name = "LocalUserFolderOpenButton";
			this.LocalUserFolderOpenButton.Size = new System.Drawing.Size(75, 23);
			this.LocalUserFolderOpenButton.TabIndex = 93;
			this.LocalUserFolderOpenButton.Text = "Open...";
			this.LocalUserFolderOpenButton.UseVisualStyleBackColor = true;
			this.LocalUserFolderOpenButton.Click += new System.EventHandler(this.LocalUserFolderOpenButton_Click);
			// 
			// RoamingUserFolderOpenButton
			// 
			this.RoamingUserFolderOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RoamingUserFolderOpenButton.Location = new System.Drawing.Point(436, 69);
			this.RoamingUserFolderOpenButton.Name = "RoamingUserFolderOpenButton";
			this.RoamingUserFolderOpenButton.Size = new System.Drawing.Size(75, 23);
			this.RoamingUserFolderOpenButton.TabIndex = 93;
			this.RoamingUserFolderOpenButton.Text = "Open...";
			this.RoamingUserFolderOpenButton.UseVisualStyleBackColor = true;
			this.RoamingUserFolderOpenButton.Click += new System.EventHandler(this.RoamingUserFolderOpenButton_Click);
			// 
			// AllUsersFolderOpenButton
			// 
			this.AllUsersFolderOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.AllUsersFolderOpenButton.Location = new System.Drawing.Point(436, 30);
			this.AllUsersFolderOpenButton.Name = "AllUsersFolderOpenButton";
			this.AllUsersFolderOpenButton.Size = new System.Drawing.Size(75, 23);
			this.AllUsersFolderOpenButton.TabIndex = 93;
			this.AllUsersFolderOpenButton.Text = "Open...";
			this.AllUsersFolderOpenButton.UseVisualStyleBackColor = true;
			this.AllUsersFolderOpenButton.Click += new System.EventHandler(this.AllUsersFolderOpenButton_Click);
			// 
			// AllUsersFolderLabel
			// 
			this.AllUsersFolderLabel.AutoSize = true;
			this.AllUsersFolderLabel.Location = new System.Drawing.Point(6, 16);
			this.AllUsersFolderLabel.Name = "AllUsersFolderLabel";
			this.AllUsersFolderLabel.Size = new System.Drawing.Size(216, 13);
			this.AllUsersFolderLabel.TabIndex = 92;
			this.AllUsersFolderLabel.Text = "All Users - apply to all users of an application";
			// 
			// RoamingUserFolderLabel
			// 
			this.RoamingUserFolderLabel.AutoSize = true;
			this.RoamingUserFolderLabel.Location = new System.Drawing.Point(6, 55);
			this.RoamingUserFolderLabel.Name = "RoamingUserFolderLabel";
			this.RoamingUserFolderLabel.Size = new System.Drawing.Size(343, 13);
			this.RoamingUserFolderLabel.TabIndex = 92;
			this.RoamingUserFolderLabel.Text = "Current User (Roaming) - follow the user to any computer in the network";
			// 
			// LocalUserFolderLabel
			// 
			this.LocalUserFolderLabel.AutoSize = true;
			this.LocalUserFolderLabel.Location = new System.Drawing.Point(6, 94);
			this.LocalUserFolderLabel.Name = "LocalUserFolderLabel";
			this.LocalUserFolderLabel.Size = new System.Drawing.Size(288, 13);
			this.LocalUserFolderLabel.TabIndex = 92;
			this.LocalUserFolderLabel.Text = "Current User (Local) - local to the user on this computer only";
			// 
			// RoamingUserFolderTextBox
			// 
			this.RoamingUserFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RoamingUserFolderTextBox.Location = new System.Drawing.Point(6, 71);
			this.RoamingUserFolderTextBox.Name = "RoamingUserFolderTextBox";
			this.RoamingUserFolderTextBox.ReadOnly = true;
			this.RoamingUserFolderTextBox.Size = new System.Drawing.Size(424, 20);
			this.RoamingUserFolderTextBox.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.FavPreset3ComboBox);
			this.groupBox1.Controls.Add(this.FavPreset2ComboBox);
			this.groupBox1.Controls.Add(this.FavPreset1ComboBox);
			this.groupBox1.Controls.Add(this.FavPreset3TextBox);
			this.groupBox1.Controls.Add(this.FavPreset2TextBox);
			this.groupBox1.Controls.Add(this.FavPreset1TextBox);
			this.groupBox1.Location = new System.Drawing.Point(3, 147);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(517, 100);
			this.groupBox1.TabIndex = 108;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Favorite Presets:";
			// 
			// FavPreset3ComboBox
			// 
			this.FavPreset3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FavPreset3ComboBox.FormattingEnabled = true;
			this.FavPreset3ComboBox.Location = new System.Drawing.Point(68, 73);
			this.FavPreset3ComboBox.Name = "FavPreset3ComboBox";
			this.FavPreset3ComboBox.Size = new System.Drawing.Size(180, 21);
			this.FavPreset3ComboBox.TabIndex = 1;
			this.FavPreset3ComboBox.SelectedIndexChanged += new System.EventHandler(this.FavPreset3ComboBox_SelectedIndexChanged);
			// 
			// FavPreset2ComboBox
			// 
			this.FavPreset2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FavPreset2ComboBox.FormattingEnabled = true;
			this.FavPreset2ComboBox.Location = new System.Drawing.Point(68, 46);
			this.FavPreset2ComboBox.Name = "FavPreset2ComboBox";
			this.FavPreset2ComboBox.Size = new System.Drawing.Size(180, 21);
			this.FavPreset2ComboBox.TabIndex = 1;
			this.FavPreset2ComboBox.SelectedIndexChanged += new System.EventHandler(this.FavPreset2ComboBox_SelectedIndexChanged);
			// 
			// FavPreset1ComboBox
			// 
			this.FavPreset1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FavPreset1ComboBox.FormattingEnabled = true;
			this.FavPreset1ComboBox.Location = new System.Drawing.Point(68, 19);
			this.FavPreset1ComboBox.Name = "FavPreset1ComboBox";
			this.FavPreset1ComboBox.Size = new System.Drawing.Size(180, 21);
			this.FavPreset1ComboBox.TabIndex = 1;
			this.FavPreset1ComboBox.SelectedIndexChanged += new System.EventHandler(this.FavPreset1ComboBox_SelectedIndexChanged);
			// 
			// FavPreset3TextBox
			// 
			this.FavPreset3TextBox.Location = new System.Drawing.Point(6, 73);
			this.FavPreset3TextBox.Name = "FavPreset3TextBox";
			this.FavPreset3TextBox.Size = new System.Drawing.Size(56, 20);
			this.FavPreset3TextBox.TabIndex = 0;
			this.FavPreset3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FavPreset3TextBox.TextChanged += new System.EventHandler(this.FavPreset3TextBox_Changed);
			// 
			// FavPreset2TextBox
			// 
			this.FavPreset2TextBox.Location = new System.Drawing.Point(6, 46);
			this.FavPreset2TextBox.Name = "FavPreset2TextBox";
			this.FavPreset2TextBox.Size = new System.Drawing.Size(56, 20);
			this.FavPreset2TextBox.TabIndex = 0;
			this.FavPreset2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FavPreset2TextBox.TextChanged += new System.EventHandler(this.FavPreset2TextBox_Changed);
			// 
			// FavPreset1TextBox
			// 
			this.FavPreset1TextBox.Location = new System.Drawing.Point(6, 19);
			this.FavPreset1TextBox.Name = "FavPreset1TextBox";
			this.FavPreset1TextBox.Size = new System.Drawing.Size(56, 20);
			this.FavPreset1TextBox.TabIndex = 0;
			this.FavPreset1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.FavPreset1TextBox.TextChanged += new System.EventHandler(this.FavPreset1TextBox_Changed);
			// 
			// OptionsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.DataAndConfigurationGroupBox);
			this.Controls.Add(this.ProgramStartGroupBox);
			this.Controls.Add(this.AutoOptionsGroupBox);
			this.Name = "OptionsControl";
			this.Size = new System.Drawing.Size(523, 578);
			this.AutoOptionsGroupBox.ResumeLayout(false);
			this.AutoOptionsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudAutoGenerateTimerSeconds)).EndInit();
			this.ProgramStartGroupBox.ResumeLayout(false);
			this.ProgramStartGroupBox.PerformLayout();
			this.DataAndConfigurationGroupBox.ResumeLayout(false);
			this.DataAndConfigurationGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.CheckBox GeneratePasswordOnStartCheckBox;
		internal System.Windows.Forms.CheckBox MinimizeToTrayCheckBox;
		internal System.Windows.Forms.CheckBox AlwaysOnTopCheckBox;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		internal System.Windows.Forms.GroupBox AutoOptionsGroupBox;
		internal System.Windows.Forms.NumericUpDown nudAutoGenerateTimerSeconds;
		internal System.Windows.Forms.CheckBox GenerateOnCopyCheckBox;
		internal System.Windows.Forms.CheckBox CopyOnGenerateCheckBox;
		internal System.Windows.Forms.CheckBox OpenPasswordListFileAfterSaveCheckBox;
		internal System.Windows.Forms.CheckBox GenerateTimerCheckBox;
		internal System.Windows.Forms.CheckBox SaveProgramSettingsCheckBox;
		internal System.Windows.Forms.GroupBox ProgramStartGroupBox;
		internal System.Windows.Forms.GroupBox DataAndConfigurationGroupBox;
		private System.Windows.Forms.Label AllUsersFolderLabel;
		private System.Windows.Forms.Label LocalUserFolderLabel;
		private System.Windows.Forms.Label RoamingUserFolderLabel;
		public System.Windows.Forms.CheckBox AllowOnlyOneCopyCheckBox;
		public System.Windows.Forms.ComboBox StartWithWindowsStateComboBox;
		public System.Windows.Forms.CheckBox StartWithWindowsCheckBox;
		public System.Windows.Forms.CheckBox MinimizeOnCloseCheckBox;
		private System.Windows.Forms.Button LocalUserFolderOpenButton;
		private System.Windows.Forms.Button RoamingUserFolderOpenButton;
		private System.Windows.Forms.Button AllUsersFolderOpenButton;
		public System.Windows.Forms.TextBox AllUsersFolderTextBox;
		public System.Windows.Forms.TextBox LocalUserFolderTextBox;
		public System.Windows.Forms.TextBox RoamingUserFolderTextBox;
		private System.Windows.Forms.Button ResetButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.TextBox FavPreset1TextBox;
		public System.Windows.Forms.TextBox FavPreset3TextBox;
		public System.Windows.Forms.TextBox FavPreset2TextBox;
		public System.Windows.Forms.ComboBox FavPreset3ComboBox;
		public System.Windows.Forms.ComboBox FavPreset2ComboBox;
		public System.Windows.Forms.ComboBox FavPreset1ComboBox;
		internal System.Windows.Forms.CheckBox CopyPasswordWhenStartCheckBox;
	}
}
