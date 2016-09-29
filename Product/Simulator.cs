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
        
        public void GenerateInitialPopulation(int populationCount)
        {
            population = new Population();
            ServiceTestData td = ServiceTestData.getInstance();
            population.SetGenom(td.getMockInitialPopulation(populationCount));
        }      

        public void RunEvolution(int iterationCount)
        {

            ServiceOutput output = ServiceOutput.GetInstance();
            //output.SetOutput(new OutputFile());

            output.SetOutput(new OutputFile());

            output.Write("Starting new evolution. Iteration count : " 
                + iterationCount);
            algorithm.SetPopulation(population);

            for (int i = 0; i < iterationCount; i++)
            {
                population.NextGeneration();
                output.Write(population);

                population.ConcatenateTwoExistingPopulations();
                output.Write(population);
               
                algorithm.Rank();
                output.Write(population);

                algorithm.ExecuteSelection();
                output.Write(population);

                output.Write(i + 1 +"th  iteration. \r\n");
           }
            
        }
        
    }
}