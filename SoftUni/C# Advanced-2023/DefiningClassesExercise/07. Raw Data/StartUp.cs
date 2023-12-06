using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DefiningClasses
{
    /*
2
ChevroletAstro 200 180 1000 fragile 1,3 1 1,5 2 1,4 2 1,7 4
Citroen2CV 190 165 1200 fragile 0,9 3 0,85 2 0,95 2 1,1 1
fragile
*/
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                Engine engine = new(engineSpeed, enginePower);
                Cargo cargo = new(cargoType, cargoWeight);
                Tire[] tires =
                {
                    new Tire(int.Parse(tokens[6]), float.Parse(tokens[5])),
                    new Tire(int.Parse(tokens[8]), float.Parse(tokens[7])),
                    new Tire(int.Parse(tokens[10]),float.Parse(tokens[9])),
                    new Tire(int.Parse(tokens[12]),float.Parse(tokens[11])),
                };

                Car car = new(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();


            if (command == "fragile")
            {
                cars
                    .Where(x => x.Cargo.Type == command)
                    .Where(x => x.Tires.Any(t => t.Pressure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
            else if (command == "flammable")
            {
                cars
                    .Where(x => x.Cargo.Type == command)
                    .Where(x => x.Engine.Power > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }

        }
    }
}
