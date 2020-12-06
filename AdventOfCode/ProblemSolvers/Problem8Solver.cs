using AdventOfCode.ProblemSolvers.Abstractions;
using AdventOfCode.Utilities;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.ProblemSolvers
{
	public class Problem8Solver : IProblemSolver
	{
		public string Solve()
		{
			var passportEntries = ResourceUtilities.ReadResource("Day4.Input.txt").Split("\r\n\r\n").Select(x => x.Replace("\r\n", " ")).ToList();
			var passportParsingRegex = new Regex("(?=.*byr:([^ ]*))(?=.*iyr:([^ ]*))(?=.*eyr:([^ ]*))(?=.*hgt:([^ ]*))(?=.*hcl:([^ ]*))(?=.*ecl:([^ ]*))(?=.*pid:([^ ]*))");
			return passportEntries.Select(x => passportParsingRegex.Match(x))
								  .Where(x => x.Success)
								  .Select(x => (BYR: x.CaptureInt(1), IYR: x.CaptureInt(2), EYR: x.CaptureInt(3), HGT: x.CaptureString(4), HCL: x.CaptureString(5), ECL: x.CaptureString(6), PID: x.CaptureString(7)))
								  .Where(x => x.BYR >= 1920 && x.BYR <= 2002)
								  .Where(x => x.IYR >= 2010 && x.IYR <= 2020)
								  .Where(x => x.EYR >= 2020 && x.EYR <= 2030)
								  .Where(x => new Regex("^([0-9]+)cm$").Match(x.HGT).CaptureInt(1) >= 150 &&
											  new Regex("^([0-9]+)cm$").Match(x.HGT).CaptureInt(1) <= 193 ||
											  new Regex("^([0-9]+)in$").Match(x.HGT).CaptureInt(1) >= 59 &&
											  new Regex("^([0-9]+)in$").Match(x.HGT).CaptureInt(1) <= 76)
								  .Where(x => new Regex("^#[0-9a-f]{6}$").IsMatch(x.HCL))
								  .Where(x => new Regex("^amb|blu|brn|gry|grn|hzl|oth$").IsMatch(x.ECL))
								  .Where(x => new Regex("^\\d{9}$").IsMatch(x.PID))
								  .Count()
								  .ToString();
		}
	}
}
