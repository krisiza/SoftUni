using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
    internal class Person: IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person? other)
        {
            int result = Name.CompareTo(other.Name);

            if(result== 0) 
            {
                result = Age.CompareTo(other.Age);

                if(result== 0) 
                {
                    result = Town.CompareTo(other.Town);
                }
            }

            return result;

        }

        public int CompareTo(object? obj)
        {
            int result = Name.CompareTo(obj);

            if (result == 0)
            {
                result = Age.CompareTo(obj);

                if (result == 0)
                {
                    result = Town.CompareTo(obj);
                }
            }

            return result;
        }
    }
}
