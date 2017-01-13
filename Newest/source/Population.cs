using System;
using System.Collections.Generic;

namespace Newest.source
{
    public class Population
    {
        internal List<Individual> genom;
        private Mutator mutation;

        public Population()
        {
            mutation = Mutator.GetInstance();
            genom = new List<Individual>();
        }

        public Population(Population pop) : base()
        {
            if (genom == null)
            {
                genom = new List<Individual>();
            }
            foreach (Individual i in pop.genom)
            {
                genom.Add(new Individual(i));
            }            
        }
        
        internal Population PerformMutation()
        {
           return new Population(mutation.PerformMutation(this));            
        }

        public int GetCount()
        {
            return this.genom.Count;
        }

        public Individual GetElementAt(int i)
        {
            if (i < genom.Count && i >= 0)
            {
                var obj = genom.ToArray();
                return (Individual)obj.GetValue(i);
            }
            return null;
        }

        public void Add(Individual individual)
        {
            this.genom.Add(individual);
        }

        public Population Concat(Population pop2)
        {
            Population merged = new Population(pop2);
            foreach(Individual i in genom)
            {
                merged.Add(i);
            }
            return merged;
        }

        internal void Add(Population population)
        {
            //I hope this doesnt violate any restrictions 
            // because I am accessing another instace's private fields
            foreach(Individual i in population.genom)
            {
                this.genom.Add(i);
            }
        }

        public void Remove(Individual ind1)
        {
            genom.Remove(ind1);
        }
    }
}