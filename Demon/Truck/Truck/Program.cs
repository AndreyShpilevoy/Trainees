using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Truck(string q, double w, double e, double r, int t, int y, int u)       //another vehicle parameters 
        {
            Model = q;
            Length = w;
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
            //URAL 4320 Lenght = 7.4m  Height = 3m  Width = 2.5m  MaxSpeed = 85 km/h  Power = 240h.p.
            Truck TRUCK1 = new Truck("URAL 4320", 7.4, 2.5, 3, 85, 240, 5);

            //URAL 375D Lenght = 7.35m  Height = 2.9m  Width = 2.69m  MaxSpeed = 75 km/h  Power = 180h.p.
            Truck TRUCK2 = new Truck("URAL 375D", 7.35, 2.9, 2.69, 75, 180, 5);

            //KRAZ 255B Lenght = 8.65m  Height = 3.18m  Width = 2.75m  MaxSpeed = 71 km/h  Power = 240h.p.
            Truck TRUCK3 = new Truck("KRAZ 255B", 8.65, 3.18, 2.75, 71, 240, 5);

            //KAMAZ Lenght = 7.65m  Height = 3.59m  Width = 2.5m  MaxSpeed = 85 km/h  Power = 220h.p.
            Truck TRUCK4 = new Truck("KAMAZ 4310", 7.65, 3.59, 2.5, 85, 220, 5);

            //ZIL 157 Lenght = 6.68m  Height = 2.9m  Width = 2.32m  MaxSpeed = 65 km/h  Power = 109h.p.
            Truck TRUCK5 = new Truck();

            //Truck name array
            string[,] TruckName =
            {
                {TRUCK1.Model},
                {TRUCK2.Model},
                {TRUCK3.Model},
                {TRUCK4.Model},
                {TRUCK5.Model},
            };

            //Truck parameters array
            double[,] TruckParameters =
            {
                {TRUCK1.Length, TRUCK1.Height, TRUCK1.Width, TRUCK1.MaxSpeed, TRUCK1.Power, TRUCK1.NumberOfGears, TRUCK1.VehicleVolume()},
                {TRUCK2.Length, TRUCK2.Height, TRUCK2.Width, TRUCK2.MaxSpeed, TRUCK2.Power, TRUCK2.NumberOfGears, TRUCK2.VehicleVolume()},
                {TRUCK3.Length, TRUCK3.Height, TRUCK3.Width, TRUCK3.MaxSpeed, TRUCK3.Power, TRUCK3.NumberOfGears, TRUCK3.VehicleVolume()},
                {TRUCK4.Length, TRUCK4.Height, TRUCK4.Width, TRUCK4.MaxSpeed, TRUCK4.Power, TRUCK4.NumberOfGears, TRUCK4.VehicleVolume()},
                {TRUCK5.Length, TRUCK5.Height, TRUCK5.Width, TRUCK5.MaxSpeed, TRUCK5.Power, TRUCK5.NumberOfGears, TRUCK5.VehicleVolume()},
            };
            //Header parameters
            string[] HeaderParameters = { "Model   ", "Length", "Height", "Width", "MaxSp", "Power", "NuOfG", "Vehicle Volume" };

            //data output to the console
            //Head
            int g;
            for (g = 0; g < 8; g++)
            {
                Console.Write(HeaderParameters[g]+ "\t");
            }
            Console.WriteLine();
            int t, i;
            for (t = 0; t < 5; t++)
                switch (t)
                {
                    case 0:
                        Console.Write(TruckName[t, 0] + "\t");
                        for (i = 0; i < 7; i++)
                        {
                            Console.Write(TruckParameters[t, i] + "\t");
                        }
                        Console.WriteLine("\n");
                        break;

                    case 1:
                        Console.Write(TruckName[t, 0] + "\t");
                        for (i = 0; i < 7; i++)
                        {
                            Console.Write(TruckParameters[t, i] + "\t");
                        }
                        Console.WriteLine("\n");
                        break;

                    case 2:
                        Console.Write(TruckName[t, 0] + "\t");
                        for (i = 0; i < 7; i++)
                        {
                            Console.Write(TruckParameters[t, i] + "\t");
                        }
                        Console.WriteLine("\n");
                        break;

                    case 3:
                        Console.Write(TruckName[t, 0] + "\t");
                        for (i = 0; i < 7; i++)
                        {
                            Console.Write(TruckParameters[t, i] + "\t");
                        }
                        Console.WriteLine("\n");
                        break;

                    case 4:
                        Console.Write(TruckName[t, 0] + "\t");
                        for (i = 0; i < 7; i++)
                        {
                            Console.Write(TruckParameters[t, i] + "\t");
                        }
                        Console.WriteLine("\n");
                        break;
                }
        }
    }
}