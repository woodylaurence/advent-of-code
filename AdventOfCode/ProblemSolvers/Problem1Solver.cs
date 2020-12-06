using AdventOfCode.ProblemSolvers.Abstractions;
using AdventOfCode.Utilities;
using System.Linq;

namespace AdventOfCode.ProblemSolvers
{
	public class Problem1Solver : IProblemSolver
	{
		public string Solve()
		{
			var numbers = ResourceUtilities.ReadResource("Day1.Input.txt").Split("\r\n").Select(int.Parse).ToList();
			var (num1, num2) = numbers.SelectMany((x, index) => numbers.Skip(index + 1)
																	   .Select(y => (Num1: x, Num2: y)))
									  .Single(x => x.Num1 + x.Num2 == 2020);
			return $"{num1 * num2}";
		}

	}
}