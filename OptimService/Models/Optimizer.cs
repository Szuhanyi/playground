using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimService.Models
{
    public interface Optimizer
    {
         Solution Optimize(Problem data);
    }
}
