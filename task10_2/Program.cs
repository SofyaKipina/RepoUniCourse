using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество экзаменов в сессии: ");
            int k;
            if (!TryInputNumber(out k))
            {
                Console.ReadKey();
                return;
            }

            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                Console.WriteLine("Введите балл за экзамен:");

                int grade;
                if (!TryInputNumber(out grade))
                {
                    
                    Console.ReadKey();
                    return;
                }
                sum += grade;
            }

            Console.WriteLine($"Средний балл за все экзамены:{sum/k}");

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
