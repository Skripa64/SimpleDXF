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
    class Arc:IShape
    {
        double x0;
        double y0;
        double radius;
        double primary_angle;
        double secondary_angle;

        public double X0
        {
            set { this.x0 = value; }
        }

        public double Y0
        {
            set { this.Y0 = value; }
        }

        public double RADIUS
        {
            set { this.radius = value; }
        }

        public double PRIMARY_ANGLE
        {
            set { this.primary_angle = value; }
        }

        public double SECONDARY_ANGLE
        {
            set { this.secondary_angle = value; }
        }

        void IShape.Draw()
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

        public Arc()
        {
            this.x0 = 0;
            this.y0 = 0;
            this.radius = 0;
            this.primary_angle = 0;
            this.secondary_angle = 0;
        }

        public Arc(Arc arc)
        {
            this.x0 = arc.x0;
            this.y0 = arc.y0;
            this.radius = arc.radius;
            this.primary_angle = arc.primary_angle;
            this.secondary_angle = arc.secondary_angle;
        }
    }
}
