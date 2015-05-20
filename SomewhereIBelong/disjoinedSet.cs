using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomewhereIBelong
{

    class DisjointSetForest
    {

        private int _nodesCount;
        private int[] _parent;
        private int[] _rank;

        public DisjointSetForest(int nodesCount)
        {
            if (nodesCount < 0) throw new ArgumentException();
            _nodesCount = nodesCount;
            _parent = new int[nodesCount];
            _rank = new int[nodesCount];

            for (int i = 0; i < _nodesCount; i++)
            {
                _parent[i] = i;
                _rank[i] = 0;
            }
        }

        public int count()
        {
            return _nodesCount;
        }

        public bool connected(int firstNode, int secondNode)
        {
            return findSet(firstNode) == findSet(secondNode);
        }

        public void makeSet(int node)
        {
            _rank[node] = 0;
            _parent[node] = node;
        }

        public void union(int firstSet, int secondSet)
        {
            Link(findSet(firstSet), findSet(secondSet));
        }

        public int findSet(int node)
        {
            if (node < 0 || node > _parent.Length) throw new IndexOutOfRangeException();
            if (node != _parent[node])
                _parent[node] = findSet(_parent[node]);
            return _parent[node];
        }

        private void Link(int firstSet, int secondSet)
        {
            if (firstSet == secondSet) return;
            if(_rank[firstSet]>_rank[secondSet])
            {
                _parent[secondSet] = firstSet;
            }
                else {
                    _parent[firstSet] = secondSet;
                    if(_rank[firstSet] == _rank[secondSet])
                    {
                        _rank[secondSet] ++;
                    }
                }
            }
        }
}




