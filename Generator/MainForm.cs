﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using JocysCom.Password.Generator.Properties;
using JocysCom.ClassLibrary.Security.Password;
using Microsoft.Win32;
using JocysCom.ClassLibrary.Configuration;

namespace JocysCom.Password.Generator
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			InitMinimize();
		}

		public Label ControlHelpBodyLabel { get { return HelpBodyLabel; } }
		public Panel ControlTopPanel { get { return TopPanel; } }

		#region Controls - Pages

		private List<UserControl> _UserControls;
		private List<UserControl> UserControls
		{ get { return _UserControls = _UserControls ?? new List<UserControl>(); } }

		private T UserControlAdd<T>()
		{
			UserControl control = (UserControl)(object)Activator.CreateInstance<T>();
			control.Dock = DockStyle.Fill;
			control.Visible = false;
			UserControls.Add(control);
			return (T)(object)control;
		}

		#endregion

		object scriptsTabLock = new object();


		public void HideScriptsTabPage()
		{
			lock (scriptsTabLock)
			{
				if (MainTabControl.TabPages.Contains(ScriptTabPage))
				{
					MainTabControl.TabPages.Remove(ScriptTabPage);
				}
			}
		}

		public void ShowScriptsTabPage()
		{
			lock (scriptsTabLock)
			{
				if (!MainTabControl.TabPages.Contains(ScriptTabPage))
				{
					MainTabControl.TabPages.Insert(1, ScriptTabPage);
				}
			}
		}

		void ControlAutoRunButton_Click(object sender, EventArgs e)
		{
			var generator = GeneratorPanel.PassGen;
			ScriptPanel.Run(generator, generator.NewPassword());
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (IsDesignMode)
				return;
			if (!Program.IsDebug)
			{
				MainTabControl.TabPages.Remove(ResourcesTabPage);
			}
			MainStripStatusLabel.Text = string.Empty;
			//MainTreeView.Nodes[1].Remove();
			ConfigureMenuItems();
			//switch (WindowState)
			//{
			//	case FormWindowState.Maximized: WindowState = FormWindowState.Maximized; break;
			//	case FormWindowState.Minimized: MinimizeToTray(); Show(); break;
			//	case FormWindowState.Normal: WindowState = FormWindowState.Normal; break;
			//}
			var info = new AssemblyInfo();
			Text = info.FullTitle;
			// Select generator.
			GeneratorPanel.CallsTextBox.Focus();
			ScriptPanel.OpenToolStripButton.Visible = false;
			ScriptPanel.AutoLoadToolStripButton.Checked = false;
			ScriptPanel.AutoLoadToolStripButton.Visible = false;
			ScriptPanel.AutoRunToolStripButton.Checked = false;
			ScriptPanel.AutoRunToolStripButton.Visible = false;
			ScriptPanel.AutoStripSeparator.Visible = false;
			ScriptPanel.SupressRunDefaultFunction = true;
			ScriptPanel.RunToolStripButton.Click += new EventHandler(ControlAutoRunButton_Click);
			OptionsPanel.Initialize();
			GeneratorPanel.Initialize();
			AboutPanel.Initialize();
			SetAlwaysOnTop(Settings.Default.AlwaysOnTop);
			SetStartWithWindows(Settings.Default.StartWithWindows);
			SetStartWithWindowsState(Settings.Default.StartWithWindowsState);
			UpdateWindowsStartRegistry(Settings.Default.StartWithWindows, Settings.Default.StartWithWindowsState);
			// Add this event at the end to prevent freezing.
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			// Begin generation of password by selecting preset.
			string[] names = GeneratorPanel.Presets.Select(x => x.PresetName).ToArray();
			PassGenHelper.LoadPresets(GeneratorPanel.PresetNameComboBox, names, Settings.Default.PresetNameComboBox);
		}

		bool IsDesignMode
		{
			get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
		}

		public void ShowPage(UserControl control)
		{
			control.BringToFront();
			if (!control.Visible) control.Visible = true;
		}

		#region Options

		public bool AlwaysOnTopChanging;
		public void SetAlwaysOnTop(bool value)
		{
			if (AlwaysOnTopChanging) return;
			AlwaysOnTopChanging = true;
			AlwaysOnTopToolStripMenuItem.Checked = value;
			OptionsPanel.AlwaysOnTopCheckBox.Checked = value;
			if (Settings.Default.AlwaysOnTop != value)
			{
				Settings.Default.AlwaysOnTop = value;
			}
			TopMost = value;
			AlwaysOnTopChanging = false;
		}

		void AlwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetAlwaysOnTop(!Settings.Default.AlwaysOnTop);
		}

		public bool StartWithWindowsChanging;
		public void SetStartWithWindows(bool value)
		{
			if (StartWithWindowsChanging) return;
			StartWithWindowsChanging = true;
			// Update controls.
			StartWithWindowsToolStripMenuItem.Checked = value;
			OptionsPanel.StartWithWindowsCheckBox.Checked = value;
			// Update settings.
			if (Settings.Default.StartWithWindows != value)
			{
				Settings.Default.StartWithWindows = value;
				UpdateWindowsStartRegistry(value, Settings.Default.StartWithWindowsState);
			}
			StartWithWindowsChanging = false;
		}

		void StartWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SetStartWithWindows(!Settings.Default.StartWithWindows);
		}

		public bool StartWithWindowsStateChanging;
		public void SetStartWithWindowsState(string value)
		{
			if (StartWithWindowsStateChanging) return;
			StartWithWindowsStateChanging = true;
			// Update controls.
			OptionsPanel.StartWithWindowsStateComboBox.Text = value;
			// Update settings.
			if (Settings.Default.StartWithWindowsState != value)
			{
				UpdateWindowsStartRegistry(Settings.Default.StartWithWindows, value);
				Settings.Default.StartWithWindowsState = value;
			}
			StartWithWindowsStateChanging = false;
		}

		public void UpdateWindowsStartRegistry(bool enabled, string state)
		{
			var startState = FormWindowState.Minimized;
			Enum.TryParse<FormWindowState>(state, out startState);
			// Update controls
			StartWithWindowsToolStripMenuItem.Checked = enabled;
			OptionsPanel.StartWithWindowsCheckBox.Checked = enabled;
			var runKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			if (enabled)
			{
				// Add the value in the registry so that the application runs at start-up
				string command = string.Format("\"{0}\" /{1}={2}", Application.ExecutablePath, Program.arg_WindowState, startState.ToString());
				var value = (string)runKey.GetValue(Application.ProductName);
				if (value != command)
				{
					runKey.SetValue(Application.ProductName, command);
				}
			}
			else
			{
				if (runKey.GetValueNames().Contains(Application.ProductName))
				{
					// Remove the value from the registry so that the application doesn't start
					runKey.DeleteValue(Application.ProductName, false);
				}
			}
			runKey.Close();
		}

		#endregion

		#region Single Double Click

		private bool isFirstClick = true;
		private bool isDoubleClick = false;
		private int milliseconds = 0;

		// Detect a valid single click or double click.
		void NotifyIcon_MouseDown(object sender, MouseEventArgs e)
		{
			MouseButtons mainButton = SystemInformation.MouseButtonsSwapped
				? MouseButtons.Right
				: MouseButtons.Left;
			if (e.Button != mainButton) return;
			// This is the first mouse click.
			if (isFirstClick)
			{
				isFirstClick = false;
				// Determine the location and size of the double click 
				// rectangle area to draw around the cursor point.
				Invalidate();
				// Start the double click timer.
				ClickControlTimer.Start();
			}
			// This is the second mouse click.
			else
			{
				// Verify that the mouse click is within the double click
				// rectangle and is within the system-defined double 
				// click period.
				if (milliseconds < SystemInformation.DoubleClickTime)
				{
					isDoubleClick = true;
				}
			}
		}

		void ClickControlTimer_Tick(object sender, EventArgs e)
		{
			milliseconds += 100;
			// The timer has reached the double click time limit.
			if (milliseconds >= SystemInformation.DoubleClickTime)
			{
				ClickControlTimer.Stop();

				if (isDoubleClick)
				{
					// Perform double click action.
					RestoreFromTray(true);
				}
				else
				{
					// Perform single click action.
					IsActionEnabled = true;
					//IsActionLongEnabled = true;
					ShowTrayIcon();
					Word password = GeneratorPanel.PassGen.NewPassword();
					if (password.Text.Length > 0)
					{
						ClipboardHelper.SetClipboardText(password.Text);
					}
				}
				// Allow the MouseDown event handler to process clicks again.
				isFirstClick = true;
				isDoubleClick = false;
				milliseconds = 0;
			}
		}

		bool IsRevealerEnabled = false;
		bool IsActionEnabled = false;
		bool IsActionLongEnabled = false;

		public void ShowTrayIcon()
		{
			TrayNotifyIcon.Icon = GetTrayIcon();
			NotifyIconTimer.Interval = 300;
			NotifyIconTimer.Start();
		}


		private void NotifyIconTimer_Tick(object sender, System.EventArgs e)
		{
			NotifyIconTimer.Stop();
			IsActionEnabled = false;
			IsActionLongEnabled = false;
			TrayNotifyIcon.Icon = GetTrayIcon();
		}


		object trayIconLock = new object();
		System.Reflection.Assembly assembly;
		private System.Drawing.Icon GetTrayIcon(string iconType)
		{
			lock (trayIconLock)
			{
				assembly = System.Reflection.Assembly.GetExecutingAssembly();
				var path = assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith(".Sources.Images.TrayIcon-" + iconType + ".ico"));
				System.IO.Stream stream = assembly.GetManifestResourceStream(path);
				return new System.Drawing.Icon(stream);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		/// <remarks>Sources/Images/TrayIcon-NNNN.ico files property must be set to embedded resources.</remarks>
		private System.Drawing.Icon GetTrayIcon()
		{
			string N1 = "0";
			string N2 = "0";
			string N3 = "0";
			string N4 = "0";
			if (IsRevealerEnabled) N1 = "1";
			if (IsActionEnabled) N2 = "1";
			if (IsActionLongEnabled) N3 = "1";
			return GetTrayIcon(N1 + N2 + N3 + N4);
		}

		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null) components.Dispose();
				if (_Mutex != null) _Mutex.Dispose();
			}
			base.Dispose(disposing);
		}

		private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainTabControl.SelectedTab = OptionsTabPage;
			RestoreFromTray(true);
		}

	}
}
