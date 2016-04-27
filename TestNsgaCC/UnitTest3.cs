using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsga;
namespace TestNsgaCC
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void InitalPopulationBoundaries()
        {
            Algorithm nsga = new Nsga2();
            int pop = 10;
            int gen = 10;
            TestFunctions funcs = TestFunctions.GetTestFunctions();
            Population p = nsga.StartEvaluation(pop, gen);
            int mistakes = 0;
            for (int i = 0; i < p.GetCount(); i++)
            {
                for(int j = 0; j < p.Get(i).DecisionVariables.Count; j++)
                {
                    if (p.Get(i).DecisionVariables[0] < funcs.GetLowerThreshold()
                        || p.Get(i).DecisionVariables[j] > funcs.GetUpperThreshold())
                    {
                        mistakes++;
                       
                    }
                }
            }
            Assert.AreEqual(mistakes, 0);
        }
        [TestMethod]
        public void OffspringPopulationBoundaries()
        {
            Algorithm nsga = new Nsga2();
            int pop = 10;
            TestFunctions funcs = TestFunctions.GetTestFunctions();
            Population parent = new Population();
            parent.NewPopulation(pop);
            Population p = parent.CreateOffspring();
            int mistakes = 0;
            for (int i = 0; i < p.GetCount(); i++)
            {
                for (int j = 0; j < p.Get(i).DecisionVariables.Count; j++)
                {
                    if (p.Get(i).DecisionVariables[0] < funcs.GetLowerThreshold()
                        || p.Get(i).DecisionVariables[j] > funcs.GetUpperThreshold())
                    {
                        mistakes++;

                    }
                }
            }
            Assert.AreEqual(mistakes, 0);
        }
        [TestMethod]
        public void InitialPopulationBoundaries()
        {
            Algorithm nsga = new Nsga2();
            int pop = 10;
            TestFunctions funcs = TestFunctions.GetTestFunctions();
            Population p = new Population();
            p.NewPopulation(pop);
            int mistakes = 0;
            for (int i = 0; i < p.GetCount(); i++)
            {
                for (int j = 0; j < p.Get(i).DecisionVariables.Count; j++)
                {
                    if (p.Get(i).DecisionVariables[0] < funcs.GetLowerThreshold()
                        || p.Get(i).DecisionVariables[j] > funcs.GetUpperThreshold())
                    {
                        mistakes++;

                    }
                }
            }
            Assert.AreEqual(mistakes, 0);
        }
        [TestMethod]
        public void CombinedPopulationCount()
        {
            int pop = 10;
            Population p1 = new Population();
            p1.NewPopulation(pop);
            Population p2 = new Population();
            p2.NewPopulation(pop);
            Population p3 = p1.Concat(p2);
            Assert.AreEqual(p3.GetCount(), p1.GetCount() + p2.GetCount());
        }
        [TestMethod]
        public void SelectionCountTest()
        {
            int pop = 10;
            Population genom = new Population();
            genom.NewPopulation(pop);
            Population genom2 = new Population();
            genom2.NewPopulation(pop);
            Population pop3 = genom.Concat(genom2);
            
            genom = pop3.Selection();
            Assert.AreEqual(pop3.GetCount() / 2, genom.GetCount());
        }
    }
}
