using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace _07.TheV_Logger
{
    /*
EmilConrad joined The V-Logger
VenomTheDoctor joined The V-Logger
Saffrona joined The V-Logger
Saffrona followed EmilConrad
Saffrona followed VenomTheDoctor
EmilConrad followed VenomTheDoctor
VenomTheDoctor followed VenomTheDoctor
Saffrona followed EmilConrad
Statistics
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, VLogger> vloggers = new Dictionary<string, VLogger>();


            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] arr = input.Split();

                if (input.EndsWith("joined The V-Logger"))
                {
                    string vlogger = arr[0];

                    if (!vloggers.ContainsKey(vlogger))
                    {
                        VLogger logger = new VLogger();
                        logger.Username = vlogger;
                        vloggers.Add(vlogger, logger);
                    }
                }
                else if (input.Contains("followed"))
                {
                    if (vloggers.ContainsKey(arr[0])
                        && vloggers.ContainsKey(arr[2])
                        && arr[0] != arr[2]
                        && !vloggers[arr[0]].Followings.Contains(arr[2]))
                    {
                        vloggers[arr[0]].Followings.Add(arr[2]);
                        vloggers[arr[2]].Followers.Add(arr[0]);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            vloggers = vloggers.OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Followings.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            int counter = 1;

            foreach (var k in vloggers)
            {
                Console.WriteLine($"{counter}. {k.Key} : {k.Value.Followers.Count} followers, {k.Value.Followings.Count} following");

                if (counter == 1)
                {
                    vloggers[k.Key].Followers = vloggers[k.Key].Followers.OrderBy(x => x).ToList();

                    for (int i = 0; i < k.Value.Followers.Count; i++) 
                    {
                        Console.WriteLine($"*  {k.Value.Followers[i]}");
                    }
                }

                counter++;
            }
        }
    }
    public class VLogger
    {
        public VLogger()
        {
            Followers = new List<string>();
            Followings = new List<string>();
        }
        public string Username { get; set; }

        public List<string> Followers { get; set; }

        public List<string> Followings { get; set; }
    }
}