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
    }
}
