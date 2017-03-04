using System;

namespace Figures.Base
{
	class Square : Figure 
	{
		public Square(double input)
		{
			a = input;
		}

		public new double Area
		{
			get { return a *a; }
		}

		public override void GetInfo()
		{
			Console.WriteLine("This object is square.");
			Console.WriteLine("The area of object equals: " + Area + "\n");
		}
}

	class Circle : Figure
	{
		public Circle(double input)
		{
			a = input;
		}

		public new double Area
		{
			get { return Math.PI * a * a; }
		}

		public override void GetInfo()
		{
			Console.WriteLine("This object is circle.");
			Console.WriteLine("The area of object equals: " + Area + "\n");
		}
	}

	class Rectangle : Figure
	{
		double b;
		public Rectangle(double inputA, double inputB)
		{
			a = inputA;
			b = inputB;
		}

		public new double Area
		{
			get { return a * b; }
		}

		public override void GetInfo()
		{
			Console.WriteLine("This object is rectangle.");
			Console.WriteLine("The area of object equals: " + Area + "\n");
		}
	}
}
