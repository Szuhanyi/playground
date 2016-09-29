using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Product
{
    public class Individual : IComparable<Individual>
    {
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
       
        public String ToReadableFormat()
        {
            StringBuilder sb = new StringBuilder();
            if (DecisionVariables != null)
            {
                sb.AppendLine("Decision Variables");

                foreach (double d in decisionVariables)
                {
                    sb.Append(d);
                    sb.Append(", ");

                }
                sb.Append("\r\n");
            }
         
                sb.AppendLine("Distance");
                sb.AppendLine(this.Distance.ToString());

            

            sb.AppendLine("Dominated by:");
            sb.AppendLine(DominatedBy.ToString());

            if (dominatedSet != null)
            {
                sb.AppendLine("Dominated set:");
                sb.AppendLine(dominatedSet.getPopulationCount().ToString());
            }
            if (values != null)
            {
                sb.AppendLine("Values:");
                foreach (double d in values)
                {
                    sb.Append(d);
                    sb.Append(", ");
                }
                sb.Append("\r\n");
            }

            return sb.ToString();
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