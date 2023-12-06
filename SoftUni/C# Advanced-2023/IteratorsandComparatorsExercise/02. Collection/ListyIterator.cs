using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
    internal class ListyIterator<T> : IEnumerable<T>
    {
        private const string ExceptionMessage = "Invalid Operation!";
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

        public string Print()
        {
            return ListIterator.Count == 0
            ? throw new InvalidOperationException(ExceptionMessage)
            : $"{ListIterator[index]}";
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < ListIterator.Count; i++)
            {
                yield return ListIterator[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string PrintAll()
        {
            StringBuilder stringBuilder= new StringBuilder();
            foreach(var item in ListIterator) 
            {
                stringBuilder.Append($"{item} ");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
