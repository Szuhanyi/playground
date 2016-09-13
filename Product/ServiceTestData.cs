using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public  class ServiceTestData
    {
        private static List<TestData> initialPopulation;
        private static ServiceTestData instance;
        private ServiceTestData()
        {
            initialPopulation = new List<TestData>();
        }
        public static ServiceTestData getInstance()
        {
            if(instance == null)
            {
                instance = new ServiceTestData();
            }
            return instance;
        }

        public List<TestData> getMockInitialPopulation(int length)
        {
            
            ServiceTestFunctions service = ServiceTestFunctions.GetInstance();

            double min = service.GetMin();
            double max = service.GetMax();

            for(int i = 0; i < length; i++)
            {
                initialPopulation.Add(generateValue(min, max));
            }

            return initialPopulation;
        }

        public List<TestData> getMockInitialPopulation()
        {
            int defaultPopulationCount = 10;
            return getMockInitialPopulation(defaultPopulationCount);
        }

        private TestData generateValue(double min, double max)
        {
            return new TestData(min);
        }
    }
}
