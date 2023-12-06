using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "Beast!")
            {
                string[] tokes = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (command)
                {
                    case "Cat":
                        //if (tokes[2] == "Female")
                        //{
                        //    Kitten kitten = new(tokes[0], int.Parse(tokes[1]));

                        //    Console.WriteLine(kitten.Type);
                        //    Console.WriteLine(kitten);

                        //}
                        //else
                        //{
                        //    Tomcat tomcat = new(tokes[0], int.Parse(tokes[1]));

                        //    Console.WriteLine(tomcat.Type);
                        //    Console.WriteLine(tomcat);
                        //}

                        Cat cat = new(tokes[0], int.Parse(tokes[1]), tokes[2]);

                        Console.WriteLine(cat.Type);
                        Console.WriteLine(cat);


                        break;
                    case "Dog":

                        Dog dog = new(tokes[0], int.Parse(tokes[1]), tokes[2]);

                        Console.WriteLine(dog.Type);
                        Console.WriteLine(dog);

                        break;
                    case "Frog":

                        Frog frog = new(tokes[0], int.Parse(tokes[1]), tokes[2]);

                        Console.WriteLine(frog.Type);
                        Console.WriteLine(frog);

                        break;

                    default:

                        Console.WriteLine("Invalid input!");

                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
