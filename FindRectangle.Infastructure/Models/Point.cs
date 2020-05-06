using System;
using System.Collections.Generic;
using System.Text;

namespace FindRectangle.Infastructure.Models
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override int GetHashCode()
        {
            return X * Y;
        }

        public override bool Equals(object other)
        {
            if (other is Point)
                return ((Point)other).X == this.X && ((Point)other).Y == this.Y;
            return false;
        }
    }
}
