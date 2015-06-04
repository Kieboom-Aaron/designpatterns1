using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Circuit
    {
        Dictionary<String, Component> nodes;
        ArrayList inputs;
        public Circuit(String path)
        {
            nodes = new Dictionary<String,Component>();
            inputs = new ArrayList();
            //try
            //{
                using (StreamReader sr = new StreamReader(path))
                {
                    String readAll = sr.ReadToEnd();
                    sr.Close();
                    foreach (string s in readAll.Split('\r'))
                    {
                        if (s.Contains(':'))
                        {
                            String[] data = s.Replace(" ", "").Replace("\n", "").Replace(";", "").Replace("\t", "").Split(':');
                            string type = data[1];
                            Component c = Component.create(type);
                            if (type.Contains("INPUT"))
                            {
                                inputs.Add(c);
                            }
                            if (c == null)
                            {
                                linkNodes(data[0], type);
                            }
                            else {
                                nodes.Add(data[0], c);
                            }
                        }
                    }
                    foreach(Component c in inputs){
                        c.execute(false);
                    }
                 }
            }
        //}

        private void linkNodes(String parent, String children)
        {
            String[] childArray = children.Split(',');
            foreach(string child in childArray){
                nodes[parent].AddNextNode(nodes[child]);
            }
        }
    }
}
