using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Tire
    {
		private int age;
		private float pressure;

		public Tire(int age, float pressure)
        {
            Age = age;
            Pressure = pressure;
        }

        public int Age
		{
			get { return age; }
			set { age = value; }
		}

        public float Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
    }
}
