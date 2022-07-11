using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	// check on this page: http://www.pinvoke.net/default.aspx/Enums/MessageBoxResult.html
	/// <summary>
	/// Represents possible values returned by the MessageBox function.
	/// </summary>
	public enum MessageBoxResult : uint
	{
		Ok = 1,
		Cancel,
		Abort,
		Retry,
		Ignore,
		Yes,
		No,
		Close,
		Help,
		TryAgain,
		Continue,
		Timeout = 32000
	}
}
