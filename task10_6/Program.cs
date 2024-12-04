using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m;
            Console.WriteLine("Натуральное число m");

            if (!int.TryParse(Console.ReadLine(), out m) || m < 1)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }
            
            FindCombinations(m);
            Console.ReadKey();
        }

        static void FindCombinations(int m)
        {
            for (int count5 = 0; count5 <= m / 5; count5++)
            {
                for (int count2 = 0; count2 <= (m - count5 * 5) / 2; count2++)
                {
                    int count1 = m - (count5 * 5 + count2 * 2);
                    if (count1 >= 0)
                    {
                        Console.WriteLine($"{count5} гирь по 5 кг, {count2} гирь по 2 кг, {count1} гирь по 1 кг");
                    }
                }             
            }

        }
    }
}
