using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    abstract class Component : ICloneable, IGetKey<String>
    {
        protected ArrayList nextNodes;

        public Component()
        {
            nextNodes = new ArrayList();
        }

        public void AddNextNode(Component node)
        {
            nextNodes.Add(node);
        }

        protected void sendToNext(bool value)
        {
            foreach (Component n in nextNodes)
            {
                n.execute(value);
            }
        }

        public abstract void execute(bool input);

        public static Component create(String sNaam)
        {
            return FactoryMethod<String, Component>.create(sNaam);
        }

        public abstract String getKey();
        public abstract object Clone();
    }
}
