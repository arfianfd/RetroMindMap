using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroMindMap
{
    public abstract class Vertex: DrawingObject, IObservable
    {
        private List<Edge> edges;
        public Vertex()
        {
            edges = new List<Edge>();
        }

        public void BroadcastUpdate(int x, int y)
        {
            foreach(var edge in edges)
            {
                edge.Update(this, x, y);
            }
        }
        public void Subscribe(IObserver O)
        {
            edges.Add((Edge)O);
        }

        public void Unsubscribe(IObserver O)
        {
            edges.Remove((Edge)O);
        }
    }
}
