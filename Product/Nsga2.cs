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
            //if (ranking == null)
            //{
            //    ranking = new List<Population>();
            //    Rank();
            //}

            ServiceTestFunctions tf = ServiceTestFunctions.GetInstance();
           
            //iterate through all the fronts
            foreach(Population front in ranking)
            {
                //sort front 
                //foreach(Individual i in front)
                //{
                //    i.Distance = 0;
                //}
                ServiceOutput o = ServiceOutput.GetInstance();
                
                for (int i = 0; i < tf.Count(); i++)
                {
                    //tf.SetCurrentFunction(i);
                    //// sort by the i-th objective function

                    //front.Sort();

                    //an alternative

                    front.SortBy(i);
                    front.First().Distance = tf.Infinite;
                    front.Last().Distance = tf.Infinite;
                    //List<Solution> sortedList = SortObjective(front, j);
                    // sortedList.First().Distance = infinite;
                    //sortedList.Last().Distance = infinite;

                    var en = front.GetEnumerator();

                    //en.MoveNext();
                    if (en.MoveNext())
                    {
                        Individual prev = (Individual)en.Current;

                        if (en.MoveNext())
                        {
                            Individual current = (Individual)en.Current;
                            while (en.MoveNext())
                            {
                                //in case this is the last element
                                Individual next = (Individual)en.Current;

                                current.Distance += Math.Abs(next.ObjectiveValue[i] - prev.ObjectiveValue[i])
                                       / (tf.GetMax() - tf.GetMin());
                                prev = current;
                                current = next;
                            }
                        }
                    }
                }
            }

            Sort();
        }
                
        public void Rank()
        {

            ranking = new List<Population>();
            ranking.Add(new Population());
            // need to order the populaton 
            // first and foremost
            // fast non dominated sorting algorithm
            // It is ordered in a way that no other is
            // it is ordere 
            foreach (Individual p in population)
            {
                p.DominatedBy = 0;
                foreach (Individual q in population)
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
                
                if(p.DominatedBy == 0)
                {
                    ranking.ElementAt(0).Add(p);                    
                }
            }

            int i = 0;
            Population front = ranking.ElementAt(i);
            // do until nextFront has elements
            // else, there are no other fronts
            while(front.getPopulationCount() > 0)
            {
                var nextFront = new HashSet<Individual>();
                foreach(Individual p in front)
                {
                    foreach(Individual q in p.getDominatedSet())
                    {
                        q.DominatedBy--;
                        if(q.getDominatedSet().getPopulationCount() == 0)
                        {   
                            nextFront.Add(q);
                            q.Fitness = i;
                        }
                    }
                }
                i++;
                ranking.Add(new Population(nextFront));
                front = ranking.Last();
            }
            // i hope this removes the empty (last) front
            ranking.Remove(front); 
        }

        public void SetPopulation(Population p)
        {
            this.population = p;
        }
         
    }
}
