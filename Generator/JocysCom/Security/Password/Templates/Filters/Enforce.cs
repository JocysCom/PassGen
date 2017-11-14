using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JocysCom.ClassLibrary.Security.Password.Templates.Filters
{
	public partial class Enforce : Filter
	{

		public Enforce()
		{
			FilterName = "Enforce Chars";
			FilterDescription = "Analyse password and make sure that all char types checked for use are used inside password.";
		}

		/// <summary>
		/// Analyse password and make suer that all char types set for use are used inside password.
		/// </summary>
		/// <returns type="System.Char[]">Array of chars.</returns>
		public override char[] GetChars(Generator generator, Word password, char[] charsList)
		{
			ValidateInput(generator, password, charsList);
			if (charsList.Length == 0) return charsList;
			Preset p = generator.Preset;
			// How many chars left to generate.
			int leftChars = p.PasswordLength - password.Chars.Length;
			bool haveUppercase = p.UseUppercase && password.Chars.Intersect(p.CharsUppercase).Count() > 0;
			bool haveLowercase = p.UseLowercase && password.Chars.Intersect(p.CharsLowercase).Count() > 0;
			bool haveNumbers = p.UseNumbers && password.Chars.Intersect(p.CharsNumbers).Count() > 0;
			bool haveSymbols = p.UseSymbols && password.Chars.Intersect(p.CharsSymbols).Count() > 0;
			bool haveExtra = p.UseExtra && p.CharsExtra.Length > 0 && password.Chars.Intersect(p.CharsExtra).Count() > 0;
			// How many char types are not used yet.
			int tc = 0;
			if (p.UseUppercase && !haveUppercase) tc++;
			if (p.UseLowercase && !haveLowercase) tc++;
			if (p.UseNumbers && !haveNumbers) tc++;
			if (p.UseSymbols && !haveSymbols) tc++;
			if (p.UseExtra && !haveExtra) tc++;
			// if no space for random generation left then...
			if (leftChars == tc)
			{
				Preset preset = generator.Preset.Copy();
				//Disable chars which were used
				if (preset.UseUppercase && haveUppercase) preset.UseUppercase = false;
				if (preset.UseLowercase && haveLowercase) preset.UseLowercase = false;
				if (preset.UseNumbers && haveNumbers) preset.UseNumbers = false;
				if (preset.UseSymbols && haveSymbols) preset.UseSymbols = false;
				if (preset.UseExtra && haveExtra) preset.UseExtra = false;
				// Generate new chars list.
				charsList = preset.GetChars().Intersect(charsList).ToArray();
			}
			ValidateOutput(generator, password, charsList);
			return charsList;
		}

	}
}
