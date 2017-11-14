using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JocysCom.ClassLibrary.Security.Password.Templates
{
	[Serializable]
	public partial class PresetBase
	{
		public string PresetName;
		public string PresetDescription;
		public string PresetRemarks;
		// Set password length property.
		public int? PasswordLength;
		// Set Use property.
		public bool? UseUppercase;
		public bool? UseLowercase;
		public bool? UseNumbers;
		public bool? UseSymbols;
		public bool? UseExtra;
		// Set Use ratios.
		public int? RatioUppercase;
		public int? RatioLowercase;
		public int? RatioNumbers;
		public int? RatioSymbols;
		public int? RatioExtra;
		// Setup characters.
		// These values will be updated automatically from
		// System.Security.Password.Templates.Charsets
		public string CharsUppercase;
		public string CharsLowercase;
		public string CharsNumbers;
		public string CharsSymbols;
		public string CharsExtra;
		// Filters.
		public bool? FilterRemember;
		public bool? FilterKeyboard;
		public bool? FilterEnforce;
		public bool? FilterPhone;
		public bool? FilterAscii;
		public bool? FilterChars;
		public string FilterCharsString;
		// Scripting.
		public bool? ScriptEnabled;
		public string ScriptEntry;
		public string ScriptLanguage;
		public string ScriptCode;
		// Regular Expressions.
		public bool? RegexEnabled;
		public string RegexPatternFind;
		public string RegexPatternReplace;
		public bool? RegexIgnoreCase;
	}
}
