using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JocysCom.ClassLibrary.Security.Password.Templates.Filters
{

	public partial class ASCII : Filter
	{
		public ASCII()
		{
			FilterName = "ASCII Only";
			FilterDescription = "Remove all non ASCII characters from password.";
		}

		/// <summary>
		/// Removes all non ASCII chars from charsList.
		/// </summary>
		/// <returns type="System.Char[]">Array of chars.</returns>
		public override char[] GetChars(Generator generator, Word password, char[] charsList)
		{
			ValidateInput(generator, password, charsList);
			if (charsList.Length == 0) return charsList;
			// Keep only proper chars.
			charsList = charsList.Intersect(charsets.Chars["ASCII"]).ToArray();
			ValidateOutput(generator, password, charsList);
			return charsList;
		}

	}

}
