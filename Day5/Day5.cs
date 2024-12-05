

using System.IO;

namespace AdventOfCode {
	public class Day5 {
		private string[] _lines;

		private List<string> _rules = new List<string>();
		private List<string> _updates = new List<string>();

		private List<List<int>> _incorrectPages = new List<List<int>>();


		private List<(int, int)> _rulePairs = new List<(int, int)>();

		private int _sumOfValidUpdatesMiddleNumber = 0;
		private int _sumOfInvalidUpdatesMiddleNumber = 0;

		public Day5(string path)
		{
			_lines = File.ReadAllLines(path);
			bool emptySpaceReached = false;
			for (int i = 0; i < _lines.Length; i++)
			{
				if (_lines[i].Length == 0)
				{
					emptySpaceReached = true;
					continue;
				}

				if (emptySpaceReached)
					_updates.Add(_lines[i]);
				else
					_rules.Add(_lines[i]);
			}

			SplitRulesIntoPairs();
		}

		private void SplitRulesIntoPairs()
		{
			for (int i = 0; i < _rules.Count; i++)
			{
				var splitRules = _rules[i].Split("|");

				_rulePairs.Add((int.Parse(splitRules[0]), int.Parse(splitRules[1])));
			}
		}

		public int GetValidPagesMiddleNumberSum()
		{
			List<List<int>> pageNumbersList = new List<List<int>>();
			for (int i = 0; i < _updates.Count; i++)
			{
				var pageNumbersAsString = _updates[i].Split(",");
				var pageNumbersAsStringList = pageNumbersAsString.ToList();
				pageNumbersList.Add(new List<int>());
				pageNumbersAsStringList.ForEach(n => pageNumbersList[i].Add(int.Parse(n)));

			}

			for (int i = 0; i < pageNumbersList.Count; i++)
			{
				pageNumbersList[i].Reverse();
				for (int j = 0; j < pageNumbersList[i].Count; j++)
				{
					var pageNumber = pageNumbersList[i][j];
					for (int k = 0; k < _rulePairs.Count; k++)
					{
						var firstPairNumber = _rulePairs[k].Item1;
						var secondPairNumber = _rulePairs[k].Item2;
						if (pageNumber == firstPairNumber)
						{
							for (int l = j + 1; l < pageNumbersList[i].Count; l++)
							{
								var sequentialPageNumber = pageNumbersList[i][l];

								if (sequentialPageNumber == secondPairNumber)
								{
									_incorrectPages.Add(pageNumbersList[i]);
									goto _INVALID;
								}
							}
						}
					}

				}
				var middlePageNumber = pageNumbersList[i][pageNumbersList[i].Count / 2];
				_sumOfValidUpdatesMiddleNumber += middlePageNumber;
			_INVALID:;
			}

			return _sumOfValidUpdatesMiddleNumber;
		}

		public int SumOfCorrectedPagesMiddleNumber()
		{
			bool f = false;
			for (int i = 0; i < _incorrectPages.Count; i++)
			{
			_SNAPOWGROUPPLAY:
				if (f) i--;
				f = false;

				for (int j = 0; j < _incorrectPages[i].Count; j++)
				{
					var currentPage = _incorrectPages[i][j];
					for (int k = 0; k < _rulePairs.Count; k++)
					{
						var firstPairNumber = _rulePairs[k].Item1;
						var secondPairNumber = _rulePairs[k].Item2;
						if (firstPairNumber == currentPage)
						{
							for (int l = j + 1; l < _incorrectPages[i].Count; l++)
							{
								var sequentialPageNumber = _incorrectPages[i][l];
								if (sequentialPageNumber == secondPairNumber)
								{
									int _ = _incorrectPages[i][j];
									_incorrectPages[i][j] = _incorrectPages[i][l];
									_incorrectPages[i][l] = _;
									goto _SNAPOWGROUPPLAY;
								}
							}
						}
					}
				}
				var middlePageNumber = _incorrectPages[i][_incorrectPages[i].Count / 2];
				_sumOfInvalidUpdatesMiddleNumber += middlePageNumber;


			}
			return _sumOfInvalidUpdatesMiddleNumber;
		}



	}
}