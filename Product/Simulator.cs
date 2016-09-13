using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    class Simulator
    {
        private Algorithm algorithm;
        private Population population;
        public Simulator()
        {            
            algorithm = new Nsga2();
        }
        
        public void GenerateInitialPopulation()
        {
            population = new Population();
            ServiceTestData td = ServiceTestData.getInstance();
            population.SetGenom(td.getMockInitialPopulation());
        }

        public void RunEvolution(int iterationCount)
        {

            ServiceOutput output = ServiceOutput.GetInstance();
            output.Write("Starting new evolution. Iteration count : " 
                + iterationCount);

            for (int i = 0; i < iterationCount; i++)
            {
                population.NextGeneration();
                output.Write(population);

                population.ConcatenateTwoExistingPopulations();
                output.Write(population);

                algorithm.Rank(population);
                output.Write(population);

                algorithm.ExecuteSelection(population);
                output.Write(population);

                output.Write(i + 1 +"th  iteration. \r\n");
           }
            
        }

        
    }
}