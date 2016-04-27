using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    public class Nsga2 : Algorithm
    {        
        private Ranking rankings;
      
        private void FastNonDominatedSort(Population genom)
        {
            genom.EvaluateObjectiveFunctions();
            List<Solution> population = new List<Solution>();
            for (int j = 0; j < genom.GetCount(); j++)
            {
                population.Add(genom.Get(j));
            }
            rankings = new Ranking();
            foreach (Solution p in population)
            {
                p.DominationCount = 0;

                foreach (Solution q in population)
                {
                    if (!p.Equals(q))
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
                    }
                }
                if (p.DominationCount == 0)
                {
                    rankings.AddIndividual(0, p);
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
                        if (q.DominationCount == 0)
                        {
                            rankings.AddIndividual(i + 1, q);
                        }
                    }
                }
                i++;
                front = rankings.GetFront(i);
            }
            for (int j = 0; j < rankings.GetFrontCount(); j++ )
            {
                front = rankings.GetFront(j);
                foreach (Solution s in front)
                {
                    s.Fitness = j;
                }
            }
        }

        private void RankingsPrintToConsole()
        {
            for (int i = 0; i < rankings.GetFrontCount(); i++)
            {
                List<Solution> front = rankings.GetFront(i);
                foreach (Solution s in front)
                {
                    foreach (double d in s.DecisionVariables)
                    {

                    }
                    Console.WriteLine(i + " " + s.DecisionVariables[0]);
                }
            }
        }

        private void AssignCrowdingDistance()
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
            //int l = population.Count;

            //double[] distances = new double[functions.Count];
            //foreach (Solution s in population)
            //{
            //    for (int i = 0; i < distances.Length; i++)
            //    {
            //        distances[i] = 0;
            //    }
            //}
            //    foreach(ObjectiveFunction m in functions)
            //     { 
            //        List<Solution> sortedList = SortObjective(population, functions.IndexOf(m));
            //        //  population = Selection(population, m);
            //        //   for (int i = 0; i < population.Count; i++)
            //        //   {
            //        //     population.ElementAt(i

            //        //  }
            //        sortedList.First().Distance[functions.IndexOf(m)] = infinite;
            //        sortedList.Last().Distance[functions.IndexOf(m)] = infinite;
            //        for (int i= 1; i < (l-1); i++)
            //        {
            //            population.ElementAt(i).Distance[functions.IndexOf(m)] = 
            //                population.ElementAt(i).Distance[functions.IndexOf(m)]
            //                + (population.ElementAt(i + 1).ObjectiveValue[functions.IndexOf(m)] - population.ElementAt(i - 1).ObjectiveValue[functions.IndexOf(m)]) 
            //                    / (m.Max - m.Min);
            //        }
            //    }
            
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
        
        public Population StartEvaluation(int populationCount, int generationCount)
        {
            Population genom = new Population();           
            genom.NewPopulation(populationCount);
            Console.WriteLine("Initial population");
            genom.PrintToConsole();
            Population newGenom = genom.CreateOffspring();
            Console.WriteLine("Initial population after creating offspring pop");
            genom.PrintToConsole();
            Console.WriteLine("Offspring population");
            newGenom.PrintToConsole();
            FastNonDominatedSort(genom);
            RankingsPrintToConsole();
            for (int i = 0; i < generationCount; i++)
            {
                Population combinedGenom = genom.Concat(newGenom);
                FastNonDominatedSort(combinedGenom);
                genom.RemoveAll();
                genom.Copy(combinedGenom.Selection());
                newGenom = genom.CreateOffspring();
            }

            newGenom.PrintToConsole();
            this.RankingsPrintToConsole();
            //PrintToConsole(genom);
           // genom.PrintToConsole();
          
            return genom;
        }

        public void PrintToConsole(Population genom)
        {
            throw new NotImplementedException();
        }
    }
}
 