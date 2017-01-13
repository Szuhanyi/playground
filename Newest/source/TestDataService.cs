using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest.source
{
    public class TestDataService
    {
        private static TestDataService instance;
        private TestDataService()
        {


        }
        public static TestDataService GetInstance()
        {
            if (instance == null)
            {
                instance = new TestDataService();
            }
            return instance;
        }
        public Population GetTestPopulation(int length)
        {
            Population pop = new Population();
            
            for(int i = 0; i < length; i++)
            {
                pop.Add(new Individual(i));

            }
            return pop;
        }
    }
}
