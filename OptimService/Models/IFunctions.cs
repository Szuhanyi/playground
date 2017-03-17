using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimService.Models
{
    public interface IFunctions
    {
        string GetAll();
        Function Get(int id);
        bool Add(Function function);
        bool Remove(string id); 
    }
}
