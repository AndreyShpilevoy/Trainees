using System;

namespace StrinAsCharArray_Seel
{
    class strings_as_char_array
    {
        static void Main()
        {
            //counter of simbols included in both strings
            int symbols_icluded = 0;
            Console.WriteLine("Application compares two words to find out if they contain the same letters.\n\nPlease input the first word...");
            //read first string and converto to array of chars
            char[] first_string = Console.ReadLine().ToLower().ToCharArray();
            Console.WriteLine("\nPlease input the second word...");
            //read second string
            string second_string = Console.ReadLine().ToLower();

            //compair each char of first string to second string and count times chars are included in both
            foreach (char character in first_string)
            {
                if (second_string.IndexOf(character)!=-1) 
                    ++symbols_icluded;
            }

            //check if numbers of included chars equals string length
            if (symbols_icluded == first_string.Length & symbols_icluded == second_string.Length)
                Console.WriteLine("\nResult: Yes, you can write down second word with the symbols of the first word");
            else Console.WriteLine("\nResult: No, you can't write down second word with the symbols of the first word");
        }
    }
}
