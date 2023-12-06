using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = tires;
        }

        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }


        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }


        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public bool FindFragileCars(Car car)
        {
            bool success = true;
            if (car.cargo.Type == "fragile")
            {
                foreach (var tire in car.Tires)
                {
                    if (tire.Pressure >= 1)
                    {
                        success = false;
                        break;
                    }
                }
            }
            return success;
        }

        public bool FindFlammableCars(Car car)
        {
            if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                return true;
            else
                return false;
        }
    }
}
