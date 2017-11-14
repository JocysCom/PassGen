using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;
using JocysCom.ClassLibrary.Data;
using System.Reflection;

namespace JocysCom.ClassLibrary.Security
{
	public partial class TokenControl : UserControl
	{
		public TokenControl()
		{
			InitializeComponent();
		}

		#region Security Token

		public class Params
		{
			public string Param1 { get; set; }
			public long Param2 { get; set; }
		}

		void GenerateSecurityToken()
		{
			var unitType = (TimeUnitType)UnitTypeComboBox.SelectedValue;
			long u = TokenHelper.GetTimeUnitValue(unitType);
			var data = new Params();
			data.Param1 = Param1ComboBox.Text;
			data.Param2 = u;
			Param2TextBox.Text = u.ToString();
			var secret = GetSecret();
			var token = TokenHelper.GetSecurityToken(data, secret, u);
			SecurityTokenTextBox.Text = token;
			// Dispaly log.
			var bytes = TokenHelper.ObjectToBytes(data);
			var param = TokenHelper.BytesToObject<Params>(bytes);
			LogTextBox.Text = JocysCom.ClassLibrary.Text.Helper.BytesToStringBlock(bytes, false, true, true);

		}

		void CheckSecurityToken()
		{
			Params data;
			string check;
			if (TokenHelper.TryGetData(SecurityTokenTextBox.Text, out data))
			{
				var unitType = (TimeUnitType)UnitTypeComboBox.SelectedValue;
				var xml = JocysCom.ClassLibrary.Runtime.Serializer.SerializeToXmlString(data, null, true);
				SecurtyTokenDataTextBox.Text = xml;
				var secret = GetSecret();
				var duration = (int)UnlockDurationUpDown.Value;
				check = TokenHelper.CheckSecurityToken(SecurityTokenTextBox.Text, data, secret, unitType, duration)
					? "Valid" : "Invalid";
				if (data != null)
				{
					var u = TokenHelper.GetTimeUnitValue(unitType);
					if ((data.Param2 + duration) <= u)
					{
						check = "Expired";
					}
				}
			}
			else
			{
				check = "Error";
			}
			SecurityTokenCheckTextBox.Text = check;
		}

		void CheckUnlockToken()
		{
			var isValid = TokenHelper.CheckUnlockToken(UnlockTokenTextBox.Text, UnlockKeyTextBox.Text, (TimeUnitType)UnitTypeComboBox.SelectedValue, (int)UnlockDurationUpDown.Value);
			UnlockTokenCheckTextBox.Text = isValid ? "Valid" : "Invalid";
		}

		byte[] Compress(byte[] bytes)
		{
			var sourceStream = new MemoryStream(bytes, false);
			var destinationStream = new MemoryStream();
			using (GZipStream gzStream = new GZipStream(destinationStream, CompressionMode.Compress, false))
			{
				gzStream.Write(bytes, 0, bytes.Length);
			}
			return destinationStream.ToArray();
		}

		byte[] Decompress(byte[] bytes)
		{
			var sourceStream = new MemoryStream(bytes, false);
			var destinationStream = new MemoryStream();
			using (GZipStream gzStream = new GZipStream(sourceStream, CompressionMode.Decompress, false))
			{
				gzStream.CopyTo(destinationStream);
			}
			return destinationStream.ToArray();
		}

		#endregion

		object GetSecret()
		{
			var s = SecretComboBox.Text;
			Guid gValue;
			int iValue;
			if (Guid.TryParse(s, out gValue))
			{
				return gValue;
			}
			else if (int.TryParse(s, out iValue))
			{
				return iValue;
			}
			return s;
		}

		private void UnlockKeyTextBox_TextChanged(object sender, EventArgs e)
		{
			GenerateUnlockToken();
		}

		void GenerateUnlockToken()
		{
			var token = TokenHelper.GetUnlockToken(UnlockKeyTextBox.Text, (TimeUnitType)UnitTypeComboBox.SelectedValue);
			UnlockTokenTextBox.Text = token;
		}

		private void TokenControl_Load(object sender, EventArgs e)
		{
			UnitTypeComboBox.DataSource = Enum.GetValues(typeof(TimeUnitType));
			UnitTypeComboBox.SelectedItem = TimeUnitType.Seconds;
			HashKeyTextBox.Text = Encryption.Current.HmacHashKeyValue;
			GenerateSecurityToken();
			GenerateUnlockToken();
			NowLinkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
		}

		private void UnlockUnitTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			GenerateUnlockToken();
		}

		private void UnlockDurationUpDown_ValueChanged(object sender, EventArgs e)
		{
			GenerateUnlockToken();
		}

		private void UnlockTokenTextBox_TextChanged(object sender, EventArgs e)
		{
			CheckUnlockToken();
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void SecurityTokenTextBox_TextChanged(object sender, EventArgs e)
		{
			CheckSecurityToken();
		}

		private void RegenerateButton_Click(object sender, EventArgs e)
		{
			GenerateSecurityToken();
			GenerateUnlockToken();
		}

		private void NowLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var n = DateTime.Now;
			TokenStartDateTimePicker.Value = new DateTime(n.Year, n.Month, n.Day, n.Hour, n.Minute, n.Second);
		}

		private void Unit_ValueChanged(object sender, EventArgs e)
		{
			var unitType = (TimeUnitType)UnitTypeComboBox.SelectedValue;
			var unitValue = TokenHelper.GetTimeUnitValue(unitType);
			UnitValueTextBox.Text = unitValue.ToString();
			UnitValueHexTextBox.Text = unitValue.ToString("X4");
		}

		private void CheckSecurityTokenButton_Click(object sender, EventArgs e)
		{
			CheckSecurityToken();
			CheckUnlockToken();
		}
	}
}
