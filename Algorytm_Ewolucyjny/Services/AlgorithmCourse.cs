using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class AlgorithmCourse
    {

        Population PopulationCreator { set; get; }
        int PopSize { set; get; }
        Algorithm Algorithm { set; get; }
        EvaluationFunction EvaluationFunction { set; get; }
        List<List<Town>> Population { set; get; }

        public AlgorithmCourse(int popSize, Agglomeration agglomeration)
        {

            PopSize = popSize;
            PopulationCreator = new Population(popSize, agglomeration);
            EvaluationFunction = new EvaluationFunction();
            

        }
        

        public void SetAlgorithm(Algorithm algorithm)
        {
            Algorithm = algorithm;
        }


        public double Test()
        {
            var test = new List<List<Town>>(PopSize);
            PopulationCreator.CreatNewGeneration(ref test);

            Population = new List<List<Town>>(test);

            var testValue = EvaluationFunction.EvaluateSpecimen(Population[0]);

            return testValue;

        }
    }
}
