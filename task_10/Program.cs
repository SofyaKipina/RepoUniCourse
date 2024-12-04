using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число n");
            int n;

            if (!TryInputNumber(out n))
            {
                Console.ReadKey();
                return;
            }

            var sum = 0;

            for (int i = n; i <= 2 * n; i++)
            {
                sum = sum + i * i;
            }
            Console.WriteLine($"Сумма n^2 + (n+1)^2 + (n+2)^2 +...+ (2*n)^2 = {sum}");

            Console.ReadKey();
        }

        static bool TryInputNumber(out int number)
        {
            number = 0;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }
            return true;
        }
    }
}
