using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
    internal class Stack<T> : IEnumerable<T>
    {
        private List<T> CustomStack = new();
        public IEnumerator<T> GetEnumerator()
        {
            if (CustomStack.Any())
            {
                for (int i = 0; i < CustomStack.Count; i++)
                {
                    yield return CustomStack[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Push(params T[] items)
        {
            foreach (T item in items)
            {
                CustomStack.Insert(0, item);
            }
        }
        public T Pop()
        {
            if (CustomStack.Any())
            {
                T temp = CustomStack[0];
                CustomStack.RemoveAt(0);
                return temp;
            }

            Console.WriteLine("No elements");
            return default;
        }
    }
}
