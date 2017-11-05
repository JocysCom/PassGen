using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using JocysCom.Password.Generator.Properties;
using System.Reflection;

namespace JocysCom.Password.Generator
{
	// Configuration lines inside *.*proj file will open this partial class in a code editor.
	//
	//		<Compile Include="MainForm.Tray.cs">
	//			<DependentUpon>MainForm.cs</DependentUpon>
	//			<SubType>Code</SubType>
	//		</Compile>

	public partial class MainForm
	{

		//public bool MinimizeToTrayChanging;
		//public void SetMinimizeToTray(bool value)
		//{
		//	if (MinimizeToTrayChanging) return;
		//	MinimizeToTrayChanging = true;
		//	if (MinimizeToTrayToolStripMenuItem.Checked != value)
		//	{
		//		MinimizeToTrayToolStripMenuItem.Checked = value;
		//	}
		//	if (OptionsPanel.MinimizeToTrayCheckBox.Checked != value)
		//	{
		//		OptionsPanel.MinimizeToTrayCheckBox.Checked = value;
		//	}
		//	if (Settings.Default.MinimizeToTray != value)
		//	{
		//		Settings.Default.MinimizeToTray = value;
		//	}
		//	UpdateStatusBar(WindowState);
		//	MinimizeToTrayChanging = false;
		//}

		void InitMinimize()
		{
			_hiddenForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			_hiddenForm.ShowInTaskbar = false;
			// Configure MinimizeToTray related controls.
			MinimizeToTrayToolStripMenuItem.Checked = Settings.Default.MinimizeToTray;
			OptionsPanel.MinimizeToTrayCheckBox.Checked = Settings.Default.MinimizeToTray;
			OptionsPanel.MinimizeToTrayCheckBox.Click += OptionsPanel_MinimizeToTrayCheckBox_Click;
			MinimizeToTrayToolStripMenuItem.Click += MinimizeToTrayToolStripMenuItem_Click;
			// Attach resize event.
			Resize += MainForm_Resize;
			//TrayNotifyIcon.Click += TrayNotifyIcon_Click;
			//TrayNotifyIcon.DoubleClick += TrayNotifyIcon_DoubleClick;
			// Run event once to apply settings.
			MainForm_Resize(this, new EventArgs());
		}

		void UnInitMinimize()
		{
			OptionsPanel.MinimizeToTrayCheckBox.Click += OptionsPanel_MinimizeToTrayCheckBox_Click;
			MinimizeToTrayToolStripMenuItem.Click += MinimizeToTrayToolStripMenuItem_Click;
		}

		Form _hiddenForm = new Form();
		FormWindowState? oldWindowState;
		object windowStateLock = new object();

		private void MainForm_Resize(object sender, EventArgs e)
		{
			// Track window state changes.
			lock (windowStateLock)
			{
				var newWindowState = WindowState;
				if (!oldWindowState.HasValue || oldWindowState.Value != newWindowState)
				{
					oldWindowState = newWindowState;
					// If window was minimized.
					if (newWindowState == FormWindowState.Minimized)
					{
						MinimizeToTray(false, Properties.Settings.Default.MinimizeToTray);
					}
				}
			}
		}

		private void MinimizeToTrayToolStripMenuItem_Click(object sender, EventArgs e)
		{
			InvertMinimizeToTray();
		}

		private void OptionsPanel_MinimizeToTrayCheckBox_Click(object sender, EventArgs e)
		{
			InvertMinimizeToTray();
		}

		void InvertMinimizeToTray()
		{
			Properties.Settings.Default.MinimizeToTray = !Properties.Settings.Default.MinimizeToTray;
			OptionsPanel.MinimizeToTrayCheckBox.Checked = Properties.Settings.Default.MinimizeToTray;
			MinimizeToTrayToolStripMenuItem.Checked = Properties.Settings.Default.MinimizeToTray;
		}

		//private void TrayNotifyIcon_Click(object sender, EventArgs e)
		//{
		//	var mi = TrayNotifyIcon.GetType().GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
		//	mi.Invoke(TrayNotifyIcon, null);
		//}

		//private void TrayNotifyIcon_DoubleClick(object sender, EventArgs e)
		//{
		//	RestoreFromTray();
		//}

		private void OpenApplicationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RestoreFromTray();
		}

		#region Minimize / Restore

		/// <summary>
		/// Minimize the window and hide it from the TaskBar. 
		/// </summary>
		public void MinimizeToTray(bool showBalloonTip, bool minimizeToTray)
		{
			// Show only first time.
			if (showBalloonTip)
			{
				TrayNotifyIcon.BalloonTipText = Application.ProductName;
				// Show balloon tip for 2 seconds.
				TrayNotifyIcon.ShowBalloonTip(2, "Password Generator", Application.ProductName, ToolTipIcon.Info);
			}
			// hold - program.
			// NOTE: also it would be possible to track which direction mouse will move in or move out on TrayIcon.
			// For example: open program if mouse moves in from left and moves out from top.
			TrayNotifyIcon.Text = "Click: double - program, left - generate, right - menu.";
			if (minimizeToTray)
			{
				// Set window style as ToolWindow to avoid its icon in ALT+TAB.
				if (Owner != _hiddenForm)
					Owner = _hiddenForm;
				// Hide form bar from the TarkBar.
				if (ShowInTaskbar)
					ShowInTaskbar = false;
			}
			if (WindowState != FormWindowState.Minimized)
			{
				WindowState = FormWindowState.Minimized;
			}
		}

		/// <summary>
		/// Restores the window.
		/// </summary>
		public void RestoreFromTray(bool activate = false)
		{
			if (activate)
			{
				// Note: FormWindowState.Minimized and FormWindowState.Normal was used to make sure that Activate() wont fail because of this:
				// Windows NT 5.0 and later: An application cannot force a window to the foreground while the user is working with another window.
				// Instead, SetForegroundWindow will activate the window (see SetActiveWindow) and call theFlashWindowEx function to notify the user.
				if (WindowState != FormWindowState.Minimized)
				{
					WindowState = FormWindowState.Minimized;
				}
				this.Activate();
			}
			// Show in task bar before restoring windows state in order to prevent flickering.
			if (!ShowInTaskbar)
				ShowInTaskbar = true;
			if (WindowState != FormWindowState.Normal)
			{
				WindowState = FormWindowState.Normal;
			}
			// Set window style as ToolWindow to show in ALT+TAB.
			if (Owner != null)
				Owner = null;
			// Bring form to the front.
			var tm = TopMost;
			TopMost = true;
			TopMost = tm;
			BringToFront();
		}

		#endregion

	}
}
