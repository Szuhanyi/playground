using System;

namespace Newest.source
{
    internal class Mutation
    {
        public Mutation()
        {
            Mu = 1;
        }

        public int Mu { get; private set; }

        internal Individual Mutate(Individual ind1)
        {
            Individual indNew = new Individual(ind1);
            indNew.Value = ind1.Value + Mu;
            return indNew;
        }
    }
}