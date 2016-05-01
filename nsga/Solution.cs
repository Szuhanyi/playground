using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    public class Solution 
    {
        private List<double> value;
        private List<double> decisionVariables;
        private int dominationCount;
        private HashSet<Solution> dominatedSolutions;
        private double crowdingDistance;
        private double distances;
        private int fitness;


        public Solution()
        {
            ObjectiveValue = new List<double>();
            decisionVariables = new List<double>();
            dominatedSolutions = new HashSet<Solution>();
        }

        public Solution(Solution sol) : this()
        {
            
           // decisionVariables = new List<double>();
            foreach (double s in sol.DecisionVariables)
            {
                this.decisionVariables.Add(s);
            }
        }

        public int Fitness
        {
            get { return fitness; }
            set { fitness = value; }
        }
        public List<double> DecisionVariables
        {
            get { return decisionVariables; }
            set { decisionVariables = value; }
        }

        public double CrowdingDistance
        {
            get { return crowdingDistance; }
            set { crowdingDistance = value;}
        } 

        public void AddDominatedSolution(Solution individual)
        {
            dominatedSolutions.Add(individual);
        }

        public void RemoveDominatedSolution(Solution individual)
        {
            dominatedSolutions.Remove(individual);
        }
        
        public ISet<Solution> DominatedSolutions
        {
            get { return dominatedSolutions; }
            set
            {   
                
                dominatedSolutions = (HashSet<Solution>) value;
            }
        }

        public int DominationCount
        {
            get { return this.dominationCount; }
            set { dominationCount = value; }
        }

        public List<double> ObjectiveValue
        {
            get { return value; }
            set { this.value = value; }
        } 

        public bool Dominates (Solution individual)
        {
            int counter = 0;
            bool dominates = false;
            for(int i = 0; i < value.Count; i++)
            {
                if(this.ObjectiveValue[i] <= individual.ObjectiveValue[i])
                {
                    counter++;
                }
            }
            if (counter == value.Count)
            {
                for (int i = 0; i < value.Count; i++)
                {
                   if (this.value[i] < individual.ObjectiveValue[i])
                    {
                        dominates = true;
                    }
                }
            }
            return dominates;
        }       

        public double Distance
        {
            get { return distances; }
            set { distances = value; }
        }

        internal void Evaluate(List<ObjectiveFunction> functions)
        {

            for(int i = 0; i < functions.Count; i++)
            {
                if (this.ObjectiveValue.Count <= i)
                {
                    ObjectiveValue.Add(EvaluateObjectiveFunction(functions.ElementAt(i), decisionVariables));
                }
                this.ObjectiveValue[i] = EvaluateObjectiveFunction(functions.ElementAt(i), decisionVariables);
            }
        }

        private double EvaluateObjectiveFunction(ObjectiveFunction objectiveFunction, List<double> decisionVariables)
        {
            // I really dont know  how to evaluate an objective function, when there are more then one decision variables
            // because I try to minimize the solution, I just aggregated them into one value (for now)
            return objectiveFunction.Evaluate(decisionVariables);
             
            }

        internal void AddDecisionVariable(double p)
        {
            this.decisionVariables.Add(p);
        }
    }

}
