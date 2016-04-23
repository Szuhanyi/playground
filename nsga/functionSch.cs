using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    class functionSch : ObjectiveFunction
    {
        bool method1;
        public functionSch(bool first)
        {
            method1 = first;            
            this.Min = -1000;
            this.Max = 1000;
            this.DecisionVariablesCount = 1;
        }
        
        public override double Evaluate(List<double> list)
        {
            double value = 0;
            double x = list.First();
            if (method1)
            {
                value = x * x;
            }
            else
            {
                value = (x - 2) * (x - 2);
            }
            return value;
        }

    }
}
