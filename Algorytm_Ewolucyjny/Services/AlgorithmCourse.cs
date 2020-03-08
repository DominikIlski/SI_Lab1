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
        EvaluationFunction EvaluationFunction { set; get; }
        List<List<Town>> Generation { set; get; }
        bool WasRunning = false;
        public AlgorithmCourse(int popSize, Agglomeration agglomeration)
        {

            PopSize = popSize;
            Population = new Population(popSize, agglomeration);
            EvaluationFunction = new EvaluationFunction(agglomeration.EdgeWeightType);
            Algorithm = new Algorithm();
            Generation = new List<List<Town>>();
            

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
            if(WasRunning)

        }

        private string StringScore

        public double Test()
        {
            
            Population.CreatNewGeneration(Generation);

            

            var testValue = EvaluationFunction.EvaluateSpecimen(Generation[0]);

            return testValue;

        }
    }
}
