﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public interface Algorithm
    {
        void SetPopulation(Population p);
        void ExecuteSelection();
        void Rank();
    }
}
