using System;

abstract class Figure
{
	double width;
	double height;
	string name;

	public Figure()
	{
		width = height = 0.0;
		name = "null";
	}

	public Figure (double w, double h, string n)
	{
		width = w;
		height = h;
		name = n;
	}

	public double Width
	{
		get
		{
			return width;
		}

		set
		{
			width = value < 0 ? -value : value;
		}
	}

	public double Height
	{
		get
		{
			return height;
		}

		set
		{
			height = value < 0 ? -value : value;
		}
	}

	public string Name
	{
		get
		{
			return name;
		}

		set
		{
			name = value;
		}
	}

	public abstract double Area();

	public abstract void GetInfo();
}