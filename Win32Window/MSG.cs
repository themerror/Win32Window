using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	//typedef struct tagMSG {
	//  HWND   hwnd;
	//  UINT   message;
	//  WPARAM wParam;
	//  LPARAM lParam;
	//  DWORD  time;
	//  POINT  pt;
	//} MSG, *PMSG, *LPMSG;

	// MSG structure http://msdn.microsoft.com/en-us/library/windows/desktop/ms644958(v=vs.85).aspx
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct MSG
	{
		public IntPtr hwnd;
		public UInt32 message;
		public UIntPtr wParam;
		public UIntPtr lParam;
		public UInt32 time;
		public POINT pt;
	}
}
