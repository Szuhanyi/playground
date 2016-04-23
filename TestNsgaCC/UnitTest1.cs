using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestNsgaCC
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ResultLength()
        {

            int popCount = 10;
            int generations = 10;
            
            nsga.Algorithm alg = new nsga.Nsga2();
            nsga.Population p = alg.StartEvaluation(popCount, generations);
            Assert.AreEqual(p.GetCount(), popCount);
           // Assert.AreEqual(1, 1);
           
        }
    }
}
