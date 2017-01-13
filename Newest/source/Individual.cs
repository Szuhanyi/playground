using System;

namespace Newest.source
{
    public class Individual
    {
        private double fitness;
        private int front;

        public int Value { get; internal set; }

        public Individual()
        {
            fitness = 0;
            front = 0;
        }

        public Individual(Individual i) : base()
        {
            this.fitness = i.fitness;
        }

        internal int GetLength()
        {
            return 1;
        }

        public Individual(int i)
        {
            fitness = i;
        }

        public int GetRank()
        {
            return front;
        }

        public int GetFrontIndex()
        {
            return (int)fitness;
        }
    }
}