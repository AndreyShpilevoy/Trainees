using System;

namespace FizzBuzz
{
	class FizzBuzz
	{
		static void Main()
		{
			for (var i = 1; i <= 100; i++)
			{
				Console.WriteLine(GetConditionResult(i));
			}
		}

		private static string GetConditionResult(int i)
		{
			string result;
			if (i % 3 == 0)
			{
				result = i % 15 == 0 ? "FizzBuzz" : "Fizz";
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
