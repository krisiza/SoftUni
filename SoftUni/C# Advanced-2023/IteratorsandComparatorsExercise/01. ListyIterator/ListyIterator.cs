using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
    internal class ListyIterator<T>
    {
        private List<T> ListIterator;
        int index = 0;

        public ListyIterator(List<T> listIterator)
        {
            ListIterator = listIterator;
        }

        public bool Move()
        {
            index++;
            if (index > ListIterator.Count - 1)
            {
                index--;
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool HasNext()
        {

            if (index >= ListIterator.Count - 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Print()
        {
            if (ListIterator.Count > 0)
                Console.WriteLine(ListIterator[index]);
            else
                Console.WriteLine("Invalid Operation!");
        }
    }
}
