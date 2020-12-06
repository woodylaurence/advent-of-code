using AdventOfCode.ProblemSolvers.Abstractions;
using AdventOfCode.Utilities;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.ProblemSolvers
{
	public class Problem4Solver : IProblemSolver
	{
		public string Solve()
		{
			var inputs = ResourceUtilities.ReadResource("Day2.Input.txt").Split("\r\n").ToList();
			var inputParsingRegex = new Regex("(\\d+)-(\\d+) ([a-z]): ([a-z]+)");
			return inputs.Select(x => inputParsingRegex.Match(x))
						 .Select(x => (FirstIndex: int.Parse(x.Groups[1].Captures[0].Value), SecondIndex: int.Parse(x.Groups[2].Captures[0].Value), Letter: x.Groups[3].Captures[0].Value, Input: x.Groups[4].Captures[0].Value))
						 .Count(x => new Regex($"^.{{{x.FirstIndex - 1}}}{x.Letter}").IsMatch(x.Input) && new Regex($"^.{{{x.SecondIndex - 1}}}{x.Letter}").IsMatch(x.Input) == false ||
									 new Regex($"^.{{{x.FirstIndex - 1}}}{x.Letter}").IsMatch(x.Input) == false && new Regex($"^.{{{x.SecondIndex - 1}}}{x.Letter}").IsMatch(x.Input))
						 .ToString();
		}
	}
}
