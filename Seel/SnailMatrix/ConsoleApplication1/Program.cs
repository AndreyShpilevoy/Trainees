using System;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("This programm draws matrix filled with incrementing values in the shape of\n"
				+ "a counterclockwise spiral.\n\n"
				+ "Matrix of what size do we need?\n");

			int inputSize = 0;
			int startValue = 0;
			int usedValue = 0;
			int minValueCount = 0;

			while (inputSize == 0)
			{
				if (!Int32.TryParse(Console.ReadLine(), out inputSize) && inputSize <= 0)
				{
					Console.WriteLine("Sorry, this input is inappropriate, try any positive integer number\n");
				}
			}

			int[,] snail = new int[inputSize, inputSize];
			var maxValueCount = snail.GetLength(0) - 1;

			Console.WriteLine("What number will be initial for a value sequence we use to fill the matrix?\n");

			while (startValue == 0)
			{
				if (Int32.TryParse(Console.ReadLine(), out startValue) & startValue > 0)
				{
					usedValue = startValue;
				}
				else
				{
					Console.WriteLine("Sorry, this input is inappropriate, try any positive integer number\n");
				}
			}

			var counter = 0;

			while (usedValue < snail.Length + startValue)
			{
				var k = maxValueCount;
				var j = maxValueCount;

				if (counter < 4)
				{
					if (j == maxValueCount && k == maxValueCount)
					{
						for (j = maxValueCount; j != minValueCount; j--)
						{
							snail[j, k] = usedValue++;
						}
						counter++;
					}

					if (j == minValueCount && k == maxValueCount)
					{
						for (k = maxValueCount; k != minValueCount; k--)
						{
							snail[j, k] = usedValue++;
						}
						counter++;
					}

					if (j == minValueCount && k == minValueCount)
					{
						for (j = minValueCount; j != maxValueCount; j++)
						{
							snail[j, k] = usedValue++;
						}
						counter++;
					}

					if (j == maxValueCount && k == minValueCount)
					{
						for (k = minValueCount; k < maxValueCount; k++)
						{
							snail[j, k] = usedValue++;
						}
						counter++;
					}
				}
				else
				{
					counter = 0;
					maxValueCount--;
					minValueCount++;

					if (maxValueCount == minValueCount)
					{
						snail[maxValueCount, maxValueCount] = usedValue;
						break;
					}
				}
			}

			for (var l = 0; l < snail.GetLength(0); l++)
			{
				Console.Write(" \n");
				for (var m = 0; m < snail.GetLength(0); m++)
				{
					Console.Write(snail[l, m] + " ");
				}
			}
			Console.WriteLine();
		}


	}
}