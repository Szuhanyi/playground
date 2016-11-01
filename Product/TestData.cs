
using System.Collections.Generic;

namespace Product
{
    public class TestData
    {
        private int id;
        private List<double> value;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public TestData(List<double> value)
        {
            this.value = value;
        }

        public TestData(List<double> value, int id) : this(value)
        {
            this.id = id;
        }

        public List<double> GetData()
        {
            return value;
        }
    }
}