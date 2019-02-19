using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_algoritmy
{
    class Program
    {
        private static void ArrInit(int n,int [] l,int [] arr,bool [] arrBool)
        {
            for(int i=1;i<= n;i++)
            {
                l[i - 1] = i;
                arr[i - 1] = i;
                arrBool[i - 1] = true;
            }
        }
//полу
        private static int [] indexOfMatrix(int [,] l,int n)
        {
            int[] indexies = new int[2];
            indexies[0] = -1;
            indexies[1] = -1;
            for(int i=0;i<l.GetLength(0);i++)
            {
                for(int j=0;j<l.GetLength(1);j++)
                {
                    if(l[i,j]==n)
                    {
                        indexies[0] = i;
                        indexies[1] = j;
                        break;
                    }
                }
            }
            return indexies;
        }

        private static double Distance(int n,int [,] l,int [] arr)
        {
            int m = (int)Math.Sqrt(n);
            int[,] matrix = new int[m, m];
            int ind = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = arr[ind];
                    ind++;
                }
            }
            int sum = 0;
            for(int i=0;i< m;i++)
            {
                for(int j=0;j< m;j++)
                {
                    int dist = 0;
                    int[] indexies = indexOfMatrix(l, matrix[i, j]);
                    while(indexies[0]!=i)
                    {
                        if(indexies[0]>i)
                        {
                            indexies[0]--;
                            dist++;
                        }
                        else if(indexies[0]<i)
                        {
                            indexies[0]++;
                            dist++;
                        }
                    }
                    while(indexies[1]!=j)
                    {
                        if (indexies[1] > j)
                        {
                            indexies[1]--;
                            dist++;
                        }
                        else if (indexies[1] < j)
                        {
                            indexies[1]++;
                            dist++;
                        }
                    }
                    sum += dist;
                }
            }
            double average = (double)sum / n;
            return average;
        }

        private static void MOAndDispersiya(int n,List<double> l)
        {
            double mo = l.Average();
            Console.WriteLine("Для " + Math.Sqrt(n) + " математическое ожидание равно " + mo);
            double sum = 0;
            foreach(double x in l)
            {
                sum+= Math.Pow(x - mo, 2);
            }
            double disp = sum / l.Count;
            Console.WriteLine("Для " + Math.Sqrt(n) + " дисперсия равна " + disp);
        }

        static void Main(string[] args)
        {
            int[] numbers = { 4, 9 };
            foreach(int n in numbers)
            {
                List<double> averages = new List<double>();
                int [] l = new int[n];
                int[] arr = new int[n];
                bool[] arrBool = new bool[n];
                ArrInit(n, l, arr, arrBool);
                int m = (int)Math.Sqrt(n);
                int[,] et = new int[m, m];
                int ind = 0;
                for(int i=0;i< m;i++)
                {
                    for(int j=0;j< m;j++)
                    {
                        et[i, j] = l[ind];
                        ind++;
                    }
                }
                int k = 0;
                while(true)
                {
                    double average = Distance(n, et, arr);
                    averages.Add(average);
                    int index = -1;
                    for(int i=0;i<arr.Length;i++)
                    {
                      if ((i!=0&&arrBool[i]==true&&arr[i]>arr[i-1])&&((index==-1)||(arr[i]>arr[index])))
                        {
                            index = i;
                        }
                      if((i!=arr.Length-1&&arrBool[i]==false&&arr[i]>arr[i+1])&&(index==-1||arr[i]>arr[index]))
                        {
                            index = i;
                        }
                    }
                    if(index==-1)
                    {
                        break;
                    }
                    int tmp = 0;
                    bool tmpbool = false;
                    if(arrBool[index]==true)
                    {
                        tmp = arr[index];
                        tmpbool = arrBool[index];
                        arr[index] = arr[index - 1];
                        arrBool[index] = arrBool[index - 1];
                        arr[index - 1] = tmp;
                        arrBool[index - 1] = tmpbool;
                        index = index - 1;
                    }
                    else
                    {
                        tmp = arr[index];
                        tmpbool = arrBool[index];
                        arr[index] = arr[index + 1];
                        arrBool[index] = arrBool[index + 1];
                        arr[index + 1] = tmp;
                        arrBool[index + 1] = tmpbool;
                        index = index + 1;
                    }
                    for(int i=0;i<arr.Length;i++)
                    {
                        if(arr[i]>arr[index])
                        {
                            if(arrBool[i]==true)
                            {
                                arrBool[i] = false;
                            }
                            else
                            {
                                arrBool[i] = true;
                            }
                        }
                    }
                    k++;
                }
                Console.WriteLine(averages.Count);
                MOAndDispersiya(n, averages);
            }
            Console.Read(); 
        }
    }
}
