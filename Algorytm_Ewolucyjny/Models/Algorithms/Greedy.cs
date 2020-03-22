using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    class Greedy : Algorithm
    {

        public override void Evaluation(EvaluationFunction evaluationFunction, Population population)
        {
            EvaluationFunction = evaluationFunction;
            Generation = new List<Individual>(population.CreatGreedyGeneration());
            SavedPopulation = Generation.AsParallel().Select(x => MakeGreedy(x)).ToList();
            //FinalScore = query.Select(x => evaluationFunction.EvaluateSpecimen(x)).ToList();
            //FinalScore.Sort();

        }

        private Individual MakeGreedy(Individual individual)
        {

            var chromosome = individual.Chromosome;

            var startingTown = chromosome[0];
            var visitedTowns = new HashSet<Town>
            {
                startingTown
            };
            var currentTown = startingTown;

            while (visitedTowns.Count < chromosome.Count)
            {
                var minDistance = Double.MaxValue;
                var minTown = new Town();

                foreach (var town in chromosome)              
                {
                    if (visitedTowns.Contains(town)) continue;

                    var distance = EvaluationFunction.CountDistance(currentTown, town);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        minTown = town;
                    }
                }

                if (minTown.Numer == 0) throw new Exception("Haven't found the closest town");

                visitedTowns.Add(minTown);
                currentTown = minTown;
            }

            var greedyIndividual = new Individual(visitedTowns.ToList());

            EvaluationFunction.EvaluateIndividual(greedyIndividual);

            return greedyIndividual;
        }

        

    }
}
