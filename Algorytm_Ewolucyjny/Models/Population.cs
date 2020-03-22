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
        EvaluationFunction EvaluationFunction { set; get; }

        public Population(int popSize, Agglomeration agglomeration, EvaluationFunction evaluationFunction)
        {
            PopSize = popSize;
            Agglomeration = agglomeration;
            EvaluationFunction = evaluationFunction;
            
        }


        

        public List<Individual> CreatNewGeneration()
        {
            
            var firstChormosome = Agglomeration.GetAgglomeration();
            var generation = new List<Individual>();
            
            for (int i = 0; i < PopSize; i++)
            {
                generation.Add(new Individual(firstChormosome));
                generation[i].Chromosome.Shuffle();          
                EvaluationFunction.EvaluateIndividual(generation[i]);
            }
           
           

            return generation;

        }

        public List<Individual> CreatGreedyGeneration()
        {
            var firstChormosome = Agglomeration.GetAgglomeration();
            var greedyGeneration = new List<Individual>();

            for (int i = 0; i < PopSize; i++)
            {
                var townHelper = new List<Town>(firstChormosome);
                townHelper.Swap(0, i);
                greedyGeneration.Add(new Individual(townHelper));
                //EvaluationFunction.EvaluateIndividual(greedyGeneration[i]);

            }

            
            return greedyGeneration;
        }


        public List<Individual> CreateMixedPopulation()
        {

            var firstChormosome = Agglomeration.GetAgglomeration();
            var generation = new List<Individual>();
            Algorithm greedy = new Greedy();

            int randomPopSize = (int)Math.Floor(PopSize - (PopSize * 0.15));

            int greedyPopSize = PopSize - randomPopSize;

            PopSize = greedyPopSize;

            greedy.Evaluation(EvaluationFunction, this);

            generation.AddRange(greedy.SavedPopulation);


            for (int i = 0; i < PopSize; i++)
            {
                generation.Add(new Individual(firstChormosome));
                generation[i].Chromosome.Shuffle();
                EvaluationFunction.EvaluateIndividual(generation[i]);
            }

            return generation;
        }


    }
}
