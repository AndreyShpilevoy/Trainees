﻿using System;

class Rectangle : IModelInfo
{
	protected double aSide;
	protected double bSide;
	protected string type;

	public Rectangle()
	{
		aSide = 0.0;
		bSide = 0.0;
		type = "figure";
	}

	public Rectangle(double sideA, double sideB, string ftyppe)
	{
		aSide = sideA;
		bSide = sideB;
		type = ftyppe;
	}

	public virtual double Area()
	{
		return aSide * bSide;
	}

	public virtual double Perimeter()
	{
		return 2 * (aSide + bSide);
	}
	public virtual void GetInfo()
	{
		Console.WriteLine("\nFigure type: " + type + "\nSide A: " + aSide + "\nSide B: " + bSide);
		Console.WriteLine("Figure area: {0:#.##}", Area());
		Console.WriteLine("Figure curve length: {0:#.##}", Perimeter());
	}
}

class Circle : IModelInfo
{
	private double radius;
	private string figureType;

	public Circle()
	{
		radius = 0.0;
		figureType = "figure";
	}

	public Circle(double radiusCircle, string typeFigure)
	{
		radius = radiusCircle;
		figureType = typeFigure;
	}

	public double Area()
	{
		return Math.PI * Math.Pow(radius,2);
	}

	public double Perimeter()
	{
		return 2 * Math.PI * radius;
	}

	public void GetInfo()
	{
		Console.WriteLine("\nFigure type: " + figureType + "\nRadius: " + radius);
		Console.WriteLine("Figure area: {0:#.##}", Area());
		Console.WriteLine("Figure curve length: {0:#.##}",Perimeter());
	}
}

class Rhombus : IModelInfo
{
	private double diagonalBig;
	private double diagonalLittle;
	private double side;
	private string typeRhombus;

	public Rhombus()
	{
		diagonalBig = 0.0;
		diagonalLittle = 0.0;
		side = 0.0;
		typeRhombus = "figure";
	}

	public Rhombus(double SideRhomb, double diagonalMaximum, double diagonalMinimum, string name)
	{
		side = SideRhomb;
		diagonalBig = diagonalMaximum;
		diagonalLittle = diagonalMinimum;
		typeRhombus = name;
	}

	public double Area()
	{
		return 0.5 * diagonalBig * diagonalLittle;
	}

	public virtual double Perimeter()
	{
		return 4 * side;
	}

	public void GetInfo()
	{
		Console.WriteLine("\nFigure type: " + typeRhombus + "\nSide: " + side + "\nDiagonal 1: " + diagonalBig + "\nDiagonal 2: " + diagonalLittle);
		Console.WriteLine("Figure area: {0:#.##}", Area());
		Console.WriteLine("Figure curve length: {0:#.##}", Perimeter());
	}
}

class Triangle : Rectangle
{
	private double _cSide;
	private double _width;

	public Triangle(double aSideTriangle, double bSideTriangle, double cSideTriangle, double widthTriangle, string name)
	{
		aSide = aSideTriangle;
		bSide = bSideTriangle;
		_cSide = cSideTriangle;
		_width = widthTriangle;
		type = name;
	}

	public override double Area()
	{
		return 0.5 * _width * _cSide;
	}

	public override double Perimeter()
	{
		return aSide + bSide + _cSide;
	}

	public override void GetInfo()
	{
		Console.WriteLine("\nFigure type: " + type + "\nSide a: " + aSide + "\nSide b: " + bSide + "\nSide c: " + _cSide+ "\nWidth to c side: " + _width);
		Console.WriteLine("Figure area: {0:#.##}", Area());
		Console.WriteLine("Figure curve length: {0:#.##}", Perimeter());
	}
}