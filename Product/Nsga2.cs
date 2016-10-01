using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class Nsga2 : Algorithm
    {
        private List<Population> ranking;
        private Population population;
        
        private void Sort()
        {
            //sorts by the aggregated disatance value
            population.Sort();
        }
        
        //The ranking property must be initialized, and filled up with values,
        //by the Rank(p) method.
        // use crodwing distance assignment, in order to obtain
        // better dispersion (what ?)
        
        public void ExecuteSelection()
        {
            ServiceTestFunctions tf = ServiceTestFunctions.GetInstance();
            //iterate through all the fronts
            foreach(Population front in ranking)
            {
                //sort front 
                foreach(Individual i in front)
                {
                    i.Distance = 0;
                }
                ServiceOutput o = ServiceOutput.GetInstance();
                for (int i = 0; i < tf.Count(); i++)
                {
                    List<Individual> genom = front.GetGenom();
                    front.SortBy(i);
                    genom[0].Distance = tf.Infinite;
                    genom[genom.Count-1].Distance = tf.Infinite;
                    for(int j = 1; j < genom.Count - 1; j++)
                    {
                        genom[j].Distance += Math.Abs(genom[j + 1].ObjectiveValue[i] - genom[j - 1].ObjectiveValue[i]) 
                            / (tf.GetMax() - tf.GetMin());
                    }
                }
            }
        }
                
        public void Rank()
        {
            ranking = new List<Population>();
            ranking.Add(new Population());
            foreach (Individual p in population)
            {
                p.DominatedBy = 0;
                foreach (Individual q in population)
                {
                    if (!p.Equals(q))
                    {
                        if (p.Dominates(q))
                        {
                            p.AddToDominatedSet(q);
                        }
                        else
                        {
                            if (q.Dominates(p))
                            {
                                p.DominatedBy++;
                            }
                        }
                    }
                    
                }
                if(p.DominatedBy == 0)
                {
                    ranking[0].Add(p);                    
                }
            }

            int i = 0;
            Population front = ranking[0];
            // do until nextFront has elements
            // else, there are no other fronts

            while (front.getPopulationCount() > 0)
            {
                var nextFront = new Population(); 
                foreach(Individual p in front)
                {
                    foreach(Individual q in p.getDominatedSet())
                    {
                        q.DominatedBy--;
                        if(q.getDominatedSet().getPopulationCount() <= 0)
                        {   
                            nextFront.Add(q);
                            q.Fitness = i + 1;
                        }
                    }
                }
                i++;
                ranking.Add(nextFront);
                front = ranking.Last();
            }
            //int i = 0;
            //List<Solution> front = rankings.GetFront(i);
            //while (front.Count > 0)
            //{
            //    foreach (Solution p in front)
            //    {
            //        foreach (Solution q in p.DominatedSolutions)
            //        {
            //            q.DominationCount--;
            //            if (q.DominationCount == 0)
            //            {
            //                rankings.AddIndividual(i + 1, q);
            //            }
            //        }
            //    }
            //    i++;
            //    front = rankings.GetFront(i);
            //}

            // i hope this removes the empty (last) front
            ranking.Remove(front); 
        }

        public void SetPopulation(Population p)
        {
            this.population = p;
        }
         
    }
}
