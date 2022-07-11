using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public static class Win32Api
	{
		// Messagae pump with C# and p/invke please check out https://docs.microsoft.com/en-us/windows/win32/winmsg/using-messages-and-message-queues
		//
		// General Reference Page: http://www.pinvoke.net
		[DllImport("user32.dll")]
		public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

		[DllImport("user32.dll")]
		public static extern bool TranslateMessage([In] ref MSG lpMsg);

		[DllImport("user32.dll")]
		public static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
		   uint wMsgFilterMax);

		public static IntPtr CreateWindow(
		   string lpClassName,
		   string lpWindowName,
		   WindowStyles dwStyle,
		   int x,
		   int y,
		   int nWidth,
		   int nHeight,
		   IntPtr hWndParent,
		   IntPtr hMenu,
		   IntPtr hInstance,
		   IntPtr lpParam)
		{
			return CreateWindowEx(
				0,
				lpClassName,
				lpWindowName,
				dwStyle,
				x,
				y,
				nWidth,
				nHeight,
				hWndParent,
				hMenu,
				hInstance,lpParam);
		}

		// To use CreateWindow, just pass 0 as the first argument.
		[DllImport("user32.dll", SetLastError = true, EntryPoint = "CreateWindowEx")]
		public static extern IntPtr CreateWindowEx(
		   WindowStylesEx dwExStyle,
		   string lpClassName,
		   string lpWindowName,
		   WindowStyles dwStyle,
		   int x,
		   int y,
		   int nWidth,
		   int nHeight,
		   IntPtr hWndParent,
		   IntPtr hMenu,
		   IntPtr hInstance,
		   IntPtr lpParam);

		// Create a window, but accept a atom value.
		[DllImport("user32.dll", SetLastError = true, EntryPoint = "CreateWindowEx")]
		public static extern IntPtr CreateWindowEx2(
		   WindowStylesEx dwExStyle,
		   UInt16 lpClassName,
		   string lpWindowName,
		   WindowStyles dwStyle,
		   int x,
		   int y,
		   int nWidth,
		   int nHeight,
		   IntPtr hWndParent,
		   IntPtr hMenu,
		   IntPtr hInstance,
		   IntPtr lpParam);

		[DllImport("user32.dll")]
		public static extern ushort RegisterClass([In] ref WNDCLASS lpWndClass);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

		[DllImport("user32.dll")]
		public static extern IntPtr BeginPaint(IntPtr hwnd, out PAINTSTRUCT lpPaint);

		[DllImport("user32.dll")]
		public static extern IntPtr DefWindowProc(IntPtr hWnd, WM uMsg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

		[DllImport("user32.dll")]
		public static extern int DrawText(IntPtr hDC, string lpString, int nCount, ref RECT lpRect, uint uFormat);

		[DllImport("user32.dll")]
		public static extern bool EndPaint(IntPtr hWnd, [In] ref PAINTSTRUCT lpPaint);

		[DllImport("user32.dll")]
		public static extern void PostQuitMessage(int nExitCode);

		[DllImport("user32.dll")]
		public static extern IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

		[DllImport("user32.dll")]
		public static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIConName);

		[DllImport("gdi32.dll")]
		public static extern IntPtr GetStockObject(StockObjects fnObject);

		[DllImport("user32.dll")]
		public static extern MessageBoxResult MessageBox(IntPtr hWnd, string text, string caption, int options);

		[DllImport("user32.dll")]
		public static extern bool UpdateWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

		[DllImport("user32.dll")]
		public static extern short RegisterClassEx([In] ref WNDCLASSEX lpwcx);

		[DllImport("user32.dll", SetLastError = true, EntryPoint = "RegisterClassEx")]
		public static extern UInt16 RegisterClassEx2([In] ref WNDCLASSEX lpwcx);
	}
}
