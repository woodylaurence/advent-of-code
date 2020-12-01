using AdventOfCode.ProblemSolvers.Abstractions;
using AdventOfCode.Utilities;
using System.Linq;

namespace AdventOfCode.ProblemSolvers
{
	public class Problem2Solver : IProblemSolver
	{
		public string Solve()
		{
			var numbers = ResourceUtilities.ReadResource("Problem2.Input.txt").Split("\r\n").Select(int.Parse).ToList();
			var (num1, num2, num3) = numbers.SelectMany((x, index1) => numbers.Skip(index1 + 1)
																			  .SelectMany((y, index2) => numbers.Skip(index1 + index2 + 2)
																												.Select(z => (Num1: x, Num2: y, Num3: z))))
											.Single(x => x.Num1 + x.Num2 + x.Num3 == 2020);

			return $"{num1 * num2 * num3}";
		}
	}
}
