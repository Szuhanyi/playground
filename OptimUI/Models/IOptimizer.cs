using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimUI.Models
{
    public interface IOptimizer
    {
        Solution Optimze(IProblem problem);
    }
}
