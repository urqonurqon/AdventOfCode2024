using System;
using System.Diagnostics;
using System.Reflection;
using AdventOfCode;

namespace AdventOfCode2024 {
	public class Program {

		static string? _dayDataPath;

		static void Main(string[] args)
		{
			string? dataPath = "C:\\Users\\urqon\\source\\repos\\AdventOfCode2024\\";

			Console.WriteLine("Choose day: \n");
			string? day = Console.ReadLine();

			if (!int.TryParse(day, out int dayInNumbers))
			{
				Console.WriteLine("Wrong input. Type in the day number");
			}
			string methodName = "Day" + dayInNumbers;

			var methodToInvoke = typeof(Program).GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);

			if (methodToInvoke == null)
			{
				Console.WriteLine("Wrong Input But how did you get here i already check for that");
			}
			else
			{
				_dayDataPath = dataPath + methodName + "\\";
				methodToInvoke.Invoke(null, null);
			}

			Console.ReadKey();
		}

		static void Day1()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			Day1 day1;

			string? filePath = _dayDataPath + "Input.txt";

			if (filePath != null)
			{
				day1 = new Day1(filePath);

				day1.ParseFileIntoListsAndSort();

				Console.WriteLine("Sum of Sorted Array Differences is: " + day1.SumOfDifferences());

				Console.WriteLine("Simillarity Score is: " + day1.CalculateSimillarityScore());
			}
			sw.Stop();
			Console.WriteLine(sw.Elapsed.TotalSeconds);
		}

	}

}