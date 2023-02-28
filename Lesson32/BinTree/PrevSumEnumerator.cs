using System.Collections;

namespace Lesson32.BinTree
{
    public class PrevSumEnumerator : IEnumerator<int>
    {
        private bool _isFirst;
        private TreeEnumerator<int> prev, current;

        public PrevSumEnumerator(BinTreeCollectionWithSumEnumerator tree)
        {
            _isFirst = true;
            prev = new TreeEnumerator<int>(tree._core._root);
            current = new TreeEnumerator<int>(tree._core._root);
        }

        public int Current => (_isFirst ? 0 : prev.Current) + current.Current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            prev.Dispose();
            current.Dispose();
        }

        public bool MoveNext()
        {
            if (_isFirst) _isFirst = false; else prev.MoveNext();
            return current.MoveNext();
        }

        public void Reset()
        {
            _isFirst = true;
            prev.Reset();
            current.Reset();
        }
    }
}
