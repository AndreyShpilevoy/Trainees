using System;
using System.Globalization;

namespace StringAsCharArray
{
    class Symbols
    {
        static void Main()
        {
            string firstword, secondword;                                //initialising first and second word

            Console.WriteLine("Enter the first word:");
            firstword = Console.ReadLine();                              //entering the first word
            Console.WriteLine("Enter the second word:");
            secondword = Console.ReadLine();                             //entering the first word

            //first word array
            char[] firstwordarray;
            firstwordarray = firstword.ToCharArray(0, firstword.Length);

            //second word array
            char[] secondwordarray;
            secondwordarray = secondword.ToCharArray(0, secondword.Length);

            int i, result;
            for (i = 0; i < secondwordarray.Length; i++)
            {
                char searchitem = secondwordarray[i];
                result = Array.IndexOf(firstwordarray, searchitem);            //searching symbols in first word

                if (i == firstword.Length - 1 & result > 0)
                {
                    Console.WriteLine("We can create word: {0}", firstword);
                    break;
                }

                else if (result < 0)                                           
                {
                    Console.WriteLine("symbol {0} not found. we can`t create word: {1}", searchitem, firstword);
                    break;
                }

                if (i >= secondword.Length && secondword.Length >= firstword.Length)
                {
                    Console.WriteLine("We can create word: {0}", firstword);
                }

                else if (i < secondword.Length && secondword.Length < firstword.Length)
                {
                    Console.WriteLine("We can`t create word: {0}", firstword);
                    break;
                }
            }
        }
    }
}