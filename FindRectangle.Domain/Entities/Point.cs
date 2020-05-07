using FindRectangle.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindRectangle.Domain.Entities
{
    public class Point : IEntity
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public PointGroup PointGroup { get; set; }
  }
}
