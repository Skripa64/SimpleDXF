using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDXF
{
    struct Arc
    {
        private double x0;
        private double y0;
        private double radius;
        private double primary_angle;
        private double secondary_angle;

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

        public double PRIMORY_ANGLE
        {
            get
            {
                return primary_angle;
            }
            set
            {
                primary_angle = value;
            }
        }

        public double SECONDARY_ANGLE
        {
            get
            {
                return secondary_angle;
            }
            set
            {
                secondary_angle = value;
            }
        }
    }
}
