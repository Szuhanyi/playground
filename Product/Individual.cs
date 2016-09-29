using System;
using System.Collections;
using System.Collections.Generic;

namespace Product
{
    public class Individual : IComparable<Individual>
    {
        private TestData t;
        private Population dominatedSet;
        private List<double> decisionVariables;
        private double[] values;
        private List<double> objectiveValue;
        public double[] Values
        {
            get { return values; }
            set { values = value; }
        }

        public List<double> DecisionVariables
        {
            get {
                    if(decisionVariables == null)
                {
                    decisionVariables = new List<double>();
                }
                return decisionVariables;
            }
            set { decisionVariables = value; }
        }

        public Individual(TestData t) 
        {
            decisionVariables = new List<double>();
            decisionVariables = t.GetData();
        }

        public Individual()
        {
            decisionVariables = new List<double>();
        }

        public Individual(Individual i)
        {
            this.DecisionVariables = i.DecisionVariables;
            this.Distance = i.Distance;
            this.DominatedBy = i.DominatedBy;
            this.Fitness = i.Fitness;
            this.Values = i.Values;
        }

        public int DominatedBy { get; internal set; }
        public int Fitness { get; internal set; }
        public double Distance { get;  set; }
        public List<double> ObjectiveValue {
            get {
                if (objectiveValue == null)
                {
                    objectiveValue = new List<double>();
                }
                    return objectiveValue;
                }
            set { objectiveValue = value; }
        }

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
            //    ServiceTestFunctions tf = ServiceTestFunctions.GetInstance();
            //    int index = tf.GetCurrentFunctionIndex();
                return this.Distance.CompareTo(other.Distance);
            }
        }
        
    }
}