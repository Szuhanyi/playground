using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product;

namespace UnitTestProject1
{
    [TestClass]
    public class TestPopulation
    {
        [TestMethod]
        public void PopulationTest()
        {
            Population pop = new Population();            
            Assert.AreEqual(0, pop.getPopulationCount());

            ServiceTestData td = ServiceTestData.getInstance();            
            pop.SetGenom(td.getMockInitialPopulation(10));            
            Assert.AreEqual(10, pop.getPopulationCount());

            Population pop2 = new Population();
            pop2.SetGenom(td.getMockInitialPopulation());
            Population pop3 = pop.Concat(pop2);
            Assert.AreEqual(20, pop3.getPopulationCount());
            
        }

        [TestMethod]
        public void MockDataTest()
        {
            ServiceTestData svd = ServiceTestData.getInstance();
            Population p = new Population();
            p.SetGenom(svd.getMockInitialPopulation());

            Assert.AreEqual(10, p.getPopulationCount());
            ServiceTestFunctions tf = ServiceTestFunctions.GetInstance();
            foreach(Individual i in p)
            {
                Assert.AreEqual(tf.GetDecisionVariablesCount(), i.DecisionVariables.Count);
            }
        }

        [TestMethod]
        public void GenerationTest()
        {
            ServiceTestData svd = ServiceTestData.getInstance();
            Population p = new Population();
            p.SetGenom(svd.getMockInitialPopulation());

            p.NextGeneration();

            p.ConcatenateTwoExistingPopulations();
            Assert.AreEqual(20, p.getPopulationCount());

            ServiceOutput so = ServiceOutput.GetInstance();
            so.SetOutput(new OutputStd());
            //
            //so.SetOutput(new OutputFile())
            so.Write(p.ToReadableFormat());
            Console.WriteLine("asdf");
        }

        [TestMethod]
        public void Nsga2Test()
        {
            Algorithm a = new Nsga2();

        }

    }
}
