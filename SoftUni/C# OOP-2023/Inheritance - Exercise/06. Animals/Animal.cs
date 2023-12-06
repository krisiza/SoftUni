using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }


        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder= new StringBuilder();

            stringBuilder.AppendLine($"{Name} {Age} {Gender}");
            stringBuilder.AppendLine(ProduceSound());

            return stringBuilder.ToString().Trim();
        }
    }
}
