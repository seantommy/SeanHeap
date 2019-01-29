using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeanHeap
{
    class SeanMinHeap<T> where T : IComparable
    {

        private T[] heap;
        public int Size{ get; private set;}

        public SeanMinHeap() { heap = new T[11]; }
        public SeanMinHeap(T firstValue) { heap = new T[11]; heap[1] = firstValue; Size++; }

        /// <summary>
        /// Adds a new value to the heap and sorts it into place.
        /// </summary>
        /// <param name="newValue">The value to be added to the heap.</param>
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
        
        private void SortValue(int index)
        {
            if(heap[index].CompareTo(heap[index / 2]) < 0 && index / 2 != 0) //we don't want to use heap[0]
            {
                T tmp = heap[index / 2];
                heap[index / 2] = heap[index];
                heap[index] = tmp;
                SortValue(index / 2);
            }
        }

        /// <summary>
        /// Returns the smallest value in the heap.
        /// </summary>
        /// <returns></returns>
        public T Peak()
        {
            if (Size == 0)
            {
                return default(T);
            }

            return heap[1];
        }

        /// <summary>
        /// Removes the smallest value in the heap and returns it.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (Size == 0)
            {
                return default(T);
            }

            T min = heap[1];
            Replace(1);
            Size--;
            return min;
        }

        private void Replace(int index)
        {
            if (index * 2 >= Size)
            {
                heap[index] = heap[Size];
                heap[Size] = default(T);
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
