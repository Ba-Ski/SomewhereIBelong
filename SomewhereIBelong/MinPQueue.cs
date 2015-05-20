using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomewhereIBelong
{
    class MinPQueue<T> where T : IComparable<T>
    {
        private List<T> _pg;
        private int _size;
        private const int _d = 2;

        public MinPQueue(int count)
        {
            _size = 0;
            _pg = new List<T>(_size);
        }

        public MinPQueue()
        {
            _size = 0;
            _pg = new List<T>();
        }

        public MinPQueue(T[] source)
        {
            _pg = new List<T>();
            foreach (var item in source)
            {
                insert(item);
            }
        }

        public void insert(T item)
        {
            _pg.Add(item);
            _size++;
            siftUp(_size - 1);
        }

        public T extractMin()
        {
            if (_size == 0) throw new ApplicationException("is empty");
            var minNode = _pg[0];
            var lastNode = _pg[_size - 1];
            _pg.Remove(_pg[_size - 1]);
            _size--;
            if (!isEmpty())
            {
                _pg[0] = lastNode;
                siftDown(0);
            }
            return minNode;
        }

        public T min()
        {
            if (!isEmpty()) return _pg[0];
            else throw new ApplicationException("is empty");
        }

        public bool isEmpty()
        {
            return _size == 0;
        }

        private void siftDown(int pos)
        {

            T insertedNode = _pg[pos];
            int nextChild = minChild(pos);

            while (nextChild != 0 && _pg[nextChild].CompareTo(insertedNode) < 0)
            {
                _pg[pos] = _pg[nextChild];
                pos = nextChild;
                nextChild = minChild(pos);
            }

            _pg[pos] = insertedNode;

        }


        private void siftUp(int pos)
        {
            T changedNode = _pg[pos];
            int parentNodeIndex = parent(pos);

            while (pos != 0 && _pg[parentNodeIndex].CompareTo(changedNode) > 0)
            {
                _pg[pos] = _pg[parentNodeIndex];
                pos = parentNodeIndex;
                parentNodeIndex = parent(pos);
            }

            _pg[pos] = changedNode;
        }

        private int minChild(int pos)
        {
            int fChild, lChild;
            T minValueNode;
            int minNodeIndex;

            fChild = firstChild(pos);
            if (fChild == 0) return 0;
            lChild = lastChild(pos);
            minValueNode = _pg[fChild];
            minNodeIndex = fChild;

            for (int chi = fChild + 1; chi <= lChild; chi++)
            {
                if (_pg[chi].CompareTo(minValueNode) < 0)
                {
                    minValueNode = _pg[chi];
                    minNodeIndex = chi;
                }
            }

            return minNodeIndex;
        }

        private int firstChild(int pos)
        {
            int index = pos * _d + 1;
            return index >= _size ? 0 : index;
        }

        private int lastChild(int pos)
        {
            int fChi = firstChild(pos);
            if (fChi == 0) return 0;
            int lChi = fChi + _d - 1;
            return lChi < _size ? lChi : _size - 1;
        }

        private int parent(int pos)
        {
            int index = pos / _d;
            if (pos % _d == 0 && index != 0)
                return index - 1;
            return index;
        }
    }
}

