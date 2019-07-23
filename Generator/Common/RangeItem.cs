using JocysCom.ClassLibrary.Security.Password.Templates;
using System.Text;
using System.Text.Unicode;
using System.Linq;
using System.Globalization;

namespace JocysCom.Password.Generator
{
	public class RangeItem
	{
		public RangeItem(string name, UnicodeRange range, int? overrideLength = null)
		{
			Name = name;
			Range = range;
			Preset = new Preset(false);
			Preset.PresetName = "Range: " + name;
			var l = overrideLength ?? range.Length;
			for (int i = 0; i < range.Length; i++)
			{
				var code = range.FirstCodePoint + i;
				var c = (char)code;
				if (char.IsLetter(c) && char.IsUpper(c) && !IsLetterWithDiacritics(c))
					Preset.CharsUppercase += c;
				else if (char.IsLetter(c) && char.IsLower(c) && !IsLetterWithDiacritics(c))
					Preset.CharsLowercase += c;
				else if (char.IsNumber(c))
					Preset.CharsNumbers += c;
				else if (char.IsSymbol(c) || char.IsSeparator(c))
					Preset.CharsSymbols += c;
			}
		}

		public override string ToString()
		{
			return Name;
		}

		bool IsLetterWithDiacritics(char c)
		{
			var s = c.ToString().Normalize(NormalizationForm.FormD);
			return (s.Length > 1) &&
				   char.IsLetter(s[0]) &&
				   s.Skip(1).All(c2 => CharUnicodeInfo.GetUnicodeCategory(c2) == UnicodeCategory.NonSpacingMark);
		}

		public string Name { get; set; }
		public UnicodeRange Range { get; set; }
		public Preset Preset { get; set; }
	}
}
