using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trucks
{
    //class containing truck name and specifications, also containing method to calculate volume of truck

    class Truck
    {
        public string name;    // truck name
        public double length;  // lenght of truck in meters
        public double height;  // height of truck in meters
        public double width;   // width of truck in meters
        public int speed;      //maximum speed in km/h
        public int gearbox_shifts; //amount of gearbox shifts 
        public int engine_power; //power of engine in hp

        // calculate and show truck volume in cubic meters
        public void TruckVolume()
        {
            Console.WriteLine("Truck volume: " + length * height * width + " cubic meters\n\n");
        }

        //simple constructor
        public Truck()
        {
            name = "Kenworth W900";
            length = 7.2;
            height = 3.1;
            width = 3.2;
            speed = 90;
            gearbox_shifts = 10;
            engine_power = 625;
        }

        // A parameterized constructor
        public Truck(string n, double l, double h, double w, int s, int gears, int hp)
        {
            name = n;
            length = l;
            height = h;
            width = w;
            speed = s;
            gearbox_shifts = gears;
            engine_power = hp;
        }
    }

    //class containing method collecting objects of Truck class in array and storing the real amount of used cells of array
    class TruckCollection
    {
        //array storing object of truck class
        public Truck[] truck_collection = new Truck[4];
        //integer to count actual(not empty) cells of array
        public int collection_length;

        //add new object to collection and count it number
        public void AddNew(Truck name)
        {
            truck_collection[collection_length++] = name;
        }

    }

    // Using two constructors to build four instances of truck class objects
    class GenerateAndDemoTrucks
    {
        static void Main()
        {
            TruckCollection TrucksArray = new TruckCollection();

            //simple constructor in use 
            Truck KenworthW900 = new Truck();
            TrucksArray.AddNew(KenworthW900);
            //parameterized constructor in use
            Truck Iveco_HighWay = new Truck("Iveco High-Way", 4, 4, 4, 100, 11, 400);
            TrucksArray.AddNew(Iveco_HighWay);
            Truck DAF_XF = new Truck("DAF XF", 3, 3, 3, 105, 9, 380);
            TrucksArray.AddNew(DAF_XF);
            Truck MercedesBenz_Actros = new Truck("Mercedes Benz", 3, 3, 3, 110, 10, 500);
            TrucksArray.AddNew(MercedesBenz_Actros);

            //outputing trucks information using our array with instances of truck class
            foreach (Truck i in TrucksArray.truck_collection)
            {
                Console.WriteLine("Name of the truck: " + i.name +
                    "\nLength: " + i.length +
                    "\nWidth: " + i.width +
                    "\nHeight: " + i.height +
                    "\nMaximum speed: " + i.speed + " km/h" +
                    "\nGearbox: " + i.gearbox_shifts + " shifts" +
                    "\nEngine power: " + i.engine_power + " HP");
                i.TruckVolume();
            }
        }
    }
}