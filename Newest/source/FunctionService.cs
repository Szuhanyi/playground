using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest.source
{
    public class FunctionService
    {
        private static FunctionService instance;
        private LinkedList<Function> _functions;


        private FunctionService()
        {
            _functions = new LinkedList<Function>();
        }

        public static FunctionService GetInstance()
        {
            if(instance == null)
            {
                instance = new FunctionService();
            }
            return instance;
        }
        public void Add(Function f)
        {
            _functions.AddFirst(f);
        } 
        public void Remove(Function f)
        {
            try
            {
                _functions.Remove(f);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveAll()
        {
            try
            {
                _functions.Clear();
            }
            catch (Exception)
            {                
                throw;
            }
        }
       
    }
}
