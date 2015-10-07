using System;
using System.Windows.Forms;
using JocysCom.ClassLibrary.Processes;

namespace JocysCom.PassMan.PassGen
{
	public partial class PasswordRevealer : IDisposable
	{
		object revealerTimerLock = new object();

		public PasswordRevealer()
		{
			revealerTimer = new Timer();
			revealerTimer.Interval = 100;
			revealerTimer.Tick += new EventHandler(RevealerTimer_Tick);
		}

		object mouseHookLock = new object();
		public MouseHook _MouseHook;
		private Timer revealerTimer;

		System.Reflection.Assembly assembly;
		private System.Drawing.Icon GetTrayIcon(string iconType)
		{
			lock (this)
			{
				assembly = System.Reflection.Assembly.GetExecutingAssembly();
				string path = assembly.GetName().Name + ".Sources.Images.TrayIcon-" + iconType + ".ico";
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
			//if (IsRevealerEnabled) N1 = "1";
			//if (IsActionEnabled) N2 = "1";
			return GetTrayIcon(N1 + N2 + N3 + N4);
		}

		private bool _IsEnabled;
		public bool IsEnabled
		{
			get
			{
				return _IsEnabled;
			}
			set
			{
				if (value) RevealerEnable();
				else RevealerDisable();
				_IsEnabled = value;
			}
		}


		private void RevealerDisable()
		{
			if (IsEnabled)
			{
				DisposeMouseHook();
				//this.ntiTrayIcon.Icon = GetTrayIcon();
				//mnuPasswordRevealer.Text = "Password Revealer: OFF";
				//mnuPasswordRevealer.Checked = false;
				// Stop timer last! (because this function runs from timer too).
				lock (revealerTimerLock)
				{
					if (revealerTimer != null) revealerTimer.Enabled = false;
				}
			}
		}

		void DisposeMouseHook()
		{
			lock (mouseHookLock)
			{
				if (_MouseHook != null)
				{
					_MouseHook.OnMouseDown -= new MouseEventHandler(RevealerMouseDown);
					_MouseHook.Stop();
					_MouseHook.Dispose();
					_MouseHook = null;
				}
			}
		}

		private void RevealerEnable()
		{
			if (!IsEnabled)
			{
				// Change one node of Icon colour to red.
				//this.ntiTrayIcon.Icon = GetTrayIcon();
				//mnuPasswordRevealer.Text = "Password Revealer: ON";
				//mnuPasswordRevealer.Checked = true;
				lock (mouseHookLock)
				{
					if (_MouseHook == null)
					{
						// Create Global Hook Monitor.
						_MouseHook = new MouseHook();
						// Attach functions to events.
						_MouseHook.OnMouseDown += new MouseEventHandler(RevealerMouseDown);
					}
				}
				lock (revealerTimerLock)
				{
					if (revealerTimer != null)
					{
						//	 AutoOff after 1 minute.
						revealerTimer.Interval = 6000;
						revealerTimer.Enabled = true;
					}
				}
			}
		}

		// Process MouseDown Event.
		public void RevealerMouseDown(object sender, MouseEventArgs e)
		{
			//To store current window handle
			int curWindow;

			//string sClassName;
			//Reduced class name
			string sName;
			ProcessControl.WinAPI.POINTAPI lpPoint = new ProcessControl.WinAPI.POINTAPI();
			//Get current mouse location
			ProcessControl.WinAPI.GetCursorPos(ref lpPoint);
			//GetCursorPos  POINTAPI  handle from that location
			curWindow = ProcessControl.WinAPI.WindowFromPoint(lpPoint.x, lpPoint.y);

			//Get class name of x  window
			//Well reduced class name
			//sClassName 
			sName = "Edit";
			//lets assume it.Due to some problems in getting the class name from the window
			//handle we are assuming the class name to be "Edit"
			//Check whether this object is Edit control or TextBox if yes
			if (sName == "Edit" || sName.IndexOf("TextBox") > -1)
			{
				//Send message to convert its password char to normal
				//api.SendMessage(curWindow, EM_SETPASSWORDCHAR, 0, 0)
				ProcessControl.WinAPI.SendMessage(curWindow, 204, 0, 0);
				SendKeys.Send("{home}");
				SendKeys.Send("{p}");
				SendKeys.Send("{bs}");
			}
			//TextBox1.Text = CStr("X : " & lpPoint.x & "   Y : " & lpPoint.y);
		}

		private void RevealerTimer_Tick(object sender, EventArgs e)
		{
			RevealerDisable();
		}

		#region IDisposable

		// Dispose() calls Dispose(true)
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		// The bulk of the clean-up code is implemented in Dispose(bool)
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Free managed resources.
				lock (revealerTimerLock)
				{
					if (revealerTimer != null)
					{
						revealerTimer.Dispose();
						revealerTimer = null;
					}
				}
				DisposeMouseHook();
			}
		}

		#endregion



	}
}
