using System;

namespace changeMatrix
{

	class Matrix
	{
		private int[,] privateMatrix;

		public Matrix() : this(4)
		{
		}

		public Matrix(int size)
		{
			var valueDefault = 10;
			privateMatrix = new int[size, size];
			for (var i = 0; i < privateMatrix.GetLength(0); ++i)
			{
				for (var j = 0; j < privateMatrix.GetLength(1); ++j)
				{
					privateMatrix[i, j] = valueDefault++;
				}
			};
		}

		//Method that changes values in every index of second column with value entered as a parameter
		public void ChangeColumn(int value)
		{
			ChangeColumn(value, 1);
		}

		//Method overloading, customisable column number
		public void ChangeColumn(int value, int columnNumber)
		{
			for (var i = 0; i < privateMatrix.GetLength(1); i++)
			{
				privateMatrix[i, columnNumber] = value;
			};
		}

		//Method that swaps values of columns and rows of matrix
		public void Rotate()
		{
			var matrixSize = privateMatrix.GetLength(0);
			var tempMatrix = new int[matrixSize, matrixSize];
			for (var i = 0; i < matrixSize; i++)
			{
				for (var j = 0; j < matrixSize; j++)
				{
					tempMatrix[j, matrixSize- 1 - i] = privateMatrix[i, j];
				}
			}
			privateMatrix = tempMatrix;
		}

		//Method to display matrix content
		public void DisplayMatrix()
		{
			for (var i = 0; i < privateMatrix.GetLength(0); i++)
			{
				for (var j = 0; j < privateMatrix.GetLength(1); j++)
				{
					Console.Write(privateMatrix[i, j] + " ");
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
			UserControl();
		}

		public static void UserControl()
		{
			Console.WriteLine("Hi! This program can do some cool stuff with a square matrix of integers.\n\n" +
				"To create new square matrix of custom size enter: 'New'\n" +
				"To change any column of that matrix to specific value enter: 'Change column'\n" +
				"To swap columns and rows of the matrix enter: 'Swap'\n" +
				"To finish fun enter: 'End'\n" +
				"To see list of commands again enter: 'Help'\n");
			string command = string.Empty;
			var newMatrix = new Matrix();

			while (command != "end")
			{
				switch (command)
				{
					case "new":
						{
							Console.WriteLine("Cool! What size of the matrix do we need?");
							int matrixSize;
							if (Int32.TryParse(Console.ReadLine(), out matrixSize) && matrixSize >= 0)
							{
								newMatrix = new Matrix(matrixSize);
								newMatrix.DisplayMatrix();
							}
							command = string.Empty;
							break;
						}
					case "change column":
						{
							Console.WriteLine("What column do you want to change?");
							int columnNumber = Int32.Parse(Console.ReadLine());
							Console.WriteLine("What new value we want in " + columnNumber + " column after change?");
							int valueNew = Int32.Parse(Console.ReadLine());
							newMatrix.ChangeColumn(valueNew, columnNumber - 1);
							newMatrix.DisplayMatrix();
							command = string.Empty;
							break;
						}
					case "swap":
						{
							newMatrix.Rotate();
							newMatrix.DisplayMatrix();
							command = string.Empty;
							break;
						}
					case "help":
						{
							Console.WriteLine("To create new square matrix of custom size enter: 'New'\n" +
											"To change any column of that matrix to specific value enter: 'Change column'\n" +
											"To swap columns and rows of the matrix enter: 'Swap'\n" +
											"To finish fun enter: 'End'\n" +
											"To see list of commands again enter: 'Help'\n");
							command = string.Empty;
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
	}
}
