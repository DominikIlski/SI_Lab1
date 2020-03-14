using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    class SelectionAlgorithm
    {

        public EvaluationFunction EvaluationFunction;
        public virtual List<Town> Selection (List<List<Town>> population){ return population[0]; }


    }
}
