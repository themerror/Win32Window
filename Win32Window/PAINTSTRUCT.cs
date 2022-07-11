using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	//The PAINTSTRUCT is the strucute use by the GDI function BegingPaint and EndPaint function call.

	// http://www.pinvoke.net/default.aspx/Structures/PAINTSTRUCT.html
	[StructLayout(LayoutKind.Sequential)]
	public struct PAINTSTRUCT
	{
		public IntPtr hdc;
		public bool fErase;
		public RECT rcPaint;
		public bool fRestore;
		public bool fIncUpdate;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] rgbReserved;
	}
}
