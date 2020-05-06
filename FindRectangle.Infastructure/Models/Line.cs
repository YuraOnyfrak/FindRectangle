using System;
using System.Collections.Generic;
using System.Text;

namespace FindRectangle.Infastructure.Models
{
    public class Line
    {
        private Point _firstPoint;
        private Point _secondPoint;

        public Line(Point firstPoint, Point secondPoint)
        {
            _firstPoint = firstPoint;
            _secondPoint = secondPoint;
            Distance = GetDistance();
        }

        public Point FirstPoint
        {
            get => _firstPoint;
        }

        public Point SecondPoint
        {
            get => _secondPoint;
        }

        public double Distance { get; private set; }

        private double GetDistance()
        {
            double squareDifferenceX = Math.Pow(this._secondPoint.X - this._firstPoint.X, 2);
            double squareDifferenceY = Math.Pow(this._secondPoint.Y - this._firstPoint.Y, 2);
            return Math.Sqrt(squareDifferenceX + squareDifferenceY);
        }

        public override int GetHashCode()
        {
            return _firstPoint.X * _firstPoint.Y * _secondPoint.X * _secondPoint.Y;
        }

        public override bool Equals(object other)
        {
            if (other is Line)
                return ((Line)other).FirstPoint.Equals(_firstPoint) && ((Line)other).SecondPoint.Equals(_secondPoint) ||
                ((Line)other).SecondPoint.Equals(_firstPoint) && ((Line)other).FirstPoint.Equals(_secondPoint);
            return false;
        }
    }
}
