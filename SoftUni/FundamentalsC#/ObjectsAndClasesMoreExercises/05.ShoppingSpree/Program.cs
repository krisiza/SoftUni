using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int j = 0; j < 2; j++)
            {
                string name = null;
                decimal money = 0;

                string[] arr = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i++)
                {
                    string[] personProduct = arr[i].Split("=");

                    name = personProduct[0];
                    money = decimal.Parse(personProduct[1]);

                    if (j == 0)
                    {
                        Person person = new Person(name, money);
                        people.Add(person);
                    }
                    else
                    {
                        Product product = new Product(name, money);
                        products.Add(product);
                    }
                }
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] arr = input.Split();
                string name = arr[0];
                string productName = arr[1];

                var person = people.FirstOrDefault(x => x.Name == name);
                var product = products.FirstOrDefault(x => x.Name == productName);

                person.BuyProduct(person, product);

                input = Console.ReadLine();
            }

            List<Person> peopleWithProducts = people.Where(x => x.Products.Count > 0).ToList();
            List<Person> peopleWithoutProducts = people.Where(x => x.Products.Count <= 0).ToList();


            foreach (Person person in peopleWithProducts)
            {
                Console.Write(person.Name + " - ");
                Console.WriteLine(String.Join(", ", person.Products));
            }

            if(peopleWithoutProducts.Count > 0) 
            {
                foreach (Person person in peopleWithoutProducts)
                {
                    Console.Write(person.Name + " - Nothing bought");
                }
            }

        }
    }
    class Person
    {
        public string Name { get; set; }
        public Product Product { get; set; }
        public decimal Money { get; set; }
        public List<string>  Products{ get; set; }

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;

            Products = new List<string>();
        }

        public void BuyProduct(Person person, Product product)
        {
            decimal temp = Money;
            if (person.Money > 0)
            {
                person.Money -= product.Cost;
                if (person.Money < 0)
                {
                    person.Money = temp;
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    return;
                }
                person.Products.Add(product.Name);
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            else
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
        }
    }
    class Product
    {
        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
