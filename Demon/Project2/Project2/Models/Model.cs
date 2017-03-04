using System;

class Square:Figure
{
	public Square(double width, double height, string name)
	{
		Width = width;
		Height = height;
		Name = name;
	}

	public override double Area()
	{
		return Width * Height;
	}

	public double Perimeter()
	{
		return 2 * (Width + Height);
	}
	public override void GetInfo()
	{
		Console.WriteLine("\nName: "+Name+"\nWidth: "+Width+"\nHeight: "+Height);
	}
}

class Circle : Figure
{
	public double radius;
	public double diameter;

	public Circle()
	{
		radius = 0.0;
		diameter = 0.0;
	}

	public Circle(double radiusCircle, double diameterCircle,string nameCircle)
	{
		radius = radiusCircle;
		diameter = diameterCircle;
		Name = nameCircle;
	}

	public override double Area()
	{
		return 3.14 * radius*radius;
	}

	public double Perimeter()
	{
		return 2 * 3.14 * radius;
	}

	public override void GetInfo()
	{
		Console.WriteLine("\nName: " + Name + "\nRadius: " + radius + "\nDiameter: " + diameter);
	}
}

class Rhombus :Figure
{
	public double diagonalMax;
	public double diagonalMin;
	public double aSide;
	public double bSide;

	public Rhombus()
	{
		diagonalMax = 0.0;
		diagonalMin = 0.0;
		aSide = 0.0;
		bSide = 0.0;
	}

	public Rhombus(double aSideRhomb,double bSideRhomb,double diagonalMaximum, double diagonalMinimum, string name)
	{
		aSide = aSideRhomb;
		bSide = bSideRhomb;
		diagonalMax = diagonalMaximum;
		diagonalMin = diagonalMinimum;
		Name = name;
	}

	public override double Area()
	{
		return 0.5 * diagonalMax * diagonalMin;
	}

	public virtual double Perimeter()
	{
		return 2 * (aSide + bSide);
	}

	public override void GetInfo()
	{
		Console.WriteLine("\nName: " + Name + "\nSide a: " + aSide + "\nSide b: " + bSide+"\nDiagonal 1: "+diagonalMax+"\nDiagonal 2: "+diagonalMin);
	}
}

class Triangle : Rhombus
{
	double cSide;

	public Triangle()
	{
	}

	public Triangle(double aSideTriangle, double bSideTriangle, double widthTriangle, double heightTriangle, string name)
	{
		aSide = aSideTriangle;
		bSide = bSideTriangle;
		Width = widthTriangle;
		Height = heightTriangle;
		Name = name;
	}

	public override double Area()
	{
		return 0.5 * aSide * Height;
	}

	public override double Perimeter()
	{
		return aSide + bSide + cSide;
	}

	public override void GetInfo()
	{
		Console.WriteLine("\nName: " + Name + "\nSide a: " + aSide + "\nSide b: " + bSide + "\nWidth: " + Width + "\nHeight: " + Height);
	}
}

class Programm
{
	static void Main()
	{
		Figure[] figure = new Figure[4];

		figure [0] = new Square(6.2, 6.2, "Square");
		figure[1] = new Circle(2.3, 4.6, "Circle");
		figure[2] = new Rhombus(2.67, 2.67, 4.9, 2.1, "rhombus");
		figure[3] = new Triangle(6.7, 6.7, 9.4, 4.77, "triangle");

		Square square = new Square(6.2, 6.2, "Square");
		Circle circle = new Circle(2.3, 4.6, "Circle");
		Rhombus rhombus = new Rhombus(2.67, 2.67, 4.9, 2.1, "rhombus");
		Triangle triangle = new Triangle(6.7, 6.7, 9.4, 4.77, "triangle");

		for (var i = 0; i < figure.Length; i++)
		{
			figure[i].GetInfo();
			Console.WriteLine("Area: " + figure[i].Area());
		}

		Console.WriteLine("\nSquare perimeter: " + square.Perimeter());
		Console.WriteLine("Circle perimeter: " + circle.Perimeter());
		Console.WriteLine("Rhombus perimeter: " + rhombus.Perimeter());
		Console.WriteLine("Triangle perimeter: " + triangle.Perimeter());
	}
}