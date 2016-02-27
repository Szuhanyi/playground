using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    class alg
    {
        private List<Individual> population;
        private List<Individual> nextPopulation;
        private Ranking rankings;
        private List<ObjectiveFunction> functions;
        private List<Constraint> constraints;
        private int infinite;
       
        public void PrintOut(List<Solution> population)
        {
            int n = rankings.GetFrontCount();
            List<Solution> list;
            for (int i = 0; i < n; i++)
            {
                list = rankings.GetFront(i);
                foreach(Solution s in list)
                {
                    System.Console.Write(" " + s.Value);
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
                //List<Individual> nextFront = new List<Individual>();
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
      
        public void CrowdingDistanceAssignment(List<Solution> population)
        {
            int l = population.Count;
            foreach (Solution s in population)
            {
                foreach(ObjectiveFunction m in functions)
                {
                    population = Sort(population, m);
                    population.ElementAt(0).Value = population.ElementAt(l).Value = infinite;
                    for(int i= 1; i < (l-1); i++)
                    {
                        population.ElementAt(i).CrowdingDistance = 
                            population.ElementAt(i).CrowdingDistance 
                            + (population.ElementAt(i + 1).CrowdingDistance - population.ElementAt(i - 1).CrowdingDistance) 
                                / (m.Max - m.Min);
                    }
                }
            }
        }
        private List<Solution> Sort(List<Solution> population, ObjectiveFunction function)
        {

            return null;
        }
    }
}
