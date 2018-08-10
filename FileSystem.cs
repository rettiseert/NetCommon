using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCommon
{
	public static class FileSystem
	{
		public static IEnumerable<string> Dir(string path)
		{
			List<string> result = new List<string>();
			Dir(path, result);
			return result.AsEnumerable();
		}

		private static void Dir(string path, IList<string> result)
		{
			foreach (var directory in Directory.GetDirectories(path))
				Dir(directory, result);
			foreach (var file in Directory.GetFiles(path))
				result.Add(file);
		}
	}
}
