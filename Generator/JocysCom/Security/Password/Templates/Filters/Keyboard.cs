using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JocysCom.ClassLibrary.Security.Password.Templates.Filters
{

	public partial class Keyboard : Filter
	{

		public Keyboard()
		{
			FilterName = "For PC Keyboaard";
			FilterDescription = "Make sure that each next pasword character will be located on different side of keyboard.";
		}

		/// <summary>
		/// Analyses last char of password and removes all chars which are located on same side of keyboard.
		/// </summary>
		/// <returns type="System.Char[]">Array of chars.</returns>
		public override char[] GetChars(Generator generator, Word password, char[] charsList)
		{
			ValidateInput(generator, password, charsList);
			if (charsList.Length == 0) return charsList;
			// Keep only proper chars which exists on keyboard.
			var chars = charsList.Intersect(charsets.Chars["Keyboard"]);
			// Limit if this is second+ letter only.
			if (password.Chars.Length > 0)
			{
				// Get last char.
				var lastChar = password.Chars.Last();
				// If Previous character is on the left side then...
				if (charsets.Chars["KeyboardLeft"].Contains(lastChar))
				{
					// Remove left side chars.
					chars = chars.Except(charsets.Chars["KeyboardLeft"]);
				}
				else
				{
					// Remove right side chars.
					chars = chars.Except(charsets.Chars["KeyboardRight"]);
				}
			}
			charsList = chars.ToArray();
			ValidateOutput(generator, password, charsList);
			return charsList;
		}

	}
}