using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newest.source
{
    public class IOService
    {
        private static IOService instance;

        private IOService()
        {

        }

        public static IOService  GetInstance()
        {
            if(instance == null)
            {
                instance = new IOService();
            }
            return instance;
        }
        public String ParseToXML(Population p)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < p.GetCount(); i++)
            {
                //for now its is going to be ok
                sb.Append(p.GetElementAt(i).ToString());
            }
            return sb.ToString();
        }
        public String ParseToJSON(Population p)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < p.GetCount(); i++)
            {
                //for now its is going to be ok
                sb.Append(p.GetElementAt(i).ToString());
            }

            return sb.ToString();
            
        }
    }
}
