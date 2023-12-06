using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01GenericBoxofString
{
    internal class Box<T>
    {
        public T TProperty { get; set; }

        public List<T> Values { get; set; }
        public override string ToString()
        {
            var type = typeof(T);
            return type.ToString();
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            (Values[secondIndex], Values[firstIndex]) = (Values[firstIndex], Values[secondIndex]);
        }
    }
}
