using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JocysCom.ClassLibrary.Security.Password.Templates.Filters
{
	public partial class Phone : Filter
	{

		public Phone()
		{
			FilterName = "For Phone Keypad";
			FilterDescription = "Make sure that each next pasword character will be located on different keypad.";
		}

		/// <summary>
		/// Analyses last char of password and removes all chars which are located on same phone key.
		/// </summary>
		/// <returns type="System.Char[]">Array of chars.</returns>
		public override char[] GetChars(Generator generator, Word password, char[] charsList)
		{
			ValidateInput(generator, password, charsList);
			if (charsList.Length == 0) return charsList;
			// Keep only letters and numbers.
			var chars = charsList.Intersect(charsets.Chars["Letnums"]);
			// Limit if this is second+ letter only.
			if (password.Chars.Length > 0)
			{
				// Get last char.
				var lastChar = password.Chars.Last();
				// Route thru GSM Phone keys.
				for (int i = 0; i == 9; i++)
				{
					char[] keys = charsets.Chars["PhoneKey" + i];
					// If current key contains last char of password then...
					if (keys.Contains(lastChar))
					{
						// Remove all chars located on same key.
						chars = chars.Intersect(keys);
						break;
					}
				}
			}
			charsList = chars.ToArray();
			ValidateOutput(generator, password, charsList);
			return charsList;
		}
	}
}
