using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCutAlgorithm
{
    public class AdjacencyList
    {
        public List<Vertex> ListOfVertices { get; set; }

        public List<Edge> ListOfEdges { get; set; }


        public AdjacencyList()
        {
            ListOfVertices = new List<Vertex>();
            ListOfEdges = new List<Edge>();
        }
        }
}
