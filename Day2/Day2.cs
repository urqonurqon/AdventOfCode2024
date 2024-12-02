

namespace AdventOfCode {
	public class Day2 {
		private string[] _lines;

		private List<List<int>> _listOfSequences = new List<List<int>>();
		private List<List<int>> _listOfSequences2 = new List<List<int>>();

		private int _lastNumber;

		public int AmountOfSafeRows;

		public Day2(string path)
		{
			_lines = File.ReadAllLines(path);

			for (int i = 0; i < _lines.Length; i++)
			{
				_listOfSequences.Add(new List<int>());
				_listOfSequences2.Add(new List<int>());
				var numbersInLine = _lines[i].Split(" ");
				for (int j = 0; j < numbersInLine.Length; j++)
				{
					_listOfSequences2[i].Add(int.Parse(numbersInLine[j]));
				}
			}

				int x = 0;
			for (int i = 0; i < _lines.Length; i++)
			{
				//_listOfSequences.Add(new List<int>());
				//_listOfSequences2.Add(new List<int>());
				var numbersInLine = _lines[i].Split(" ");
				//for (int j = 0; j < numbersInLine.Length; j++)
				//{
				//	_listOfSequences2[i].Add(int.Parse(numbersInLine[j]));
				//}
				bool isIncreasing = false;
				List<int> numbers = new List<int>();
				for (int j = 0; j < numbersInLine.Length; j++)
				{

					var number = int.Parse(numbersInLine[j]);
					numbers.Add(number);
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
						_listOfSequences2[i].Clear();
						AmountOfSafeRows++;
					}
					_lastNumber = number;


				}
			}

			for (int i = 0; i < _listOfSequences2.Count; i++)
			{
				for (int j = 0; j < _listOfSequences2[i].Count; j++)
				{
					var numberRemoved = _listOfSequences2[i][j];
					_listOfSequences2[i].RemoveAt(j);
					bool isIncreasing = false;
					bool gothim = false;
					for (int k = 0; k < _listOfSequences2[i].Count; k++)
					{
						int number = _listOfSequences2[i][k];
						if (k == 0)
						{
							_lastNumber = number;
							continue;
						}
						var difference = number - _lastNumber;

						if (k == 1)
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
						if (k == _listOfSequences2[i].Count - 1)
						{
							gothim = true;
							AmountOfSafeRows++;
						}
						_lastNumber = number;
					}
					_listOfSequences2[i].Insert(j, numberRemoved);
					if (gothim) { break; }
				}
			}
		}



	}
}