using System;
using System.Windows.Forms;
using JocysCom.Password.Generator.Properties;
using System.Configuration.Install;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

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
			var dllName = e.Name.Contains(",") ? e.Name.Substring(0, e.Name.IndexOf(',')) : e.Name.Replace(".dll", "");
			Stream sr = null;
			switch (dllName)
			{
				case "System.Text.Encodings.Web":
					sr = GetResourceStream(dllName + ".dll");
					break;
				default:
					break;
			}
			if (sr == null)
				return null;
			var bytes = new byte[sr.Length];
			sr.Read(bytes, 0, bytes.Length);
			var asm = Assembly.Load(bytes);
			sr.Dispose();
			return asm;
		}

		/// <summary>
		/// Get 32-bit or 64-bit resource depending on x360ce.exe platform.
		/// </summary>
		public static Stream GetResourceStream(string name)
		{
			var path = GetResourcePath(name);
			if (path == null)
				return null;
			var assembly = Assembly.GetEntryAssembly();
			var sr = assembly.GetManifestResourceStream(path);
			return sr;
		}

		/// <summary>
		/// Get 32-bit or 64-bit resource depending on x360ce.exe platform.
		/// </summary>
		public static string GetResourcePath(string name)
		{
			var assembly = Assembly.GetEntryAssembly();
			var names = assembly.GetManifestResourceNames()
				.Where(x => x.EndsWith(name));
			var a = Environment.Is64BitProcess ? ".x64." : ".x86.";
			// Try to get by architecture first.
			var path = names.FirstOrDefault(x => x.Contains(a));
			if (!string.IsNullOrEmpty(path))
				return path;
			// Return first found.
			return names.FirstOrDefault();
		}

	}
}
