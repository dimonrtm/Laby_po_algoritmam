using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proverka_prostyh_chisel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввведите число");
            int n = 0;
            try
            {
                 n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Вы ввели не число");
                Console.ReadLine();
                return;
            }
            if (n == 2)
            {
                Console.WriteLine("Простое число");
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        Console.WriteLine("Число не является простым");
                        Console.ReadLine();
                        return;
                    }
                }
                Console.WriteLine("Простое число");
            }
            Console.ReadLine();
        }
    }
}
