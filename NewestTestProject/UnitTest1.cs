using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newest.source;

namespace NewestTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private TestDataService tds;
        public UnitTest1()
        {
             tds = TestDataService.GetInstance();
        }
        [TestMethod]
        public void TestMethod1()
        {
            //test the creation of algortihm, and its implementations
            Algorithm alg = new Nsga2();
            bool equal = alg is Nsga2;
            Assert.AreEqual(true, equal);

            Population pop = new Population();
            for(int i = 0; i < 5; i++)
            {
                pop.Add(new Individual(i));
                
            }

            Population paretoFront = alg.GetParetoFront(pop);

            Assert.IsTrue(paretoFront.GetCount() > 0);


        }

        [TestMethod]
        public void IndividualTest()
        {
            //test constructors

            Individual i = new Individual();
            Individual i2 = new Individual(i);
            Individual i3 = new Individual(i.GetRank());

            Assert.AreEqual(i.GetRank(), i2.GetRank());
            Assert.AreEqual(i.GetRank(), i3.GetRank());

        }
        [TestMethod]
        public void PopulationTest()
        {
            //constructor
            Population pop1 = new Population();
            Assert.IsTrue(pop1 is Population);

            Individual ind1 = new Individual(1);
            Individual ind2 = new Individual(2);
            pop1.Add(ind1);
            pop1.Add(ind2);

            pop1.Remove(ind1);
            pop1.Remove(ind1);
            pop1.Add(ind1);

            Assert.AreEqual(2, pop1.GetCount());

            Population pop2 = new Population(pop1);
            Assert.AreEqual(pop1.GetCount(), pop2.GetCount());

            //concat

            Population pop3;
            pop3 = pop1.Concat(pop2);
            Assert.AreEqual(pop1.GetCount() + pop2.GetCount(), pop3.GetCount());

            //get
            Individual i1;
            i1 = pop3.GetElementAt(pop3.GetCount());
            Assert.AreEqual(null,i1);

            i1 = pop3.GetElementAt(0);
            Assert.IsTrue(i1 is Individual);

            i1 = pop3.GetElementAt(-1);
            Assert.AreEqual(null, i1);
        }

        [TestMethod]
        public void MutatorTest()
        {
            var count = 100;
            Mutator mutator = Mutator.GetInstance();
            Population pop1 = new Population(tds.GetTestPopulation(count));

            Population pop2 = mutator.PerformMutation(pop1);

            Assert.AreEqual(count, pop2.GetCount());
        }

        [TestMethod]
        public void IOServiceTest()
        {
            IOService ios = IOService.GetInstance();
            Population pop = new Population(tds.GetTestPopulation(10));
            String xml = ios.ParseToXML(pop);
            Assert.AreNotEqual(null, xml);

            String json = ios.ParseToJSON(pop);
            Assert.AreNotEqual(null, json);
            Console.Out.WriteLine(json);
        }


    }
}
