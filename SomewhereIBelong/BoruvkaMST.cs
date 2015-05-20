using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomewhereIBelong
{
	class BoruvkaMST : IMST
	{
		public int weight { get; private set; }
		private List<GraphEdge> _mst;

		public BoruvkaMST(Graph graph)
		{
			weight = 0;
			_mst = new List<GraphEdge>();
			
			MakeMST(graph);
		}

		private  void MakeMST(Graph graph)
		{
			
			DisjointSetForest dsf = new DisjointSetForest(graph.vertciesCount());
			
			while( _mst.Count() < graph.vertciesCount()-1)
			{
				GraphEdge[] closest = new GraphEdge[graph.vertciesCount()];
				foreach (var edge in graph.edges())
				{
					int v = edge.either(), w = edge.other(v);
					int i = dsf.findSet(v), j = dsf.findSet(w);
					if(i==j) continue;
					if(closest[i] == null || less(edge, closest[i])) closest[i] = edge;
					if(closest[j] == null || less(edge, closest[j])) closest[j] = edge;
				}

				for (int i = 0; i < graph.vertciesCount(); i++)
				{
					GraphEdge e = closest[i];
					if(e!=null)
					{
						int v  = e.either(), w = e.other(v);
						if(!dsf.connected(v,w))
						{
							_mst.Add(e);
							weight+=e.weight;
                            dsf.union(v, w);
						}
					}
				}

			}

		}

		private bool less(GraphEdge e, GraphEdge f)
		{
			return e.weight < f.weight;
		}

		public IEnumerable<GraphEdge> edges()
		{
			return _mst;
		}

	}
}
