using System;

namespace changeMatrix
{
    class Matrix
    {
        private int[,] priv_matrix;

        public Matrix()
        {
            priv_matrix = new int[4, 4];
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
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


        //Method that swaps values of columns and rows of matrix
        public void Rotate()
        {
            for (int i = 1; i < 4; i++)
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
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(priv_matrix[i, j] + " ");
                }
                Console.WriteLine();
            };
            Console.WriteLine();
        }

    }

    class Program
    {
        static void Main()
        {
            var newMatrix = new Matrix();
            newMatrix.DisplayMatrix();
            newMatrix.ChangeColumn(3);
            newMatrix.DisplayMatrix();
            newMatrix.Rotate();
            newMatrix.DisplayMatrix();
            newMatrix.ChangeColumn(3);
            newMatrix.DisplayMatrix();
        }
    }
}
