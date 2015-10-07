using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JocysCom.ClassLibrary.Security.Password.Templates.Filters
{

	public partial class Chars : Filter
	{

		public Chars()
		{
			FilterName = "Chars";
			FilterDescription = "Remove custom characters from password.";
		}

		/// <summary>
		/// Removes rare chars from charsList.
		/// </summary>
		/// <returns type="System.Char[]">Array of chars.</returns>
		public override char[] GetChars(Generator generator, Word password, char[] charsList)
		{
			ValidateInput(generator, password, charsList);
			if (charsList.Length == 0) return charsList;
			// Remove specified chars. 
			charsList = charsList.Except(generator.Preset.FilterCharsString.ToCharArray()).ToArray();
			ValidateOutput(generator, password, charsList);
			return charsList;
		}

	}

}
