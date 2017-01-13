using System;

namespace Newest.source
{
    internal class Crossover
    {
        private GlobalValues gl;
        public Crossover()
        {
            gl = GlobalValues.GetInstance();
        }
        internal Individual Mutate(Individual ind1, Individual ind2)
        {
            Individual ind3 = new Individual();
            for(int i = 0; i < ind1.GetLength(); i++)
            {
                ind3.Value = (ind1.Value + ind2.Value) / 2;
            }
            return ind3;
        }
    }
}