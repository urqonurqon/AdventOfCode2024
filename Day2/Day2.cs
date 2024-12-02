

namespace AdventOfCode {
	public class Day2 {
		private string[] _lines;

		private List<List<int>> _listOfSequences = new List<List<int>>();

		private int _lastNumber;

		public int AmountOfSafeRows;

		public Day2(string path)
		{
			_lines = File.ReadAllLines(path);

			for (int i = 0; i < _lines.Length; i++)
			{
				_listOfSequences.Add(new List<int>());
				var numbersInLine = _lines[i].Split(" ");
				bool isIncreasing = false;
				for (int j = 0; j < numbersInLine.Length; j++)
				{

					var number = int.Parse(numbersInLine[j]);
					if (j == 0)
					{
						_lastNumber = number;
						continue;
					}
					var difference = number - _lastNumber;

					if (j == 1)
					{
						isIncreasing = difference > 0;
					}



					if (isIncreasing)
					{
						if (difference < 0)
							break;
					}
					else
					{
						if (difference > 0)
							break;
					}
					difference = Math.Abs(difference);

					if (difference < 1 || difference > 3)
					{
						_lastNumber = number;
						break;
					}
					if (j == numbersInLine.Length - 1)
					{
						AmountOfSafeRows++;
					}
					_lastNumber = number;


				}
			}
		}



	}
}