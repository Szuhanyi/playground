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
        
        public Nsga2()
        {
        }


        public void Sort(Population p)
        {
            //sorts by the aggregated disatance value
            p.Sort();
        }
        
        
        //The ranking property must be initialized, and filled up with values,
        //by the Rank(p) method.
        public void ExecuteSelection(Population population)
        {
            // use crodwing distance assignment, in order to obtain
            // better dispersion (what ?)
            if (ranking == null)
            {
                ranking = new List<Population>();
                Rank(population);
            }
            ExecuteSelection();
        }

        private void ExecuteSelection()
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

                    en.MoveNext();
                    Individual prev =(Individual) en.Current;

                    while (en.MoveNext())
                    {
                        Individual c =(Individual)en.Current;
                        //in case this is the last element
                        if (en.MoveNext())
                        {
                            Individual next = (Individual)en.Current;
                            c.Distance += Math.Abs(next.Values[i] - prev.Values[i])
                                / (tf.GetMax() - tf.GetMin());
                        }
                    }
                    //for (int i = 1; i < sortedList.Count - 1; i++)
                    //{
                    //    sortedList.ElementAt(i).Distance =
                    //        sortedList.ElementAt(i).Distance
                    //        + Math.Abs(front.ElementAt(i + 1).ObjectiveValue[j] - sortedList.ElementAt(i - 1).
                    //ObjectiveValue[j])
                    //            / (functions.GetUpperThreshold() - functions.GetLowerThreshold());
                    //}

                }
            }
            
        }

        public void Rank(Population population)
        {

            ranking = new List<Population>();
            // need to order the populaton 
            // first and foremost
            // fast non dominated sorting algorithm
            // It is ordered in a way that no other is
            // it is ordere 
            foreach (Individual p in population)
            {
                p.DominatedBy = 0;
                foreach(Individual q in population)
                {
                    if (!p.Equals(q))
                    {
                        if (p.Dominates(q))
                        {
                            p.AddToDominatedSet(q);
                        }
                        else
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
                Population nextFront = new Population();
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
                ranking.Add(nextFront);
                front = nextFront;
            }
            // i hope this removes the empty (last) front
            ranking.Remove(front); 
        }

      
    }
}
