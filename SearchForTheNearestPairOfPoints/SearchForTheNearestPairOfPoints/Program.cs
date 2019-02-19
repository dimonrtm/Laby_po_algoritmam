using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForTheNearestPairOfPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iters = { 5, 10, 20, 30,100,1000 };
            List<Point> pointsst = init(1000);
            PairPoint ppst = brutforce(1000, pointsst);
            Console.WriteLine("Алгоритм грубой силы");
            Console.WriteLine("Время работы алгоритма");
            Console.WriteLine("Первая точка");
            Console.WriteLine("(" + ppst.Point1.X + "," + ppst.Point1.Y + ")");
            Console.WriteLine("Вторая точка");
            Console.WriteLine("(" + ppst.Point2.X + "," + ppst.Point2.Y + ")");
            Console.WriteLine("Расстояние между точками");
            Console.WriteLine(ppst.Distance());
            Console.ReadLine();
            DivideAndConquer dacst = new DivideAndConquer(1000, pointsst);
            PairPoint pp1st = dacst.MyClosestDivide();
            Console.WriteLine("Алгоритм декомпозиции");
            Console.WriteLine("Время работы алгоритма");
            Console.WriteLine("Первая точка");
            Console.WriteLine("(" + pp1st.Point1.X + "," + pp1st.Point1.Y + ")");
            Console.WriteLine("Вторая точка");
            Console.WriteLine("(" + pp1st.Point2.X + "," + pp1st.Point2.Y + ")");
            Console.WriteLine("Расстояние между точками");
            Console.WriteLine(pp1st.Distance());
            Console.ReadLine();
            foreach (int i in iters)
            {
                for (int j = 0; j < 100; j++)
                {
                    //List<Point> points = new List<Point>();
                    //Point point1 = new Point();
                    //point1.X = 3;
                    //point1.Y = 1;
                    //points.Add(point1);
                    //Point point2 = new Point();
                    //point2.X = 4;
                    //point2.Y = 2;
                    //points.Add(point2);
                    //Point point3 = new Point();
                    //point3.X = 5;
                    //point3.Y = 6;
                    //points.Add(point3);
                    //Point point4 = new Point();
                    //point4.X = 7;
                    //point4.Y = 8;
                    //points.Add(point4);
                    //Point point5 = new Point();
                    //point5.X = 6;
                    //point5.Y = 4;
                    //points.Add(point5);
                    List<Point> points = init(i);
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    PairPoint pp = brutforce(i, points);
                    timer.Stop();
                    Console.WriteLine("Алгоритм грубой силы");
                    long time = timer.ElapsedMilliseconds;
                    Console.WriteLine("Время работы алгоритма");
                    Console.WriteLine(time);
                    Console.WriteLine("Первая точка");
                    Console.WriteLine("(" + pp.Point1.X + "," + pp.Point1.Y + ")");
                    Console.WriteLine("Вторая точка");
                    Console.WriteLine("(" + pp.Point2.X + "," + pp.Point2.Y + ")");
                    Console.WriteLine("Расстояние между точками");
                    Console.WriteLine(pp.Distance());
                    DivideAndConquer dac = new DivideAndConquer(i, points);
                    timer.Reset();
                    timer.Start();
                    PairPoint pp1 = dac.MyClosestDivide();
                    timer.Stop();
                    long time2 = timer.ElapsedMilliseconds;
                    Console.WriteLine("Алгоритм декомпозиции");
                    Console.WriteLine("Время работы алгоритма");
                    Console.WriteLine(time2);
                    Console.WriteLine("Первая точка");
                    Console.WriteLine("(" + pp1.Point1.X + "," + pp1.Point1.Y + ")");
                    Console.WriteLine("Вторая точка");
                    Console.WriteLine("(" + pp1.Point2.X + "," + pp1.Point2.Y + ")");
                    Console.WriteLine("Расстояние между точками");
                    Console.WriteLine(pp1.Distance());
                }
                Console.ReadLine();
            }
        }

        static List<Point> init(int N)
        {
            Random rand = new Random();
            List<Point> points = new List<Point>();
            for(int i=0;i< N;i++)
            {
                Point point = new Point();
                point.X = rand.NextDouble();
                point.Y = rand.NextDouble();
                points.Add(point);
            }
            return points;
        }

       public static PairPoint brutforce(int N,List<Point> points)
        {
            PairPoint pp = new PairPoint();
            double distance = Double.MaxValue;
            for(int i=0;i< N;i++)
            {
                for(int j=0;j< N;j++)
                {
                    if(i==j)
                    {
                        continue;
                    }
                    PairPoint temp = new PairPoint();
                    temp.Point1 = points[i];
                    temp.Point2 = points[j];
                    if(temp.Distance()<distance)
                    {
                        distance = temp.Distance();
                        pp = temp;
                    }
                    //double currDistance = Math.Sqrt(Math.Pow(points[i].X - points[j].X, 2) + Math.Pow(points[i].Y - points[j].Y, 2));
                    //if(currDistance<distance)
                    //{
                    //    distance = currDistance;
                    //    pp.Point1 = points[i];
                    //    pp.Point2 = points[j];
                    //}
                }
            }
            return pp;
        }
    }
}
