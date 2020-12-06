using AdventOfCode.ProblemSolvers.Abstractions;
using AdventOfCode.Utilities;
using System.Linq;

namespace AdventOfCode.ProblemSolvers
{
	public class Problem5Solver : IProblemSolver
	{
		public string Solve()
		{
			var terrainPoints = ResourceUtilities.ReadResource("Day3.Input.txt").Split("\r\n").Select(x => x.ToCharArray()).ToList();
			return terrainPoints.Skip(1).Select((mapRow, row) => mapRow[CalculatePosition(mapRow, row)]).Count(PointIsTree).ToString();
		}

		private int CalculatePosition(char[] mapRow, int row) => (row + 1) * 3 % mapRow.Length;
		private bool PointIsTree(char mapPoint) => mapPoint == '#';
	}
}
