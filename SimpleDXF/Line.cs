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
    class Line:Shape
    {
        public Line() { }
        public Line(Line line):base(line)
        {

        }

        public override void Draw()
        {
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(x0, y0);
            GL.Vertex2(x1, y1);
            GL.End();
        }
    }
}
