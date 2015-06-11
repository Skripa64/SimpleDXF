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
    class Point:Shape
    {
        public Point(){}

        public Point(Point point):base(point)
        {

        }
        public override void Draw()
        {
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(x0, y0);
            GL.End();
        }
    }
}
