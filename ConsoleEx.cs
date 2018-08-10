using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCommon
{
	public static class ConsoleEx
	{
		public static string ReadExistingFilePath(string question)
		{
			return ReadExistingFilePath(question, null);
		}

		public static string ReadExistingFilePath(string question, string @default)
		{
			return ReadExistingPath(question, @default, (o => File.Exists(o)));
		}

		public static string ReadExistingFolderPath(string question)
		{
			return ReadExistingFolderPath(question, null);
		}

		public static string ReadExistingFolderPath(string question, string @default)
		{
			return ReadExistingPath(question, @default, (o => Directory.Exists(o)));
		}

		public static string ReadExistingPath(string question, string @default, Func<string, bool> existsFunc)
		{
			string result = null;
			do
			{
				Console.WriteLine(
					question +
					(@default != null ? string.Format(" [{0}]", @default) : string.Empty)
				);
				var answer = Console.ReadLine().Trim();
				answer = PathEx.RemoveDoubleQuote(answer);
				if (@default != null && answer.IsEmpty())
					answer = @default;
				try
				{
					if (existsFunc(answer))
						result = answer;
					else
						Console.WriteLine("Path does not exists");
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			} while (result == null);
			return result;
		}

		public static int ReadInt(string question, int? @default, int minAllowed, int maxAllowed)
		{
			int result;
			do
			{
				Console.WriteLine(
					question +
					(@default.HasValue ? string.Format(" [{0}]", @default.Value) : string.Empty)
				);
				var answer = Console.ReadLine().Trim();
				if (@default != null && answer.IsEmpty())
					answer = @default.Value.ToString();
				if (int.TryParse(answer, out result))
				{
					if (result >= minAllowed && result <= maxAllowed)
						return result;
					else
						Console.WriteLine("Invalid value");
				}
			} while (true);
		}

		public static string ReadValidPathInLetteredDrive(string question, string @default)
		{
			string result = null;
			do
			{
				Console.WriteLine(
					question +
					(@default != null ? string.Format(" [{0}]", @default) : string.Empty)
				);
				var answer = Console.ReadLine().Trim();
				if (@default != null && answer.IsEmpty())
					answer = @default;
				if (PathEx.IsValidRootedPath(answer))
					result = answer;
				else
					Console.WriteLine("Path is not valid");
			} while (result == null);
			return result;
		}

		public static void WriteLines(IEnumerable<string> lines)
		{
			foreach (var line in lines)
				Console.WriteLine(line);
		}
	}
}
