using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Probe : Component
    {

        public override void execute(bool input)
        {
            Console.WriteLine(input);
        }


        public override string getKey()
        {
            return "PROBE";
        }

        public override object Clone()
        {
            return new Probe();
        }
    }
}
