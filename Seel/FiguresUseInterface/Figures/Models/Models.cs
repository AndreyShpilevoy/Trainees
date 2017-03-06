using System;

namespace Figures.Models
{
	class Square : IFigure
	{
		private double _side;
		public Square(double input)
		{
			_side = input;
		}

		public double Area
		{
			get { return Math.Pow(_side, 2); }
		}

		public void GetInfo()
		{
			Console.WriteLine("This object is square.");
			Console.WriteLine("The area of object equals: " + Area + "\n");
		}
}

	class Circle : IFigure
	{
		private double _radius;
		public Circle(double input)
		{
			_radius = input;
		}

		public double Area
		{
			get { return Math.PI * Math.Pow(_radius, 2); }
		}

		public void GetInfo()
		{
			Console.WriteLine("This object is circle.");
			Console.WriteLine("The area of object equals: " + Area + "\n");
		}
	}

	class Rectangle : IFigure
	{
		private double _sideOne;
		private double _sideTwo;
		public Rectangle(double inputA, double inputB)
		{
			_sideOne = inputA;
			_sideTwo = inputB;
		}

		public double Area
		{
			get { return _sideOne * _sideTwo; }
		}

		public void GetInfo()
		{
			Console.WriteLine("This object is rectangle.");
			Console.WriteLine("The area of object equals: " + Area + "\n");
		}
	}
}
