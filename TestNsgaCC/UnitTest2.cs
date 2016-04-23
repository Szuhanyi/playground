using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nsga;
namespace TestNsgaCC
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void ResultNotNull()
        {
            int pop = 10;
            int gen = 10;
            Algorithm nsga = new Nsga2();
            Assert.AreNotEqual(nsga.StartEvaluation(pop,gen), null);
        }
    }
}
