using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimService.Models
{
    // this class serves as a controller for the subjected functions 
    public class Functions : IFunctions
    {
        private LinkedList<Function> _functions;

        public bool Add(Function function)
        {
            try
            {
                _functions.AddLast(function);
            }
            catch (Exception)
            {
                // Do I need to silent this exception ?
                return false;
            }
            return true;
        }

        public string Get(int id)
        {
            return _functions.ElementAt(id).ToString();
        }

        public string GetAll()
        {
            // this is incorrect
            return _functions.ToString();
        }

        public bool Remove(string id)
        {
            // Need to test this solution
            var a = _functions.Where(x => x.name == id).First();
            return _functions.Remove(a);
        }

        Function IFunctions.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
