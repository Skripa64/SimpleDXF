﻿using System;
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
    struct Solid
    {
        public Line first;
        public Line second;
        public Line third;
        public Line fourth;
        public int state;
    }
}
