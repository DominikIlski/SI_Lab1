using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    class Greedy : Algorithm
    {

        public override void Evaluation(EvaluationFunction evaluationFunction, Population population, double Mutation = 0, double Crossing = 0)
        {
            EvaluationFunction = evaluationFunction;
            Generation = new List<List<Town>>(population.CreatNewGeneration());
            var query = Generation.AsParallel().Select(x => MakeGreedy(x)).ToList();
            FinalScore = query.Select(x => evaluationFunction.EvaluateSpecimen(x)).ToList();
            FinalScore.Sort();

        }

        private List<Town> MakeGreedy(List<Town> specimen)
        {
            var startingTown = specimen[0];
            var visitedTowns = new HashSet<Town>
            {
                startingTown
            };
            var currentTown = startingTown;

            while (visitedTowns.Count < specimen.Count)
            {
                var minDistance = Double.MaxValue;
                var minTown = new Town();

                foreach (var town in specimen)              
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

            return visitedTowns.ToList();
        }


    }
}
