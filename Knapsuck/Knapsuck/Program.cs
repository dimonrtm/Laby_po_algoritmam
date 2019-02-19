using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Knapsuck
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iters = { 5, 10, 20,30 };
            foreach (int i in iters)
            {
                int N = i;
                int weight = i * 2;
                List<double> profits1 = new List<double>();
                List<double> profits2 = new List<double>();
                for (int j = 0; j < 100; j++)
                {
                    Item[] arr = Init(N);
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    BranchAndBound bab = new BranchAndBound(N, weight, arr);
                    timer.Stop();
                    int profit = bab.knapsack();
                    DateTime second = DateTime.Now;
                    long time = timer.ElapsedMilliseconds;
                    Console.WriteLine("Время выполнения метода ветвей и границ");
                    Console.WriteLine(time);
                    profits1.Add(profit);
                    Stopwatch timer1 = new Stopwatch();
                    GreedyAlgoritm ga = new GreedyAlgoritm(N, weight, arr);
                    timer1.Start();
                    double profit1 = ga.knapsack();
                    timer1.Stop();
                    second = DateTime.Now;
                    time = timer1.ElapsedMilliseconds;
                    Console.WriteLine("Время выполнения жадного алгоритма");
                    Console.WriteLine(time);
                    profits2.Add(profit1);
                }
                double average1 = profits1.Average();
                double average2 = profits2.Average();
                Console.WriteLine("Средняя найвысшая стоимость предметов в рюкзаке методом ветвей и границ");
                Console.WriteLine(average1);
                Console.WriteLine("Средняя наивысшая стоимость предметов в рюкзаке жадный алгоритм");
                Console.WriteLine(average2);
                double averageRate = average1 / average2;
                Console.WriteLine("Средняя оценка работы алгоритма");
                Console.WriteLine(averageRate);
                Console.WriteLine("Нажмите любую клавишу");
                Console.ReadLine();
            }
            //Item[] arr = new Item[5];
            //arr[0] = new Item();
            //arr[0].Weight = 2;
            //arr[0].Value = 40;
            //arr[1] = new Item();
            //arr[1].Weight = 3.14;
            //arr[1].Value = 50;
            //arr[2] = new Item();
            //arr[2].Weight = 1.98;
            //arr[2].Value = 100;
            //arr[3] = new Item();
            //arr[3].Weight = 5;
            //arr[3].Value = 95;
            //arr[4] = new Item();
            //arr[4].Weight = 3;
            //arr[4].Value = 30;
            //BranchAndBound bab = new BranchAndBound(5, 10, arr);
            //int profit = bab.knapsack();
            //Console.WriteLine(profit);
            //GreedyAlgoritm ga = new GreedyAlgoritm(5, 10, arr);
            //double profit1 = ga.knapsack();
            //Console.WriteLine(profit1);
        }
    

    static private Item[] Init(int N)
    {
        Item[] arrItem = new Item[N];
        Random rand = new Random();
        for (int i = 0; i < arrItem.Length; i++)
        {
            Item item = new Item();
            item.Value = rand.Next(100);
            item.Weight = rand.NextDouble() * N / 2;
            arrItem[i] = item;
        }
        return arrItem;
    }
}
}

