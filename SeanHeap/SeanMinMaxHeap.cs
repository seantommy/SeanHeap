using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeanHeap
{
    class SeanMinMaxHeap<T> where T : IComparable
    {
        private T[] heap;
        public int Size { get; private set; }

        public SeanMinMaxHeap() { heap = new T[11]; }
        public SeanMinMaxHeap(T firstValue) { heap = new T[11]; heap[1] = firstValue; Size++; }

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
                for (int x = 1; x < heap.Length; x++)
                {
                    newHeap[x] = heap[x];
                }
                heap = newHeap;
            }

            heap[Size] = newValue;
            SortValue(Size);
        }

        //I think this works.
        private void SortValue(int index)
        {
            int layer = Convert.ToInt32(Math.Truncate(Math.Log(index, 2))); //Math.* is hard
            if (layer == 0)
            {
                return;
            }
            else if (layer % 2 == 0) //if it's an even-numbered layer, it's a min layer
            {
                SortMin(index);
            }
            else //otherwise, it's a max layer
            {
                SortMax(index);
            } 
        }

        private void SortMin(int index)
        {
            if (heap[index].CompareTo(heap[index / 4]) < 0 && index / 4 != 0) //we don't want to use heap[0]
            {
                T tmp = heap[index / 4];
                heap[index / 4] = heap[index];
                heap[index] = tmp;
                SortValue(index / 4);
            }else if(heap[index].CompareTo(heap[index / 2]) > 0 && index / 2 != 0)
            {
                T tmp = heap[index / 2];
                heap[index / 2] = heap[index];
                heap[index] = tmp;
                SortValue(index / 2);
            }
        }

        private void SortMax(int index)
        {
            if (heap[index].CompareTo(heap[index / 4]) > 0 && index / 4 != 0) //we don't want to use heap[0]
            {
                T tmp = heap[index / 4];
                heap[index / 4] = heap[index];
                heap[index] = tmp;
                SortValue(index / 4);
            }else if(heap[index].CompareTo(heap[index/2]) < 0 && index / 2 != 0)
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
        public T PeakMin()
        {
            if (Size == 0)
            {
                return default(T);
            }

            return heap[1];
        }

        /// <summary>
        /// Returns the largest value in the heap.
        /// </summary>
        /// <returns></returns>
        public T PeakMax()
        {
            if (Size == 0)
            {
                return default(T);
            }else if(Size == 1)
            {
                return heap[1];
            }else if(Size == 2)
            {
                return heap[2];
            }
            else
            {
                if (heap[2].CompareTo(heap[3]) > 0)
                {
                    return heap[2];
                }
                else
                {
                    return heap[3];
                }
            }
        }

        /// <summary>
        /// Removes the smallest value in the heap and returns it.
        /// </summary>
        /// <returns></returns>
        public T PopMin()
        {
            if(Size == 0)
            {
                return default(T);
            }

            T min = heap[1];
            Replace(1);
            Size--;
            return min;
        }

        /// <summary>
        /// Removes the largest value in the heap and returns it.
        /// </summary>
        /// <returns></returns>
        public T PopMax()
        {
            T max;

            if (Size == 0)
            {
                return default(T);
            }else if(Size == 1)
            {
                max = heap[1];
                heap[1] = default(T);
                
            }else if(Size == 2)
            {
                max = heap[2];
                heap[2] = default(T);
            }
            else
            {
                if (heap[2].CompareTo(heap[3]) > 0)
                {
                    max = heap[2];
                    Replace(2);
                }
                else
                {
                    max = heap[3];
                    Replace(3);
                }
            }

            Size--;
            return max;
        }

        //must adjust logic from Min to MinMax
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
