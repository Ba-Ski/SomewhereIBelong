using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomewhereIBelong
{
    class GraphGenerator
    {
        public Graph generateWeightedGraph(int verticesCount, int edgesCount, int weightMin, int weightMax)
        {
            Graph graph = new Graph(verticesCount);
            bool[,] vertciesMap = new bool[verticesCount, verticesCount];

            Random rand = new Random();
            int firstVertexsId, secondVertexsId;

            for (int i = 1; i < verticesCount; i++)
            {
                firstVertexsId = i;
                secondVertexsId = rand.Next(0, i - 1);

                GraphEdge edge = new GraphEdge(firstVertexsId, secondVertexsId,
                    rand.Next(weightMin, weightMax + 1));

                graph.addEdge(edge);
                vertciesMap[firstVertexsId, secondVertexsId] = true;
                vertciesMap[secondVertexsId, firstVertexsId] = true;
            }

            for (int i = 0; i < edgesCount - verticesCount + 1; i++)
            {

                firstVertexsId = rand.Next(0, verticesCount);
                secondVertexsId = rand.Next(0, verticesCount);

                while (firstVertexsId == secondVertexsId ||
                    vertciesMap[firstVertexsId, secondVertexsId] == true ||
                    vertciesMap[secondVertexsId, firstVertexsId] == true)
                {
                    firstVertexsId = rand.Next(0, verticesCount);
                    secondVertexsId = rand.Next(0, verticesCount);
                }

                GraphEdge edge = new GraphEdge(firstVertexsId, secondVertexsId, rand.Next(weightMin, weightMax + 1));

                graph.addEdge(edge);
            }

            return graph;
        }
    }

}

