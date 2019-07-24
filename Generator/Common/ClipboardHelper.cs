using System;
using System.Runtime.InteropServices;
using System.Linq;

namespace JocysCom.Password.Generator
{
	public class ClipboardHelper
	{
		internal class NativeMethods
		{

			[DllImport("user32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

			[DllImport("user32.dll", SetLastError = true)]
			public static extern bool EmptyClipboard();

			[DllImport("user32.dll", SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool CloseClipboard();

			[DllImport("user32.dll", SetLastError = true)]
			internal static extern IntPtr SetClipboardData(uint uFormat, IntPtr data);
		}

		[STAThread]
		public static bool SetClipboardText(string text)
		{
			var isUnicode = text != null && text.Any(x => x >= 128);
			// CF_TEXT = 1, CF_UNICODETEXT = 13
			var hglobal = isUnicode
				? Marshal.StringToHGlobalUni(text)
				: Marshal.StringToHGlobalAnsi(text);
			if (hglobal == IntPtr.Zero)
				return false;
			if (!NativeMethods.OpenClipboard(IntPtr.Zero))
			{
				Marshal.FreeHGlobal(hglobal);
				return false;
			}
			NativeMethods.EmptyClipboard();
			var format = isUnicode ? (uint)13 : 1;
			var success = (NativeMethods.SetClipboardData(format, hglobal) != IntPtr.Zero);
			// If failed to set then...
			if (!success)
				// Free resource because it won't be used by the clipboard.
				Marshal.FreeHGlobal(hglobal);
			NativeMethods.CloseClipboard();
			return success;
		}
	}
}
