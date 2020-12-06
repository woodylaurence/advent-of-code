using AdventOfCode.ProblemSolvers.Abstractions;
using AdventOfCode.Utilities;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.ProblemSolvers
{
	public class Problem7Solver : IProblemSolver
	{
		public string Solve()
		{
			var passportEntries = ResourceUtilities.ReadResource("Day4.Input.txt").Split("\r\n\r\n").Select(x => x.Replace("\r\n", " ")).ToList();
			var passportRegex = new Regex("(?=.*byr)(?=.*iyr)(?=.*eyr)(?=.*hgt)(?=.*hcl)(?=.*ecl)(?=.*pid)");
			return passportEntries.Count(x => passportRegex.IsMatch(x)).ToString();
		}
	}
}
