using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    public interface Algorithm
    {               
         Population StartEvaluation(int populationCount, int generationCount);
         void PrintToConsole(Population genom);

    }
}
