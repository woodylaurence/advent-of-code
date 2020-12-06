using AdventOfCode.ProblemSolvers.Abstractions;
using AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.ProblemSolvers
{
	public class Problem6Solver : IProblemSolver
	{
		public string Solve()
		{
			var terrainPoints = ResourceUtilities.ReadResource("Day3.Input.txt").Split("\r\n").Select(x => x.ToCharArray()).ToList();

			return new List<Func<char[], int, int?>> { CalculatePositionRight1Down1, CalculatePositionRight3Down1, CalculatePositionRight5Down1, CalculatePositionRight7Down1, CalculatePositionRight1Down2 }
						.Select(func => terrainPoints.Skip(1)
													 .Select((mapRow, row) => ReadMapSymbolAtPosition(mapRow, func(mapRow, row)))
													 .Count(PointIsTree))
						.Aggregate(1, (product, numTrees) => product * numTrees)
						.ToString();
		}

		private static int? CalculatePositionRight1Down1(char[] mapRow, int row) => (row + 1) % mapRow.Length;
		private static int? CalculatePositionRight3Down1(char[] mapRow, int row) => (row + 1) * 3 % mapRow.Length;
		private static int? CalculatePositionRight5Down1(char[] mapRow, int row) => (row + 1) * 5 % mapRow.Length;
		private static int? CalculatePositionRight7Down1(char[] mapRow, int row) => (row + 1) * 7 % mapRow.Length;
		private static int? CalculatePositionRight1Down2(char[] mapRow, int row) => (row + 1) % 2 != 0 ? (int?)null : (row + 1) / 2 % mapRow.Length;
		private static char? ReadMapSymbolAtPosition(char[] mapRow, int? position) => position == null ? (char?)null : mapRow[position.Value];
		private static bool PointIsTree(char? mapPoint) => mapPoint == '#';
	}
}
