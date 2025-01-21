using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число m от 5 до 20");
            int m;

            if (!TryInputNumber(out m))
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите целое число n от 5 до 20");
            int n;

            if (!TryInputNumber(out n))
            {
                Console.ReadKey();
                return;
            }

            if (m < 5 || m > 20 || n < 5 || n > 20)
            {
                Console.WriteLine("Числа не удовлетворяют неравенству 5 <= m,n <= 20");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();

            var matrix = new int[m, n];

            var rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(100);

            PrintMatrix(matrix);
            Console.WriteLine();


            bool descendOrder = CheckIfElementsSortedInDescendingOrder(matrix);
            if (descendOrder)
                {
                Console.WriteLine("Столбцы массива упорядочены по убыванию.");
                }

            Console.WriteLine();

            var diff = GetMaxMinDifferecies(matrix);

            for (int i = 0; i < diff.Length; i++)
                Console.WriteLine($"Строка {i} - разность равна {diff[i]}");

            Console.ReadKey();
        }

        static bool TryInputNumber(out int number)
        {
            number = 0;
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }

            number = n;
            return true;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],2} ");

                Console.WriteLine();
            }
        }

        static bool CheckIfElementsSortedInDescendingOrder(int[,] matrix)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                for (var i = 1; i < matrix.GetLength(0) - 1; i++)
                {
                    if (matrix[i, j] >= matrix[i - 1, j])
                    {
                        Console.WriteLine($"В столбце {j} порядок нарушен на индексах: ({i - 1}, {j}) = {matrix[i - 1, j]} и ({i}, {j}) = {matrix[i, j]}");
                        return false;
                    }
                }
                
            }
            return true;
        }

        static int[] GetMaxMinDifferecies(int[,] matrix)
        {
            var result = new int[matrix.GetLength(0)];

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                var min = int.MaxValue;
                var max = int.MinValue;

                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];

                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                }

                result[i] = max - min;
            }


            return result;
        }
    }
}
