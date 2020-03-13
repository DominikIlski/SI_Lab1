using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Algorithms
{
    class Genetic : Algorithm
    {
       
        public Genetic(double mutation, double crossing)
        {

            Mutation = mutation;
            Crossing = crossing;

        }

    }
}
