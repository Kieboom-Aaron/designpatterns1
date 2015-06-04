using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Not : Component
    {
        public override void execute(bool input)
        {
            bool value = !input;
            sendToNext(value);
        }

        public override string getKey()
        {
            return "NOT";
        }

        public override object Clone()
        {
            return new Not();
        }
    }
}
