using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCommon
{
	public static class StringExtensions
	{
		public static bool IsEmpty(this string me)
		{
			return me == string.Empty;
		}

		public static string TrimStart(this string me, string trimString, StringComparison comparisonType, int maxRepeats)
		{
			StringBuilder result = new StringBuilder(me);
			for (int i = 0; i < maxRepeats; i++)
				if (result.Length >= trimString.Length && result.ToString(0, trimString.Length).Equals(trimString, comparisonType))
					result.Remove(0, trimString.Length);
				else
					break;
			return result.ToString();
		}

		public static string TrimStart(this string me, string trimString, StringComparison comparisonType)
		{
			return TrimStart(me, trimString, comparisonType, int.MaxValue);
		}

		public static string TrimStart(this string me, string trimString)
		{
			return TrimStart(me, trimString, StringComparison.Ordinal, int.MaxValue);
		}
	}
}
