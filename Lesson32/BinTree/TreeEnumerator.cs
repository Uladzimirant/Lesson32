using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace Lesson32.BinTree
{
    public class TreeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private TreeNode<T>? _root;
        private TreeNode<T>? _current;
        private Stack<TreeNode<T>> _stack;
        private bool inited = false;

        public TreeEnumerator(TreeNode<T>? root)
        {
            _root = root;
            Reset();
        }

        public T Current => _stack.TryPeek(out var elem) ? elem.Value : default(T);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        private void ToStackTillNull()
        {
            while (_current != null)
            {
                _stack.Push(_current);
                _current = _current.Left;
            }
        }

        public bool MoveNext()
        {
            if (!inited)
            {
                ToStackTillNull();
                inited = true;
                return _stack.Count > 0;
            }
            if (_current == null)
            {
                if (_stack.Count > 0)
                {
                    var p = _stack.Pop();
                    _current = p.Right;
                    ToStackTillNull();
                };
            }
            return _stack.Count > 0;
        }

        private IEnumerable<TreeNode<T>> Inorder(TreeNode<T>? current)
        {
            if (current != null)
            {
                Inorder(current.Left);
                yield return current;
                Inorder(current.Right);
            }
        }

        public void Reset()
        {
            _stack = new Stack<TreeNode<T>>();
            _current = _root;
        }
    }
}
