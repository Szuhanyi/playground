using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Nsga2Test()
        {

            Algorithm a = new Nsga2();
            ServiceTestData td = ServiceTestData.getInstance();
            Population p = new Population();
            var asdf = td.getMockInitialPopulation(3);           

            p.SetGenom(td.getMockInitialPopulation(3));

            ServiceTestFunctions tf = ServiceTestFunctions.GetInstance();

            foreach (Individual i in p)
            {
                tf.EvaluateObjective(i);
            }
            a.SetPopulation(p);
            a.Rank();
            ServiceOutput so = ServiceOutput.GetInstance();
            //foreach (Individual i in p)
            //{
            //    so.Write(i.ToReadableFormat());
            //}
            Assert.AreEqual(td.GetPopulationCount(), asdf.Count);

            a.ExecuteSelection();
            
            foreach(Individual i in p)
            {
                so.Write(i.ToReadableFormat());
            }

        }

        [TestMethod]
        public void FastNonDominatedSortTest()
        {

        }
        [TestMethod]
        public void SortByITest()
        {

        }

        [TestMethod]
        public void SelectionTest()
        {

        }
    }
}
