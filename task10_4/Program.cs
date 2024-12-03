using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Натуральное число n");

            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            var min = 9;
            int commonCount = 0;
            int remainder;
            int minCount = 0;
            while (n > 0)
            {
            remainder = n % 10;
                if (remainder < min)
                {
                    min = remainder;
                    minCount = commonCount;
                }
            n = (n - remainder)/10;
            commonCount++;
            }

            Console.WriteLine($"Минимальное число: {min}; порядковый номер цифры в числе:{minCount}");
            Console.ReadKey();
        }
    }
}
