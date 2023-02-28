using Lesson32.BinTree;

namespace Lesson32
{
    internal class Program
    {
        public static bool EnterCollection(ICollection<int> collection)
        {
            Console.WriteLine("Enter int to add or something else for output:");
            bool parsed = int.TryParse(Console.ReadLine(), out int res);
            if (parsed)
            {
                collection.Add(res);
            }
            return parsed;
        }

        static void Main(string[] args)
        {
            var tree = new BinTreeCollectionWithSumEnumerator();
            while (EnterCollection(tree)) { }

            var prev = 0;
            Console.WriteLine("Sum of current and previous:");
            foreach (var item in tree)
            {
                var sum = prev + item;
                prev = item; 
                Console.WriteLine($"{sum}");
            }
        }
    }
}