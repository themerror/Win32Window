using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
	#region

	// WndProcDelegate http://www.pinvoke.net/default.aspx/user32/WndProcDelegate.html
	public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	public delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	#endregion

	internal class Program
	{
		private static IntPtr hinst;
		private static UInt16 atom;

		private static void Main(string[] args)
		{
			Main2(System.Diagnostics.Process.GetCurrentProcess().Handle, IntPtr.Zero, string.Empty, (int)ShowWindowCommands.Normal);
		}

		// Reference: https://docs.microsoft.com/en-us/windows/win32/winmsg/using-window-classes

		private static bool Main2(IntPtr hinstance, IntPtr hPrevInstance, string lpCmdLine, int nCmdShow)
		{
			MSG msg;

			if (!InitApplication(hinstance))
				return false;

			if (!InitInstance(hinstance, nCmdShow))
				return false;

			sbyte hasMessage;

			while ((hasMessage = Win32Api.GetMessage(out msg, IntPtr.Zero, 0, 0)) != 0 && hasMessage != -1)
			{
				Win32Api.TranslateMessage(ref msg);
				Win32Api.DispatchMessage(ref msg);
			}
			return msg.wParam == UIntPtr.Zero;
		}

		private static bool InitApplication(IntPtr hinstance)
		{
			WNDCLASSEX wcx = new WNDCLASSEX();

			wcx.cbSize = Marshal.SizeOf(wcx);
			wcx.style = (int)(ClassStyles.VerticalRedraw | ClassStyles.HorizontalRedraw);

			IntPtr address2 = Marshal.GetFunctionPointerForDelegate((Delegate)(WndProc)MainWndProc);
			wcx.lpfnWndProc = address2;

			wcx.cbClsExtra = 0;
			wcx.cbWndExtra = 0;
			wcx.hInstance = hinstance;
			wcx.hIcon = Win32Api.LoadIcon(
					IntPtr.Zero, new IntPtr((int)2));
			wcx.hCursor = Win32Api.LoadCursor(IntPtr.Zero, (int)Win32_IDC_Constants.IDC_ARROW);
			wcx.hbrBackground = Win32Api.GetStockObject(StockObjects.WHITE_BRUSH);
			wcx.lpszMenuName = "MainMenu";
			wcx.lpszClassName = "MainWClass";

			UInt16 ret = Win32Api.RegisterClassEx2(ref wcx);
			if (ret != 0)
			{
				string message = new Win32Exception(Marshal.GetLastWin32Error()).Message;
				Console.WriteLine("Failed to call RegisterClasEx, error = {0}", message);
			}
			atom = ret;
			return ret != 0;
		}

		private static bool InitInstance(IntPtr hInstance, int nCmdShow)
		{
			IntPtr hwnd;

			hinst = hInstance;
			hwnd = Win32Api.CreateWindowEx2(
				0,
				atom,								// name of window class 
				"Sample",							// title-bar string 
				WindowStyles.WS_OVERLAPPEDWINDOW,   // top-level window 
				Win32_CW_Constant.CW_USEDEFAULT,    // 0 horizontal position 
				Win32_CW_Constant.CW_USEDEFAULT,	// 0 vertical position 
				400,								// 400 width 
				300,								// 300 height 
				IntPtr.Zero,						// no owner window 
				IntPtr.Zero,						// use class menu 
				hInstance,							// handle to application instance 
				IntPtr.Zero);						// no window-creation data 
			if (hwnd == IntPtr.Zero)
			{
				string error = new Win32Exception(Marshal.GetLastWin32Error()).Message;
				Console.WriteLine("Failed to InitInstance , error = {0}", error);
				return false;
			}
			Win32Api.ShowWindow(hwnd, (ShowWindowCommands)nCmdShow);
			Win32Api.UpdateWindow(hwnd);
			return true;
		}

		private static IntPtr MainWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			IntPtr hdc;
			PAINTSTRUCT ps;
			RECT rect;
			switch ((WM)msg)
			{
				case WM.PAINT:
					hdc = Win32Api.BeginPaint(hWnd, out ps);
					Win32Api.GetClientRect(hWnd, out rect);
					Win32Api.DrawText(hdc, "Hello, Win 32!", -1, ref rect, Win32_DT_Constant.DT_SINGLELINE | Win32_DT_Constant.DT_CENTER | Win32_DT_Constant.DT_VCENTER);
					Win32Api.EndPaint(hWnd, ref ps);
					return IntPtr.Zero;
					break;

				case WM.DESTROY:
					Win32Api.PostQuitMessage(0);
					return IntPtr.Zero;
					break;
			}

			return Win32Api.DefWindowProc(hWnd, (WM)msg, wParam, lParam);
		}
	}
}