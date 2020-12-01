using System.IO;
using System.Reflection;

namespace AdventOfCode.Utilities
{
	public static class ResourceUtilities
	{
		public static string ReadResource(string resourceName)
		{
			using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"AdventOfCode.ProblemResources.{resourceName}");
			using var reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}
	}
}
