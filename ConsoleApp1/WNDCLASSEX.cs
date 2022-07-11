using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	// check on this: http://www.pinvoke.net/default.aspx/Structures/WNDCLASSEX.html
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WNDCLASSEX
	{
		[MarshalAs(UnmanagedType.U4)]
		public int cbSize;

		[MarshalAs(UnmanagedType.U4)]
		public int style;

		public IntPtr lpfnWndProc; // not WndProc -- careful
		public int cbClsExtra;
		public int cbWndExtra;
		public IntPtr hInstance;
		public IntPtr hIcon;
		public IntPtr hCursor;
		public IntPtr hbrBackground;
		public string lpszMenuName;
		public string lpszClassName;
		public IntPtr hIconSm;
	}
}
