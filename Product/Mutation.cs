using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest
{
    public class Mutation : GeneticOperator
    {
        private ServiceTestFunctions functions;

        public Mutation()
        {
            functions = ServiceTestFunctions.GetInstance();
            probability = 0.5;
        }

        protected override void DoSm(Individual i)
        {
            double max = functions.GetMax();
            double min = functions.GetMin();
            double mum = functions.GetMum();

            Random rand = new Random();

            List<Individual> newBees = new List<Individual>();
            for (int j = 0; j < functions.GetDecisionVariablesCount(); j++)
            {
                double random = rand.NextDouble();
                double delta;
                if (random < 0.5)
                {
                    delta = Math.Pow(2 * random, 1 / (mum + 1)) - 1;
                }
                else
                {
                    delta = 1 - Math.Pow(2 * (1 - random), 1 / (mum + 1));
                }

                i.DecisionVariables[j] += delta;
                if (i.DecisionVariables[j] > max)
                {
                    i.DecisionVariables[j] = max;
                }
                else
                {
                    if (i.DecisionVariables[j] < min)
                    {
                        i.DecisionVariables[j] = min;
                    }
                }
            }

            functions.EvaluateObjective(i);
        }
    }
}
