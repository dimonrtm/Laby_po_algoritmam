using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForTheNearestPairOfPoints
{
    class DivideAndConquer
    {
        private int N;
        private List<Point> points;

        public DivideAndConquer(int N,List<Point> points)
        {
            this.N = N;
            this.points = points;
        }
        public PairPoint MyClosestDivide()
        {
            return MyClosestRec(points.OrderBy(p=>p.X).ToList());
        }

        private PairPoint MyClosestRec(List<Point> sortedByX)
        {
            int count = sortedByX.Count;
            if(count<=4)
            {
                return Program.brutforce(count, sortedByX);
            }
            var leftByX = sortedByX.Take(count / 2).ToList();
            var leftResult = MyClosestRec(leftByX);
            var rightByX = sortedByX.Skip(count / 2).ToList();
            var rightResult = MyClosestRec(rightByX);
            var result = rightResult.Distance() < leftResult.Distance() ? rightResult : leftResult;
            var midX = leftByX.Last().X;
            var bandWidth = result.Distance();
            var inBandByX = sortedByX.Where(p => Math.Abs(midX - p.X) <= bandWidth);
            var inBandByY = inBandByX.OrderBy(p => p.Y).ToArray();
            int last = inBandByY.Length - 1;
            for(int i=0;i< last;i++)
            {
                var point1 = inBandByY[i];
                for(int j=i+1;j<= last;j++)
                {
                    var point2 = inBandByY[j];
                    if((point1.Y-point2.Y)>=result.Distance())
                    {
                        break;
                    }
                    PairPoint temp = new PairPoint();
                    temp.Point1 = point1;
                    temp.Point2 = point2;
                    if(temp.Distance()<result.Distance())
                    {
                        result = temp;
                    }
                }
            }
            return result;
        }
    }
}
