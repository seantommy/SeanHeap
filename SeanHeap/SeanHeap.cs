using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeanHeap
{
    class SeanHeap<T> where T : IComparable
    {

        private T[] heap;
        public int Size{ get; private set;}

        public SeanHeap() { heap = new T[11]; }
        public SeanHeap(T firstValue) { heap = new T[10]; heap[1] = firstValue; Size++; }

        public void Add(T newValue)
        {
            Size++;
            if (Size == heap.Length - 1)
            {
                T[] newHeap = new T[(heap.Length) * 2];
                for(int x = 1; x < heap.Length; x++)
                {
                    newHeap[x] = heap[x];
                }
                heap = newHeap;
            }

            heap[Size] = newValue;
            SortValue(Size);
        }
        
        private void SortValue(int place)
        {
            if(heap[place].CompareTo(heap[place / 2]) < 0)
            {
                T tmp = heap[place / 2];
                heap[place / 2] = heap[place];
                heap[place] = tmp;
                SortValue(place / 2);
            }
        }

        public T Peak()
        {
            return heap[1];
        }

        public T Pop()
        {
            T min = heap[1];
            Replace(1);
            Size--;
            return min;
        }

        private void Replace(int index)
        {
            if (index * 2 > Size)
            {
                heap[index] = heap[Size];
                heap[Size] = default(T);
            }
            else if (index * 2 == Size)
            {
                heap[index] = heap[index * 2];
                heap[index * 2] = default(T);
            }
            else
            {
                if (heap[index * 2].CompareTo(heap[index * 2 + 1]) < 0)
                {
                    heap[index] = heap[index * 2];
                    Replace(index * 2);
                }
                else
                {
                    heap[index] = heap[index * 2 + 1];
                    Replace(index * 2 + 1);
                }
            }
        }
    }
}
