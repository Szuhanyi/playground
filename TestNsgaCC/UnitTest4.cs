using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsga;
using System.Collections.Generic;
namespace TestNsgaCC
{
    [TestClass]
    public class GeneticOperatorsTest
    {
        [TestMethod]
        public void CrossoverTest()
        {
            GeneticOperators operators = new GeneticOperators();
            int pop = 10;
            Population genom = new Population();
            genom.NewPopulation(pop);
            List<Solution> newGenom = new List<Solution>();

            for (int i = 0; i < genom.GetCount() - 1; i += 2)
            {
                List<Solution> list = operators.Crossover(genom.Get(i), genom.Get(i + 1));
                foreach (Solution s in list)
                {
                    newGenom.Add(s);
                }
            }
            if (newGenom.Count < genom.GetCount())
            {
                newGenom.Add(genom.Get(genom.GetCount()-1));
            }
            double eps = 0.001;

            int mistakes = 0;           
            List<Solution>.Enumerator e = newGenom.GetEnumerator();
            int j = -1; 
            while (e.MoveNext())
            {
                j++;
                for (int i = 0; i < e.Current.DecisionVariables.Count; i++)
                {
                    if (Math.Abs(e.Current.DecisionVariables[i] - genom.Get(j).DecisionVariables[i]) < eps)
                    {
                        mistakes++;
                    }
                }
            }
            Assert.AreEqual(0, mistakes);

        }
    }
}
