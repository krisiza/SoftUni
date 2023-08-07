using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.CompanyUsers
{
    /*
SoftUni -> AA12345
SoftUni -> BB12345
HI -> AA12345
Microsoft -> CC12345
HP -> BB12345
End
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] arr = input.Split(" -> ");

                string company = arr[0];
                string employee = arr[1];

                if (!companies.ContainsKey(company))
                {
                    companies[company] = new List<string>();

                    if (!companies[company].Contains(employee))
                        companies[company].Add(employee);
                }
                else
                {
                    if (!companies[company].Contains(employee))
                        companies[company].Add(employee);
                }

                input = Console.ReadLine();
            
            }

            foreach (var s in companies)
            {
                Console.WriteLine(s.Key);
                Console.Write("-- ");
                Console.WriteLine(String.Join("\n-- ", s.Value));
            }
        }
    }
}
