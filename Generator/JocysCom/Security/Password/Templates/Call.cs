using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace JocysCom.ClassLibrary.Security.Password.Templates
{
	[Serializable, XmlRoot, DataContract]
	public partial class Call : INotifyPropertyChanged
	{
		public Call(CallName name)
		{
			Load(name, false);
		}

		public Call(string name)
		{
			Load(name, false);
		}

		public void SaveAs(string name)
		{
			string contents = JocysCom.ClassLibrary.Runtime.Serializer.SerializeToJson(this);
			contents = contents.Replace(",[", ",\r\n\t[");
			contents = contents.Replace(",\"Data\":[", ",\r\n\"Data\":[\r\n\t");
			contents = contents.Replace("]}", "\r\n]}");
			System.IO.File.WriteAllText(name, contents);
		}

		public void Load(CallName name, bool append)
		{
			string path = string.Format(@"Security\Password\Templates\Calls\{0}.js", name.ToString());
			string contents = JocysCom.ClassLibrary.Helper.FindResource<string>(GetType().Assembly, path);
			loadContents(contents, append);
		}

		public void Load(string name, bool append)
		{
			string contents = System.IO.File.ReadAllText(name.ToString());
			loadContents(contents, append);
		}

		private void loadContents(string contents, bool append)
		{
			Call call = (Call)JocysCom.ClassLibrary.Runtime.Serializer.DeserializeFromJson(contents, typeof(Call));
			CallName = call.CallName;
			CallDescription = call.CallDescription;
			FontName = call.FontName;
			Data = call.Data;
			if (Keys == null) Keys = new Dictionary<uint, CallItem>();
			if (!append) Keys.Clear();
			foreach (string[] item in Data)
			{
				uint code = 0;
				if (item[0].StartsWith("0x", StringComparison.InvariantCultureIgnoreCase))
				{
					code = uint.Parse(item[0].Substring(2), System.Globalization.NumberStyles.HexNumber);
				}
				else
				{
					code = uint.Parse(item[0]);
				}
				Keys.Remove(code);
				CallItem ci = new CallItem();
				ci.Code = code;
				ci.Name = item[1];
				ci.Description = item[2];
				Keys[code] = ci;
			}
		}

		string _CallName;
		[DataMember]
		public string CallName
		{
			get { return _CallName; }
			set { _CallName = value; NotifyPropertyChanged("CallName"); }
		}

		string _CallDescription;
		[DataMember]
		public string CallDescription
		{
			get { return _CallDescription; }
			set { _CallDescription = value; NotifyPropertyChanged("CallDescription"); }
		}

		string _FontName;
		[DataMember]
		public string FontName
		{
			get { return _FontName; }
			set { _FontName = value; NotifyPropertyChanged("FontName"); }
		}

		[DataMember]
		private List<string[]> Data { get; set; }

		[NonSerialized]
		public Dictionary<uint, CallItem> Keys;

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName = "")
		{
			var ev = PropertyChanged;
			if (ev == null) return;
			ev(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion


	}
}
