using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using JocysCom.ClassLibrary.Runtime;

namespace JocysCom.ClassLibrary.Security.Password.Templates
{
	public partial class Preset
	{
		public Preset()
		{
			PresetTemplate = Templates.PresetName.Default;
			Load(Templates.PresetName.Default);
			SetDefaultChars();
		}

		public Preset(PresetName name)
		{
			PresetTemplate = name;
			Load(Templates.PresetName.Default);
			SetDefaultChars();
			Load(name);
		}

		public Preset(string name)
		{
			Enum.TryParse(name, out PresetTemplate);
			Load(Templates.PresetName.Default);
			SetDefaultChars();
			Load(name);
		}

		public void SetDefaultChars()
		{
			Charsets charsets = new Charsets();
			CharsNumbers = charsets.Strings["Numbers"];
			CharsUppercase = charsets.Strings["Uppercase"];
			CharsLowercase = charsets.Strings["Lowercase"];
			CharsSymbols = charsets.Strings["Symbols"];
			CharsExtra = charsets.Strings["Extra"];
		}

		/// <summary>
		/// Get chars array from which chars will be chosen.
		/// </summary>
		public char[] GetChars()
		{
			if (_Chars == null)
			{
				StringBuilder sb = new StringBuilder();
				if (UseNumbers) for (int i = 0; i < RatioNumbers; i++) sb.Append(CharsNumbers);
				if (UseUppercase) for (int i = 0; i < RatioUppercase; i++) sb.Append(CharsUppercase);
				if (UseLowercase) for (int i = 0; i < RatioLowercase; i++) sb.Append(CharsLowercase);
				if (UseSymbols) for (int i = 0; i < RatioSymbols; i++) sb.Append(CharsSymbols);
				if (UseExtra) for (int i = 0; i < RatioExtra; i++) sb.Append(CharsExtra);
				_Chars = sb.ToString().ToCharArray();
			}
			return _Chars;
		}
		private char[] _Chars;

		public PresetName PresetTemplate;
		public string PresetName;
		public string PresetDescription;
		public string PresetRemarks;
		// Set password length property.
		public int PasswordLength;
		// Set Use property.
		private bool _UseUppercase;
		private bool _UseLowercase;
		private bool _UseNumbers;
		private bool _UseSymbols;
		private bool _UseExtra;
		public bool UseUppercase { get { return _UseUppercase; } set { _UseUppercase = value; _Chars = null; } }
		public bool UseLowercase { get { return _UseLowercase; } set { _UseLowercase = value; _Chars = null; } }
		public bool UseNumbers { get { return _UseNumbers; } set { _UseNumbers = value; _Chars = null; } }
		public bool UseSymbols { get { return _UseSymbols; } set { _UseSymbols = value; _Chars = null; } }
		public bool UseExtra { get { return _UseExtra; } set { _UseExtra = value; _Chars = null; } }
		// Set Use ratios.
		private int _RatioUppercase;
		private int _RatioLowercase;
		private int _RatioNumbers;
		private int _RatioSymbols;
		private int _RatioExtra;
		public int RatioUppercase { get { return _RatioUppercase; } set { _RatioUppercase = value; _Chars = null; } }
		public int RatioLowercase { get { return _RatioLowercase; } set { _RatioLowercase = value; _Chars = null; } }
		public int RatioNumbers { get { return _RatioNumbers; } set { _RatioNumbers = value; _Chars = null; } }
		public int RatioSymbols { get { return _RatioSymbols; } set { _RatioSymbols = value; _Chars = null; } }
		public int RatioExtra { get { return _RatioExtra; } set { _RatioExtra = value; _Chars = null; } }
		// Setup characters.
		// These values will be updated automatically from
		// System.Security.Password.Templates.Charsets
		private string _CharsUppercase;
		private string _CharsLowercase;
		private string _CharsNumbers;
		private string _CharsSymbols;
		private string _CharsExtra;
		public string CharsUppercase { get { return _CharsUppercase; } set { _CharsUppercase = value; _Chars = null; } }
		public string CharsLowercase { get { return _CharsLowercase; } set { _CharsLowercase = value; _Chars = null; } }
		public string CharsNumbers { get { return _CharsNumbers; } set { _CharsNumbers = value; _Chars = null; } }
		public string CharsSymbols { get { return _CharsSymbols; } set { _CharsSymbols = value; _Chars = null; } }
		public string CharsExtra { get { return _CharsExtra; } set { _CharsExtra = value; _Chars = null; } }
		// Filters.
		public bool FilterRemember;
		public bool FilterKeyboard;
		public bool FilterEnforce;
		public bool FilterPhone;
		public bool FilterAscii;
		public bool FilterChars;
		public string FilterCharsString;
		// Scripting.
		public bool ScriptEnabled;
		public string ScriptLanguage;
		public string ScriptEntry;
		public string ScriptCode;
		// Regular Expressions.
		public bool RegexEnabled;
		public string RegexPatternFind;
		public string RegexPatternReplace;
		public bool RegexIgnoreCase;

		public bool Load(PresetName name)
		{
			string path = string.Format(@"Security\Password\Templates\Presets\{0}.js", name.ToString());
			string contents = JocysCom.ClassLibrary.Helper.FindResource<string>(GetType().Assembly, path);
			try { loadContents(contents); }
			catch (Exception ex)
			{
				LoadException = ex;
				return false;
			}
			return true;
		}

		public Exception LoadException;

		public bool Load(string name)
		{
			string contents = System.IO.File.ReadAllText(name.ToString());
			try { loadContents(contents); }
			catch (Exception ex)
			{
				LoadException = ex;
				return false;
			}
			return true;
		}

		private void loadContents(string contents)
		{

			string[] names = typeof(PresetBase).GetFields().Select(x => x.Name).ToArray();
			string missing = string.Empty;
			for (int i = 0; i < names.Length; i++)
			{
				// If content don’t have some property then...
				if (!contents.Contains("\"" + names[i] + "\":"))
				{
					missing += "\t\"" + names[i] + "\": null,\r\n";
				}
			}
			if (!string.IsNullOrEmpty(missing))
			{
				contents = "{" + missing + contents.Substring(contents.IndexOf('{') + 1);
			}
			PresetBase item = (PresetBase)JocysCom.ClassLibrary.Runtime.Serializer.DeserializeFromJson(contents, typeof(PresetBase));
			PresetName = (item.PresetName != null) ? item.PresetName : PresetName;
			PresetDescription = (item.PresetDescription != null) ? item.PresetDescription : PresetDescription;
			PresetRemarks = (item.PresetRemarks != null) ? item.PresetRemarks : PresetRemarks;
			PasswordLength = item.PasswordLength.HasValue ? item.PasswordLength.Value : PasswordLength;
			UseNumbers = item.UseNumbers.HasValue ? item.UseNumbers.Value : UseNumbers;
			UseUppercase = item.UseUppercase.HasValue ? item.UseUppercase.Value : UseUppercase;
			UseLowercase = item.UseLowercase.HasValue ? item.UseLowercase.Value : UseLowercase;
			UseSymbols = item.UseSymbols.HasValue ? item.UseSymbols.Value : UseSymbols;
			UseExtra = item.UseExtra.HasValue ? item.UseExtra.Value : UseExtra;
			RatioNumbers = item.RatioNumbers.HasValue ? item.RatioNumbers.Value : RatioNumbers;
			RatioUppercase = item.RatioUppercase.HasValue ? item.RatioUppercase.Value : RatioUppercase;
			RatioLowercase = item.RatioLowercase.HasValue ? item.RatioLowercase.Value : RatioLowercase;
			RatioSymbols = item.RatioSymbols.HasValue ? item.RatioSymbols.Value : RatioSymbols;
			RatioExtra = item.RatioExtra.HasValue ? item.RatioExtra.Value : RatioExtra;
			CharsNumbers = (item.CharsNumbers != null) ? item.CharsNumbers : CharsNumbers;
			CharsUppercase = (item.CharsUppercase != null) ? item.CharsUppercase : CharsUppercase;
			CharsLowercase = (item.CharsLowercase != null) ? item.CharsLowercase : CharsLowercase;
			CharsSymbols = (item.CharsSymbols != null) ? item.CharsSymbols : CharsSymbols;
			CharsExtra = (item.CharsExtra != null) ? item.CharsExtra : CharsExtra;
			FilterRemember = item.FilterRemember.HasValue ? item.FilterRemember.Value : FilterRemember;
			FilterKeyboard = item.FilterKeyboard.HasValue ? item.FilterKeyboard.Value : FilterKeyboard;
			FilterEnforce = item.FilterEnforce.HasValue ? item.FilterEnforce.Value : FilterEnforce;
			FilterPhone = item.FilterPhone.HasValue ? item.FilterPhone.Value : FilterPhone;
			FilterAscii = item.FilterAscii.HasValue ? item.FilterAscii.Value : FilterAscii;
			FilterChars = item.FilterChars.HasValue ? item.FilterChars.Value : FilterChars;
			FilterCharsString = item.FilterCharsString != null ? item.FilterCharsString : FilterCharsString;
			ScriptEnabled = item.ScriptEnabled.HasValue ? item.ScriptEnabled.Value : ScriptEnabled;
			ScriptLanguage = (item.ScriptLanguage != null) ? item.ScriptLanguage : ScriptLanguage;
			ScriptEntry = item.ScriptEntry != null ? item.ScriptEntry : ScriptEntry;
			ScriptCode = (item.ScriptCode != null) ? item.ScriptCode : ScriptCode;
			RegexEnabled = item.RegexEnabled.HasValue ? item.RegexEnabled.Value : RegexEnabled;
			RegexPatternFind = (item.RegexPatternFind != null) ? item.RegexPatternFind : RegexPatternFind;
			RegexPatternReplace = (item.RegexPatternReplace != null) ? item.RegexPatternReplace : RegexPatternReplace;
			RegexIgnoreCase = item.RegexIgnoreCase.HasValue ? item.RegexIgnoreCase.Value : RegexIgnoreCase;
		}

		public string GetFileName()
		{
			return JocysCom.ClassLibrary.Text.Filters.GetKey(PresetName, true).Replace("_", "") + ".js";
		}

		public string SaveAs(string fileName)
		{
			PresetBase item = new PresetBase();
			item.PresetName = PresetName;
			item.PresetDescription = PresetDescription;
			item.PresetRemarks = PresetRemarks;
			item.PasswordLength = PasswordLength;
			item.UseUppercase = UseUppercase;
			item.UseLowercase = UseLowercase;
			item.UseNumbers = UseNumbers;
			item.UseSymbols = UseSymbols;
			item.UseExtra = UseExtra;
			item.RatioUppercase = RatioUppercase;
			item.RatioLowercase = RatioLowercase;
			item.RatioNumbers = RatioNumbers;
			item.RatioSymbols = RatioSymbols;
			item.RatioExtra = RatioExtra;
			item.CharsUppercase = CharsUppercase;
			item.CharsLowercase = CharsLowercase;
			item.CharsNumbers = CharsNumbers;
			item.CharsSymbols = CharsSymbols;
			item.CharsExtra = CharsExtra;
			item.FilterRemember = FilterRemember;
			item.FilterKeyboard = FilterKeyboard;
			item.FilterEnforce = FilterEnforce;
			item.FilterPhone = FilterPhone;
			item.FilterAscii = FilterAscii;
			item.FilterChars = FilterChars;
			item.FilterCharsString = FilterCharsString;
			item.ScriptEnabled = ScriptEnabled;
			item.ScriptLanguage = ScriptLanguage;
			item.ScriptEntry = ScriptEntry;
			item.ScriptCode = ScriptCode;
			item.RegexEnabled = RegexEnabled;
			item.RegexPatternFind = RegexPatternFind;
			item.RegexPatternReplace = RegexPatternReplace;
			item.RegexIgnoreCase = RegexIgnoreCase;
			string contents = JocysCom.ClassLibrary.Runtime.Serializer.SerializeToJson(item);
			contents = contents.TrimStart('{');
			contents = contents.TrimEnd('}');
			MemberInfo[] members = this.GetType().GetMembers();
			for (int i = 0; i < members.Length; i++)
			{
				string find = string.Format(",\"{0}\":", members[i].Name);
				string repl = string.Format(",\r\n\t\"{0}\":", members[i].Name);
				contents = contents.Replace(find, repl);
			}
			contents = "{\r\n\t" + contents + "\r\n}";
			System.IO.File.WriteAllText(fileName, contents);
			return contents;
		}

		/// <summary>
		/// Return list of names of different properties.
		/// </summary>
		/// <param name="preset"></param>
		/// <returns></returns>
		public string[] Compare(Preset preset)
		{
			List<string> list = new List<string>();
			PropertyInfo[] properties = this.GetType().GetProperties();
			PropertyInfo property;
			object thisValue;
			object presetValue;
			for (int i = 0; i < properties.Length; i++)
			{
				property = properties[i];
				Type type = property.PropertyType;
				if (!type.IsPublic) continue;
				thisValue = property.GetValue(this, null);
				presetValue = property.GetValue(preset, null);
				if (type == typeof(bool) && (bool)thisValue != (bool)presetValue)
				{
					list.Add(property.Name);
				}
				if (type == typeof(string) && (string)thisValue != (string)presetValue)
				{
					list.Add(property.Name);
				}
			}
			FieldInfo[] fields = this.GetType().GetFields(BindingFlags.Public);
			FieldInfo field;
			for (int i = 0; i < fields.Length; i++)
			{
				field = fields[i];
				Type type = field.FieldType;
				if (!type.IsPublic) continue;
				thisValue = field.GetValue(this);
				presetValue = field.GetValue(preset);
				if (type == typeof(bool) && (bool)thisValue != (bool)presetValue)
				{
					list.Add(field.Name);
				}
				if (type == typeof(string) && (string)thisValue != (string)presetValue)
				{
					list.Add(field.Name);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// Creates a copy of Preset with same values.
		/// </summary>
		/// <returns>Copy of this Preset with same values.</returns>
		public Preset Copy()
		{
			Preset preset = new Preset();
			RuntimeHelper.CopyProperties(this, preset);
			return preset;
		}

	}
}
