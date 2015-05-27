using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDXF
{
    struct Circle
    {
        private double x0;
        private double y0;
        private double radius;

        public double X0
        {
            get
            {
                return x0;
            }
            set
            {
                x0 = value;
            }
        }

        public double Y0
        {
            get
            {
                return y0;
            }
            set
            {
                y0 = value;
            }
        }

        public double RADIUS
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
    }
}
