using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class Population : IEnumerable
    {
        private Algorithm algorithm;
        private List<Individual> genom;
        private List<GeneticOperator> genOperator;

        public Population()
        {
            genom = new List<Individual>();
        }
   
     
        
        public String ToReadableFormat()
        {
            StringBuilder sb = new StringBuilder();

            foreach(Individual i in genom)
            {
                sb.Append(i.ToString());
            }
            return sb.ToString();
        }

        internal void Add(Individual i)
        {
            throw new NotImplementedException();
        }

        /*
         * Returns a new population, which is created by concatenating the two
         * given parameters.
         * */
        public Population Concat(Population p1, Population p2)
        {

            return null;
        }

        public void setAlgorithm(Algorithm alg)
        {
            algorithm = alg;   
        }

        /*
         * Sorts genom based on Distance 
         * */
        internal void Sort()
        {            
            this.genom.Sort();
        }

        internal void ConcatenateTwoExistingPopulations()
        {
            throw new NotImplementedException();
        }

      

        internal void SortBy(int i)
        {
            genom.OrderBy(x => x.Values[i]);
            
        }

        internal Individual Last()
        {
            throw new NotImplementedException();
        }

        internal Individual First()
        {
            throw new NotImplementedException();
        }

        internal void NextGeneration()
        {
            throw new NotImplementedException();
        }

        /*
         * Genetic opertors: crossover, mutation, etc.
         * nsga by default uses two of them (crossover 0.9 and mutation 0.1)
         * */
        public void SetGeneticOperators(List<GeneticOperator> op)
        {
            genOperator = op;
        }
        // TODO: read the Attributes documentation
        // inconsistent accessability or something like that.

        public void SetGenom(List<TestData> gen)
        {
            if (genom == null)
            {
                genom = new List<Individual>();
            }
            foreach(TestData t in gen)
            {
                genom.Add(new Individual(t));
            }                       
        }
        public int getPopulationCount()
        {
            if(genom == null)
            {
                genom = new List<Individual>();
            }
            return genom.Count;
        }

        
        public PopulationEnum GetEnumerator()
        {
            return new PopulationEnum(genom);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (PopulationEnum)GetEnumerator();
        }
    }

    public class PopulationEnum : IEnumerator
    {
        public List<Individual> genom;
        int position = -1;

        public PopulationEnum(List<Individual> genom)
        {
            this.genom = genom;
        }
         
        public object Current
        {
            get
            {
                return genom.ElementAt(position);
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < genom.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
