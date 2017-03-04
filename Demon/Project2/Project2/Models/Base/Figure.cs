using System;

abstract class Figure
{
	double _width;
	double _height;

	public Figure()
	{
		_width = 0.0;
		_height = 0.0;
		Name = String.Empty;
	}

	public Figure(double w, double h, string n)
	{
		_width = w;
		_height = h;
		Name = n;
	}

	public double Width
	{
		get
		{
			return _width;
		}

		set
		{
			_width = value < 0 ? -value : value;
		}
	}

	public double Height
	{
		get
		{
			return _height;
		}

		set
		{
			_height = value < 0 ? -value : value;
		}
	}

	public string Name { get; set; }

	public abstract double Area();

	public abstract void GetInfo();
}