using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace флуд_файлыНачало
{
    internal class Program
    {
        static void Main(string[] args)
        {
            File.Create("text.txt");
            Console.WriteLine(File.Exists("text.txt"));
            Console.ReadKey();

        }
    }
}
