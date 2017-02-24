using System;

namespace Truck
{
	class Truck
	{
		public string Model;            //vehicle model
		public double Length;           //vehicle length
		public double Height;           //vehicle height
		public double Width;            //vehicle width
		public int MaxSpeed;            //vehicle max speed
		public int Power;               //vehicle engine power
		public int NumberOfGears;       //transmission number of gears

		public Truck()
		{
			Model = "ZIL 157  ";
			Length = 6.68;
			Height = 2.9;
			Width = 2.32;
			MaxSpeed = 65;
			Power = 109;
			NumberOfGears = 5;       //All vehicles have 5-speed manual transmission
		}

		public Truck(string model, double length, double e, double r, int t, int y, int u)       //another vehicle parameters 
		{
			Model = model;
			Length = length;
			Height = e;
			Width = r;
			MaxSpeed = t;
			Power = y;
			NumberOfGears = u;
		}

		public double VehicleVolume()            //Vehicle volume
		{
			return Length * Height * Width;
		}
	}
	class TruckDemo
	{
		static void Main()
		{
			var truckArray = new Truck[]
			{
				new Truck("URAL 4320", 7.4, 2.5, 3, 85, 240, 5),
				new Truck("URAL 375D", 7.35, 2.9, 2.69, 75, 180, 5),
				new Truck("URAL 375D", 7.35, 2.9, 2.69, 75, 180, 5),
				new Truck("KRAZ 255B", 8.65, 3.18, 2.75, 71, 240, 5),
				new Truck("KAMAZ 4310", 7.65, 3.59, 2.5, 85, 220, 5),
				new Truck()
		};

			Console.WriteLine("Model   \tLength\tHeight\tWidth\tMaxSp\tPower\tNuOfG\tVehicle Volume");
			foreach (var truck in truckArray)
			{
				Console.Write(truck.Model + "\t" + truck.Length + "\t" + truck.Height + "\t" +
				              truck.Width + "\t" + truck.MaxSpeed + "\t" + truck.Power + "\t" +
				              truck.NumberOfGears + "\t" + truck.VehicleVolume() + "\t\n\n");
			}
		}
	}
}