using Figures.Models;

namespace Figures
{
	class Program
	{
		static void Main()
		{
			Square s = new Square(4.5);
			Circle c = new Circle(3.1);
			Rectangle r = new Rectangle(4.7, 3.8);
			s.GetInfo();
			c.GetInfo();
			r.GetInfo();
			IFigure s1 = s;
			s1.GetInfo();
			IFigure c1 = c;
			c1.GetInfo();
		}
	}
}
