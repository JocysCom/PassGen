using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JocysCom.ClassLibrary.Security.Password.Templates
{
	public partial class Filter
	{
		protected Charsets charsets = new Charsets();

		public string FilterName;
		public string FilterDescription;

		public virtual char[] GetChars(Generator generator, Word password, char[] chars)
		{
			return chars;
		}

		public virtual void ValidateInput(Generator generator, Word password, char[] chars){
			if (chars.Length == 0){
				password.AppendLog("Error: Chars list supplied to '{0}' filter is empty.\r\n", FilterName);
			}
		}

		public virtual void ValidateOutput(Generator generator, Word password, char[] chars)
		{
			if (chars.Length == 0)
			{
				password.AppendLog("Error: '{0}' filter removed all chars from list.\r\n", FilterName);
			}
		}


	}
}
