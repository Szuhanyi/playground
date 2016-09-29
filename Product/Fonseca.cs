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
        public override String ToReadableFormat()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: Fonseca;");
            sb.AppendLine("n = 3");
            sb.AppendLine("Objective functions:");
            sb.AppendLine("f1(x) = 1 - exp(sqr( - summa (i=1,3) (xi - 1/sqrt(3)))");
            sb.AppendLine("f1(x) = 1 - exp(sqr( - summa (i=1,3) (xi + 1/sqrt(3)))");
            sb.AppendLine("Variable bounds: [-4,4]");
            sb.AppendLine("Optimal solutions: x1=x2=x3;");
            sb.AppendLine("Comments: nonconvex");

            return sb.ToString();
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
