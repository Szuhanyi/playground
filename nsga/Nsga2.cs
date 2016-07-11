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
                if (front.Count == 0)
                {
                    rankings.Remove(rankings.GetFrontCount() - 1);
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
                    string list = "";
                    foreach (double d in s.DecisionVariables)
                    {
                        list += d + "; ";
                    }
                    Console.WriteLine(i + " " + list);
                   
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

        private void CrowdingDistanceAssignment(List<Solution> front)
        {
            TestFunctions functions = TestFunctions.GetTestFunctions();

            foreach (Solution s in front)
            {           
                s.Distance = 0;
            }
            for (int j = 0; j < functions.GetFunctionCount(); j++)
            {
                List<Solution> sortedList = SortObjective(front, j);
                sortedList.First().Distance = infinite;
                sortedList.Last().Distance = infinite;
                for (int i = 1; i < sortedList.Count - 1; i++)
                {
                    sortedList.ElementAt(i).Distance =
                        sortedList.ElementAt(i).Distance
                        + Math.Abs(front.ElementAt(i + 1).ObjectiveValue[j] - sortedList.ElementAt(i - 1).ObjectiveValue[j])
                            / (functions.GetUpperThreshold() - functions.GetLowerThreshold());
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
                min =  list.First();
                for(int j = 1; j < list.Count; j++)
                {
                    if (min.ObjectiveValue[index] > list[j].ObjectiveValue[index])
                    {
                        min = list[j];
                    }
                }

                newList.Add(min);
                list.Remove(min);
            }
            
            return newList;
        }
        private Population SortPopulation(Population geom) 
        {
            Population pop = new Population();

            for (int i = 0; i < rankings.GetFrontCount(); i++)
            {

                var front = rankings.GetFront(i);
                while (front.Count > 0)
                {
                    var min = front.First();
                    for (int j = 1; j < front.Count; j++)
                    {
                        if(!min.Equals(front.ElementAt(j))) {
                        if (min.Dominates(front.ElementAt(j)))
                        {
                            min = front.ElementAt(j);
                        }
                        else
                        {   // front[j] does not dominate min either
                            // this mean that they are kinda equal
                            if (!front.ElementAt(j).Dominates(min))
                            {
                                // crowind distance
                                if (min.Distance < front.ElementAt(j).Distance)
                                {
                                    min = front.ElementAt(j);
                                }
                            }
                        }
                        }
                    }

                    pop.Add(min);
                    front.Remove(min);
                }

 
            }
            return pop;
        }
        public Population StartEvaluation(int populationCount, int generationCount)
        {
            infinite = 10000;
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
                AssignCrowdingDistance();
                genom.Copy(SortPopulation(combinedGenom).Selection());
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
    
public  double infinite { get; set; }}
}
 