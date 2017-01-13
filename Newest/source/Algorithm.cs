using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest.source
{
    public interface Algorithm
    {
        Population GetParetoFront(Population pop);
    }
}
