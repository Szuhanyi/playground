using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest
{
    public  class ServiceTestData
    {
        private  List<TestData> initialPopulation;
        private static ServiceTestData instance;
        private Random rand;

        public int GetPopulationCount()
        {
            return initialPopulation.Count;
        }

        private ServiceTestData()
        {
            rand = new Random();   
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
            if (initialPopulation == null)
            {
                initialPopulation = new List<TestData>();
                ServiceTestFunctions service = ServiceTestFunctions.GetInstance();

                double min = service.GetMin();
                double max = service.GetMax();
                int n = service.GetDecisionVariablesCount();
                for (int i = 0; i < length; i++)
                {
                    initialPopulation.Add(generateValue(min, max, n, i));
                }
            }
            return initialPopulation;
        }

        public List<TestData> getMockInitialPopulation()
        {
            int defaultPopulationCount = 15;
            return getMockInitialPopulation(defaultPopulationCount);
        }

        private TestData generateValue(double min, double max, int n, int id)
        {
            List<double> data = new List<double>();
        
            for (int j = 0; j < n; j++)
            {
                data.Add(min + (max - min) * rand.NextDouble());
            }
            return new TestData(data, id);
        }
    }
}
