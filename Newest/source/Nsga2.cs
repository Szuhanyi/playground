using Newest.source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest.source
{
   public class Nsga2 : Algorithm
    {
        private int _iterCount = 5;

        public  Nsga2 () : base()
        {
            GlobalValues gl = GlobalValues.GetInstance();
            _iterCount = gl.ITERATION_COUNT;
        }

        public Population GetParetoFront(Population parent)
        {
            //Perform the sort through implementing the NSGA 2 evolutionary 
            // multi-objective algorithm           
            Population mutatedPopulation;                       
            for (int i = 0; i < _iterCount; i++)
            {
                mutatedPopulation  = parent.PerformMutation();
                //     performNonDominatedSort(parent);
                Population mergedPopulation = mutatedPopulation.Concat(parent);
                performNonDominatedSort(mergedPopulation);
                parent = PerformSelection(mergedPopulation);                
            }

            return GetLastFront(parent);
        }

        private void performNonDominatedSort(Population parent)
        {
            
        }

        // returns the 0th front(the Pareto Front);
        private Population GetLastFront(Population parent)
        {
            Population front = new Population();
            for(int i = 0; i < parent.GetCount(); i++)
            {
                if(parent.GetElementAt(i).GetRank() == 0)
                {
                    front.Add(parent.GetElementAt(i));
                }
            }
            return front;
        }

        //returns a merged population
        private Population PerformSelection(Population mergedPopulation)
        {
           
            Population sorted = Sort(mergedPopulation);
            Population selected = new Population();
          
            for(int i = 0; i < sorted.GetCount() / 2; i++)
            {
                selected.Add(new Individual(sorted.GetElementAt(i)));
            }
            return selected;
        }

        private Population Sort(Population mergedPopulation)
        {
            Population sorted = new Population();
            int frontIndex = -1;

            while (sorted.GetCount() < mergedPopulation.GetCount())
            {
                frontIndex++;
                Population front = new Population();
                for (int i = 0; i < mergedPopulation.GetCount(); i++)
                {
                    if(mergedPopulation.GetElementAt(i).GetFrontIndex() == frontIndex)
                    {
                        front.Add(mergedPopulation.GetElementAt(i));
                    }
                }
                sorted.Add(front);
            }

            return sorted;
        }
    }
}
