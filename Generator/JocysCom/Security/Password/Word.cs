using System;
using System.Text;

namespace JocysCom.ClassLibrary.Security.Password
{
	public partial class Word
	{
		public string Text
		{
			get { return new string(Chars); }
		}

		private char[] _Chars;
		public char[] Chars
		{
			get { return _Chars = _Chars ?? new char[0]; }
			set { _Chars = value; }
		}

		public double Strength { get; set; }

		private StringBuilder _Log;
		public StringBuilder Log
		{
			get { return _Log = _Log ?? new StringBuilder(); }
		}

		public void AppendChar(char c)
		{
			if (_Chars == null)
				_Chars = new char[0];
			Array.Resize(ref _Chars, _Chars.Length + 1);
			_Chars[_Chars.Length - 1] = c;
		}


		public void AppendLog(string format, params object[] args)
		{
			Log.Append(string.Format(format, args));
		}

	}
}
