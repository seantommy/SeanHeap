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
            SeanMinHeap<int> minHeap = new SeanMinHeap<int>();
            SeanMaxHeap<int> maxHeap = new SeanMaxHeap<int>();
            SeanMinMaxHeap<int> minMaxHeap = new SeanMinMaxHeap<int>();
           
            minHeap.Add(3);
            minHeap.Add(7);
            minHeap.Add(2);
            minHeap.Add(9);
            minHeap.Add(-8);
            minHeap.Add(1);
            minHeap.Add(4);
            minHeap.Add(5);

            minHeap.Peak();

            minHeap.Pop();
            minHeap.Pop();


            maxHeap.Add(3);
            maxHeap.Add(7);
            maxHeap.Add(2);
            maxHeap.Add(9);
            maxHeap.Add(8);
            maxHeap.Add(1);
            maxHeap.Add(4);
            maxHeap.Add(5);

            maxHeap.Peak();

            maxHeap.Pop();
            maxHeap.Pop();
            
            
            for(int x = 1; x < 30; x++)
            {
                minMaxHeap.Add(x);
            }

            /*
            for(int y = 29; y > 0; y--)
            {
                minMaxHeap.Add(y);
            }*/

            minMaxHeap.PopMin();
            minMaxHeap.PopMax();
            minMaxHeap.PopMin();
            minMaxHeap.PopMax();
            minMaxHeap.PopMin();
            minMaxHeap.PopMax();
            //minMaxHeap.PopMin();
        }
    }
}
