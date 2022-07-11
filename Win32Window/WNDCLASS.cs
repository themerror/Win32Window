using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	// http://www.pinvoke.net/default.aspx/Structures.WNDCLASS
	[StructLayout(LayoutKind.Sequential)]
	public struct WNDCLASS
	{
		public ClassStyles style;

		[MarshalAs(UnmanagedType.FunctionPtr)]
		public WndProc lpfnWndProc;

		public int cbClsExtra;
		public int cbWndExtra;
		public IntPtr hInstance;
		public IntPtr hIcon;
		public IntPtr hCursor;
		public IntPtr hbrBackground;

		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszMenuName;

		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszClassName;
	}
}
