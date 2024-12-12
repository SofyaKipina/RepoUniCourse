using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_11_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число элементов массива");
            int n;

            if (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            var numbers = new double[n];
            var v = Math.Truncate(Math.PI * Math.Pow(10, numbers.Length - 1));
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                numbers[i] = v % 10;
                v = Math.Floor(v / 10);
            }


            PrintArray(numbers);

            NormalizeArray(numbers);
            PrintArray(numbers);

            Console.WriteLine("Введите число m");
            int m;

            if (!int.TryParse(Console.ReadLine(), out m))
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Число {m} встречается {CalculalateNumber(m, numbers)} раз");

            PrintArray(ReplaceElements(numbers));


            Console.ReadKey();
        }

        static void PrintArray(double[] array)
        {
            foreach (var element in array)
                Console.Write($"{element} ");

            Console.WriteLine();
        }

        static void NormalizeArray(double[] array)
        {
            if (array.Length == 0)
                return;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 9 - array[i];
            }

        }

        static double CalculalateNumber(int m, double[] array)
        {
            int result = 0;
            foreach (var element in array)
                if (element == m)
                    result++;

            return result;
        }

        static double[] ReplaceElements(double[] array)
        {
            if (array.Length == 0)
                return new double[0];

            double[] result = new double[array.Length];

            for (var k = 0; k < array.Length; k++)
            {
                if (array[k]%2==0)
                    result[k] = 0;
                else result[k] = 1;
            }

            return result;
        }
    }
}
