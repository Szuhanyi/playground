
namespace Product
{
    public class TestData
    {
        private double min;

        public TestData(double min)
        {
            this.min = min;
        }
        public double GetValue()
        {
            return min;
        }
    }
}