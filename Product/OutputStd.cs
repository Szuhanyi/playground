using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest
{
    public class OutputStd : Output
    {
        public void Write(string msg)
        {
            Console.Out.Write(msg);
        }
    }
}
