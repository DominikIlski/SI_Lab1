using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    class CrossingAlgorithm
    {


        public virtual (Individual O1, Individual O2) Crossover(Individual P1, Individual P2) { return (P1, P2); }


    }
}
