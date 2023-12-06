using _04.WildFarm.IO.Interfaces;

namespace _04.WildFarm.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string text)
            => Console.WriteLine(text);
    }
}
