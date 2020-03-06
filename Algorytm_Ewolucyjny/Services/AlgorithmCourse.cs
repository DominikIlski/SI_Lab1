using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class AlgorithmCourse
    {

        Population Population { set; get; }
        int PopSize { set; get; }
        Algorithm Algorithm { set; get; }

        public void SetPopulation(int popSize)
        {
            PopSize = popSize;

        }

        public void SetAlgorithm(Algorithm algorithm)
        {
            Algorithm = algorithm;
        }

    }
}
