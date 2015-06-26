using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace SimpleDXF
{
    class Line:IShape
    {
        double x0;
        double y0;
        double x1;
        double y1;

        public double X0
        {
            set { this.x0 = value; }
        }

        public double Y0
        {
            set { this.y0 = value; }
        }

        public double X1
        {
            set { this.x1 = value; }
        }

        public double Y1
        {
            set { this.y1 = value; }
        }

        void IShape.Draw()
        {
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(x0, y0);
            GL.Vertex2(x1, y1);
            GL.End();
        }

        public Line()
        {
            this.x0 = 0;
            this.y0 = 0;
            this.x1 = 0;
            this.y1 = 0;
        }

        public Line(Line line)
        {
            this.x0 = line.x0;
            this.y0 = line.y0;
            this.x1 = line.x1;
            this.y1 = line.y1;
        }
    }
}
