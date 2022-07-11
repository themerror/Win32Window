using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	// Did not find the the definition, thought this is for value -1
	public static class Win32_CW_Constant
	{
		//public const int CW_USEDEFAULT = (int)0x80000000;
		public const int CW_USEDEFAULT = -1;
	}

	//To show you how this Win32_CW_Constants is used, chck on the following code snippet.
#if false
	IntPtr hwnd = Win32Api.CreateWindowEx2(
			0,
			regRest,
			"The hello proram",
			WindowStyles.WS_OVERLAPPEDWINDOW,
			Win32_CW_Constant.CW_USEDEFAULT,
			Win32_CW_Constant.CW_USEDEFAULT,
			Win32_CW_Constant.CW_USEDEFAULT,
			Win32_CW_Constant.CW_USEDEFAULT,
			IntPtr.Zero,
			IntPtr.Zero,
			hInstance,
			IntPtr.Zero);
#endif
}
