using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
   public class Population
    {
        private List<Solution> genom;
        private TestFunctions functions;

        public Population()
        {
            functions = TestFunctions.GetTestFunctions();
            genom = new List<Solution>();
        }

        public Population(List<Solution> offsprings) : this()
        {
            // TODO: Complete member initialization
            genom = new List<Solution>();
           // this.genom.Clear();
            foreach (Solution s in offsprings)
            {
                this.genom.Add(s);
            }
        }

        public Population CreateOffspring()
        {
            GeneticOperators operators = new GeneticOperators();
            Random rand = new Random();
            List<Solution> newIndividuals = null;
            List<Solution> parentGenom = new List<Solution>();
            //foreach (Solution s in genom)
            //{
            //    parentGenom.Add(s);
            //}
            for (int j = 0; j < genom.Count;j++)
            {
                parentGenom.Add(new Solution(genom.ElementAt(j)));
            }
            List<Solution> offsprings = new List<Solution>();
            int i = genom.Count - 1;
            while( i >= 0 )
            {
                if ( (i > 1) && (rand.NextDouble() < 0.9))
                {
                    //do crossover
                    int i1 = 0; ////////////////////////////////////////////////// todo
                    int i2 = 1;
                    newIndividuals = operators.Crossover(parentGenom.ElementAt(i1), parentGenom.ElementAt(i2));
                    parentGenom.RemoveAt(i1);
                    parentGenom.RemoveAt(i2 - 1);
                    i -= 2;
                    foreach (Solution s in newIndividuals)
                    {
                        offsprings.Add(s);
                    }
                }
                else
                {
                    //do mutation
                    int i1 = 0;
                    newIndividuals = operators.Mutation(parentGenom.ElementAt(i1));
                    parentGenom.RemoveAt(i1);
                    i--;
                    foreach (Solution s in newIndividuals)
                    {
                        offsprings.Add(s);
                    }
                }
              
                
            }
           
            return new Population(offsprings);
        }

        public void NewPopulation(int count)
        { // should be done
            double min = functions.GetLowerThreshold();
            double max = functions.GetUpperThreshold();
            int n = functions.GetDecisionVariablesCount();
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                Solution item = new Solution();
                for (int j = 0; j < n; j++)
                {
                    item.AddDecisionVariable(min + (max - min) * rand.NextDouble()); 
                }
                this.Add(item);
            }
        }

        public Population Concat(Population genom2)
        {
            Population combined = new Population(this.genom);
            for (int i = 0; i < genom2.GetCount(); i++)
            {
                combined.Add(genom2.Get(i));
            } 
            return combined;
        }

        public Population Selection()
        {
            int n = genom.Count / 2;
            Population p = new Population();
            //fitness [0,1,...,m] front index
            int i = 0;
            int f = 0;
            while (i < n)
            {
                foreach (Solution s in genom)
                {
                    if (f == s.Fitness)
                    {
                        p.Add(s);
                        i++;
                    }
                }
                f++;
            }
            while (i > n)
            {
                p.Remove(p.GetCount() - 1);
                i--;
            }
            return p;
        }

        public void Add(Solution individual) 
        {
            this.genom.Add(individual);
        }

        public Solution Get(int index)
        {
            return this.genom.ElementAt(index);
        }

        public void Remove(int index)
        {
            this.genom.RemoveAt(index);
        }

        public void Remove(Solution individual)
        {
            this.genom.Remove(individual);
        }

        public void RemoveAll()
        {
            this.genom.Clear();
        }

        public int GetCount()
        {
            return genom.Count;
        }

        public void PrintToConsole()
        {
            Console.WriteLine("Min:" + functions.GetLowerThreshold());
            Console.WriteLine("Max:" + functions.GetUpperThreshold());
            for (int i = 0; i < genom.Count; i++)
            {
                for (int j = 0; j < genom.ElementAt(i).DecisionVariables.Count; j++)
                {
                    Console.Write(genom.ElementAt(i).DecisionVariables[j] + " ");
                }
                Console.WriteLine();
            }

        }

        internal void Copy(Population list)
        {
            for (int i = 0; i < list.GetCount(); i++)
            {
                this.Add(list.Get(i));
            }
        }

        internal void EvaluateObjectiveFunctions()
        {
            foreach (Solution s in this.genom)
            {
                functions.EvaluateObjective(s);
            }
        }
    }
}
