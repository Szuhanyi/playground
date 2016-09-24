using System;
using System.Collections.Generic;

namespace Product
{
     public abstract class GeneticOperator
    {
        private double probability;

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