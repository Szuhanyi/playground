using System;

namespace Newest.source
{
    internal class GlobalValues
    {
        private static GlobalValues instance;
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