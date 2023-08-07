using System;
using System.Collections.Generic;

namespace _05.HTML
{
    /*
SoftUni Article
Some content of the SoftUni article
some comment
more comment
last comment
end of comments
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            string input = Console.ReadLine();

            List<string> comments = new List<string>();

            while(input != "end of comments")
            {
                comments.Add(input);
                input= Console.ReadLine();
            }

            Console.WriteLine("<h1>");
            Console.WriteLine(title);
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine(content);
            Console.WriteLine("</article>");
            foreach(string comment in comments) 
            {
                Console.WriteLine("<div>");
                Console.WriteLine(comment);
                Console.WriteLine("</div>");
            }
        }
    }
}
