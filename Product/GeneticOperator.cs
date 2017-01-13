using System;
using System.Collections.Generic;

namespace Newest
{
     public abstract class GeneticOperator
    {
        protected double probability;

        public void MakeChange(List<Individual> successor)
        {
            Random rand = new Random();
            foreach (Individual i in successor)
            {
                if (rand.NextDouble() <= probability)
                {
                    DoSm(i);
                }
            }
        }        
        void SetProbability(double value) {
            probability = value;
        }

        protected abstract void DoSm(Individual i);
    }
}