using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetCommon
{
	public static class PathEx
	{
		public static string RemoveDoubleQuote(string path)
		{
			if (path.Length > 1 && path.StartsWith("\"") && path.EndsWith("\""))
				return path.Remove(path.Length - 1, 1).Remove(0, 1);
			else
				return path;
		}

		public static bool IsValidRootedPath(string path)
		{
			try
			{
				return Path.IsPathRooted(path);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
