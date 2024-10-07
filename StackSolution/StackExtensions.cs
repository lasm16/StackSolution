namespace StackSolution
{
    public static class StackExtensions
    {
        public static void Merge(this IStack stack1, IStack stack2)
        {
            var stackSize = stack2.Size;
            for (int i = 0; i < stackSize; i++)
            {
                var item = stack2.Pop();
                stack1.Add(item);
            }
        }
    }
}
