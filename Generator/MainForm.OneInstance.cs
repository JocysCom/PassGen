using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using JocysCom.PassMan.PassGen.Properties;

namespace JocysCom.PassMan.PassGen
{
	public partial class MainForm
	{

		#region only 1 instance force window show of last instance

		//constants
		public const byte BSF_IGNORECURRENTTASK = 2; //this ignores the current app Hex 2
		public const byte BSF_POSTMESSAGE = 16; //This posts the message Hex 10
		public const byte BSM_APPLICATIONS = 8; //This tells the windows message to just go to applications Hex 8

		public int MessageId; //This stores the unique windows message id from the register window message call
		System.Threading.Mutex _Mutex; //Used to determine if the application is already open
		object mutexLock = new object();
		string m_uniqueIdentifier = string.Empty; //user to determine if the app is already open

		public const int wp_Maximize = 1;
		public const int wp_Close = 2;

		public bool CheckPrevious(int wParam)
		{
			//Check for previous instance of this app
			lock (mutexLock)
			{
				m_uniqueIdentifier = Application.ProductName;
				_Mutex = new System.Threading.Mutex(false, m_uniqueIdentifier);
			}
			// First register the windows message
			MessageId = NativeMethods.RegisterWindowMessage(m_uniqueIdentifier);
			if (_Mutex.WaitOne(1, true))
			{
				//we are the first instance don't need to do anything
				return true;
			}
			else
			{
				// Cause the current form to show
				// Now broadcast a message to cause the first instance to show up
				Int32 BSMRecipients = BSM_APPLICATIONS; //Only go to applications
				Int32 tmpuint32 = 0;
				tmpuint32 = tmpuint32 | BSF_IGNORECURRENTTASK; //Ignore current app
				tmpuint32 = tmpuint32 | BSF_POSTMESSAGE; //Post the windows message
				int ret = NativeMethods.BroadcastSystemMessage(tmpuint32, ref BSMRecipients, MessageId, wParam, 0);
				//A different instance already exists exit now.
				return false;
			}
		}

		private const int WM_QUERYENDSESSION = 0x11;
		// OnClosing implementation prevents the window to be closed, which prevents the computer to be shutdown...
		// To solve this issue, we need some lightweight Interop 
		private bool endSessionPending;

		/// <summary>
		/// NOTE you must be careful with this method. This is handling all the
		/// windows messages that are coming to the form...
		/// </summary>
		/// <param name="m"></param>
		/// <remarks>This overrides the windows messaging processing</remarks>
		protected override void DefWndProc(ref System.Windows.Forms.Message m)
		{
			// If we found our message then show currently running instance.
			if (m.Msg == MessageId)
			{
				if (m.WParam.ToInt32() == wp_Maximize) RestoreFromTray();
				if (m.WParam.ToInt32() == wp_Close) Close();
			}
			// If session is ending then allow to close the form.
			if (m.Msg == WM_QUERYENDSESSION) endSessionPending = true;
			// Let the normal windows messaging process it.
			base.DefWndProc(ref m);
		}

		#endregion

		//protected override void WndProc(ref Message m)
		//{
		//    if (m.Msg == WM_QUERYENDSESSION)
		//    {
		//        endSessionPending = true;
		//    }
		//    base.WndProc(ref m);
		//}

		/// <summary>
		/// Occurs when the window is requested to be closed.
		/// This function is attached to "Closing" behaviour of the form.
		/// Problem is that it wont be fired if Application [X] is presses.
		/// By default so this makes form to be minimized when user press close 'X' button
		/// it is said that this is set to true to improve the application performance.
		/// </summary>
		/// <param name="e">The event arguments</param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!endSessionPending && Settings.Default.MinimizeOnClose)
			{
				// The window must only be minimized in tray
				e.Cancel = true;
				// Hide the form...
				MinimizeToTray(false);
			}
			else
			{
				if (Settings.Default.SaveProgramSettingsOnExit)
				{
					Settings.Default.PresetNameComboBox = (string)GeneratorPanel.PresetNameComboBox.SelectedItem;
					Settings.Default.Save();
				}
			}
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			endSessionPending = true;
			this.Close();
		}



	}
}
