using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    class Fonseca : ObjectiveFunction
    {
        private bool first;
        public Fonseca(bool method1)
        {
            first = method1;
            this.Max = 4;
            this.Min = -4;
            this.DecisionVariablesCount = 2;
        }
        public override double Evaluate(List<double> list)
        {
            double value = 0;
            double number = 1 / Math.Sqrt(3);
            if (first)
            {
                value = 1 - Math.Exp(-((list.ElementAt(0) - number) * (list.ElementAt(0) - number)
                                         + (list.ElementAt(1) - number) * (list.ElementAt(1) - number)
                                        )
                                     );
            }
            else
            {
                value = 1 - Math.Exp(-((list.ElementAt(0) + number) * (list.ElementAt(0) + number)
                                       + (list.ElementAt(1) + number) * (list.ElementAt(1) + number)
                                      )
                                   );
            }

            return value;
        }
    }
}
