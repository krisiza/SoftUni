using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01GenericBoxofString
{
    public class Box<T> where T : IComparable<T>
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

        public int Compare(List<T> list, T element)
        {
            int count = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (element.CompareTo(list[i]) < 0)
                    count++;
            }

            return count;
        }
    }
}
