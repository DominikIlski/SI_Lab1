using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public class Individual
    {

        public List<Town> Chromosome { set; get; }
        public double? Score { set; get; }


        public Individual(List<Town> chromosome, double? score = null)
        {

            Chromosome = new List<Town>(chromosome);
            Score = score;

        }

        public Individual(Individual other)
        {

            Chromosome = new List<Town>(other.Chromosome);
            Score = other.Score;

        }

    }
}
