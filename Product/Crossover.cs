using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest
{
    class Crossover : GeneticOperator
    {
        private Random rand;
        private ServiceTestFunctions functions;
        public Crossover()
        {
            rand = new Random();
        }
        protected override void DoSm(Individual parent1)
        {
            throw new NotImplementedException();
        //    //needs a refactor... 
        //    //
            
        //    double max = functions.GetMin();
        //    double min = functions.GetMax();

        //    Individual child1 = new Individual();
        //    Individual child2 = new Individual();

        //    Random rand = new Random();
        //    for (int j = 0; j < functions.GetDecisionVariablesCount(); j++)
        //    {
        //        double c;
        //        double r = rand.NextDouble();

        //        if (r <= 0.5)
        //        {
        //            c = Math.Pow((2 * r), (1 / (mu + 1)));
        //        }
        //        else
        //        {
        //            c = Math.Pow(1 / (2 * r), 1 / (mu + 1));
        //        }
        //        child1.DecisionVariables.Add(0.5 * (((1 + c) * parent1.DecisionVariables[j]) + (1 - c) * parent2.DecisionVariables[j]));
        //        child2.DecisionVariables.Add(0.5 * (((1 - c) * parent1.DecisionVariables[j]) + (1 + c) * parent2.DecisionVariables[j]));
        //        if (child1.DecisionVariables[j] > max)
        //        {
        //            child1.DecisionVariables[j] = max;
        //        }
        //        else
        //        {
        //            if (child1.DecisionVariables[j] < min)
        //            {
        //                child1.DecisionVariables[j] = min;
        //            }
        //        }
        //        if (child2.DecisionVariables[j] > max)
        //        {
        //            child2.DecisionVariables[j] = max;
        //        }
        //        else
        //        {
        //            if (child2.DecisionVariables[j] < min)
        //            {
        //                child2.DecisionVariables[j] = min;
        //            }
        //        }
        //    }
        //    functions.EvaluateObjective(child1);
        //    functions.EvaluateObjective(child2);
        //    List<Solution> newBees = new List<Solution>();
        //    newBees.Add(child1);
        //    newBees.Add(child2);

        }
    }
}
