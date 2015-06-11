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
    class Circle:Shape
    {
        public Circle() { }

        public Circle(Circle circle):base(circle)
        {

        }

        public override void Draw()
        {
            double R = radius;
            double min = x0 - R;
            double max = x0 + R;
            double x = min;
            double y;

            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.LineLoop);
            while (x < max)
            {
                y = y0 + Math.Sqrt(R * R - Math.Pow((x - x0), 2));
                GL.Vertex2(x, y);
                x += 0.001;
            }
            while (x > min)
            {
                y = y0 - Math.Sqrt(R * R - Math.Pow((x - x0), 2));
                GL.Vertex2(x, y);
                x -= 0.001;
            }
            GL.End();
        }
    }
}
