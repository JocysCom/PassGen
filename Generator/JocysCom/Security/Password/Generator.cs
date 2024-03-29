﻿using JocysCom.ClassLibrary.Controls.DynamicCompile;
using JocysCom.ClassLibrary.Security.Password.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
				if (PresetChanged != null)
					PresetChanged(this, new EventArgs());
			}
		}

		private readonly Random rnd = new Random();

		public EventHandler<EventArgs> PresetChanged;

		private string _splitString(string s, string separator)
		{
			s.ToCharArray();
			return string.Join(separator, s.ToCharArray().Select(x => x.ToString()).ToArray());
		}

		public string NewPasswordList(int count, string separator)
		{
			var sb = new StringBuilder();
			for (var i = 0; i < count; i++)
			{
				if (i > 0)
					sb.Append(separator);
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
			//password.AppendLog("Info: Attempt {0} to generate password.\r\n", a);
			var types = new List<CharType>();
			var charsCount = 0;
			if (Preset.UseUppercase)
			{
				charsCount += Preset.CharsUppercase.Length;
				for (var i = 0; i < Preset.RatioUppercase; i++)
					types.Add(CharType.Uppercase);
			}
			if (Preset.UseLowercase)
			{
				charsCount += Preset.CharsLowercase.Length;
				for (var i = 0; i < Preset.RatioLowercase; i++)
					types.Add(CharType.Lowercase);
			}
			if (Preset.UseNumbers)
			{
				charsCount += Preset.CharsNumbers.Length;
				for (var i = 0; i < Preset.RatioNumbers; i++)
					types.Add(CharType.Number);
			}
			if (Preset.UseSymbols)
			{
				charsCount += Preset.CharsSymbols.Length;
				for (var i = 0; i < Preset.RatioSymbols; i++)
					types.Add(CharType.Symbol);
			}
			if (Preset.UseExtra)
			{
				charsCount += Preset.CharsExtra.Length;
				for (var i = 0; i < Preset.RatioExtra; i++)
					types.Add(CharType.Extra);
			}
			// Types must contains types of all chars.
			if (types.Count == 0)
			{
				password.AppendLog("Error: chars list is empty!\r\n");
				return password;
			}
			var list = new Dictionary<CharType, string>
			{
				{ CharType.Uppercase, Preset.CharsUppercase },
				{ CharType.Lowercase, Preset.CharsLowercase },
				{ CharType.Number, Preset.CharsNumbers },
				{ CharType.Symbol, Preset.CharsSymbols },
				{ CharType.Extra, Preset.CharsExtra }
			};
			//password.AppendLog("Info: Chars To Use: {0}\r\n", new string(charsToUse));
			// Now we can create our password.
			for (var i = 0; i < Preset.PasswordLength; i++)
			{
				var charsToGenerate = Preset.PasswordLength - i;
				var missing = new List<CharType>();
				if (Preset.UseUppercase && !password.Chars.Intersect(Preset.CharsUppercase).Any())
					missing.Add(CharType.Uppercase);
				if (Preset.UseLowercase && !password.Chars.Intersect(Preset.CharsLowercase).Any())
					missing.Add(CharType.Lowercase);
				if (Preset.UseNumbers && !password.Chars.Intersect(Preset.CharsNumbers).Any())
					missing.Add(CharType.Number);
				if (Preset.UseSymbols && !password.Chars.Intersect(Preset.CharsSymbols).Any())
					missing.Add(CharType.Symbol);
				if (Preset.UseExtra && !password.Chars.Intersect(Preset.CharsExtra).Any())
					missing.Add(CharType.Extra);
				// Get random type according to rate.
				var charType = types[rnd.Next(types.Count)];
				// Override with missing type.
				if (missing.Count > 0 && charsToGenerate <= missing.Count)
					charType = missing.FirstOrDefault();
				var chars = list[charType].ToArray();
				// Apply filters and get list of available chars.
				var filteredChars = FilterChars(password, chars);
				// If filters left some chars then...
				if (filteredChars.Length > 0)
				{
					// Calculate password strength (10^x).
					var strength = Math.Log(charsCount) / Math.Log(10);
					password.Strength += strength;
					// Get random char.
					var charPosition = rnd.Next(filteredChars.Length);
					var filteredChar = filteredChars[charPosition];
					password.AppendChar(filteredChar);
				}
				else
				{
					//password.AppendLog("Warning: filteredChars.length == 0\r\n");
					break;
				}
			}
			// If no filter enabled then randomize chars to make sure that missing chars are not at the end.
			if (!Preset.FilterRemember && !Preset.FilterKeyboard && !Preset.FilterPhone)
				Shuffle(password.Chars);
			// Apply regular expressions to password.
			if (Preset.RegexEnabled)
				password = ApplyRegex(password);
			// Apply script to password.
			if (Preset.ScriptEnabled)
				password = ApplyScript(password);
			// If password is empty then...
			if (password.Chars.Length != Preset.PasswordLength)
			{
				// Add error message.
				password.AppendLog("Error: all attempts to generate password was failed. Please relax password settings.\r\n");
			}
			return password;
		}

		private Dictionary<FilterName, Filter> _Filters;
		public Dictionary<FilterName, Filter> Filters
		{
			get
			{
				if (_Filters == null)
				{
					_Filters = new Dictionary<FilterName, Filter>
					{
						{ FilterName.Remember, new Templates.Filters.Remember() },
						{ FilterName.Keyboard, new Templates.Filters.Keyboard() },
						{ FilterName.Phone, new Templates.Filters.Phone() },
						{ FilterName.Chars, new Templates.Filters.Chars() }
					};
				}
				return _Filters;
			}
		}

		private char[] FilterChars(Word password, char[] chars)
		{
			if (Preset.FilterRemember)
				chars = Filters[FilterName.Remember].GetChars(this, password, chars);
			if (Preset.FilterKeyboard)
				chars = Filters[FilterName.Keyboard].GetChars(this, password, chars);
			if (Preset.FilterPhone)
				chars = Filters[FilterName.Phone].GetChars(this, password, chars);
			if (Preset.FilterChars)
				chars = Filters[FilterName.Chars].GetChars(this, password, chars);
			return chars;
		}

		private T[] Shuffle<T>(T[] array)
		{
			var i = array.Length;
			T temporaryValue;
			var randomIndex = 0;
			// While there remain elements to shuffle...
			while (i > 0)
			{
				// Pick a remaining element...
				randomIndex = rnd.Next(i);
				i--;
				// And swap it with the current element.
				temporaryValue = array[i];
				array[i] = array[randomIndex];
				array[randomIndex] = temporaryValue;
			}
			return array;
		}

		private Controls.DynamicCompile.DcEngine engine;

		//-------------------------------------------------------
		public Word ApplyScript(Word password)
		{
			password.AppendLog("Info: ApplyScript to '{0}'\r\n", password.Text);
			// If thre is no code then return original password.
			if (string.IsNullOrEmpty(Preset.ScriptCode))
				return password;
			var language = (LanguageType)Enum.Parse(typeof(LanguageType), Preset.ScriptLanguage);
			if (engine == null
				|| engine.SourceCode != Preset.ScriptCode
				|| engine.Language != language
				|| Preset.ScriptEntry != Preset.ScriptEntry)
			{
				engine = new Controls.DynamicCompile.DcEngine(Preset.ScriptCode, language, Preset.ScriptEntry);
			}
			var result = (string)engine.Run(this, password);
			if (result != null)
				password.Chars = result.ToCharArray();
			return password;
		}

		public int GetPasswordStrength(char[] passChars)
		{
			// Find which chars were used.
			var haveUppercase = passChars.Intersect(Preset.CharsUppercase).Any();
			var haveLowercase = passChars.Intersect(Preset.CharsLowercase).Any();
			var haveNumbers = passChars.Intersect(Preset.CharsNumbers).Any();
			var haveSymbols = passChars.Intersect(Preset.CharsSymbols).Any();
			var haveExtra = Preset.CharsExtra.Length > 0 && passChars
				.Intersect(Preset.CharsUppercase)
				.Intersect(Preset.CharsLowercase)
				.Intersect(Preset.CharsNumbers)
				.Intersect(Preset.CharsSymbols)
				.Intersect(Preset.CharsExtra).Any();
			// Calculate total number of used chars. 
			double chars = (haveUppercase ? Preset.CharsUppercase.Length : 0) +
				(haveLowercase ? Preset.CharsLowercase.Length : 0) +
				(haveNumbers ? Preset.CharsNumbers.Length : 0) +
				(haveSymbols ? Preset.CharsSymbols.Length : 0) +
				(haveExtra ? Preset.CharsExtra.Length : 0);
			// Calculate number of possible passwords.
			var number = Math.Pow(chars, passChars.Length);
			// Strength of the password in bits.
			// It represents N where 2 ^ N is a number of all possible password variations required
			// to check by brute-force algorithm in order to crack you password successfully.
			var strength = (int)Math.Round(Math.Log(number, 2));
			return strength;
		}

		private Word ApplyRegex(Word password)
		{
			try
			{
				var rx = new Regex(Preset.RegexPatternFind);
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
