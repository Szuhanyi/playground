using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    abstract class ObjectiveFunction
    {
        private double min;
        private double max;
        private int n;
        public double Min
        {
            get { return min; }
            set { min = value; }
        }
        public double Max
        {
            get { return max; }
            set { max = value; }
        }
        
        public int DecisionVariablesCount
        {
            get
            {
                return n;
            }
            set { n = value; }
        }

        public abstract double Evaluate(List<double> list);
        
    }
}
