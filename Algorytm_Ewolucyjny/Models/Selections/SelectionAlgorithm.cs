using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    class SelectionAlgorithm
    {

        public EvaluationFunction EvaluationFunction;
        public virtual Individual Selection(List<Individual> list) { return list[0]; }


    }
}
