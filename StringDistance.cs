using F23.StringSimilarity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCommon
{
    public class StringDistance
    {
		public static double GetDistance(string s1, string s2)
		{
			var algorithm = new JaroWinkler();
			return algorithm.Distance(s1, s2);
		}
    }
}
