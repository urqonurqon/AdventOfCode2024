using System;

namespace AdventOfCode {
	public class Program {

		static void Main(string[] args)
		{
			Console.WriteLine("Please input file path\n");
			string? filePath = "C:\\Users\\urqon\\source\\repos\\AdventOfCode2024\\" + Console.ReadLine();

			while (filePath == "")
			{
				Console.WriteLine("at least type smthing bruv");
				filePath = Console.ReadLine();
			}

			Day1 day1;
			if (filePath != null)
			{
				day1 = new Day1(filePath);

				day1.ParseFileIntoListsAndSort();

				Console.WriteLine("Sum of Sorted Array Differences is: " + day1.SumOfDifferences());
			}

		}

	}

}