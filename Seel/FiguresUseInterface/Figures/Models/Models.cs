using System;

namespace Figures.Models
{
	class Square : IFigure
	{
		double side;
		public Square(double input)
		{
			side = input;
		}

		public double Area
		{
			get { return Math.Pow(side, 2); }
		}

		public void GetInfo()
		{
			Console.WriteLine("This object is square.");
			Console.WriteLine("The area of object equals: " + Area + "\n");
		}
}

	class Circle : IFigure
	{
		double radius;
		public Circle(double input)
		{
			radius = input;
		}

		public double Area
		{
			get { return Math.PI * Math.Pow(radius, 2); }
		}

		public void GetInfo()
		{
			Console.WriteLine("This object is circle.");
			Console.WriteLine("The area of object equals: " + Area + "\n");
		}
	}

	class Rectangle : IFigure
	{
		double sideOne;
		double sideTwo;
		public Rectangle(double inputA, double inputB)
		{
			sideOne = inputA;
			sideTwo = inputB;
		}

		public new double Area
		{
			get { return sideOne * sideTwo; }
		}

		public void GetInfo()
		{
			Console.WriteLine("This object is rectangle.");
			Console.WriteLine("The area of object equals: " + Area + "\n");
		}
	}
}
