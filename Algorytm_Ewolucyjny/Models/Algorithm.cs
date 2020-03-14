using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    class Algorithm
    {
        public List<List<Town>> Generation {protected set; get; }
        public double Pm { protected set; get; }
        public double Px { protected set; get; }
        public EvaluationFunction EvaluationFunction { protected set; get; }       
        public List<(double BestScore, double AvarageScore, double WorstScore)> FinalScore { protected set; get; }
        public virtual void Evaluation(EvaluationFunction evaluationFunction, Population population) { }
    }
}
