using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph G = new Graph();
            Edge a = new Edge("A", Color.Blue);
            Edge b = new Edge("B", Color.Blue);
            Edge c = new Edge("C", Color.Red);
            Edge d = new Edge("D", Color.Blue);
            Edge e = new Edge("E", Color.Red);
            Edge f = new Edge("F", Color.Red);

            a.AddNeighbor(b);
            a.AddNeighbor(c);
            b.AddNeighbor(d);
            b.AddNeighbor(e);
            c.AddNeighbor(e);
            d.AddNeighbor(f);
            e.AddNeighbor(f);


            G.AddEdge(a);
            G.AddEdge(b);
            G.AddEdge(c);
            G.AddEdge(d);
            G.AddEdge(e);
            G.AddEdge(f);

            //BFS(G);

            BFSRed(G);

            PrintGraph(G);

            Console.ReadKey();
        }

        public static void BFS(Graph G)
        {
            int count = G.Edges.Count;

            Queue<Edge> Q = new Queue<Edge>();
            G.Edges[0].Distance = 0;
            G.Edges[0].Scolor = ScanColor.Gray;

            Q.Enqueue(G.Edges[0]);

            while(!(Q.Count == 0))
            {
                Edge u = Q.Dequeue();
                foreach (Edge v in u.neighbors)
                {
                    if (v.Scolor == ScanColor.White)
                    {
                        v.Distance = u.Distance + 1;
                        v.Pie = u;
                        v.Scolor = ScanColor.Gray;
                        Q.Enqueue(v);
                    }
                }
                u.Scolor = ScanColor.Black;
            }
        }

        public static void BFSRed(Graph G)
        {
            int count = G.Edges.Count;

            Queue<Edge> Q = new Queue<Edge>();
            G.Edges[0].Distance = 0;
            G.Edges[0].Scolor = ScanColor.Gray;
            G.Edges[0].RedCount = G.Edges[0].IsRed();

            Q.Enqueue(G.Edges[0]);

            while (!(Q.Count == 0))
            {
                Edge u = Q.Dequeue();
                foreach (Edge v in u.neighbors)
                {
                    int red_count = u.RedCount + v.IsRed();
                    int distance = u.Distance + 1;

                    if (v.Scolor == ScanColor.White)
                    {
                        v.Distance = distance;
                        v.Pie = u;
                        v.Scolor = ScanColor.Gray;
                        v.RedCount = red_count;
                        Q.Enqueue(v);
                    }
                    else if (v.Distance == distance && v.RedCount < red_count)
                    {
                        v.Pie = u;
                        v.RedCount = red_count;
                    }
                }
                u.Scolor = ScanColor.Black;
            }
        }

        public int IsRed(Edge v)
        {
            if (v.Ecolor == Color.Red)
                return 1;
            else
                return 0;
        }

        public static void PrintGraph(Graph G)
        {
            Console.Write("V: | ");
            for (int i = 0; i < G.Edges.Count; i++)
            {
                Console.Write(G.Edges[i].Name + " | ");
            }
            Console.WriteLine();
            Console.Write("D: | ");
            for (int i = 0; i < G.Edges.Count; i++)
            {
                Console.Write(G.Edges[i].Distance + " | ");
            }
            Console.WriteLine();
            Console.Write("P: | ");
            for (int i = 0; i < G.Edges.Count; i++)
            {
                Console.Write((G.Edges[i].Pie != null) ? G.Edges[i].Pie.Name : " ");
                Console.Write(" | ");
            }
        }
    }
}
