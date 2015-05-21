using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomewhereIBelong
{
    static class HeapSort<T> where T :IComparable<T>
    {
        public static void sort(ref T[] source)
        {
            int N = source.Length;
            for (int i = (N / 2) - 1; i >= 0; i--)
                siftDown(ref source, i, N);

            while (N >= 1)
            {
                exch(ref source, 0, --N);
                siftDown(ref source, 0, N);
            }

        }

        private static void siftDown(ref T[] source, int pos, int N)
        {
            while(2*pos+1<N)
            {
                int j = 2 * pos + 1;
                if (j < N - 1 && less(ref source, j, j + 1)) j++;
                if (!less(ref source, pos, j)) break;
                exch(ref source, pos, j);
                pos = j;
            }
            
        }

        private static bool less(ref T[] source, int i, int j)
        {
            return source[i].CompareTo(source[j]) < 0;
        }

        private static void exch(ref T[] source, int i, int j)
        {
            var buffer = source[i];
            source[i] = source[j];
            source[j] = buffer;
        }

    }
}
