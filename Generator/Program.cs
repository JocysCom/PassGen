using System;
using System.Windows.Forms;
using JocysCom.Password.Generator.Properties;
using System.Configuration.Install;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace JocysCom.Password.Generator
{
	static class Program
	{

		public static bool IsDebug
		{
			get
			{
#if DEBUG
				return true;
#else
				return false;
#endif
			}
		}

		public static MainForm mainForm;

		public const string arg_WindowState = "WindowState";

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// IMPORTANT: Make sure this method don't have any static references to JocysCom library or
			// program tries to load JocysCom.ClassLibrary.dll before AssemblyResolve event is available and fails.
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

			// Call these before everything.
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			CheckSettings();
			mainForm = new MainForm();
			// Requires System.Configuration.Installl reference.
			InstallContext ic = new InstallContext(null, args);
			//Settings.Default.Upgrade();
			//Settings.Default.Reload();
			if (ic.Parameters.ContainsKey("Exit"))
			{
				mainForm.CheckPrevious(MainForm.wp_Close);
				return;
			}
			bool notRunning = Settings.Default.AllowOnlyOneCopy
				? mainForm.CheckPrevious(MainForm.wp_Maximize)
				: true;
			if (notRunning)
			{
				mainForm.TrayNotifyIcon.Visible = true;
				if (ic.Parameters.ContainsKey(arg_WindowState))
				{
					switch (ic.Parameters[arg_WindowState])
					{
						case "Maximized":
							mainForm.RestoreFromTray();
							mainForm.WindowState = FormWindowState.Maximized;
							break;
						case "Minimized":
							mainForm.MinimizeToTray(false, Properties.Settings.Default.MinimizeToTray);
							break;
					}
				}
				Application.Run(mainForm);
			}
			else
			{
				mainForm.Close();
			}
		}

		static void CheckSettings()
		{
			try
			{
				Settings.Default.Reload();
				//var p = Settings.Default.Properties.Cast<SettingsProperty>().FirstOrDefault();
				//var v = Settings.Default[p.Name];
			}
			catch (ConfigurationErrorsException ex)
			{   // requires System.Configuration
				string filename = ((ConfigurationErrorsException)ex.InnerException).Filename;
				if (MessageBox.Show("Program has detected that your" +
									  " user settings file has become corrupted. " +
									  "This may be due to a crash or improper exiting" +
									  " of the program. Program must reset your " +
									  "user settings in order to continue.\n\nClick" +
									  " Yes to reset your user settings and continue.\n\n" +
									  "Click No if you wish to attempt manual repair" +
									  " or to rescue information before proceeding.",
									  "Corrupt user settings of " + Application.ProductName,
									  MessageBoxButtons.YesNo,
									  MessageBoxIcon.Error) == DialogResult.Yes)
				{
					File.Delete(filename);
					Settings.Default.Reload();
					// you could optionally restart the app instead
				}
				else
					Process.GetCurrentProcess().Kill();
				// avoid the inevitable crash
			}
		}

		static void RestoreUserSettings()
		{
			//restore user settings
			try
			{
				Settings.Default.ToString();
			}
			catch (ConfigurationErrorsException ex)
			{
				string filename = ((ConfigurationErrorsException)ex.InnerException).Filename;
				File.Delete(filename);
				Application.Restart();
				Process.GetCurrentProcess().Kill();
			}
		}

		static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs e)
		{
			string dllName = e.Name.Contains(",") ? e.Name.Substring(0, e.Name.IndexOf(',')) : e.Name.Replace(".dll", "");
			string path = null;
			switch (dllName)
			{
				case "JocysCom.ClassLibrary":
					path = "Resources.JocysCom.ClassLibrary.dll";
					break;
				default:
					break;
			}
			if (path == null) return null;
			var assembly = Assembly.GetExecutingAssembly();
			var sr = assembly.GetManifestResourceStream(typeof(MainForm).Namespace + "." + path);
			if (sr == null) return null;
			byte[] bytes = new byte[sr.Length];
			sr.Read(bytes, 0, bytes.Length);
			return Assembly.Load(bytes);
		}

	}
}
