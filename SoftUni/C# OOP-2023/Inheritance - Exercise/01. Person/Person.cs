﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        private string name;

        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString() 
        {
            StringBuilder stringBuilder= new StringBuilder();

            stringBuilder.Append(String.Format("Name: {0}, Age: {1}", Name, Age));

            return stringBuilder.ToString();
        }

    }
}
