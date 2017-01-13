using System;
using System.Collections.Generic;

namespace Newest.source
{
    //I am not sure about this class
    public class Mutator
    {
        private static Mutator instance;
        private Crossover crossover;
        private Mutation mutation;
        private Mutator()
        {
            crossover = new Crossover();
            mutation = new Mutation();  
        }

        public static Mutator GetInstance()
        {
            if(instance == null)
            {
                instance = new Mutator();
            }
            return instance;
        }

        public Population PerformMutation(Population population)
        {
            Population newPop = new Population(population);
            Random rand = new Random();
            Individual ind1;
            Individual ind2;
            
            int i = 0;
            while (i < newPop.GetCount())
            {
                double f = rand.NextDouble();
                if (f < 0.8)
                {
                    //perform crossover
                    ind1 = newPop.GetElementAt(i);
                    i++;
                    ind2 = newPop.GetElementAt(i);
                    i++;
                    if (ind1 != null && ind2 != null)
                    {
                        ind1 = crossover.Mutate(ind1, ind2);
                        ind2 = crossover.Mutate(ind1, ind2);
                    }
                    else
                    {
                        if (ind1 != null)
                        {
                            ind1 = mutation.Mutate(ind1);
                        }
                    }
                }
                else
                {
                    //perform mutation
                    mutation.Mutate(newPop.GetElementAt(i));
                    i++;
                }

            }
            return newPop;
        }
    }
}