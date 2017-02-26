using System;

namespace changeMatrix
{

    class Matrix
    {
        private int[,] priv_matrix;

        public Matrix(int size)
        {
            priv_matrix = new int[size, size];
            for (int i = 0; i < priv_matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < priv_matrix.GetLength(1); ++j)
                {
                    priv_matrix[i, j] = 0;
                }
            };
        }
        public Matrix()
        {
            priv_matrix = new int[4, 4];
            for (int i = 0; i < priv_matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < priv_matrix.GetLength(1); ++j)
                {
                    priv_matrix[i, j] = 0;
                }
            };
        }

        //Method that changes values in every index of second column with value entered as a parameter
        public void ChangeColumn(int value)
        {
            for (int i = 0; i < priv_matrix.GetLength(1); i++)
            {
                priv_matrix[i, 1] = value;
            };
        }

        //Method overloading, customisable column number
        public void ChangeColumn(int value, int column_number)
        {
            for (int i = 0; i < priv_matrix.GetLength(1); i++)
            {
                priv_matrix[i, column_number - 1] = value;
            };
        }

        //Method that swaps values of columns and rows of matrix
        public void Rotate()
        {
            for (int i = 1; i < priv_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int temp = priv_matrix[i, j];
                    priv_matrix[i, j] = priv_matrix[j, i];
                    priv_matrix[j, i] = temp;
                }
            };
        }

        //Method to display matrix content
        public void DisplayMatrix()
        {
            for (int i = 0; i < priv_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < priv_matrix.GetLength(1); j++)
                {
                    Console.Write(priv_matrix[i, j] + " ");
                }
                Console.WriteLine();
            };
            Console.WriteLine();
        }

    }

    class UserControl
    {
        public UserControl()
        {
            Console.WriteLine("Hi! This program can do some cool stuff with a square matrix of integers.\n\n" +
                "To create new square matrix of custom size enter: 'New'\n" +
                "To change any column of that matrix to specific value enter: 'Change column'\n" +
                "To swap columns and rows of the matrix enter: 'Swap'\n" +
                "To finish fun enter: 'End'\n"+
                "To see list of commands again enter: 'Help'\n");
            string command = "";
            var newMatrix = new Matrix();


            while (command != "end")
            {
                switch (command)
                {

                    case "new":
                        {
                            Console.WriteLine("Cool! What size of the matrix do we need?");
                            int matrixSize = Int32.Parse(Console.ReadLine());
                            newMatrix = new Matrix(matrixSize);
                            newMatrix.DisplayMatrix();
                            command = null;
                            break;
                        }
                    case "change column":
                        {
                            Console.WriteLine("What column do you want to change?");
                            int columnNumber = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("What new value we want in "+columnNumber+" column after change?");
                            int valueNew = Int32.Parse(Console.ReadLine());
                            newMatrix.ChangeColumn(valueNew, columnNumber);
                            newMatrix.DisplayMatrix();
                            command = null;
                            break;
                        }
                    case "swap":
                        {
                            newMatrix.Rotate();
                            newMatrix.DisplayMatrix();
                            command = null;
                            break;
                        }
                    case "help":
                        {
                            Console.WriteLine("To create new square matrix of custom size enter: 'New'\n" +
                                            "To change any column of that matrix to specific value enter: 'Change column'\n" +
                                            "To swap columns and rows of the matrix enter: 'Swap'\n" +
                                            "To finish fun enter: 'End'\n" +
                                            "To see list of commands again enter: 'Help'\n");
                            command = null;
                            break;
                        }
                    default:
                        {
                            command = Console.ReadLine().ToLower();
                            break;
                        }
                }
            }

        }

        class Program
        {
            static void Main()
            {
                new UserControl();
                /*
                            var newMatrix = new Matrix(4);
                            newMatrix.DisplayMatrix();
                            newMatrix.ChangeColumn(3);
                            newMatrix.DisplayMatrix();
                            newMatrix.ChangeColumn(5,3);
                            newMatrix.DisplayMatrix();
                            newMatrix.Rotate();
                            newMatrix.DisplayMatrix();
                            newMatrix.ChangeColumn(1, 4);
                            newMatrix.DisplayMatrix();
                            newMatrix.UserControl();

                /*

                /*          Example working with square matrix of custom size (7)

                            var newMatrix = new Matrix(7);
                            newMatrix.DisplayMatrix();
                            newMatrix.ChangeColumn(3);
                            newMatrix.DisplayMatrix();
                            newMatrix.ChangeColumn(4,5);
                            newMatrix.DisplayMatrix();
                            newMatrix.Rotate();
                            newMatrix.DisplayMatrix();
                            newMatrix.ChangeColumn(5, 3);
                            newMatrix.DisplayMatrix();

                */
            }
        }
    }
}
