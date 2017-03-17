using System;

namespace Newest.source
{
    internal class GlobalValues
    {
        private static GlobalValues instance;
        public int ITERATION_COUNT {get; set;}

        private GlobalValues()
        {
            ITERATION_COUNT = 5;
        }
        internal static GlobalValues GetInstance()
        {
            if(instance == null)
            {
                instance = new GlobalValues();
            }
            return instance;
        }
    }
}