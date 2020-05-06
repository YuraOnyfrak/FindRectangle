using System;
using System.Collections.Generic;
using System.Text;

namespace FindRectangle.Infastructure.Models
{
    public class Rectangle
    {
        private Point _firstPoint;
        private Point _secondPoint;
        private Point _thirdPoint;
        private Point _fourthPoint;

        public Point FirstPoint { get => _firstPoint; }
        public Point SecondPoint { get => _secondPoint; }
        public Point ThirdPoint { get => _thirdPoint; }
        public Point FourthPoint { get => _fourthPoint; }

        public Rectangle
            (
            Point firstPoint, Point secondPoint,
            Point thirdPoint, Point fourthPoint
            )
        {
            _firstPoint = firstPoint;
            _secondPoint = secondPoint;
            _thirdPoint = thirdPoint;
            _fourthPoint = fourthPoint;
        }
    }
}
