using System;

namespace ChangeMatrix
{
	class Matrix
	{
		private int[,] privateMatrix;

		public Matrix()
		{
			int someValue = 10;
			privateMatrix = new int[4, 4];
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					privateMatrix[i, j] = someValue++;
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
			var matrixSize = privateMatrix.GetLength(0);
			var tempMatrix = new int[matrixSize, matrixSize];
			for (var i = 0; i < matrixSize; i++)
			{
				for (var j = 0; j < matrixSize; j++)
				{
					tempMatrix[j, matrixSize - 1 - i] = privateMatrix[i, j];
				}
			}
			privateMatrix = tempMatrix;
		}
		//Display matrix
		public void DisplayMatrix()
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					Console.Write(privateMatrix[i,j] + " ");
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
