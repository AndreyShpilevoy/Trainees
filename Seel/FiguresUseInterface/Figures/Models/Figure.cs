﻿namespace Figures.Models
{
	//abstract class Figure
	//{
	//	public double a;

	//	public Figure()
	//	{
	//		a = 0;
	//	}

	//	public Figure(double input)
	//	{
	//		a = input;
	//	}

	//	public double Area
	//	{
	//		get { return 0; }
	//	}

	//	public abstract void GetInfo();


	//}

	interface IFigure
	{
		double Area
		{
			get;
		}

		void GetInfo();
	}
}
