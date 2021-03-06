﻿namespace JocysCom.Password.Generator
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.ImageList16 = new System.Windows.Forms.ImageList(this.components);
			this.TopPanel = new System.Windows.Forms.Panel();
			this.HelpBodyLabel = new System.Windows.Forms.Label();
			this.PictureBox2 = new System.Windows.Forms.PictureBox();
			this.labHelpSubject = new System.Windows.Forms.Label();
			this.HeaderPictureBox = new System.Windows.Forms.PictureBox();
			this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.MainStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.LeftToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.TrayNotifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.OpenGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AlwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MinimizeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StartWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.Preset1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Preset2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Preset3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.ClickControlTimer = new System.Windows.Forms.Timer(this.components);
			this.NotifyIconTimer = new System.Windows.Forms.Timer(this.components);
			this.ImageList48 = new System.Windows.Forms.ImageList(this.components);
			this.MainTabControl = new System.Windows.Forms.TabControl();
			this.GeneratorTabPage = new System.Windows.Forms.TabPage();
			this.GeneratorPanel = new JocysCom.Password.Generator.Controls.GeneratorControl();
			this.ScriptTabPage = new System.Windows.Forms.TabPage();
			this.ScriptPanel = new JocysCom.ClassLibrary.Controls.DynamicCompile.DcControl();
			this.OptionsTabPage = new System.Windows.Forms.TabPage();
			this.OptionsPanel = new JocysCom.Password.Generator.Controls.OptionsControl();
			this.AboutTabPage = new System.Windows.Forms.TabPage();
			this.AboutPanel = new JocysCom.Password.Generator.Controls.AboutControl();
			this.ResourcesTabPage = new System.Windows.Forms.TabPage();
			this.resorcesControl1 = new JocysCom.Password.Generator.Controls.ResorcesControl();
			this.TopPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HeaderPictureBox)).BeginInit();
			this.TrayNotifyIconContextMenuStrip.SuspendLayout();
			this.MainTabControl.SuspendLayout();
			this.GeneratorTabPage.SuspendLayout();
			this.ScriptTabPage.SuspendLayout();
			this.OptionsTabPage.SuspendLayout();
			this.AboutTabPage.SuspendLayout();
			this.ResourcesTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// ImageList16
			// 
			this.ImageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList16.ImageStream")));
			this.ImageList16.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageList16.Images.SetKeyName(0, "generator_16x16.png");
			this.ImageList16.Images.SetKeyName(1, "script_16x16.png");
			this.ImageList16.Images.SetKeyName(2, "options_16x16.png");
			this.ImageList16.Images.SetKeyName(3, "about_16x16.png");
			// 
			// TopPanel
			// 
			this.TopPanel.BackColor = System.Drawing.SystemColors.Info;
			this.TopPanel.Controls.Add(this.HelpBodyLabel);
			this.TopPanel.Controls.Add(this.PictureBox2);
			this.TopPanel.Controls.Add(this.labHelpSubject);
			this.TopPanel.Controls.Add(this.HeaderPictureBox);
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPanel.Location = new System.Drawing.Point(0, 0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(694, 64);
			this.TopPanel.TabIndex = 2;
			// 
			// HelpBodyLabel
			// 
			this.HelpBodyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.HelpBodyLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.HelpBodyLabel.Location = new System.Drawing.Point(42, 29);
			this.HelpBodyLabel.Name = "HelpBodyLabel";
			this.HelpBodyLabel.Size = new System.Drawing.Size(592, 32);
			this.HelpBodyLabel.TabIndex = 7;
			this.HelpBodyLabel.Text = "[HelpDescriptionShort]";
			// 
			// PictureBox2
			// 
			this.PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox2.Image")));
			this.PictureBox2.Location = new System.Drawing.Point(6, 29);
			this.PictureBox2.Name = "PictureBox2";
			this.PictureBox2.Size = new System.Drawing.Size(24, 24);
			this.PictureBox2.TabIndex = 8;
			this.PictureBox2.TabStop = false;
			// 
			// labHelpSubject
			// 
			this.labHelpSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labHelpSubject.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.labHelpSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labHelpSubject.Location = new System.Drawing.Point(6, 9);
			this.labHelpSubject.Name = "labHelpSubject";
			this.labHelpSubject.Size = new System.Drawing.Size(628, 20);
			this.labHelpSubject.TabIndex = 5;
			this.labHelpSubject.Text = "Welcome to Jocys.com Password Generator";
			// 
			// HeaderPictureBox
			// 
			this.HeaderPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.HeaderPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("HeaderPictureBox.Image")));
			this.HeaderPictureBox.Location = new System.Drawing.Point(640, 9);
			this.HeaderPictureBox.Name = "HeaderPictureBox";
			this.HeaderPictureBox.Size = new System.Drawing.Size(48, 48);
			this.HeaderPictureBox.TabIndex = 6;
			this.HeaderPictureBox.TabStop = false;
			// 
			// MainStatusStrip
			// 
			this.MainStatusStrip.Location = new System.Drawing.Point(0, 649);
			this.MainStatusStrip.Name = "MainStatusStrip";
			this.MainStatusStrip.Size = new System.Drawing.Size(694, 22);
			this.MainStatusStrip.TabIndex = 3;
			this.MainStatusStrip.Text = "statusStrip1";
			// 
			// MainStripStatusLabel
			// 
			this.MainStripStatusLabel.Name = "MainStripStatusLabel";
			this.MainStripStatusLabel.Size = new System.Drawing.Size(126, 17);
			this.MainStripStatusLabel.Text = "[MainStripStatusLabel]";
			// 
			// LeftToolStripStatusLabel
			// 
			this.LeftToolStripStatusLabel.Name = "LeftToolStripStatusLabel";
			this.LeftToolStripStatusLabel.Size = new System.Drawing.Size(22, 17);
			this.LeftToolStripStatusLabel.Text = "     ";
			// 
			// TrayNotifyIconContextMenuStrip
			// 
			this.TrayNotifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenGeneratorToolStripMenuItem,
            this.toolStripSeparator3,
            this.OptionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.Preset1ToolStripMenuItem,
            this.Preset2ToolStripMenuItem,
            this.Preset3ToolStripMenuItem,
            this.toolStripSeparator2,
            this.ExitToolStripMenuItem});
			this.TrayNotifyIconContextMenuStrip.Name = "NotifyIconContextMenuStrip";
			this.TrayNotifyIconContextMenuStrip.Size = new System.Drawing.Size(166, 154);
			// 
			// OpenGeneratorToolStripMenuItem
			// 
			this.OpenGeneratorToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OpenGeneratorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenGeneratorToolStripMenuItem.Image")));
			this.OpenGeneratorToolStripMenuItem.Name = "OpenGeneratorToolStripMenuItem";
			this.OpenGeneratorToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.OpenGeneratorToolStripMenuItem.Text = "Open Generator";
			this.OpenGeneratorToolStripMenuItem.Click += new System.EventHandler(this.OpenApplicationToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
			// 
			// OptionsToolStripMenuItem
			// 
			this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AlwaysOnTopToolStripMenuItem,
            this.MinimizeToTrayToolStripMenuItem,
            this.StartWithWindowsToolStripMenuItem});
			this.OptionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OptionsToolStripMenuItem.Image")));
			this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
			this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.OptionsToolStripMenuItem.Text = "Options";
			this.OptionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
			// 
			// AlwaysOnTopToolStripMenuItem
			// 
			this.AlwaysOnTopToolStripMenuItem.Name = "AlwaysOnTopToolStripMenuItem";
			this.AlwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.AlwaysOnTopToolStripMenuItem.Text = "Always on Top";
			this.AlwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.AlwaysOnTopToolStripMenuItem_Click);
			// 
			// MinimizeToTrayToolStripMenuItem
			// 
			this.MinimizeToTrayToolStripMenuItem.Name = "MinimizeToTrayToolStripMenuItem";
			this.MinimizeToTrayToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.MinimizeToTrayToolStripMenuItem.Text = "Minimize to Tray";
			// 
			// StartWithWindowsToolStripMenuItem
			// 
			this.StartWithWindowsToolStripMenuItem.Name = "StartWithWindowsToolStripMenuItem";
			this.StartWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.StartWithWindowsToolStripMenuItem.Text = "Start with Windows";
			this.StartWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.StartWithWindowsToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
			// 
			// Preset1ToolStripMenuItem
			// 
			this.Preset1ToolStripMenuItem.Checked = true;
			this.Preset1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.Preset1ToolStripMenuItem.Name = "Preset1ToolStripMenuItem";
			this.Preset1ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.Preset1ToolStripMenuItem.Text = "Fav1";
			// 
			// Preset2ToolStripMenuItem
			// 
			this.Preset2ToolStripMenuItem.Name = "Preset2ToolStripMenuItem";
			this.Preset2ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.Preset2ToolStripMenuItem.Text = "Fav2";
			// 
			// Preset3ToolStripMenuItem
			// 
			this.Preset3ToolStripMenuItem.Name = "Preset3ToolStripMenuItem";
			this.Preset3ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.Preset3ToolStripMenuItem.Text = "Fav3";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
			// 
			// ExitToolStripMenuItem
			// 
			this.ExitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExitToolStripMenuItem.Image")));
			this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			this.ExitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.ExitToolStripMenuItem.Text = "Exit";
			this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// TrayNotifyIcon
			// 
			this.TrayNotifyIcon.ContextMenuStrip = this.TrayNotifyIconContextMenuStrip;
			this.TrayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayNotifyIcon.Icon")));
			this.TrayNotifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDown);
			// 
			// ClickControlTimer
			// 
			this.ClickControlTimer.Tick += new System.EventHandler(this.ClickControlTimer_Tick);
			// 
			// NotifyIconTimer
			// 
			this.NotifyIconTimer.Interval = 300;
			this.NotifyIconTimer.Tick += new System.EventHandler(this.NotifyIconTimer_Tick);
			// 
			// ImageList48
			// 
			this.ImageList48.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList48.ImageStream")));
			this.ImageList48.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageList48.Images.SetKeyName(0, "generator_48x48.png");
			this.ImageList48.Images.SetKeyName(1, "script_48x48.png");
			this.ImageList48.Images.SetKeyName(2, "options_48x48.png");
			this.ImageList48.Images.SetKeyName(3, "about_48x48.png");
			// 
			// MainTabControl
			// 
			this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainTabControl.Controls.Add(this.GeneratorTabPage);
			this.MainTabControl.Controls.Add(this.ScriptTabPage);
			this.MainTabControl.Controls.Add(this.OptionsTabPage);
			this.MainTabControl.Controls.Add(this.AboutTabPage);
			this.MainTabControl.Controls.Add(this.ResourcesTabPage);
			this.MainTabControl.ImageList = this.ImageList16;
			this.MainTabControl.Location = new System.Drawing.Point(6, 70);
			this.MainTabControl.Name = "MainTabControl";
			this.MainTabControl.SelectedIndex = 0;
			this.MainTabControl.Size = new System.Drawing.Size(682, 576);
			this.MainTabControl.TabIndex = 4;
			// 
			// GeneratorTabPage
			// 
			this.GeneratorTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.GeneratorTabPage.Controls.Add(this.GeneratorPanel);
			this.GeneratorTabPage.ImageKey = "generator_16x16.png";
			this.GeneratorTabPage.Location = new System.Drawing.Point(4, 23);
			this.GeneratorTabPage.Name = "GeneratorTabPage";
			this.GeneratorTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.GeneratorTabPage.Size = new System.Drawing.Size(674, 549);
			this.GeneratorTabPage.TabIndex = 0;
			this.GeneratorTabPage.Text = "Generator";
			// 
			// GeneratorPanel
			// 
			this.GeneratorPanel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.GeneratorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GeneratorPanel.Location = new System.Drawing.Point(3, 3);
			this.GeneratorPanel.Name = "GeneratorPanel";
			this.GeneratorPanel.Size = new System.Drawing.Size(668, 543);
			this.GeneratorPanel.TabIndex = 0;
			// 
			// ScriptTabPage
			// 
			this.ScriptTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.ScriptTabPage.Controls.Add(this.ScriptPanel);
			this.ScriptTabPage.ImageKey = "script_16x16.png";
			this.ScriptTabPage.Location = new System.Drawing.Point(4, 23);
			this.ScriptTabPage.Name = "ScriptTabPage";
			this.ScriptTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.ScriptTabPage.Size = new System.Drawing.Size(674, 563);
			this.ScriptTabPage.TabIndex = 3;
			this.ScriptTabPage.Text = "Script";
			// 
			// ScriptPanel
			// 
			this.ScriptPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ScriptPanel.Location = new System.Drawing.Point(3, 3);
			this.ScriptPanel.Name = "ScriptPanel";
			this.ScriptPanel.Size = new System.Drawing.Size(668, 557);
			this.ScriptPanel.TabIndex = 0;
			// 
			// OptionsTabPage
			// 
			this.OptionsTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.OptionsTabPage.Controls.Add(this.OptionsPanel);
			this.OptionsTabPage.ImageKey = "options_16x16.png";
			this.OptionsTabPage.Location = new System.Drawing.Point(4, 23);
			this.OptionsTabPage.Name = "OptionsTabPage";
			this.OptionsTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.OptionsTabPage.Size = new System.Drawing.Size(674, 563);
			this.OptionsTabPage.TabIndex = 1;
			this.OptionsTabPage.Text = "Options";
			// 
			// OptionsPanel
			// 
			this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OptionsPanel.Location = new System.Drawing.Point(3, 3);
			this.OptionsPanel.Name = "OptionsPanel";
			this.OptionsPanel.Size = new System.Drawing.Size(668, 557);
			this.OptionsPanel.TabIndex = 0;
			// 
			// AboutTabPage
			// 
			this.AboutTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.AboutTabPage.Controls.Add(this.AboutPanel);
			this.AboutTabPage.ImageKey = "about_16x16.png";
			this.AboutTabPage.Location = new System.Drawing.Point(4, 23);
			this.AboutTabPage.Name = "AboutTabPage";
			this.AboutTabPage.Size = new System.Drawing.Size(674, 563);
			this.AboutTabPage.TabIndex = 2;
			this.AboutTabPage.Text = "About";
			// 
			// AboutPanel
			// 
			this.AboutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AboutPanel.Location = new System.Drawing.Point(0, 0);
			this.AboutPanel.Name = "AboutPanel";
			this.AboutPanel.Size = new System.Drawing.Size(674, 563);
			this.AboutPanel.TabIndex = 0;
			// 
			// ResourcesTabPage
			// 
			this.ResourcesTabPage.BackColor = System.Drawing.SystemColors.Control;
			this.ResourcesTabPage.Controls.Add(this.resorcesControl1);
			this.ResourcesTabPage.Location = new System.Drawing.Point(4, 23);
			this.ResourcesTabPage.Name = "ResourcesTabPage";
			this.ResourcesTabPage.Size = new System.Drawing.Size(674, 563);
			this.ResourcesTabPage.TabIndex = 4;
			this.ResourcesTabPage.Text = "Resources";
			// 
			// resorcesControl1
			// 
			this.resorcesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resorcesControl1.Location = new System.Drawing.Point(0, 0);
			this.resorcesControl1.Name = "resorcesControl1";
			this.resorcesControl1.Size = new System.Drawing.Size(674, 563);
			this.resorcesControl1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(694, 671);
			this.Controls.Add(this.MainTabControl);
			this.Controls.Add(this.MainStatusStrip);
			this.Controls.Add(this.TopPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Jocys.com Password Generator";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.TopPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HeaderPictureBox)).EndInit();
			this.TrayNotifyIconContextMenuStrip.ResumeLayout(false);
			this.MainTabControl.ResumeLayout(false);
			this.GeneratorTabPage.ResumeLayout(false);
			this.ScriptTabPage.ResumeLayout(false);
			this.OptionsTabPage.ResumeLayout(false);
			this.AboutTabPage.ResumeLayout(false);
			this.ResourcesTabPage.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ImageList ImageList16;
		private System.Windows.Forms.Panel TopPanel;
		internal System.Windows.Forms.PictureBox PictureBox2;
		internal System.Windows.Forms.Label HelpBodyLabel;
		internal System.Windows.Forms.Label labHelpSubject;
		internal System.Windows.Forms.PictureBox HeaderPictureBox;
		private System.Windows.Forms.ToolStripMenuItem OpenGeneratorToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
		public System.Windows.Forms.ContextMenuStrip TrayNotifyIconContextMenuStrip;
		public System.Windows.Forms.ToolStripMenuItem AlwaysOnTopToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem MinimizeToTrayToolStripMenuItem;
		public System.Windows.Forms.NotifyIcon TrayNotifyIcon;
		public System.Windows.Forms.ToolStripMenuItem StartWithWindowsToolStripMenuItem;
		private System.Windows.Forms.Timer ClickControlTimer;
		private System.Windows.Forms.Timer NotifyIconTimer;
		public System.Windows.Forms.StatusStrip MainStatusStrip;
		public System.Windows.Forms.ToolStripStatusLabel LeftToolStripStatusLabel;
		private System.Windows.Forms.ImageList ImageList48;
		public System.Windows.Forms.ToolStripStatusLabel MainStripStatusLabel;
		private System.Windows.Forms.TabControl MainTabControl;
		private System.Windows.Forms.TabPage GeneratorTabPage;
		private System.Windows.Forms.TabPage OptionsTabPage;
		private System.Windows.Forms.TabPage AboutTabPage;
		private System.Windows.Forms.TabPage ScriptTabPage;
		public ClassLibrary.Controls.DynamicCompile.DcControl ScriptPanel;
		public Controls.OptionsControl OptionsPanel;
		public Controls.AboutControl AboutPanel;
		public Controls.GeneratorControl GeneratorPanel;
		public System.Windows.Forms.ToolStripMenuItem Preset1ToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem Preset2ToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem Preset3ToolStripMenuItem;
		private System.Windows.Forms.TabPage ResourcesTabPage;
		private Controls.ResorcesControl resorcesControl1;
	}
}

