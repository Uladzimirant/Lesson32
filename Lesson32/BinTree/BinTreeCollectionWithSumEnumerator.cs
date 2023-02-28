using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson32.BinTree
{
    public class BinTreeCollectionWithSumEnumerator: ICollection<int>
    {
        internal BinTreeCollection<int> _core = new BinTreeCollection<int>();

        public int Count => ((ICollection<int>)_core).Count;

        public bool IsReadOnly => ((ICollection<int>)_core).IsReadOnly;

        public void Add(int item)
        {
            ((ICollection<int>)_core).Add(item);
        }

        public void Clear()
        {
            ((ICollection<int>)_core).Clear();
        }

        public bool Contains(int item)
        {
            return ((ICollection<int>)_core).Contains(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            ((ICollection<int>)_core).CopyTo(array, arrayIndex);
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)_core).GetEnumerator();
        }

        public bool Remove(int item)
        {
            return ((ICollection<int>)_core).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_core).GetEnumerator();
        }
    }
}
