namespace StackSolution
{
    public class SimpleStack : IStack
    {
        private List<string> _collection;

        public int Size => _collection.Count;

        public string? Top
        {
            get
            {
                try
                {
                    return _collection.Last();
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
        }

        public SimpleStack(params string[] args) => _collection = [.. args];

        public void Add(string item) => _collection.Add(item);

        public string Pop()
        {
            if (_collection.Count == 0)
            {
                throw new InvalidOperationException("Стек пустой!");
            }
            var item = _collection.Last();
            _collection.Remove(item);
            return item;
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public static SimpleStack Concat(params SimpleStack[] args) // Как можно этот метод вынести в интерфейс?
        {
            var stack = new SimpleStack();
            // Как-то можно избежать двойной цикл?
            foreach (var item in args)
            {
                var size = item.Size;
                for (var i = 0; i < size; i++)
                {
                    var deleted = item.Pop();
                    stack.Add(deleted);
                }
            }
            return stack;
        }
    }
}
