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
        private List<Individual> successor;

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
            if(genom == null)
            {
                genom = new List<Individual>();
            }
            genom.Add(i);
        }

        /*
         * Returns a new population, which is created by concatenating the two
         * given parameters.
         * */
        public Population Concat(Population p1, Population p2)
        {
            Population p3 = new Population();
            foreach(Individual i in p1)
            {
                p3.Add(i);
            }
            foreach(Individual i in p2)
            {
                p3.Add(i);
            }
            return p3;
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

        //concatenats the second one to the first
        internal void ConcatenateTwoExistingPopulations()
        {
            foreach(Individual i in successor)
            {
                genom.Add(i);
            }
        }

      

        internal void SortBy(int i)
        {
            genom.OrderBy(x => x.Values[i]);            
        }


        internal Individual Last()
        {
            return genom.Last();
            
        }

        internal Individual First()
        {
            return genom.First();
        }

        /***
         * this method should generate another genom, by applying genetic operators 
         * 
         * */
        internal void NextGeneration()
        {           
            successor = new List<Individual>();
            
            foreach(Individual i in genom)
            {
                successor.Add(new Individual(i));
            }

            foreach (GeneticOperator g in genOperator)
            {
                g.MakeChange(successor);
            }
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
