using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest.source
{
   public class Nsga2 : Algorithm
    {
        private int ITERATION_COUNT = 5;

        public Population GetParetoFront(Population parent)
        {
            //Perform the sort through implementing the NSGA 2 evolutionary 
            // multi-objective algorithm
                        
            Population mutatedPopulation;                       
            for (int i = 0; i < ITERATION_COUNT; i++)
            {
                mutatedPopulation = parent.PerformMutation();
                parent = PerformSelection(parent, mutatedPopulation);                
            }
            return GetLastFront(parent);
        }

        //returns the 0th front(the Pareto Front);
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
        private Population PerformSelection(Population pop1, Population pop2)
        {
            Population mergedPopulation = pop1.Concat(pop2);
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
