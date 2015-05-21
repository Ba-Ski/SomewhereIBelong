using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomewhereIBelong
{
    class KruskalMST : IMST
    {
        public int weight { get; private set; }
        List<GraphEdge> _mst;

        public KruskalMST(Graph graph)
        {
            weight = 0;
            _mst = new List<GraphEdge>(graph.vertciesCount());
            
            MST(graph);
        }
        public void MST(Graph graph)
        {

            DisjointSetForest dsf = new DisjointSetForest(graph.vertciesCount());

            GraphEdge[] edges = graph.edges();
            HeapSort<GraphEdge>.sort(ref edges);

            for (int i = 0; i < edges.Length; i++)
            {
                GraphEdge edge = edges[i];
                int v = edge.either(), w = edge.other(v);
                if (!dsf.connected(v, w))
                {
                    _mst.Add(edge);
                    dsf.union(v, w);
                    weight += edge.weight;
                }

            }
            
        }

        public IEnumerable<GraphEdge> edges()
        {
            return _mst;
        }        

    }
}
