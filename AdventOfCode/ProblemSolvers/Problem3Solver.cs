using AdventOfCode.ProblemSolvers.Abstractions;
using AdventOfCode.Utilities;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.ProblemSolvers
{
	public class Problem3Solver : IProblemSolver
	{
		public string Solve()
		{
			var inputs = ResourceUtilities.ReadResource("Day2.Input.txt").Split("\r\n").ToList();
			var inputParsingRegex = new Regex("(\\d+)-(\\d+) ([a-z]): ([a-z]+)");
			return inputs.Select(x => inputParsingRegex.Match(x))
						 .Select(x => (LowerLimit: x.CaptureInt(1), UpperLimit: x.CaptureInt(2), Letter: x.CaptureChar(3), Input: x.CaptureString(4)))
						 .Count(x => x.Input.Count(y => y == x.Letter) >= x.LowerLimit && x.Input.Count(y => y == x.Letter) <= x.UpperLimit)
						 .ToString();
		}
	}
}
