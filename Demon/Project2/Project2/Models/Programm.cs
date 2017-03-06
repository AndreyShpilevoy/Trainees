class Programm
{
	static void Main()
	{
		Rectangle s = new Rectangle(4.5, 7.2, "Rectangle");
		Circle c = new Circle(3.1, "CIrcle");
		Rhombus r = new Rhombus(3.27, 5.4, 3.7, "Rhombus");
		Triangle t = new Triangle(6.1, 8.3, 4.9,3.57, "Triangle");
		s.GetInfo();
		c.GetInfo();
		r.GetInfo();
		t.GetInfo();
	}
}