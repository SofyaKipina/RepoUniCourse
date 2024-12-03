using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число m:");
            int m;

            if (!TryInputNumber(out m))
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите натуральное число n:");
            int n;

            if (!TryInputNumber(out n))
            {
                Console.ReadKey();
                return;
            }

            int min;
            if (n<=m) min = n;    
            else min = m;
            Console.WriteLine("Все взаимно простые числа с m и n:");

            for (int i = 1; i <= min; i++)
            {
                if (GCD(m, i) == 1 && GCD(n, i) == 1)
                    Console.WriteLine(i);
            }

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
        static int GCD(int a, int b)
        {
            while (b!=0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
