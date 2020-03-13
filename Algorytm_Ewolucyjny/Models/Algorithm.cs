using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    class Algorithm
    {
        public List<List<Town>> Generation {protected set; get; }
        public double Mutation { protected set; get; }
        public double Crossing { protected set; get; }
        public EvaluationFunction EvaluationFunction { protected set; get; }       
        public List<double> FinalScore { protected set; get; }
        public virtual void Evaluation(EvaluationFunction evaluationFunction, Population population) { }
    }
}
