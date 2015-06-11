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
    class Arc:Shape
    {
        public Arc() { }

        public Arc(Arc arc):base(arc)
        {

        }

        public override void Draw()
        {
            double c_x = this.x0;
            double c_y = this.y0;
            double radius = this.radius;
            double primory_angle = this.primary_angle;
            double secondary_angle = this.secondary_angle;
            double x0 = radius * Math.Cos(primory_angle * Math.PI / 180) + c_x;
            double y0 = radius * Math.Sin(primory_angle * Math.PI / 180) + c_y;
            double x;
            double y;
            double step = 1 / radius;
            primory_angle += step;

            if (primory_angle <= secondary_angle)
            {
                while (primory_angle <= secondary_angle)
                {
                    x = radius * Math.Cos(primory_angle * Math.PI / 180) + c_x;
                    y = radius * Math.Sin(primory_angle * Math.PI / 180) + c_y;
                    GL.Color3(Color.Black);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Vertex2(x0, y0);
                    GL.Vertex2(x, y);
                    GL.End();

                    x0 = x;
                    y0 = y;
                    primory_angle += step;
                }
            }
            else
            {
                while (primory_angle < 0)
                {
                    x = radius * Math.Cos(primory_angle * Math.PI / 180) + c_x;
                    y = radius * Math.Sin(primory_angle * Math.PI / 180) + c_y;
                    GL.Color3(Color.Black);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Vertex2(x0, y0);
                    GL.Vertex2(x, y);
                    GL.End();

                    x0 = x;
                    y0 = y;
                    primory_angle += step;
                }
                primory_angle = 0;
                while (primory_angle < secondary_angle)
                {
                    x = radius * Math.Cos(primory_angle * Math.PI / 180) + c_x;
                    y = radius * Math.Sin(primory_angle * Math.PI / 180) + c_y;
                    GL.Color3(Color.Black);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Vertex2(x0, y0);
                    GL.Vertex2(x, y);
                    GL.End();

                    x0 = x;
                    y0 = y;
                    primory_angle += step;
                }
            }
        }
    }
}
