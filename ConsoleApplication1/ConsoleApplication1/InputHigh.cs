using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class InputHigh : Component
    {
        public override void execute(bool input)
        {
            sendToNext(true);
        }

        public override string getKey()
        {
            return "INPUT_HIGH";
        }

        public override object Clone()
        {
            return new InputLow();
        }
    }
}
