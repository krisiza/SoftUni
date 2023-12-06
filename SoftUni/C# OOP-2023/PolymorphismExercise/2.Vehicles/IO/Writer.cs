using _2.Vehicles.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Vehicles.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string text)
            => Console.WriteLine(text);
    }
}
