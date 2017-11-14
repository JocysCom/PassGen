namespace JocysCom.ClassLibrary.Controls.DynamicCompile
{
	partial class DcControl
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DcControl));
			this.DataTempFolderLabel = new System.Windows.Forms.Label();
			this.CodeTextBox = new System.Windows.Forms.TextBox();
			this.OpenCodeFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.CodeFileSystemWatcher = new System.IO.FileSystemWatcher();
			this.OutputTextBox = new System.Windows.Forms.TextBox();
			this.RunTimer = new System.Windows.Forms.Timer(this.components);
			this.ResultsTabControl = new System.Windows.Forms.TabControl();
			this.OutputTabPage = new System.Windows.Forms.TabPage();
			this.OutputDataGridView = new System.Windows.Forms.DataGridView();
			this.ErrorsTabPage = new System.Windows.Forms.TabPage();
			this.ErrorsTextBox = new System.Windows.Forms.TextBox();
			this.CodeTabPage = new System.Windows.Forms.TabPage();
			this.CodeLineTextBox = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.MainToolStrip = new System.Windows.Forms.ToolStrip();
			this.OpenToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.SaveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ReloadToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.AutoLoadToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.AutoRunToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.LanguageToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.CheckToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.EntryToolStripLabel = new System.Windows.Forms.ToolStripLabel();
			this.EntryToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
			this.RunToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.ChangedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.LoadedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.FileToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.CodeFileSystemWatcher)).BeginInit();
			this.ResultsTabControl.SuspendLayout();
			this.OutputTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.OutputDataGridView)).BeginInit();
			this.ErrorsTabPage.SuspendLayout();
			this.CodeTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.MainToolStrip.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DataTempFolderLabel
			// 
			this.DataTempFolderLabel.AutoSize = true;
			this.DataTempFolderLabel.Location = new System.Drawing.Point(-185, 181);
			this.DataTempFolderLabel.Name = "DataTempFolderLabel";
			this.DataTempFolderLabel.Size = new System.Drawing.Size(69, 13);
			this.DataTempFolderLabel.TabIndex = 31;
			this.DataTempFolderLabel.Text = "Temp Folder:";
			// 
			// CodeTextBox
			// 
			this.CodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CodeTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CodeTextBox.Location = new System.Drawing.Point(0, 0);
			this.CodeTextBox.Multiline = true;
			this.CodeTextBox.Name = "CodeTextBox";
			this.CodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.CodeTextBox.Size = new System.Drawing.Size(804, 158);
			this.CodeTextBox.TabIndex = 32;
			// 
			// CodeFileSystemWatcher
			// 
			this.CodeFileSystemWatcher.EnableRaisingEvents = true;
			this.CodeFileSystemWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
			this.CodeFileSystemWatcher.SynchronizingObject = this;
			this.CodeFileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.CodeFileSystemWatcher_Changed);
			// 
			// OutputTextBox
			// 
			this.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.OutputTextBox.Location = new System.Drawing.Point(6, 6);
			this.OutputTextBox.Multiline = true;
			this.OutputTextBox.Name = "OutputTextBox";
			this.OutputTextBox.ReadOnly = true;
			this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.OutputTextBox.Size = new System.Drawing.Size(356, 117);
			this.OutputTextBox.TabIndex = 32;
			this.OutputTextBox.TextChanged += new System.EventHandler(this.OutputTextBox_TextChanged);
			// 
			// RunTimer
			// 
			this.RunTimer.Interval = 1000;
			this.RunTimer.Tick += new System.EventHandler(this.RunTimer_Tick);
			// 
			// ResultsTabControl
			// 
			this.ResultsTabControl.Controls.Add(this.OutputTabPage);
			this.ResultsTabControl.Controls.Add(this.ErrorsTabPage);
			this.ResultsTabControl.Controls.Add(this.CodeTabPage);
			this.ResultsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ResultsTabControl.Location = new System.Drawing.Point(0, 0);
			this.ResultsTabControl.Name = "ResultsTabControl";
			this.ResultsTabControl.SelectedIndex = 0;
			this.ResultsTabControl.Size = new System.Drawing.Size(804, 155);
			this.ResultsTabControl.TabIndex = 36;
			this.ResultsTabControl.SelectedIndexChanged += new System.EventHandler(this.ResultsTabControl_SelectedIndexChanged);
			// 
			// OutputTabPage
			// 
			this.OutputTabPage.Controls.Add(this.OutputDataGridView);
			this.OutputTabPage.Controls.Add(this.OutputTextBox);
			this.OutputTabPage.Location = new System.Drawing.Point(4, 22);
			this.OutputTabPage.Name = "OutputTabPage";
			this.OutputTabPage.Size = new System.Drawing.Size(796, 129);
			this.OutputTabPage.TabIndex = 0;
			this.OutputTabPage.Text = "Output";
			this.OutputTabPage.UseVisualStyleBackColor = true;
			// 
			// OutputDataGridView
			// 
			this.OutputDataGridView.AllowUserToAddRows = false;
			this.OutputDataGridView.AllowUserToDeleteRows = false;
			this.OutputDataGridView.AllowUserToOrderColumns = true;
			this.OutputDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.OutputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.OutputDataGridView.Location = new System.Drawing.Point(365, 3);
			this.OutputDataGridView.Name = "OutputDataGridView";
			this.OutputDataGridView.ReadOnly = true;
			this.OutputDataGridView.Size = new System.Drawing.Size(428, 117);
			this.OutputDataGridView.TabIndex = 36;
			// 
			// ErrorsTabPage
			// 
			this.ErrorsTabPage.Controls.Add(this.ErrorsTextBox);
			this.ErrorsTabPage.Location = new System.Drawing.Point(4, 22);
			this.ErrorsTabPage.Name = "ErrorsTabPage";
			this.ErrorsTabPage.Size = new System.Drawing.Size(796, 129);
			this.ErrorsTabPage.TabIndex = 2;
			this.ErrorsTabPage.Text = "Errors";
			this.ErrorsTabPage.UseVisualStyleBackColor = true;
			// 
			// ErrorsTextBox
			// 
			this.ErrorsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ErrorsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ErrorsTextBox.Location = new System.Drawing.Point(0, 0);
			this.ErrorsTextBox.Multiline = true;
			this.ErrorsTextBox.Name = "ErrorsTextBox";
			this.ErrorsTextBox.ReadOnly = true;
			this.ErrorsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ErrorsTextBox.Size = new System.Drawing.Size(796, 129);
			this.ErrorsTextBox.TabIndex = 33;
			this.ErrorsTextBox.TextChanged += new System.EventHandler(this.ErrorsTextBox_TextChanged);
			// 
			// CodeTabPage
			// 
			this.CodeTabPage.Controls.Add(this.CodeLineTextBox);
			this.CodeTabPage.Location = new System.Drawing.Point(4, 22);
			this.CodeTabPage.Name = "CodeTabPage";
			this.CodeTabPage.Size = new System.Drawing.Size(796, 129);
			this.CodeTabPage.TabIndex = 3;
			this.CodeTabPage.Text = "Code";
			this.CodeTabPage.UseVisualStyleBackColor = true;
			// 
			// CodeLineTextBox
			// 
			this.CodeLineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.CodeLineTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CodeLineTextBox.Location = new System.Drawing.Point(0, 0);
			this.CodeLineTextBox.Multiline = true;
			this.CodeLineTextBox.Name = "CodeLineTextBox";
			this.CodeLineTextBox.ReadOnly = true;
			this.CodeLineTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.CodeLineTextBox.Size = new System.Drawing.Size(796, 129);
			this.CodeLineTextBox.TabIndex = 33;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(3, 28);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.CodeTextBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.ResultsTabControl);
			this.splitContainer1.Size = new System.Drawing.Size(804, 317);
			this.splitContainer1.SplitterDistance = 158;
			this.splitContainer1.TabIndex = 37;
			// 
			// MainToolStrip
			// 
			this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripButton,
            this.SaveToolStripButton,
            this.ReloadToolStripButton,
            this.toolStripSeparator3,
            this.AutoLoadToolStripButton,
            this.AutoRunToolStripButton,
            this.toolStripSeparator1,
            this.LanguageToolStripComboBox,
            this.CheckToolStripButton,
            this.EntryToolStripLabel,
            this.EntryToolStripComboBox,
            this.RunToolStripButton});
			this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
			this.MainToolStrip.Name = "MainToolStrip";
			this.MainToolStrip.Size = new System.Drawing.Size(810, 25);
			this.MainToolStrip.TabIndex = 38;
			// 
			// OpenToolStripButton
			// 
			this.OpenToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripButton.Image")));
			this.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OpenToolStripButton.Name = "OpenToolStripButton";
			this.OpenToolStripButton.Size = new System.Drawing.Size(56, 22);
			this.OpenToolStripButton.Text = "Open";
			this.OpenToolStripButton.Click += new System.EventHandler(this.OpenToolStripButton_Click);
			// 
			// SaveToolStripButton
			// 
			this.SaveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripButton.Image")));
			this.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SaveToolStripButton.Name = "SaveToolStripButton";
			this.SaveToolStripButton.Size = new System.Drawing.Size(51, 22);
			this.SaveToolStripButton.Text = "Save";
			this.SaveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
			// 
			// ReloadToolStripButton
			// 
			this.ReloadToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ReloadToolStripButton.Image")));
			this.ReloadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ReloadToolStripButton.Name = "ReloadToolStripButton";
			this.ReloadToolStripButton.Size = new System.Drawing.Size(63, 22);
			this.ReloadToolStripButton.Text = "Reload";
			this.ReloadToolStripButton.ToolTipText = "Reload code file";
			this.ReloadToolStripButton.Click += new System.EventHandler(this.ReloadToolStripButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// AutoLoadToolStripButton
			// 
			this.AutoLoadToolStripButton.Checked = true;
			this.AutoLoadToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AutoLoadToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AutoLoadToolStripButton.Image")));
			this.AutoLoadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AutoLoadToolStripButton.Name = "AutoLoadToolStripButton";
			this.AutoLoadToolStripButton.Size = new System.Drawing.Size(82, 22);
			this.AutoLoadToolStripButton.Text = "Auto Load";
			this.AutoLoadToolStripButton.Click += new System.EventHandler(this.AutoLoadToolStripButton_Click);
			// 
			// AutoRunToolStripButton
			// 
			this.AutoRunToolStripButton.Checked = true;
			this.AutoRunToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.AutoRunToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AutoRunToolStripButton.Image")));
			this.AutoRunToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AutoRunToolStripButton.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
			this.AutoRunToolStripButton.Name = "AutoRunToolStripButton";
			this.AutoRunToolStripButton.Size = new System.Drawing.Size(77, 22);
			this.AutoRunToolStripButton.Text = "Auto Run";
			this.AutoRunToolStripButton.Click += new System.EventHandler(this.AutoRunToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// LanguageToolStripComboBox
			// 
			this.LanguageToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LanguageToolStripComboBox.Items.AddRange(new object[] {
            "CSharp",
            "VB",
            "JScript"});
			this.LanguageToolStripComboBox.Name = "LanguageToolStripComboBox";
			this.LanguageToolStripComboBox.Size = new System.Drawing.Size(75, 25);
			this.LanguageToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageToolStripComboBox_SelectedIndexChanged);
			// 
			// CheckToolStripButton
			// 
			this.CheckToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CheckToolStripButton.Image")));
			this.CheckToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.CheckToolStripButton.Name = "CheckToolStripButton";
			this.CheckToolStripButton.Size = new System.Drawing.Size(60, 22);
			this.CheckToolStripButton.Text = "&Check";
			this.CheckToolStripButton.ToolTipText = "Check code";
			this.CheckToolStripButton.Click += new System.EventHandler(this.CheckToolStripButton_Click);
			// 
			// EntryToolStripLabel
			// 
			this.EntryToolStripLabel.Name = "EntryToolStripLabel";
			this.EntryToolStripLabel.Size = new System.Drawing.Size(37, 22);
			this.EntryToolStripLabel.Text = "Entry:";
			// 
			// EntryToolStripComboBox
			// 
			this.EntryToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.EntryToolStripComboBox.Name = "EntryToolStripComboBox";
			this.EntryToolStripComboBox.Size = new System.Drawing.Size(148, 25);
			// 
			// RunToolStripButton
			// 
			this.RunToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RunToolStripButton.Image")));
			this.RunToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RunToolStripButton.Name = "RunToolStripButton";
			this.RunToolStripButton.Size = new System.Drawing.Size(48, 22);
			this.RunToolStripButton.Text = "&Run";
			this.RunToolStripButton.ToolTipText = "Compile and run code";
			this.RunToolStripButton.Click += new System.EventHandler(this.RunToolStripButton_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangedToolStripStatusLabel,
            this.LoadedToolStripStatusLabel,
            this.FileToolStripStatusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 352);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(810, 22);
			this.statusStrip1.TabIndex = 39;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// ChangedToolStripStatusLabel
			// 
			this.ChangedToolStripStatusLabel.Name = "ChangedToolStripStatusLabel";
			this.ChangedToolStripStatusLabel.Size = new System.Drawing.Size(67, 17);
			this.ChangedToolStripStatusLabel.Text = "Changed: 0";
			// 
			// LoadedToolStripStatusLabel
			// 
			this.LoadedToolStripStatusLabel.Name = "LoadedToolStripStatusLabel";
			this.LoadedToolStripStatusLabel.Size = new System.Drawing.Size(58, 17);
			this.LoadedToolStripStatusLabel.Text = "Loaded: 0";
			// 
			// FileToolStripStatusLabel
			// 
			this.FileToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
			this.FileToolStripStatusLabel.Name = "FileToolStripStatusLabel";
			this.FileToolStripStatusLabel.Size = new System.Drawing.Size(670, 17);
			this.FileToolStripStatusLabel.Spring = true;
			this.FileToolStripStatusLabel.Text = "Path";
			this.FileToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DcControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.DataTempFolderLabel);
			this.Controls.Add(this.MainToolStrip);
			this.Name = "DcControl";
			this.Size = new System.Drawing.Size(810, 374);
			this.Load += new System.EventHandler(this.DcControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.CodeFileSystemWatcher)).EndInit();
			this.ResultsTabControl.ResumeLayout(false);
			this.OutputTabPage.ResumeLayout(false);
			this.OutputTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.OutputDataGridView)).EndInit();
			this.ErrorsTabPage.ResumeLayout(false);
			this.ErrorsTabPage.PerformLayout();
			this.CodeTabPage.ResumeLayout(false);
			this.CodeTabPage.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.MainToolStrip.ResumeLayout(false);
			this.MainToolStrip.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label DataTempFolderLabel;
		private System.Windows.Forms.OpenFileDialog OpenCodeFileDialog;
		private System.IO.FileSystemWatcher CodeFileSystemWatcher;
		private System.Windows.Forms.TextBox OutputTextBox;
		private System.Windows.Forms.Timer RunTimer;
		private System.Windows.Forms.TabControl ResultsTabControl;
		private System.Windows.Forms.TabPage OutputTabPage;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel ChangedToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel LoadedToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel FileToolStripStatusLabel;
		private System.Windows.Forms.ToolStrip MainToolStrip;
		private System.Windows.Forms.TabPage ErrorsTabPage;
		private System.Windows.Forms.DataGridView OutputDataGridView;
		public System.Windows.Forms.TextBox CodeTextBox;
		public System.Windows.Forms.ToolStripButton AutoLoadToolStripButton;
		public System.Windows.Forms.ToolStripButton AutoRunToolStripButton;
		public System.Windows.Forms.ToolStripButton ReloadToolStripButton;
		public System.Windows.Forms.ToolStripButton CheckToolStripButton;
		public System.Windows.Forms.ToolStripComboBox LanguageToolStripComboBox;
		public System.Windows.Forms.ToolStripButton SaveToolStripButton;
		public System.Windows.Forms.ToolStripButton OpenToolStripButton;
		public System.Windows.Forms.ToolStripComboBox EntryToolStripComboBox;
		public System.Windows.Forms.ToolStripButton RunToolStripButton;
        public System.Windows.Forms.TextBox ErrorsTextBox;
        private System.Windows.Forms.ToolStripLabel EntryToolStripLabel;
		private System.Windows.Forms.TabPage CodeTabPage;
		private System.Windows.Forms.TextBox CodeLineTextBox;
	}
}
