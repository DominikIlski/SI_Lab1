using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class AlgorithmCourse
    {

        Population Population { set; get; }

        Algorithm Algorithm { set; get; }
        EvaluationFunction EvaluationFunction { set; get; }
        
        bool WasRunning = false;
        public AlgorithmCourse(int popSize, Agglomeration agglomeration)
        {

            
            
            EvaluationFunction = new EvaluationFunction(agglomeration.EdgeWeightType);
            Population = new Population(popSize, agglomeration, EvaluationFunction);
            Algorithm = new Algorithm();
            
            

        }
        

        public void SetAlgorithm(Algorithm algorithm)
        {
            Algorithm = algorithm;
        }

        public void Run()
        {
            
            Algorithm.Evaluation(EvaluationFunction, Population);
            WasRunning = true;
            

        }

        public List<(double BestScore, double AvarageScore, double WorstScore)> GetScores()
        {

            /* StringBuilder stringBuilder = new StringBuilder();
             if(WasRunning)
             {
                 var querry = Algorithm.FinalScore.Select((x, Index)=> $"Specimen number: {Index} | scored: {x.BestScore}").ToArray();
                 stringBuilder.AppendJoin('\n', querry);
             }

             return stringBuilder.ToString();*/
            return Algorithm.FinalScore;
        }

       

        
    }
}
