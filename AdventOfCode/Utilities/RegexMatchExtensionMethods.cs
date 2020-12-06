using System.Text.RegularExpressions;

namespace AdventOfCode.Utilities
{
	public static class RegexMatchExtensionMethods
	{
		public static string CaptureString(this Match match, int num) => match.Groups[num].Captures[0].Value;
		public static int? CaptureInt(this Match match, int num) => match.Success ? int.Parse(match.CaptureString(num)) : (int?)null;
		public static char? CaptureChar(this Match match, int num) => match.Success ? char.Parse(match.CaptureString(num)) : (char?)null;
	}
}