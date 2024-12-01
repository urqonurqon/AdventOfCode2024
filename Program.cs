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

			Console.WriteLine("Choose day or create a new one: \n");
			string? day = Console.ReadLine();


			if (!int.TryParse(day, out int dayInNumbers))
			{
				Console.WriteLine("Wrong input. Type in the day number");
			}
			string methodName = "Day" + dayInNumbers;

			var methodToInvoke = typeof(Program).GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic);

			if (methodToInvoke == null)
			{
				if (!Directory.Exists(methodName))
				{
					Directory.CreateDirectory(dataPath + methodName);
					var fileStream = File.Create(dataPath + methodName + "\\" + methodName + ".cs");
					fileStream.Close();
					File.WriteAllText(dataPath + methodName + "\\" + methodName + ".cs", "\r\n\r\nnamespace AdventOfCode " +
						"{\r\n\tpublic class " + methodName + " {\r\n\r\n\r\n\r\n\t\tpublic " + methodName + "()\r\n\t\t" +
						"{\r\n\t\r\n\t\t}\r\n\r\n\t\r\n\r\n\t}" +
						"\r\n}");

					var programCode = File.ReadAllText(dataPath + "Program.cs");
					programCode = programCode.Remove(programCode.LastIndexOf("}"));
					programCode = programCode.Remove(programCode.LastIndexOf("}"));

					programCode += "\n\t\tstatic void " + methodName + "()\r\n\t\t{\r\n\r\n\t\t}\r\n\t}\r\n}";

					File.WriteAllText(dataPath + "Program.cs", programCode);
				}
			}
			else
			{
				_dayDataPath = dataPath + methodName + "\\";
				Stopwatch sw = new Stopwatch();
				sw.Start();
				methodToInvoke.Invoke(null, null);
				sw.Stop();
				Console.WriteLine("Runtime: " + sw.Elapsed.TotalSeconds + "s.\n");
			}

			Console.WriteLine("Press any key..");
			Console.ReadKey();
		}

		static void Day1()
		{
			Day1 day1;

			string? filePath = _dayDataPath + "Input.txt";

			if (filePath != null)
			{
				day1 = new Day1(filePath);

				day1.ParseFileIntoListsAndSort();

				Console.WriteLine("Sum of Sorted Array Differences is: " + day1.SumOfDifferences());

				Console.WriteLine("Simillarity Score is: " + day1.CalculateSimillarityScore());
			}
		}

		static void Day2()
		{

		}

		static void Day3()
		{

		}
	}
}