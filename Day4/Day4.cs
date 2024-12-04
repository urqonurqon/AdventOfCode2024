

using System.Numerics;

namespace AdventOfCode {
	public class Day4 {

		private string[] _lines;

		private List<List<int>> _allCharsAsInts = new List<List<int>>();

		private int[,] _kernel = new int[7, 7];
		private int[,] _result = new int[7, 7];

		private const string _wordToFind = "XMAS";

		public int Sum = 0;


		public Day4(string path)
		{
			for (int i = 0; i < _kernel.GetLength(0); i++)
			{
				for (int j = 0; j < _kernel.GetLength(1); j++)
				{
					_kernel[i, j] = -5;
					_result[i, j] = -25;
				}
			}

			_lines = File.ReadAllLines(path);

			for (int i = 0; i < _lines.Length; i++)
			{
				List<int> line = new List<int>();
				_allCharsAsInts.Add(line);
				for (int j = 0; j < _lines[i].Length; j++)
				{
					var c = _lines[i][j];
					line.Add(-10);
					for (int k = 0; k < _wordToFind.Length; k++)
					{
						if (_wordToFind[k] == c)
							line[j] = k;
					}
					//_allCharsAsInts[i].AddRange(line);
				}
			}

			var size = 2 * _wordToFind.Length - 1;
			var kernelSize = size - 1;


			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					for (int k = 0; k < _wordToFind.Length; k++)
					{
						if ((i == k || i == _wordToFind.Length - 1 || i == kernelSize - k) && (j == k || j == _wordToFind.Length - 1 || j == kernelSize - k))
						{
							_kernel[i, j] = _wordToFind.Length - 1 - k;
							break;
						}
					}

				}

			}

			_kernel[_wordToFind.Length - 1, _wordToFind.Length - 1] = 0;


		}

		public void SearchForWord()
		{

			var size = _wordToFind.Length;
			var kernelSize = size - 1;



			for (int i = 0; i < _allCharsAsInts.Count; i++)
			{
				for (int j = 0; j < _allCharsAsInts[i].Count; j++)
				{
					var originNumber = _allCharsAsInts[i][j];

					if (originNumber == 0)
					{
						for (int k = 0; k < _kernel.GetLength(0); k++)
						{
							for (int l = 0; l < _kernel.GetLength(1); l++)
							{
								_result[k, l] = -25;
							}
						}

						for (int k = -kernelSize; k <= kernelSize; k++)
						{
							for (int l = -kernelSize; l <= kernelSize; l++)
							{
								if (i + k < 0 || i + k > _allCharsAsInts.Count - 1 || j + l < 0 || j + l > _allCharsAsInts[i].Count - 1) continue;
								int kernelIndexK = k + kernelSize;
								int kernelIndexL = l + kernelSize;
								var number = _allCharsAsInts[i + k][j + l];
								var kernelNumber = _kernel[kernelIndexK, kernelIndexL];

								_result[kernelIndexK, kernelIndexL] = number - kernelNumber;


							}

						}

						bool[] failed = new bool[_kernel.GetLength(0)+1];
						for (int k = 1; k < size; k++)
						{
							if (!failed[0] && _result[kernelSize - k, kernelSize] == 0)
							{
								if (k == size - 1)
									Sum++;
							}
							else
							{
								failed[0] = true;
							}

							if (!failed[1] && _result[kernelSize, kernelSize - k] == 0)
							{
								if (k == size - 1)
									Sum++;
							}
							else
							{
								failed[1] = true;
							}

							if (!failed[2] && _result[kernelSize - k, kernelSize - k] == 0)
							{
								if (k == size - 1)
									Sum++;
							}
							else
							{
								failed[2] = true;
							}

							if (!failed[3] && _result[kernelSize + k, kernelSize] == 0)
							{
								if (k == size - 1)
									Sum++;
							}
							else
							{
								failed[3] = true;
							}

							if (!failed[4] && _result[kernelSize, kernelSize + k] == 0)
							{
								if (k == size - 1)
									Sum++;
							}
							else
							{
								failed[4] = true;
							}

							if (!failed[5] && _result[kernelSize + k, kernelSize + k] == 0)
							{
								if (k == size - 1)
									Sum++;
							}
							else
							{
								failed[5] = true;
							}

							if (!failed[6] && _result[kernelSize + k, kernelSize - k] == 0)
							{
								if (k == size - 1)
									Sum++;
							}
							else
							{
								failed[6] = true;
							}

							if (!failed[7] && _result[kernelSize - k, kernelSize + k] == 0)
							{
								if (k == size - 1)
									Sum++;
							}
							else
							{
								failed[7] = true;
							}
						}





					}
				}
			}
		}



	}
}