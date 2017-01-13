using Newest.source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimService.Models
{
    public class Problem
    {
        public LinkedList<Function> Functions { get; set; }

        public Problem()
        {
           
            Functions = new LinkedList<Function>();
        }  
        public void InitWithTestData()
        {
            //just in case 

        }      

    }
}
