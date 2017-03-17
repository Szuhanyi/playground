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

        // other scenerios: 
        // what do i need to implement I here:
        // restful api.. so need to implement crud operations.



            // Post: it is linked to creating resources
            // so in a post method we are going to publish test functions
            // like.. On ui. There will be a form, which would record the creation of a new TestFunction
            // and then sent by the the Post method.
            // after the, we could request the pareto front from the given function
            

            // Creating Problem objects.: they contain multiple test functions, and values
            // 

            // all of these things should be stateless... so no need for registering any user sessions
            //all connections must be anonymus ? do they really ? 
            

            Algorithm alg = new Nsga2();

            var sol = alg.GetParetoFront(TestDataService.GetInstance().GetTestPopulation(10));


            return result;
        }
    }
}
