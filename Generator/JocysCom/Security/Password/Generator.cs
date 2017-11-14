using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JocysCom.ClassLibrary.Security.Password.Templates;
using System.Text.RegularExpressions;
using System.Reflection;
using JocysCom.ClassLibrary.Controls.DynamicCompile;

namespace JocysCom.ClassLibrary.Security.Password
{
	public partial class Generator
	{

		/// <summary>
		///
		/// </summary>
		/// <remarks>
		/// Password is generated in these steps:
		///	    a) Load array of chars according to presets;
		///     b) Apply filters;
		///     c) Proceed until password length is reached;
		///     d) Apply Regular Expressions;
		/// </remarks>
		public Generator()
		{
			// Preconfigure generator with default preset;
			Preset = new Preset(PresetName.DefaultEasyToEnter);
		}

		private Preset _Preset;
		public Preset Preset
		{
			get { return _Preset; }
			set
			{
				_Preset = value;
				if (PresetChanged != null) PresetChanged(this, new EventArgs());
			}
		}

		Random rnd = new Random();

		public EventHandler<EventArgs> PresetChanged;

		string _splitString(string s, string separator)
		{
			s.ToCharArray();
			return string.Join(separator, s.ToCharArray().Select(x => x.ToString()).ToArray());
		}

		public string NewPasswordList(int count, string separator)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				if (i > 0) sb.Append(separator);
				sb.Append(NewPassword().Text);
			}
			return sb.ToString();
		}

		/// </summary>
		/// Generate new password.
		/// </summary>
		public Word NewPassword()
		{
			var password = new Word();
			password.AppendLog("Info: Password log started.\r\n");
			// Maximum number of attempts to generate password.
			var maxTries = 4;
			for (var a = 1; a <= maxTries; a++)
			{
				password.AppendLog("Info: Attempt {0} to generate password.\r\n", a);
				var charsToUse = Preset.GetChars();
				if (charsToUse.Length == 0)
				{
					password.AppendLog("Error: chars list is empty!\r\n");
				}
				else
				{
					//password.AppendLog("Info: Chars To Use: {0}\r\n", new string(charsToUse));
					// Now we can create our password.
					for (var i = 0; i < this.Preset.PasswordLength; i++)
					{
						// Apply filters and get list of available chars.
						var filteredChars = FilterChars(password, charsToUse);
						// If filters left some chars then...
						if (filteredChars.Length > 0)
						{
							// Calculate password strength (10^x).
							var strength = Math.Log(filteredChars.Length) / Math.Log(10);
							password.Strength += strength;
							// Get random char.
							var charPosition = rnd.Next(filteredChars.Length);
							var filteredChar = filteredChars[charPosition];
							var chars = password.Chars.ToList();
							chars.Add(filteredChar);
							password.Chars = chars.ToArray();
						}
						else
						{
							//password.AppendLog("Warning: filteredChars.length == 0\r\n");
							break;
						}
					}
				}
				// If we reached required password length then...
				if (password.Chars.Length == Preset.PasswordLength)
				{
					break;
				}
			}
			// Apply regular expressions to password.
			if (Preset.RegexEnabled) password = ApplyRegex(password);
			// Apply script to password.
			if (Preset.ScriptEnabled) password = ApplyScript(password);
			// If password is empty then...
			if (password.Chars.Length != Preset.PasswordLength)
			{
				// Add error message.
				password.AppendLog("Error: all attempts to generate password was failed. Please relax password settings.\r\n");
			}
			return password;
		}

		Dictionary<FilterName, Filter> _Filters;
		public Dictionary<FilterName, Filter> Filters
		{
			get
			{
				if (_Filters == null)
				{
					_Filters = new Dictionary<FilterName, Filter>();
					_Filters.Add(FilterName.Remember, new Templates.Filters.Remember());
					_Filters.Add(FilterName.Keyboard, new Templates.Filters.Keyboard());
					_Filters.Add(FilterName.Enforce, new Templates.Filters.Enforce());
					_Filters.Add(FilterName.Phone, new Templates.Filters.Phone());
					_Filters.Add(FilterName.Ascii, new Templates.Filters.ASCII());
					_Filters.Add(FilterName.Chars, new Templates.Filters.Chars());
				}
				return _Filters;
			}
		}

		char[] FilterChars(Word password, char[] chars)
		{
			if (Preset.FilterRemember) chars = Filters[FilterName.Remember].GetChars(this, password, chars);
			if (Preset.FilterKeyboard) chars = Filters[FilterName.Keyboard].GetChars(this, password, chars);
			if (Preset.FilterEnforce) chars = Filters[FilterName.Enforce].GetChars(this, password, chars);
			if (Preset.FilterPhone) chars = Filters[FilterName.Phone].GetChars(this, password, chars);
			if (Preset.FilterAscii) chars = Filters[FilterName.Ascii].GetChars(this, password, chars);
			if (Preset.FilterChars) chars = Filters[FilterName.Chars].GetChars(this, password, chars);
			return chars;
		}

		Controls.DynamicCompile.DcEngine engine;

		//-------------------------------------------------------
		public Word ApplyScript(Word password)
		{
			password.AppendLog("Info: ApplyScript to '{0}'\r\n", password.Text);
			LanguageType language = (LanguageType)Enum.Parse(typeof(LanguageType), Preset.ScriptLanguage);
			if (engine == null
				|| engine.SourceCode != Preset.ScriptCode
				|| engine.Language != language
				|| Preset.ScriptEntry != Preset.ScriptEntry)
			{
				engine = new Controls.DynamicCompile.DcEngine(Preset.ScriptCode, language, Preset.ScriptEntry);
				engine.CurrentAssembly = null;
			}
			string result = (string)engine.Run(this, password);
			if (result != null) password.Chars = result.ToCharArray();
			return password;
		}

		public int GetPasswordStrength(char[] passChars)
		{
			// Find which chars were used.
			bool haveUppercase = passChars.Intersect(Preset.CharsUppercase).Count() > 0;
			bool haveLowercase = passChars.Intersect(Preset.CharsLowercase).Count() > 0;
			bool haveNumbers = passChars.Intersect(Preset.CharsNumbers).Count() > 0;
			bool haveSymbols = passChars.Intersect(Preset.CharsSymbols).Count() > 0;
			bool haveExtra = Preset.CharsExtra.Length > 0 && passChars
				.Intersect(Preset.CharsUppercase)
				.Intersect(Preset.CharsLowercase)
				.Intersect(Preset.CharsNumbers)
				.Intersect(Preset.CharsSymbols)
				.Intersect(Preset.CharsExtra)
				.Count() > 0;
			// Calculate total number of used chars. 
			double chars = (haveUppercase ? Preset.CharsUppercase.Length : 0) +
				(haveLowercase ? Preset.CharsLowercase.Length : 0) +
				(haveNumbers ? Preset.CharsNumbers.Length : 0) +
				(haveSymbols ? Preset.CharsSymbols.Length : 0) +
				(haveExtra ? Preset.CharsExtra.Length : 0);
			// Calculate number of possible passwords.
			double number = Math.Pow(chars, (double)passChars.Length);
			// Calculate number of decimals (zeroes). 10000 => 4
			int strength = (int)Math.Round(Math.Log10(number));
			return strength;
		}


		Word ApplyRegex(Word password)
		{
			try
			{
				Regex rx = new Regex(Preset.RegexPatternFind);
				var s = new string(password.Chars);
				password.Chars = rx.Replace(s, Preset.RegexPatternReplace).ToCharArray();
			}
			catch (Exception ex)
			{
				password.AppendLog(ex.Message);
			}
			return password;
		}

	}
}
