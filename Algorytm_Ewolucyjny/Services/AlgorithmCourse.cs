using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class AlgorithmCourse
    {

        Population Population { set; get; }
        int PopSize { set; get; }
        Algorithm Algorithm { set; get; }
        EvaluationFunction EvaluationFunction { set; get; }
        
        bool WasRunning = false;
        public AlgorithmCourse(int popSize, Agglomeration agglomeration)
        {

            PopSize = popSize;
            Population = new Population(popSize, agglomeration);
            EvaluationFunction = new EvaluationFunction(agglomeration.EdgeWeightType);
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

        public string GetScoreString()
        {
            
            StringBuilder stringBuilder = new StringBuilder();
            if(WasRunning)
            {
                var querry = Algorithm.FinalScore.Select((x, Index)=> $"Specimen number: {Index} | scored: {x}").ToArray();
                stringBuilder.AppendJoin('\n', querry);
            }

            return stringBuilder.ToString();
        }

       

        
    }
}
