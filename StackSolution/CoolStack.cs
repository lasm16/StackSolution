namespace StackSolution
{
    public class CoolStack : IStack
    {
        private int _size = 0;
        private StackItem? _stackItem;

        public int Size => _size;
        public string? Top
        {
            get
            {
                if (_stackItem == null)
                {
                    return null;
                }
                return _stackItem.Current;
            }
        }

        public CoolStack(params string[] args)
        {
            foreach (var arg in args)
            {
                Add(arg);
            }
        }

        public void Add(string item)
        {
            var stackItem = new StackItem(item);
            stackItem.Previous = _stackItem;
            _stackItem = stackItem;
            _size++;
        }

        public string Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Стек пустой!");
            }

            var item = _stackItem!.Current;
            if (_size == 1)
            {
                _stackItem = null;
                _size--;
                return item;
            }
            _stackItem.Current = _stackItem.Previous!.Current;
            _stackItem.Previous = _stackItem.Previous.Previous;
            _size--;
            return item;
        }

        public void Clear()
        {
            _size = 0;
            _stackItem = null;
        }

        public static IStack Concat(params IStack[] args)
        {
            var stack = new CoolStack();
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

        class StackItem
        {
            public string Current { get; set; }
            public StackItem? Previous { get; set; }

            public StackItem(string element)
            {
                Current = element;
            }
        }
    }
}
