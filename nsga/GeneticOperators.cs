using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    public class GeneticOperators
    {
        private double mu;
        private double mum;
        private TestFunctions functions;

        public GeneticOperators()
        {
            functions = TestFunctions.GetTestFunctions();
            mu = 0.0001;
            mum = 0.0004;
        }

        public List<Solution> Crossover(Solution parent1, Solution parent2)
        {
            double max = functions.GetUpperThreshold();
            double min = functions.GetLowerThreshold();
            Solution child1 = new Solution();
            Solution child2 = new Solution();
            Random rand = new Random();
            for (int j = 0; j < functions.GetDecisionVariablesCount(); j++)
            {
                double c;
                double r = rand.NextDouble();

                if (r <= 0.5)
                {
                    c = Math.Pow((2 * r), (1 / (mu + 1)));
                }
                else
                {
                    c = Math.Pow(1 / (2 * r), 1 / (mu + 1));
                }
                child1.DecisionVariables.Add(0.5 * (((1 + c) * parent1.DecisionVariables[j]) + (1 - c) * parent2.DecisionVariables[j]));
                child2.DecisionVariables.Add(0.5 * (((1 - c) * parent1.DecisionVariables[j]) + (1 + c) * parent2.DecisionVariables[j]));
                if (child1.DecisionVariables[j] > max)
                {
                    child1.DecisionVariables[j] = max;
                }
                else
                {
                    if (child1.DecisionVariables[j] < min)
                    {
                        child1.DecisionVariables[j] = min;
                    }
                }
                if (child2.DecisionVariables[j] > max)
                {
                    child2.DecisionVariables[j] = max;
                }
                else
                {
                    if (child2.DecisionVariables[j] < min)
                    {
                        child2.DecisionVariables[j] = min;
                    }
                }
            }
            functions.EvaluateObjective(child1);
            functions.EvaluateObjective(child2);
            List<Solution> newBees = new List<Solution>();
            newBees.Add(child1);
            newBees.Add(child2);

            return newBees;
        }

        public List<Solution> Mutation(Solution solution)
        {
            double max = functions.GetUpperThreshold();
            double min = functions.GetLowerThreshold();
            Random rand = new Random();
            List<Solution> newBees = new List<Solution>();
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

                solution.DecisionVariables[j] += delta;
                if (solution.DecisionVariables[j] > max)
                {
                    solution.DecisionVariables[j] = max;
                }
                else
                {
                    if (solution.DecisionVariables[j] < min)
                    {
                        solution.DecisionVariables[j] = min;
                    }
                }
            }
            functions.EvaluateObjective(solution);
            newBees.Add(solution);
            
            return newBees;
        }
    }
}
