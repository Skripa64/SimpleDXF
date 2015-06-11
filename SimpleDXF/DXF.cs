using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleDXF
{
    class DXF
    {
        List<Shape> Shapes = new List<Shape>();

        private enum primitive {NON, POINT, LINE, CIRCLE, ARC, SOLID, MTEXT };
        primitive type_primitive;
        private enum coordinate {NON, x0, y0, x1, y1, radius, primary_angle, secondary_angle, drawing_direction, text };
        coordinate type_coordinate;
        private bool next_is_coordinate;

        Point _point = new Point();
        Line _line = new Line();
        Circle _circle = new Circle();
        Arc _arc = new Arc();
        //Solid _solid;

        public void Read(string input)
        {
            Type_Primitive(input);
            if(next_is_coordinate)
            {
                switch(type_primitive)
                {
                    case primitive.POINT:
                        Read_Point(input);
                        break;
                    case primitive.LINE:
                        Read_Line(input);
                        break;
                    case primitive.CIRCLE:
                        Read_Circle(input);
                        break;
                    case primitive.ARC:
                        Read_Arc(input);
                        break;
                    case primitive.SOLID:
                        //Read_Solid(input);
                        break;
                    case primitive.MTEXT:
                        //Read_MText(input);
                        break;
                    default:
                        break;
                }
                
            }
            Type_Coordinate(input);
        }

        private void Type_Primitive(string str)
        {
            switch(str)
            {
                case "POINT":
                    type_primitive = primitive.POINT;
                    break;
                case "LINE":
                    type_primitive = primitive.LINE;
                    break;
                case "CIRCLE":
                    type_primitive = primitive.CIRCLE;
                    break;
                case "ARC":
                    type_primitive = primitive.ARC;
                    break;
                case "SOLID":
                    type_primitive = primitive.SOLID;
                    break;
                case "MTEXT":
                    type_primitive = primitive.MTEXT;
                    break;
                default:
                    break;
            }
        }

        private void Type_Coordinate(string str)
        {
            switch(str)
            {
                case "10":
                    next_is_coordinate = true;
                    type_coordinate = coordinate.x0;
                    break;
                case "20":
                    next_is_coordinate = true;
                    type_coordinate = coordinate.y0;
                    break;
                case "11":
                    next_is_coordinate = true;
                    type_coordinate = coordinate.x1;
                    break;
                case "21":
                    next_is_coordinate = true;
                    type_coordinate = coordinate.y1;
                    break;
                case "40":
                    next_is_coordinate = true;
                    type_coordinate = coordinate.radius;
                    break;
                case "50":
                    next_is_coordinate = true;
                    type_coordinate = coordinate.primary_angle;
                    break;
                case "51":
                    next_is_coordinate = true;
                    type_coordinate = coordinate.secondary_angle;
                    break;
                case "1":
                    next_is_coordinate = true;
                    type_coordinate = coordinate.text;
                    break;
                case "72":
                    next_is_coordinate = true;
                    type_coordinate = coordinate.drawing_direction;
                    break;
                default:
                    next_is_coordinate = false;
                    break;
            }
        }

        private void Read_Point(string str)
        {
            switch (type_coordinate)
            {
                case coordinate.x0:
                    _point.X0 = Convert.ToDouble(str);
                    break;
                case coordinate.y0:
                    _point.Y0 = Convert.ToDouble(str);
                    Shapes.Add(new Point(_point));
                    type_coordinate = coordinate.NON;
                    break;
                default:
                    break;
            }
        }

        private void Read_Line(string str)
        {
            switch (type_coordinate)
            {
                case coordinate.x0:
                    _line.X0 = Convert.ToDouble(str);
                    break;
                case coordinate.y0:
                    _line.Y0 = Convert.ToDouble(str);
                    break;
                case coordinate.x1:
                    _line.X1 = Convert.ToDouble(str);
                    break;
                case coordinate.y1:
                    _line.Y1 = Convert.ToDouble(str);
                    Shapes.Add(new Line(_line));
                   type_coordinate = coordinate.NON;
                    break;
                default:
                    break;
            }
        }

        private void Read_Circle(string str)
        {
            switch (type_coordinate)
            {
                case coordinate.x0:
                    _circle.X0 = Convert.ToDouble(str);
                    break;
                case coordinate.y0:
                    _circle.Y0 = Convert.ToDouble(str);
                    break;
                case coordinate.radius:
                    _circle.Radius = Convert.ToDouble(str);
                    Shapes.Add(new Circle(_circle));
                    type_coordinate = coordinate.NON;
                    break;
                default:
                    break;
            }
        }

        private void Read_Arc(string str)
        {
            switch (type_coordinate)
            {
                case coordinate.x0:
                    _arc.X0 = Convert.ToDouble(str);
                    break;
                case coordinate.y0:
                    _arc.Y0 = Convert.ToDouble(str);
                    break;
                case coordinate.radius:
                    _arc.Radius = Convert.ToDouble(str);
                    break;
                case coordinate.primary_angle:
                    _arc.Primory_angle = Convert.ToDouble(str);
                    break;
                case coordinate.secondary_angle:
                    _arc.Secondary_angle = Convert.ToDouble(str);
                    Shapes.Add(new Arc(_arc));
                    type_coordinate = coordinate.NON;
                    break;
                default:
                    break;
            }
        }

        /*
        private void Read_Solid(string str)
        {
             switch (type_coordinate)
             {
                case coordinate.x0:
                     _line.X0 = Convert.ToDouble(str);
                     break;
                case coordinate.y0:
                     _line.Y0 = Convert.ToDouble(str);
                     break;
                case coordinate.x1:
                     _line.X1 = Convert.ToDouble(str);
                     break;
                case coordinate.y1:
                     _line.Y1 = Convert.ToDouble(str);
                     if (_solid.state == 0)
                     {
                        _solid.first = _line;
                     }
                     if (_solid.state == 1)
                     {
                        _solid.second = _line;
                     }
                     if (_solid.state == 2)
                     {
                        _solid.third = _line;
                     }
                     if (_solid.state == 3)
                     {
                        _solid.fourth = _line;
                     }
                     _solid.state++;
                     if (_solid.state >= 4)
                      {
                         _solid.state = 0;
                         type_coordinate = coordinate.NON;
                     }
                     break;
                 default:
                     break;
             }
       }

                private void Read_MText(string str)
                {
                    switch (type_coordinate)
                    {
                        case coordinate.x0:
                            break;
                        case coordinate.y0:
                            break;
                        case coordinate.drawing_direction:
                            break;
                        case coordinate.text:
                            break;
                        default:
                            break;
                    }
                }
        */
        public void Draw()
        {
            foreach(Shape shape in Shapes)
            {
                shape.Draw();
            }
        }

        public void Clear()
        {
            Shapes.Clear();
        }
    }
}
