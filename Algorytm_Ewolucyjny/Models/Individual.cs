using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public class Individual
    {

        public List<Town> Chromosome { set; get; }
        public double? Score { set; get; }


        public Individual(List<Town> chromosome)
        {

            Chromosome = chromosome;
            Score = null;

        }

    }
}
