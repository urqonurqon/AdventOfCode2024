using System;

namespace AdventOfCode {
	public class Day1 {

		private string[] _lines;

		private List<List<int>> _listOfNumberColumns = new List<List<int>>();
		private List<Tuple<int, int>> _sortedListOfPairs = new List<Tuple<int, int>>();

		private const int _numberOfCollumns = 2;
		public Day1(string path)
		{
			_lines = File.ReadAllLines(path);
			for (int i = 0; i < _numberOfCollumns; i++)
			{
				_listOfNumberColumns.Add(new List<int>());
			}
		}

		public void ParseFileIntoListsAndSort()
		{
			for (int i = 0; i < _lines.Length; i++)
			{
				var line = _lines[i];
				line = line.Trim();

				var splitLine = line.Split(' ').ToList();

				int k = 0;
				for (int j = 0; j < splitLine.Count; j++)
				{
					if (splitLine[j] == "" || splitLine[j] == " ")
					{
						continue;
					}

					if (int.TryParse(splitLine[j], out int number))
					{

						_listOfNumberColumns[k].Add(number);
						k++;
					}
				}


			}

			for (int i = 0; i < _listOfNumberColumns.Count; i++)
			{
				_listOfNumberColumns[i].Sort();
			}

			for (int i = 0; i < _listOfNumberColumns[0].Count; i++)
			{
				_sortedListOfPairs.Add(new Tuple<int, int>(_listOfNumberColumns[0][i], _listOfNumberColumns[1][i]));
			}

		}

		public int SumOfDifferences()
		{
			int sum = 0;

			for (int i = 0; i < _sortedListOfPairs.Count; i++)
			{
				var difference = Math.Abs(_sortedListOfPairs[i].Item1 - _sortedListOfPairs[i].Item2);
				sum += difference;
			}
			return sum;
		}


		public int CalculateSimillarityScore()
		{
			int simScore = 0;

			for (int i = 0; i < _listOfNumberColumns[0].Count; i++)
			{
				for (int j = 0; j < _listOfNumberColumns[1].Count; j++)
				{
					if (_listOfNumberColumns[0][i] == _listOfNumberColumns[1][j])
						simScore += _listOfNumberColumns[1][j];
					if (_listOfNumberColumns[1][j] > _listOfNumberColumns[0][i])
						break;
				}
			}

			return simScore;
		}

	}
}