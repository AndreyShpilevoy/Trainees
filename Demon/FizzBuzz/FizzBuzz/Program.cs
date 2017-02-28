using System;

namespace FizzBuzz
{
	class FizzBuzz
	{
		static void Main()
		{
			var answer = string.Empty;

			while (answer != "N")
			{
				Console.WriteLine("Input start number:");
				int minNumber;
				var minNumberValid = Int32.TryParse(Console.ReadLine(), out minNumber);

				Console.WriteLine("Input finish number:");
				int maxNumber;
				var maxNumberValid = Int32.TryParse(Console.ReadLine(), out maxNumber);

				if (Validate(minNumberValid, maxNumberValid, minNumber, maxNumber))
				{
					if (minNumber > maxNumber)
					{
						Swap(ref minNumber, ref maxNumber);
					}

					for (var i = minNumber; i <= maxNumber; i++)
					{
						Console.WriteLine(GetConditionResult(i));
					}
				}
				else
				{
					Console.WriteLine("Error! Entered value is wrong.");
				}

				Console.WriteLine("\nDo you want to continue work with app. Y/N.");
				answer = Console.ReadLine().ToUpperInvariant();
			}
		}

		private static bool Validate(bool minNumberValid, bool maxNumberValid, int minNumber, int maxNumber)
		{
			return minNumberValid && maxNumberValid && maxNumber != minNumber;
		}

		private static void Swap(ref int min, ref int max)
		{
			min = min + max;
			max = min - max;
			min = min - max;
		}

		private static string GetConditionResult(int i)
		{
			string result;
			if (i % 15 == 0)
			{
				result = "FizzBuzz";
			}
			else if (i % 3 == 0)
			{
				result = "Fizz";
			}
			else if (i % 5 == 0)
			{
				result = "Buzz";
			}
			else
			{
				result = i.ToString();
			}
			return result;
		}
	}
}
