using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
    internal class Lake : IEnumerable<int>
    {
        private List<Stone> stones = new List<Stone>();

        public IEnumerator<int> GetEnumerator()
        {
            int i = 0;

            for (; i < stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return stones[i].Number;

                }
            }

            i--;

            for (; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    yield return stones[i].Number;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Stone stone)
        {
            stones.Add(stone);
        }
    }
}
