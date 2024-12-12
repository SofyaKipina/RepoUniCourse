using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число целое число n:");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n < 1)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            var number = new double[n];
            var rnd = new Random();
            for (int i = 0; i < number.Length; i++)
                number[i] = rnd.NextDouble();

            PrintNumbers(number);

            NormaliseArray(number);
            PrintNumbers(number);

            Console.WriteLine($"Сумма произведений a[i] * i равна {CalculalateSumOfProducts(numbers)}");

            PrintNumbers(GetAveragePartialSquaresSums(numbers));

            Console.ReadKey();
        }

        static void PrintNumbers(double[] array)
        {
            foreach (var element in array)
            {
                Console.Write($"{element:F4} ");
            }
        }

        static void NormaliseArray(double[] array)
        {
            if (array.Length == 0)
                return;

            double sum = 0;
            foreach (var element in array)
                sum += element;

            if (sum == 0)
                return;

            for (int i = 0; i < array.Length; i++)
                array[i] /= sum;

        }

        static double CalculalateSumOfProducts(double[] array)
        {
            double result = 0;

            for (var i = 0; i < array.Length; i++)
                result += array[i] * i;

            return result;
        }
        static double[] GetAveragePartialSum(double[] array)
        { 
            if (array.Length == 0)
                return new double[0];

            double[] result = new double[array.Length];

            double partialSum = 0;
            for (int k = 1; k < array.Length; k++)
            {
                partialSum += array[k] * array[k];
                result[k] = partialSum/(k+1);
            }
            return result;
        }
    }
}
