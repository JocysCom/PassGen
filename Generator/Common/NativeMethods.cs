using System.Runtime.InteropServices;

namespace JocysCom.Password.Generator
{
	public class NativeMethods
	{

		[DllImport("USER32.DLL", EntryPoint = "BroadcastSystemMessageA", SetLastError = true,
		CharSet = CharSet.Unicode, ExactSpelling = true,
		CallingConvention = CallingConvention.StdCall)]
		internal static extern int BroadcastSystemMessage(int dwFlags, ref int pdwRecipients, int uiMessage, int wParam, int lParam);


		[DllImport("USER32.DLL", EntryPoint = "RegisterWindowMessageA", SetLastError = true,
		CharSet = CharSet.Unicode, ExactSpelling = true,
		CallingConvention = CallingConvention.StdCall)]
		internal static extern int RegisterWindowMessage(string pString);

	}
}
