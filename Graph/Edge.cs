using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public enum ScanColor { White, Gray, Black }
    public enum Color { Red, Blue}

    public class Edge
    {
        public List<Edge> neighbors;
        public ScanColor Scolor { get; set; }
        public Edge Pie { get; set; }
        public Color Ecolor { get; set; }
        public int Distance { get; set; }
        public string Name { get; set; }
        public int RedCount { get; set; }

        public Edge(string name, Color color)
        {
            Ecolor = color;
            Name = name;
            neighbors = new List<Edge>();
            Scolor = ScanColor.White;
            Distance = -1;
            RedCount = -1;
        }

        public void AddNeighbor(Edge n)
        {
            neighbors.Add(n);
        }

        public int IsRed()
        {
            return (Ecolor == Color.Red) ? 1 : 0;
        }
    };
}
