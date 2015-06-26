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
    class Point:IShape
    {
        double x0;
        double y0;

        public double X0
        {
            set { this.x0 = value; }
        }

        public double Y0
        {
            set { this.y0 = value; }
        }

        void IShape.Draw()
        {
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(x0, y0);
            GL.End();
        }

        public Point()
        {
            this.x0 = 0;
            this.y0 = 0;
        }

        public Point(Point point)
        {
            this.x0 = point.x0;
            this.y0 = point.y0;
        }
    }
}
