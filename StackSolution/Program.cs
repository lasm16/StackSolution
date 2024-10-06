namespace StackSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // просто выбрать нужный тип стека

            //var stack = new SimpleStack();
            var stack = new CoolStack();

            Exercise1(stack);
            Exercise2(stack);
            Exercise3(stack);
            Exercise4(stack);
        }

        private static void Exercise1(IStack? stack)
        {
            if (stack is SimpleStack)
            {
                stack = new SimpleStack("a", "b", "c");
            }
            else
            {
                stack = new CoolStack("a", "b", "c");
            }
            // size = 3, Top = 'c'
            Console.WriteLine($"size = {stack.Size}, Top = '{stack.Top}'");
            var deleted = stack.Pop();
            // Извлек верхний элемент 'c' Size = 2
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {stack.Size}");
            stack.Add("d");
            // size = 3, Top = 'd'
            Console.WriteLine($"size = {stack.Size}, Top = '{stack.Top}'");
            stack.Pop();
            stack.Pop();
            stack.Pop();
            // size = 0, Top = null
            Console.WriteLine($"size = {stack.Size}, Top = {(stack.Top == null ? "null" : stack.Top)}");
            try
            {
                stack.Pop();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Сработало исключение!");
            }
        }

        private static void Exercise2(IStack? stack)
        {

            if (stack is SimpleStack)
            {
                var s = new SimpleStack("a", "b", "c");
                s.Merge(new SimpleStack("1", "2", "3"));
            }
            else
            {
                var s = new CoolStack("a", "b", "c");
                s.Merge(new CoolStack("1", "2", "3"));
            }
            // в стеке s теперь элементы - "a", "b", "c", "3", "2", "1" <- верхний
        }

        private static void Exercise3(IStack? stack)
        {

            if (stack is SimpleStack)
            {
                stack = SimpleStack.Concat(new SimpleStack("a", "b", "c"), new SimpleStack("1", "2", "3"), new SimpleStack("А", "Б", "В"));
            }
            else
            {
                stack = CoolStack.Concat(new CoolStack("a", "b", "c"), new CoolStack("1", "2", "3"), new CoolStack("А", "Б", "В"));
            }
            // в стеке s теперь элементы - "c", "b", "a" "3", "2", "1", "В", "Б", "А" <- верхний}
        }

        private static void Exercise4(IStack? stack)
        {

            if (stack is SimpleStack)
            {
                stack = new SimpleStack("a", "b", "c");
            }
            else
            {
                stack = new CoolStack("a", "b", "c");
            }
            stack.Clear();
            // стек очищен от всех элементов
        }
    }
}
