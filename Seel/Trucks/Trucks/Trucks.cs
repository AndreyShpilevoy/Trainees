using System;

namespace Trucks
{
	class Truck
	{
		public string Name;    // truck name
		public double Length;  // lenght of truck in meters
		public double Height;  // height of truck in meters
		public double Width;   // width of truck in meters
		public int Speed;      //maximum speed in km/h
		public int GearboxShifts; //amount of gearbox shifts 
		public int EnginePower; //power of engine in hp
		
		public Truck()
		{
			Name = "Kenworth W900";
			Length = 7.2;
			Height = 3.1;
			Width = 3.2;
			Speed = 90;
			GearboxShifts = 10;
			EnginePower = 625;
		}
		
		public Truck(string n, double l, double h, double w, int s, int gears, int hp)
		{
			Name = n;
			Length = l;
			Height = h;
			Width = w;
			Speed = s;
			GearboxShifts = gears;
			EnginePower = hp;
		}

		public void TruckVolume()
		{
			Console.WriteLine("Truck volume: " + Length * Height * Width + " cubic meters\n\n");
		}
	}
	
	class GenerateAndDemoTrucks
	{
		static void Main()
		{
			var trucksArray = new Truck[]
			{
				new Truck(),
				new Truck("Iveco High-Way", 4, 4, 4, 100, 11, 400),
				new Truck("DAF XF", 3, 3, 3, 105, 9, 380),
				new Truck("Mercedes Benz", 3, 3, 3, 110, 10, 500)
			};
			
			foreach (var truck in trucksArray)
			{
				Console.WriteLine("Name of the truck: " + truck.Name + "\nLength: " + truck.Length + "\nWidth: " + truck.Width +
				                  "\nHeight: " + truck.Height + "\nMaximum speed: " + truck.Speed + " km/h" + "\nGearbox: " +
				                  truck.GearboxShifts + " shifts" + "\nEngine power: " + truck.EnginePower + " HP");
				truck.TruckVolume();
			}
		}
	}
}