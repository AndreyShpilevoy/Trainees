using System;

namespace SnailMatrix
{
	class Matrix
	{
		private int[,] privateMatrix;

		public Matrix() //create matrix (MEGA CRUTCH)
		{
			var initialValue = 10;
			privateMatrix = new int[6, 6];

			//column 5
			for (var i = 5; i >= 0; i--)
			{
				privateMatrix[i, 5] = initialValue++;
			}

			//row 0
			for (var count = 4; count >= 0; count--)
			{
				privateMatrix[0, count] = initialValue++;
			}

			//column 0
			for (var i = 1; i <= 5; i++)
			{
				privateMatrix[i, 0] = initialValue++;
			}


			//row 5
			for (var count = 1; count < 5; count++)
			{
				privateMatrix[5, count] = initialValue++;
			}


			//column 4
			for (var i = 4; i > 0; i--)
			{
				privateMatrix[i, 4] = initialValue++;
			}

			//row 1
			for (var count = 3; count > 0; count--)
			{
				privateMatrix[1, count] = initialValue++;
			}


			//column 1
			for (var i = 2; i <= 4; i++)
			{
				privateMatrix[i, 1] = initialValue++;
			}


			//row 4
			for (var count = 2; count < 4; count++)
			{
				privateMatrix[4, count] = initialValue++;
			}


			//column 3
			for (var i = 3; i >= 2; i--)
			{
				privateMatrix[i, 3] = initialValue++;
			}

			//column/row 2
			for (var i = 2; i < 4; i++)
			{
				privateMatrix[i, 2] = initialValue++;
			}

		}

		public void MatrixShow() //Matrix show
		{
			for (var i = 0; i < 6; i++)
			{
				for (var j = 0; j < 6; j++)
				{
					Console.Write(privateMatrix[i, j] + " ");
				}
				Console.WriteLine();
			}
		}
	}

	class User
	{
		static void Main()
		{
			Matrix newMatrix = new Matrix();
			newMatrix.MatrixShow();
		}
	}
}
