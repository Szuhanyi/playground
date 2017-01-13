using Newest.source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimService.Models
{
    public class Optim : Optimizer
    {
        public Solution Optimize(Problem data)
        {
            if(data.Functions.Count == 0)
            {
                data.InitWithTestData();
            }
            Solution result = null;
            //Should i use the factory pattern here ?
            // Standard client scenerio 
              // Client logs in into the client app
              // Generates a request, (there should be one default, one opion for creating onther one)
              // Server recieves the requests, then performs some operations upon request
              // then server generates a response (if needed, because Only GET HTTP method requires one)
           // Http requests: 
                // get : By default, it should return the init page
                // get:?id : retrieves a resource from server side
                // post : uploads(creates resources)
                // put : update( or at least in CRUD operations)
                // delete : well. it should be implemented.

             // GetAll(): returns a standard hanshake kinda response. 
             //         Recieves a great pleasure from the server 
             //

        


            Algorithm alg = new Nsga2();

            var sol = alg.GetParetoFront(TestDataService.GetInstance().GetTestPopulation(10));


            return result;
        }
    }
}
