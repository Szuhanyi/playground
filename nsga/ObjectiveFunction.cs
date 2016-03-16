using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    class ObjectiveFunction
    {
        private float min;
        private float max;
        public float Min
        {
            get { return min; }
            set { min = value; }
        }
        public float Max
        {
            get { return max; }
            set { max = value; }
        }

        internal double Evaluate(double d)
        {
            throw new NotImplementedException();
        }
    }
}
