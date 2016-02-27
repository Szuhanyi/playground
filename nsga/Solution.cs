using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    class Solution : Individual
    {
        private int value;
        private int dominationCount;
        private HashSet<Solution> dominatedSolutions;
        private float crowdingDistance;
        
        public float CrowdingDistance
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
                if (dominatedSolutions == null)
                {
                    dominatedSolutions = new HashSet<Solution>();
                }
                dominatedSolutions = (HashSet<Solution>) value;
            }
        }

        public int DominationCount
        {
            get { return this.dominationCount; }
            set { dominationCount = value; }
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        } 
       public bool Dominates (Solution individual)
        {
            return false;
        }
        public float Evaluate (ObjectiveFunction function)
        {

            return 0;
        }
    }

}
