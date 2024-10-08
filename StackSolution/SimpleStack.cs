namespace StackSolution
{
    public class SimpleStack : IStack
    {
        private List<string> _collection;

        public int Size => _collection.Count;
        public string? Top => _collection.LastOrDefault();

        public SimpleStack(params string[] args) => _collection = [.. args];

        public void Add(string item) => _collection.Add(item);

        public string Pop()
        {
            if (_collection.Count == 0)
            {
                throw new InvalidOperationException("Стек пустой!");
            }
            var item = _collection.Last();
            _collection.RemoveAt(Size - 1);
            return item;
        }

        public void Clear() => _collection.Clear();

        public static IStack Concat(params IStack[] args)
        {
            var stack = new SimpleStack();
            foreach (var arg in args)
            {
                var size = arg.Size;
                for (var i = 0; i < size; i++)
                {
                    var item = arg.Pop();
                    stack.Add(item);
                }
            }
            return stack;
        }
    }
}
