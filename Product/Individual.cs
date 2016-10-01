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
        private double distance;
        private List<double> objectiveValue;
        private int id;

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
            id = t.Id;
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
        }

        public int DominatedBy { get; internal set; }
        public int Fitness { get; internal set; }
        public double Distance { get { return distance; }  set { distance = value; } }
        public int Id { get { return id; } set { id = value; } }

        public List<double> ObjectiveValue {
            get
            {
                if (objectiveValue == null)
                {
                    objectiveValue = new List<double>();
                }
                    return objectiveValue;
                }
            set
            {
                objectiveValue = value;
            }
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
            int counter = 0;
            bool dominates = false;
            for (int i = 0; i < ObjectiveValue.Count; i++)
            {
                double def = this.ObjectiveValue[i] - q.ObjectiveValue[i];
                if (this.ObjectiveValue[i] <= q.ObjectiveValue[i])
                {
                    counter++;
                }
            }
            if (counter == ObjectiveValue.Count)
            {
                // 
                //for (int i = 0; i < objectiveValue.Count; i++)
                //{
                //    double def = this.objectiveValue[i] - q.ObjectiveValue[i];
                //    if (this.objectiveValue[i] < q.ObjectiveValue[i])
                //    {
                        dominates = true;
                //    }
                //}
            }
            return dominates;
        }

        internal Population getDominatedSet()
        {
            if(dominatedSet == null)
            {
                dominatedSet = new Population();
            }
            return this.dominatedSet;
        }
       
        public String ToReadableFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Id:");
            sb.AppendLine(id.ToString());
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
                sb.AppendLine(this.distance.ToString());

            

            sb.AppendLine("Dominated by:");
            sb.AppendLine(DominatedBy.ToString());

            if (dominatedSet != null)
            {
                sb.AppendLine("Dominated set:");
                sb.AppendLine(dominatedSet.getPopulationCount().ToString());
            }
            if (objectiveValue != null)
            {
                sb.AppendLine("Values:");
                foreach (double d in this.objectiveValue)
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