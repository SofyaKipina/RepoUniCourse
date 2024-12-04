using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double product = 1;
            double n = 0;
            int count = 0;
            do
            {
                Console.WriteLine("Введите очередной член последовательности");
                if (!TryInputNumber(out n))
                {
                    Console.ReadKey();
                    return;
                }

                if (n > 0) 
                { 
                product *= n;
                count++;
                }

            } while (n != 0);
            double geometricMean = Math.Pow(product, 1.0 / count);
            Console.WriteLine($"Среднее геометрическое равно {geometricMean}");

            Console.ReadKey();
        }

        static bool TryInputNumber(out double number)
        {
            number = 0;
            if (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }
            return true;
        }
    }
}
