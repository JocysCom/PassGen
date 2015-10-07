using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JocysCom.ClassLibrary.Security.Password.Templates
{
	public partial class Charsets
	{

		public Charsets()
		{
			initAscii();
			// These two can by changed by user.
			Strings.Add("Extra", "£€");
			Strings.Add("Chars", "qwxzQWZX");
			// Chars for easy to remmeber filter.
			Strings.Add("Volves", "aeiouyAEIOUY");
			Strings.Add("Consonants", "bcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ");
			// Phone keyboard.
			Strings.Add("PhoneKey0", "0");
			Strings.Add("PhoneKey1", "1");
			Strings.Add("PhoneKey2", "2abcABC");
			Strings.Add("PhoneKey3", "3defDEF");
			Strings.Add("PhoneKey4", "4ghiGHI");
			Strings.Add("PhoneKey5", "5jklJKL");
			Strings.Add("PhoneKey6", "6mnoMNO");
			Strings.Add("PhoneKey7", "7pqrsPQRS");
			Strings.Add("PhoneKey8", "8tuvTUV");
			Strings.Add("PhoneKey9", "9wxyzWXYZ");
			Strings.Add("PhoneKey10", "*");
			Strings.Add("PhoneKey11", "#");
			// PC Keyboard.
			Strings.Add("KeyboardLeft", "123456qwertasdfgzxcvbQWERTASDFGZXCVB`¬!\"$%^|");
			Strings.Add("KeyboardRight", "7890yuiophjklnmYUIOPHJKLNM-=[];'#,./()_+{}:@~<>?");
			// Create additional properties. Keep same order!
			Strings.Add("Letters", Strings["Uppercase"] + Strings["Lowercase"]);
			Strings.Add("Letnums", Strings["Letters"] + Strings["Numbers"]);
			Strings.Add("Keyboard", Strings["KeyboardLeft"] + Strings["KeyboardRight"]);
			Strings.Add("ASCII", Strings["Letnums"] + Strings["Symbols"]);
			// Create Regular Expressions.
			foreach (var key in Strings.Keys)
			{
				Patterns.Add(key, GetPatternFromString(Strings[key]));
				RegexPos.Add(key, new Regex("[" + Patterns[key] + "]", RegexOptions.Multiline));
				RegexNeg.Add(key, new Regex("[^" + Patterns[key] + "]", RegexOptions.Multiline));
				Chars.Add(key, Strings[key].ToCharArray());
			}
		}

		private void initAscii()
		{
			string numbers = string.Empty;
			string lowercase = string.Empty;
			string uppercase = string.Empty;
			string symbols = string.Empty;
			//List<string> list = new List<string>(); 
			//string s = string.Empty;
			for (int i = 1; i < 127; i++)
			{
				var c = System.Text.Encoding.ASCII.GetChars(new byte[] { (byte)i }).First();
				if (Char.IsControl(c)) continue;
				//list.Add(string.Format("{0} - {1} - {2}", i, c, Char.GetUnicodeCategory(c)));
				if (Char.IsNumber(c))
				{
					numbers += c.ToString();
				}
				else if (Char.IsLetter(c) && Char.IsLower(c))
				{
					lowercase += c.ToString();
				}
				else if (Char.IsLetter(c) && Char.IsUpper(c))
				{
					uppercase += c.ToString();
				}
				else if ((Char.IsSymbol(c) || Char.IsPunctuation(c)))
				{
					symbols += c.ToString();
				}
				else
				{
					//s += c.ToString();
				}
			}
			Strings.Add("Numbers", numbers);
			Strings.Add("Uppercase", uppercase);
			Strings.Add("Lowercase", lowercase);
			Strings.Add("Symbols", symbols);
		}

		public Dictionary<string, string> Strings = new Dictionary<string, string>();
		public Dictionary<string, string> Patterns = new Dictionary<string, string>();
		public Dictionary<string, Regex> RegexPos = new Dictionary<string, Regex>();
		public Dictionary<string, Regex> RegexNeg = new Dictionary<string, Regex>();
		public Dictionary<string, char[]> Chars = new Dictionary<string, char[]>();

		/// <summary>
		/// Get Regular expression pattern from string.
		/// </summary>
		/// <returns name="s" type="String">Regular expression pattern</returns>
		public string GetPatternFromString(string s)
		{
			var filter = new JocysCom.ClassLibrary.Text.Filters();
			return filter.GetEscapedPattern(s);
		}

	}
}