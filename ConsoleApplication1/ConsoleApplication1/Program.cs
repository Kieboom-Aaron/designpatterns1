using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string prefix = "D:/projects/";
            String[] paths = new String[] { "schakeling.txt", "circuit1.txt", "circuit2.txt", "CIRCUIT3.txt", "circuit4.txt" };
            foreach (String s in paths)
            {
                string path = prefix + s;
                Console.WriteLine(path);
                Circuit c = new Circuit(path);
            }
            Console.ReadLine();
        }
    }
}
