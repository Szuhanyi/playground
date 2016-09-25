using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    class OutputStd : Output
    {
        public void Write(string msg)
        {
            Console.Out.Write(msg);
        }
    }
}
