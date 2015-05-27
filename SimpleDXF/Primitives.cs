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
    class Primitives
    {
        List<Point> all_Point = new List<Point>();
        List<Line> all_Line = new List<Line>();
        List<Circle> all_Circle = new List<Circle>();
        List<Arc> all_Arc = new List<Arc>();
        List<Solid> all_Solid = new List<Solid>();

        public void Add_Point(Point _point)
        {
            all_Point.Add(_point);
        }

        public void Add_Line(Line _line)
        {
            all_Line.Add(_line);
        }

        public void Add_Circle(Circle _circle)
        {
            all_Circle.Add(_circle);
        }

        public void Add_Arc(Arc _arc)
        {
            all_Arc.Add(_arc);
        }

        public void Add_Solid(Solid _solid)
        {
            all_Solid.Add(_solid);
        }

        private void Draw_Point(Point _point)
        {
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(_point.X0, _point.Y0);
            GL.End();

        }

        private void Draw_Line(Line _line)
        {
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(_line.X0, _line.Y0);
            GL.Vertex2(_line.X1, _line.Y1);
            GL.End();
        }

        private void Draw_Circle(Circle _circle)
        {
            double x0 = _circle.X0;
            double y0 = _circle.Y0;
            double R = _circle.RADIUS;
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

        private void Draw_Arc(Arc _arc)
        {
            double c_x = _arc.X0;
            double c_y = _arc.Y0;
            double radius = _arc.RADIUS;
            double primory_angle = _arc.PRIMORY_ANGLE;
            double secondary_angle = _arc.SECONDARY_ANGLE;
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

        private void Draw_Solid(Solid _solid)
        {
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex2(_solid.first.X0, _solid.first.Y0);
            GL.Vertex2(_solid.first.X1, _solid.first.Y1);
            GL.Vertex2(_solid.second.X0, _solid.second.Y0);
            GL.Vertex2(_solid.second.X1, _solid.second.Y1);
            GL.Vertex2(_solid.third.X0, _solid.third.Y0);
            GL.Vertex2(_solid.third.X1, _solid.third.Y1);
            GL.Vertex2(_solid.fourth.X0, _solid.fourth.Y0);
            GL.Vertex2(_solid.fourth.X1, _solid.fourth.Y1);
            GL.End();
        }

        public void Draw_Primitives()
        {
            foreach (Point _point in all_Point)
            {
                Draw_Point(_point);
            }

            foreach (Line _line in all_Line)
            {
                Draw_Line(_line);

            }

            foreach (Circle _circle in all_Circle)
            {
                Draw_Circle(_circle);
            }

            foreach (Arc _arc in all_Arc)
            {
                Draw_Arc(_arc);
            }

            foreach (Solid _solid in all_Solid)
            {
                Draw_Solid(_solid);
            }
        }

        public void Clear_ALL()
        {
            all_Point.Clear();
            all_Line.Clear();
            all_Circle.Clear();
            all_Arc.Clear();
            all_Solid.Clear();
        }
    }
}
