using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    class ServiceOutput
    {
        private static ServiceOutput instance;
        
        private ServiceOutput()
        {

        }
        public static ServiceOutput GetInstance()
        {
            if(instance != null)
            {
                instance = new ServiceOutput();
            }
            return instance;
        }

        internal void Write(string v)
        {
            throw new NotImplementedException();
        }

        internal void Write(Population population)
        {
            Write(population.ToReadableFormat());
        }
    }
}
