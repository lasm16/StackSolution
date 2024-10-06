using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
