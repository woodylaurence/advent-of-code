using AdventOfCode.ProblemSolvers;
using System;
using System.Diagnostics;

namespace AdventOfCode
{
	class Program
	{
		static void Main(string[] args)
		{
			var problemSolver = new Problem8Solver();
			var stopwatch = Stopwatch.StartNew();
			var solution = problemSolver.Solve();
			stopwatch.Stop();

			Console.WriteLine($"Solution: {solution} (Took {GetFormattedTime(stopwatch)})");
			Console.ReadLine();
		}

		private static string GetFormattedTime(Stopwatch stopwatch)
		{
			var elapsedTicks = stopwatch.ElapsedTicks;
			if (elapsedTicks < 10) return $"{elapsedTicks}ns";
			if (elapsedTicks < 10000) return $"{elapsedTicks / 10.0:F1}µs";
			if (elapsedTicks < 10000000) return $"{elapsedTicks / 10000.0:F1}ms";
			return $"{elapsedTicks / 10000000.0:F1}s";
		}
	}
}
