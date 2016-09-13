using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class InitialTest
    {
        [TestMethod]
        public void ConstructionTest()
        {
            ServiceTestData td = ServiceTestData.getInstance();
            Population population = new Population();
             population.SetGenom(td.getMockInitialPopulation());
            Assert.AreEqual(10, population.getPopulationCount());
        }
      
        [TestMethod]
        public void IndividualTest()
        {
            List<Individual> list = new List<Individual>();
            Individual i = null;
            for(int j = 0; j < 5; j++)
            {
                i = new Individual();
                i.Distance = j;
                list.Add(i);
                
            }
            var expectedList = list.OrderBy(x => x.Distance);
            list.Sort();
            Assert.IsTrue(expectedList.SequenceEqual(list));
         
        }
    }
}
