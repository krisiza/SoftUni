using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Library
{
    internal class BookComparator : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            int result = x.Title.CompareTo(y.Title);

            if (result == 0)
            {
                result = y.Year.CompareTo(x.Year);
            }

            return result;
        }
    }
}
