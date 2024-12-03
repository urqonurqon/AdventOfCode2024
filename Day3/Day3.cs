

using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode {
	public class Day3 {

		private string _fileText;
		public int SumOfMultiplication = 0;

		private const string _regex = "mul\\((\\d+),(\\d+)\\)|don't\\(\\)|do\\(\\)";

		public Day3(string path)
		{
			SumOfMultiplication = 0;
			_fileText = File.ReadAllText(path);
			Regex regex = new Regex(_regex);
			var regexResult = regex.Matches(_fileText);
			bool shouldMultiply = true;
			for (int i = 0; i < regexResult.Count; i++)
			{
				if (regexResult[i].Value == "don't()")
				{
					shouldMultiply = false;
					continue;
				}
				if (regexResult[i].Value == "do()")
				{
					shouldMultiply = true;
					continue;
				}


				if (shouldMultiply)
				{

					int firstNumber = int.Parse(regexResult[i].Groups[1].Value);
					int secondNumber = int.Parse(regexResult[i].Groups[2].Value);


					SumOfMultiplication += firstNumber * secondNumber;
				}

			}





		}

	}
}