using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest
{
    public class ServiceOutput
    {
        private static ServiceOutput instance;
        private Output output;
        
        private ServiceOutput()
        {
            output = new OutputStd();
        }
        public static ServiceOutput GetInstance()
        {
            if(instance == null)
            {
                instance = new ServiceOutput();
            }
            return instance;
        }
        public void SetOutput(Output o)
        {
            output = o;
        }
        public void Write(string v)
        {
            output.Write(v);
        }

        internal void Write(Population population)
        {
            Write(population.ToReadableFormat());
        }
    }
}
