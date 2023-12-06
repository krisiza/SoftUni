using _3.Raiding.IO.Interfaces;

namespace _3.Raiding.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string text)
         => Console.WriteLine(text);
    }
}
