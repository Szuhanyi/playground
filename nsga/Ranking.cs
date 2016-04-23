using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsga
{
    class Ranking
    {
        
        private List<List<Solution>> rankings;
       
        public Ranking()
        {
            rankings = new List<List<Solution>>();
        }
        public int GetFrontCount()
        {
            return rankings.Count;
        }
        public List<Solution> GetFront(int index)
        {
            if (index >= rankings.Count)
            {
                rankings.Add(new List<Solution>());
            }
            return rankings.ElementAt(index);
        }
        public void AddIndividual(int rank, Solution individual)
        {
            if (rank >= rankings.Count)
            {
                rankings.Add(new List<Solution>());
            }
            try
            {
                rankings.ElementAt(rank).Add(individual);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
