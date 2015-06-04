using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Nand : Component
    {
        bool? holder;
        public override void execute(bool input)
        {
            if (holder == null)
            {
                holder = input;
            }
            else
            {
                bool value = ((bool)holder && input);
                sendToNext(value);
            }
        }

        public override String getKey()
        {
            return "NAND";
        }

        public override object Clone()
        {
            return new Nand();
        }
    }
}
