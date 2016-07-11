using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    public class TestFunctions
    {
        private List<ObjectiveFunction> functions;
        private static TestFunctions test;
        private TestFunctions()
        {
            functions = new List<ObjectiveFunction>();
            functions.Add(new Fonseca(true));
            functions.Add(new Fonseca(false));
            //functions.Add(new functionSch(true));
            //functions.Add(new functionSch(false));
        }
        
        public double GetLowerThreshold()
        {
            return functions.First().Min;
        }
        public double GetUpperThreshold()
        {
            return functions.First().Max;
        }
        public int GetDecisionVariablesCount()
        {
            return functions.First().DecisionVariablesCount;
        }

        internal void EvaluateObjective(Solution child1)
        {
            child1.ObjectiveValue.Clear();
            foreach (ObjectiveFunction f in functions)
            {
                child1.ObjectiveValue.Add(f.Evaluate(child1.DecisionVariables));
            }
        }
        public static TestFunctions GetTestFunctions()
        {
            if (test == null)
            {
                test = new TestFunctions();
            }
            return test;
        }

        internal int GetFunctionCount()
        {
            return functions.Count;
        }
    }
}
