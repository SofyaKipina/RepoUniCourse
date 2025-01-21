using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace task_exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[] sequance = new int[n];
            for (int i = 0; i < n; i++) 
            {
                sequance[i] = DetermineSequanceTerm(i);
                Console.WriteLine(sequance[i]);
            }

            int sum = 0;
            foreach (int element in sequance)
                sum += element;
            Console.WriteLine(sum);

            Console.ReadKey();
        }

        static int DetermineSequanceTerm(int n)
        {
            
                if (n == 0)
                    return 1;
                else if (n % 2 != 0)
                    return 2 * DetermineSequanceTerm(n - 2);
                else return DetermineSequanceTerm(n - 1) - 3 * DetermineSequanceTerm(n - 2);
            
        }

    }
}
