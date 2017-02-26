using System;

namespace ChangeMatrix
{
    class Matrix
    {
        private int[,] privateMatrix;

        public Matrix()
        {
            privateMatrix = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    privateMatrix[j, i] = 0;
                }
            }
        }

        //Method changeSecondColumn
        public void ChangeSecondColumn(int value)
        {
            for (int i = 0; i < 4; i++)
            {
                privateMatrix[1, i] = value;
            }
        }

        //Method RotateMatrix
        public void RotateMatrix()
        {
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    int rotate = privateMatrix[i, j];
                    privateMatrix[j, 3-i] = privateMatrix[i, j];
                }
            }

        }
        //Display matrix
        public void DisplayMatrix()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(privateMatrix[j, i]+" ");                
                }
                Console.WriteLine();
            }
        }
    }

    //for user
    class User
    {
        static void Main()
        {
            //create matrix
            Matrix newMatrix = new Matrix();

            //display default matrix
            newMatrix.DisplayMatrix();

            //Request
            int number;
            Console.WriteLine("\nEnter the number by which to replace the second column of the matrix\n" + "Number: ");
            string value = Console.ReadLine();
            number = Convert.ToInt16(value);

            //Change column
            newMatrix.ChangeSecondColumn(number);

            //Display matrix after change column
            newMatrix.DisplayMatrix();

            //Rotate matrix
            Console.WriteLine("\nRotate matrix? yes/no");
            string answer = Console.ReadLine().ToLower();
            switch (answer)
            {
                case "yes":
                    {
                        newMatrix.RotateMatrix();
                        newMatrix.DisplayMatrix();
                        break;
                    }

                case "no":
                    {
                        Console.WriteLine("\nPress any key fo restart program");
                        string anykey = Console.ReadLine();
                        break;
                    }
            }
        }
    }
}
