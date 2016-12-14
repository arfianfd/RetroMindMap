using RetroMindMap.Shapes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RetroMindMap.Tools
{
    public class LineTool : Button, ITool
    {
        private ICanvas canvas;
        private LineSegment lineSegment;
        private Vertex startingObject, endingObject;
        public Cursor iniCursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public LineTool()
        {
            this.Name = "Stateful Line tool";
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lineSegment = new LineSegment(new Point(e.X, e.Y));
                lineSegment.Endpoint = new Point(e.X, e.Y);
                canvas.AddDrawingObject(lineSegment);
                if (canvas.GetObjectAt(e.X, e.Y) is Vertex)
                {
                    startingObject = (Vertex)canvas.GetObjectAt(e.X, e.Y);
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.lineSegment != null)
                {
                    lineSegment.Endpoint = new Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.lineSegment != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point P = new Point();
                    lineSegment.Endpoint = new Point(e.X, e.Y);
                    lineSegment.Select();

                    if (canvas.GetObjectAt(e.X, e.Y) is Vertex)
                    {
                        endingObject = (Vertex)canvas.GetObjectAt(e.X, e.Y);
                    }

                    if (startingObject != null)
                    {
                        P = startingObject.GetIntersectionPoint(lineSegment.Startpoint, lineSegment.Endpoint);
                        //startingObject.Subscribe(lineSegment);
                        lineSegment.AddVertex(startingObject);
                        lineSegment.Startpoint = new Point(P.X, P.Y);
                    }
                    if (endingObject != null)
                    {
                        P = endingObject.GetIntersectionPoint(lineSegment.Startpoint, lineSegment.Endpoint);
                        //endingObject.Subscribe(lineSegment);
                        lineSegment.AddVertex(endingObject);
                        lineSegment.Endpoint = new Point(P.X, P.Y);
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.lineSegment);
                }
            }
        }
        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }
    }
}
