namespace StackSolution
{
    public interface IStack
    {
        public int Size { get; }
        public string? Top { get; }

        public void Add(string item);
        public string? Pop();
        public void Clear();
    }
}
