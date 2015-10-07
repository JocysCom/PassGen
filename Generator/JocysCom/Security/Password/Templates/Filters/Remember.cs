using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JocysCom.ClassLibrary.Security.Password.Templates.Filters
{
	public partial class Remember : Filter
	{

		public Remember()
		{
			FilterName = "Easy to Remember";
			FilterDescription = "Combine volves and consonants in such order so password will look as normal word.";
		}

		/// <summary>
		/// Analyses type of last char (volve or consonant) and removes all chars of same type.
		/// This creates <volve>,<consonant>,<volve>,<consonant>,... password.
		/// </summary>
		/// <returns type="System.Char[]">Array of chars.</returns>
		public override char[] GetChars(Generator generator, Word password, char[] charsList)
		{
			ValidateInput(generator, password, charsList);
			if (charsList.Length == 0) return charsList;
			// Keep only proper chars (volves and consonants).
			var chars = charsList.Intersect(charsets.Chars["Letters"]);
			// If password already contains some chars then...
			if (password.Chars.Length > 0)
			{
				// If last character is volve then...
				if (charsets.Chars["Volves"].Contains(password.Chars.Last()))
				{
					// Keep only consonants.
					chars = chars.Intersect(charsets.Chars["Consonants"]);
				}
				else
				{
					// Keep only volves.
					chars = chars.Intersect(charsets.Chars["Volves"]);
				}
			}
			charsList = chars.ToArray();
			ValidateOutput(generator, password, charsList);
			return charsList;
		}

	}
}
