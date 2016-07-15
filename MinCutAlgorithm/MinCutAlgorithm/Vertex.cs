using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCutAlgorithm
{
   public class Vertex
    {
        public List<Edge> IncidentEdges { get; set; }

        public string Label { get; set; }

        public Vertex()
        {
            IncidentEdges = new List<Edge>();
        }
    }
}
