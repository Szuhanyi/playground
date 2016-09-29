
using System.Collections.Generic;

namespace Product
{
    public class TestData
    {
        private List<double> value;

        public TestData(List<double> value)
        {
            this.value = value;
        }
        public List<double> GetData()
        {
            return value;
        }
    }
}