using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_kommivoyajora
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iters = { 5, 10, 20 };
            foreach (int i in iters)
            {
                if (i == 20)
                {
                    double[,] graph = InitGraph(i);
                    BranchAndBound bab = new BranchAndBound(i, graph);
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    bab.TSP();
                    timer.Stop();
                    int[] path = bab.FinalPath;
                    double res = bab.FinalRes;
                    long time = timer.ElapsedMilliseconds;
                    Console.WriteLine("Время работы метода ветвей и границ");
                    Console.WriteLine(time);
                    Console.WriteLine("Путь");
                    foreach (int vert in path)
                    {
                        Console.Write(vert + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Вес пути");
                    Console.WriteLine(res);
                    timer.Reset();
                    APPROX_TSP approx = new APPROX_TSP(i, graph);
                    timer.Start();
                    List<Vertex> cicle = approx.TSP();
                    timer.Stop();
                    long time1 = timer.ElapsedMilliseconds;
                    Console.WriteLine("Время работы аппроксимирующего алгоритма");
                    Console.WriteLine(time1);
                    double result = 0;
                    Console.WriteLine("Путь");
                    for (int j = 1; j < cicle.Count; j++)
                    {
                        Console.Write(cicle[j - 1].Number + " ");
                        result += graph[cicle[j - 1].Number, cicle[j].Number];
                    }
                    Console.Write(cicle[cicle.Count - 1].Number);
                    Console.WriteLine();
                    Console.WriteLine("Вес пути");
                    double rate = res / result;
                    Console.WriteLine(result);
                    Console.WriteLine("Оценка качества");
                    Console.WriteLine(rate);
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadLine();
                }
                else
                {
                    List<double> results1 = new List<double>();
                    List<double> results2 = new List<double>();
                    for(int j=0;j<100;j++)
                    {
                        double[,] graph = InitGraph(i);
                        BranchAndBound bab = new BranchAndBound(i, graph);
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        bab.TSP();
                        timer.Stop();
                        int[] path = bab.FinalPath;
                        double res = bab.FinalRes;
                        long time = timer.ElapsedMilliseconds;
                        Console.WriteLine("Время работы метода ветвей и границ");
                        Console.WriteLine(time);
                        Console.WriteLine("Путь");
                        foreach (int vert in path)
                        {
                            Console.Write(vert + " ");
                        }
                        Console.WriteLine();
                        APPROX_TSP approx = new APPROX_TSP(i, graph);
                        timer.Reset();
                        timer.Start();
                        List<Vertex> cicle = approx.TSP();
                        timer.Stop();
                        DateTime second1 = DateTime.Now;
                        long time1 = timer.ElapsedMilliseconds;
                        Console.WriteLine("Время работы аппроксимирующего алгоритма");
                        Console.WriteLine(time1);
                        double result = 0;
                        Console.WriteLine("Путь");
                        for (int k = 1; k < cicle.Count; k++)
                        {
                            Console.Write(cicle[k - 1].Number + " ");
                            result += graph[cicle[k - 1].Number, cicle[k].Number];
                        }
                        Console.Write(cicle[cicle.Count - 1].Number);
                        results1.Add(res);
                        results2.Add(result);
                    }
                    double averageRes = results1.Average();
                    double averageResult = results2.Average();
                    Console.WriteLine("Средний результат работы метода ветвей и границ");
                    Console.WriteLine(averageRes);
                    Console.WriteLine("Средний результат аппроксимирующего алгоритма");
                    Console.WriteLine(averageResult);
                    Console.WriteLine("Средняя оценка качества работы алгоритма");
                    double averageRate = averageRes / averageResult;
                    Console.WriteLine(averageRate);
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadLine();
                }
            }
            int[] iters2 = { 50, 100, 500, 1000 };
            foreach(int i in iters2)
            {
                double[,] graph = InitGraph(i);
                APPROX_TSP approx = new APPROX_TSP(i, graph);
                Stopwatch timer = new Stopwatch();
                timer.Start();
                List<Vertex> cicle = approx.TSP();
                timer.Stop();
                long time1 = timer.ElapsedMilliseconds;
                Console.WriteLine("Время работы аппроксимирующего алгоритма");
                Console.WriteLine(time1);
                double result = 0;
                Console.WriteLine("Путь");
                for (int j = 1; j < cicle.Count; j++)
                {
                    Console.Write(cicle[j - 1].Number + " ");
                    result += graph[cicle[j - 1].Number, cicle[j].Number];
                }
                Console.Write(cicle[cicle.Count - 1].Number);
                Console.WriteLine();
                Console.WriteLine("Вес пути");
                Console.WriteLine(result);
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadLine();
            }
            }  

        static double [,] InitGraph(int n)
        {
            Vertex_Graph[] vertex = new Vertex_Graph[n];
            double[,] matrix = new double[n, n];
            Random rand = new Random();
            for(int i=0;i< n;i++)
            {
                Vertex_Graph vert = new Vertex_Graph();
                vert.X = rand.NextDouble();
                vert.Y = rand.NextDouble();
                vertex[i] = vert;
            }
            for(int i=0;i< n;i++)
            {
                for(int j=0;j< n;j++)
                {
                    if(i==j)
                    {
                        matrix[i, j] = double.PositiveInfinity;
                    }
                    else
                    {
                        matrix[i, j] = Math.Sqrt(Math.Pow(vertex[i].X - vertex[j].X, 2) + Math.Pow(vertex[i].Y - vertex[j].Y,2));
                    }
                }
            }
            return matrix;
        }
    }
    class Vertex_Graph
    {
        private double x;
        private double y;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }
}
