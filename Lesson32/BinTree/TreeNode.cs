namespace Lesson32.BinTree
{
    public class TreeNode<T> : IComparable<TreeNode<T>> where T : IComparable<T>
    {
        public TreeNode<T>? Left { get; internal set; }
        public TreeNode<T>? Right { get; internal set; }
        public T? Value { get; internal set; }

        public TreeNode(T? value = default, TreeNode<T>? left = null, TreeNode<T>? right = null) { Value = value; Left = left; Right = right; }

        public int CompareTo(TreeNode<T>? other)
        {
            return other == null ? 1 : Value?.CompareTo(other.Value) ?? (other.Value == null ? 1 : 0);
        }
    }
}
