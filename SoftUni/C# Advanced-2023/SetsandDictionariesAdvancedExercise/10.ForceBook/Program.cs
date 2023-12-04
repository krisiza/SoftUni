using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace _10.ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, HashSet<string>> sides = new();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

                    string side = tokens[0];
                    string user = tokens[1];

                    if (!sides.ContainsKey(side))
                    {
                        sides.Add(side, new HashSet<string>());
                    }

                    if (!sides[side].Contains(user))
                        sides[side].Add(user);
                }
                else
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string user = tokens[0];
                    string side = tokens[1];

                    var foundUser = sides.FirstOrDefault(x => x.Value.Contains(user));

                    if (sides.ContainsKey(side) && foundUser.Value != null)
                    {
                        foreach (var s in sides)
                        {
                            foreach (var name in s.Value)
                            {
                                if (name == user)
                                    sides[s.Key].Remove(name);
                            }
                        }

                        sides[side].Add(user);
                    }
                    else
                    {
                        if (sides.ContainsKey(side))
                        {
                            sides[side].Add(user);
                        }
                        else
                        {
                            sides.Add(side, new HashSet<string>());
                            sides[side].Add(user);
                        }
                    }

                    Console.WriteLine($"{user} joins the {side} side!");
                }

                input = Console.ReadLine();
            }

            var sorted = sides.OrderByDescending(x => x.Value.Count);

            foreach (var s in sorted)
            {
                if (s.Value.Any())
                {
                    Console.WriteLine($"Side: {s.Key}, Members: {s.Value.Count}");

                    foreach (var name in s.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {name}");
                    }
                }

            }
        }
    }
}