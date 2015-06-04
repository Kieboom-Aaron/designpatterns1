using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class InputLow : Component
    {

        public override void execute(bool input)
        {
            sendToNext(false);
        }

        public override string getKey()
        {
            return "INPUT_LOW";
        }

        public override object Clone()
        {
            return new InputLow();
        }
    }
}
