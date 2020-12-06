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
						 .Select(x => (LowerLimit: int.Parse(x.Groups[1].Captures[0].Value), UpperLimit: int.Parse(x.Groups[2].Captures[0].Value), Letter: x.Groups[3].Captures[0].Value, Input: x.Groups[4].Captures[0].Value))
						 .Count(x => x.Input.Count(y => y.ToString() == x.Letter) >= x.LowerLimit && x.Input.Count(y => y.ToString() == x.Letter) <= x.UpperLimit)
						 .ToString();
		}
	}
}
