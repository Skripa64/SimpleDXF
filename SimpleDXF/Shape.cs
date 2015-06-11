using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDXF
{
    abstract class Shape
    {
        protected double x0;
        protected double y0;
        protected double x1;
        protected double y1;
        protected double radius;
        protected double primary_angle;
        protected double secondary_angle;

        public Shape()
        {
        }

        public Shape(Shape shape)
        {
            this.x0 = shape.x0;
            this.y0 = shape.y0;
            this.x1 = shape.x1;
            this.y1 = shape.y1;
            this.radius = shape.radius;
            this.primary_angle = shape.primary_angle;
            this.secondary_angle = shape.secondary_angle;
        }

        public double X0 { get { return x0; } set { x0 = value; } }

        public double Y0 { get { return y0; } set { y0 = value; } }

        public double X1 { get { return x1; } set { x1 = value; } }

        public double Y1 { get { return y1; } set { y1 = value; } }

        public double Radius { get { return radius; } set { radius = value; } }
        public double Primory_angle { get { return primary_angle; } set { primary_angle = value; } }
        public double Secondary_angle { get { return secondary_angle; } set { secondary_angle = value; } }

        public abstract void Draw();
    }
}
