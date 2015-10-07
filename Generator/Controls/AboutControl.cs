using System;
using System.ComponentModel;
using System.Windows.Forms;
using JocysCom.ClassLibrary.Configuration;

namespace JocysCom.Password.Generator.Controls
{
	public partial class AboutControl : UserControl
	{
		public AboutControl()
		{
			InitializeComponent();
		}

		void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			OpenUrl(((Control)sender).Text);
		}

		public void OpenUrl(string url)
		{
			try
			{
				System.Diagnostics.Process.Start(url);
			}
			catch (Win32Exception noBrowser)
			{
				if (noBrowser.ErrorCode == -2147467259)
					MessageBox.Show(noBrowser.Message);
			}
			catch (Exception other)
			{
				MessageBox.Show(other.Message);
			}
		}

		public void Initialize()
		{
			var info = new AssemblyInfo();
			AboutDescriptionLabel.Text = info.Description;
			AboutProductLabel.Text = info.Title;
			var changeLog = ClassLibrary.Helper.FindResource<string>("ChangeLog.txt");
			ChangeLogTextBox.Text = changeLog;
			var license = ClassLibrary.Helper.FindResource<string>("License.txt");
			LicenseTextBox.Text = license;
			LicenseTabPage.Text = string.Format("{0} {1} License", Application.ProductName, new Version(Application.ProductVersion).ToString(2));
		}

	}
}
