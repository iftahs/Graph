using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    

    class Graph
    {
        public List<Edge> Edges { get; set; }

        public Graph()
        {
            Edges = new List<Edge>();
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }
    }
}
