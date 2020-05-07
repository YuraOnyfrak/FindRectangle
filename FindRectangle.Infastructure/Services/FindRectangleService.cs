using FindRectangle.Application.Common.Interfaces;
using FindRectangle.Infastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindRectangle.Infastructure.Services
{
   public class FindRectangleService : IFindRectangleService
   {
        public int GetCountRectangle(int[,] inputData)
        {
            List<Point> points = MapArrayToPointCollection(inputData);

            List<Rectangle> rectangles = new List<Rectangle>();
            IEnumerable<Line> lines = CombinePointInLines(points);

            //group line by distance
            IEnumerable<IGrouping<double, Line>> linesGroupedByDistance 
                = lines.Distinct().GroupBy(s => s.Distance);

            Line firstLine;
            Line secondLine;

            foreach (var groupLines in linesGroupedByDistance)
            {                   
                for (int i = 0; i < groupLines.ToList().Count(); i++)
                {
                    for (int j = i + 1; j < groupLines.ToList().Count(); j++)
                    {
                            if (CheckUsedLine(rectangles, groupLines.ElementAt(i), groupLines.ElementAt(j)))
                                continue;

                            //first line which join two other line with equal length
                            firstLine = new Line
                            (
                                new Point { X = groupLines.ElementAt(i).FirstPoint.X, Y = groupLines.ElementAt(i).FirstPoint.Y },
                                new Point { X = groupLines.ElementAt(j).FirstPoint.X, Y = groupLines.ElementAt(j).FirstPoint.Y }                                                                
                            );

                            
                            //second line which join two other line with equal length
                            secondLine = new Line
                            (                               
                                new Point { X = groupLines.ElementAt(i).SecondPoint.X, Y = groupLines.ElementAt(i).SecondPoint.Y },
                                new Point { X = groupLines.ElementAt(j).SecondPoint.X, Y = groupLines.ElementAt(j).SecondPoint.Y }
                            );

                            if (firstLine.Distance != secondLine.Distance)
                                continue;

                            //РїРµСЂРµРІС–СЂСЏС”РјРѕ С‡Рё РґР°РЅР° С„С–РіСѓСЂР° РЅРµ С” РєРІР°РґСЂР°С‚РѕРј
                            if (firstLine.Distance == secondLine.Distance && secondLine.Distance == groupLines.ElementAt(i).Distance)
                                continue;

                            if (!PythagoreanTheoreme(groupLines.ElementAt(i), firstLine) &&
                                !PythagoreanTheoreme(groupLines.ElementAt(j), secondLine))
                                continue;

                            rectangles.Add(new Rectangle
                                (firstLine.FirstPoint, firstLine.SecondPoint,
                                 secondLine.FirstPoint, secondLine.SecondPoint));                           
                    }
                }
            }

            return rectangles.Count();
        }

        private List<Point> MapArrayToPointCollection(int[,] inputData)
        {
            List<Point> points = new List<Point>();

            int rows = inputData.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
              points.Add(new Point()
              {
                X = inputData[i, 0],
                Y = inputData[i, 1]
              });
            }

            return points;
        }


        /// <summary>
        /// Combine point to line
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private IEnumerable<Line> CombinePointInLines(List<Point> points)
        {
            List<Line> lines = new List<Line>();

            for (int i = 0; i < points.Count(); i++)
            {
                for (int j = i + 1; j < points.Count(); j++)
                {
                    if (lines.Any(s => s.FirstPoint.X == points[j].X && s.SecondPoint.Y == points[j].Y ||
                                       s.SecondPoint.X == points[j].X && s.FirstPoint.Y == points[j].Y))
                        continue;

                    lines.Add(new Line
                     (
                        new Point { X = points[i].X, Y = points[i].Y },
                        new Point { X = points[j].X, Y = points[j].Y }
                     ));
                }
            }

            return lines;
        }

        private bool PythagoreanTheoreme(Line firstLine, Line secondLine)
        {
           //нypotenuse
            Line thirdLine = new Line
            (
                new Point { X = firstLine.SecondPoint.X, Y = firstLine.SecondPoint.Y },
                new Point { X = secondLine.SecondPoint.X, Y = secondLine.SecondPoint.Y }
            );

            double summa = Math.Pow(firstLine.Distance, 2) + Math.Pow(secondLine.Distance, 2);

            double squareHypotenuse = Math.Pow(thirdLine.Distance, 2);

            if (Math.Round(summa, 0) == Math.Round(squareHypotenuse, 0))
                  return true;

            return false;
        }

        private bool CheckUsedLine(IEnumerable<Rectangle> rectangles, Line firstLine, Line secondLine)
        {
           return  rectangles.Select(s =>
             new List<Point>
             {
                    s.FirstPoint, s.SecondPoint, s.ThirdPoint, s.FourthPoint
             })
             .Where(s => s.Intersect(new List<Point>
             {
                    secondLine.FirstPoint, secondLine.SecondPoint, firstLine.FirstPoint, firstLine.SecondPoint
             }).Any())
             .Any();
        }
   }
}

