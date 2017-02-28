using System;

namespace FizzBuzz
{
    class FizzBuzz
    {
        static void Main()
        {
            int minNumber;
            int maxNumber;
            string answer = string.Empty;

            while (answer != "exit")
            {
                Console.WriteLine("Input start number:");
                if (Int32.TryParse(Console.ReadLine(), out minNumber))
                {
                    Console.WriteLine("Input finish number:");
                    if (Int32.TryParse(Console.ReadLine(), out maxNumber))
                    {
                        for (int i = minNumber; i <= maxNumber && maxNumber!=minNumber; i++)
                        {
                            if (i % 3 == 0 && i % 5 == 0)
                            {
                                Console.WriteLine("FizzBuzz");
                            }

                            if (i % 3 == 0 && i % 5 != 0)
                            {
                                Console.WriteLine("Fizz");
                            }

                            if (i % 3 != 0 && i % 5 == 0)
                            {
                                Console.WriteLine("Buzz");
                            }

                            if (i % 3 != 0 && i % 5 != 0)
                            {
                                Console.WriteLine(i);
                            }
                        }
                    }

                    if (maxNumber == minNumber | maxNumber<minNumber)
                    {
                        Console.WriteLine("Error! Start number can`t be equal or more than finish number.");
                    }
                }

                Console.WriteLine("\n" + @"To exit programm enter ""exit"" or press any key to continue.");
                answer = Console.ReadLine();
            }
        }
    }     
}
