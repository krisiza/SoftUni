using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
    internal class Stone : IComparable<Stone>
    {
        public int Number { get; set; }

        public int CompareTo(Stone? other)
        {
           if(Number < other.Number)
                return 1;
           else
                return -1;
        }
    }
}
