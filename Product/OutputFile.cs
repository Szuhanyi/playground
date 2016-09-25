using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class OutputFile : Output
    {
        private String fileName;
        public OutputFile()
        {
            fileName = "log.txt";
        }
        public OutputFile(String fileName)
        {
            this.fileName = fileName;
        }
        public void Write(string msg)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(
                    @"C:\Users\gyorgy\test\" + fileName, true))
                {
                    file.WriteLine(msg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Source);
            }
        }
    }
}
