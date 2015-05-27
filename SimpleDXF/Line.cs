using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDXF
{
    struct Line
    {
        private double x0;
        private double y0;
        private double x1;
        private double y1;

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

        public double X1
        {
            get
            {
                return x1;
            }
            set
            {
                x1 = value;
            }
        }

        public double Y1
        {
            get
            {
                return y1;
            }
            set
            {
                y1 = value;
            }
        }
    }
}
