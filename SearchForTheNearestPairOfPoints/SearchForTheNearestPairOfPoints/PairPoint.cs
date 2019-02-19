using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForTheNearestPairOfPoints
{
    class PairPoint
    {
        private Point point1;
        private Point point2;

        public Point Point1
        {
            get
            {
                return point1;
            }

            set
            {
                point1 = value;
            }
        }

        public Point Point2
        {
            get
            {
                return point2;
            }

            set
            {
                point2 = value;
            }
        }
        public double Distance()
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }
    }
}
