using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeanHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            SeanHeap<int> heap = new SeanHeap<int>();

            heap.Add(3);
            heap.Add(7);
            heap.Add(2);
            heap.Add(9);
            heap.Add(8);
            heap.Add(1);
            heap.Add(4);
            heap.Add(5);

            heap.Peak();

            heap.Pop();
            heap.Pop();

        }
    }
}
