using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson32.BinTree
{
    public class TestT : BinTreeCollection<int>
    {
        public void Test()
        {
            _root = new TreeNode<int>(1, new TreeNode<int>(2, new TreeNode<int>(4), new TreeNode<int>(5)), new TreeNode<int>(3));
        }
    }


    public class BinTreeCollection<T> : ICollection<T> where T : IComparable<T>
    {
        public TreeNode<T>? _root;

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _root = InsertRec(_root, new TreeNode<T>(item));
            Count++;
        }

        private static TreeNode<T> InsertRec(TreeNode<T>? current, TreeNode<T> inserting)
        {
            if (current == null)
            {
                current = inserting;
                return current;
            }

            if (inserting.CompareTo(current) < 0)
            {
                current.Left = InsertRec(current.Left, inserting);
            }
            else if (inserting.CompareTo(current) > 0)
            {
                current.Right = InsertRec(current.Right, inserting);
            }

            return current;
        }

        public bool Remove(T item)
        {
            _root = RemoveRec(_root, item, out bool found);
            return found;
        }

        private TreeNode<T>? RemoveRec(TreeNode<T>? current, T? toDelete, out bool found)
        {
            if (current == null) { found = false; return current; }

            if (toDelete.CompareTo(current.Value) < 0)
            {
                current.Left = RemoveRec(current.Left, toDelete, out found);
            }
            else if (toDelete.CompareTo(current.Value) > 0)
            {
                current.Right = RemoveRec(current.Right, toDelete, out found);
            }
            else
            {
                if (current.Left == null) { found = true; return current.Right; }
                else if (current.Right == null) { found = true; return current.Left; }

                current.Value = minValue(current.Right);
                current.Right = RemoveRec(current.Right, current.Value, out found);
            }
            return current;
        }

        private T? minValue(TreeNode<T>? current)
        {
            T? min = current!.Value;
            while (current.Left != null)
            {
                min = current.Left.Value;
                current = current.Left;
            }
            return min;
        }


        public void Clear()
        {
            _root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var elem in this) {
                if (elem.CompareTo(item) == 0) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var elem in this)
            {
                array[arrayIndex++] = elem;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new TreeEnumerator<T>(_root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
