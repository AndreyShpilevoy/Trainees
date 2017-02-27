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
            int matrixSize;
            int startValue = 0;
            int usedValue = 0;
            int maxValue;
            int minValue = 0;


            while (inputSize==0)
            {

                if (Int32.TryParse(Console.ReadLine(), out inputSize) & inputSize > 0)
                {
                    matrixSize = inputSize;
                }
                else
                {
                    Console.WriteLine("Sorry, this input is inappropriate, try any positive integer number\n");
                }
            }
            int[,] snail = new int[inputSize, inputSize];
            maxValue = snail.GetLength(0) - 1;

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
            int j;
            int k;
            int counter = 0;
            while (usedValue < snail.Length + startValue)
            {
                j = k = maxValue;
                if (counter < 4)
                {
                    if (j == maxValue && k == maxValue)
                    {
                        for (j = maxValue; j != minValue; j--)
                        {
                            snail[j, k] = usedValue++;
                        }
                        counter++;
                    }
                    if (j == minValue && k == maxValue)
                    {
                        for (k = maxValue; k != minValue; k--)
                        {
                            snail[j, k] = usedValue++;
                        }
                        counter++;
                    }
                    if (j == minValue && k == minValue)
                    {
                        for (j = minValue; j != maxValue; j++)
                        {
                            snail[j, k] = usedValue++;
                        }
                        counter++;
                    }
                    if (j == maxValue && k == minValue)
                    {
                        for (k = minValue; k < maxValue; k++)
                        {
                            snail[j, k] = usedValue++;
                        }
                        counter++;
                    }
                }
                else
                {
                    counter = 0;
                    maxValue--;
                    minValue++;
                    if (maxValue == minValue)
                    {
                       snail[maxValue, maxValue] = usedValue;
                        break; 
                    }
                }
            }

            for (var l = 0; l < snail.GetLength(0); l++)
            {
                Console.Write(" \n");
                for (var m = 0; m < snail.GetLength(0); m++)
                    {
                    Console.Write(snail[l, m]+" ");
                    }
            }
            Console.WriteLine();
        }


    }
}