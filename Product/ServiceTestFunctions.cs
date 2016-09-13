using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public  class ServiceTestFunctions
    {
        private static ServiceTestFunctions instance;

        public double Infinite { get; internal set; }

        private ServiceTestFunctions()
        {

        }
        public static ServiceTestFunctions GetInstance()
        {
            if(instance == null)
            {
                instance = new ServiceTestFunctions();
            }
            return instance;
        }

        internal double GetMin()
        {
            return 10 ;
        }

        internal double GetMax()
        {
            return 10;
        }

        internal int Count()
        {
            throw new NotImplementedException();
        }

        internal void SetCurrentFunction(int i)
        {
            throw new NotImplementedException();
        }

        internal int GetCurrentFunctionIndex()
        {
            throw new NotImplementedException();
        }
    }

 
}
