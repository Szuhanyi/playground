using System;
using System.Collections;
using System.Collections.Generic;

namespace Product
{
    public class Individual : IComparable<Individual>
    {
        private TestData t;

        private Population dominatedSet;

        private double[] values;

        public double[] Values
        {
            get { return values; }
        }

        public Individual(TestData t)
        {
            this.t = t;
        }

        public Individual()
        {
        }

        public int DominatedBy { get; internal set; }
        public int Fitness { get; internal set; }
        public double Distance { get;  set; }

        public void AddToDominatedSet(Individual i)
        {
            if(dominatedSet == null)
            {
                dominatedSet = new Population();
            }
            dominatedSet.Add(i);
        }

        internal void SetDominationCount(int v)
        {
            throw new NotImplementedException();
        }

        internal bool Dominates(Individual q)
        {
            throw new NotImplementedException();
        }

        internal Population getDominatedSet()
        {
            throw new NotImplementedException();
        }

       
        public int CompareTo(Individual other)
        {
            // A null value means that this object is greater
            if (other == null)
                return 1;
            else
            {
                ServiceTestFunctions tf = ServiceTestFunctions.GetInstance();
                int index = tf.GetCurrentFunctionIndex();
                return this.values[index].CompareTo(other.values[index]);
            }
        }
        
    }
}