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
    class Circle:IShape
    {
        double x0;
        double y0;
        double radius;

        public double X0
        {
            set { this.x0 = value; }
        }

        public double Y0
        {
            set { this.y0 = value; }
        }

        public double RADIUS
        {
            set { this.radius = value; }
        }

        void IShape.Draw()
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

        public Circle()
        {
            this.x0 = 0;
            this.y0 = 0;
            this.radius = 0;
        }

        public Circle(Circle circle)
        {
            this.x0 = circle.x0;
            this.y0 = circle.y0;
            this.radius = circle.radius;
        }
    }
}
