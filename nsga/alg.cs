using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    class alg
    {
        private List<Solution> population;
        private List<Solution> offspringPopulation;
        private List<Solution> combinedPopulation;
        private Ranking rankings;
        private List<ObjectiveFunction> functions;
        private List<Constraint> constraints;
        private double infinite;
        private double mu; // erteket kell adni
        private double mum;// initializalni kell
        private double max;
        private double min;
        private int variables;
       
        public void PrintOut(List<Solution> population)
        {
            int n = rankings.GetFrontCount();
            List<Solution> list;
            for (int i = 0; i < n; i++)
            {
                list = rankings.GetFront(i);
                foreach(Solution s in list)
                {
                    System.Console.Write(" " + s.DecisionVariables);
                }
                System.Console.WriteLine();
            } 
        } 

        public void FastNonDominatedSort(List<Solution> population)
        {
            rankings = new Ranking();
            foreach (Solution p in population)
            {
                p.DominationCount = 0;
                p.DominatedSolutions = null;
                foreach(Solution q in population)
                {
                    if (p.Dominates(q))
                    {
                        p.DominatedSolutions.Add(q);
                    }
                    else
                    {
                        if (q.Dominates(p))
                        {
                            p.DominationCount++;
                        }
                    }
                    if (p.DominationCount == 0)
                    {
                        rankings.AddIndividual(0, p);
                    }
                }
            }
            int i = 0;
            List<Solution> front = rankings.GetFront(i);
            while (front.Count > 0)
            {                
                foreach (Solution p in front)
                {
                    foreach (Solution q in p.DominatedSolutions)
                    {
                        q.DominationCount--;
                        if (q.DominationCount ==0)
                        {
                            rankings.AddIndividual(i + 1, q);                            
                        }
                    }
                }
                i++;
                front = rankings.GetFront(i);
            }
        }

        public void NsgaII(int populationSize, int generations) 
        {
            population = CreateRandomParentPopulation(populationSize);
            FastNonDominatedSort(population);
            offspringPopulation = CreateOffspringPopulation(population);
            for (int i = 0 ; i < generations; i++)
            {
                combinedPopulation = Combine(population, offspringPopulation);
                FastNonDominatedSort(combinedPopulation);
                population = Selection(combinedPopulation);
                offspringPopulation = CreateOffspringPopulation(population);
         

            }
        }

        private List<Solution> CreateOffspringPopulation(List<Solution> population)
        {
            // needs a good deep testing
            int n = population.Count;
            int p = 1;
            bool wasCrossover = false;
            bool wasMutation = false;
            Random rand = new Random();
            List<Solution> offsprings = new List<Solution>();
            for (int i = 0; i < n; i++) 
            {
                Solution child1 = new Solution();
                Solution child2 = new Solution();
                Solution parent1 = new Solution();
                Solution parent2 = new Solution();
                if (rand.NextDouble() < 0.9)
                {
                    // crossover

                    int index1 = Convert.ToInt32(n * rand.NextDouble());
                    if (index1 == n)
                    {
                        index1--;
                    }
                    int index2 = Convert.ToInt32(n * rand.NextDouble());
                    if (index2 == n)
                    {
                        index2--;
                    }
                    while (index1 == index2)
                    {
                        index2 = Convert.ToInt32(n * rand.NextDouble());
                        if (index2 ==  n)
                        {
                            index2--;
                        }
                    }

                    parent1 = population.ElementAt(index1);
                    parent2 = population.ElementAt(index2);                    
                    for (int j = 0; j < variables; j++)
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
                        child1.DecisionVariables[j] = 0.5 * (((1 + c) * parent1.DecisionVariables[j]) + (1 - c) * parent2.DecisionVariables[j]);
                        child2.DecisionVariables[j] = 0.5 * (((1 + c) * parent1.DecisionVariables[j]) + (1 - c) * parent2.DecisionVariables[j]);
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
                    EvaluateObjective(child1);
                    EvaluateObjective(child2);
                    wasCrossover = true;
                    wasMutation = false;
                }
                else
                {
                    // mutation
                    int index = Convert.ToInt32(n * rand.NextDouble());
                    if (index == n)
                    {
                        index--;
                    }
                    Solution child3 = new Solution(population.ElementAt(index));
                    for (int j = 0; j < functions.Count; j++)
                    {
                        double random = rand.NextDouble();
                        double delta;
                        if (random < 0.5)
                        {
                            delta = Math.Pow(2 * random,1 / (mum + 1)) - 1;
                        }
                        else
                        {
                            delta = 1 - Math.Pow(2 * (1 - random), 1 / (mum + 1));
                        }
                        child3.DecisionVariables[j] += delta;
                        if (child3.DecisionVariables[j] > max)
                        {
                            child3.DecisionVariables[j] = max;
                        }
                        else
                        {
                            if (child3.DecisionVariables[j] < min)
                            {
                                child3.DecisionVariables[j] = min;
                            }
                        }
                    }
                    EvaluateObjective(child3);
                    wasCrossover = false;
                    wasMutation = true;
                    if (wasCrossover)
                    {
                        offsprings.Add(child1);
                        offsprings.Add(child2);
                        wasCrossover = false;
                    }
                    else
                    {
                        if (wasMutation)
                        {
                            offsprings.Add(child3);
                            wasMutation = false;
                        }
                    }
                }
            }

            return offsprings;
        }

        private void EvaluateObjective(Solution child1)
        {
            child1.Evaluate(functions);
        }

        private List<Solution> Combine(List<Solution> population1, List<Solution> population2)
        {
            List<Solution> list = new List<Solution>();
            foreach(Solution s in population2)
            {
                list.Add(s);
            }
            foreach (Solution s in population1)
            {
                list.Add(s);
            }
            return list;
        }

        private List<Solution> Selection(List<Solution> combinedPopulation)
        {
            int n = combinedPopulation.Count / 2;
            List<Solution> list = new List<Solution>();
            int f = 0;
            while (list.Count < n)
            {
                List<Solution> front = rankings.GetFront(f);
                foreach(Solution s in front)
                {
                    list.Add(s);
                }
                f++;
            }
            if (list.Count > n)
            {
                // need to remove a few elements based on theier crowding distance 
                while (list.Count > n)
                { // and how do you do that ??? hhuh ?
                    list.Remove(list.Last());
                }
            }
            return list;
        }

        private List<Solution> CreateRandomParentPopulation(int size)
        {

            List<Solution> list = new List<Solution>();
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                Solution item = new Solution();
                item.DecisionVariables.Add(this.min + (this.max - this.min) * rand.NextDouble());
            }

            return list;
        }

        private List<Solution> geneticOperator(List<Solution> population)
        {
            throw new NotImplementedException();
        }

        private List<Solution> tournamentSelection(List<Solution> population, Ranking rankings, int pool, int tour)
        {
            throw new NotImplementedException();
        }

        public void AssignCrowdingDistance()
        {
            int n = rankings.GetFrontCount();
            for (int i = 0; i < n; i++)
            {
                List<Solution> list = rankings.GetFront(i);
                CrowdingDistanceAssignment(list);
            }
        }
        private void CrowdingDistanceAssignment(List<Solution> population)
        {
            int l = population.Count;

            double[] distances = new double[functions.Count];
            foreach (Solution s in population)
            {
                for (int i = 0; i < distances.Length; i++)
                {
                    distances[i] = 0;
                }
            }
                foreach(ObjectiveFunction m in functions)
                 { 
                    List<Solution> sortedList = SortObjective(population, functions.IndexOf(m));
                    //  population = Selection(population, m);
                    //   for (int i = 0; i < population.Count; i++)
                    //   {
                    //     population.ElementAt(i

                    //  }
                    sortedList.First().Distance[functions.IndexOf(m)] = infinite;
                    sortedList.Last().Distance[functions.IndexOf(m)] = infinite;
                    for (int i= 1; i < (l-1); i++)
                    {
                        population.ElementAt(i).Distance[functions.IndexOf(m)] = 
                            population.ElementAt(i).Distance[functions.IndexOf(m)]
                            + (population.ElementAt(i + 1).ObjectiveValue[functions.IndexOf(m)] - population.ElementAt(i - 1).ObjectiveValue[functions.IndexOf(m)]) 
                                / (m.Max - m.Min);
                    }
                }
            
        }

        private List<Solution> SortObjective(List<Solution> population, int index)
        {
            List<Solution> list = new List<Solution>(population);
            List<Solution> newList = new List<Solution>();
            Solution min = null;
            while (list.Count > 0)
            {
                min = new Solution(list.First());
                for(int j = 1; j < list.Count; j++)
                {
                    if (min.ObjectiveValue[index] > list[j].ObjectiveValue[index])
                    {
                        min = list[j];
                    }
                    newList.Add(min);
                    list.Remove(min);
                }
            }
            
            return list;
        }

       
    }
}
 