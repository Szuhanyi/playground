using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nsga
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEvaluate_Click(object sender, EventArgs e)
        {
            Algorithm nsga = new Nsga2();
            int pop = 10;
            int gen = 10;
            Population p = nsga.StartEvaluation(pop, gen);
            //p.PrintToConsole();
        
        }
    }
}
