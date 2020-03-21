using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class Population
    {
        public int PopSize { set; get; }

        Agglomeration Agglomeration { set; get; }

        EvaluationFunction EvaluationFunction;

        public Population(int popSize, Agglomeration agglomeration, EvaluationFunction evaluationFunction)
        {
            PopSize = popSize;
            Agglomeration = agglomeration;
            EvaluationFunction = evaluationFunction;
            
        }


        

        public List<(List<Town> geneticCode , double? score)> CreatNewGeneration()
        {
            
            var specimenElement = Agglomeration.GetAgglomeration();
            var generation = new List<(List<Town> geneticCode, double? score)>();
            
            for (int i = 0; i < PopSize; i++)
            {
                generation.Add((new List<Town>(specimenElement), null));
                generation[i].geneticCode.Shuffle();
                generation[i] = (generation[i].geneticCode, EvaluationFunction.EvaluateSpecimen(generation[i].geneticCode));


            }
           
            return generation;

        }

        public List<(List<Town> geneticCode , double? score)> CreatGreedyGeneration()
        {
            var townList = Agglomeration.GetAgglomeration();
            var greedyGeneration = new List(<Town> geneticCode , double? score)>();

            for (int i = 0; i < townList.Count; i++)
            {
                var townHelper = new(List<Town> geneticCode , double? score)(townList);
                townHelper.geneticCode.Swap(0, i);
                greedyGeneration.Add(townHelper);


            }
            
            return greedyGeneration;
        }





    }
}
