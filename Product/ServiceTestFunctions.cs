using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public  class ServiceTestFunctions
    {
        private static ServiceTestFunctions instance;

        private int numberOfObjectives;

        public double Infinite { get; internal set; }
        public double Delta { get; internal set; }

        private double num;

        private List<ObjectiveFunction> functions;

        public int GetDecisionVariablesCount()
        {
            return numberOfObjectives;
        }

        private ServiceTestFunctions()
        {
            Delta = 0.00001;
            num = 0.0004;
            Infinite = 1000;
            functions = new List<ObjectiveFunction>();
            // for what purpes am I doing this. 
            functions.Add(new Fonseca(true));
            functions.Add(new Fonseca(false));
            numberOfObjectives = functions.First().DecisionVariablesCount; // ?????
           // ServiceOutput sout = ServiceOutput.GetInstance();
            //sout.Write(functions.First().ToReadableFormat());
        }

        public static ServiceTestFunctions GetInstance()
        {
            if(instance == null)
            {
                instance = new ServiceTestFunctions();
            }
            return instance;
        }

        internal double GetMum()
        {
            return num;
        }

        internal double GetMin()
        {
            return functions.First().Min;
        }

        internal double GetMax()
        {
            return functions.First().Max;
        }

        internal int Count()
        {
            return functions.Count;
        }

        public void EvaluateObjective(Individual i)
        {
            //value for each function// cause we do this... and not otherwise... lalla.. alive daft punk
            i.ObjectiveValue.Clear();

            foreach (ObjectiveFunction f in functions)
            {
                i.ObjectiveValue.Add(f.Evaluate(i.DecisionVariables));
            }

        }
    }
}
